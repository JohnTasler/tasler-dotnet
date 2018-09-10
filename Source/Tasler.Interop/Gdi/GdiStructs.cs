using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop.Gdi
{
    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAP
    {
        public int type;
        public int width;
        public int height;
        public int widthBytes;
        public ushort planes;
        public ushort bitsPixel;
        public IntPtr bits;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class BITMAPINFOHEADER
    {
        public int size;
        public int width;
        public int height;
        public ushort planes;
        public ushort bitCount;
        public uint compression;
        public uint sizeImage;
        public int xPelsPerMeter;
        public int yPelsPerMeter;
        public uint clrUsed;
        public uint clrImportant;

        public static readonly int MarhalSizeOf = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
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
    public class DIBSECTION
    {
        public BITMAP bm;
        public BITMAPINFOHEADER bmih;
        public uint redBitfields;
        public uint greenBitfields;
        public uint blueBitfields;
        public IntPtr hSection;
        public uint offset;

        public static readonly int MarhalSizeOf = Marshal.SizeOf(typeof(DIBSECTION));
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct PAINTSTRUCT
    {
        public IntPtr hdc;
        public bool fErase;
        public RECT rcPaint;
        public bool fRestore;
        public bool fIncUpdate;
        public int reserved1;
        public int reserved2;
        public int reserved3;
        public int reserved4;
        public int reserved5;
        public int reserved6;
        public int reserved7;
        public int reserved8;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class LOGBRUSH
    {
        public BrushStyle Style;
        public uint       Color;
        public IntPtr     Hatch;
    }
}
