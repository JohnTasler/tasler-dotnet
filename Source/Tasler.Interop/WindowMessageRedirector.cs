using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tasler.Interop.User;

namespace Tasler.Interop
{
	public abstract class WindowMessageRedirector
	{
		#region Instance Fields
		private WndProc wndProc;
		private HandleRef windowProcedure;
		private EventSubscriberDictionary<int, EventHandler<WindowMessageEventArgs>> eventSubscribers;
		private bool hadEventSubscribers;
		#endregion Instance Fields

		#region Constructors
		protected WindowMessageRedirector()
		{
		}

		protected WindowMessageRedirector(WindowMessageRedirector outerRedirector)
		{
			if (outerRedirector != null)
			{
				var eventSubscribers = outerRedirector.eventSubscribers;
				if (eventSubscribers != null && eventSubscribers.Count != 0)
				{
					this.eventSubscribers = eventSubscribers;
					this.hadEventSubscribers = true;
					this.eventSubscribers.PropertyChanged += this.eventSubscribers_PropertyChanged;
					this.OnHasEventSubscribersChanged();
				}
			}
		}
		#endregion Constructors

		#region Properties

		public EventSubscriber<EventHandler<WindowMessageEventArgs>> this[int messageId]
		{
			get
			{
				return this.eventSubscribers != null ? this.eventSubscribers[messageId] : null;
			}

			set
			{
				if (this.eventSubscribers == null)
				{
					if (value == null)
						return;

					this.eventSubscribers = new EventSubscriberDictionary<int, EventHandler<WindowMessageEventArgs>>(
						new SortedDictionary<int, EventSubscriber<EventHandler<WindowMessageEventArgs>>>());
					this.eventSubscribers.PropertyChanged += this.eventSubscribers_PropertyChanged;
				}

				this.eventSubscribers[messageId] = value;
			}
		}

		public EventSubscriber<EventHandler<WindowMessageEventArgs>> this[WM message]
		{
			get { return this[(int)message]; }
			set { this[(int)message] = value; }
		}

		public virtual IntPtr WindowProcedure
		{
			get
			{
				if (this.windowProcedure.Handle == IntPtr.Zero)
				{
					this.wndProc = this.WndProc;
					this.windowProcedure = new HandleRef(this, Marshal.GetFunctionPointerForDelegate(this.wndProc));
				}

				return this.windowProcedure.Handle;
			}
		}

		protected IntPtr OriginalWindowProcedure { get; set; }

		protected bool HasEventSubscribers
		{
			get { return this.eventSubscribers != null && this.eventSubscribers.Count != 0; }
		}

		#endregion Properties

		#region Protected Methods
		protected void ClearWindowProcedure()
		{
			this.wndProc = null;
		}
		#endregion Protected Methods

		#region Overridables

		protected virtual void OnHasEventSubscribersChanged()
		{
		}

		protected virtual IntPtr OnRedirecting(IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			return IntPtr.Zero;
		}

		protected virtual IntPtr OnRedirected(IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			return IntPtr.Zero;
		}

		#endregion Overridables

		#region Private Implementation
		
		private IntPtr WndProc(IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam)
		{
			var handled = false;
			var result = this.Redirect(hwnd, message, wParam, lParam, out handled);
			return result;
		}

		private IntPtr Redirect(IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam, out bool handled)
		{
			var wasHandled = false;

			// Call the pre-redirect virtual method
			var result = this.OnRedirecting(hwnd, message, wParam, lParam, ref wasHandled);

			// Only redirect the message if the pre-redirect virtual method did not indicate that it handled the message
			if (!wasHandled)
			{
				EventSubscriber<EventHandler<WindowMessageEventArgs>> subscriber = null;
				if (this.eventSubscribers.TryGetValue(message, out subscriber))
				{
					if (subscriber != null && subscriber.Handler != null)
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
				if (this.OriginalWindowProcedure == IntPtr.Zero)
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
		private void eventSubscribers_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Count")
			{
				var hasEventSubscribers = this.HasEventSubscribers;
				if (this.hadEventSubscribers != hasEventSubscribers)
				{
					this.hadEventSubscribers = hasEventSubscribers;
					this.OnHasEventSubscribersChanged();
				}
			}
		}
		#endregion Event Handlers
	}
}
