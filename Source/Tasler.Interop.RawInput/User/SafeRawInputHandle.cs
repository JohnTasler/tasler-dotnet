namespace Tasler.Interop.Gdi;

public class SafeRawInputHandle : SafeHandleZeroIsInvalid
{
	public SafeRawInputHandle()
		: this(nint.Zero, false)
	{
	}

	public SafeRawInputHandle(nint handle, bool ownsHandle = false)
		: base(handle, ownsHandle)
	{
	}

	protected override bool ReleaseHandle() => true;
}
