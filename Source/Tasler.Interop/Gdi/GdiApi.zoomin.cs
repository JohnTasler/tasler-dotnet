using System;
using System.ComponentModel;
using System.IO.MemoryMappedFiles;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using Tasler.Interop.User;

namespace Tasler.Interop.Gdi
{
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
				if (double.IsNaN(dpiScaleX))
				{
					int logPixels;
					using (var hdcScreen = UserApi.GetDC(IntPtr.Zero))
						logPixels = Private.GetDeviceCaps(hdcScreen, DeviceCapability.LOGPIXELSX);
					var scale = 96.0 / logPixels;
					Interlocked.Exchange(ref dpiScaleX, scale);
				}

				return dpiScaleX;
			}
		}
		private static double dpiScaleX = double.NaN;

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
					using (var hdcScreen = UserApi.GetDC(IntPtr.Zero))
						logPixels = Private.GetDeviceCaps(hdcScreen, DeviceCapability.LOGPIXELSX);
					var scale = 96.0 / logPixels;
					Interlocked.Exchange(ref dpiScaleY, scale);
				}

				return dpiScaleY;
			}
		}
		private static double dpiScaleY = double.NaN;

		#endregion Properties

		#region Unsafe Methods

		public static SafePrivateHdc CreateCompatibleDC(SafeHdc hdcExisting)
		{
			var hdc = Private.CreateCompatibleDC(hdcExisting);
			if (hdc.IsInvalid)
				throw new Win32Exception();
			return hdc;
		}

		public static SafeGdiObjectOwned CreateCompatibleBitmap(SafeHdc hdc, int width, int height)
		{
			var hbm = Private.CreateCompatibleBitmap(hdc, width, height);
			if (hbm.IsInvalid)
				throw new Win32Exception();
			return hbm;
		}

		public static SafeGdiObjectOwned CreateDIBSection(SafeHdc hdc, BITMAPINFOHEADER pbmi, ref IntPtr ppvBits)
		{
			var hbm = Private.CreateDIBSection(hdc, pbmi, 0, ref ppvBits, IntPtr.Zero, 0);
			if (hbm.IsInvalid)
				throw new Win32Exception();
			return hbm;
		}

		public static SafeGdiObjectOwned CreateDIBSection(SafeHdc hdc, BITMAPINFOHEADER pbmi, MemoryMappedFile section, ref IntPtr ppvBits)
		{
			var hbm = Private.CreateDIBSection(hdc, pbmi, 0, ref ppvBits, section.SafeMemoryMappedFileHandle, 0);
			if (hbm.IsInvalid)
				throw new Win32Exception();
			return hbm;
		}

		public static SafeGdiObjectOwned CreateDIBSection(SafeHdc hdc, int width, int height, ushort bpp, ref IntPtr ppvBits)
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

		public static SafeGdiObjectOwned CreateDIBSection(SafeHdc hdc, int width, int height, ushort bpp, MemoryMappedFile section, ref IntPtr ppvBits)
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
			var hpen = Private.CreatePen(penStyle, width, color);
			if (hpen.IsInvalid)
				throw new Win32Exception();
			return hpen;
		}

		public static SafeGdiObjectOwned CreatePen(PenStyle penStyle, int width, uint color, params int[] segmentLengths)
		{
			var logBrush = new LOGBRUSH { Color = color };
			var segmentCount = (segmentLengths != null) ? segmentLengths.Length : 0;
			var hpen = Private.ExtCreatePen(penStyle, width, logBrush, segmentCount, segmentLengths);
			if (hpen.IsInvalid)
				throw new Win32Exception();
			return hpen;
		}

		public static SafeGdiObjectOwned CreateSolidBrush(uint color)
		{
			var hbr = Private.CreateSolidBrush(color);
			if (hbr.IsInvalid)
				throw new Win32Exception();
			return hbr;
		}

		public static void MoveTo(SafeHdc hdc, int x, int y)
		{
			if (!Private.MoveToEx(hdc, x, y, IntPtr.Zero))
				throw new Win32Exception();
		}

		public static void MoveTo(SafeHdc hdc, int x, int y, out POINT previousPoint)
		{
			if (!Private.MoveToEx(hdc, x, y, out previousPoint))
				throw new Win32Exception();
		}

		public static void LineTo(SafeHdc hdc, int xEnd, int yEnd)
		{
			if (!Private.LineTo(hdc, xEnd, yEnd))
				throw new Win32Exception();
		}

		public static void PolyPolyline(SafeHdc hdc, POINT[] pt, int[] dwPolyPoints)
		{
			if (!Private.PolyPolyline(hdc, pt, dwPolyPoints, dwPolyPoints.Length))
				throw new Win32Exception();
		}

		public static void Rectangle(SafeHdc hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect)
		{
			if (!Private.Rectangle(hdc, nLeftRect, nTopRect, nRightRect, nBottomRect))
				throw new Win32Exception();
		}

		public static void BitBlt(
			SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
			SafeHdc hdcSrc, int xSrc, int ySrc, ROP3 dwRop)
		{
			if (!Private.BitBlt(hdcDest, xDest, yDest, cxDest, cyDest, hdcSrc, xSrc, ySrc, dwRop))
				throw new Win32Exception();
		}

		public static void StretchBlt(
			SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
			SafeHdc hdcSrc, int xSrc, int ySrc, int cxSrc, int cySrc, ROP3 dwRop)
		{
			if (!Private.StretchBlt(hdcDest, xDest, yDest, cxDest, cyDest, hdcSrc, xSrc, ySrc, cxSrc, cySrc, dwRop))
				throw new Win32Exception();
		}

		public static IDisposable SetStretchBltMode(SafeHdc hdc, StretchBltMode stretchMode)
		{
			var previous = Private.SetStretchBltMode(hdc, stretchMode);
			if ((int)previous == 0)
				throw new Win32Exception();
			return new ScopeExitDisposable(() => Private.SetStretchBltMode(hdc, previous));
		}

		public static IDisposable SetROP2(SafeHdc hdc, ROP2 mixMode)
		{
			var previous = Private.SetROP2(hdc, mixMode);
			if ((int)previous == 0)
				throw new Win32Exception();
			return new ScopeExitDisposable(() => Private.SetROP2(hdc, previous));
		}

		public static IDisposable SetBkColor(SafeHdc hdc, uint color)
		{
			var previous = Private.SetBkColor(hdc, color);
			if (previous == 0xFFFFFFFF)
				throw new Win32Exception();
			return new ScopeExitDisposable(() => Private.SetBkColor(hdc, previous));
		}

		public static IDisposable SetBkMode(SafeHdc hdc, BackgroundMode bkMode)
		{
			var previous = Private.SetBkMode(hdc, bkMode);
			if ((int)previous == 0)
				throw new Win32Exception();
			return new ScopeExitDisposable(() => Private.SetBkMode(hdc, previous));
		}

		public static void GdiFlush()
		{
			if (!Private.GdiFlush())
				throw new Win32Exception();
		}

		public static IDisposable SelectObject(SafeHdc hdc, SafeGdiObject obj)
		{
			var previous = Private.SelectObject(hdc, obj);
			if (previous.IsInvalid)
				throw new Win32Exception();
			return new ScopeExitDisposable(() => { using (Private.SelectObject(hdc, previous)) {} });
		}

		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern int GetPixel(SafeHdc hdc, int nXPos, int nYPos);

		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern bool DeleteDC(IntPtr hDC);

		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern bool DeleteObject(IntPtr hObject);

		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern SafeGdiObject GetStockObject(StockObject n);
		#endregion Unsafe Methods

		#region Nested Types
		internal static class Private
		{
			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern SafePrivateHdc CreateCompatibleDC(SafeHdc hDC);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern SafeGdiObjectOwned CreateCompatibleBitmap(SafeHdc hdc, int width, int height);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern SafeGdiObjectOwned CreateDIBSection(SafeHdc hdc, BITMAPINFOHEADER pbmi,
				int iUsage, ref IntPtr ppvBits, IntPtr hSection, int dwOffset);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern SafeGdiObjectOwned CreateDIBSection(SafeHdc hdc, BITMAPINFOHEADER pbmi,
				int iUsage, ref IntPtr ppvBits, SafeMemoryMappedFileHandle hSection, int dwOffset);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern SafeGdiObjectOwned CreatePen(PenStyle penStyle, int width, uint color);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern SafeGdiObjectOwned CreateSolidBrush(uint color);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern int GetDeviceCaps(SafeHdc hdc, DeviceCapability nIndex);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			[return:MarshalAs(UnmanagedType.Bool)]
			public static extern bool MoveToEx(SafeHdc hdc, int x, int y, IntPtr lpPoint);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			[return:MarshalAs(UnmanagedType.Bool)]
			public static extern bool MoveToEx(SafeHdc hdc, int x, int y, out POINT lpPoint);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			[return:MarshalAs(UnmanagedType.Bool)]
			public static extern bool LineTo(SafeHdc hdc, int xEnd, int yEnd);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool PolyPolyline(SafeHdc hdc, POINT[] pt, int[] dwPolyPoints, int count);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool Rectangle(SafeHdc hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern SafeGdiObject SelectObject(SafeHdc hdc, SafeGdiObject obj);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern uint SetBkColor(SafeHdc hdc, uint color);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern BackgroundMode SetBkMode(SafeHdc hdc, BackgroundMode bkMode);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern uint SetDCPenColor(SafeHdc hdc, uint color);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern SafeGdiObjectOwned ExtCreatePen(
				PenStyle penStyle, int width, LOGBRUSH logBrush, int segmentCount,
				[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] int[] segments);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			[return:MarshalAs(UnmanagedType.Bool)]
			public static extern bool BitBlt(
				SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
				SafeHdc hdcSrc, int xSrc, int ySrc, ROP3 dwRop);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool StretchBlt(
				SafeHdc hdcDest, int xDest, int yDest, int cxDest, int cyDest,
				SafeHdc hdcSrc, int xSrc, int ySrc, int cxSrc, int cySrc, ROP3 dwRop);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern StretchBltMode SetStretchBltMode(SafeHdc hdc, StretchBltMode stretchMode);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern ROP2 SetROP2(SafeHdc hdc, ROP2 mixMode);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool GdiFlush();
		}
		#endregion Nested Types
	}
}
