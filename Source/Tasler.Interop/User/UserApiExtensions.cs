using System.Buffers;
using Tasler.Interop.Gdi;

namespace Tasler.Interop.User;

public static partial class UserApi
{
	public static SafeHdc GetWindowDC(this SafeHwnd? hwnd, SafeGdiRgn? hrgn, DCX flags)
	{
		uint combinedFlags = (uint)flags | 1;
		var hdc = NativeMethods.GetDCEx(hwnd ?? new SafeHwnd { Handle = nint.Zero }, hrgn ?? new SafeGdiRgn { Handle = nint.Zero }, combinedFlags);
		return hdc;
	}

	public static SafeHdc GetWindowClientDC(this SafeHwnd? hwnd, SafeGdiRgn? hrgn, DCX flags)
	{
		var hdc = NativeMethods.GetDCEx(hwnd ?? new SafeHwnd { Handle = nint.Zero }, hrgn ?? new SafeGdiRgn { Handle = nint.Zero }, (uint)flags);

		if (hwnd is not null)
		{
			// If the window class owns the DC, do not release it when finished with it
			var wndClass = hwnd.GetWindowsClassInfo();
			if ((wndClass.Style & (CS.ClassDC| CS.OwnDC | CS.ParentDC)) != 0)
			{
				return hdc;
			}

			// This window handle will release the DC when it goes out of Dispose scope.
			return new SafeWindowHdc(hwnd) { Handle = hdc.Handle };
		}

		// TODO: Maybe throw some sort of exception here
		return hdc;
	}

	public static WINDOWPLACEMENT GetWindowPlacement(this SafeHwnd hwnd)
	{
		WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
		hwnd.GetWindowPlacement(ref placement);
		return placement;
	}

	public static SafeHdc GetDC(this SafeHwnd hwnd)
		=> NativeMethods.GetDC(hwnd);

	public static void GetWindowPlacement(this SafeHwnd hwnd, ref WINDOWPLACEMENT placement)
		=> NativeMethods.GetWindowPlacement(hwnd, ref placement);

	public static void SetWindowPlacement(this SafeHwnd hwnd, ref WINDOWPLACEMENT placement)
		=> NativeMethods.SetWindowPlacement(hwnd, ref placement);

	public static string GetWindowText(this SafeHwnd hwnd)
	{
		int length = hwnd.GetWindowTextLength();
		if (length == 0)
			return string.Empty;

		char[]? buffer = null;
		using (var bufferScope = new DisposeScopeExit(() => ArrayPool<char>.Shared.Return(buffer!)))
		{
			buffer = ArrayPool<char>.Shared.Rent(length + 1);
			NativeMethods.GetWindowTextW(hwnd, buffer, length);
			return new string(buffer);
		}
	}

	public static int GetWindowTextLength(this SafeHwnd hwnd) => NativeMethods.GetWindowTextLengthW(hwnd);

	public static string GetWindowClassName(this SafeHwnd hwnd)
		=> StringHelpers.GetVariableLengthString((buffer, length)
			=> NativeMethods.GetClassNameW(hwnd, buffer, length));

	public static WNDCLASSEX GetWindowsClassInfo(this SafeHwnd hwnd, Kernel.SafeInstanceHandle? instance = null)
	{
		string windowClassName = hwnd.GetWindowClassName();
		return GetWindowClassInfo(windowClassName, instance);
	}

	public static WNDCLASSEX GetWindowClassInfo(string windowClassName, Kernel.SafeInstanceHandle? instance = null)
	{
		ValidateArgument.IsNotNullOrWhiteSpace(windowClassName, nameof(windowClassName));
		instance ??= new();

		WNDCLASSEXW wndClassW = new();
		bool succeeded = NativeMethods.GetClassInfoExW(instance, windowClassName, ref wndClassW);

		WNDCLASSEX wndClass = new(wndClassW);
		return wndClass;
	}

	public static bool AnimateWindow(this SafeHwnd hwnd, uint milliseconds, AW commands)
		=> NativeMethods.AnimateWindow(hwnd, milliseconds, commands);

	public static bool EnableWindow(this SafeHwnd hwnd, bool enable)
		=> NativeMethods.EnableWindow(hwnd, enable);

	public static bool GetClientRect(this SafeHwnd hwnd, ref RECT rect)
		=> NativeMethods.GetClientRect(hwnd, ref rect);

	public static RegionTypes GetUpdateRgn(this SafeHwnd hwnd, SafeGdiRgn hrgn, bool fErase)
		=> NativeMethods.GetUpdateRgn(hwnd, hrgn, fErase);

	public static bool GetWindowRect(this SafeHwnd hwnd, ref RECT rect)
		=> NativeMethods.GetWindowRect(hwnd, ref rect);

	public static bool SetWindowPos(this SafeHwnd hwnd, SafeHwnd hwndInsertAfter, int x, int y, int cx, int cy, SWP flags)
		=> NativeMethods.SetWindowPos(hwnd, hwndInsertAfter, x, y, cx, cy, flags);

	public static bool ShowWindow(this SafeHwnd hwnd, SW nCmdShow)
		=> NativeMethods.ShowWindow(hwnd, nCmdShow);

	public static bool IsIconic(this SafeHwnd hwnd)
		=> NativeMethods.IsIconic(hwnd);

