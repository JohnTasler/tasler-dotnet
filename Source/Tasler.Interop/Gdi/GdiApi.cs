using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Principal;
using Microsoft.Win32.SafeHandles;

namespace Tasler.Interop.Gdi;

public static partial class GdiApi
{
	/// <summary>
/// Creates a solid brush with the specified color.
/// </summary>
/// <param name="color">The RGB color value for the brush.</param>
/// <returns>A SafeGdiBrushOwned representing the created solid brush.</returns>
public static SafeGdiBrushOwned CreateSolidBrush(uint color) => NativeMethods.CreateSolidBrush(color);

	/// <summary>
	/// Flushes the GDI batch, ensuring all pending GDI operations are completed.
	/// </summary>
	/// <exception cref="Win32Exception">Thrown if the native GDI flush operation fails.</exception>
	public static void GdiFlush()
	{
		if (!GdiApi.NativeMethods.GdiFlush())
			throw new Win32Exception();
	}

	/// <summary>
	/// Combines two ROP3 raster operation codes into a single ROP4 code for use in advanced GDI operations.
	/// </summary>
	/// <param name="foregroundOperation">The foreground ROP3 operation code.</param>
	/// <param name="backgroundOperation">The background ROP3 operation code.</param>
	/// <returns>A 32-bit ROP4 code representing the combination of the specified foreground and background operations.</returns>
	public static uint MAKEROP4(ROP3 foregroundOperation, ROP3 backgroundOperation)
	{
		return (uint)(((((uint)backgroundOperation) << 8) & 0xFF000000) | ((uint)foregroundOperation));
	}

	#region Nested Types
	internal static partial class NativeMethods
	{
		#region Constants
		private const string ApiLib = "gdi32.dll";
		#endregion Constants

		[LibraryImport(ApiLib)]
		public static partial int GetPixel(SafeHdc hdc, int nXPos, int nYPos);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool DeleteDC(SafeHdc hdc);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool DeleteObject(SafeGdiObject hObject);

		[LibraryImport(ApiLib)]
		public static partial SafeGdiObject GetStockObject(StockObject n);

		[LibraryImport(ApiLib, EntryPoint = nameof(GetStockObject))]
		public static partial SafeGdiBrush GetStockBrush(StockBrush n);

		[LibraryImport(ApiLib, EntryPoint = nameof(GetStockObject))]
		public static partial SafeGdiPen GetStockPen(StockPen n);

		[LibraryImport(ApiLib, EntryPoint = nameof(GetStockObject))]
		public static partial SafeGdiFont GetStockFont(StockFont n);

		[LibraryImport(ApiLib, EntryPoint = nameof(GetStockObject))]
		public static partial SafeGdiPalette GetStockPalette(StockPalette n);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafePrivateHdc CreateCompatibleDC(SafeHdc hDC);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiBitmapOwned CreateCompatibleBitmap(SafeHdc hdc, int width, int height);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiBitmapOwned CreateDIBSection(SafeHdc hdc, BITMAPINFOHEADER pbmi,
			int iUsage, out nint ppvBits, nint hSection, int dwOffset);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiBitmapOwned CreateDIBSection(SafeHdc hdc, BITMAPINFOHEADER pbmi,
			int iUsage, out nint ppvBits, SafeMemoryMappedFileHandle hSection, int dwOffset);

		[LibraryImport(ApiLib)]
		public static partial SafeGdiRgnOwned CreateRectRgn(int x1, int y1, int x2, int y2);

		[LibraryImport(ApiLib)]
		public static partial SafeGdiRgnOwned CreateRectRgnIndirect(ref RECT rect);

		[LibraryImport(ApiLib)]
		public static partial SafeGdiRgnOwned CreateRoundRectRgn(int x1, int y1, int x2, int y2, int w, int h);

		[LibraryImport(ApiLib)]
		public static partial SafeGdiPenOwned CreatePen(PenStyle penStyle, int width, uint color);

		[LibraryImport(ApiLib)]
		public static partial SafeGdiBrushOwned CreateSolidBrush(uint color);

		[LibraryImport(ApiLib)]
		public static partial int GetDeviceCaps(SafeHdc hdc, DeviceCapability nIndex);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool MoveToEx(SafeHdc hdc, int x, int y, nint lpPoint = 0);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool MoveToEx(SafeHdc hdc, int x, int y, out POINT lpPoint);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool LineTo(SafeHdc hdc, int xEnd, int yEnd);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool PolyPolyline(SafeHdc hdc,
			[In] POINT[] points,
			[MarshalUsing(CountElementName = nameof(count))] [In] uint[] dwPolyPoints,
			int count);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool Rectangle(SafeHdc hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

		[LibraryImport(ApiLib)]
		public static partial SafeGdiObject SelectObject(SafeHdc hdc, SafeGdiObject obj);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial uint SetBkColor(SafeHdc hdc, uint color);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial BackgroundMode SetBkMode(SafeHdc hdc, BackgroundMode bkMode);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial uint SetDCPenColor(SafeHdc hdc, uint color);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiPenOwned ExtCreatePen(
				PenStyle penStyle, int width, LOGBRUSH logBrush, int segmentCount,
				[MarshalUsing(CountElementName = nameof(segmentCount))] [In] int[] segments);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool BitBlt(
				SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
				SafeHdc hdcSrc, int xSrc, int ySrc, ROP3 dwRop);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool StretchBlt(
			SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
			SafeHdc hdcSrc, int xSrc, int ySrc, int cxSrc, int cySrc, ROP3 dwRop);

		[LibraryImport(ApiLib)]
		public static partial StretchBltMode SetStretchBltMode(SafeHdc hdc, StretchBltMode stretchMode);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool MaskBlt(
			SafeHdc hdcDest, int xDest, int yDest, int width, int height,
			SafeHdc hdcSrc, int xSrc, int ySrc,
			SafeGdiBitmap hbmMask, int xMask, int yMask, uint rop);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial ROP2 SetROP2(SafeHdc hdc, ROP2 mixMode);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool GdiFlush();

		[LibraryImport(ApiLib)]
		public unsafe static partial int GetObjectW(nint handle, int count, void* info);
	}
	#endregion Nested Types
}
