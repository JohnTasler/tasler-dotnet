using System.Diagnostics;
using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;
using Tasler.Extensions;
using Tasler.Interop.Gdi;
using Tasler.Interop.Kernel;
using Tasler.Interop.User;
using Tasler.IO;

namespace Tasler.Interop.Resources;

/// <summary>
/// The type of the file stream resource. Cursors and icons have very similar structures.
/// </summary>
public enum IconCursorResourceType : ushort
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
	public IconCursorResourceType ResourceType;
	/// <summary>The number of icons or cursors in the file stream resource.</summary>
	public ushort ResourceCount;
}

/// <summary>
/// From the Windows SDK documentation:
///   "The CURSORRESHEADER structure defines the header of a cursor resource directory entry."
/// However, from observation of .CUR files, it appears that the CURSORRESHEADER is identical
/// to the ICONRESHEADER.
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
	/// <remarks>
	/// Acceptable values are 2, 8, and 16. The value 0 means that the number of colors deduced from
	/// <see cref="IDirEntry.BitCount"/> and <see cref="IDirEntry.Planes"/> in the
	/// <see cref="DirEntry"/> or <see cref="GroupDirEntry"/> structures.</remarks>
	public int ColorCount
	{
		get => _colorCount;
		set => _colorCount = (byte)value;
	}

	/// <summary>
	/// Returns 256 if the input value is 0; otherwise, returns the input value.
	/// </summary>
	/// <param name="extent">A byte representing width, height, or color count, where 0 indicates 256.</param>
	/// <returns>The extent as an integer, with 0 mapped to 256.</returns>
	private static int GetExtent(byte extent) => extent == 0 ? 256 : extent;

	/// <summary>
	/// Sets the extent value for width, height, or color count, encoding 256 as 0 per ICO format specification.
	/// </summary>
	/// <param name="extent">Reference to the byte field to set.</param>
	/// <param name="value">Extent value, must be between 0 and 256 inclusive.</param>
	private static void SetExtent(ref byte extent, int value)
	{
		Guard.IsBetweenOrEqualTo(value, 0, 256, nameof(value));
		extent = value == 256 ? (byte)0 : (byte)value;
	}

	/// <summary>
	/// Returns a string representation of the icon resource directory entry, including width, height, and color count.
	/// </summary>
	/// <returns>A string in the format "WidthxHeight ColorCountbpp".</returns>
	public override string ToString() => $"{Width}x{Height} {ColorCount}bpp";
}

public interface IIconDirectoryItem
{
	int Width { get; }
	int Height { get; }
	int ColorCount { get; }
	IconResDir ResDirEntry { get; }
	ushort Planes { get; }
	ushort BitCount { get; }
	uint BytesInRes { get; }
	uint FileOffset { get; }
	bool IsPngData { get; }
	byte[] ImageData { get; }
	BITMAPINFOHEADER BitmapInfoHeader { get; }
	SafeGdiIconOwned CreateIcon();
	SafeGdiIconOwned GetIcon(SafeInstanceHandle hModule);
}

/// <summary>
/// After the <c>RT_GROUP_ICON</c> header, represented by <see cref="IconCursorHeader"/>, each
/// <c>RT_ICON</c> represents the image data of one image resolution and bit depth. The directory
/// of these image items is represented by a sequence of directory entries, structured as
/// <see cref="DirEntry"/>. This class, <see cref="IconDirectoryItem"/>, represents each of these
/// directory items and its access to its image data.
/// </summary>
/// <seealso cref="System.IDisposable" />
public class IconDirectoryItem<T> : IIconDirectoryItem
	where T : unmanaged, IDirEntry
{
	private T _binaryEntry;
	private bool _isFromResourceGroupIcon;

	/// <summary>
	/// Constructor to read the icon directory item from a stream<.
	/// /summary>
	/// <param name="stream">The <see cref="Stream"/> from which to read the icon directory item.</param>
	/// <remarks>
	///   Upon return, the <paramref name="stream"/> is positioned after the next icon directory
	///   item, even though the image data has been read further into the stream.
	/// <summary>
	/// Initializes a new instance of <see cref="IconDirectoryItem"/> by reading a directory entry and its associated image data from the provided stream.
	/// </summary>
	/// <param name="stream">A readable stream positioned at an icon directory entry within an ICO or CUR file.</param>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="stream"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown if <paramref name="stream"/> is not readable or contains invalid data.</exception>
	private IconDirectoryItem(Stream stream, bool isFromResourceGroupIcon)
	{
		Guard.IsNotNull(stream, nameof(stream));
		Guard.CanRead(stream);

		stream.ReadStruct(out _binaryEntry);

		_isFromResourceGroupIcon = isFromResourceGroupIcon;

		if (!_isFromResourceGroupIcon)
		{
			long fileOffset = stream.Position;
			using var scope = new DisposeScopeExit(() => stream.Position = fileOffset);
			this.LoadImageData(stream, _binaryEntry.FileOffset);
		}
	}

	/// <summary>
	/// Creates an <see cref="IconDirectoryItem"/> by reading directory entry and image data from the specified stream.
	/// </summary>
	/// <param name="stream">The stream positioned at the start of an icon directory entry.</param>
	/// <returns>An <see cref="IconDirectoryItem"/> representing the parsed entry and its image data.</returns>
	internal static IIconDirectoryItem CreateFromStream(Stream stream, bool isFromResourceGroupIcon = false)
	{
		IIconDirectoryItem iconDirectoryItem = isFromResourceGroupIcon
			? new IconDirectoryItem<GroupDirEntry>(stream, isFromResourceGroupIcon)
			: new IconDirectoryItem<DirEntry>(stream, isFromResourceGroupIcon);
		return iconDirectoryItem;
	}

	public override string ToString() => $"{Width}x{Height} {BitCount}bpp";

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
	public BITMAPINFOHEADER BitmapInfoHeader => _bitmapInfoHeader;
	private BITMAPINFOHEADER _bitmapInfoHeader;

	/// <summary>
	/// Creates a GDI icon handle from the image data of this directory entry.
	/// </summary>
	/// <returns>
	/// A <see cref="SafeGdiIconOwned"/> representing the created icon, or an empty handle if and
	/// error occurs. To get extended error information, call
	/// <see cref="Marshal.GetLastPInvokeError"/>.
	/// </returns>
	public SafeGdiIconOwned CreateIcon()
	{
		if (this.ImageData.Length == 0)
			return new() { Handle = nint.Zero };

		return UserApi.CreateIconFromBits(this.ImageData);
	}

	/// <summary>
	/// Gets the associated GDI icon handle from the specified executable module handle.
	/// </summary>
	/// <returns>
	/// A <see cref="SafeGdiIconOwned"/> representing the loaded icon, or an empty handle if an error
	/// occurs.
	/// </returns>
	public SafeGdiIconOwned GetIcon(SafeInstanceHandle hModule)
	{
		Guard.IsTrue(_isFromResourceGroupIcon);

		var name = new ResourceValue((nint)_binaryEntry.FileOffset);

		var hrsrc = hModule.FindResource(name, new(IntegerResourceType.Icon));
		var hGlobal = hModule.LoadResource(hrsrc);
		var pointer = hGlobal.LockResource();
		unsafe
		{
			var span = new ReadOnlySpan<byte>((void*)pointer, hModule.SizeofResource(hrsrc));
			using var stream = new UnmanagedMemoryStream((byte*)pointer, span.Length);
			this.LoadImageData(stream, 0);
		}
		return this.CreateIcon();
	}

	/// <summary>
	/// Loads the image data and bitmap info header for the icon directory entry from the specified stream.
	/// </summary>
	/// <param name="stream">The stream positioned at the start of the icon or cursor file.</param>
	/// <remarks>
	/// Determines if the image data is in PNG format by inspecting the bitmap info header. Sets the <c>IsPngData</c> property accordingly and reads the image data bytes into <c>ImageData</c>.
	/// </remarks>
	private void LoadImageData(Stream stream, uint fromOffset)
	{
		const int pngSignature1 = 0x474E_5089;
		const int pngSignature2 = 0x0A1A_0A0D;

		stream.Seek(fromOffset, SeekOrigin.Begin);
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
		stream.Seek(fromOffset, SeekOrigin.Begin);
		stream.ReadExactly(this.ImageData, 0, imageDataSize);
	}
}

