
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
	public SafeGdiIconOwned()
		: base(true)
	{
	}

	protected override bool ReleaseHandle()
		=> UserApi.NativeMethods.DestroyIcon(DangerousGetHandle());
}
