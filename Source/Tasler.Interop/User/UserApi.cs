using System.ComponentModel;
using System.Runtime.InteropServices;
using Tasler.Extensions;
using Tasler.Interop.Gdi;

namespace Tasler.Interop.User;

public static partial class UserApi
{
	public static POINT GetMessagePosition()
	{
		var pos = NativeMethods.GetMessagePos();
		return new POINT
		{
			X = WinDef.GET_X_LPARAM(pos),
			Y = WinDef.GET_Y_LPARAM(pos),
		};
	}

	public static IReadOnlyList<SafeHwnd> EnumWindows()
	{
		var windowList = new List<SafeHwnd>();
		if (!NativeMethods.EnumWindows((h, l) => { windowList.Add( new SafeHwnd { Handle = h }); return true; }, nint.Zero))
			throw new Win32Exception();

		return windowList;
	}

	// TODO: Create a new delegate to better document the bool return value.
	public static bool EnumWindows(Func<SafeHwnd, bool> func)
	{
		var earlyBreak = false;
		EnumWindowsProc callback = (h, l) =>
		{
			var shouldContinue = func(new SafeHwnd { Handle= h });
			if (!shouldContinue)
				earlyBreak = true;
			return shouldContinue;
		};

		if (!NativeMethods.EnumWindows(callback, nint.Zero) && !earlyBreak)
			throw new Win32Exception();

		return !earlyBreak;
	}

	// TODO: Create a new delegate to better document the bool return value.
	public static bool EnumCurrentThreadWindows(Func<SafeHwnd, bool> func)
	{
		var currentNativeThreadId = Kernel.KernelApi.GetCurrentThreadId();
		return EnumThreadWindows(currentNativeThreadId, func);
	}

	// TODO: Create a new delegate to better document the bool return value.
	public static bool EnumThreadWindows(uint nativeThreadId, Func<SafeHwnd, bool> func)
	{
		var earlyBreak = false;
		EnumWindowsProc callback = (h, l) =>
		{
			var shouldContinue = func(new SafeHwnd { Handle= h });
			if (!shouldContinue)
				earlyBreak = true;
			return shouldContinue;
		};

		if (!NativeMethods.EnumThreadWindows(nativeThreadId, callback, nint.Zero) && !earlyBreak)
			throw new Win32Exception();

		return !earlyBreak;
	}

	public static string GetScanCodeKeyDisplayText(ushort scanCode)
	{
		return GetScanCodeKeyDisplayText(scanCode, false, false);
	}

	public static string GetScanCodeKeyDisplayText(ushort scanCode, bool extendedKey, bool doNotCare)
	{
		uint param = (uint)(scanCode << 16);
		param = param.SetOrClearFlags(extendedKey, (uint)KF.Extended);
		param = param.SetOrClearFlags(doNotCare, (uint)KF.DoNotCare);

		return StringHelpers.GetVariableLengthString((buffer, bufferLength)
			=> NativeMethods.GetKeyNameTextW(param, buffer, buffer.Length), 64);
	}

	public static string GetClipboardFormatName(uint format)
	{
		return StringHelpers.GetVariableLengthString((buffer, bufferLength)
			=> NativeMethods.GetClipboardFormatNameW(format, buffer, buffer.Length), 64);
	}

	public static bool EnumWindows(EnumWindowsProc enumFunc, nint param)
		=> NativeMethods.EnumWindows(enumFunc, param);

	public static bool EnumThreadWindows(uint dwThreadId, EnumWindowsProc enumFunc, nint param)
		=> NativeMethods.EnumThreadWindows(dwThreadId, enumFunc, param);

	public static nint SetCursor(SafeGdiCursor hcursor)
		=> NativeMethods.SetCursor(hcursor);

	public static bool ClipCursor(RECT? rect)
	{
		unsafe
		{
			RECT rectCopy;
			RECT* rectPtr = null;
			if (rect.HasValue)
			{
				rectCopy = rect.Value;
				rectPtr = &rectCopy;
			}

			return NativeMethods.ClipCursor(rectPtr);
		}
	}

