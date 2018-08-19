using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop.User
{
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
		public IntPtr hwnd;
		public IntPtr hwndInsertAfter;
		public int x;
		public int y;
		public int cx;
		public int cy;
		public SWP flags;
	}
	#endregion WM_WINDOWPOSITIONCHANGING/WM_WINDOWPOSITIONCHANGED Paramater

	[StructLayout(LayoutKind.Sequential)]
	public class WINDOWPLACEMENT
	{
		public static readonly int MarshalSizeOf =
			Marshal.SizeOf(typeof(WINDOWPLACEMENT));

		private int _length = MarshalSizeOf;
		public int flags;
		public SW showCmd;
		public POINT ptMinPosition;
		public POINT ptMaxPosition;
		public RECTstruct rcNormalPosition;
	}
}
