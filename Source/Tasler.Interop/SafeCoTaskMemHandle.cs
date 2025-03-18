using System.Runtime.InteropServices;

namespace Tasler.Interop;

public class SafeCoTaskMemHandle : SafeHandle
{
	#region Construction
	public SafeCoTaskMemHandle()
		: base(nint.Zero, true)
	{
	}
	#endregion Construction

	#region Overrides
	public override bool IsInvalid
	{
		get
		{
			return base.handle == nint.Zero;
		}
	}

	protected override bool ReleaseHandle()
	{
		Marshal.FreeCoTaskMem(base.handle);
		base.handle = nint.Zero;
		return true;
	}
	#endregion Overrides
}
