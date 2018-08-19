using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Tasler.Interop.User;

namespace Tasler.Interop
{
	public class WindowMessageBroadcastProcessor : WindowMessageRedirector
	{
		private const int MaximumWaitForSystemEventsMilliseconds = 200;

		#region Instance Fields
		private WindowMessageProcessor _innerProcessor;
		private WindowUsage? _windowUsage;
		#endregion Instance Fields

		#region Constructors
		private WindowMessageBroadcastProcessor()
		{
		}
		#endregion Constructors

		#region Singleton Instance
		public static WindowMessageBroadcastProcessor Instance { get; } = new WindowMessageBroadcastProcessor();
		#endregion Singleton Instance

		#region Properties

		public IntPtr WindowHandle
		{
			get
			{
				return this._innerProcessor != null
					? this._innerProcessor.WindowHandle
					: IntPtr.Zero;
			}
		}

		#endregion Properties

		#region Overrides

		public override IntPtr WindowProcedure
		{
			get
			{
				return this._innerProcessor != null
					? this._innerProcessor.WindowProcedure
					: IntPtr.Zero;
			}
		}

		protected override void OnHasEventSubscribersChanged()
		{
			if (this.HasEventSubscribers)
			{
				Debug.Assert(this._innerProcessor == null);
				this.CreateInnerProcessor();
			}
			else
			{
				this._innerProcessor.Detach();
				this._innerProcessor = null;
			}
		}

		#endregion Overrides

		#region Private Implementation

		private void CreateInnerProcessor()
		{
			Debug.Assert(this._innerProcessor == null);

			if (this._windowUsage == null)
				this._windowUsage = WindowUsage.Auto;

			var windowHandleToSubclass = IntPtr.Zero;

			if (this._windowUsage == WindowUsage.Auto)
			{
				var eventWaitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
				Action action = () =>
				{
					var bestMatchWindowHandle = IntPtr.Zero;
					UserApi.EnumCurrentThreadWindows(hwnd =>
						{
							var style = UserApi.GetWindowStyle(new HandleRef(null, hwnd));
							if (style.HasFlag(WS.Popup | WS.Overlapped))
							{
								if (bestMatchWindowHandle == IntPtr.Zero)
									bestMatchWindowHandle = hwnd;

								// Scan the window title for known name substring
								if (UserApi.GetWindowText(hwnd).Contains("BroadcastEvent"))
								{
									windowHandleToSubclass = hwnd;
									return false;
								}
							}

							// Continue enumerating the thread windows
							return true;
						}
					);

					if (windowHandleToSubclass == IntPtr.Zero)
						windowHandleToSubclass = bestMatchWindowHandle;

					// Signal the waiting thread
					eventWaitHandle.Set();
				};

				try
				{
					SystemEvents.InvokeOnEventsThread(action);
					eventWaitHandle.WaitOne(MaximumWaitForSystemEventsMilliseconds);
				}
				catch (InvalidOperationException) { }
				catch (ExternalException)         { }
			}

			if (windowHandleToSubclass == IntPtr.Zero)
			{
				// TODO: Create a STATIC window to subclass.
			}

			// Subclass whichever window handle we found or created
			Debug.Assert(windowHandleToSubclass != IntPtr.Zero);
			this._innerProcessor = new WindowMessageSubclass(this);
			this._innerProcessor.Attach(windowHandleToSubclass);
		}

		private void DestroyInnerProcessor()
		{
			Debug.Assert(this._innerProcessor != null);
		}

		#endregion Private Implementation

		#region Nested Types

		public enum WindowUsage
		{
			Auto = 0,
			PrivateShared = 2,
		}

		#endregion Nested Types
	}
}
