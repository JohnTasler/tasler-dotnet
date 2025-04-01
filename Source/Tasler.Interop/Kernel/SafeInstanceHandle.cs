namespace Tasler.Interop.Kernel;

public class SafeInstanceHandle : SafeHandleZeroIsInvalid
{
	#region Constructors
	public SafeInstanceHandle()
		: this(nint.Zero, false)
	{
	}

	protected SafeInstanceHandle(nint handle, bool ownsHandle)
		: base(handle, ownsHandle)
	{
	}
	#endregion Constructors

	#region Overrides
	protected override bool ReleaseHandle() => true;
	#endregion Overrides
}