public interface IDirEntry
{
	IconResDir ResDirEntry { get; }
	ushort Planes { get; }
	ushort BitCount { get; }
	uint BytesInRes { get; }
	uint FileOffset { get; }
}

[StructLayout(LayoutKind.Sequential, Pack = 2)]
internal struct DirEntry : IDirEntry
{
	private IconResDir _resDirEntry;
	private ushort _planes;
	private ushort _bitCount;
	private uint _bytesInRes;
	private uint _fileOffset;

	public IconResDir ResDirEntry => _resDirEntry;
	public ushort Planes => _planes;
	public ushort BitCount => _bitCount;
	public uint BytesInRes => _bytesInRes;
	public uint FileOffset => _fileOffset;
}

[StructLayout(LayoutKind.Sequential, Pack = 2)]
internal struct GroupDirEntry : IDirEntry
{
	private IconResDir _resDirEntry;
	private ushort _planes;
	private ushort _bitCount;
	private uint _bytesInRes;
	private ushort _fileOffset;

	public IconResDir ResDirEntry => _resDirEntry;
	public ushort Planes => _planes;
	public ushort BitCount => _bitCount;
	public uint BytesInRes => _bytesInRes;
	public uint FileOffset => _fileOffset;
}

public static class IconFileReader
{
	/// <summary>
	/// Reads icon or cursor directory entries from a stream containing ICO or CUR file data.
	/// </summary>
	/// <param name="icoFileDataStream">A readable stream positioned at the start of an ICO or CUR file.</param>
	/// <returns>An enumerable sequence of <see cref="IconDirectoryItem"/> objects representing each icon or cursor entry in the file.</returns>
	/// <exception cref="ArgumentNullException">Thrown if <paramref name="icoFileDataStream"/> is null.</exception>
	/// <exception cref="ArgumentException">Thrown if the stream is not readable or does not contain a valid ICO or CUR file header.</exception>
	public static IEnumerable<IIconDirectoryItem> GetIconDirectoryEntries(Stream icoFileDataStream, bool isFromResourceGroupIcon = false)
	{
		Guard.IsNotNull(icoFileDataStream);
		Guard.CanRead(icoFileDataStream);

		// Read the ICO file header
		var header = new IconCursorHeader();
		icoFileDataStream.ReadExactly(MemoryMarshal.AsBytes(MemoryMarshal.CreateSpan(ref header, 1)));
		Guard.IsTrue(
			header.ResourceType == IconCursorResourceType.Icon || header.ResourceType == IconCursorResourceType.Cursor,
			nameof(header.ResourceType), Properties.Resources.ArgumentExceptionStreamIsNotIcoOrCursorFormat);

		// Read each icon directory item
		for (int i = 0; i < header.ResourceCount; ++i)
		{
			var iconDirectoryItem = isFromResourceGroupIcon
				? IconDirectoryItem<GroupDirEntry>.CreateFromStream(icoFileDataStream, isFromResourceGroupIcon)
				: IconDirectoryItem<DirEntry>.CreateFromStream(icoFileDataStream, isFromResourceGroupIcon);
			yield return iconDirectoryItem;
		}
	}
}
