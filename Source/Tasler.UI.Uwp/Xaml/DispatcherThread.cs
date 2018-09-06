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

		#region Properties

		public override bool HasThreadAccess
		{
			get { return (this.Dispatcher?.HasThreadAccess).Value; }
		}

		#endregion Properties

		#region Methods

		public override void Shutdown()
		{
			this.Dispatcher?.StopProcessEvents();
		}

		public override void VerifyThreadAccess()
		{
			const int RPC_E_WRONG_THREAD = unchecked((int)0x8001010E);

			if (!this.HasThreadAccess)
				Marshal.ThrowExceptionForHR(RPC_E_WRONG_THREAD);
		}

		#endregion Methods

		#region Overrides

		protected override CoreDispatcher CreateDispatcher()
		{
			var coreDispatcherActivationFactory = WindowsRuntimeMarshal.GetActivationFactory(typeof(CoreDispatcher));
			var coreDispatcherStatics = (IInternalCoreDispatcherStatic)coreDispatcherActivationFactory;
			return coreDispatcherStatics.GetOrCreateForCurrentThread();
		}

		protected override void EnterDispatcherLoop()
		{
			Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
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
