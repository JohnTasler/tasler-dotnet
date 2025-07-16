using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com.Interfaces;

namespace Tasler.Interop.Com;

[GeneratedComClass]
public partial class DefaultClassFactory(Func<IUnknown> _creatorFunc) : IClassFactory
{
	public nint CreateInstance(nint pUnkOuter, ref Guid riid)
	{
		var newObject = _creatorFunc();
		return ComApi.Wrappers.GetOrCreateComInterfaceForObject(newObject, CreateComInterfaceFlags.None);
	}

	public int LockServer(bool fLock) => 0;
}
