namespace Tasler.Interop.Gdi;

public class SafeGdiObject : SafeHandleZeroIsInvalid
{
	public static readonly SafeGdiObject HGDI_ERROR = new SafeGdiObject() { Handle = (nint)(-1) };

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

	protected override bool ReleaseHandle() => this.IsInvalid ? false : GdiApi.NativeMethods.DeleteObject(this);
	#endregion Overrides
}

public class SafeGdiObjectOwned : SafeGdiObject
{
	public SafeGdiObjectOwned()
		: base(true)
	{
	}
}
