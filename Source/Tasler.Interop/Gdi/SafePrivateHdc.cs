
namespace Tasler.Interop.Gdi;

public class SafePrivateHdc : SafeHdc
{
	#region Overrides
	protected override bool ReleaseHandle()
	{
		return this.DeleteDC();
	}
	#endregion Overrides
}
