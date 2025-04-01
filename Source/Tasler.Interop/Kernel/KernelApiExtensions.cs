using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Tasler.Interop.Kernel;

public static partial class KernelApi
{
	public static bool CloseProcess(this SafeProcessHandle @this) => NativeMethods.CloseHandle(@this);

	public static bool DuplicateHandle(
		this SafeProcessHandle hSourceProcessHandle,
		SafeWaitHandle hSourceHandle,
		SafeProcessHandle hTargetProcessHandle,
		ref SafeWaitHandle lpTargetHandle,
		uint dwDesiredAccess,
		[MarshalAs(UnmanagedType.Bool)]
		bool bInheritHandle,
		uint dwOptions) => NativeMethods.DuplicateHandle(
			hSourceProcessHandle,
			hSourceHandle,
			hTargetProcessHandle,
			ref lpTargetHandle,
			dwDesiredAccess,
			bInheritHandle,
			dwOptions);
}
