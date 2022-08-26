using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Tasler.Interop.Gdi;
using Tasler.Interop.Shell;
using Tasler.Windows.Diagnostics;
using Tasler.Windows.Media.Imaging;

namespace Tasler.Windows.Shell
{
	public class ItemImageFactory : DispatcherObject, IDisposable, ISizeableImageFactory
	{
		#region Instance Fields
		private object lockObject = new object();
		private ItemIdList itemIdList;
		private RequestItem requestItemInProgress;
		private RequestItem requestItemRecent = new RequestItem(Int32Size.Empty);
		#endregion Instance Fields

		#region Construction / Finalization
		public ItemImageFactory(ItemIdList itemIdList)
		{
			if (itemIdList.Value == IntPtr.Zero)
				throw new ArgumentNullException("itemIdList");
			this.itemIdList = itemIdList;
		}

		~ItemImageFactory()
		{
			if (!this.IsDisposed)
				this.Dispose();
		}
		#endregion Construction / Finalization

		#region IDisposable Members
		public void Dispose()
		{
			lock (this.lockObject)
			{
				this.itemIdList.Dispose();
				this.requestItemInProgress = null;
			}
			GC.SuppressFinalize(this);
		}
		#endregion IDisposable Members

		#region ISizeableImageFactory Members

		public void RequestImageSource(Int32Size size)
		{
			// If the most recent image has the same size, raise the Loaded event
			if (this.requestItemRecent.Size == size)
			{
				if (this.Loaded != null)
					this.Loaded(this, new SizeableImageLoadedEventArgs(this.requestItemRecent.BitmapSource));
				return;
			}

			// If an image of the same size is being processed, ignore the request
			lock (this.lockObject)
				if (this.requestItemInProgress != null && this.requestItemInProgress.Size == size)
					return;

			Debug.WriteLine(
				string.Format("{0:X8} ItemImageFactory.RequestImageSource: size={1}x{2}",
				ThreadIdleCounter.Instance.Counter, size.Width, size.Height));

			lock (this.lockObject)
				this.requestItemInProgress = new RequestItem(size);
			ThreadPool.QueueUserWorkItem(this.ThreadProc);
		}

		public event EventHandler<SizeableImageLoadedEventArgs> Loaded;

		public event EventHandler<SizeableImageFailedEventArgs> Failed;

		#endregion ISizeableImageFactory Members

		#region Private Implementation
		private bool IsDisposed
		{
			get
			{
				lock (this.lockObject)
					return this.itemIdList.Value == IntPtr.Zero;
			}
		}

