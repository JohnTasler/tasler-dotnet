using System.ComponentModel;
using System.Runtime.InteropServices;
using Tasler.ComponentModel;
using Tasler.Interop.User;

namespace Tasler.Interop;

public abstract class WindowMessageRedirector
{
	#region Instance Fields
	private readonly EventSubscriberDictionary<int, EventHandler<WindowMessageEventArgs>> _eventSubscribers;
	private WndProc? _wndProc;
	private nint _wndProcNative;
	private bool _hadEventSubscribers;
	#endregion Instance Fields

	#region Constructors
	protected WindowMessageRedirector()
	{
		_eventSubscribers = new(new SortedDictionary<int, EventSubscriber<EventHandler<WindowMessageEventArgs>>>()!);
		_eventSubscribers.PropertyChanged += this.EventSubscribers_PropertyChanged;
	}

	protected WindowMessageRedirector(WindowMessageRedirector outerRedirector)
	{
		_eventSubscribers = outerRedirector._eventSubscribers;
		if (_eventSubscribers.Count != 0)
		{
			_hadEventSubscribers = true;
			_eventSubscribers.PropertyChanged += this.EventSubscribers_PropertyChanged;

			this.OnHasEventSubscribersChanged();
		}
	}
	#endregion Constructors

	#region Properties

	public EventSubscriber<EventHandler<WindowMessageEventArgs>> this[int messageId]
	{
		get => _eventSubscribers[messageId]!;
		set => _eventSubscribers[messageId] = value;
	}

	public EventSubscriber<EventHandler<WindowMessageEventArgs>> this[WM message]
	{
		get => this[(int)message];
		set => this[(int)message] = value;
	}

	public virtual nint WindowProcedure
	{
		get
		{
			if (_wndProc is null)
			{
				_wndProc = this.WndProc;
			}

			if (_wndProcNative == nint.Zero)
			{
				nint wndProcNative(nint h, int m, nint w, nint l)
				{
					return _wndProc?.Invoke(new SafeHwnd { Handle = h }, m, w, l) ?? nint.Zero;
				}

				_wndProcNative = Marshal.GetFunctionPointerForDelegate(wndProcNative);
			}

			return _wndProcNative;
		}
	}

	protected WndProcNative? OriginalWindowProcedure { get; set; }

	protected bool HasEventSubscribers
	{
		get { return _eventSubscribers?.Count != 0; }
	}

	#endregion Properties

	#region Protected Methods
	protected void ClearWindowProcedure()
	{
		_wndProc = null;
		_wndProcNative = nint.Zero;
	}
	#endregion Protected Methods

	#region Overridables

	protected virtual void OnHasEventSubscribersChanged()
	{
	}

	protected virtual nint OnRedirecting(SafeHwnd hwnd, int message, nint wParam, nint lParam, ref bool handled)
	{
		return nint.Zero;
	}

	protected virtual nint OnRedirected(SafeHwnd hwnd, int message, nint wParam, nint lParam, ref bool handled)
	{
		return nint.Zero;
	}

	#endregion Overridables

	#region Private Implementation

	private nint WndProc(SafeHwnd hwnd, int message, nint wParam, nint lParam)
	{
		var result = this.Redirect(hwnd, message, wParam, lParam, out var handled);
		return result;
	}

	private nint Redirect(SafeHwnd hwnd, int message, nint wParam, nint lParam, out bool handled)
	{
		var wasHandled = false;

		// Call the pre-redirect virtual method
		var result = this.OnRedirecting(hwnd, message, wParam, lParam, ref wasHandled);

		// Only redirect the message if the pre-redirect virtual method did not indicate that it handled the message
		if (!wasHandled)
		{
			EventSubscriber<EventHandler<WindowMessageEventArgs>> subscriber;
			if (_eventSubscribers.TryGetValue(message, out subscriber!))
			{
				if (subscriber.Handler is not null)
				{
					nint originalWndProc(SafeHwnd h, int m, nint w, nint l)
					{
						return this.OriginalWindowProcedure?.Invoke(h.Handle, m, w, l) ?? nint.Zero;
					}

					var args = new WindowMessageEventArgs(originalWndProc, hwnd, message, wParam, lParam);
					subscriber.Handler(this, args);
					if (args.Handled)
					{
						wasHandled = true;
						result = args.Result;
					}
				}
			}
		}

		// Call the post-redirect virtual method
		if (!wasHandled)
			result = this.OnRedirecting(hwnd, message, wParam, lParam, ref wasHandled);
		else
			this.OnRedirecting(hwnd, message, wParam, lParam, ref wasHandled);

		// Call the default or original window procedure
		if (!wasHandled)
		{
			if (this.OriginalWindowProcedure is null)
				result = UserApi.DefWindowProc(hwnd, message, wParam, lParam);
			else
				result = hwnd.CallWindowProc(this.OriginalWindowProcedure, message, wParam, lParam);

			wasHandled = true;
		}

		// Set the out parameter and return the result
		handled = wasHandled;
		return result;
	}

	#endregion Private Implementation

	#region Event Handlers
	private void EventSubscribers_PropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (e.PropertyName == nameof(_eventSubscribers.Count))
		{
			var hasEventSubscribers = this.HasEventSubscribers;
			if (_hadEventSubscribers != hasEventSubscribers)
			{
				_hadEventSubscribers = hasEventSubscribers;
				this.OnHasEventSubscribersChanged();
			}
		}
	}
	#endregion Event Handlers
}
