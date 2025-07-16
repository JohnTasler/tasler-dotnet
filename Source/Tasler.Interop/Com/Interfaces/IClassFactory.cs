using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com.Interfaces;

[Guid("00000001-0000-0000-C000-000000000046")]
[GeneratedComInterface]
public partial interface IClassFactory : IUnknown
{
	nint CreateInstance(nint pUnkOuter, ref Guid riid);

	int LockServer([MarshalAs(UnmanagedType.Bool)] bool fLock);
}
