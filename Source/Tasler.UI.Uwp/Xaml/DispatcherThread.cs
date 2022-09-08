using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Core;

namespace Tasler.UI.Core
{
    public class DispatcherThread : DispatcherThreadBase
    {
        #region Constructors

        public DispatcherThread() : base() { }

        public DispatcherThread(string threadName) : base(threadName) { }

        #endregion Constructors

        #region Overrides

        protected override CoreDispatcher CreateDispatcher()
        {
            // TODO: This doesn't work in Release builds. Still investigating.
            var coreDispatcherActivationFactory = WindowsRuntimeMarshal.GetActivationFactory(typeof(CoreDispatcher));
            var coreDispatcherStatics = (IInternalCoreDispatcherStatic)coreDispatcherActivationFactory;
            return coreDispatcherStatics.GetOrCreateForCurrentThread();
        }

        protected override void EnterDispatcherLoop(CoreDispatcher dispatcher)
        {
            dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
        }

        protected override void ExitDispatcherLoop(CoreDispatcher dispatcher)
        {
            dispatcher?.StopProcessEvents();
        }

        protected override bool GetHasThreadAccess(CoreDispatcher dispatcher)
        {
            return (dispatcher?.HasThreadAccess).Value;
        }

        protected override void VerifyThreadAccess(CoreDispatcher dispatcher)
        {
            const int RPC_E_WRONG_THREAD = unchecked((int)0x8001010E);

            if (!this.GetHasThreadAccess(dispatcher))
                Marshal.ThrowExceptionForHR(RPC_E_WRONG_THREAD);
        }

        #endregion Overrides

        #region Private Implementation

        [Guid("4B4D0861-D718-4F7C-BEC7-735C065F7C73")]
        [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
        interface IInternalCoreDispatcherStatic
        {
            CoreDispatcher GetForCurrentThread();
            CoreDispatcher GetOrCreateForCurrentThread();
        }

        #endregion Private Implementation
    }
}
