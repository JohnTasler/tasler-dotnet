
namespace Tasler.Interop.Gdi;

public class SafeGdiPen : SafeGdiObject
{
	#region Constructors
	public SafeGdiPen() : this(false) { }

	protected SafeGdiPen(bool ownsHandle) : base(ownsHandle) { }
	#endregion Constructors
}

public class SafeGdiPenOwned : SafeGdiPen
{
	public SafeGdiPenOwned() : base(true) { }
}
