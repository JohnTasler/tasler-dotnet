using System.ComponentModel;
using System.IO.MemoryMappedFiles;
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
					logPixels = GdiApi.NativeMethods.GetDeviceCaps(hdcScreen, DeviceCapability.LogicalPixelsX);
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
					logPixels = GdiApi.NativeMethods.GetDeviceCaps(hdcScreen, DeviceCapability.LogicalPixelsX);
				var scale = 96.0 / logPixels;
				Interlocked.Exchange(ref s_dpiScaleY, scale);
			}

			return s_dpiScaleY;
		}
	}
	private static double s_dpiScaleY = double.NaN;

	#endregion Properties

	#region Methods

	public static void DeleteObject(this SafeGdiObject gdiObject)
		=> GdiApi.NativeMethods.DeleteObject(gdiObject);

	public static SafePrivateHdc CreateCompatibleDC(this SafeHdc hdcExisting)
		=> GdiApi.NativeMethods.CreateCompatibleDC(hdcExisting);

	public static SafeGdiObjectOwned CreateCompatibleBitmap(this SafeHdc hdc, int width, int height)
		=> GdiApi.NativeMethods.CreateCompatibleBitmap(hdc, width, height);

	public static SafeGdiObjectOwned CreateDIBSection(this SafeHdc hdc, BITMAPINFOHEADER pbmi, out nint ppvBits)
		=> GdiApi.NativeMethods.CreateDIBSection(hdc, pbmi, 0, out ppvBits, nint.Zero, 0);

	public static SafeGdiObjectOwned CreateDIBSection(this SafeHdc hdc, BITMAPINFOHEADER pbmi, MemoryMappedFile section, out nint ppvBits)
		=> GdiApi.NativeMethods.CreateDIBSection(hdc, pbmi, 0, out ppvBits, section.SafeMemoryMappedFileHandle, 0);

	public static SafeGdiObjectOwned CreateDIBSection(this SafeHdc hdc, int width, int height, ushort bpp, nint ppvBits)
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

	public static SafeGdiObjectOwned CreateDIBSection(this SafeHdc hdc,
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

	public static void MoveTo(this SafeHdc hdc, int x, int y) => GdiApi.NativeMethods.MoveToEx(hdc, x, y, nint.Zero);

	public static void MoveTo(this SafeHdc hdc, int x, int y, out POINT previousPoint)
	{
		previousPoint = new();
		GdiApi.NativeMethods.MoveToEx(hdc, x, y, out previousPoint);
	}

	public static void LineTo(this SafeHdc hdc, int xEnd, int yEnd) => GdiApi.NativeMethods.LineTo(hdc, xEnd, yEnd);

	public static void PolyPolyline(this SafeHdc hdc, POINT[] pt, uint[] dwPolyPoints)
		=> GdiApi.NativeMethods.PolyPolyline(hdc, pt, dwPolyPoints, dwPolyPoints.Length);

	public static void Rectangle(this SafeHdc hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect)
		=> GdiApi.NativeMethods.Rectangle(hdc, nLeftRect, nTopRect, nRightRect, nBottomRect);

	public static void BitBlt(
			this SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
			SafeHdc hdcSrc, int xSrc, int ySrc, ROP3 dwRop)
		=> GdiApi.NativeMethods.BitBlt(hdcDest, xDest, yDest, cxDest, cyDest, hdcSrc, xSrc, ySrc, dwRop);

	public static void StretchBlt(
			this SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
			SafeHdc hdcSrc, int xSrc, int ySrc, int cxSrc, int cySrc, ROP3 dwRop)
		=> GdiApi.NativeMethods.StretchBlt(hdcDest, xDest, yDest, cxDest, cyDest, hdcSrc, xSrc, ySrc, cxSrc, cySrc, dwRop);

	public static IDisposable SetStretchBltMode(this SafeHdc hdc, StretchBltMode stretchMode)
	{
		var previous = GdiApi.NativeMethods.SetStretchBltMode(hdc, stretchMode);
		if ((int)previous == 0)
			throw new Win32Exception();
		return new DisposeScopeExit(() => GdiApi.NativeMethods.SetStretchBltMode(hdc, previous));
	}

	public static IDisposable SetROP2(this SafeHdc hdc, ROP2 mixMode)
	{
		var previous = GdiApi.NativeMethods.SetROP2(hdc, mixMode);
		if ((int)previous == 0)
			throw new Win32Exception();
		return new DisposeScopeExit(() => GdiApi.NativeMethods.SetROP2(hdc, previous));
	}

	public static IDisposable SetBkColor(this SafeHdc hdc, uint color)
	{
		var previous = GdiApi.NativeMethods.SetBkColor(hdc, color);
		if (previous == 0xFFFFFFFF)
			throw new Win32Exception();
		return new DisposeScopeExit(() => GdiApi.NativeMethods.SetBkColor(hdc, previous));
	}

	public static IDisposable SetBkMode(this SafeHdc hdc, BackgroundMode bkMode)
	{
		var previous = GdiApi.NativeMethods.SetBkMode(hdc, bkMode);
		if ((int)previous == 0)
			throw new Win32Exception();
		return new DisposeScopeExit(() => GdiApi.NativeMethods.SetBkMode(hdc, previous));
	}

	public static IDisposable SelectObject(this SafeHdc hdc, SafeGdiObject obj)
	{
		var previous = GdiApi.NativeMethods.SelectObject(hdc, obj);
		if (previous.IsInvalid)
			throw new Win32Exception();
		return new DisposeScopeExit(() => { using (GdiApi.NativeMethods.SelectObject(hdc, previous)) { } });
	}

	public static bool FillRect(this SafeHdc hdc, ref RECT rect, SafeGdiBrush brush)
	{
		return UserApi.NativeMethods.FillRect(hdc, ref rect, brush) != 0;
	}

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
	{
		return hdc.FillRect(ref rect, new SafeGdiBrush() { Handle = ((nint)color) + 1 });
	}

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

	#endregion Methods

}
