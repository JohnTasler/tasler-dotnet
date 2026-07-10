using System.Runtime.InteropServices;
using Tasler.Interop.Extensions;
using Tasler.Interop.Shell.PropertyStore;

namespace Tasler.Interop.Shell;

public static partial class PropSysApi
{
	public static Guid PSLookupPropertyHandlerCLSID(string pszFilePath)
	{
		using var filePath = new SafeCoTaskMemString() { Handle = Marshal.StringToCoTaskMemUni(pszFilePath) };
		NativeMethods.PSLookupPropertyHandlerCLSID(filePath.Handle, out var clsid).ThrowIfFailed();
		return clsid;
	}

	public static IPropertyStore GetItemPropertyHandler(this IShellItem item, bool fReadWrite)
	{
		Guid riid = typeof(IPropertyStore).GUID;
		NativeMethods.PSGetItemPropertyHandler(item, fReadWrite, ref riid, out var propertyStore).ThrowIfFailed();
		return propertyStore;
	}

	/// <summary>
	/// Gets the canonical name associated with the specified property key.
	/// </summary>
	/// <param name="propkey">The property key whose canonical name to retrieve.</param>
	/// <returns>The canonical property name, or an empty string if no name is available.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown when the native API returns a failing HRESULT.</exception>
	public static string GetNameFromPropertyKey(this PropertyKey propkey)
	{
		Marshal.ThrowExceptionForHR(NativeMethods.PSGetNameFromPropertyKey(ref propkey, out var pszCanonicalName));
		using var name = pszCanonicalName;
		return pszCanonicalName.Value;
	}

	extension (PropertyKey @this)
	{
		public string Name => @this.GetNameFromPropertyKey();
	}
}
