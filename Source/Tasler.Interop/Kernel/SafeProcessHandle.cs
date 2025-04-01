namespace Tasler.Interop.Kernel;

public class SafeProcessHandle : SafeHandleZeroIsInvalid
{
	#region Constructors
	public SafeProcessHandle()
		: this(nint.Zero, false)
	{
	}

	protected SafeProcessHandle(nint handle, bool ownsHandle)
		: base(handle, ownsHandle)
	{
	}
	#endregion Constructors

	#region Overrides
	protected override bool ReleaseHandle() => true;
	#endregion Overrides
}

public class SafeProcessHandleOwned : SafeProcessHandle
{
	public SafeProcessHandleOwned(nint handle)
		: base(handle, true)
	{
	}

	protected override bool ReleaseHandle() => KernelApi.NativeMethods.CloseHandle(this);
}
