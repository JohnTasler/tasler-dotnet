using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com.Interfaces;

[Guid("00000001-0000-0000-C000-000000000046")]
[GeneratedComInterface]
public partial interface IClassFactory : IUnknown
{
	/// <summary>
	/// Creates a new COM object instance and obtains the requested interface.
	/// </summary>
	/// <param name="pUnkOuter">Pointer to the outer IUnknown for aggregation, or zero if not aggregating.</param>
	/// <param name="riid">Reference to the GUID of the interface being requested on the new object.</param>
	/// <returns>Native pointer to the requested interface on success; on failure the returned value contains a COM error code (HRESULT) encoded as a pointer.</returns>
	nint CreateInstance(nint pUnkOuter, ref Guid riid);

	/// <summary>
	/// Locks or unlocks the COM server to control whether it remains loaded in memory.
	/// </summary>
	/// <param name="fLock">`true` to lock the server (increment the lock count); `false` to unlock the server (decrement the lock count).</param>
	/// <returns>An HRESULT status code indicating success or failure of the operation.</returns>
	int LockServer([MarshalAs(UnmanagedType.Bool)] bool fLock);
}
