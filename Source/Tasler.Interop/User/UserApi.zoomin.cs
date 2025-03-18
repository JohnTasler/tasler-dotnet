using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
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

	public static SafeHwnd[] EnumWindows()
	{
		var windows = new List<SafeHwnd>();
		if (!NativeMethods.EnumWindows((h, l) => { windows.Add(h); return true; }, nint.Zero))
			throw new Win32Exception();
		return windows.ToArray();
	}

	public static bool EnumWindows(Func<nint, bool> func)
	{
		var earlyBreak = false;
		NativeMethods.WNDENUMPROC callback = (h, l) =>
		{
			var shouldContinue = func(h);
			if (!shouldContinue)
				earlyBreak = true;
			return shouldContinue;
		};

		if (!NativeMethods.EnumWindows(callback, nint.Zero) && !earlyBreak)
			throw new Win32Exception();

		return !earlyBreak;
	}

	public static bool EnumCurrentThreadWindows(Func<nint, bool> func)
	{
		var currentNativeThreadId = Kernel.KernelApi.GetCurrentThreadId();
		return EnumThreadWindows(currentNativeThreadId, func);
	}

	public static bool EnumThreadWindows(int nativeThreadId, Func<nint, bool> func)
	{
		var earlyBreak = false;
		NativeMethods.WNDENUMPROC callback = (h, l) =>
		{
			var shouldContinue = func(h);
			if (!shouldContinue)
				earlyBreak = true;
			return shouldContinue;
		};

		if (!NativeMethods.EnumThreadWindows(nativeThreadId, callback, nint.Zero) && !earlyBreak)
			throw new Win32Exception();

		return !earlyBreak;
	}

	public static string GetScanCodeKeyDisplayText(short scanCode)
	{
		return GetScanCodeKeyDisplayText(scanCode, false, false);
	}

	public static string GetScanCodeKeyDisplayText(short scanCode, bool extendedKey, bool doNotCare)
	{
		var lParam = ((ushort)scanCode) << 16;
		lParam = lParam.SetOrClearBits(extendedKey, NativeMethods.ExtendedKeyFlag);
		lParam = lParam.SetOrClearBits(doNotCare, NativeMethods.DoNotCareFlag);

		var sb = new StringBuilder(256);
		var cch = NativeMethods.GetKeyNameText(lParam, sb, sb.Capacity);
		return sb.ToString();
	}

	public static void FillRect(SafeHdc hdc, SafeGdiBrush hbr, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect)
	{
		var rc = new RECT
		{
			Left = nLeftRect,
			Top = nTopRect,
			Right = nRightRect,
			Bottom = nBottomRect
		};

		if (!NativeMethods.FillRect(hdc, rc, hbr))
			throw new Win32Exception();
	}

	public static SafeWindowHdc GetDC(SafeHwnd hwnd)
	{
		var hdc = NativeMethods.GetDC(hwnd);
		if (hdc.IsInvalid)
			throw new Win32Exception();

		hdc.WindowHandle = hwnd;
		return hdc;
	}

	internal static partial class NativeMethods
	{
		#region Constants
		private const string ApiLib = "user32.dll";
		#endregion Constants

		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern nint SetCursor(SafeGdiCursor hcursor);

		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ClipCursor(RECT rect);

		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern uint GetMessagePos();

		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern uint GetMessageTime();

		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern uint GetSystemMetrics(SM nIndex);

		[DllImport(ApiLib, CharSet = CharSet.Unicode, SetLastError = true)]
		[LibraryImport(ApiLib, StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ReleaseDC(SafeHwnd hwnd, nint hDC);

		[DllImport(ApiLib, CharSet = CharSet.Auto)]
		public static extern nint SendMessage(SafeHwnd hwnd, WM msg, nint wParam, nint lParam);

		public static WINDOWPLACEMENT GetWindowPlacement(SafeHwnd hwnd)
		{
			WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
			GetWindowPlacement(hwnd, placement);
			return placement;
		}

		public static void GetWindowPlacement(SafeHwnd hwnd, WINDOWPLACEMENT placement)
		{
			if (!NativeMethods.GetWindowPlacement(hwnd, placement))
				throw new Win32Exception();
		}

		public static void SetWindowPlacement(SafeHwnd hwnd, WINDOWPLACEMENT placement)
		{
			if (!NativeMethods.SetWindowPlacement(hwnd, placement))
				throw new Win32Exception();
		}

		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern int GetWindowThreadProcessId(SafeHwnd hwnd, out int lpdwProcessId);

		public static int GetWindowThreadId(SafeHwnd hwnd)
		{
			return GetWindowThreadProcessId(hwnd, out _);
		}

		public static string GetWindowText(SafeHwnd hwnd)
		{
			var sb = new StringBuilder { Capacity = NativeMethods.GetWindowTextLength(hwnd) };
			NativeMethods.GetWindowText(hwnd, sb, sb.Capacity);
			return sb.ToString();
		}

		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern SafeWindowHdc GetDC(SafeHwnd hwnd);

		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool FillRect(SafeHdc hdc, RECT rc, SafeGdiObject hbr);

		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowPlacement(SafeHwnd hwnd, WINDOWPLACEMENT placement);

		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		public static extern bool SetWindowPlacement(SafeHwnd hwnd, WINDOWPLACEMENT placement);

		[DllImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool
		EnumWindows(
			WNDENUMPROC lpfn,
			nint lParam);

		[DllImport(ApiLib, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool
		EnumThreadWindows(
			int dwThreadId,
			WNDENUMPROC lpfn,
			nint lParam);

		public const int ExtendedKeyFlag = 1 << 24;
		public const int DoNotCareFlag = 1 << 25;

		[DllImport(ApiLib, SetLastError = true)]
		public static extern int
		GetKeyNameText(
			int lParam,
			StringBuilder lpString,
			int cchSize);

		[DllImport(ApiLib, CharSet = CharSet.Auto, EntryPoint = "GetWindowText")]
		private static extern int GetWindowTextExtern(
			SafeHwnd hwnd,
			StringBuilder lpString,
			int nMaxCount);

		[DllImport(ApiLib, CharSet = CharSet.Auto, EntryPoint = "GetWindowTextLength")]
		private static extern int GetWindowTextLengthExtern(
			SafeHwnd hwnd);

		public static int GetWindowText(SafeHwnd hwnd, StringBuilder lpString, int nMaxCount)
		{
			var length = GetWindowTextExtern(hwnd, lpString, nMaxCount);
			if (length == 0)
			{
				var error = Marshal.GetLastWin32Error();
				if (error != 0)
					throw new Win32Exception(error);
			}
			return length;
		}

		public static int GetWindowTextLength(SafeHwnd hwnd)
		{
			var length = GetWindowTextLengthExtern(hwnd);
			if (length == 0)
			{
				var error = Marshal.GetLastWin32Error();
				if (error != 0)
					throw new Win32Exception(error);
			}
			return length;
		}

		[return: MarshalAs(UnmanagedType.Bool)]
		public delegate bool
		WNDENUMPROC(
			SafeHwnd hwnd,
			nint lParam);
	}
}