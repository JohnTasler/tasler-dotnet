using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using Tasler.Interop.User;

namespace Tasler.Interop;

public class WindowMessageBroadcastProcessor : WindowMessageRedirector
{
	private const int MaximumWaitForSystemEventsMilliseconds = 200;

	#region Instance Fields
	private WindowMessageProcessor? _innerProcessor;
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

	public SafeHwnd WindowHandle
	{
		get
		{
			return _innerProcessor is not null
				? _innerProcessor.WindowHandle
				: new SafeHwnd();
		}
	}

	#endregion Properties

	#region Overrides

	public override nint WindowProcedure
	{
		get
		{
			return _innerProcessor is not null
				? _innerProcessor.WindowProcedure
				: nint.Zero;
		}
	}

	protected override void OnHasEventSubscribersChanged()
	{
		if (this.HasEventSubscribers)
		{
			Debug.Assert(_innerProcessor is null);
			this.CreateInnerProcessor();
		}
		else
		{
			_innerProcessor?.Detach();
			_innerProcessor = null;
		}
	}

	#endregion Overrides

	#region Private Implementation

	private void CreateInnerProcessor()
	{
		Debug.Assert(_innerProcessor == null);

		if (_windowUsage == null)
			_windowUsage = WindowUsage.Auto;

		var windowHandleToSubclass = new SafeHwnd();

		if (_windowUsage == WindowUsage.Auto)
		{
			var eventWaitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
			Action action = () =>
			{
				var bestMatchWindowHandle = new SafeHwnd();
				UserApi.EnumCurrentThreadWindows(hwnd =>
					{
						var style = hwnd.GetWindowStyle();
						if (style.HasFlag(WS.Popup | WS.Overlapped))
						{
							if (bestMatchWindowHandle.IsInvalid)
								bestMatchWindowHandle = hwnd;

							// Scan the window title for known name substring
							if (hwnd.GetWindowText().Contains("BroadcastEvent"))
							{
								windowHandleToSubclass = hwnd;
								return false;
							}
						}

						// Continue enumerating the thread windows
						return true;
					}
				);

				if (windowHandleToSubclass.IsInvalid)
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

		if (windowHandleToSubclass.IsInvalid)
		{
			// TODO: Create a STATIC window to subclass.
		}

		// Subclass whichever window handle we found or created
		Debug.Assert(!windowHandleToSubclass.IsInvalid);
		_innerProcessor = new WindowMessageSubclass(this);
		_innerProcessor.Attach(windowHandleToSubclass);
	}

	private void DestroyInnerProcessor()
	{
		Debug.Assert(_innerProcessor != null);
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
