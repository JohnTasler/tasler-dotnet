using System.Threading;

#if WINDOWS_UWP
using Dispatcher = Windows.UI.Core.CoreDispatcher;
namespace Tasler.UI.Core
#elif WINDOWS_WPF
using System.Windows.Threading;
namespace Tasler.Windows.Threading
#endif
{
	public abstract class DispatcherThreadBase
	{
		#region Static Fields
		private static int _count = 0;
		#endregion Static Fields

		#region Instance Fields
		private Dispatcher _dispatcher;
		#endregion Instance Fields

		protected DispatcherThreadBase() : this(null)
		{
		}

		protected DispatcherThreadBase(string threadName)
		{
			this.ThreadName = threadName ??
				$"{Interlocked.Increment(ref _count)} {this.GetType().Name}";
		}

		#region Properties

		public Dispatcher Dispatcher
		{
			get { return this._dispatcher; }
		}

		public string ThreadName { get; }

		#endregion Properties

		#region Methods

		public void Start()
		{
			this.Start(ApartmentState.STA);
		}

		public void Start(ApartmentState apartmentState)
		{
			if (this.Dispatcher == null)
			{
				AutoResetEvent dispatcherCreatedEvent = null;

				Thread thread = new Thread(this.ThreadProc);
				thread.SetApartmentState(apartmentState);
				thread.Name = this.ThreadName;
				dispatcherCreatedEvent = new AutoResetEvent(false);
				thread.Start(dispatcherCreatedEvent);

				if (dispatcherCreatedEvent != null)
					dispatcherCreatedEvent.WaitOne();
			}
		}

		public abstract void Shutdown();

		public abstract void VerifyThreadAccess();

		public abstract bool HasThreadAccess { get; }

		#endregion Methods

		#region Overridables

		protected virtual void OnDispatcherAttached()
		{
		}

		protected virtual void OnDispatcherDetaching()
		{
		}

		protected abstract Dispatcher CreateDispatcher();

		protected abstract void EnterDispatcherLoop();

		#endregion Overridables

		#region Private Implementation

		private void ThreadProc(object dispatcherCreatedEventObject)
		{
			Interlocked.Exchange(ref _dispatcher, this.CreateDispatcher());

			((EventWaitHandle)dispatcherCreatedEventObject).Set();
			this.OnDispatcherAttached();

			this.EnterDispatcherLoop();

			this.OnDispatcherDetaching();

			Interlocked.Exchange(ref _dispatcher, null);
		}

		#endregion Private Implementation
	}
}
