using Tasler.Interop.User;

namespace Tasler.Interop;

public class WindowMessageEventArgs : EventArgs
{
	private nint previousWndProc;

	#region Constructors
	internal WindowMessageEventArgs(nint previousWndProc, nint hwnd, int message, nint wParam, nint lParam, int time, POINT pt)
	{
		this.previousWndProc = previousWndProc;

		this.hwnd = hwnd;
		this.message = message;
		this.wParam = wParam;
		this.lParam = lParam;
		this.time = time;
		this.pt = pt;
	}

	internal WindowMessageEventArgs(nint previousWndProc, nint hwnd, int message, nint wParam, nint lParam)
		: this(previousWndProc, hwnd, message, wParam, lParam, UserApi.GetMessageTime(), UserApi.GetMessagePosAsPOINT())
	{
	}
	#endregion Constructors

	#region Value Properties (named the same as in the Windows MSG struct)

	public nint hwnd { get; private set; }
	public int message { get; private set; }
	public nint wParam { get; private set; }
	public nint lParam { get; private set; }
	public int time { get; private set; }
	public POINT pt { get; private set; }

	#endregion Value Properties (named the same as in the Windows MSG struct)

	#region Properties (with .NET names)

	public nint WindowHandle
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

	public nint WParam
	{
		get { return this.wParam; }
	}

	public nint LParam
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

	public nint Result { get; set; }

	#endregion Properties (with .NET names)

	public nint CallBaseWindowProc()
	{
		return CallBaseWindowProc(this.hwnd, this.MessageValue, this.wParam, this.lParam);
	}

	public nint CallBaseWindowProc(nint hWnd, WM Msg, nint wParam, nint lParam)
	{
		return this.CallBaseWindowProc(hWnd, (int)Msg, wParam, lParam);
	}

	public nint CallBaseWindowProc(nint hWnd, int Msg, nint wParam, nint lParam)
	{
		this.Handled = true;
		return UserApi.CallWindowProc(this.previousWndProc, hWnd, Msg, wParam, lParam);
	}


	public nint CallDefaultWindowProc()
	{
		return this.CallDefaultWindowProc(this.hwnd, this.MessageValue, this.wParam, this.lParam);
	}

	public nint CallDefaultWindowProc(nint hWnd, WM Msg, nint wParam, nint lParam)
	{
		return this.CallDefaultWindowProc(hWnd, (int)Msg, wParam, lParam);
	}

	public nint CallDefaultWindowProc(nint hWnd, int Msg, nint wParam, nint lParam)
	{
		this.Handled = true;
		return UserApi.DefWindowProc(hWnd, Msg, wParam, lParam);
	}
}
