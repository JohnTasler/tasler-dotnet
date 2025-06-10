using Tasler.Interop.User;

namespace Tasler.Interop.Gdi;

public class SafeGdiIcon : SafeGdiObject
{
	#region Constructors
	public SafeGdiIcon()
		: this(false)
	{
	}

	protected SafeGdiIcon(bool ownsHandle)
		: base(ownsHandle)
	{
	}
	#endregion Constructors
}

public class SafeGdiIconOwned : SafeGdiIcon
{
	/// <summary>
	/// Initializes a new instance of the <see cref="SafeGdiIconOwned"/> class that owns the underlying icon handle.
	/// </summary>
	public SafeGdiIconOwned()
		: base(true)
	{
	}

	/// <summary>
		/// Releases the icon handle by calling DestroyIcon on the underlying GDI handle.
		/// </summary>
		/// <returns>True if the icon handle was successfully released; otherwise, false.</returns>
		protected override bool ReleaseHandle()
		=> UserApi.NativeMethods.DestroyIcon(DangerousGetHandle());
}
