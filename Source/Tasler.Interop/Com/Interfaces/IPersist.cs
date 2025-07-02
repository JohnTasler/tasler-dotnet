using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("00000109-0000-0000-C000-000000000046")]
public partial interface IPersistStream : IPersist
{
	[PreserveSig]
	int IsDirty();

	[PreserveSig]
	int Load(IStream stream);

	[PreserveSig]
	int Save(IStream stream, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

	ulong GetSizeMax();
}

[GeneratedComInterface]
[Guid("0000010A-0000-0000-C000-000000000046")]
public partial interface IPersistStorage : IPersist
{
	[PreserveSig]
	int IsDirty();

	[PreserveSig]
	int InitNew(IStorage storage);

	[PreserveSig]
	int Load(IStorage storage);

	[PreserveSig]
	int Save(IStorage storage, [MarshalAs(UnmanagedType.Bool)] bool fSameAsLoad);

	[PreserveSig]
	int SaveCompleted(IStorage storage);

	[PreserveSig]
	int HandsOffStorage();
}

[GeneratedComInterface]
[Guid("0000010B-0000-0000-C000-000000000046")]
public partial interface IPersistFile : IPersist
{
	[PreserveSig]
	int IsDirty();

	[PreserveSig]
	int Load([MarshalAs(UnmanagedType.LPWStr)] string fileName, uint dwMode);

	[PreserveSig]
	int Save([MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.Bool)] bool fRemember);

	[PreserveSig]
	int SaveCompleted([MarshalAs(UnmanagedType.LPWStr)] string fileName);

	[return: MarshalAs(UnmanagedType.LPWStr)]
	string GetCurFile();
}

[GeneratedComInterface]
[Guid("0000010C-0000-0000-C000-000000000046")]
public partial interface IPersist
{
	Guid GetClassID();
}

[GeneratedComInterface]
[Guid("7FD52380-4E07-101B-AE2D-08002B2EC713")]
public partial interface IPersistStreamInit : IPersist
{
	[PreserveSig]
	int InitNew();

	[PreserveSig]
	int Load(IStream stream);

	[PreserveSig]
	int Save(IStream stream, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty);
}

[GeneratedComInterface]
[Guid("BD1AE5E0-A6AE-11CE-BD37-504200C10000")]
public partial interface IPersistMemory : IPersist
{
	[PreserveSig]
	int IsDirty();

	[PreserveSig]
	int Load(nint pMem, uint cbSize);

	[PreserveSig]
	int Save(nint pMem, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty, uint cbSize);

	uint GetSizeMax();

	[PreserveSig]
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
