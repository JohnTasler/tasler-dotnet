using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Tasler.Interop.Kernel;

public static partial class KernelApi
{
	public static uint GetCurrentProcessId() => NativeMethods.GetCurrentProcessId();

	public static uint GetCurrentThreadId() => NativeMethods.GetCurrentThreadId();

	public static SafeProcessHandle GetCurrentProcess() => NativeMethods.GetCurrentProcess();

	internal static partial class NativeMethods
	{
		#region Constants
		private const string ApiLib = "kernel32.dll";
		#endregion Constants

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ResetEvent(SafeWaitHandle handle);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool SetEvent(SafeWaitHandle handle);

		[LibraryImport(ApiLib)]
		public static partial uint GetCurrentProcessId();

		[LibraryImport(ApiLib)]
		public static partial uint GetCurrentThreadId();

		[LibraryImport(ApiLib)]
		public static partial SafeProcessHandle GetCurrentProcess();

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool CloseHandle(SafeProcessHandle handle);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool DuplicateHandle(
			SafeProcessHandle hSourceProcessHandle,
			SafeWaitHandle hSourceHandle,
			SafeProcessHandle hTargetProcessHandle,
			ref SafeWaitHandle lpTargetHandle,
			uint dwDesiredAccess,
			[MarshalAs(UnmanagedType.Bool)]
			bool bInheritHandle,
			uint dwOptions);
	}
}
