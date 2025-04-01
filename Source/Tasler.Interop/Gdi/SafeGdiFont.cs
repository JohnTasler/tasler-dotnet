
namespace Tasler.Interop.Gdi;

public class SafeGdiFont : SafeGdiObject
{
	#region Constructors
	public SafeGdiFont() : this(false) { }

	protected SafeGdiFont(bool ownsHandle) : base(ownsHandle) { }
	#endregion Constructors
}

public class SafeGdiFontOwned : SafeGdiFont
{
	public SafeGdiFontOwned() : base(true) { }
}
