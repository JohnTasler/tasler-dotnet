using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Tasler.Extensions;
using Tasler.Interop.Gdi;
using Tasler.SuppressMessage;

namespace Tasler.Interop.Shell;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public struct SHFILEINFOW
{
	public nint hIcon;
	public int iIcon;
	public SFGAO attributes;
	public unsafe fixed char displayName[260];
	public unsafe fixed char typeName[80];
};

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public struct IMAGEINFO
{
	public nint hbmImage;
	public nint hbmMask;
	public int Unused1;
	public int Unused2;
	public RECT rcImage;
}

[StructLayout(LayoutKind.Sequential)]
[SuppressMessage(Category.Style, CheckId.IDE1006_NamingStyles, Justification = Justification.NamingStyles)]
public struct IMAGELISTDRAWPARAMS
{
	private int cbSize = IMAGELISTDRAWPARAMS.SizeOf;
	public nint himl;
	public int i;
	public nint hdcDst;
	public int x;
	public int y;
	public int cx;
	public int cy;
	public int xBitmap;        // x offest from the upperleft of bitmap
	public int yBitmap;        // y offset from the upperleft of bitmap
	public COLORREF rgbBk;
	public COLORREF rgbFg;
	public ImageListDrawFlags fStyle;
	public ROP3 dwRop;
	public ImageListStateFlags fState;
	public uint Frame;
	public COLORREF crEffect;

	public IMAGELISTDRAWPARAMS() { }
}
