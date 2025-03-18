using System.Runtime.InteropServices;

namespace Tasler.Interop.User
{
	public static class SafeHwndExtensions
	{
		public static WS GetWindowStyle(this SafeHwnd hwnd)
		{
			WS dwStyle = (WS)UserApi.NativeMethods.GetWindowLongPtr(hwnd, GWLP.Style).ToInt64();
			return dwStyle;
		}

		public static bool ModifyStyle(SafeHwnd hwnd, WS remove, WS add)
		{
			return ModifyStyle(hwnd, remove, add, false);
		}

		public static bool ModifyStyle(SafeHwnd hwnd, WS remove, WS add, bool updateFrame)
		{
			WS dwStyle = GetWindowStyle(hwnd);
			WS dwNewStyle = (dwStyle & ~remove) | add;
			if (dwStyle == dwNewStyle)
				return false;

			SetWindowLongPtr(hwnd, GWLP.Style, (nint)dwNewStyle);
			if (updateFrame)
			{
				UserApi.SetWindowPos(hwnd, new HandleRef(), 0, 0, 0, 0,
					SWP.NoSize | SWP.NoMove | SWP.NoZOrder | SWP.NoActivate | SWP.DrawFrame | SWP.FrameChanged);
			}

			return true;
		}

		public static WS_EX GetWindowStyleEx(SafeHwnd hwnd)
		{
			WS_EX dwStyle = (WS_EX)UserApi.GetWindowLongPtr(hwnd, GWLP.ExStyle).ToInt32();
			return dwStyle;
		}

		public static bool ModifyStyleEx(SafeHwnd hwnd, WS_EX remove, WS_EX add)
		{
			return ModifyStyleEx(hwnd, remove, add, false);
		}

		public static bool ModifyStyleEx(SafeHwnd hwnd, WS_EX remove, WS_EX add, bool updateFrame)
		{
			WS_EX dwStyle = GetWindowStyleEx(hwnd);
			WS_EX dwNewStyle = (dwStyle & ~remove) | add;
			if (dwStyle == dwNewStyle)
				return false;

			UserApi.SetWindowLongPtr(hwnd, GWLP.ExStyle, (nint)dwNewStyle);
			if (updateFrame)
			{
				UserApi.SetWindowPos(hwnd, new HandleRef(), 0, 0, 0, 0,
					SWP.NoSize | SWP.NoMove | SWP.NoZOrder | SWP.NoActivate | SWP.DrawFrame | SWP.FrameChanged);
			}

			return true;
		}

	}
}
