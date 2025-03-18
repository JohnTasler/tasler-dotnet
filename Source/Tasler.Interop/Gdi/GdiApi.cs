using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Tasler.Interop.User;

namespace Tasler.Interop.Gdi;

public static partial class GdiApi
{
	#region Constants
	private const string ApiLib = "gdi32.dll";
	#endregion Constants

	#region Properties

	/// <summary>
	/// Gets the horizontal scaling factor needed to match the DPI of the screen.
	/// </summary>
	public static double DpiScaleX
	{
		get
		{
			if (double.IsNaN(_dpiScaleX))
			{
				int logPixels;
				using (var hdcScreen = UserApi.GetDC(nint.Zero))
					logPixels = NativeMethods.GetDeviceCaps(hdcScreen, DeviceCapability.LOGPIXELSX);
				var scale = 96.0 / logPixels;
				Interlocked.Exchange(ref _dpiScaleX, scale);
			}

			return _dpiScaleX;
		}
	}
	private static double _dpiScaleX = double.NaN;

	/// <summary>
	/// Gets the vertical scaling factor needed to match the DPI of the screen.
	/// </summary>
	public static double DpiScaleY
	{
		get
		{
			if (double.IsNaN(dpiScaleY))
			{
				int logPixels;
				using (var hdcScreen = UserApi.GetDC(nint.Zero))
					logPixels = NativeMethods.GetDeviceCaps(hdcScreen, DeviceCapability.LOGPIXELSX);
				var scale = 96.0 / logPixels;
				Interlocked.Exchange(ref dpiScaleY, scale);
			}

			return dpiScaleY;
		}
	}
	private static double dpiScaleY = double.NaN;

	#endregion Properties

	#region Methods

	public static SafePrivateHdc CreateCompatibleDC(this SafeHdc hdcExisting)
	{
		var hdc = NativeMethods.CreateCompatibleDC(hdcExisting);
		if (hdc.IsInvalid)
			throw new Win32Exception();
		return hdc;
	}

	public static SafeGdiObjectOwned CreateCompatibleBitmap(this SafeHdc hdc, int width, int height)
	{
		var hbm = NativeMethods.CreateCompatibleBitmap(hdc, width, height);
		if (hbm.IsInvalid)
			throw new Win32Exception();
		return hbm;
	}

	public static SafeGdiObjectOwned CreateDIBSection(this SafeHdc hdc, BITMAPINFOHEADER pbmi, ref nint ppvBits)
	{
		var hbm = NativeMethods.CreateDIBSection(hdc, pbmi, 0, ref ppvBits, nint.Zero, 0);
		if (hbm.IsInvalid)
			throw new Win32Exception();
		return hbm;
	}

	public static SafeGdiObjectOwned CreateDIBSection(this SafeHdc hdc, BITMAPINFOHEADER pbmi, MemoryMappedFile section, ref nint ppvBits)
	{
		var hbm = NativeMethods.CreateDIBSection(hdc, pbmi, 0, ref ppvBits, section.SafeMemoryMappedFileHandle, 0);
		if (hbm.IsInvalid)
			throw new Win32Exception();
		return hbm;
	}

	public static SafeGdiObjectOwned CreateDIBSection(this SafeHdc hdc, int width, int height, ushort bpp, ref nint ppvBits)
	{
		BITMAPINFOHEADER bmi = new BITMAPINFOHEADER();
		bmi.size = BITMAPINFOHEADER.MarhalSizeOf;
		bmi.planes = 1;
		bmi.bitCount = bpp;
		bmi.width = Math.Max(1, width);
		bmi.height = height < 0 ? Math.Min(height, -1) : Math.Max(1, height);

		var hbm = CreateDIBSection(hdc, bmi, ref ppvBits);
		return hbm;
	}

