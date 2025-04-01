using Tasler.Interop.User;

namespace Tasler.Interop;

public class WindowMessageEventArgs : EventArgs
{
	private WndProc _previousWndProc;

	#region Constructors
	internal WindowMessageEventArgs(WndProc previousWndProc, SafeHwnd hwnd, int message, nint wParam, nint lParam, uint time, POINT pt)
	{
		this._previousWndProc = previousWndProc;
		this.Hwnd = hwnd;
		this.MessageValue = message;
		this.WParam = wParam;
		this.LParam = lParam;
		this.Time = time;
		this.Point = pt;
	}

	internal WindowMessageEventArgs(WndProc previousWndProc, SafeHwnd hwnd, int message, nint wParam, nint lParam)
		: this(previousWndProc, hwnd, message, wParam, lParam, UserApi.GetMessageTime(), UserApi.GetMessagePosition())
	{
	}
	#endregion Constructors

	#region Value Properties

	public SafeHwnd Hwnd { get; private set; }
	public int MessageValue { get; private set; }
	public nint WParam { get; private set; }
	public nint LParam { get; private set; }
	public uint Time { get; private set; }
	public POINT Point { get; private set; }

	#endregion Value Properties

	#region Properties (with .NET names)

	public WM Message => (WM)this.MessageValue;

	public uint MessageTime => this.Time;

	public POINT MessagePosition => this.Point;

	public bool Handled { get; set; }

	public nint Result { get; set; }

	#endregion Properties (with .NET names)

	public nint CallBaseWindowProc()
		=> CallBaseWindowProc(this.Hwnd, this.MessageValue, this.WParam, this.LParam);

	public nint CallBaseWindowProc(SafeHwnd hWnd, WM Msg, nint wParam, nint lParam)
		=> this.CallBaseWindowProc(hWnd, (int)Msg, wParam, lParam);

	public nint CallBaseWindowProc(SafeHwnd hWnd, int Msg, nint wParam, nint lParam)
	{
		this.Handled = true;

		nint previousWndProcNative(nint hwnd, int message, nint wParam, nint lParam)
		{
			return _previousWndProc(hWnd, message, wParam, lParam);
		}

		return hWnd.CallWindowProc(previousWndProcNative, Msg, wParam, lParam);
	}

	public nint CallDefaultWindowProc()
		=> this.CallDefaultWindowProc(this.Hwnd, this.MessageValue, this.WParam, this.LParam);

	public nint CallDefaultWindowProc(SafeHwnd hWnd, WM Msg, nint wParam, nint lParam)
		=> this.CallDefaultWindowProc(hWnd, (int)Msg, wParam, lParam);

	public nint CallDefaultWindowProc(SafeHwnd hWnd, int Msg, nint wParam, nint lParam)
	{
		this.Handled = true;
		return UserApi.DefWindowProc(hWnd, Msg, wParam, lParam);
	}
}
