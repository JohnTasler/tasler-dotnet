using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;
using Tasler.Interop.User;

namespace Tasler.Interop.Gdi;

public static partial class GdiApi
{
	#region Properties

	/// <summary>
	/// Gets the horizontal scaling factor needed to match the DPI of the screen.
	/// </summary>
	public static double DpiScaleX
	{
		get
		{
			if (double.IsNaN(s_dpiScaleX))
			{
				int logPixels;
				using (var hdcScreen = UserApi.GetWindowClientDC(null, null, DCX.Default))
					logPixels = NativeMethods.GetDeviceCaps(hdcScreen, DeviceCapability.LogicalPixelsX);
				var scale = 96.0 / logPixels;
				Interlocked.Exchange(ref s_dpiScaleX, scale);
			}

			return s_dpiScaleX;
		}
	}
	private static double s_dpiScaleX = double.NaN;

	/// <summary>
	/// Gets the vertical scaling factor needed to match the DPI of the screen.
	/// </summary>
	public static double DpiScaleY
	{
		get
		{
			if (double.IsNaN(s_dpiScaleY))
			{
				int logPixels;
				using (var hdcScreen = UserApi.GetWindowClientDC(null, null, DCX.Default))
					logPixels = NativeMethods.GetDeviceCaps(hdcScreen, DeviceCapability.LogicalPixelsX);
				var scale = 96.0 / logPixels;
				Interlocked.Exchange(ref s_dpiScaleY, scale);
			}

			return s_dpiScaleY;
		}
	}
	private static double s_dpiScaleY = double.NaN;

	#endregion Properties

	#region Methods

	public static int GetPixel(this SafeHdc hdc, int nXPos, int nYPos)
		=> NativeMethods.GetPixel(hdc, nXPos, nYPos);

	public static void DeleteObject(this SafeGdiObject gdiObject)
		=> NativeMethods.DeleteObject(gdiObject);

	public static SafePrivateHdc CreateCompatibleDC(this SafeHdc hdcExisting)
		=> NativeMethods.CreateCompatibleDC(hdcExisting);

	public static SafeGdiBitmapOwned CreateCompatibleBitmap(this SafeHdc hdc, int width, int height)
		=> NativeMethods.CreateCompatibleBitmap(hdc, width, height);

	public static SafeGdiBitmapOwned CreateDIBSection(this SafeHdc hdc, BITMAPINFOHEADER pbmi, out nint ppvBits)
		=> NativeMethods.CreateDIBSection(hdc, pbmi, 0, out ppvBits, nint.Zero, 0);

	public static SafeGdiBitmapOwned CreateDIBSection(this SafeHdc hdc, BITMAPINFOHEADER pbmi, MemoryMappedFile section, out nint ppvBits)
		=> NativeMethods.CreateDIBSection(hdc, pbmi, 0, out ppvBits, section.SafeMemoryMappedFileHandle, 0);

	public static SafeGdiBitmapOwned CreateDIBSection(this SafeHdc hdc, int width, int height, ushort bpp, nint ppvBits)
	{
		BITMAPINFOHEADER bmi = new()
		{
			Planes = 1,
			BitCount = bpp,
			Width = Math.Max(1, width),
			Height = height < 0 ? Math.Min(height, -1) : Math.Max(1, height)
		};

		var hbm = hdc.CreateDIBSection(bmi, out ppvBits);
		return hbm;
	}

	public static SafeGdiBitmapOwned CreateDIBSection(this SafeHdc hdc,
		int width, int height, ushort bpp, MemoryMappedFile section, out nint ppvBits)
	{
		BITMAPINFOHEADER bmi = new()
		{
			Planes = 1,
			BitCount = bpp,
			Width = Math.Max(1, width),
			Height = height < 0 ? Math.Min(height, -1) : Math.Max(1, height)
		};

		var hbm = hdc.CreateDIBSection(bmi, section, out ppvBits);
		return hbm;
	}

	public static SafeGdiPenOwned CreatePen(this PenStyle penStyle, int width, uint color)
		=> NativeMethods.CreatePen(penStyle, width, color);

