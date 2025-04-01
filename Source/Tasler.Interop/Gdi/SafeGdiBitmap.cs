
namespace Tasler.Interop.Gdi;

public class SafeGdiBitmap : SafeGdiObject
{
	#region Constructors
	public SafeGdiBitmap() : this(false) { }

	protected SafeGdiBitmap(bool ownsHandle) : base(ownsHandle) { }
	#endregion Constructors
}

public class SafeGdiBitmapOwned : SafeGdiBitmap
{
	public SafeGdiBitmapOwned() : base(true) { }
}
