using System.Runtime.InteropServices;

namespace Tasler.Interop.User;

#region Delegates

public delegate nint WndProcNative(nint hwnd, int message, nint wParam, nint lParam);
public delegate nint WndProc(SafeHwnd hwnd, int message, nint wParam, nint lParam);

[return: MarshalAs(UnmanagedType.Bool)]
public delegate bool EnumWindowsProc(nint hwnd, nint lParam);

#endregion Delegates
