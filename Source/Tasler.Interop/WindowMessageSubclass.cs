using System.Diagnostics;
using System.Runtime.InteropServices;
using Tasler.Interop.User;

namespace Tasler.Interop;

public class WindowMessageSubclass : WindowMessageProcessor
{
	#region Constructors
	public WindowMessageSubclass()
	{
	}

	public WindowMessageSubclass(WindowMessageRedirector outerRedirector)
		: base(outerRedirector)
	{
	}
	#endregion Constructors

	#region Overrides

	protected override void OnAttached()
	{
		if (this.HasEventSubscribers)
			this.Subclass();
	}

	protected override void OnDetaching()
	{
		if (this.IsSubclassed)
			this.Unsubclass();
	}

	protected override void OnHasEventSubscribersChanged()
	{
		if (this.WindowHandle.Handle != nint.Zero)
		{
			if (this.HasEventSubscribers)
				this.Subclass();
			else
				this.Unsubclass();
		}
	}

	#endregion Overrides

	#region Private Implementation

	private bool IsSubclassed
	{
		get { return this.OriginalWindowProcedure != null; }
	}

	private void Subclass()
	{
		Debug.Assert(!this.WindowHandle.IsInvalid);
		Debug.Assert(this.IsSubclassed == false);

		this.OriginalWindowProcedure = Marshal.GetDelegateForFunctionPointer<WndProcNative>(this.WindowHandle.GetWindowLongPtr(GWLP.WndProc));
		this.WindowHandle.SetWindowLongPtr(GWLP.WndProc, this.WindowProcedure);
	}

	private void Unsubclass()
	{
		Debug.Assert(this.WindowHandle.Handle != nint.Zero);
		Debug.Assert(this.IsSubclassed == true);

		// Restore the window's previous window procedure
		if (this.OriginalWindowProcedure is not null)
		{
			this.WindowHandle.SetWindowLongPtr(GWLP.WndProc, Marshal.GetFunctionPointerForDelegate(this.OriginalWindowProcedure));
		}

		// Clear our state
		this.OriginalWindowProcedure = null;
		this.ClearWindowProcedure();
	}

	#endregion Private Implementation
}
