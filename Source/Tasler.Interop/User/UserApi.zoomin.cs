namespace Tasler.Interop.User
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime;
	using System.Runtime.ConstrainedExecution;
	using System.Runtime.InteropServices;
	using System.Security;
	using System.Text;
	using Tasler.Interop.Gdi;

	public static partial class UserApi
	{
		#region Constants
		private const string ApiLib = "user32.dll";
		#endregion Constants

		#region Safe Methods

		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern IntPtr SetCursor(IntPtr hcursor);

		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern bool ClipCursor(RECT rect);

		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern int GetMessagePos();

		public static POINT GetMessagePosAsPOINT()
		{
			var pos = GetMessagePos();
			return new POINT
			{
				X = WinDef.GET_X_LPARAM(pos),
				Y = WinDef.GET_Y_LPARAM(pos),
			};
		}

		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern int GetMessageTime();

		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern int GetSystemMetrics(SM nIndex);

		public static IntPtr[] EnumWindows()
		{
			var windows = new List<IntPtr>();
			if (!Private.EnumWindows((h, l) => { windows.Add(h); return true; }, IntPtr.Zero))
				throw new Win32Exception();
			return windows.ToArray();
		}

		public static bool EnumWindows(Func<IntPtr, bool> func)
		{
			var earlyBreak = false;
			Private.WNDENUMPROC callback = (h, l) =>
			{
				var shouldContinue = func(h);
				if (!shouldContinue)
					earlyBreak = true;
				return shouldContinue;
			};

			if (!Private.EnumWindows(callback, IntPtr.Zero) && !earlyBreak)
				throw new Win32Exception();

			return !earlyBreak;
		}

		public static bool EnumCurrentThreadWindows(Func<IntPtr, bool> func)
		{
			var currentNativeThreadId = Kernel.KernelApi.GetCurrentThreadId();
			return EnumThreadWindows(currentNativeThreadId, func);
		}

		public static bool EnumThreadWindows(int nativeThreadId, Func<IntPtr, bool> func)
		{
			var earlyBreak = false;
			Private.WNDENUMPROC callback = (h, l) =>
			{
				var shouldContinue = func(h);
				if (!shouldContinue)
					earlyBreak = true;
				return shouldContinue;
			};

			if (!Private.EnumThreadWindows(nativeThreadId, callback, IntPtr.Zero) && !earlyBreak)
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
			lParam = lParam.SetOrClearBits(extendedKey, Private.ExtendedKeyFlag);
			lParam = lParam.SetOrClearBits(doNotCare, Private.DoNotCareFlag);

			var sb = new StringBuilder(256);
			var cch = Private.GetKeyNameText(lParam, sb, sb.Capacity);
			return sb.ToString();
		}

		#endregion Safe Methods

		#region Unsafe Methods

		public static void FillRect(SafeHdc hdc, SafeGdiObject hbr, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect)
		{
			var rc = new RECT
			{
				Left = nLeftRect,
				Top = nTopRect,
				Right = nRightRect,
				Bottom = nBottomRect
			};

			if (!Private.FillRect(hdc, rc, hbr))
				throw new Win32Exception();
		}

		public static SafeWindowHdc GetDC(IntPtr hwnd)
		{
			var hdc = Private.GetDC(hwnd);
			if (hdc.IsInvalid)
				throw new Win32Exception();

			hdc.WindowHandle = hwnd;
			return hdc;
		}

		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ReleaseDC(IntPtr hwnd, IntPtr hDC);

		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport(ApiLib, CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);

		public static WINDOWPLACEMENT GetWindowPlacement(IntPtr hwnd)
		{
			WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
			GetWindowPlacement(hwnd, placement);
			return placement;
		}

		public static void GetWindowPlacement(IntPtr hwnd, WINDOWPLACEMENT placement)
		{
			if (!Private.GetWindowPlacement(hwnd, placement))
				throw new Win32Exception();
		}

		public static void SetWindowPlacement(IntPtr hwnd, WINDOWPLACEMENT placement)
		{
			if (!Private.SetWindowPlacement(hwnd, placement))
				throw new Win32Exception();
		}

		[SecurityCritical]
		[SuppressUnmanagedCodeSecurity]
		[DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
		public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

		public static int GetWindowThreadId(IntPtr hWnd)
		{
			int lpdwProcessId;
			return GetWindowThreadProcessId(hWnd, out lpdwProcessId);
		}

		[SecurityCritical]
		public static string GetWindowText(IntPtr hWnd)
		{
			var sb = new StringBuilder { Capacity = Private.GetWindowTextLength(hWnd) };
			Private.GetWindowText(hWnd, sb, sb.Capacity);
			return sb.ToString();
		}

		#endregion Unsafe Methods

		#region Nested Types
		internal static partial class Private
		{
			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern SafeWindowHdc GetDC(IntPtr hwnd);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool FillRect(SafeHdc hdc, RECT rc, SafeGdiObject hbr);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool GetWindowPlacement(IntPtr hwnd, WINDOWPLACEMENT placement);

			[SecurityCritical]
			[SuppressUnmanagedCodeSecurity]
			[DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
			public static extern bool SetWindowPlacement(IntPtr hWnd, WINDOWPLACEMENT placement);

			[DllImport(ApiLib, SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool
			EnumWindows(
				WNDENUMPROC lpfn,
				IntPtr lParam);

			[DllImport(ApiLib, SetLastError = true)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool
			EnumThreadWindows(
				int dwThreadId,
				WNDENUMPROC lpfn,
				IntPtr lParam);

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
				IntPtr hWnd,
				StringBuilder lpString,
				int nMaxCount);

			[DllImport(ApiLib, CharSet = CharSet.Auto, EntryPoint = "GetWindowTextLength")]
			private static extern int GetWindowTextLengthExtern(
				IntPtr hWnd);

			[SecurityCritical]
			public static int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount)
			{
				var length = GetWindowTextExtern(hWnd, lpString, nMaxCount);
				if (length == 0)
				{
					var error = Marshal.GetLastWin32Error();
					if (error != 0)
						throw new Win32Exception(error);
				}
				return length;
			}

			[SecurityCritical]
			public static int GetWindowTextLength(IntPtr hWnd)
			{
				var length = GetWindowTextLengthExtern(hWnd);
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
				IntPtr hwnd,
				IntPtr lParam);

		}
		#endregion Nested Types
	}
}