		private void ThreadProc(object param)
		{
			Int32Size size = new Int32Size();
			IShellItemImageFactory imageFactory = null;
			lock (this.lockObject)
			{
				if (this.IsDisposed)
				{
					Debug.WriteLine("ItemImageFactory.ThreadProc: this.IsDisposed is true.");
					return;
				}

				if (this.requestItemInProgress == null)
				{
					Debug.WriteLine("ItemImageFactory.ThreadProc: this.requestItemInProgress is null.");
					return;
				}

				Guid iid = typeof(IShellItemImageFactory).GUID;
				imageFactory = (IShellItemImageFactory)ShellApi.SHCreateItemFromIDList(this.itemIdList, ref iid);
				size = this.requestItemInProgress.Size;
				this.requestItemInProgress.Thread = Thread.CurrentThread;
				this.requestItemInProgress.Thread.Name = this.GetType().FullName;
				this.requestItemInProgress.Thread.SetApartmentState(ApartmentState.MTA);
			}

#if DEBUG
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
#endif // DEBUG

			IntPtr hBitmap;
			int hr = imageFactory.GetImage(size.ToSIZE(), SIIGB.BiggerSizeOk, out hBitmap);

#if DEBUG
				stopwatch.Stop();
				Debug.WriteLine(
					string.Format("ItemImageFactory.ThreadProc: IShellItemImageFactory.GetImage({0}x{1}) took {2:X16} ticks. ({3} ms)",
						size.Width, size.Height, stopwatch.ElapsedTicks, stopwatch.ElapsedMilliseconds));
#endif // DEBUG

			// Try just the icon if the thumbnail failed
			if (hr != 0)
			{
				Debug.WriteLine(
					string.Format("ItemImageFactory.ThreadProc: IShellItemImageFactory.GetImage({0}x{1}) returned {2:X8} for SIIGB.BiggerSizeOk",
						size.Width, size.Height, hr));

				if (this.IsDisposed)
				{
					Debug.WriteLine("ItemImageFactory.ThreadProc: this.IsDisposed is true.");
					return;
				}

				hr = imageFactory.GetImage(size.ToSIZE(), SIIGB.BiggerSizeOk | SIIGB.IconOnly, out hBitmap);
			}

			// Notify main thread of success or failure
			if (hr == 0)
			{
				base.Dispatcher.BeginInvoke(new Action<Int32Size, IntPtr>(this.OnLoaded), size, hBitmap);
			}
			else
			{
				Debug.WriteLine(
					string.Format("ItemImageFactory.ThreadProc: IShellItemImageFactory.GetImage({0}x{1}) returned {2:X8} for SIIGB.IconOnly",
						size.Width, size.Height, hr));

				SizeableImageFailedEventArgs args = new SizeableImageFailedEventArgs(Marshal.GetExceptionForHR(hr));
				base.Dispatcher.BeginInvoke(new Action<SizeableImageFailedEventArgs>(this.OnFailed), args);
			}
		}

		private Int32Size GetBitmapSize(IntPtr hBitmap)
		{
			// Get the actual dimensions of the specified hBitmap
			BITMAP bitmap;
			int result = GdiApi.GetObject(hBitmap, Marshal.SizeOf(typeof(BITMAP)), out bitmap);
			if (result == 0)
				throw new Win32Exception();
			return new Int32Size(bitmap.width, bitmap.height);
		}

		private void OnLoaded(Int32Size size, IntPtr hBitmap)
		{
			Debug.Assert(base.CheckAccess());
			base.VerifyAccess();

			// Create a new WorkItem to record the recent size and bitmapSource
			RequestItem workItemNew = new RequestItem(size);

			// Get the actual dimensions of the specified hBitmap
			Int32Size actualSize = this.GetBitmapSize(hBitmap);

			// Create the BitmapSource from the hBitmap
			Int32Rect sourceRect = new Int32Rect(0, 0, actualSize.Width, actualSize.Height);
			workItemNew.BitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
				hBitmap, IntPtr.Zero, sourceRect, BitmapSizeOptions.FromEmptyOptions());

			// Save the new recent work item
			this.requestItemRecent = workItemNew;

			// Clear the work item in progress
			lock (this.lockObject)
				this.requestItemInProgress = null;

			// Raise the event if a handler is registered
			if (this.Loaded != null)
			{
				SizeableImageLoadedEventArgs args = new SizeableImageLoadedEventArgs(workItemNew.BitmapSource);
				this.Loaded(this, args);
			}
		}

		private void OnFailed(SizeableImageFailedEventArgs e)
		{
			Debug.WriteLine("ItemImageFactory.OnFailed: ExceptionMessage=" + e.Exception.Message);
			Debug.Assert(base.CheckAccess());
			base.VerifyAccess();

			// Clear the work item in progress
			lock (this.lockObject)
				this.requestItemInProgress = null;

			// Raise the event if any handlers are registered
			if (this.Failed != null)
				this.Failed(this, e);
		}
		#endregion Private Implementation

		#region Nested Types
		private class RequestItem
		{
			#region Instance Fields
			public Thread Thread;
			public Int32Size Size;
			public BitmapSource BitmapSource;
			#endregion Instance Fields

			#region Construction
			public RequestItem(Int32Size size)
			{
				this.Size = size;
			}
			#endregion Construction
		}
		#endregion Nested Types
	}
}
