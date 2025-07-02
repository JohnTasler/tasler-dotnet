using System.Runtime.InteropServices;

namespace Tasler.Interop.Shell;

public static partial class PropSysApi
{
	public static string GetNameFromPropertyKey(PropertyKey propkey)
	{
		SafeCoTaskMemString pszCanonicalName = null!;
		int hr = NativeMethods.PSGetNameFromPropertyKey(propkey, out pszCanonicalName);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return pszCanonicalName.Value ?? string.Empty;
	}

	public static partial class NativeMethods
	{
		private const string PropSys = "propsys.dll";

		[LibraryImport(PropSys)]
		internal static partial int PSGetNameFromPropertyKey(PropertyKey propkey, out SafeCoTaskMemString ppszCanonicalName);

		[LibraryImport(PropSys)]
		internal static partial int PSGetPropertyDescription(
			PropertyKey propkey,
			ref Guid riid,
			out nint ppv);
	}
}
