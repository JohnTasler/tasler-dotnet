using System.Runtime.InteropServices;

namespace Tasler.Interop.Gdi;

[StructLayout(LayoutKind.Sequential)]
public struct BITMAP
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
public struct BITMAPINFOHEADER
{
	private static int GetSizeOf() { unsafe { return sizeof(BITMAPINFOHEADER); } }
	public static readonly int SizeOf = GetSizeOf();

	public int Size = SizeOf;
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

	public static readonly int MarhalSizeOf = Marshal.SizeOf<DIBSECTION>();
}

[StructLayout(LayoutKind.Sequential)]
public struct PAINTSTRUCT
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Most natural name for interop type")]
	public SafeHdc hdc;
	public bool MustErase;
	public RECT PaintRectangle;
	private bool _fRestore;
	private bool _fIncUpdate;
	private ulong _reserved1;
	private ulong _reserved2;
	private ulong _reserved3;
	private ulong _reserved4;
}

[StructLayout(LayoutKind.Sequential)]
public struct LOGBRUSH
{
	public BrushStyle Style;
	public uint Color;
	public nint Hatch;
}
