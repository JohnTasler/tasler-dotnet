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
	/// <summary>
	/// Initializes a new instance of the <see cref="SafeGdiCursorOwned"/> class,
	/// indicating ownership of the cursor handle.
	/// </summary>
	public SafeGdiCursorOwned()
		: base(true)
	{
	}

	/// <summary>
	/// Releases the cursor handle by invoking the native DestroyCursor method.
	/// </summary>
	/// <returns>True if the cursor was successfully destroyed; otherwise, false.</returns>
	protected override bool ReleaseHandle()
		=> UserApi.NativeMethods.DestroyCursor(DangerousGetHandle());
}
