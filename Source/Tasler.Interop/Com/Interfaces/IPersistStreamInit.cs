using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("7FD52380-4E07-101B-AE2D-08002B2EC713")]
public partial interface IPersistStreamInit : IPersist
{
	[PreserveSig]
	int IsDirty();

	void Load(IStream stream);

	void Save(IStream stream, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

	ulong GetSizeMax();

	void InitNew();
}