	public static SafeGdiPenOwned CreatePen(this PenStyle penStyle, int width, uint color, params int[] segmentLengths)
	{
		var logBrush = new LOGBRUSH { Color = color };
		var segmentCount = (segmentLengths != null) ? segmentLengths.Length : 0;
		var hpen = NativeMethods.ExtCreatePen(penStyle, width, logBrush, segmentCount, segmentLengths ??= []);
		return hpen;
	}

	public static void MoveTo(this SafeHdc hdc, int x, int y)
		=> NativeMethods.MoveToEx(hdc, x, y, nint.Zero);

	public static void MoveTo(this SafeHdc hdc, int x, int y, out POINT previousPoint)
		=> NativeMethods.MoveToEx(hdc, x, y, out previousPoint);

	public static void LineTo(this SafeHdc hdc, int xEnd, int yEnd)
		=> NativeMethods.LineTo(hdc, xEnd, yEnd);

	public static void PolyPolyline(this SafeHdc hdc, POINT[] pt, uint[] dwPolyPoints)
		=> NativeMethods.PolyPolyline(hdc, pt, dwPolyPoints, dwPolyPoints.Length);

	public static void Rectangle(this SafeHdc hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect)
		=> NativeMethods.Rectangle(hdc, nLeftRect, nTopRect, nRightRect, nBottomRect);

	public static void BitBlt(
			this SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
			SafeHdc hdcSrc, int xSrc, int ySrc, ROP3 dwRop)
		=> NativeMethods.BitBlt(hdcDest, xDest, yDest, cxDest, cyDest, hdcSrc, xSrc, ySrc, dwRop);

	public static void StretchBlt(
			this SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
			SafeHdc hdcSrc, int xSrc, int ySrc, int cxSrc, int cySrc, ROP3 dwRop)
		=> NativeMethods.StretchBlt(hdcDest, xDest, yDest, cxDest, cyDest, hdcSrc, xSrc, ySrc, cxSrc, cySrc, dwRop);

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

	public static IDisposable SelectObject(this SafeHdc hdc, SafeGdiObject obj)
	{
		var previous = NativeMethods.SelectObject(hdc, obj);
		if (previous.IsInvalid)
			throw new Win32Exception();
		return new DisposeScopeExit(() => NativeMethods.SelectObject(hdc, previous));
	}

	public static bool FillRect(this SafeHdc hdc, ref RECT rect, SafeGdiBrush brush)
		=> UserApi.NativeMethods.FillRect(hdc, ref rect, brush) != 0;

	public static bool FillRect(this SafeHdc hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, SafeGdiBrush brush)
	{
		var rect = new RECT
		{
			Left = nLeftRect,
			Top = nTopRect,
			Right = nRightRect,
			Bottom = nBottomRect
		};

		return hdc.FillRect(ref rect, brush);
	}

	public static bool FillRect(this SafeHdc hdc, ref RECT rect, COLOR color)
		=> hdc.FillRect(ref rect, new SafeGdiBrush() { Handle = ((nint)color) + 1 });

	public static bool FillRect(this SafeHdc hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, COLOR color)
	{
		var rect = new RECT
		{
			Left = nLeftRect,
			Top = nTopRect,
			Right = nRightRect,
			Bottom = nBottomRect
		};

		return hdc.FillRect(ref rect, color);
	}

	public static SafeGdiObject GetStockObject(this StockObject stockObject)
		=> NativeMethods.GetStockObject(stockObject);

	public static SafeGdiBrush GetStockBrush(this StockBrush stockBrush)
		=> NativeMethods.GetStockBrush(stockBrush);

	public static SafeGdiPen GetStockPen(this StockPen stockPen)
		=> NativeMethods.GetStockPen(stockPen);

	public static SafeGdiFont GetStockFont(this StockFont stockFont)
		=> NativeMethods.GetStockFont(stockFont);

	public static SafeGdiPalette GetStockPalette(this StockPalette stockPalette)
		=> NativeMethods.GetStockPalette(stockPalette);


	#endregion Methods
}
