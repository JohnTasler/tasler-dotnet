using System.Runtime.InteropServices;

namespace Tasler.Interop.Com;

/// <summary>
/// Managed code wrapper for the standard Global Interface Table.
/// </summary>
internal class GlobalInterfaceTable : IGlobalInterfaceTable
{
	private const int E_INVALIDARG = unchecked((int)0x80070057);

	#region IGlobalInterfaceTable Method Delegates
	private const int RegisterInterfaceInGlobalIndex = 3;
	private delegate int RegisterInterfaceInGlobalDelegate(
		nint pThis,
		nint pUnk,
		ref Guid riid,
		out int pdwCookie);

	private const int RevokeInterfaceFromGlobalIndex = 4;
	private delegate int RevokeInterfaceFromGlobalDelegate(
		nint pThis,
		int dwCookie);

	private const int GetInterfaceFromGlobalIndex = 5;
	private delegate int GetInterfaceFromGlobalDelegate(
		nint pThis,
		int dwCookie,
		ref Guid riid,
		out nint ppv);
	#endregion IGlobalInterfaceTable Method Delegates

	#region Instance Fields
	private nint _pGit;
	private nint _vtbl;
	private RegisterInterfaceInGlobalDelegate? _fnRegisterInterfaceInGlobal;
	private RevokeInterfaceFromGlobalDelegate? _fnRevokeInterfaceFromGlobal;
	private GetInterfaceFromGlobalDelegate? _fnGetInterfaceFromGlobal;
	#endregion Instance Fields

	#region Construction / Finalization
	public GlobalInterfaceTable()
	{
		_pGit = ComApi.CoCreateInstance(typeof(StdGlobalInterfaceTable).GUID, typeof(IGlobalInterfaceTable).GUID);

		_vtbl = Marshal.ReadIntPtr(_pGit);
		nint pfnRegisterInterfaceInGlobal = Marshal.ReadIntPtr(_vtbl, nint.Size * RegisterInterfaceInGlobalIndex);
		nint pfnRevokeInterfaceFromGlobal = Marshal.ReadIntPtr(_vtbl, nint.Size * RevokeInterfaceFromGlobalIndex);
		nint pfnGetInterfaceFromGlobal = Marshal.ReadIntPtr(_vtbl, nint.Size * GetInterfaceFromGlobalIndex);

		_fnRegisterInterfaceInGlobal = Marshal.GetDelegateForFunctionPointer<RegisterInterfaceInGlobalDelegate>(pfnRegisterInterfaceInGlobal);
		_fnRevokeInterfaceFromGlobal = Marshal.GetDelegateForFunctionPointer<RevokeInterfaceFromGlobalDelegate>(pfnRevokeInterfaceFromGlobal);
		_fnGetInterfaceFromGlobal = Marshal.GetDelegateForFunctionPointer<GetInterfaceFromGlobalDelegate>(pfnGetInterfaceFromGlobal);
	}

	~GlobalInterfaceTable()
	{
		_vtbl = nint.Zero;
		_fnRegisterInterfaceInGlobal = null;
		_fnRevokeInterfaceFromGlobal = null;
		_fnGetInterfaceFromGlobal = null;

		if (_pGit != nint.Zero)
		{
			Marshal.Release(_pGit);
			_pGit = nint.Zero;
		}
	}
	#endregion Construction / Finalization

	#region IGlobalInterfaceTable Methods

	public int RegisterInterfaceInGlobal(object pUnk, ref Guid riid, out int pdwCookie)
	{
		nint pUnknown = Marshal.GetIUnknownForObject(pUnk);
		pdwCookie = 0;
		int? hr = _fnRegisterInterfaceInGlobal?.Invoke(_vtbl, pUnknown, ref riid, out pdwCookie);
		Marshal.Release(pUnknown);
		return hr ?? E_INVALIDARG;
	}

	public int RevokeInterfaceFromGlobal(int dwCookie)
	{
		return _fnRevokeInterfaceFromGlobal?.Invoke(_vtbl, dwCookie) ?? E_INVALIDARG;
	}

	public int GetInterfaceFromGlobal(int dwCookie, ref Guid riid, out object ppv)
	{
		ppv = null!;
		nint pUnknown = nint.Zero;
		int? hr = _fnGetInterfaceFromGlobal?.Invoke(_vtbl, dwCookie, ref riid, out pUnknown);
		ppv = (hr >= 0 && pUnknown != nint.Zero) ? Marshal.GetObjectForIUnknown(pUnknown) : null!;
		return hr ?? E_INVALIDARG;
	}

	#endregion IGlobalInterfaceTable Methods
}

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
