namespace Tasler.Interop.User;

public class SafeHwnd	: SafeHandleZeroIsInvalid
{
	public SafeHwnd() : base(false) { }

	protected override bool ReleaseHandle() => true;
}
