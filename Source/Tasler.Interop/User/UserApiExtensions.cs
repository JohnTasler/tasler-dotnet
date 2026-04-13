using System.Buffers;
using System.ComponentModel;
using Tasler.Extensions;
using Tasler.Interop.Extensions;
using Tasler.Interop.Gdi;
using Tasler.Interop.Kernel;

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
		NativeMethods.EnumWindows((h, l) =>
		{
			windowList.Add(new SafeHwnd { Handle = h });
			return true;
		}, nint.Zero).ReturnOrThrow();
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
		var currentNativeThreadId = KernelApi.GetCurrentThreadId();
		return EnumThreadWindows(currentNativeThreadId, func);
	}

	// TODO: Create a new delegate to better document the bool return value.
	public static bool EnumThreadWindows(uint nativeThreadId, Func<SafeHwnd, bool> func)
	{
		var earlyBreak = false;
		EnumWindowsProc callback = (h, l) =>
		{
			var shouldContinue = func(new SafeHwnd { Handle = h });
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

	/// <summary>
	/// Returns the display text for a keyboard scan code, with options for extended key and "do not care" flags.
	/// </summary>
	/// <param name="scanCode">The keyboard scan code.</param>
	/// <param name="extendedKey">Indicates if the key is an extended key.</param>
	/// <param name="doNotCare">Indicates if the "do not care" flag should be set.</param>
	/// <returns>The display text associated with the specified scan code and flags.</returns>
	public static string GetScanCodeKeyDisplayText(ushort scanCode, bool extendedKey, bool doNotCare)
	{
		uint param = (uint)(scanCode << 16);
		param = param.SetOrClearFlags(extendedKey, (uint)KF.Extended);
		param = param.SetOrClearFlags(doNotCare, (uint)KF.DoNotCare);

		return StringHelpers.GetVariableLengthString((buffer, bufferLength)
			=> NativeMethods.GetKeyNameTextW(param, buffer, buffer.Length).ReturnOrThrow(), 64);
	}

	public static string GetClipboardFormatName(uint format)
	{
		return StringHelpers.GetVariableLengthString((buffer, bufferLength)
			=> NativeMethods.GetClipboardFormatNameW(format, buffer, buffer.Length).ReturnOrThrow(), 64);
	}

	public static bool EnumWindows(EnumWindowsProc enumFunc, nint param)
		=> NativeMethods.EnumWindows(enumFunc, param).ReturnOrThrow();

	public static bool EnumThreadWindows(uint dwThreadId, EnumWindowsProc enumFunc, nint param)
		=> NativeMethods.EnumThreadWindows(dwThreadId, enumFunc, param).ReturnOrThrow();

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

			return NativeMethods.ClipCursor(rectPtr).ReturnOrThrow();
		}
	}

	public static uint GetMessageTime() => NativeMethods.GetMessageTime();

	/// <summary>
	/// Retrieves the value of a specified system metric or configuration setting.
	/// </summary>
	/// <param name="nIndex">The system metric or configuration setting to retrieve.</param>
	/// <returns>The value of the requested system metric.</returns>
	public static int GetSystemMetrics(SM nIndex) => NativeMethods.GetSystemMetrics(nIndex);

	/// <summary>
	/// Creates an icon or cursor from resource bits using the specified parameters.
	/// </summary>
	/// <param name="presbits">The resource bits representing the icon or cursor image.</param>
	/// <param name="fIcon">True to create an icon; false to create a cursor.</param>
	/// <param name="dwVer">The version number of the icon or cursor format.</param>
	/// <param name="cxDesired">The desired width of the icon or cursor.</param>
	/// <param name="cyDesired">The desired height of the icon or cursor.</param>
	/// <param name="flags">Flags specifying creation options.</param>
	/// <returns>A handle to the created icon or cursor.</returns>
	/// <exception cref="System.ComponentModel.Win32Exception">Thrown if the native creation fails.</exception>
	private static nint CreateIconFromResourceEx(byte[] presbits, bool fIcon, uint dwVer, int cxDesired, int cyDesired, uint flags)
		=> NativeMethods.CreateIconFromResourceEx(presbits, (uint)presbits.Length, fIcon, dwVer, cxDesired, cyDesired, flags).ReturnOrThrow();

	/// <summary>
	/// Creates an icon from resource bits using the specified version, size, and flags.
	/// </summary>
	/// <param name="presbits">The resource bits representing the icon image.</param>
	/// <param name="dwVer">The version number of the icon resource format.</param>
	/// <param name="cxDesired">The desired width of the icon in pixels.</param>
	/// <param name="cyDesired">The desired height of the icon in pixels.</param>
	/// <param name="flags">Flags that control icon creation behavior.</param>
	/// <returns>A <see cref="SafeGdiIconOwned"/> representing the created icon.</returns>
	public static SafeGdiIconOwned CreateIconFromResourceEx(byte[] presbits, uint dwVer, int cxDesired, int cyDesired, uint flags)
		=> new() { Handle = CreateIconFromResourceEx(presbits, true, dwVer, cxDesired, cyDesired, flags) };

	/// <summary>
	/// Creates a cursor from resource bits using the specified version, size, and flags.
	/// </summary>
	/// <param name="presbits">The resource bits representing the cursor image.</param>
	/// <param name="dwVer">The version number of the resource format.</param>
	/// <param name="cxDesired">The desired width of the cursor.</param>
	/// <param name="cyDesired">The desired height of the cursor.</param>
	/// <param name="flags">Flags that control cursor creation.</param>
	/// <returns>A <see cref="SafeGdiCursorOwned"/> representing the created cursor.</returns>
	public static SafeGdiCursorOwned CreateCursorFromResourceEx(byte[] presbits, uint dwVer, int cxDesired, int cyDesired, uint flags)
		=> new() { Handle = CreateIconFromResourceEx(presbits, false, dwVer, cxDesired, cyDesired, flags) };

	/// <summary>
	/// Creates an icon from the specified resource bits using default version and size parameters.
	/// </summary>
	/// <param name="presbits">The byte array containing the icon resource data.</param>
	/// <returns>A safe handle to the created icon.</returns>
	public static SafeGdiIconOwned CreateIconFromBits(byte[] presbits)
		=> CreateIconFromResourceEx(presbits, 0x00030000, 0, 0, 0);

	/// <summary>
	/// Creates a cursor from the specified resource bits using default version and size parameters.
	/// </summary>
	/// <param name="presbits">The byte array containing the cursor resource data.</param>
	/// <returns>A safe handle to the created cursor.</returns>
	public static SafeGdiCursorOwned CreateCursorFromBits(byte[] presbits)
		=> CreateCursorFromResourceEx(presbits, 0x00030000, 0, 0, 0);

	/// <summary>
	/// Releases the resources associated with the specified icon handle.
	/// </summary>
	/// <param name="hIcon">A handle to the icon to be destroyed.</param>
	/// <exception cref="Win32Exception">Thrown if the icon cannot be destroyed.</exception>
	public static void DestroyIcon(nint hIcon) => NativeMethods.DestroyIcon(hIcon).ReturnOrThrow();

	/// <summary>
	/// Releases the resources associated with a native cursor handle.
	/// </summary>
	/// <param name="hCursor">A handle to the cursor to be destroyed.</param>
	/// <exception cref="Win32Exception">Thrown if the cursor destruction fails.</exception>
	public static void DestroyCursor(nint hCursor) => NativeMethods.DestroyCursor(hCursor).ReturnOrThrow();

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
			if ((wndClass.Style & (CS.ClassDC | CS.OwnDC | CS.ParentDC)) != 0)
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
		=> NativeMethods.GetWindowPlacement(hwnd, ref placement).ReturnOrThrow();

	public static void SetWindowPlacement(this SafeHwnd hwnd, ref WINDOWPLACEMENT placement)
		=> NativeMethods.SetWindowPlacement(hwnd, ref placement).ReturnOrThrow();

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
			=> NativeMethods.GetClassNameW(hwnd, buffer, length).ReturnOrThrow());

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
		bool succeeded = NativeMethods.GetClassInfoExW(instance, windowClassName, ref wndClassW).ReturnOrThrow();

		WNDCLASSEX wndClass = new(wndClassW);
		return wndClass;
	}

	public static bool AnimateWindow(this SafeHwnd hwnd, uint milliseconds, AW commands)
		=> NativeMethods.AnimateWindow(hwnd, milliseconds, commands);

	public static bool EnableWindow(this SafeHwnd hwnd, bool enable)
		=> NativeMethods.EnableWindow(hwnd, enable);

	public static bool GetClientRect(this SafeHwnd hwnd, ref RECT rect)
		=> NativeMethods.GetClientRect(hwnd, ref rect).ReturnOrThrow();

	public static RegionTypes GetUpdateRgn(this SafeHwnd hwnd, SafeGdiRgn hrgn, bool fErase)
		=> NativeMethods.GetUpdateRgn(hwnd, hrgn, fErase);

	public static bool GetWindowRect(this SafeHwnd hwnd, ref RECT rect)
		=> NativeMethods.GetWindowRect(hwnd, ref rect).ReturnOrThrow();

	public static bool SetWindowPos(this SafeHwnd hwnd, SafeHwnd hwndInsertAfter, int x, int y, int cx, int cy, SWP flags)
		=> NativeMethods.SetWindowPos(hwnd, hwndInsertAfter, x, y, cx, cy, flags).ReturnOrThrow();

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

	public static SafeHwnd GetWindow(this SafeHwnd hwnd, GW uCmd)
		=> NativeMethods.GetWindow(hwnd, uCmd).ReturnOrThrow();


	/// <summary>
	/// Retrieves the identifier of the thread that created the specified window and the identifier
	/// of the process that created the window.
	/// </summary>
	/// <param name="hwnd">A handle to the window.</param>
	/// <param name="processId">The process identifier.</param>
	/// <returns>If the function succeeds, the return value is the identifier of the thread that
	/// created the window. If the window handle is invalid, the return value is zero. </returns>
	/// <seealso cref="GetWindowThreadId"/>
	public static uint GetWindowThreadProcessId(this SafeHwnd hwnd, out uint processId)
		=> NativeMethods.GetWindowThreadProcessId(hwnd, out processId).ReturnOrThrow();

	public static uint GetWindowThreadId(this SafeHwnd hwnd)
		=> NativeMethods.GetWindowThreadProcessId(hwnd, out _).ReturnOrThrow();

	public static nint PostMessage(this SafeHwnd hwnd, WM msg, nint wparam, nint lparam)
		=> NativeMethods.PostMessageW(hwnd, msg, wparam, lparam).ReturnOrThrow();

	public static nint SendMessage(this SafeHwnd hwnd, WM msg, nint wparam, nint lparam)
		=> NativeMethods.SendMessageW(hwnd, msg, wparam, lparam).ReturnOrThrow();

	internal static int MapWindowPoints(this SafeHwnd hwndFrom, SafeHwnd hwndTo, ref RECT rect, int cPoints)
		=> NativeMethods.MapWindowPoints(hwndFrom, hwndTo, ref rect, cPoints).ReturnOrThrow();

	internal static nint GetWindowLongPtr(this SafeHwnd hwnd, GWLP index)
		=> NativeMethods.GetWindowLongPtrW(hwnd, index);

	internal static nint SetWindowLongPtr(this SafeHwnd hwnd, GWLP index, nint newValue)
		=> NativeMethods.SetWindowLongPtrW(hwnd, index, newValue);

	public static WS GetWindowStyle(this SafeHwnd hwnd) => (WS)hwnd.GetWindowLongPtr(GWLP.Style);

	public static bool ModifyStyle(this SafeHwnd hwnd, WS remove, WS add) => ModifyStyle(hwnd, remove, add, false);

	public static bool ModifyStyle(this SafeHwnd hwnd, WS remove, WS add, bool updateFrame)
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

	public static SafeHwnd SetActiveWindow(this SafeHwnd hwnd)
		=> NativeMethods.SetActiveWindow(hwnd).ReturnOrThrow();

	public static nint DefWindowProc(this SafeHwnd hwnd, int Msg, nint wParam, nint lParam)
		=> NativeMethods.DefWindowProcW(hwnd, Msg, wParam, lParam);

	public static nint DefWindowProc(this SafeHwnd hwnd, WM Msg, nint wParam, nint lParam)
		=> NativeMethods.DefWindowProcW(hwnd, Msg, wParam, lParam);

	public static nint CallWindowProc(this SafeHwnd hwnd, WndProcNative previousWndFunc, int Msg, nint wParam, nint lParam)
		=> NativeMethods.CallWindowProcW(previousWndFunc, hwnd, Msg, wParam, lParam);

	public static bool AddClipboardFormatListener(this SafeHwnd hwnd)
		=> NativeMethods.AddClipboardFormatListener(hwnd).ReturnOrThrow();

	public static SafeGdiIcon LoadIcon(this SafeInstanceHandle hInstance, ResourceValue name)
		=> new() { Handle = NativeMethods.LoadIconW(hInstance, name.Id).ReturnOrThrow() };

	public static SafeGdiIcon LoadIconImage(this SafeInstanceHandle hInst, ResourceValue name,
		ImageType type, int cx, int cy, LoadResourceFlags fuLoad)
			=> new() { Handle = NativeMethods.LoadImageW(hInst, name.Id, type, cx, cy, fuLoad).ReturnOrThrow() };

}
