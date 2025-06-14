using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;
using Tasler.Extensions;

namespace Tasler.Interop.Gdi;

/// <summary>Defines the type, width, height, color format, and bit values of a bitmap.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct BITMAP
{
	private int _type = 0;

	/// <summary>The width, in pixels, of the bitmap. The width must be greater than zero.</summary>
	public int Width;

	/// <summary>The height, in pixels, of the bitmap. The height must be greater than zero.</summary>
	public int Height;

	/// <summary>
	/// The number of bytes in each scan line. This value must be divisible by 2, because the system
	/// assumes that the bit values of a bitmap form an array that is word aligned.
	/// </summary>
	public int WidthInBytes;

	/// <summary>The number of color planes for the target device. This value must be set to 1.</summary>
	public ushort Planes;

	/// <summary>The number of bits required to indicate the color of a pixel.</summary>
	public ushort BitsPerPixel;

	/// <summary>
	/// A pointer to the location of the bit values for the bitmap. The bmBits member must be a
	/// pointer to an array of character (1-byte) values.
	/// </summary>
	public nint Bits;

	/// <summary>
	/// Initializes a new instance of the BITMAP struct with default values.
	/// </summary>
	public BITMAP() { }

	/// <summary>
	/// Initializes a new BITMAP structure with the specified dimensions, color planes, bit depth,
	/// and a pointer to the bitmap bits.
	/// </summary>
	/// <param name="width">The width of the bitmap, in pixels.</param>
	/// <param name="height">The height of the bitmap, in pixels.</param>
	/// <param name="widthInBytes">The width of the bitmap, in bytes.</param>
	/// <param name="planes">The number of color planes.</param>
	/// <param name="bitsPerPixel">The number of bits per pixel.</param>
	/// <param name="bits">A pointer to the bitmap pixel data.</param>
	public BITMAP(int width, int height, int widthInBytes, ushort planes, ushort bitsPerPixel, nint bits)
		: this()
	{
		Width = width;
		Height = height;
		WidthInBytes = widthInBytes;
		Planes = planes;
		BitsPerPixel = bitsPerPixel;
		Bits = (nint)bits;
	}

	/// <summary>
	/// Initializes a new BITMAP structure with the specified dimensions, color planes, bit depth,
	/// and a pointer to the bitmap bits.
	/// </summary>
	/// <param name="width">The width of the bitmap, in pixels.</param>
	/// <param name="height">The height of the bitmap, in pixels.</param>
	/// <param name="widthInBytes">The width of the bitmap, in bytes.</param>
	/// <param name="planes">The number of color planes.</param>
	/// <param name="bitsPerPixel">The number of bits per pixel.</param>
	/// <param name="bits">A pointer to the bitmap pixel data.</param>
	public unsafe BITMAP(int width, int height, int widthInBytes, ushort planes, ushort bitsPerPixel, byte* bits)
		: this(width, height, widthInBytes, planes, bitsPerPixel, (nint)bits)
	{
	}
}

[StructLayout(LayoutKind.Sequential)]
public struct BITMAPINFOHEADER
{
	public int    Size = BITMAPINFOHEADER.SizeOf;
	public int    Width;
	public int    Height;
	public ushort Planes;
	public ushort BitCount;
	public uint   Compression;
	public uint   SizeImage;
	public int    XPelsPerMeter;
	public int    YPelsPerMeter;
	public uint   ColorsUsed;
	public uint   ColorsImportant;

	/// <summary>
	/// Initializes a new instance of the BITMAPINFOHEADER struct with default values.
	/// </summary>
	public BITMAPINFOHEADER() { }

	/// <summary>
	/// Returns a formatted string representation of the BITMAPINFOHEADER fields.
	/// </summary>
	/// <returns>A string summarizing width, height, planes, bit count, compression, image size, resolution, and color usage.</returns>
	public override string ToString()
		=>  $"Width: {Width}, Height: {Height}\nPlanes: {Planes}, BitCount: {BitCount}, Compression: {Compression}\nSizeImage: {SizeImage:X8} XPelsPerMeter: {XPelsPerMeter}, YPelsPerMeter: {YPelsPerMeter}\nColorsUsed: {ColorsUsed}, ColorsImportant: {ColorsImportant}";
}

[StructLayout(LayoutKind.Sequential)]
public struct BLENDFUNCTION
{
	public byte BlendOp;
	public byte BlendFlags;
	public byte SourceConstantAlpha;
	public byte AlphaFormat;
}

[StructLayout(LayoutKind.Sequential)]
public struct DIBSECTION
{
	public BITMAP Bitmap;
	public BITMAPINFOHEADER BitmapInfoHeader;
	public uint RedBitfields;
	public uint GreenBitfields;
	public uint BlueBitfields;
	public nint HSection;
	public uint Offset;
}

[StructLayout(LayoutKind.Sequential)]
public struct PAINTSTRUCT
{
	private nint _hdc;
	public bool MustErase;
	public RECT PaintRectangle;
	private bool _fRestore;
	private bool _fIncUpdate;
	private ulong _reserved1;
	private ulong _reserved2;
	private ulong _reserved3;
	private ulong _reserved4;

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Most natural name for interop type")]
	public readonly SafeHdc hdc => new() { Handle = _hdc };
}

