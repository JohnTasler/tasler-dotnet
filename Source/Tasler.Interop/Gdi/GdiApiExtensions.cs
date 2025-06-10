using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using CommunityToolkit.Diagnostics;
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

	/// <summary>
		/// Retrieves the color value of the pixel at the specified coordinates in the given device context.
		/// </summary>
		/// <param name="nXPos">The x-coordinate of the pixel.</param>
		/// <param name="nYPos">The y-coordinate of the pixel.</param>
		/// <returns>The color value of the specified pixel as a 32-bit integer.</returns>
		public static int GetPixel(this SafeHdc hdc, int nXPos, int nYPos)
		=> NativeMethods.GetPixel(hdc, nXPos, nYPos);

	/// <summary>
		/// Deletes the specified GDI object and releases its associated resources.
		/// </summary>
		public static void DeleteObject(this SafeGdiObject gdiObject)
		=> NativeMethods.DeleteObject(gdiObject);

	/// <summary>
		/// Creates a memory device context compatible with the specified device context.
		/// </summary>
		/// <returns>A safe handle to the newly created compatible device context.</returns>
		public static SafePrivateHdc CreateCompatibleDC(this SafeHdc hdcExisting)
		=> NativeMethods.CreateCompatibleDC(hdcExisting);

	/// <summary>
		/// Creates a bitmap compatible with the specified device context and dimensions.
		/// </summary>
		/// <param name="width">The width of the bitmap in pixels.</param>
		/// <param name="height">The height of the bitmap in pixels.</param>
		/// <returns>A safe handle to the created compatible bitmap.</returns>
		public static SafeGdiBitmapOwned CreateCompatibleBitmap(this SafeHdc hdc, int width, int height)
		=> NativeMethods.CreateCompatibleBitmap(hdc, width, height);

	/// <summary>
		/// Creates a device-independent bitmap (DIB) section using the specified device context and bitmap information header.
		/// </summary>
		/// <param name="hdc">The device context to associate with the DIB section.</param>
		/// <param name="pbmi">The bitmap information header describing the DIB format.</param>
		/// <param name="ppvBits">When the method returns, contains a pointer to the bitmap's bit values.</param>
		/// <returns>A safe handle to the created DIB section.</returns>
		public static SafeGdiBitmapOwned CreateDIBSection(this SafeHdc hdc, BITMAPINFOHEADER pbmi, out nint ppvBits)
		=> NativeMethods.CreateDIBSection(hdc, pbmi, 0, out ppvBits, nint.Zero, 0);

	/// <summary>
		/// Creates a device-independent bitmap (DIB) section using the specified device context, bitmap information header, and memory-mapped file.
		/// </summary>
		/// <param name="hdc">The device context to associate with the DIB section.</param>
		/// <param name="pbmi">The bitmap information header describing the DIB format.</param>
		/// <param name="section">The memory-mapped file to back the DIB section.</param>
		/// <param name="ppvBits">When the method returns, contains a pointer to the bitmap's bit values.</param>
		/// <returns>A safe handle to the created DIB section.</returns>
		public static SafeGdiBitmapOwned CreateDIBSection(this SafeHdc hdc, BITMAPINFOHEADER pbmi, MemoryMappedFile section, out nint ppvBits)
		=> NativeMethods.CreateDIBSection(hdc, pbmi, 0, out ppvBits, section.SafeMemoryMappedFileHandle, 0);

	/// <summary>
	/// Creates a device-independent bitmap (DIB) section with the specified dimensions and bits per pixel.
	/// </summary>
	/// <param name="width">The width of the bitmap in pixels.</param>
	/// <param name="height">The height of the bitmap in pixels. Negative values create a top-down DIB.</param>
	/// <param name="bpp">The number of bits per pixel.</param>
	/// <param name="ppvBits">Receives a pointer to the bitmap's pixel data.</param>
	/// <returns>A safe handle to the created DIB section.</returns>
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

	/// <summary>
	/// Creates a device-independent bitmap (DIB) section with the specified dimensions and bit depth, optionally backed by a memory-mapped file.
	/// </summary>
	/// <param name="width">The width of the bitmap in pixels.</param>
	/// <param name="height">The height of the bitmap in pixels. Negative values create a top-down DIB.</param>
	/// <param name="bpp">The number of bits per pixel.</param>
	/// <param name="section">An optional memory-mapped file to back the bitmap storage.</param>
	/// <param name="ppvBits">Outputs a pointer to the bitmap's pixel data.</param>
	/// <returns>A safe handle to the created DIB section.</returns>
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

	/// <summary>
		/// Creates a GDI pen with the specified style, width, and color.
		/// </summary>
		/// <param name="penStyle">The style of the pen (e.g., solid, dashed).</param>
		/// <param name="width">The width of the pen in logical units.</param>
		/// <param name="color">The color of the pen as a 32-bit unsigned integer.</param>
		/// <returns>A safe handle to the created pen object.</returns>
		public static SafeGdiPenOwned CreatePen(this PenStyle penStyle, int width, uint color)
		=> NativeMethods.CreatePen(penStyle, width, color);

	/// <summary>
	/// Creates an extended GDI pen with the specified style, width, color, and optional custom dash pattern.
	/// </summary>
	/// <param name="penStyle">The style of the pen, including options for custom dash patterns.</param>
	/// <param name="width">The width of the pen in logical units.</param>
	/// <param name="color">The color of the pen.</param>
	/// <param name="segmentLengths">Optional array specifying the lengths of dashes and gaps for custom patterns.</param>
	/// <returns>A safe handle to the created pen.</returns>
	public static SafeGdiPenOwned CreatePen(this PenStyle penStyle, int width, uint color, params int[] segmentLengths)
	{
		var logBrush = new LOGBRUSH { Color = color };
		var segmentCount = (segmentLengths != null) ? segmentLengths.Length : 0;
		var hpen = NativeMethods.ExtCreatePen(penStyle, width, logBrush, segmentCount, segmentLengths ??= []);
		return hpen;
	}

	/// <summary>
		/// Sets the current drawing position in the device context to the specified coordinates.
		/// </summary>
		/// <param name="x">The new x-coordinate in logical units.</param>
		/// <param name="y">The new y-coordinate in logical units.</param>
		public static void MoveTo(this SafeHdc hdc, int x, int y)
		=> NativeMethods.MoveToEx(hdc, x, y, nint.Zero);

	/// <summary>
		/// Moves the current drawing position in the device context to the specified coordinates and outputs the previous position.
		/// </summary>
		/// <param name="x">The new x-coordinate.</param>
		/// <param name="y">The new y-coordinate.</param>
		/// <param name="previousPoint">Receives the previous drawing position.</param>
		public static void MoveTo(this SafeHdc hdc, int x, int y, out POINT previousPoint)
		=> NativeMethods.MoveToEx(hdc, x, y, out previousPoint);

	/// <summary>
		/// Draws a line from the current position in the device context to the specified endpoint.
		/// </summary>
		/// <param name="xEnd">The x-coordinate of the line's endpoint.</param>
		/// <param name="yEnd">The y-coordinate of the line's endpoint.</param>
		public static void LineTo(this SafeHdc hdc, int xEnd, int yEnd)
		=> NativeMethods.LineTo(hdc, xEnd, yEnd);

	/// <summary>
		/// Draws multiple polylines on the device context, using the specified points and segment counts.
		/// </summary>
		/// <param name="pt">An array of points defining the vertices of the polylines.</param>
		/// <param name="dwPolyPoints">An array specifying the number of points in each polyline.</param>
		public static void PolyPolyline(this SafeHdc hdc, POINT[] pt, uint[] dwPolyPoints)
		=> NativeMethods.PolyPolyline(hdc, pt, dwPolyPoints, dwPolyPoints.Length);

	/// <summary>
		/// Draws a rectangle on the specified device context using the given coordinates.
		/// </summary>
		/// <param name="nLeftRect">The x-coordinate of the upper-left corner.</param>
		/// <param name="nTopRect">The y-coordinate of the upper-left corner.</param>
		/// <param name="nRightRect">The x-coordinate of the lower-right corner.</param>
		/// <param name="nBottomRect">The y-coordinate of the lower-right corner.</param>
		public static void Rectangle(this SafeHdc hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect)
		=> NativeMethods.Rectangle(hdc, nLeftRect, nTopRect, nRightRect, nBottomRect);

	/// <summary>
		/// Performs a bit-block transfer of pixel data from a source device context to a destination device context using the specified raster operation.
		/// </summary>
		/// <param name="xDest">The x-coordinate of the upper-left corner of the destination rectangle.</param>
		/// <param name="yDest">The y-coordinate of the upper-left corner of the destination rectangle.</param>
		/// <param name="cxDest">The width of the destination rectangle.</param>
		/// <param name="cyDest">The height of the destination rectangle.</param>
		/// <param name="hdcSrc">The source device context.</param>
		/// <param name="xSrc">The x-coordinate of the upper-left corner of the source rectangle.</param>
		/// <param name="ySrc">The y-coordinate of the upper-left corner of the source rectangle.</param>
		/// <param name="dwRop">The raster operation code to use for the transfer.</param>
		public static void BitBlt(
			this SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
			SafeHdc hdcSrc, int xSrc, int ySrc, ROP3 dwRop)
		=> NativeMethods.BitBlt(hdcDest, xDest, yDest, cxDest, cyDest, hdcSrc, xSrc, ySrc, dwRop);

	/// <summary>
		/// Performs a bit-block transfer of color data from a source device context to a destination device context, stretching or compressing the image to fit the specified destination rectangle.
		/// </summary>
		/// <param name="hdcDest">The destination device context.</param>
		/// <param name="xDest">The x-coordinate of the upper-left corner of the destination rectangle.</param>
		/// <param name="yDest">The y-coordinate of the upper-left corner of the destination rectangle.</param>
		/// <param name="cxDest">The width of the destination rectangle.</param>
		/// <param name="cyDest">The height of the destination rectangle.</param>
		/// <param name="hdcSrc">The source device context.</param>
		/// <param name="xSrc">The x-coordinate of the upper-left corner of the source rectangle.</param>
		/// <param name="ySrc">The y-coordinate of the upper-left corner of the source rectangle.</param>
		/// <param name="cxSrc">The width of the source rectangle.</param>
		/// <param name="cySrc">The height of the source rectangle.</param>
		/// <param name="dwRop">The raster operation code specifying how source and destination colors are combined.</param>
		public static void StretchBlt(
			this SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
			SafeHdc hdcSrc, int xSrc, int ySrc, int cxSrc, int cySrc, ROP3 dwRop)
		=> NativeMethods.StretchBlt(hdcDest, xDest, yDest, cxDest, cyDest, hdcSrc, xSrc, ySrc, cxSrc, cySrc, dwRop);

	/// <summary>
	/// Sets the stretch mode for bit-block transfers in the specified device context and returns an <see cref="IDisposable"/> that restores the previous mode when disposed.
	/// </summary>
	/// <param name="hdc">The device context handle.</param>
	/// <param name="stretchMode">The stretch mode to set.</param>
	/// <returns>An <see cref="IDisposable"/> that restores the previous stretch mode on disposal.</returns>
	/// <exception cref="Win32Exception">Thrown if retrieving the previous stretch mode fails.</exception>
	public static IDisposable SetStretchBltMode(this SafeHdc hdc, StretchBltMode stretchMode)
	{
		var previous = NativeMethods.SetStretchBltMode(hdc, stretchMode);
		if ((int)previous == 0)
			throw new Win32Exception();
		return new DisposeScopeExit(() => NativeMethods.SetStretchBltMode(hdc, previous));
	}

	/// <summary>
	/// Sets the binary raster operation mode for the specified device context and returns an <see cref="IDisposable"/> that restores the previous mode when disposed.
	/// </summary>
	/// <param name="hdc">The device context handle.</param>
	/// <param name="mixMode">The raster operation mode to set.</param>
	/// <returns>An <see cref="IDisposable"/> that restores the previous raster operation mode on disposal.</returns>
	/// <exception cref="Win32Exception">Thrown if setting the raster operation mode fails.</exception>
	public static IDisposable SetROP2(this SafeHdc hdc, ROP2 mixMode)
	{
		var previous = NativeMethods.SetROP2(hdc, mixMode);
		if ((int)previous == 0)
			throw new Win32Exception();
		return new DisposeScopeExit(() => NativeMethods.SetROP2(hdc, previous));
	}

	/// <summary>
	/// Sets the background color for the specified device context and returns an <see cref="IDisposable"/> that restores the previous color when disposed.
	/// </summary>
	/// <param name="hdc">The device context handle.</param>
	/// <param name="color">The new background color as a COLORREF value.</param>
	/// <returns>An <see cref="IDisposable"/> that restores the previous background color upon disposal.</returns>
	/// <exception cref="Win32Exception">Thrown if retrieving the previous background color fails.</exception>
	public static IDisposable SetBkColor(this SafeHdc hdc, uint color)
	{
		var previous = NativeMethods.SetBkColor(hdc, color);
		if (previous == 0xFFFFFFFF)
			throw new Win32Exception();
		return new DisposeScopeExit(() => NativeMethods.SetBkColor(hdc, previous));
	}

	/// <summary>
	/// Sets the background mode for the specified device context and returns an <see cref="IDisposable"/> that restores the previous mode when disposed.
	/// </summary>
	/// <param name="bkMode">The background mode to set (transparent or opaque).</param>
	/// <returns>An <see cref="IDisposable"/> that restores the previous background mode upon disposal.</returns>
	/// <exception cref="Win32Exception">Thrown if setting the background mode fails.</exception>
	public static IDisposable SetBkMode(this SafeHdc hdc, BackgroundMode bkMode)
	{
		var previous = NativeMethods.SetBkMode(hdc, bkMode);
		if ((int)previous == 0)
			throw new Win32Exception();
		return new DisposeScopeExit(() => NativeMethods.SetBkMode(hdc, previous));
	}

	/// <summary>
	/// Selects a GDI object into the specified device context and returns an <see cref="IDisposable"/> that restores the previous object when disposed.
	/// </summary>
	/// <param name="hdc">The device context to modify.</param>
	/// <param name="obj">The GDI object to select.</param>
	/// <returns>An <see cref="IDisposable"/> that restores the previously selected object upon disposal.</returns>
	/// <exception cref="Win32Exception">Thrown if selecting the object fails.</exception>
	public static IDisposable SelectObject(this SafeHdc hdc, SafeGdiObject obj)
	{
		var previous = NativeMethods.SelectObject(hdc, obj);
		if (previous.IsInvalid)
			throw new Win32Exception();
		return new DisposeScopeExit(() => NativeMethods.SelectObject(hdc, previous));
	}

	/// <summary>
		/// Fills the specified rectangle in the device context with the given brush.
		/// </summary>
		/// <param name="rect">The rectangle to fill.</param>
		/// <param name="brush">The brush used to fill the rectangle.</param>
		/// <returns><c>true</c> if the rectangle was filled successfully; otherwise, <c>false</c>.</returns>
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

	/// <summary>
	/// Fills the specified rectangle in the device context with the given color.
	/// </summary>
	/// <param name="nLeftRect">The x-coordinate of the upper-left corner of the rectangle.</param>
	/// <param name="nTopRect">The y-coordinate of the upper-left corner of the rectangle.</param>
	/// <param name="nRightRect">The x-coordinate of the lower-right corner of the rectangle.</param>
	/// <param name="nBottomRect">The y-coordinate of the lower-right corner of the rectangle.</param>
	/// <param name="color">The color used to fill the rectangle.</param>
	/// <returns>True if the rectangle was filled successfully; otherwise, false.</returns>
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

	/// <summary>
		/// Retrieves a handle to a stock GDI object of the specified type.
		/// </summary>
		/// <param name="stockObject">The type of stock object to retrieve.</param>
		/// <returns>A safe handle to the requested stock GDI object.</returns>
		public static SafeGdiObject GetStockObject(this StockObject stockObject)
		=> NativeMethods.GetStockObject(stockObject);

	/// <summary>
		/// Retrieves a stock GDI brush corresponding to the specified stock brush type.
		/// </summary>
		/// <param name="stockBrush">The type of stock brush to retrieve.</param>
		/// <returns>A safe handle to the requested stock GDI brush.</returns>
		public static SafeGdiBrush GetStockBrush(this StockBrush stockBrush)
		=> NativeMethods.GetStockBrush(stockBrush);

	/// <summary>
		/// Retrieves a stock pen object corresponding to the specified stock pen type.
		/// </summary>
		/// <param name="stockPen">The type of stock pen to retrieve.</param>
		/// <returns>A safe handle to the requested stock pen.</returns>
		public static SafeGdiPen GetStockPen(this StockPen stockPen)
		=> NativeMethods.GetStockPen(stockPen);

	/// <summary>
		/// Retrieves a stock GDI font corresponding to the specified stock font type.
		/// </summary>
		/// <param name="stockFont">The type of stock font to retrieve.</param>
		/// <returns>A safe handle to the requested stock font.</returns>
		public static SafeGdiFont GetStockFont(this StockFont stockFont)
		=> NativeMethods.GetStockFont(stockFont);

	/// <summary>
		/// Retrieves a handle to a stock GDI palette object corresponding to the specified stock palette type.
		/// </summary>
		/// <param name="stockPalette">The type of stock palette to retrieve.</param>
		/// <returns>A safe handle to the requested stock palette.</returns>
		public static SafeGdiPalette GetStockPalette(this StockPalette stockPalette)
		=> NativeMethods.GetStockPalette(stockPalette);

	/// <summary>
	/// Retrieves detailed information about an icon or cursor handle.
	/// </summary>
	/// <param name="hIconOrCursor">A handle to the icon or cursor.</param>
	/// <returns>An <see cref="ICONINFO"/> structure containing information about the icon or cursor.</returns>
	/// <exception cref="Win32Exception">Thrown if the native call to retrieve icon information fails.</exception>
	private static ICONINFO GetIconInfo(nint hIconOrCursor)
	{
		Guard.IsNotDefault(hIconOrCursor);

		var iconInfo = new ICONINFO();
		if (!UserApi.NativeMethods.GetIconInfo(hIconOrCursor, ref iconInfo))
			throw new Win32Exception();

		return iconInfo;
	}

	/// <summary>
		/// Retrieves detailed information about the specified icon handle.
		/// </summary>
		/// <param name="hIcon">A safe handle to the icon.</param>
		/// <returns>An <see cref="ICONINFO"/> structure containing information about the icon.</returns>
		/// <exception cref="System.ComponentModel.Win32Exception">Thrown if retrieving icon information fails.</exception>
		public static ICONINFO GetIconInfo(this SafeGdiIcon hIcon)
		=> GetIconInfo(hIcon.DangerousGetHandle());

	/// <summary>
		/// Retrieves information about the specified cursor.
		/// </summary>
		/// <param name="hCursor">A safe handle to the cursor.</param>
		/// <returns>An <see cref="ICONINFO"/> structure containing details about the cursor.</returns>
		public static ICONINFO GetCursorInfo(this SafeGdiCursor hCursor)
		=> GetIconInfo(hCursor.DangerousGetHandle());

	/// <summary>
	/// Retrieves information about a bitmap represented by the specified safe handle.
	/// </summary>
	/// <param name="hBitmap">A safe handle to the bitmap.</param>
	/// <returns>A <see cref="BITMAP"/> structure containing details about the bitmap.</returns>
	/// <exception cref="Win32Exception">Thrown if the bitmap information cannot be retrieved.</exception>
	public static BITMAP GetBitmapInfo(this SafeGdiBitmap hBitmap)
	{
		Guard.IsNotNull(hBitmap);
		Guard.IsNotDefault(hBitmap.Handle);

		var bitmapInfo = new BITMAP();
		unsafe
		{
			var sizeofBitmap = sizeof(BITMAP);
			if (0 == NativeMethods.GetObjectW(hBitmap.Handle, sizeofBitmap, &bitmapInfo))
				throw new Win32Exception();
		}
		return bitmapInfo;
	}

	/// <summary>
	/// Retrieves the logical pen information for the specified GDI pen handle.
	/// </summary>
	/// <param name="hPen">A safe handle to the GDI pen.</param>
	/// <returns>The <see cref="LOGPEN"/> structure containing pen attributes.</returns>
	/// <exception cref="Win32Exception">Thrown if the pen information cannot be retrieved.</exception>
	public static LOGPEN GetPenInfo(this SafeGdiPen hPen)
	{
		Guard.IsNotNull(hPen);
		Guard.IsNotDefault(hPen.Handle);

		var logPen = new LOGPEN();
		unsafe
		{
			var sizeofLogPen = sizeof(LOGPEN);
			if (0 == NativeMethods.GetObjectW(hPen.Handle, sizeofLogPen, &logPen))
				throw new Win32Exception();
		}
		return logPen;
	}

	#endregion Methods
}
