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
	/// <summary>
	/// Registers a COM interface pointer in the Global Interface Table and obtains a cookie that identifies the registration.
	/// </summary>
	/// <param name="pUnk">A pointer to the COM interface (an `IUnknown` or other interface pointer) to register.</param>
	/// <param name="riid">The interface identifier (IID) of the interface being requested from the registered object.</param>
	/// <param name="pdwCookie">When the method returns, receives a cookie that can be used to revoke the registration or retrieve the interface.</param>
	/// <returns>An HRESULT indicating success or failure (for example, `S_OK` on success). Negative values represent failure codes.</returns>
	[PreserveSig]
	int RegisterInterfaceInGlobal(
		nint pUnk,
		ref Guid riid,
		out int pdwCookie);

	/// <summary>
	/// Revokes a previously registered interface from the Global Interface Table using its registration cookie.
	/// </summary>
	/// <param name="dwCookie">Registration cookie returned by RegisterInterfaceInGlobal that identifies the entry to revoke.</param>
	/// <returns>An HRESULT code: 0 (S_OK) on success; a negative value indicates failure.</returns>
	[PreserveSig]
	int RevokeInterfaceFromGlobal(int dwCookie);

	/// <summary>
	/// Retrieves a pointer to the interface identified by <paramref name="riid"/> from the global interface table using the specified registration cookie.
	/// </summary>
	/// <param name="dwCookie">The registration cookie that identifies the previously registered interface in the global table.</param>
	/// <param name="riid">The IID of the interface to retrieve.</param>
	/// <param name="ppv">When the method returns, contains the pointer to the requested interface.</param>
	/// <returns>An HRESULT value: S_OK on success; a COM error code otherwise.</returns>
	[PreserveSig]
	int GetInterfaceFromGlobal(
		int dwCookie,
		ref Guid riid,
		out nint ppv);
}

public static class IGlobalInterfaceTableExtensions
{
	/// <summary>
	/// Registers a managed object in the COM Global Interface Table using the IID for T.
	/// </summary>
	/// <typeparam name="T">The interface or class type whose IID will be used for registration.</typeparam>
	/// <param name="pUnk">The managed object to register in the global table.</param>
	/// <returns>The cookie assigned by the Global Interface Table for the registered interface.</returns>
	public static int RegisterInterfaceInGlobal<T>(this IGlobalInterfaceTable @this, T pUnk)
		=> RegisterInterfaceInGlobal(@this, pUnk!, typeof(T).GUID);

	/// <summary>
	/// Registers a managed object's COM interface in the Global Interface Table and returns the registration cookie.
	/// </summary>
	/// <param name="pUnk">The managed object whose COM interface will be registered.</param>
	/// <param name="iid">The IID of the interface to register.</param>
	/// <returns>The cookie that identifies the registered interface in the Global Interface Table.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown when the underlying COM call returns a failing HRESULT (HRESULT &lt; 0).</exception>
	public static int RegisterInterfaceInGlobal(this IGlobalInterfaceTable @this, object pUnk, Guid iid)
	{
		int hr = @this.RegisterInterfaceInGlobal(ComApi.Wrappers.GetOrCreateComInterfaceForObject(pUnk, CreateComInterfaceFlags.None), ref iid, out int cookie);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return cookie;
	}

	/// <summary>
	/// Revokes a previously registered COM interface from the Global Interface Table.
	/// </summary>
	/// <param name="dwCookie">The cookie that identifies the registered interface to revoke.</param>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown when the underlying COM call returns a failing HRESULT.</exception>
	public static void RevokeInterfaceFromGlobal(this IGlobalInterfaceTable @this, int dwCookie)
	{
		int hr = @this.RevokeInterfaceFromGlobal(dwCookie);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);
	}

	/// <summary>
	/// Retrieves a managed instance of the specified COM interface from the Global Interface Table using the supplied registration cookie.
	/// </summary>
	/// <param name="@this">The global interface table instance.</param>
	/// <param name="dwCookie">The registration cookie that identifies the interface in the Global Interface Table.</param>
	/// <returns>The managed instance of <typeparamref name="TInterface"/> that represents the COM interface associated with the cookie.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown if the underlying COM call returns a failing HRESULT.</exception>
	public static TInterface GetInterfaceFromGlobal<TInterface>(this IGlobalInterfaceTable @this, int dwCookie)
	{
		Guid iid = typeof(TInterface).GUID;
		int hr = @this.GetInterfaceFromGlobal(dwCookie, ref iid, out nint ppv);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (TInterface)ComApi.Wrappers.GetOrCreateObjectForComInstance(ppv, CreateObjectFlags.Unwrap);
	}
}
