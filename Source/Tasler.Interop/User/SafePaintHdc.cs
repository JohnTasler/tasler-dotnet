using Tasler.Interop.Gdi;

namespace Tasler.Interop.User;

public class SafePaintHdc : SafeHdc
{
	public SafePaintHdc(PAINTSTRUCT paintStruct)
		: base(true)
	{
		this.PaintStruct = paintStruct;
	}

	#region Properties
	public PAINTSTRUCT PaintStruct { get; set; }
	#endregion Properties

	#region Overrides
	protected override bool ReleaseHandle()
	{
		return UserApi.ReleaseDC(this.WindowHandle, base.handle);
	}
	#endregion Overrides
}
