using System.Runtime.InteropServices;

namespace Tasler.Interop;

public class SafeCoTaskMemHandle : SafeHandleZeroIsInvalid
{
	#region Construction
	public SafeCoTaskMemHandle()
		: base(nint.Zero, true)
	{
	}
	#endregion Construction

	#region Overrides
	protected override bool ReleaseHandle()
	{
		if (base.handle == nint.Zero)
			return true; // Already released

		Marshal.FreeCoTaskMem(base.handle);
		base.handle = nint.Zero;
		return true;
	}
	#endregion Overrides
}
