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
	public SafeHwnd WindowHandle { get; private set; } = new SafeHwnd();
	#endregion Properties

	#region Methods
	public void Attach(SafeHwnd hwnd)
	{
		if (this.WindowHandle != hwnd)
			this.Detach();

		if (!hwnd.IsInvalid)
		{
			this.WindowHandle = hwnd;
			this.OnAttached();
		}
	}

	public SafeHwnd Detach()
	{
		var result = this.WindowHandle;
		if (!this.WindowHandle.IsInvalid)
		{
			this.OnDetaching();
			this.WindowHandle = new SafeHwnd();
		}
		return result;
	}
	#endregion Methods

	#region Protected Abstract Methods
	protected abstract void OnAttached();

	protected abstract void OnDetaching();
	#endregion Protected Abstract Methods

	#region Overrides
	protected override nint OnRedirected(SafeHwnd hwnd, int message, nint wParam, nint lParam, ref bool handled)
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
