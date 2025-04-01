using System.Runtime.InteropServices;
using Tasler.Interop.Gdi;
using Tasler.Interop.Kernel;

namespace Tasler.Interop.User;

#region WM_GETMINMAXINFO Parameter
[StructLayout(LayoutKind.Sequential)]
public struct MINMAXINFO
{
	private POINT _reserved;
	public POINT MaxSize;
	public POINT MaxPosition;
	public POINT MinTrackSize;
	public POINT MaxTrackSize;

	private unsafe static MINMAXINFO FromLParamUnsafe(nint lParam) => *(MINMAXINFO*)lParam;

	public static MINMAXINFO FromLParam(nint lParam) => FromLParamUnsafe(lParam);

	public void Initialize()
	{
		this.MaxSize = new POINT(UserApi.GetSystemMetrics(SM.MaximizedWidth), UserApi.GetSystemMetrics(SM.MaximizedHeight));
		this.MinTrackSize = new POINT(UserApi.GetSystemMetrics(SM.MinTrackWidth), UserApi.GetSystemMetrics(SM.MinTrackHeight));
		this.MaxTrackSize = new POINT(UserApi.GetSystemMetrics(SM.MaxTrackWidth), UserApi.GetSystemMetrics(SM.MaxTrackHeight));
	}
}
#endregion WM_GETMINMAXINFO Parameter

#region WM_WINDOWPOSITIONCHANGING/WM_WINDOWPOSITIONCHANGED Paramater
[StructLayout(LayoutKind.Sequential)]
public struct WINDOWPOS
{
	private nint _hwnd;
	private nint _hwndInsertAfter;
	public int X;
	public int Y;
	public int Width;
	public int Height;
	public SWP Flags;

	private unsafe static WINDOWPOS FromLParamUnsafe(nint lParam) => *(WINDOWPOS*)lParam;

	public static WINDOWPOS FromLParam(nint lParam) => FromLParamUnsafe(lParam);

	public readonly SafeHwnd Hwnd => new() { Handle = _hwnd };
	public readonly SafeHwnd HwndInsertAfter => new() { Handle = _hwndInsertAfter };
}
#endregion WM_WINDOWPOSITIONCHANGING/WM_WINDOWPOSITIONCHANGED Paramater

[StructLayout(LayoutKind.Sequential)]
public struct WINDOWPLACEMENT
{
	public static readonly int MarshalSizeOf = Marshal.SizeOf<WINDOWPLACEMENT>();

	public WINDOWPLACEMENT() { }
	private int _length = MarshalSizeOf;
	public int Flags;
	public SW ShowCommand;
	public POINT MinimizedPosition;
	public POINT MaximizedPosition;
	public RECT NormalPosition;
}

public struct WNDCLASSEX
{
	private uint _cbSize = (uint)Marshal.SizeOf<WNDCLASSEX>();
	public CS                 Style;
	public WndProcNative?     WndProc;
	public int                ClasssExtraByteCount;
	public int                WindowExtraByteCount;
	public SafeInstanceHandle Instance;
	public SafeGdiIcon        Icon;
	public SafeGdiCursor      Cursor;
	public SafeGdiBrush       BackgroundBrush;
	public string             MenuName = string.Empty;
	public string             ClassName = string.Empty;
	public SafeGdiIcon        SmallIcon;

	public WNDCLASSEX(WNDCLASSEXW native)
	{
		Style = (CS)native.Style;
		WndProc = Marshal.GetDelegateForFunctionPointer<WndProcNative>(native.WndProc);
		ClasssExtraByteCount = native.ClasssExtraByteCount;
		WindowExtraByteCount = native.WindowExtraByteCount;
		Instance = new SafeInstanceHandle { Handle = native.Instance };
		Icon = new SafeGdiIcon { Handle = native.Icon };
		Cursor = new SafeGdiCursor { Handle = native.Cursor };
		BackgroundBrush = new SafeGdiBrush { Handle = native.BackgroundBrush };
		SmallIcon = new SafeGdiIcon { Handle = native.SmallIcon };
		MenuName = Marshal.PtrToStringUni(native.MenuName)!;
		ClassName = Marshal.PtrToStringUni(native.ClassName)!;
	}
}

public unsafe struct WNDCLASSEXW
{
	private uint _size = (uint)Marshal.SizeOf<WNDCLASSEXW>();
	public uint Style;
	public nint WndProc;
	public int  ClasssExtraByteCount;
	public int  WindowExtraByteCount;
	public nint Instance;
	public nint Icon;
	public nint Cursor;
	public nint BackgroundBrush;
	public nint MenuName;
	public nint ClassName;
	public nint SmallIcon;

	public WNDCLASSEXW()
	{
	}
}

[StructLayout(LayoutKind.Sequential)]
public struct PAINTSTRUCT
{
	public SafeHdc Hdc;
	[MarshalAs(UnmanagedType.Bool)]
	public bool MustErase;
	public RECT PaintRectangle;

	private uint _fRestore;
	private uint _fIncUpdate;
	private ulong _rgbReserved0;
	private ulong _rgbReserved1;
	private ulong _rgbReserved2;
	private ulong _rgbReserved3;
}
