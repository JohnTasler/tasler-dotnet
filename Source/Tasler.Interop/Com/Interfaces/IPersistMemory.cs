using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("BD1AE5E0-A6AE-11CE-BD37-504200C10000")]
public partial interface IPersistMemory : IPersist
{
	[PreserveSig]
	int IsDirty();

	void Load(nint pMem, uint cbSize);

	uint Save(nint pMem, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty );

	uint GetSizeMax();

	void InitNew();
}
