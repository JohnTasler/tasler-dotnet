
namespace Tasler.Interop.Gdi;

public class SafeGdiBrush : SafeGdiObject
{
	#region Constructors
	public SafeGdiBrush() : this(false) { }

	protected SafeGdiBrush(bool ownsHandle) : base(ownsHandle) { }
	#endregion Constructors
}

public class SafeGdiBrushOwned : SafeGdiBrush
{
	public SafeGdiBrushOwned() : base(true) { }
}
