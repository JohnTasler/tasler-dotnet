using System.Runtime.InteropServices;
using Tasler.Interop.Gdi;

namespace Tasler.Interop.User;

#region WM_GETMINMAXINFO Parameter
[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct MINMAXINFO
{
	public POINT ptReserved;
	public POINT ptMaxSize;
	public POINT ptMaxPosition;
	public POINT ptMinTrackSize;
	public POINT ptMaxTrackSize;

	public void Initialize()
	{
		this.ptMaxSize = new POINT(UserApi.GetSystemMetrics(SM.MaximizedWidth), UserApi.GetSystemMetrics(SM.MaximizedHeight));
		this.ptMinTrackSize = new POINT(UserApi.GetSystemMetrics(SM.MinTrackWidth), UserApi.GetSystemMetrics(SM.MinTrackHeight));
		this.ptMaxTrackSize = new POINT(UserApi.GetSystemMetrics(SM.MaxTrackWidth), UserApi.GetSystemMetrics(SM.MaxTrackHeight));
	}
}
#endregion WM_GETMINMAXINFO Parameter

#region WM_WINDOWPOSITIONCHANGING/WM_WINDOWPOSITIONCHANGED Paramater
[StructLayout(LayoutKind.Sequential)]
public struct WINDOWPOS
{
	public nint hwnd;
	public nint hwndInsertAfter;
	public int x;
	public int y;
	public int cx;
	public int cy;
	public SWP flags;
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