	public static bool ValidateRect(this SafeHwnd hwnd, ref RECT rect)
		=> NativeMethods.ValidateRect(hwnd, ref rect);

	public static SafeHwnd GetForegroundWindow()
		=> NativeMethods.GetForegroundWindow();

	public static bool SetForegroundWindow(this SafeHwnd hwnd)
		=> NativeMethods.SetForegroundWindow(hwnd);

	public static SafePaintHdc BeginPaint(this SafeHwnd hwnd, out PAINTSTRUCT paintStruct)
	{
		unsafe
		{
			#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
			fixed (PAINTSTRUCT* paintStructPtr = &paintStruct)
			{
				var hdc = NativeMethods.BeginPaint(hwnd, paintStructPtr);
				return new SafePaintHdc(paintStruct, hwnd) { Handle = hdc };
			}
			#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
		}
	}

	public static SafeHwnd GetWindow(this SafeHwnd hwnd, GW uCmd) => NativeMethods.GetWindow(hwnd, uCmd);

	public static nint PostMessage(this SafeHwnd hwnd, WM msg, nint wparam, nint lparam)
		=> NativeMethods.PostMessageW(hwnd, msg, wparam, lparam);

	public static nint SendMessage(this SafeHwnd hwnd, WM msg, nint wparam, nint lparam)
		=> NativeMethods.SendMessageW(hwnd, msg, wparam, lparam);

	internal static int MapWindowPoints(this SafeHwnd hwndFrom, SafeHwnd hwndTo, ref RECT rect, int cPoints)
		=> NativeMethods.MapWindowPoints(hwndFrom, hwndTo, ref rect, cPoints);

	internal static nint GetWindowLongPtr(this SafeHwnd hwnd, GWLP index)
		=> NativeMethods.GetWindowLongPtrW(hwnd, index);

	internal static nint SetWindowLongPtr(this SafeHwnd hwnd, GWLP index, nint newValue)
		=> NativeMethods.SetWindowLongPtrW(hwnd, index, newValue);

	public static WS GetWindowStyle(this SafeHwnd hwnd) => (WS)hwnd.GetWindowLongPtr(GWLP.Style);

	public static bool ModifyStyle(SafeHwnd hwnd, WS remove, WS add) => ModifyStyle(hwnd, remove, add, false);

	public static bool ModifyStyle(SafeHwnd hwnd, WS remove, WS add, bool updateFrame)
	{
		WS dwStyle = GetWindowStyle(hwnd);
		WS dwNewStyle = (dwStyle & ~remove) | add;
		if (dwStyle == dwNewStyle)
			return false;

		UserApi.SetWindowLongPtr(hwnd, GWLP.Style, (nint)dwNewStyle);
		if (updateFrame)
		{
			hwnd.SetWindowPos(new SafeHwnd(), 0, 0, 0, 0,
				SWP.NoSize | SWP.NoMove | SWP.NoZOrder | SWP.NoActivate | SWP.DrawFrame | SWP.FrameChanged);
		}

		return true;
	}

	public static WS_EX GetWindowStyleEx(this SafeHwnd hwnd)
		=> (WS_EX)UserApi.NativeMethods.GetWindowLongPtrW(hwnd, GWLP.ExStyle).ToInt32();

	public static bool ModifyStyleEx(this SafeHwnd hwnd, WS_EX remove, WS_EX add)
		=> ModifyStyleEx(hwnd, remove, add, false);

	public static bool ModifyStyleEx(this SafeHwnd hwnd, WS_EX remove, WS_EX add, bool updateFrame)
	{
		WS_EX dwStyle = hwnd.GetWindowStyleEx();
		WS_EX dwNewStyle = (dwStyle & ~remove) | add;
		if (dwStyle == dwNewStyle)
			return false;

		hwnd.SetWindowLongPtr(GWLP.ExStyle, (nint)dwNewStyle);
		if (updateFrame)
		{
			hwnd.SetWindowPos(new SafeHwnd(), 0, 0, 0, 0,
				SWP.NoSize | SWP.NoMove | SWP.NoZOrder | SWP.NoActivate | SWP.DrawFrame | SWP.FrameChanged);
		}

		return true;
	}

	public static SafeHwnd GetActiveWindow() => NativeMethods.GetActiveWindow();

	public static SafeHwnd SetActiveWindow(this SafeHwnd hwnd) => NativeMethods.SetActiveWindow(hwnd);

	public static nint DefWindowProc(this SafeHwnd hwnd, int Msg, nint wParam, nint lParam)
		=> NativeMethods.DefWindowProcW(hwnd, Msg, wParam, lParam);

	public static nint DefWindowProc(this SafeHwnd hwnd, WM Msg, nint wParam, nint lParam)
		=> NativeMethods.DefWindowProcW(hwnd, Msg, wParam, lParam);

	public static nint CallWindowProc(this SafeHwnd hwnd, WndProcNative previousWndFunc, int Msg, nint wParam, nint lParam)
		=> NativeMethods.CallWindowProcW(previousWndFunc, hwnd, Msg, wParam, lParam);

	public static bool AddClipboardFormatListener(this SafeHwnd hwnd)
		=> NativeMethods.AddClipboardFormatListener(hwnd);
}
