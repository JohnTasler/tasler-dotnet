using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Tasler.Interop.Com;

public static partial class ComApi
{
	public static TClass? CoCreateInstance<TClass>(string clsid)
		where TClass : class
	{
		return (TClass?)Activator.CreateInstance(
			Type.GetTypeFromCLSID(new Guid(clsid)) ?? throw new InvalidCastException());
	}

	public static nint CoCreateInstance(Guid clsid, Guid iid, ClsCtx dwClsContext = ClsCtx.Default)
	{
		int hr = NativeMehods.CoCreateInstance(ref clsid, nint.Zero, dwClsContext, ref iid, out nint ppv);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return ppv;
	}

	public static TInterface CoCreateInstance<TInterface>(Guid clsid, ClsCtx dwClsContext = ClsCtx.Default)
		where TInterface : class
	{
		return (TInterface)Marshal.GetObjectForIUnknown(CoCreateInstance(clsid, typeof(TInterface).GUID, dwClsContext));
	}

	public static TInterface CoCreateInstance<TClass, TInterface>(ClsCtx dwClsContext = ClsCtx.Default)
		where TClass : class
		where TInterface : class
	{
		return CoCreateInstance<TInterface>(typeof(TClass).GUID, dwClsContext);
	}

	public static IRunningObjectTable GetRunningObjectTable()
	{
		var hr = NativeMehods.GetRunningObjectTable(0, out nint rot);
		if (hr != 0)
			Marshal.ThrowExceptionForHR(hr);

		return (IRunningObjectTable)Marshal.GetObjectForIUnknown(rot);
	}

	public static IBindCtx CreateBindCtx()
	{
		var hr = NativeMehods.CreateBindCtx(0, out nint ctx);
		if (hr != 0)
			Marshal.ThrowExceptionForHR(hr);

		return (IBindCtx)Marshal.GetObjectForIUnknown(ctx);
	}

	#region Nested Types

	private static partial class NativeMehods
	{
		private const string ApiLib = "ole32.dll";

		[LibraryImport(ApiLib)]
		public static partial int CoCreateInstance(
			ref Guid rclsid,
			nint pUnkOuter,
			ClsCtx dwClsContext,
			ref Guid riid,
			out nint ppv);

		[LibraryImport(ApiLib)]
		public static partial int GetRunningObjectTable(int reserved, out nint pprot);

		[LibraryImport(ApiLib)]
		public static partial int CreateBindCtx(int reserved, out nint ppbc);

	}

	#endregion Nested Types
}
