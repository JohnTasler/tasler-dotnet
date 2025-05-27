namespace Tasler.Interop.Gdi;

public class SafeGdiObject : SafeHandleZeroIsInvalid
{
	public static readonly SafeGdiObject HGDI_ERROR = new() { Handle = (nint)(-1) };

	#region Constructors
	public SafeGdiObject()
		: this(false)
	{
	}

	public SafeGdiObject(bool ownsHandle)
		: base(nint.Zero, ownsHandle)
	{
	}
	#endregion Constructors

	#region Overrides
	public override bool IsInvalid => base.handle == (nint)(-1);

	protected override bool ReleaseHandle() => true;
	#endregion Overrides
}

public class SafeGdiObjectOwned : SafeGdiObject
{
	#region Constructor
	public SafeGdiObjectOwned()
		: base(true)
	{
	}
	#endregion Constructor

	#region Overrides
	protected override bool ReleaseHandle() => !this.IsInvalid && GdiApi.NativeMethods.DeleteObject(this);
	#endregion Overrides
}