	public static uint GetMessageTime() => NativeMethods.GetMessageTime();

	public static int GetSystemMetrics(SM nIndex) => NativeMethods.GetSystemMetrics(nIndex);

	private static nint CreateIconFromResourceEx(byte[] presbits, bool fIcon, uint dwVer, int cxDesired, int cyDesired, uint flags)
	{
		var result = NativeMethods.CreateIconFromResourceEx(presbits, (uint)presbits.Length, fIcon, dwVer, cxDesired, cyDesired, flags);
		return result != nint.Zero
			? result
			: throw new Win32Exception(Marshal.GetLastWin32Error());
	}
	public static SafeGdiIconOwned CreateIconFromResourceEx(byte[] presbits, uint dwVer, int cxDesired, int cyDesired, uint flags)
		=> new() { Handle = CreateIconFromResourceEx(presbits, true, dwVer, cxDesired, cyDesired, flags) };

	public static SafeGdiCursorOwned CreateCursorFromResourceEx(byte[] presbits, uint dwVer, int cxDesired, int cyDesired, uint flags)
		=> new() { Handle = CreateIconFromResourceEx(presbits, false, dwVer, cxDesired, cyDesired, flags) };

	public static SafeGdiIconOwned CreateIconFromBits(byte[] presbits)
		=> CreateIconFromResourceEx(presbits, 0x00030000, 0, 0, 0);

	public static SafeGdiCursorOwned CreateCursorFromBits(byte[] presbits)
		=>  CreateCursorFromResourceEx(presbits, 0x00030000, 0, 0, 0);

	public static void DestroyIcon(nint hIcon)
	{
		if (!NativeMethods.DestroyIcon(hIcon))
			throw new Win32Exception(Marshal.GetLastWin32Error());
	}

	public static void DestroyCursor(nint hCursor)
	{
		if (!NativeMethods.DestroyCursor(hCursor))
			throw new Win32Exception(Marshal.GetLastWin32Error());
	}

	internal static partial class NativeMethods
	{
		#region Constants
		private const string ApiLib = "user32.dll";
		#endregion Constants

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool AnimateWindow(SafeHwnd hwnd, uint milliseconds, AW commands);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool EnableWindow(SafeHwnd hwnd, [MarshalAs(UnmanagedType.Bool)] bool enable);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool GetClientRect(SafeHwnd hwnd, ref RECT rect);

		[LibraryImport(ApiLib)]
		public static partial RegionTypes GetUpdateRgn(SafeHwnd hwnd, SafeGdiRgn hrgn, [MarshalAs(UnmanagedType.Bool)] bool fErase);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool GetWindowRect(SafeHwnd hwnd, ref RECT rect);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool SetWindowPos(SafeHwnd hwnd, SafeHwnd hwndInsertAfter, int x, int y, int cx, int cy, SWP flags);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ShowWindow(SafeHwnd hwnd, SW nCmdShow);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool IsIconic(SafeHwnd hWnd);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ValidateRect(SafeHwnd hwnd, ref RECT rect);

