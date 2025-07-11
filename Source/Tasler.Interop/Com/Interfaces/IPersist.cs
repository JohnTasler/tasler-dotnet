using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("0000010C-0000-0000-C000-000000000046")]
public partial interface IPersist
{
	Guid GetClassID();
}

[GeneratedComInterface]
[Guid("00000109-0000-0000-C000-000000000046")]
public partial interface IPersistStream : IPersist
{
	[PreserveSig]
	int IsDirty();

	void Load(IStream stream);

	void Save(IStream stream, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

	ulong GetSizeMax();
}

[GeneratedComInterface]
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

[GeneratedComInterface]
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

[GeneratedComInterface]
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

public static class IPersistExtensions
{
	extension(IPersistStream @this)
	{
		bool IsDirty => @this.IsDirty() == 0;
	}

	extension(IPersistStorage @this)
	{
		bool IsDirty => @this.IsDirty() == 0;
	}

	extension(IPersistFile @this)
	{
		bool IsDirty => @this.IsDirty() == 0;
	}

	extension(IPersistMemory @this)
	{
		bool IsDirty => @this.IsDirty() == 0;
	}
}
