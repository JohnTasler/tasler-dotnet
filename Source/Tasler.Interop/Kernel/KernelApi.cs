using System.Runtime.InteropServices;
using System.Security;

namespace Tasler.Interop.Kernel
{
	public static class KernelApi
	{
		#region Constants
		private const string ApiLib = "kernel32.dll";
		#endregion Constants

		#region Safe Methods
		[SecuritySafeCritical]
		[DllImport(ApiLib, ExactSpelling = true)]
		public static extern int GetCurrentProcessId();

		[SecuritySafeCritical]
		[DllImport(ApiLib, ExactSpelling = true)]
		public static extern int GetCurrentThreadId();

		#endregion Safe Methods

		#region Unsafe Methods

		#endregion Unsafe Methods
	}
}
