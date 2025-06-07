using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace Tasler.Interop.Gdi;

public static partial class GdiApi
{
	public static SafeGdiBrushOwned CreateSolidBrush(uint color) => NativeMethods.CreateSolidBrush(color);

	public static void GdiFlush()
	{
		if (!GdiApi.NativeMethods.GdiFlush())
			throw new Win32Exception();
	}

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
		public static partial bool PolyPolyline(SafeHdc hdc, POINT[] pt, uint[] dwPolyPoints, int count);

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
				[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] int[] segments);

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


		/// <summary>
		/// Combines the color data for the source and destination bitmaps using the specified mask and raster operation.
		/// </summary>
		/// <param name="hdcDest">A handle to the destination device context.</param>
		/// <param name="xDest">The x-coordinate, in logical units, of the upper-left corner of the destination rectangle.</summary
		/// <param name="yDest">The y-coordinate, in logical units, of the upper-left corner of the destination rectangle.</summary
		/// <param name="width">The width, in logical units, of the destination rectangle and source bitmap.</summary>
		/// <param name="height">The height, in logical units, of the destination rectangle and source bitmap.</summary>
		/// <param name="hdcSrc">A handle to the device context from which the bitmap is to be copied. It must be zero if the dwRop parameter specifies a raster operation that does not include a source.</summary>
		/// <param name="xSrc">The x-coordinate, in logical units, of the upper-left corner of the source bitmap.</summary>
		/// <param name="ySrc">The y-coordinate, in logical units, of the upper-left corner of the source bitmap.</summary>
		/// <param name="hbmMask">A handle to the monochrome mask bitmap combined with the color bitmap in the source device context.</summary>
		/// <param name="xMask">The horizontal pixel offset for the mask bitmap specified by the hbmMask parameter.</summary>
		/// <param name="yMask">The vertical pixel offset for the mask bitmap specified by the hbmMask parameter.</summary>
		/// <param name="rop">The foreground and background ternary raster operation codes (ROPs) that the function uses to control the combination of source and destination data. The background raster operation code is stored in the high-order byte of the high-order word of this value; the foreground raster operation code is stored in the low-order byte of the high-order word of this value; the low-order word of this value is ignored, and should be zero. The <see cref="MAKEROP4" /> method creates such combinations of foreground and background raster operation codes.</summary>
		/// <returns>
		///	  <para>If the function succeeds, the return value is nonzero.</para>
		///   <para>If the function fails, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		///   <para>The <see cref="MaskBlt"/> function uses device-dependent bitmaps.</para>
		///   <para>A value of 1 in the mask specified by hbmMask indicates that the foreground raster operation code specified by <paramref name="rop"/> should be applied at that location. A value of 0 in the mask indicates that the background raster operation code specified by dwRop should be applied at that location.</para>
		///   <para>If the raster operations require a source, the mask rectangle must cover the source rectangle. If it does not, the function will fail. If the raster operations do not require a source, the mask rectangle must cover the destination rectangle. If it does not, the function will fail.</para>
		///   <para>If a rotation or shear transformation is in effect for the source device context when this function is called, an error occurs. However, other types of transformation are allowed.</para>
		///   <para>If the color formats of the source, pattern, and destination bitmaps differ, this function converts the pattern or source format, or both, to match the destination format.</para>
		///   <para>If the mask bitmap is not a monochrome bitmap, an error occurs.</para>
		///   <para>When an enhanced metafile is being recorded, an error occurs (and the function returns <see langword="false"/>) if the source device context identifies an enhanced-metafile device context.</para>
		///   <para>Not all devices support the <see cref="MaskBlt"/> function. An application should call the <see cref="GetDeviceCaps"/> function with the nIndex parameter as RC_BITBLT to determine whether a device supports this function.</para>
		///   <para>If no mask bitmap is supplied, this function behaves exactly like BitBlt, using the foreground raster operation code.</para>
		///   <para>ICM: No color management is performed when blits occur.</para>
		///   <para>When used in a multiple monitor system, both hdcSrc and hdcDest must refer to the same device or the function will fail. To transfer data between DCs for different devices, convert the memory bitmap (compatible bitmap, or DDB) to a DIB by calling GetDIBits. To display the DIB to the second device, call SetDIBits or StretchDIBits.</para>
		/// </remarks>
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
	}
	#endregion Nested Types
}
