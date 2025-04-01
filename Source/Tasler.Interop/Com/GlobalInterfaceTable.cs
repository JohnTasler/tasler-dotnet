using System.Runtime.InteropServices;

namespace Tasler.Interop.Com;

/// <summary>
/// StdGlobalInterfaceTable
/// </summary>
[ComImport]
[Guid("00000323-0000-0000-C000-000000000046")]
internal class StdGlobalInterfaceTable
{
}

/// <summary>
/// IGlobalInterfaceTable
/// </summary>
[ComImport]
[Guid("00000146-0000-0000-C000-000000000046")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IGlobalInterfaceTable
{
	[PreserveSig]
	int RegisterInterfaceInGlobal(
		[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
		object pUnk,
		ref Guid riid,
		out int pdwCookie);

	[PreserveSig]
	int RevokeInterfaceFromGlobal(int dwCookie);

	[PreserveSig]
	int GetInterfaceFromGlobal(
		int dwCookie,
		ref Guid riid,
		[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
		out object ppv);
}
