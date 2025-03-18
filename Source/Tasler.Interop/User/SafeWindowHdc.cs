using Tasler.Interop.Gdi;

namespace Tasler.Interop.User;

public class SafeWindowHdc : SafeHdc
{
	public SafeWindowHdc(SafeHwnd windowHandle)
		: base(true)
	{
		WindowHandle = windowHandle;
	}

	#region Properties
	public SafeHwnd WindowHandle { get; set; }
	#endregion Properties

	#region Overrides
	protected override bool ReleaseHandle()
	{
		return UserApi.NativeMethods.ReleaseDC(this.WindowHandle, this.Handle);
	}
	#endregion Overrides
}
