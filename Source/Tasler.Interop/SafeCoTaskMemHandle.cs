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
		var oldHandle = Interlocked.Exchange(ref base.handle, nint.Zero);
		if (oldHandle == nint.Zero)
			return true; // Already released

		Marshal.FreeCoTaskMem(oldHandle);
		return true;
	}
	#endregion Overrides
}