	public static SafeGdiObjectOwned CreateDIBSection(this SafeHdc hdc, int width, int height, ushort bpp, MemoryMappedFile section, ref nint ppvBits)
	{
		BITMAPINFOHEADER bmi = new BITMAPINFOHEADER();
		bmi.size = BITMAPINFOHEADER.MarhalSizeOf;
		bmi.planes = 1;
		bmi.bitCount = bpp;
		bmi.width = Math.Max(1, width);
		bmi.height = height < 0 ? Math.Min(height, -1) : Math.Max(1, height);

		var hbm = CreateDIBSection(hdc, bmi, section, ref ppvBits);
		return hbm;
	}

	public static SafeGdiObjectOwned CreatePen(PenStyle penStyle, int width, uint color)
	{
		var hpen = NativeMethods.CreatePen(penStyle, width, color);
		if (hpen.IsInvalid)
			throw new Win32Exception();
		return hpen;
	}

	public static SafeGdiObjectOwned CreatePen(PenStyle penStyle, int width, uint color, params int[] segmentLengths)
	{
		var logBrush = new LOGBRUSH { Color = color };
		var segmentCount = (segmentLengths != null) ? segmentLengths.Length : 0;
		var hpen = NativeMethods.ExtCreatePen(penStyle, width, logBrush, segmentCount, segmentLengths ??= []);
		if (hpen.IsInvalid)
			throw new Win32Exception();
		return hpen;
	}

	public static SafeGdiObjectOwned CreateSolidBrush(uint color)
	{
		var hbr = NativeMethods.CreateSolidBrush(color);
		if (hbr.IsInvalid)
			throw new Win32Exception();
		return hbr;
	}

	public static void MoveTo(this SafeHdc hdc, int x, int y)
	{
		if (!NativeMethods.MoveToEx(hdc, x, y, nint.Zero))
			throw new Win32Exception();
	}

	public static void MoveTo(this SafeHdc hdc, int x, int y, out POINT previousPoint)
	{
		previousPoint = new();
		if (!NativeMethods.MoveToEx(hdc, x, y, out previousPoint))
			throw new Win32Exception();
	}

	public static void LineTo(this SafeHdc hdc, int xEnd, int yEnd)
	{
		if (!NativeMethods.LineTo(hdc, xEnd, yEnd))
			throw new Win32Exception();
	}

	public static void PolyPolyline(this SafeHdc hdc, POINT[] pt, int[] dwPolyPoints)
	{
		if (!NativeMethods.PolyPolyline(hdc, pt, dwPolyPoints, dwPolyPoints.Length))
			throw new Win32Exception();
	}

	public static void Rectangle(this SafeHdc hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect)
	{
		if (!NativeMethods.Rectangle(hdc, nLeftRect, nTopRect, nRightRect, nBottomRect))
			throw new Win32Exception();
	}

	public static void BitBlt(
			this SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
			SafeHdc hdcSrc, int xSrc, int ySrc, ROP3 dwRop)
	{
		if (!NativeMethods.BitBlt(hdcDest, xDest, yDest, cxDest, cyDest, hdcSrc, xSrc, ySrc, dwRop))
			throw new Win32Exception();
	}

	public static void StretchBlt(
			this SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
			SafeHdc hdcSrc, int xSrc, int ySrc, int cxSrc, int cySrc, ROP3 dwRop)
	{
		if (!NativeMethods.StretchBlt(hdcDest, xDest, yDest, cxDest, cyDest, hdcSrc, xSrc, ySrc, cxSrc, cySrc, dwRop))
			throw new Win32Exception();
	}

	public static IDisposable SetStretchBltMode(this SafeHdc hdc, StretchBltMode stretchMode)
	{
		var previous = NativeMethods.SetStretchBltMode(hdc, stretchMode);
		if ((int)previous == 0)
			throw new Win32Exception();
		return new DisposeScopeExit(() => NativeMethods.SetStretchBltMode(hdc, previous));
	}

