using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000010A-0000-0000-C000-000000000046")]
public partial interface IPersistStorage : IPersist
{
	[PreserveSig]
	int IsDirty();

	void InitNew(IStorage storage);

	void Load(IStorage storage);

	void Save(IStorage storage, [MarshalAs(UnmanagedType.Bool)] bool fSameAsLoad);

	void SaveCompleted(IStorage storage);

	void HandsOffStorage();
}
