using System.Windows.Threading;

namespace Tasler.Windows.Threading
{
	public class DispatcherThread : DispatcherThreadBase
	{
		#region Constructors

		public DispatcherThread() : base() { }

		public DispatcherThread(string threadName) : base(threadName) { }

		#endregion Constructors

		#region Properties

		public override bool HasThreadAccess
		{
			get { return (this.Dispatcher?.CheckAccess()).Value; }
		}

		#endregion Properties

		#region Methods

		public override void Shutdown()
		{
			var dispatcher = this.Dispatcher;
			if (dispatcher != null && !dispatcher.HasShutdownStarted && !dispatcher.HasShutdownFinished)
				dispatcher.InvokeShutdown();
		}

		public override void VerifyThreadAccess()
		{
			this.Dispatcher?.VerifyAccess();
		}

		#endregion Methods

		#region Overrides

		protected override Dispatcher CreateDispatcher()
		{
			return Dispatcher.CurrentDispatcher;
		}

		protected override void EnterDispatcherLoop()
		{
			Dispatcher.Run();
		}

		#endregion Private Implementation
	}
}
