
using System.Runtime.InteropServices;

namespace Tasler.Interop.Com;

public static class ComObjectExtensions
{
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
