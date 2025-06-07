
using Tasler.Interop.User;

namespace Tasler.Interop.Gdi;

public class SafeGdiCursor : SafeGdiObject
{
	#region Constructors
	public SafeGdiCursor()
		: this(false)
	{
	}

	protected SafeGdiCursor(bool ownsHandle)
		: base(ownsHandle)
	{
	}
	#endregion Constructors
}

public class SafeGdiCursorOwned : SafeGdiCursor
{
	public SafeGdiCursorOwned()
		: base(true)
	{
	}

	protected override bool ReleaseHandle()
		=> UserApi.NativeMethods.DestroyCursor(DangerousGetHandle());
}
