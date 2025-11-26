using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com.Interfaces;

namespace Tasler.Interop.Com;

[GeneratedComClass]
public partial class DefaultClassFactory(Func<IUnknown> _creatorFunc) : IClassFactory
{
	/// <summary>
	/// Creates a new COM object using the factory and returns its native interface pointer.
	/// </summary>
	/// <param name="pUnkOuter">Reserved for aggregation; ignored by this implementation.</param>
	/// <param name="riid">Requested interface IID; ignored by this implementation. The returned pointer is the default COM interface for the created object.</param>
	/// <returns>Native COM interface pointer (nint) for the newly created object.</returns>
	public nint CreateInstance(nint pUnkOuter, ref Guid riid)
	{
		var newObject = _creatorFunc();
		return ComApi.Wrappers.GetOrCreateComInterfaceForObject(newObject, CreateComInterfaceFlags.None);
	}

	/// <summary>
/// Handles a request to lock or unlock the COM server; this implementation is a no-op.
/// </summary>
/// <param name="fLock">True to request locking the server, false to request unlocking it.</param>
/// <returns>0 to indicate success.</returns>
public int LockServer(bool fLock) => 0;
}