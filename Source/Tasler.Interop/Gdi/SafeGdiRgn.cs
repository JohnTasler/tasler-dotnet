
namespace Tasler.Interop.Gdi;

public class SafeGdiRgn : SafeGdiObject
{
	#region Constructors
	public SafeGdiRgn() : this(false) { }

	protected SafeGdiRgn(bool ownsHandle) : base(ownsHandle) { }
	#endregion Constructors
}

public class SafeGdiRgnOwned : SafeGdiRgn
{
	public SafeGdiRgnOwned() : base(true) { }
}
