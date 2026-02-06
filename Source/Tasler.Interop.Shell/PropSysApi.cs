using System.Runtime.InteropServices;

namespace Tasler.Interop.Shell;

public static partial class PropSysApi
{
	/// <summary>
	/// Gets the canonical name associated with the specified property key.
	/// </summary>
	/// <param name="propkey">The property key whose canonical name to retrieve.</param>
	/// <returns>The canonical property name, or an empty string if no name is available.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown when the native API returns a failing HRESULT.</exception>
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

		/// <summary>
		/// Retrieves the canonical name associated with a PropertyKey.
		/// </summary>
		/// <param name="propkey">The property key to query.</param>
		/// <param name="ppszCanonicalName">When successful, receives a SafeCoTaskMemString that wraps the canonical name returned by the native API.</param>
		/// <returns>An HRESULT value indicating the result of the operation (S_OK on success).</returns>
		[LibraryImport(PropSys)]
		internal static partial int PSGetNameFromPropertyKey(PropertyKey propkey, out SafeCoTaskMemString ppszCanonicalName);

		/// <summary>
		/// Retrieves a property description object for the specified property key using the requested interface IID.
		/// </summary>
		/// <param name="propkey">The property key identifying the property whose description is requested.</param>
		/// <param name="riid">The IID of the interface being requested; identifies the interface returned in <paramref name="ppv"/>.</param>
		/// <param name="ppv">Receives a pointer to the requested interface on success; the caller is responsible for releasing the returned COM pointer.</param>
		/// <returns>The HRESULT returned by the native call indicating success or failure.</returns>
		[LibraryImport(PropSys)]
		internal static partial int PSGetPropertyDescription(
			PropertyKey propkey,
			ref Guid riid,
			out nint ppv);
	}
}
