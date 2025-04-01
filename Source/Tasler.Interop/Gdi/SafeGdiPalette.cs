
namespace Tasler.Interop.Gdi;

public class SafeGdiPalette : SafeGdiObject
{
	#region Constructors
	public SafeGdiPalette() : this(false) { }

	protected SafeGdiPalette(bool ownsHandle) : base(ownsHandle) { }
	#endregion Constructors
}

public class SafeGdiPaletteOwned : SafeGdiPalette
{
	public SafeGdiPaletteOwned() : base(true) { }
}
