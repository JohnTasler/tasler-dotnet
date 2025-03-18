using System.Runtime.InteropServices;

namespace Tasler.Interop.Gdi;

public class SafeGdiObject : SafeHandleZeroIsInvalid
{
	#region Constructors
	public SafeGdiObject()
		: this(false)
	{
	}

	protected SafeGdiObject(bool ownsHandle)
		: base(ownsHandle)
	{
	}
	#endregion Constructors

	#region Overrides
	protected override bool ReleaseHandle() => this.DeleteObject();
	#endregion Overrides
}

public class SafeGdiObjectOwned : SafeGdiObject
{
	public SafeGdiObjectOwned()
		: base(true)
	{
	}
}
