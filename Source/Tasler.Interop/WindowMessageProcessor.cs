using Tasler.Interop.User;

namespace Tasler.Interop;

public abstract class WindowMessageProcessor : WindowMessageRedirector
{
	#region Constructors
	protected WindowMessageProcessor()
	{
	}

	protected WindowMessageProcessor(WindowMessageRedirector outerRedirector)
		: base(outerRedirector)
	{
	}
	#endregion Constructors

	#region Properties
	public nint WindowHandle { get; private set; }
	#endregion Properties

	#region Methods
	public void Attach(nint hwnd)
	{
		if (this.WindowHandle != hwnd)
			this.Detach();

		if (hwnd != nint.Zero)
		{
			this.WindowHandle = hwnd;
			this.OnAttached();
		}
	}

	public void Detach()
	{
		if (this.WindowHandle != nint.Zero)
		{
			this.OnDetaching();
			this.WindowHandle = nint.Zero;
		}
	}
	#endregion Methods

	#region Protected Abstract Methods
	protected abstract void OnAttached();

	protected abstract void OnDetaching();
	#endregion Protected Abstract Methods

	#region Overrides
	protected override nint OnRedirected(nint hwnd, int message, nint wParam, nint lParam, ref bool handled)
	{
		if (message == (int)WM.NCDESTROY)
		{
			this.Detach();
			this.ClearWindowProcedure();
		}

		return nint.Zero;
	}
	#endregion Overrides
}