		[LibraryImport(ApiLib, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
		public static partial int GetClipboardFormatNameW(uint format, [Out] char[] formatName, int cchMaxCount);

		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static partial SafeHwnd GetForegroundWindow();

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool SetForegroundWindow(SafeHwnd hwnd);

		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		internal unsafe static partial nint BeginPaint(SafeHwnd hwnd, void* paintStruct);

		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal unsafe static partial bool EndPaint(SafeHwnd hwnd, void* paintStruct);

		[LibraryImport(ApiLib, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
		public static partial int GetClassNameW(
			SafeHwnd hwnd, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] char[] text, int nMaxCount);

		[LibraryImport(ApiLib, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool GetClassInfoExW(SafeHandleZeroIsInvalid instance, string className, ref WNDCLASSEXW wndClass);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial SafeHwnd GetWindow(SafeHwnd hwnd, GW uCmd);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial uint GetWindowThreadProcessId(SafeHwnd hwnd, out uint processId);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial int GetWindowTextW(SafeHwnd hwnd, [Out] char[] text, int nMaxCount);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial int GetWindowTextLengthW(SafeHwnd hwnd);

		[LibraryImport(ApiLib, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
		public static partial nint PostMessageW(SafeHwnd hwnd, WM msg, nint wparam, nint param);

		[LibraryImport(ApiLib, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
		public static partial nint SendMessageW(SafeHwnd hwnd, WM msg, nint wparam, nint param);

		[LibraryImport(ApiLib, SetLastError = true)]
		internal static partial int MapWindowPoints(SafeHwnd hwndFrom, SafeHwnd hwndTo, ref RECT rect, int cPoints);

		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		internal static partial nint GetWindowLongPtrW(SafeHwnd hwnd, GWLP index);

		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		internal static partial nint SetWindowLongPtrW(SafeHwnd hwnd, GWLP index, nint newValue);

		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static partial SafeHwnd GetActiveWindow();

		[LibraryImport(ApiLib, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
		public static partial SafeHwnd SetActiveWindow(SafeHwnd hwnd);

		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static partial nint DefWindowProcW(SafeHwnd hwnd, int Msg, nint wParam, nint param);

		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static partial nint DefWindowProcW(SafeHwnd hwnd, WM Msg, nint wParam, nint param);

		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static partial nint CallWindowProcW(WndProcNative previousWndFunc, SafeHwnd hwnd, int Msg, nint wParam, nint param);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool AddClipboardFormatListener(SafeHwnd hwnd);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool EnumWindows(EnumWindowsProc enumFunc, nint param);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool EnumThreadWindows(uint dwThreadId, EnumWindowsProc enumFunc, nint param);

		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16)]
		public static partial nint SetCursor(SafeGdiCursor hcursor);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public unsafe static partial bool ClipCursor(RECT* rect);

		[LibraryImport(ApiLib)]
		public static partial uint GetMessagePos();

		[LibraryImport(ApiLib)]
		public static partial uint GetMessageTime();

		[LibraryImport(ApiLib)]
		public static partial int GetSystemMetrics(SM nIndex);

		[LibraryImport(ApiLib)]
		public static partial SafeHdc GetDC(SafeHwnd hwnd);

		[LibraryImport(ApiLib)]
		public static partial SafeHdc GetDCEx(SafeHwnd hwnd, SafeGdiRgn region, uint flags);

		[LibraryImport(ApiLib)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ReleaseDC(SafeHwnd hwnd, SafeHdc hdc);

		[LibraryImport(ApiLib)]
		public static partial int FillRect(SafeHdc hdc, ref RECT rect, SafeGdiBrush brush);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool GetWindowPlacement(SafeHwnd hwnd, ref WINDOWPLACEMENT windowPlacement);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool SetWindowPlacement(SafeHwnd hwnd, ref WINDOWPLACEMENT windowPlacement);

		[LibraryImport(ApiLib, SetLastError = true, StringMarshalling = StringMarshalling.Utf16)]
		public static partial int GetKeyNameTextW(uint keyParameter, [Out] char[] buffer, int cchSize);

		[LibraryImport(ApiLib, SetLastError = true)]
		public static partial nint CreateIconFromResourceEx(
			byte[] presbits, uint dwResSize, [MarshalAs(UnmanagedType.Bool)] bool fIcon,
			uint dwVer, int cxDesired, int cyDesired, uint Flags);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool DestroyIcon(nint hIcon);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool DestroyCursor(nint hCursor);

		[LibraryImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool GetIconInfo(nint hIcon, ref ICONINFO piconinfo);
	}
}
