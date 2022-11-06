using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;

namespace Tasler.Interop.Com
{
	public static class ComApi
	{
		#region Constants
		private const string ApiLib = "ole32.dll";
		#endregion Constants

		#region Safe Methods

		public static T CoCreateInstance<T>(string clsid)
		{
			return (T)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(clsid)));
		}

		public static IRunningObjectTable GetRunningObjectTable()
		{
			IRunningObjectTable result;
			var hr = Private.GetRunningObjectTable(0, out result);
			if (hr != 0)
				Marshal.ThrowExceptionForHR(hr);

			return result;
		}

		public static IBindCtx CreateBindCtx()
		{
			IBindCtx result;
			var hr = Private.CreateBindCtx(0, out result);
			if (hr != 0)
				Marshal.ThrowExceptionForHR(hr);

			return result;
		}

		#endregion Safe Methods

		#region Unsafe Methods

		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport(ApiLib)]
		public static extern int CoCreateInstance(
			ref Guid rclsid,
			IntPtr pUnkOuter,
			ClsCtx dwClsContext,
			ref Guid riid,
			out IntPtr ppv);

		#endregion Unsafe Methods

		#region Nested Types
		private static class Private
		{
			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, ExactSpelling = true)]
			public static extern int GetRunningObjectTable(
				int reserved,
				out IRunningObjectTable pprot);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, ExactSpelling = true)]
			public static extern int CreateBindCtx(int reserved, out IBindCtx ppbc);

		}
		#endregion Nested Types
	}
}
