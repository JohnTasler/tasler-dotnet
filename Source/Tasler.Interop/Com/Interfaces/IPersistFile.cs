using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000010B-0000-0000-C000-000000000046")]
public partial interface IPersistFile : IPersist
{
	[PreserveSig]
	int IsDirty();

	void Load(string fileName, STGM mode);

	[PreserveSig]
	int Save(string fileName, [MarshalAs(UnmanagedType.Bool)] bool fRemember);

	void SaveCompleted(string fileName);

	[PreserveSig]
	int GetCurFile(out string? fileName);
}
