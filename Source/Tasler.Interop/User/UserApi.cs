using System.Buffers;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Tasler.Interop.Gdi;

namespace Tasler.Interop.User;

public static partial class UserApi
{
	public static string GetClipboardFormatName(uint format)
	{
		var previousCch = 0;
		var cch = 1;
		var bufferLength = 16L;
		char[] buffer = [];

		do
		{
			using var bufferScope = new DisposeScopeExit(
				() => ArrayPool<char>.Shared.Return(buffer));

			buffer = ArrayPool<char>.Shared.Rent(unchecked((int)bufferLength));
			cch = NativeMethods.GetClipboardFormatName(format, buffer, unchecked((int)bufferLength));
			var lastError = Marshal.GetLastPInvokeError();
			if (cch == 0)
			{
				if (lastError != 0 && lastError != WinError.InsufficientBuffer)
					throw new Win32Exception(lastError);
			}

			if ((bufferLength - 1) > cch || cch == previousCch)
			{
				return new string(buffer, 0, unchecked(cch));
			}
			previousCch = cch;

			// Double the buffer length and do a sanity range check
			bufferLength <<= 1;
			if ((bufferLength & 0x0040_0000) != 0)
			{
				Marshal.SetLastPInvokeError(WinError.InsufficientBuffer);
				throw new OutOfMemoryException { HResult = Marshal.GetHRForLastWin32Error() };
			}

		} while (true);
	}

	internal static partial class NativeMethods
	{
		[DllImport(ApiLib)]
		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool AnimateWindow(SafeHwnd hwnd, uint milliseconds, AW commands);

		[DllImport(ApiLib)]
		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool EnableWindow(SafeHwnd hwnd, [MarshalAs(UnmanagedType.Bool)] bool enable);

		[DllImport(ApiLib)]
		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool GetClientRect(SafeHwnd hwnd, ref RECT rect);

		[DllImport(ApiLib)]
		[LibraryImport(ApiLib)]
		public static extern int GetUpdateRgn(SafeHwnd hwnd, SafeGdiRgn hrgn, [MarshalAs(UnmanagedType.Bool)] bool fErase);

		[DllImport(ApiLib)]
		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowRect(SafeHwnd hwnd, [In, Out] ref RECT rect);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool SetWindowPos(SafeHwnd hwnd, SafeHwnd hwndInsertAfter, int x, int y, int cx, int cy, SWP flags);

		[DllImport(ApiLib)]
		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ShowWindow(SafeHwnd hwnd, SW nCmdShow);

		[DllImport(ApiLib)]
		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsIconic(SafeHwnd hWnd);

		[DllImport(ApiLib)]
		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ValidateRect(SafeHwnd hwnd, RECT rect);

		[DllImport(ApiLib, EntryPoint = "GetClipboardFormatNameW", CharSet = CharSet.Unicode, SetLastError = true)]
		[LibraryImport(ApiLib, EntryPoint = "GetClipboardFormatNameW", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
		public static extern int GetClipboardFormatName(uint format, [Out] char[] formatName, int cchMaxCount);

		[DllImport(ApiLib, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static extern SafeHwnd GetForegroundWindow();

		[DllImport(ApiLib)]
		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetForegroundWindow(SafeHwnd hwnd);

		[DllImport(ApiLib, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static extern SafeHdc BeginPaint(SafeHwnd hwnd, [In, Out] ref PAINTSTRUCT lpPaint);

		[DllImport(ApiLib, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EndPaint(SafeHwnd hwnd, ref PAINTSTRUCT lpPaint);

		[DllImport(ApiLib, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UpdateLayeredWindow(SafeHwnd hwnd, nint hdcDst,
			nint pptDst, ref SIZE psize, nint hdcSrc, ref POINT pptSrc, uint crKey,
			ref BLENDFUNCTION pblend, uint dwFlags);

		[DllImport(ApiLib, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static extern nint GetWindow(SafeHwnd hwnd, GW uCmd);

		[DllImport(ApiLib, CharSet = CharSet.Unicode)]
		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static extern nint PostMessage(SafeHwnd hwnd, WM msg, nint wparam, nint lparam);

		[DllImport(ApiLib, CharSet = CharSet.Unicode)]
		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static extern partial nint SendMessage(SafeHwnd hwnd, WM msg, nint wparam, nint lparam);

		[DllImport(ApiLib, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static extern int MapWindowPoints(SafeHwnd hwndFrom, SafeHwnd hwndTo, [In, Out] ref RECT rect, int cPoints);

		[DllImport(ApiLib, CharSet = CharSet.Unicode, EntryPoint = "SetWindowLongPtrW")]
		[LibraryImport(ApiLib, EntryPoint = "SetWindowLongPtrW", StringMarshalling = StringMarshalling.Utf16)]
		private static extern nint SetWindowLongPtr(SafeHwnd hwnd, GWLP index, nint newValue);

		[DllImport(ApiLib, CharSet = CharSet.Unicode, ExactSpelling = true)]
		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static extern nint GetActiveWindow();

		[DllImport(ApiLib, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
		public static extern nint SetActiveWindow(SafeHwnd hwnd);

		[DllImport(ApiLib, EntryPoint = "DefWindowProcW", CharSet = CharSet.Unicode)]
		[LibraryImport(ApiLib, EntryPoint = "DefWindowProcW", StringMarshalling = StringMarshalling.Utf16)]
		public static extern nint DefWindowProc(SafeHwnd hwnd, int Msg, nint wParam, nint lParam);

		[DllImport(ApiLib, EntryPoint = "DefWindowProcW", CharSet = CharSet.Unicode)]
		[LibraryImport(ApiLib, EntryPoint = "DefWindowProcW", StringMarshalling = StringMarshalling.Utf16)]
		public static extern nint DefWindowProc(SafeHwnd hwnd, WM Msg, nint wParam, nint lParam);

		[DllImport(ApiLib, EntryPoint = "CallWindowProcW", CharSet = CharSet.Unicode)]
		[LibraryImport(ApiLib, EntryPoint = "CallWindowProcW", StringMarshalling = StringMarshalling.Utf16)]
		public static extern nint CallWindowProc(nint lpPrevWndFunc, SafeHwnd hwnd, int Msg, nint wParam, nint lParam);

		[DllImport(ApiLib, EntryPoint = "CallWindowProcW", CharSet = CharSet.Unicode)]
		[LibraryImport(ApiLib, EntryPoint = "CallWindowProcW", StringMarshalling = StringMarshalling.Utf16)]
		public static extern nint CallWindowProc(nint lpPrevWndFunc, SafeHwnd hwnd, WM Msg, nint wParam, nint lParam);

		[DllImport(ApiLib, SetLastError = true)]
		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool AddClipboardFormatListener(SafeHwnd hwnd);
	}
}

#region Delegates
public delegate nint WndProc(SafeHwnd hwnd, int message, nint wParam, nint lParam);
#endregion Delegates
