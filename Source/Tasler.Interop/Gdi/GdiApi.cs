using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Tasler.Interop.Gdi
{
	public static partial class GdiApi
	{
		#region Constants
		private const string ApiLib = "gdi32.dll";
		#endregion Constants

		#region Safe Methods
		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern IntPtr
		CreateDIBSection(
			HandleRef hdc,
			ref BITMAPINFOHEADER pbmi,
			int iUsage,
			ref IntPtr ppvBits,
			IntPtr hSection,
			int dwOffset);

		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern IntPtr
		CreateRectRgn(
			int x1,
			int y1,
			int x2,
			int y2);

		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern bool
		DeleteObject(
			HandleRef hObject);

		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int
		GetObject(
			HandleRef hObject,
			int nSize,
			[In, Out] DIBSECTION ds);

		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern IntPtr
		SelectObject(
			HandleRef hDC,
			HandleRef hObject);

		#endregion Safe Methods

		#region Unsafe Methods
		[SuppressUnmanagedCodeSecurity]
		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern IntPtr CreateCompatibleDC(HandleRef hDC);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern bool DeleteDC(HandleRef hDC);

		[SuppressUnmanagedCodeSecurity]
		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true)]
		public static extern int GetObject(IntPtr hBitmap, int nSize, out BITMAP bitmap);
		#endregion Unsafe Methods
	}
}
