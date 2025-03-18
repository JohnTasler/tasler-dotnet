namespace Tasler.Interop.Gdi;

public abstract class SafeHdc : SafeHandleZeroIsInvalid
{
	public static readonly SafeHdc Null = new NullHdc();

	#region Constructors
	protected SafeHdc(bool ownsHandle)
		: base(ownsHandle)
	{
	}
	#endregion Constructors

	#region Overrides
	public override bool IsInvalid => base.handle == nint.Zero;

	#endregion Overrides

	#region Nested Types
	private class NullHdc : SafeHdc
	{
		public NullHdc() : base(false) {}

		protected override bool ReleaseHandle() => true;
	}
	#endregion Nested Types
}
