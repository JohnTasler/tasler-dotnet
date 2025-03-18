using System.Windows.Threading;

namespace Tasler.Windows.Threading
{
    public class DispatcherThread : DispatcherThreadBase
    {
        #region Constructors

        public DispatcherThread() : base() { }

        public DispatcherThread(string threadName) : base(threadName) { }

        #endregion Constructors

        #region Overrides

        protected override Dispatcher CreateDispatcher()
        {
            return Dispatcher.CurrentDispatcher;
        }

        protected override void EnterDispatcherLoop(Dispatcher dispatcher)
        {
            Dispatcher.Run();
        }

        protected override void ExitDispatcherLoop(Dispatcher dispatcher)
        {
            if (dispatcher != null && !dispatcher.HasShutdownStarted && !dispatcher.HasShutdownFinished)
                dispatcher.InvokeShutdown();
        }

        protected override bool GetHasThreadAccess(Dispatcher dispatcher)
        {
            return (dispatcher?.CheckAccess()!).Value;
        }

        protected override void VerifyThreadAccess(Dispatcher dispatcher)
        {
            dispatcher?.VerifyAccess();
        }

        #endregion Private Implementation
    }
}
