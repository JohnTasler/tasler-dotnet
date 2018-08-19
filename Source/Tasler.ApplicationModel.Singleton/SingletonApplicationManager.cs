using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Security;
using System.Threading;
using Tasler.Interop.User;
using Tasler.IO;

namespace Tasler.ApplicationModel
{
	public class SingletonApplicationManager
	{
		#region Instance Fields
		private SingletonApplicationBroker _broker;
		private Mutex _mutex;
		private EventWaitHandle _readyEvent;
		#endregion Instance Fields

		#region Construction
		public SingletonApplicationManager(SingletonApplicationBroker broker)
		{
			_broker = broker;
		}
		#endregion Construction

		#region Methods
		public void Run(string[] args)
		{
			this.Run(args, true);
		}

		public void Run(string[] args, bool activateExistingWindow)
		{
			if (Debugger.IsAttached)
			{
				this.RunInternal(args, activateExistingWindow);
			}
			else
			{
				try
				{
					this.RunInternal(args, activateExistingWindow);
				}
				catch (Exception ex)
				{
					Debug.WriteLine(ex.ToString());
					throw;
				}
			}
		}

		private void RunInternal(string[] args, bool activateExistingWindow)
		{
			// Determine the unique name for this application and object URI
			string uniqueName = PathUtility.GetInvalidFileNameCharsRegex().Replace(_broker.UniqueName, "_");
			string mutexName = uniqueName + "_mutex";
			string eventName = uniqueName + "_ready";
			string programURI = _broker.GetType().Name;
			string programURL = "ipc://" + uniqueName + "/" + programURI;

			// Create or obtain a named mutex
			bool createdNew;
			using (_mutex = new Mutex(true, mutexName, out createdNew))
			{
				// Create or obtain the event used to signal when ready for calls
				using (_readyEvent = new EventWaitHandle(false, EventResetMode.ManualReset, eventName))
				{
					SingletonApplicationStartupArgs startupArgs = new SingletonApplicationStartupArgs(args);

					// Check for first instance
					if (createdNew)
					{
						// Create and register an ipc server channel
						IpcServerChannel serverChannel = new IpcServerChannel(uniqueName);
						ChannelServices.RegisterChannel(serverChannel, true);

						// Register a well-known service
						RemotingConfiguration.RegisterWellKnownServiceType(
							_broker.GetType(), programURI, WellKnownObjectMode.Singleton);

						// Marshal the application broker instance
						RemotingServices.Marshal(_broker, programURI);

						// Allow the new instance to initialize itself
						_broker.OnStartupFirstInstance(startupArgs);

						// Signal that we're ready for calls
						_readyEvent.Set();

						// Allow the new application instance to run
						_broker.OnRun();

						// Unregister the channel
						ChannelServices.UnregisterChannel(serverChannel);
					}
					else
					{
						// Wait for the other instance to be ready for calls
						_readyEvent.WaitOne();

						// Create and register an ipc client channel
						IpcClientChannel clientChannel = new IpcClientChannel();
						ChannelServices.RegisterChannel(clientChannel, true);

						// Create the remote object proxy
						_broker = (SingletonApplicationBroker)
							RemotingServices.Connect(_broker.GetType(), programURL);

						// Bring the existing window into the foreground, as specified
						if (activateExistingWindow)
						{
							IntPtr mainWindowHandle = (IntPtr)_broker.MainWindowHandle;

							bool result = UnsafeNativeMethods.SetForegroundWindow(mainWindowHandle);
							Debug.WriteLineIf(result, "SingletonApplicationManager.RunInternal: SetForegroundWindow succeeded.");
							Debug.WriteLineIf(!result, "SingletonApplicationManager.RunInternal: SetForegroundWindow failed.");
							if (!result)
							{
								using (new AttachThreadInput(UnsafeNativeMethods.GetForegroundWindow()))
								{
									result = UnsafeNativeMethods.SetForegroundWindow(mainWindowHandle);
									Debug.WriteLineIf(result, "SingletonApplicationManager.RunInternal: SetForegroundWindow succeeded.");
									Debug.WriteLineIf(!result, "SingletonApplicationManager.RunInternal: SetForegroundWindow failed.");
								}
							}

//							if (result)
							{
								using (new AttachThreadInput(mainWindowHandle))
								{
									result = UnsafeNativeMethods.SetForegroundWindow(mainWindowHandle);
									Debug.WriteLineIf(result, "SingletonApplicationManager.RunInternal: SetForegroundWindow succeeded.");
									Debug.WriteLineIf(!result, "SingletonApplicationManager.RunInternal: SetForegroundWindow failed.");

									result = UnsafeNativeMethods.SetActiveWindow(mainWindowHandle) != IntPtr.Zero;
									Debug.WriteLineIf(result, "SingletonApplicationManager.RunInternal: SetActiveWindow succeeded.");
									Debug.WriteLineIf(!result, "SingletonApplicationManager.RunInternal: SetActiveWindow failed.");


									if (UserApi.IsIconic(mainWindowHandle))
									{
										result = UnsafeNativeMethods.ShowWindowAsync(mainWindowHandle, NativeMethods.SW_RESTORE);
										Debug.WriteLineIf(result, "SingletonApplicationManager.RunInternal: ShowWindowAsync succeeded.");
										Debug.WriteLineIf(!result, "SingletonApplicationManager.RunInternal: ShowWindowAsync failed.");
									}

									result = UnsafeNativeMethods.SetFocus(mainWindowHandle) != IntPtr.Zero;
									Debug.WriteLineIf(result, "SingletonApplicationManager.RunInternal: SetFocus succeeded.");
									Debug.WriteLineIf(!result, "SingletonApplicationManager.RunInternal: SetFocus failed.");
								}
							}
						}

						// Allow the other instance to respond to the command line parameters
						_broker.OnStartupNextInstance(startupArgs);
					}
				}
			}
		}
		#endregion Methods