	public static IDisposable SetROP2(this SafeHdc hdc, ROP2 mixMode)
	{
		var previous = NativeMethods.SetROP2(hdc, mixMode);
		if ((int)previous == 0)
			throw new Win32Exception();
		return new DisposeScopeExit(() => NativeMethods.SetROP2(hdc, previous));
	}

	public static IDisposable SetBkColor(this SafeHdc hdc, uint color)
	{
		var previous = NativeMethods.SetBkColor(hdc, color);
		if (previous == 0xFFFFFFFF)
			throw new Win32Exception();
		return new DisposeScopeExit(() => NativeMethods.SetBkColor(hdc, previous));
	}

	public static IDisposable SetBkMode(this SafeHdc hdc, BackgroundMode bkMode)
	{
		var previous = NativeMethods.SetBkMode(hdc, bkMode);
		if ((int)previous == 0)
			throw new Win32Exception();
		return new DisposeScopeExit(() => NativeMethods.SetBkMode(hdc, previous));
	}

	public static void GdiFlush()
	{
		if (!NativeMethods.GdiFlush())
			throw new Win32Exception();
	}

	public static IDisposable SelectObject(this SafeHdc hdc, SafeGdiObject obj)
	{
		var previous = NativeMethods.SelectObject(hdc, obj);
		if (previous.IsInvalid)
			throw new Win32Exception();
		return new DisposeScopeExit(() => { using (NativeMethods.SelectObject(hdc, previous)) { } });
	}

	[LibraryImport(ApiLib)]
	public static partial int GetPixel(this SafeHdc hdc, int nXPos, int nYPos);

	[LibraryImport(ApiLib, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static partial bool DeleteDC(this SafeHdc hdc);

	[LibraryImport(ApiLib, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static partial bool DeleteObject(this SafeGdiObject hObject);

	[LibraryImport(ApiLib, SetLastError = true)]
	public static partial SafeGdiObject GetStockObject(StockObject n);
	#endregion Methods

	#region Nested Types
	internal static partial class NativeMethods
	{
		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafePrivateHdc CreateCompatibleDC(SafeHdc hDC);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiObjectOwned CreateCompatibleBitmap(SafeHdc hdc, int width, int height);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiObjectOwned CreateDIBSection(SafeHdc hdc, BITMAPINFOHEADER pbmi,
				int iUsage, ref nint ppvBits, nint hSection, int dwOffset);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiObjectOwned CreateDIBSection(SafeHdc hdc, BITMAPINFOHEADER pbmi,
				int iUsage, ref nint ppvBits, SafeMemoryMappedFileHandle hSection, int dwOffset);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiObjectOwned CreateRectRgn(
			int x1,
			int y1,
			int x2,
			int y2);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiObjectOwned CreatePen(PenStyle penStyle, int width, uint color);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiObjectOwned CreateSolidBrush(uint color);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial int GetDeviceCaps(SafeHdc hdc, DeviceCapability nIndex);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool MoveToEx(SafeHdc hdc, int x, int y, nint lpPoint);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool MoveToEx(SafeHdc hdc, int x, int y, out POINT lpPoint);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool LineTo(SafeHdc hdc, int xEnd, int yEnd);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool PolyPolyline(SafeHdc hdc, POINT[] pt, int[] dwPolyPoints, int count);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool Rectangle(SafeHdc hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiObject SelectObject(SafeHdc hdc, SafeGdiObject obj);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial uint SetBkColor(SafeHdc hdc, uint color);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial BackgroundMode SetBkMode(SafeHdc hdc, BackgroundMode bkMode);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial uint SetDCPenColor(SafeHdc hdc, uint color);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeGdiObjectOwned ExtCreatePen(
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

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial StretchBltMode SetStretchBltMode(SafeHdc hdc, StretchBltMode stretchMode);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial ROP2 SetROP2(SafeHdc hdc, ROP2 mixMode);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool GdiFlush();
	}
	#endregion Nested Types
}