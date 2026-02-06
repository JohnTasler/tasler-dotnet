
using System.Runtime.InteropServices;

namespace Tasler.Interop.Com;

public static class ComObjectExtensions
{
	/// <summary>
	/// Releases the underlying COM interface for the specified IUnknown and returns the resulting reference count.
	/// </summary>
	/// <param name="this">The COM object whose interface to release.</param>
	/// <returns>The reference count after the release, or 0 if the object is null or no interface pointer was obtained.</returns>
	public static int Release(this IUnknown @this)
	{
		if (@this is not null)
		{
			var raw = ComApi.Wrappers.GetOrCreateComInterfaceForObject(@this, CreateComInterfaceFlags.None);
			if (raw != nint.Zero)
				return Marshal.Release(raw);
		}

		return 0;
	}
}
