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
	int IsDirty();

	int Load(IStream stream);

	int Save(IStream stream, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

	ulong GetSizeMax();
}

[GeneratedComInterface]
[Guid("7FD52380-4E07-101B-AE2D-08002B2EC713")]
public partial interface IPersistStreamInit : IPersist
{
	int InitNew();

	int Load(IStream stream);

	int Save(IStream stream, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty);
}

[GeneratedComInterface]
[Guid("0000010A-0000-0000-C000-000000000046")]
public partial interface IPersistStorage : IPersist
{
	int IsDirty();

	int InitNew(IStorage storage);

	int Load(IStorage storage);

	int Save(IStorage storage, [MarshalAs(UnmanagedType.Bool)] bool fSameAsLoad);

	int SaveCompleted(IStorage storage);

	int HandsOffStorage();
}

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000010B-0000-0000-C000-000000000046")]
public partial interface IPersistFile : IPersist
{
	int IsDirty();

	int Load(string fileName, uint dwMode);

	int Save(string fileName, [MarshalAs(UnmanagedType.Bool)] bool fRemember);

	int SaveCompleted(string fileName);

	string GetCurFile();
}

[GeneratedComInterface]
[Guid("BD1AE5E0-A6AE-11CE-BD37-504200C10000")]
public partial interface IPersistMemory : IPersist
{
	int IsDirty();

	int Load(nint pMem, uint cbSize);

	int Save(nint pMem, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty, uint cbSize);

	uint GetSizeMax();

	int InitNew();
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
