using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CommunityToolkit.Diagnostics;

namespace Tasler.Interop.Gdi;

[StructLayout(LayoutKind.Sequential)]
public struct BITMAP : IProvideStructSize<BITMAP>
{
	private int _type = 0;
	public int Width;
	public int Height;
	public int WidthInBytes;
	public ushort Planes;
	public ushort BitsPerPixel;
	public nint Bits;

	public BITMAP()
	{
	}

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

	public unsafe BITMAP(int width, int height, int widthInBytes, ushort planes, ushort bitsPerPixel, byte* bits)
		: this(width, height, widthInBytes, planes, bitsPerPixel, (nint)bits)
	{
	}
}

[StructLayout(LayoutKind.Sequential)]
public struct BITMAPINFOHEADER : IProvideStructSize<BITMAPINFOHEADER>
{
	public int Size = IProvideStructSize<BITMAPINFOHEADER>.SizeOf;
	public int Width;
	public int Height;
	public ushort Planes;
	public ushort BitCount;
	public uint Compression;
	public uint SizeImage;
	public int XPelsPerMeter;
	public int YPelsPerMeter;
	public uint ColorsUsed;
	public uint ColorsImportant;

	public BITMAPINFOHEADER()
	{
	}

	public override string ToString()
	{
		return $"Width: {Width}, Height: {Height}\nPlanes: {Planes}, BitCount: {BitCount}, Compression: {Compression}\nSizeImage: {SizeImage:X8} XPelsPerMeter: {XPelsPerMeter}, YPelsPerMeter: {YPelsPerMeter}\nColorsUsed: {ColorsUsed}, ColorsImportant: {ColorsImportant}";
	}
}

[StructLayout(LayoutKind.Sequential)]
public struct BLENDFUNCTION : IProvideStructSize<BLENDFUNCTION>
{
	public byte BlendOp;
	public byte BlendFlags;
	public byte SourceConstantAlpha;
	public byte AlphaFormat;
}

[StructLayout(LayoutKind.Sequential)]
public struct DIBSECTION : IProvideStructSize<DIBSECTION>
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
public struct PAINTSTRUCT : IProvideStructSize<PAINTSTRUCT>
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
public struct LOGBRUSH : IProvideStructSize<LOGBRUSH>
{
	public BrushStyle Style;
	public uint Color;
	public nint Hatch;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LOGFONTW : IProvideStructSize<LOGFONTW>
{
	public int Height;
	public int Width;
	public int Escapement;
	public int Orientation;
	public FontWeight Weight;
	private byte _italic;
	private byte _underline;
	private byte _strikeOut;
	public CharSet CharSet;
	public OutputPrecision OutPrecision;
	public ClipPrecision ClipPrecision;
	public FontQuality Quality;
	public PitchAndFamily PitchAndFamily;
	private ulong _faceName;
	private ulong _reserved0;
	private ulong _reserved1;
	private ulong _reserved2;

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
public struct COLORREF : IProvideStructSize<COLORREF>
{
	public readonly uint Value;

	public COLORREF(uint value)
	{
		Value = value;
	}

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
public struct RGBQUAD : IProvideStructSize<RGBQUAD>
{
	public byte Blue;
	public byte Green;
	public byte Red;
	private byte _reserved;
}

[StructLayout(LayoutKind.Sequential)]
public struct FontWeight : IProvideStructSize<FontWeight>
{
	public int Value;

	public FontWeight(int value)
	{
		Value = value;
	}

	public static implicit operator int(FontWeight weight) => weight.Value;
	public static implicit operator FontWeight(int value) => new(value);
	public override string ToString() => Value.ToString();

	// Font weight constants
	public static FontWeight DontCare => 0;
	public static FontWeight Thin => 100;
	public static FontWeight ExtraLight => 200;
	public static FontWeight UltraLight => 200;
	public static FontWeight Light => 300;
	public static FontWeight Normal => 400;
	public static FontWeight Regular => 400;
	public static FontWeight Medium => 500;
	public static FontWeight SemiBold => 600;
	public static FontWeight DemiBold => 600;
	public static FontWeight Bold => 700;
	public static FontWeight ExtraBold => 800;
	public static FontWeight UltraBold => 800;
	public static FontWeight Heavy => 900;
	public static FontWeight Black => 900;
}

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PitchAndFamily : IProvideStructSize<PitchAndFamily>
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

