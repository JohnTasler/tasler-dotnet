
namespace Tasler.Interop.Gdi;

public class SafePrivateHdc : SafeHdc
{
	#region Overrides
	protected override bool ReleaseHandle()
	{
		return Gdi.GdiApi.NativeMethods.DeleteDC(this);
	}
	#endregion Overrides
}
