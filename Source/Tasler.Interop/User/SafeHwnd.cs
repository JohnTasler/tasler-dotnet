namespace Tasler.Interop.User;

public class SafeHwnd : SafeHandleZeroIsInvalid
{
	public static readonly SafeHwnd Null = new();

	protected override bool ReleaseHandle() => true;

	public static implicit operator SafeHwnd(nint handle) => new() { Handle = handle };
}
