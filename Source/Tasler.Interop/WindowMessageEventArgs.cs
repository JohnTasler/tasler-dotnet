using System;
using Tasler.Interop.User;

namespace Tasler.Interop
{
	public class WindowMessageEventArgs : EventArgs
	{
		private IntPtr previousWndProc;

		#region Constructors
		internal WindowMessageEventArgs(IntPtr previousWndProc, IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam, int time, POINT pt)
		{
			this.previousWndProc = previousWndProc;

			this.hwnd    = hwnd;
			this.message = message;
			this.wParam  = wParam;
			this.lParam  = lParam;
			this.time    = time;
			this.pt      = pt;
		}

		internal WindowMessageEventArgs(IntPtr previousWndProc, IntPtr hwnd, int message, IntPtr wParam, IntPtr lParam)
			: this(previousWndProc, hwnd, message, wParam, lParam, UserApi.GetMessageTime(), UserApi.GetMessagePosAsPOINT())
		{
		}
		#endregion Constructors

		#region Value Properties (named the same as in the Windows MSG struct)

		public IntPtr hwnd    { get; private set; }
		public int    message { get; private set; }
		public IntPtr wParam  { get; private set; }
		public IntPtr lParam  { get; private set; }
		public int    time    { get; private set; }
		public POINT  pt      { get; private set; }

		#endregion Value Properties (named the same as in the Windows MSG struct)

		#region Properties (with .NET names)

		public IntPtr WindowHandle
		{
			get { return this.hwnd; }
		}

		public int MessageValue
		{
			get { return this.message; }
		}

		public WM Message
		{
			get { return (WM)this.message; }
		}

		public IntPtr WParam
		{
			get { return this.wParam; }
		}

		public IntPtr LParam
		{
			get { return this.lParam; }
		}

		public int MessageTime
		{
			get { return this.time; }
		}

		public POINT MessagePosition
		{
			get { return this.pt; }
		}

		public bool Handled { get; set; }

		public IntPtr Result { get; set; }

		#endregion Properties (with .NET names)



		public IntPtr CallBaseWindowProc()
		{
			return CallBaseWindowProc(this.hwnd, this.MessageValue, this.wParam, this.lParam);
		}

		public IntPtr CallBaseWindowProc(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam)
		{
			return this.CallBaseWindowProc(hWnd, (int)Msg, wParam, lParam);
		}

		public IntPtr CallBaseWindowProc(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam)
		{
			this.Handled = true;
			return UserApi.CallWindowProc(this.previousWndProc, hWnd, Msg, wParam, lParam);
		}


		public IntPtr CallDefaultWindowProc()
		{
			return this.CallDefaultWindowProc(this.hwnd, this.MessageValue, this.wParam, this.lParam);
		}

		public IntPtr CallDefaultWindowProc(IntPtr hWnd, WM Msg, IntPtr wParam, IntPtr lParam)
		{
			return this.CallDefaultWindowProc(hWnd, (int)Msg, wParam, lParam);
		}

		public IntPtr CallDefaultWindowProc(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam)
		{
			this.Handled = true;
			return UserApi.DefWindowProc(hWnd, Msg, wParam, lParam);
		}
	}
}
