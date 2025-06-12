using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;
using Tasler.Extensions;
using Tasler.Interop.Gdi;
using Tasler.Interop.User;
using Tasler.IO;

namespace Tasler.Interop.Resources;

/// <summary>
/// The type of the file stream resource. Cursors and icons have very similar structures.
/// </summary>
public enum ResourceType : ushort
{
	Icon = 1,
	Cursor = 2,
}

/// <summary>
/// The header of the file stream reasource. Cursors and icons have very similar structures. This
/// repesents the <c>NEWHEADER</c> presented in the Windows SDK documentation for the data of the
/// <c>RT_GROUP_ICON</c> and <c>RT_GROUP_CURSOR</c> resource types.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct IconCursorHeader
{
	private ushort _reserved;
	/// <summary>The resource type, cursor or icon. Cursors and icons have very similar structures.</summary>
	public ResourceType ResourceType;
	/// <summary>The number of icons or cursors in the file stream resource.</summary>
	public ushort ResourceCount;
}

/// <summary>
/// From the Windows SDK documentation:
///   "The CURSORRESHEADER structure defines the header of a cursor resource directory entry."
/// From observation of .CUR files, it appears that the CURSORRESHEADER is identical to the ICONRESHEADER.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 2)]
public struct CursorResDir
{
	/// <summary>Gets or sets the width.</summary>
	/// <value>The width in pixels.</value>
	public ushort Width;

	/// <summary>Gets or sets the height.</summary>
	/// <value>The height in pixels.</value>
	public ushort Height;
}

/// <summary>
/// The header of the resource directory entry for an icon.
/// Cursors and icons have very similar structures, but this header is one difference.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct IconResDir
{
	private byte _width;
	private byte _height;
	private byte _colorCount;
	private byte _reserved;

	/// <summary>Gets or sets the width.</summary>
	/// <value>The width in pixels.</value>
	/// <remarks>Since this is stored as a byte, the maximum value is 256, stored as zero.</remarks>
	public int Width
	{
		get => GetExtent(_width);
		set => SetExtent(ref _width, value);
	}

	/// <summary>Gets or sets the height.</summary>
	/// <value>The height in pixels.</value>
	/// <remarks>Since this is stored as a byte, the maximum value is 256, stored as zero.</remarks>
	public int Height
	{
		get => GetExtent(_height);
		set => SetExtent(ref _height, value);
	}

	/// <summary>Gets or sets the color count.</summary>
	/// <value>The number of colors in each pixel.</value>
	/// <remarks>Since this is stored as a byte, the maximum value is 256, stored as zero.</remarks>
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

	/// <summary>Returns a string that represents the current object.</summary>
	public override string ToString() => $"{Width}x{Height} {ColorCount}bpp";
}

/// <summary>
/// After the <c>RT_GROUP_ICON</c> header, represented by <see cref="IconCursorHeader"/>, each
/// <c>RT_ICON</c> represents the image data of one image resolution and bit depth. The directory
/// of these image items is represented by a sequence of directory entries, structured as
/// <see cref="DirEntry"/>. This class, <see cref="IconDirectoryItem"/>, represents each of these
/// directory items and its access to its image data.
/// </summary>
/// <seealso cref="System.IDisposable" />
public class IconDirectoryItem
{
	private DirEntry _binaryEntry = new();

	/// <summary>
	/// Constructor to read the icon directory item from a stream<.
	/// /summary>
	/// <param name="stream">The <see cref="Stream"/> from which to read the icon directory item.</param>
	/// <remarks>
	///   Upon return, the <paramref name="stream"/> is positioned after the next icon directory
	///   item, even though the image data has been read further into the stream.
	/// </remarks>
	private IconDirectoryItem(Stream stream)
	{
		Guard.IsNotNull(stream, nameof(stream));
		Guard.CanRead(stream);

		stream.ReadStruct(out _binaryEntry);

		long fileOffset = stream.Position;
		using (var scope = new DisposeScopeExit(() => stream.Position = fileOffset))
		{
			this.LoadImageData(stream);
		}
	}

	/// <summary>
	/// Creates the icon directory entry from the specified <paramref name="stream"/>.
	/// </summary>
	/// <param name="stream">The stream.</param>
	/// <returns>An instance of the <see cref="IconDirectoryItem"/> class</returns>
	internal static IconDirectoryItem CreateFromStream(Stream stream)
	{
		var iconDirectoryItem = new IconDirectoryItem(stream);
		return iconDirectoryItem;
	}

	/// <summary>Gets the width, in pixels, of the icon image.</summary>
	/// <value>The width, in pixels.</value>
	public int Width => _binaryEntry.ResDirEntry.Width;

	/// <summary>Gets the height, in pixels, of the icon image.</summary>
	/// <value>The height, in pixels.</value>
	public int Height => _binaryEntry.ResDirEntry.Height;

	/// <summary>Gets the number of bits used to represent colors in each pixel.</summary>
	/// <value>The number of bits</value>
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

	public SafeGdiIconOwned CreateIcon()
	{
		if (this.ImageData.Length == 0)
			return new() { Handle = nint.Zero };

		return UserApi.CreateIconFromBits(this.ImageData);
	}

	private void LoadImageData(Stream stream)
	{
		const int pngSignature1 = 0x474E_5089;
		const int pngSignature2 = 0x0A1A_0A0D;

		_bitmapInfoHeader = new();
		stream.Seek(_binaryEntry.FileOffset, SeekOrigin.Begin);
		stream.ReadStruct(out _bitmapInfoHeader);

		this.IsPngData = false;
		if (_bitmapInfoHeader.Size != BITMAPINFOHEADER.SizeOf)
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
	}

	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal struct DirEntry
	{
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
