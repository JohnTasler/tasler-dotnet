using System.ComponentModel;
using System.Runtime.InteropServices;
using Tasler.Interop.Com;
using Tasler.Interop.Shell.Interfaces;
using Tasler.Interop.User;

namespace Tasler.Interop.Shell;

public static partial class ShellApi
{
	/// <summary>
	/// Obtain the system shell's desktop folder.
	/// </summary>
	/// <returns>The desktop shell folder exposed as an <see cref="IShellFolder2"/> instance.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown when the native SHGetDesktopFolder call fails; the HRESULT is converted to a managed exception.</exception>
	public static IShellFolder2 GetDesktopFolder()
	{
		IShellFolder folder = null!;
		var hr = NativeMethods.SHGetDesktopFolder(out folder);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (IShellFolder2)folder;
	}

	/// <summary>
	/// Creates a managed wrapper for the shell item identified by the specified PIDL and returns it as the requested interface type.
	/// </summary>
	/// <param name="pidl">The item ID list (PIDL) that identifies the shell item to create.</param>
	/// <typeparam name="TInterface">The COM interface type to cast the created shell item to.</typeparam>
	/// <returns>An instance of <typeparamref name="TInterface"/> representing the shell item identified by <paramref name="pidl"/>.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown when the underlying shell API returns a failure HRESULT.</exception>
	public static TInterface CreateItemFromIDList<TInterface>(ItemIdList pidl)
	{
		var iid = typeof(TInterface).GUID;
		int hr = NativeMethods.SHCreateItemFromIDList(pidl.Handle, ref iid, out nint value);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (TInterface)ComApi.Wrappers.GetOrCreateObjectForComInstance(value, CreateObjectFlags.Unwrap);
	}

	/// <summary>
	/// Creates an IShellItem of the requested interface for a child PIDL using the specified parent folder and parent PIDL.
	/// </summary>
	/// <param name="parentItemIdList">Absolute or parent PIDL that identifies the parent folder.</param>
	/// <param name="parentShellFolder">The parent IShellFolder to use when creating the child item.</param>
	/// <param name="childItemIdList">The child (relative) PIDL to create as an IShellItem under the parent.</param>
	/// <returns>An instance of <typeparamref name="TInterface"/> representing the created shell item.</returns>
	/// <exception cref="System.Exception">Thrown when the native SHCreateItemWithParent call returns a failing HRESULT; a corresponding COM exception is propagated.</exception>
	public static TInterface CreateItemWithParent<TInterface>(
		ItemIdList parentItemIdList,
		IShellFolder parentShellFolder,
		ChildItemIdList childItemIdList)
		where TInterface : IShellItem
	{
		var iid = typeof(TInterface).GUID;
		var hr = NativeMethods.SHCreateItemWithParent(parentItemIdList.Handle, parentShellFolder, childItemIdList.Handle, ref iid, out IShellItem value);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (TInterface)value;
	}

	/// <summary>
	/// Gets the parse-name (the parsing/display path used by the shell) for the folder identified by the given item ID list.
	/// </summary>
	/// <param name="folderIdList">A PIDL that identifies the folder whose parse-name to retrieve.</param>
	/// <returns>The parse-name for the specified folder, or <c>null</c> if no parse-name is available.</returns>
	public static string GetFolderParseName(ItemIdList folderIdList)
	{
		ChildItemIdList folderInParentIdList;
		using (ItemIdList folderParentIdList = folderIdList.GetParentAndChild(out folderInParentIdList))
		using (folderInParentIdList)
		{
			Guid iid = typeof(IShellFolder).GUID;
			IShellFolder folderParent = (IShellFolder)ShellApi.GetDesktopFolder();

			if (!folderParentIdList.IsEmpty)
			{
				var folderParentPointer = folderParent.BindToObject(folderParentIdList.Handle, null, ref iid);
				folderParent = (IShellFolder)ComApi.Wrappers.GetOrCreateObjectForComInstance(folderParentPointer, CreateObjectFlags.Unwrap);
			}

			using StrRet strRet = folderParent.GetDisplayNameOf(folderInParentIdList.Handle, SHGDNF.ForParsing);
			return strRet.Value ?? strRet.GetValue(folderInParentIdList);
		}
	}

	/// <summary>
	/// Retrieve the display name for the specified absolute PIDL using the given SIGDN format.
	/// </summary>
	/// <param name="pidlAbsolute">Absolute PIDL identifying the shell item.</param>
	/// <param name="sigdnName">The display name type to retrieve.</param>
	/// <returns>The display name for the specified PIDL.</returns>
	/// <exception cref="System.Runtime.InteropServices.COMException">Thrown when the underlying Shell API call fails.</exception>
	public static string GetNameFromIDList(ItemIdList pidlAbsolute, SIGDN sigdnName)
	{
		int hr = NativeMethods.SHGetNameFromIDList(pidlAbsolute.Handle, sigdnName, out var namePtr);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);
		using var name = new SafeCoTaskMemString { Handle = namePtr };
		return name.Value;
	}

	/// <summary>
	/// Uses ShellExecuteW to open the specified URI in the system's default web browser.
	/// </summary>
	/// <param name="uri">
	/// The URI to open. This must be an absolute URL using http, https, file, or mailto protocols.
	/// </param>
	public static void OpenUriInDefaultBrowser(string uri)
	{
		if (string.IsNullOrWhiteSpace(uri))
			throw new ArgumentException(Properties.Resources.ArgumentExceptionNonEmptyAbsoluteUriRequired, nameof(uri));

		if (!Uri.TryCreate(uri, UriKind.Absolute, out var parsedUri) ||
			(parsedUri.Scheme != Uri.UriSchemeHttp
			&& parsedUri.Scheme != Uri.UriSchemeHttps
			&& parsedUri.Scheme != Uri.UriSchemeFile
			&& parsedUri.Scheme != Uri.UriSchemeMailto))
		{
			throw new ArgumentException(Properties.Resources.ArgumentExceptionOnlySpecificAbsoluteUrisSupported, nameof(uri));
		}

		var result = NativeMethods.ShellExecuteW(SafeHwnd.Null, "open", uri, null, null, SW.ShowNormal);
		if (result <= 32)
			throw new Win32Exception();
	}

	public static IImageList SHGetImageList(SHIL iImageList)
	{
		var iid = typeof(IImageList).GUID;
		nint imageList;
		int hr = NativeMethods.SHGetImageList(iImageList, ref iid, out imageList);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (IImageList)ComApi.Wrappers.GetOrCreateObjectForComInstance(imageList, CreateObjectFlags.Unwrap);
	}
}