		#region Nested Types
		private struct AttachThreadInput : IDisposable
		{
			private uint _currentThreadId;
			private uint _otherThreadId;

			public AttachThreadInput(IntPtr hwnd)
			{
				_currentThreadId = UnsafeNativeMethods.GetCurrentThreadId();
				_otherThreadId = UnsafeNativeMethods.GetWindowThreadProcessId(hwnd, IntPtr.Zero);
				bool isAttached = UnsafeNativeMethods.AttachThreadInput(_currentThreadId, _otherThreadId, true);
				Debug.WriteLine(string.Format(
					"AttachThreadInput..ctor: AttachThreadInput({0:D4}, {1:D4}) returned {2}",
					_currentThreadId, _otherThreadId, isAttached));
			}

			public void Dispose()
			{
				UnsafeNativeMethods.AttachThreadInput(_currentThreadId, _otherThreadId, false);
			}
		}

		private static class NativeMethods
		{
			public const int SW_SHOWNORMAL = 1;
			public const int SW_RESTORE = 9;
		}

		[SuppressUnmanagedCodeSecurity]
		private static class UnsafeNativeMethods
		{
			private const string User32 = "user32.dll";
			private const string Kernel32 = "kernel32.dll";

			#region Platform Invoke Methods
			[DllImport(User32)]
			public static extern IntPtr GetForegroundWindow();

			[DllImport(User32)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool SetForegroundWindow(IntPtr hWnd);

			[DllImport(User32)]
			public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr lpdwProcessId);

			[DllImport(Kernel32)]
			public static extern uint GetCurrentThreadId();

			[DllImport(User32)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool AttachThreadInput(
				uint idAttach, uint idAttachTo,
				[MarshalAs(UnmanagedType.Bool)] bool fAttach);

			[DllImport(User32)]
			public static extern IntPtr SetActiveWindow(IntPtr hWnd);

			[DllImport(User32)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

			[DllImport(User32)]
			public static extern IntPtr SetFocus(IntPtr hWnd);
			#endregion Platform Invoke Methods
		}
		#endregion Nested Types
	}

}
