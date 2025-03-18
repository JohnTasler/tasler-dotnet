using System.ComponentModel;
using System.Runtime.InteropServices;
using Tasler.ComponentModel;
using Tasler.Interop.User;

namespace Tasler.Interop;

public abstract class WindowMessageRedirector
{
	#region Instance Fields
	private WndProc? _wndProc;
	private HandleRef? _windowProcedure;
	private EventSubscriberDictionary<int, EventHandler<WindowMessageEventArgs>> _eventSubscribers;
	private bool _hadEventSubscribers;
	#endregion Instance Fields

	#region Constructors
	protected WindowMessageRedirector()
	{
		_eventSubscribers = new EventSubscriberDictionary<int, EventHandler<WindowMessageEventArgs>>(
			new SortedDictionary<int, EventSubscriber<EventHandler<WindowMessageEventArgs>>>());
		_eventSubscribers.PropertyChanged += this.EventSubscribers_PropertyChanged;
	}

	protected WindowMessageRedirector(WindowMessageRedirector outerRedirector)
		: this()
	{
		if (outerRedirector != null)
		{
			var eventSubscribers = outerRedirector._eventSubscribers;
			if (eventSubscribers != null && eventSubscribers.Count != 0)
			{
				_eventSubscribers = eventSubscribers;
				_hadEventSubscribers = true;
				_eventSubscribers.PropertyChanged += this.EventSubscribers_PropertyChanged;
				this.OnHasEventSubscribersChanged();
			}
		}
	}
	#endregion Constructors

	#region Properties

	public EventSubscriber<EventHandler<WindowMessageEventArgs>> this[int messageId]
	{
		get => _eventSubscribers[messageId];
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
			if (_windowProcedure?.Handle == nint.Zero)
			{
				_wndProc = this.WndProc;
				_windowProcedure = new HandleRef(this, Marshal.GetFunctionPointerForDelegate(_wndProc));
			}

			return _windowProcedure?.Handle ?? nint.Zero;
		}
	}

	protected nint OriginalWindowProcedure { get; set; }

	protected bool HasEventSubscribers
	{
		get { return _eventSubscribers.Count != 0; }
	}

	#endregion Properties

	#region Protected Methods
	protected void ClearWindowProcedure()
	{
		_wndProc = null;
	}
	#endregion Protected Methods

	#region Overridables

	protected virtual void OnHasEventSubscribersChanged()
	{
	}

	protected virtual nint OnRedirecting(nint hwnd, int message, nint wParam, nint lParam, ref bool handled)
	{
		return nint.Zero;
	}

	protected virtual nint OnRedirected(nint hwnd, int message, nint wParam, nint lParam, ref bool handled)
	{
		return nint.Zero;
	}

	#endregion Overridables

	#region Private Implementation

	private nint WndProc(nint hwnd, int message, nint wParam, nint lParam)
	{
		var result = this.Redirect(hwnd, message, wParam, lParam, out var handled);
		return result;
	}

	private nint Redirect(nint hwnd, int message, nint wParam, nint lParam, out bool handled)
	{
		var wasHandled = false;

		// Call the pre-redirect virtual method
		var result = this.OnRedirecting(hwnd, message, wParam, lParam, ref wasHandled);

		// Only redirect the message if the pre-redirect virtual method did not indicate that it handled the message
		if (!wasHandled)
		{
			if (_eventSubscribers.TryGetValue(message, out EventSubscriber<EventHandler<WindowMessageEventArgs>> subscriber))
			{
				if (subscriber.Handler is not null)
				{
					var args = new WindowMessageEventArgs(this.OriginalWindowProcedure, hwnd, message, wParam, lParam);
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
			if (this.OriginalWindowProcedure == nint.Zero)
				result = UserApi.DefWindowProc(hwnd, message, wParam, lParam);
			else
				result = UserApi.CallWindowProc(this.OriginalWindowProcedure, hwnd, message, wParam, lParam);

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