[StructLayout(LayoutKind.Sequential)]
public struct LOGBRUSH
{
	public BrushStyle Style;
	public uint Color;
	public nint Hatch;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LOGFONTW
{
	public int             Height;
	public int             Width;
	public int             Escapement;
	public int             Orientation;
	public FontWeight      Weight;
	private byte           _italic;
	private byte           _underline;
	private byte           _strikeOut;
	public FontCharSet     CharSet;
	public OutputPrecision OutPrecision;
	public ClipPrecision   ClipPrecision;
	public FontQuality     Quality;
	public PitchAndFamily  PitchAndFamily;
	private ulong          _faceName;
	private ulong          _reserved0;
	private ulong          _reserved1;
	private ulong          _reserved2;

	public bool IsItalic
	{
		get => _italic != 0;
		set => _italic = (byte)(value ? 1 : 0);
	}

	public bool IsUnderline
	{
		get => _underline != 0;
		set => _underline = (byte)(value ? 1 : 0);
	}

	public bool IsStrikeOut
	{
		get => _strikeOut != 0;
		set => _strikeOut = (byte)(value ? 1 : 0);
	}

	/// <summary>Gets or sets the name of the typeface.</summary>
	/// <value>The name of the face.</value>
	public string FaceName
	{
		get
		{
			unsafe
			{
				fixed (void* pFaceName = &_faceName)
				{
					return new string((char*)pFaceName);
				}
			}
		}
		set
		{
			Guard.HasSizeLessThan(value, 32, nameof(FaceName));
			int byteLength = value.Length * sizeof(char);
			unsafe
			{
				fixed (void* pFaceName = &_faceName)
				fixed (void* pValue = value)
				{
					_faceName = _reserved0 = _reserved1 = _reserved2 = 0;
					Buffer.MemoryCopy(pValue, pFaceName, byteLength, byteLength);
				}
			}
		}
	}
}

[StructLayout(LayoutKind.Sequential)]
public struct COLORREF
{
	public readonly uint Value;

	/// <summary>
	/// Initializes a COLORREF instance from a 32-bit unsigned integer value.
	/// </summary>
	public COLORREF(uint value)
	{
		Value = value;
	}

	/// <summary>
	/// Initializes a COLORREF value from individual red, green, and blue byte components.
	/// </summary>
	/// <param name="r">The red component.</param>
	/// <param name="g">The green component.</param>
	/// <param name="b">The blue component.</param>
	public COLORREF(byte r, byte g, byte b)
	{
		Value = (uint)((b << 16) | (g << 8) | r);
	}

	public readonly byte R => (byte)(Value & 0xFF);
	public readonly byte G => (byte)((Value >> 8) & 0xFF);
	public readonly byte B => (byte)((Value >> 16) & 0xFF);

	public readonly byte Red => (byte)(Value & 0xFF);
	public readonly byte Green => (byte)((Value >> 8) & 0xFF);
	public readonly byte Blue => (byte)((Value >> 16) & 0xFF);
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct RGBQUAD
{
	public byte Blue;
	public byte Green;
	public byte Red;
	private byte _reserved;
}

[StructLayout(LayoutKind.Sequential)]
public struct FontWeight
{
	public int Value;

	/// <summary>
	/// Initializes a new instance of the <see cref="FontWeight"/> struct with the specified weight value.
	/// </summary>
	/// <param name="value">The integer value representing the font weight.</param>
	public FontWeight(int value)
	{
		Value = value;
	}

	public static implicit operator int(FontWeight weight) => weight.Value;
	public static implicit operator FontWeight(int value) => new(value);

	/// <summary>Returns the string representation of the font weight value.</summary>
	/// <returns>The font weight as a string.</returns>
	public override string ToString() => Value.ToString();

	// Font weight constants
	public static FontWeight DontCare   =>   0;
	public static FontWeight Thin       => 100;
	public static FontWeight ExtraLight => 200;
	public static FontWeight UltraLight => 200;
	public static FontWeight Light      => 300;
	public static FontWeight Normal     => 400;
	public static FontWeight Regular    => 400;
	public static FontWeight Medium     => 500;
	public static FontWeight SemiBold   => 600;
	public static FontWeight DemiBold   => 600;
	public static FontWeight Bold       => 700;
	public static FontWeight ExtraBold  => 800;
	public static FontWeight UltraBold  => 800;
	public static FontWeight Heavy      => 900;
	public static FontWeight Black      => 900;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PitchAndFamily
{
	public byte Value;

	public FontPitch Pitch
	{
		get => (FontPitch)(Value & 0x03);
		set => Value = (byte)((Value & ~0x03) | ((byte)value & 0x03));
	}

	public FontFamily Family
	{
		get => (FontFamily)((Value >> 2) & 0x0F);
		set => Value = (byte)((Value & ~0x3C) | ((byte)value << 2));
	}
}

