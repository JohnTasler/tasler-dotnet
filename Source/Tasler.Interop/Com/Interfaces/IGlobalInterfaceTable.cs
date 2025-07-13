using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

/// <summary>
/// IGlobalInterfaceTable
/// </summary>
[GeneratedComInterface]
[Guid("00000146-0000-0000-C000-000000000046")]
public partial interface IGlobalInterfaceTable : IUnknown
{
	[PreserveSig]
	int RegisterInterfaceInGlobal(
		nint pUnk,
		ref Guid riid,
		out int pdwCookie);

	[PreserveSig]
	int RevokeInterfaceFromGlobal(int dwCookie);

	[PreserveSig]
	int GetInterfaceFromGlobal(
		int dwCookie,
		ref Guid riid,
		out nint ppv);
}

public static class IGlobalInterfaceTableExtensions
{
	public static int RegisterInterfaceInGlobal<T>(this IGlobalInterfaceTable @this, T pUnk)
		=> RegisterInterfaceInGlobal(@this, pUnk!, typeof(T).GUID);

	public static int RegisterInterfaceInGlobal(this IGlobalInterfaceTable @this, object pUnk, Guid iid)
	{
		int hr = @this.RegisterInterfaceInGlobal(ComApi.Wrappers.GetOrCreateComInterfaceForObject(pUnk, CreateComInterfaceFlags.None), ref iid, out int cookie);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return cookie;
	}

	public static void RevokeInterfaceFromGlobal(this IGlobalInterfaceTable @this, int dwCookie)
	{
		int hr = @this.RevokeInterfaceFromGlobal(dwCookie);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);
	}

	public static TInterface GetInterfaceFromGlobal<TInterface>(this IGlobalInterfaceTable @this, int dwCookie)
	{
		Guid iid = typeof(TInterface).GUID;
		int hr = @this.GetInterfaceFromGlobal(dwCookie, ref iid, out nint ppv);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (TInterface)ComApi.Wrappers.GetOrCreateObjectForComInstance(ppv, CreateObjectFlags.Unwrap);
	}
}
