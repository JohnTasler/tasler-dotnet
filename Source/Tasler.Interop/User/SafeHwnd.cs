namespace Tasler.Interop.User;

public class SafeHwnd	: SafeHandleZeroIsInvalid
{
	protected override bool ReleaseHandle() => true;
}
