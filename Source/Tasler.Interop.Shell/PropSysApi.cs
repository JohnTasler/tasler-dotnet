using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;
using Tasler.Interop.Shell.PropertyStore;

namespace Tasler.Interop.Shell;

public static partial class PropSysApi
{
	public static partial class NativeMethods
	{
		private const string PropSys = "propsys.dll";

		/// <summary>
		/// Looks up a per-machine registered file property handler.
		/// </summary>
		/// <param name="pszFilePath"></param>
		/// <param name="pclsid"></param>
		/// <returns></returns>
		[LibraryImport(PropSys, StringMarshalling = StringMarshalling.Utf16)]
		internal static partial HRESULT PSLookupPropertyHandlerCLSID(nint pszFilePath, out Guid pclsid);

		/// <summary>
		/// Get a property handler, on Vista or downlevel to XP
		/// </summary>
		/// <param name="punkItem">The <see cref="IShellItem"/> for which to get the property handler.</param>
		/// <param name="fReadWrite"></param>
		/// <param name="riid"></param>
		/// <param name="ppv">Upon success, an <see cref="IPropertyStore"/> for the item.</param>
		/// <returns></returns>
		// punkItem is a shell item created with an SHCreateItemXXX API
		// Returns an IPropertyStore
		[LibraryImport(PropSys)]
		internal static partial HRESULT PSGetItemPropertyHandler(
			IShellItem punkItem,
			[MarshalAs(UnmanagedType.Bool)] bool fReadWrite,
			ref Guid riid,
			out IPropertyStore ppv);

		/// <summary>
		/// Retrieves the canonical name associated with a PropertyKey.
		/// </summary>
		/// <param name="propkey">The property key to query.</param>
		/// <returns>Returns a SafeCoTaskMemString that wraps the canonical name returned by the native API.</returns>
		/// <exception cref="COMException">In case of COM failure code.</exception>
		[LibraryImport(PropSys)]
		internal static partial int PSGetNameFromPropertyKey(ref PropertyKey propkey, out SafeCoTaskMemString name);

		/// <summary>
		/// Retrieves a property description object for the specified property key using the requested interface IID.
		/// </summary>
		/// <param name="propkey">The property key identifying the property whose description is requested.</param>
		/// <param name="riid">The IID of the interface being requested; identifies the interface returned in <paramref name="ppv"/>.</param>
		/// <param name="ppv">Receives a pointer to the requested interface on success; the caller is responsible for releasing the returned COM pointer.</param>
		/// <returns>The HRESULT returned by the native call indicating success or failure.</returns>
		[LibraryImport(PropSys)]
		internal static partial int PSGetPropertyDescription(
			ref PropertyKey propkey,
			ref Guid riid,
			out nint ppv);

		/// <summary>
		/// Creates an in-memory property store.
		/// </summary>
		/// <param name="riid"></param>
		/// <param name="ppv">Upon success, contains an IPropertyStore, IPersistSerializedPropStorage, or related interface.</param>
		/// <returns>The HRESULT returned by the native call indicating success or failure.</returns>
		[LibraryImport(PropSys)]
		internal static partial int PSCreateMemoryPropertyStore(
			ref Guid riid,
			out IUnknown ppv);

	}
}
