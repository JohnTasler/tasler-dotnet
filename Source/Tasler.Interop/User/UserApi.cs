using System;
using System.Runtime.InteropServices;
using System.Security;

using Tasler.Interop.Gdi;

namespace Tasler.Interop.User
{
    public static partial class UserApi
    {
        //#region Constants
        //private const string ApiLib = "user32.dll";
        //#endregion Constants

        public static IntPtr GetWindowLongPtr(HandleRef hwnd, GWLP index)
        {
            return Environment.Is64BitProcess
                ? GetWindowLongPtr64(hwnd, index)
                : GetWindowLongPtr32(hwnd, index);
        }

        public static IntPtr SetWindowLongPtr(HandleRef hwnd, GWLP index, IntPtr newValue)
        {
            return Environment.Is64BitProcess
                ? SetWindowLongPtr64(hwnd, index, newValue)
                : SetWindowLongPtr32(hwnd, index, newValue);
        }

        #region Safe Methods
        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool AnimateWindow(HandleRef hWnd, uint dwTime, uint dwFlags);

        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool EnableWindow(HandleRef hWnd, bool enable);

        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool GetClientRect(HandleRef hWnd, [In, Out] ref RECT rect);

        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int GetUpdateRgn(HandleRef hwnd, HandleRef hrgn, bool fErase);

        [DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref RECT rect);

        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, SWP flags);

        [DllImport(ApiLib)]
        public static extern bool ShowWindow(HandleRef hWnd, SW nCmdShow);

        [DllImport(ApiLib)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic(IntPtr hWnd);

        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool ValidateRect(HandleRef hWnd, IntPtr rect);
        #endregion Safe Methods

        #region Unsafe Methods
        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr BeginPaint(HandleRef hWnd, [In, Out] ref PAINTSTRUCT lpPaint);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool EndPaint(HandleRef hWnd, ref PAINTSTRUCT lpPaint);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern bool UpdateLayeredWindow(HandleRef hWnd, IntPtr hdcDst,
            IntPtr pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pptSrc, uint crKey,
            ref BLENDFUNCTION pblend, uint dwFlags);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetWindow(HandleRef hWnd, GW uCmd);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(HandleRef hwnd, WM msg, IntPtr wparam, IntPtr lparam);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hwnd, WM msg, IntPtr wparam, IntPtr lparam);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [In, Out] ref RECT rect, int cPoints);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, EntryPoint = "GetWindowLongPtr", ExactSpelling = false)]
        private static extern IntPtr GetWindowLongPtr64(HandleRef hwnd, GWLP index);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, EntryPoint = "GetWindowLong", ExactSpelling = false)]
        private static extern IntPtr GetWindowLongPtr32(HandleRef hwnd, GWLP index);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, EntryPoint = "SetWindowLongPtr", ExactSpelling = false)]
        private static extern IntPtr SetWindowLongPtr64(HandleRef hwnd, GWLP index, IntPtr newValue);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, EntryPoint = "SetWindowLong", ExactSpelling = false)]
        private static extern IntPtr SetWindowLongPtr32(HandleRef hwnd, GWLP index, IntPtr newValue);

        public static WS GetWindowStyle(HandleRef hwnd)
        {
            WS dwStyle = (WS)GetWindowLongPtr(hwnd, GWLP.Style).ToInt32();
            return dwStyle;
        }

        public static bool ModifyStyle(HandleRef hwnd, WS remove, WS add)
        {
            return ModifyStyle(hwnd, remove, add, false);
        }

        public static bool ModifyStyle(HandleRef hwnd, WS remove, WS add, bool updateFrame)
        {
            WS dwStyle = GetWindowStyle(hwnd);
            WS dwNewStyle = (dwStyle & ~remove) | add;
            if (dwStyle == dwNewStyle)
                return false;

            SetWindowLongPtr(hwnd, GWLP.Style, (IntPtr)dwNewStyle);
            if (updateFrame)
            {
                UserApi.SetWindowPos(hwnd, new HandleRef(), 0, 0, 0, 0,
                    SWP.NoSize | SWP.NoMove | SWP.NoZOrder | SWP.NoActivate | SWP.DrawFrame | SWP.FrameChanged);
            }

            return true;
        }

        public static WS_EX GetWindowStyleEx(HandleRef hwnd)
        {
            WS_EX dwStyle = (WS_EX)UserApi.GetWindowLongPtr(hwnd, GWLP.ExStyle).ToInt32();
            return dwStyle;
        }

        public static bool ModifyStyleEx(HandleRef hwnd, WS_EX remove, WS_EX add)
        {
            return ModifyStyleEx(hwnd, remove, add, false);
        }

        public static bool ModifyStyleEx(HandleRef hwnd, WS_EX remove, WS_EX add, bool updateFrame)
        {
            WS_EX dwStyle = GetWindowStyleEx(hwnd);
            WS_EX dwNewStyle = (dwStyle & ~remove) | add;
            if (dwStyle == dwNewStyle)
                return false;

            UserApi.SetWindowLongPtr(hwnd, GWLP.ExStyle, (IntPtr)dwNewStyle);
            if (updateFrame)
            {
                UserApi.SetWindowPos(hwnd, new HandleRef(), 0, 0, 0, 0,
                    SWP.NoSize | SWP.NoMove | SWP.NoZOrder | SWP.NoActivate | SWP.DrawFrame | SWP.FrameChanged);
            }

            return true;
        }

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetActiveWindow();

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SetActiveWindow(HandleRef hWnd);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, EntryPoint = "DefWindowProcW", CharSet = CharSet.Unicode)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, EntryPoint = "DefWindowProcW", CharSet = CharSet.Unicode)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, EntryPoint = "CallWindowProcW", CharSet = CharSet.Unicode)]
        public static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [SuppressUnmanagedCodeSecurity]
        [DllImport(ApiLib, EntryPoint = "CallWindowProcW", CharSet = CharSet.Unicode)]
        public static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam);
        #endregion Unsafe Methods
    }

    #region Delegates
    [SuppressUnmanagedCodeSecurity]
    public delegate IntPtr WndProc(IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam);
    #endregion Delegates
}
