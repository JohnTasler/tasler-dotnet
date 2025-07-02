using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Kernel;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("0000000f-0000-0000-C000-000000000046")]
public partial interface IMoniker	: IPersistStream
{
	[return: MarshalAs(UnmanagedType.Interface)]
	object BindToObject(IBindCtx pbc, IMoniker? pmkToLeft, ref Guid riidResult);

	[return: MarshalAs(UnmanagedType.Interface)]
	object BindToStorage(IBindCtx pbc, IMoniker? pmkToLeft, ref Guid riid);

	IMoniker Reduce(IBindCtx pbc, int dwReduceHowFar, nint ppmkToLeft);

	IMoniker ComposeWith(IMoniker pmkRight, [MarshalAs(UnmanagedType.Bool)] bool fOnlyIfNotGeneric);

	IEnumMoniker Enum([MarshalAs(UnmanagedType.Bool)] bool fForward);

	[PreserveSig]
	int IsEqual(IMoniker pmkOtherMoniker);

	int Hash();

	[PreserveSig]
	int IsRunning(IBindCtx pbc, IMoniker? pmkToLeft, IMoniker? pmkNewlyRunning);

	FILETIME GetTimeOfLastChange(IBindCtx pbc, IMoniker? pmkToLeft);

	IMoniker Inverse();

	IMoniker CommonPrefixWith(IMoniker pmkOther);

	IMoniker RelativePathTo(IMoniker pmkOther);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	string GetDisplayName(IBindCtx pbc, IMoniker? pmkToLeft);

	IMoniker ParseDisplayName(IBindCtx pbc, IMoniker? pmkToLeft, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, out int pchEaten);

	[PreserveSig]
	int IsSystemMoniker(out MKSYS pdwMksys);
}

public static class IMonikerExtensions
{
	extension(IMoniker moniker)
	{
		public IMoniker Reduce(IBindCtx pbc, int dwReduceHowFar)
			=> moniker.Reduce(pbc, dwReduceHowFar, nint.Zero);

		public IMoniker Reduce(IBindCtx pbc, int dwReduceHowFar, ref IMoniker monikerToLeft)
		{
			GCHandle handle = GCHandle.Alloc(monikerToLeft, GCHandleType.Pinned);
			using (new DisposeScopeExit(() => handle.Free()))
			{
				handle.AddrOfPinnedObject();
				return moniker.Reduce(pbc, dwReduceHowFar, handle.AddrOfPinnedObject());
			}
		}
	}
}
