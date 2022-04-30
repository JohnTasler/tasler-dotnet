using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;

namespace Tasler.Windows.Threading
{
	public class ThreadedDispatcherObject
	{
		#region Instance Fields
		private object lockObject = new object();
		private Dispatcher dispatcher;
		#endregion Instance Fields

		#region Properties

		public Dispatcher Dispatcher
		{
			get
			{
				lock (this.lockObject)
					return this.dispatcher;
			}
		}

		#endregion Properties

		#region Methods

		public void Start()
		{
			this.Start(ApartmentState.MTA);
		}

		public void Start(ApartmentState apartmentState)
		{
			if (this.Dispatcher == null)
			{
				AutoResetEvent dispatcherCreatedEvent = null;
				lock (this.lockObject)
				{
					if (this.dispatcher == null)
					{
						Thread thread = new Thread(this.ThreadProc);
						thread.SetApartmentState(apartmentState);
						thread.Name = this.ThreadName;
						dispatcherCreatedEvent = new AutoResetEvent(false);
						thread.Start(dispatcherCreatedEvent);
					}
				}

				if (dispatcherCreatedEvent != null)
					dispatcherCreatedEvent.WaitOne();
			}
		}

		public void Shutdown()
		{
			var dispatcher = this.Dispatcher;
			if (dispatcher != null && !dispatcher.HasShutdownStarted && !dispatcher.HasShutdownFinished)
				dispatcher.InvokeShutdown();
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool CheckAccess()
		{
			var dispatcher = this.Dispatcher;
			if (dispatcher != null)
				return dispatcher.CheckAccess();
			return true;
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public void VerifyAccess()
		{
			var dispatcher = this.Dispatcher;
			if (dispatcher != null)
				dispatcher.VerifyAccess();
		}

		#endregion Methods

		#region Overridables

		protected virtual string ThreadName
		{
			get
			{
				return this.GetType().FullName;
			}
		}

		protected virtual void OnDispatcherAttached()
		{
		}

		protected virtual void OnDispatcherDetaching()
		{
		}

		#endregion Overridables

		#region Private Implementation

		private void ThreadProc(object dispatcherCreatedEventObject)
		{
			lock (this.lockObject)
				this.dispatcher = Dispatcher.CurrentDispatcher;

			((EventWaitHandle)dispatcherCreatedEventObject).Set();
			this.OnDispatcherAttached();

			Dispatcher.Run();

			this.OnDispatcherDetaching();

			lock (this.lockObject)
				this.dispatcher = null;
		}

		#endregion Private Implementation
	}
}
