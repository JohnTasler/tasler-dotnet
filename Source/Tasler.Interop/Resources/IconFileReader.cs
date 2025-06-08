using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;
using Tasler.Interop.Gdi;
using Tasler.Interop.User;

namespace Tasler.Interop.Resources;

public enum ResourceType : ushort
{
	Icon = 1,
	Cursor = 2,
}

[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct IconCursorHeader
{
	private ushort _reserved;
	public ResourceType ResourceType;
	public ushort ResourceCount;
}

[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct CursorResDir
{
	public ushort Width;
	public ushort Height;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct IconResDir
{
	private byte _width;
	private byte _height;
	private byte _colorCount;
	private byte _reserved;

	public int Width
	{
		get => GetExtent(_width);
		set => SetExtent(ref _width, value);
	}

	public int Height
	{
		get => GetExtent(_height);
		set => SetExtent(ref _height, value);
	}

	public int ColorCount
	{
		get => GetExtent(_colorCount);
		set => SetExtent(ref _colorCount, value);
	}

	private static int GetExtent(byte extent) => extent == 0 ? 256 : extent;

	private static void SetExtent(ref byte extent, int value)
	{
		Guard.IsBetweenOrEqualTo(value, 0, 256, nameof(value));
		extent = value == 256 ? (byte)0 : (byte)value;
	}

	public override string ToString() => $"{Width}x{Height} {ColorCount} bpp";
}

public class IconDirectoryItem : IDisposable
{
	private DirEntry _binaryEntry = new();

	// Constructor to initialize the struct with default values
	private IconDirectoryItem(Stream stream)
	{
		Guard.IsNotNull(stream, nameof(stream));
		Guard.CanRead(stream);

		stream.ReadExactly(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref _binaryEntry, 1)));

		long fileOffset = stream.Position;
		using (var scope = new DisposeScopeExit(() => stream.Position = fileOffset))
		{
			this.LoadImageData(stream);
		}
	}

	internal static IconDirectoryItem CreateFromStream(Stream stream)
	{
		var iconDirectoryItem = new IconDirectoryItem(stream);
		return iconDirectoryItem;
	}

	public int Width => _binaryEntry.ResDirEntry.Width;
	public int Height => _binaryEntry.ResDirEntry.Height;
	public int ColorCount => _binaryEntry.ResDirEntry.ColorCount;
	public IconResDir ResDirEntry => _binaryEntry.ResDirEntry;
	public ushort Planes => _binaryEntry.Planes;
	public ushort BitCount => _binaryEntry.BitCount;
	public uint BytesInRes => _binaryEntry.BytesInRes;
	public uint FileOffset => _binaryEntry.FileOffset;

	public bool IsPngData { get; private set; }

	public byte[] ImageData { get; private set; } = [];

	public SafeGdiIcon Icon { get; private set; } = new();

	public BITMAPINFOHEADER BitmapInfoHeader => _bitmapInfoHeader;
	private BITMAPINFOHEADER _bitmapInfoHeader;

	private void LoadImageData(Stream stream)
	{
		const int pngSignature1 = 0x474E_5089;
		const int pngSignature2 = 0x0A1A_0A0D;

		stream.Seek(_binaryEntry.FileOffset, SeekOrigin.Begin);

		_bitmapInfoHeader = new();
		stream.ReadExactly(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref _bitmapInfoHeader, 1)));

		this.IsPngData = false;
		if (_bitmapInfoHeader.Size != IProvideStructSize<BITMAPINFOHEADER>.SizeOf)
		{
			Guard.IsTrue(
				_bitmapInfoHeader.Size == pngSignature1 || _bitmapInfoHeader.Size == pngSignature2,
				nameof(stream), Properties.Resources.ArgumentExceptionBitmapInfoHeaderStreamIsInvalid);

			this.IsPngData = true;
			this.ImageData = [];
		}

		int imageDataSize = (int)_binaryEntry.BytesInRes;
		this.ImageData = new byte[imageDataSize];
		stream.Seek(_binaryEntry.FileOffset, SeekOrigin.Begin);
		stream.ReadExactly(this.ImageData, 0, imageDataSize);

		this.Icon = UserApi.CreateIconFromBits(this.ImageData);
	}

	public void Dispose()
	{
		this.ImageData = [];
		this.Icon.Dispose();
		GC.SuppressFinalize(this);
	}

	~IconDirectoryItem() => this.Dispose();

	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal struct DirEntry
	{
		private static int GetSizeOf() { unsafe { return sizeof(DirEntry); } }
		public static readonly int SizeOf = GetSizeOf();

		public IconResDir ResDirEntry;
		public ushort Planes;
		public ushort BitCount;
		public uint BytesInRes;
		public uint FileOffset;
	}
}

public static class IconFileReader
{
	public static IEnumerable<IconDirectoryItem> GetIconDirectoryEntries(Stream icoFileDataStream)
	{
		Guard.IsNotNull(icoFileDataStream);
		Guard.CanRead(icoFileDataStream);

		// Read the ICO file header
		var header = new IconCursorHeader();
		icoFileDataStream.ReadExactly(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref header, 1)));
		Guard.IsTrue(
			header.ResourceType == ResourceType.Icon || header.ResourceType == ResourceType.Cursor,
			nameof(header.ResourceType), Properties.Resources.ArgumentExceptionStreamIsNotIcoOrCursorFormat);

		// Read each icon directory item
		for (int i = 0; i < header.ResourceCount; ++i)
		{
			var iconDirectoryItem = IconDirectoryItem.CreateFromStream(icoFileDataStream);
			yield return iconDirectoryItem;
		}
	}
}
