using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("00000109-0000-0000-C000-000000000046")]
public partial interface IPersistStream : IPersist
{
	[PreserveSig]
	int IsDirty();

	void Load(IStream stream);

	void Save(IStream stream, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

	ulong GetSizeMax();
}
