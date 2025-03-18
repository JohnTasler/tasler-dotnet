using System.Runtime.InteropServices;

namespace Tasler.Interop.Kernel;

public static partial class KernelApi
{
	#region Constants
	private const string ApiLib = "kernel32.dll";
	#endregion Constants

	public static int GetCurrentProcessId() => NativeMethods.GetCurrentProcessId();

	public static int GetCurrentThreadId() => NativeMethods.GetCurrentThreadId();

	internal static partial class NativeMethods
	{
		[LibraryImport(ApiLib)]
		public static partial int GetCurrentProcessId();

		[LibraryImport(ApiLib)]
		public static partial int GetCurrentThreadId();
	}
}
