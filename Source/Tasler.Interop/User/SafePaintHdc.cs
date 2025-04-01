using Tasler.Interop.Gdi;

namespace Tasler.Interop.User;

public class SafePaintHdc : SafeHdc
{
	public SafePaintHdc(PAINTSTRUCT paintStruct, SafeHwnd windowHandle)
		: base(nint.Zero, true)
	{
		this.PaintStruct = paintStruct;
		this.WindowHandle = windowHandle;
	}

	#region Properties
	public PAINTSTRUCT PaintStruct { get; set; }

	public SafeHwnd WindowHandle { get; init; }
	#endregion Properties

	#region Overrides
	protected override bool ReleaseHandle()
	{
		var paintStruct = this.PaintStruct;
		unsafe
		{
			#pragma warning disable CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
			return UserApi.NativeMethods.EndPaint(WindowHandle, &paintStruct);
			#pragma warning restore CS8500 // This takes the address of, gets the size of, or declares a pointer to a managed type
		}
	}
	#endregion Overrides
}
