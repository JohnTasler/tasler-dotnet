using System.Runtime.InteropServices;

namespace Tasler.Interop;

public class SafeHGlobalHandle : SafeHandleZeroIsInvalid
{
	#region Construction
	public SafeHGlobalHandle()
		: base(nint.Zero, true)
	{
	}
	#endregion Construction

	#region Overrides
	protected override bool ReleaseHandle()
	{
		if (handle == nint.Zero)
			return true; // Already released or never allocated

		Marshal.FreeHGlobal(base.handle);
		return true;
	}
	#endregion Overrides
}
