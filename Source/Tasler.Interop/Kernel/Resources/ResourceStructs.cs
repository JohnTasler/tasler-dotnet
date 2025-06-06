using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;
using Tasler.Interop.Gdi;

namespace Tasler.Interop.Kernel.Resources;

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

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct IconResDir
{
	private byte _width;
	private byte _height;
	public byte ColorCount;
	private byte _reserved;

	public int Width
	{
		get => _width == 0 ? 256 : (int)_width;
		set => SetExtent(ref _width, value);
	}

	public int Height
	{
		get => _height == 0 ? 256 : (int)_width;
		set => SetExtent(ref _height, value);
	}

	private static void SetExtent(ref byte extent, int value)
	{
		Guard.IsBetweenOrEqualTo(value, 0, 256, nameof(value));
		extent = value == 256 ? (byte)0 : (byte)value;
	}
}

public struct IconDirectoryItem
{
	internal BinaryEntry _binaryEntry = new();

	// Constructor to initialize the struct with default values
	public IconDirectoryItem(byte width, byte height, byte colorCount, ushort planes, ushort bitCount, uint bytesInRes, uint fileOffset)
	{
		_binaryEntry.ResDirEntry.Width = width;
		_binaryEntry.ResDirEntry.Height = height;
		_binaryEntry.ResDirEntry.ColorCount = colorCount;
		_binaryEntry.Planes = planes;
		_binaryEntry.BitCount = bitCount;
		_binaryEntry.BytesInRes = bytesInRes;
		_binaryEntry.FileOffset = fileOffset;
	}

	public IconResDir ResDirEntry => _binaryEntry.ResDirEntry;
	public ushort Planes => _binaryEntry.Planes;
	public ushort BitCount => _binaryEntry.BitCount;
	public uint BytesInRes => _binaryEntry.BytesInRes;
	public uint FileOffset => _binaryEntry.FileOffset;

	public BITMAPINFOHEADER BitmapInfoHeader => _bitmapInfoHeader;
	private BITMAPINFOHEADER _bitmapInfoHeader;

	public byte[] ImageData { get; private set; } = [];

	internal void LoadImages(Stream stream)
	{
		Guard.IsNotNull(stream, nameof(stream));
		Guard.IsTrue(stream.CanRead, nameof(stream), "Stream must be readable.");
		if (stream.Position != _binaryEntry.FileOffset)
		{
			stream.Seek(_binaryEntry.FileOffset, SeekOrigin.Begin);
		}

		_bitmapInfoHeader = new();
		stream.ReadExactly(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref _bitmapInfoHeader, 1)));

		this.ImageData = new byte[_binaryEntry.BytesInRes - BITMAPINFOHEADER.SizeOf];
		stream.ReadExactly(this.ImageData, 0, (int)_binaryEntry.BytesInRes - BITMAPINFOHEADER.SizeOf);
		// Here you can process the image data as needed
		// For example, you could convert it to a Bitmap or any other image format
		// This part is left as an exercise for the user
	}

	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal struct BinaryEntry
	{
		private static int GetSizeOf() { unsafe { return sizeof(BinaryEntry); } }
		public static readonly int SizeOf = GetSizeOf();

		public IconResDir ResDirEntry;
		public ushort Planes;
		public ushort BitCount;
		public uint BytesInRes;
		public uint FileOffset;
	}
}

public static class IconFileExtensions
{
	public static IEnumerable<IconDirectoryItem> GetIconDirectoryEntries(Stream icoFileDataStream)
	{
		Guard.IsNotNull(icoFileDataStream);
		Guard.IsTrue(icoFileDataStream.CanRead, nameof(icoFileDataStream), "Stream must be readable.");

		// Read the ICO file header
		IconCursorHeader header = new IconCursorHeader();
		icoFileDataStream.ReadExactly(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref header, 1)));
		Guard.IsTrue(header.ResourceType == ResourceType.Icon, nameof(header.ResourceType), "The stream is not a valid ICO stream.");

		// Read each icon directory item
		for (int i = 0; i < header.ResourceCount; ++i)
		{
			var iconDirectoryItem = new IconDirectoryItem();
			icoFileDataStream.ReadExactly(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref iconDirectoryItem._binaryEntry, 1)));

			long fileOffset = icoFileDataStream.Position;
			using (var scope = new DisposeScopeExit(() => icoFileDataStream.Position = fileOffset))
			{
				iconDirectoryItem.LoadImages(icoFileDataStream);
			}

			yield return iconDirectoryItem;
		}
	}
}
