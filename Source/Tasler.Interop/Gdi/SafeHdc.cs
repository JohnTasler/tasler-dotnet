namespace Tasler.Interop.Gdi;

public class SafeHdc : SafeHandleZeroIsInvalid
{
	public static readonly SafeHdc Null = new();

	public SafeHdc()
		: this(nint.Zero, false)
	{
	}

	public SafeHdc(nint handle, bool ownsHandle = false)
		: base(handle, ownsHandle)
	{
	}

	protected override bool ReleaseHandle() => true;
}
