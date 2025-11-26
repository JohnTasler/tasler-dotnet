using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

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
			var folderParentPointer = folderParent.BindToObject(folderParentIdList.Handle, null, ref iid);
			if (!folderParentIdList.IsEmpty)
				ComApi.Wrappers.GetOrCreateObjectForComInstance(folderParentPointer, CreateObjectFlags.Unwrap);

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
		return new SafeCoTaskMemString { Handle = namePtr }.Value;
	}

	//[System.Diagnostics.CodeAnalysis.SuppressMessage("ComInterfaceGenerator", "SYSLIB1051:Specified type is not supported by source-generated COM", Justification = "It works")]
	//[System.Diagnostics.CodeAnalysis.SuppressMessage("LibraryImportGenerator", "SYSLIB1052:Specified configuration is not supported by source-generated P/Invokes.", Justification = "<Pending>")]
	public static partial class NativeMethods
	{
		private const string Shell32 = "shell32.dll";

		/// <summary>
		/// Retrieves the desktop folder's COM IShellFolder interface.
		/// </summary>
		/// <param name="shellFolder">When successful, receives the desktop IShellFolder instance.</param>
		/// <returns>`HRESULT` indicating success or failure (`S_OK` on success, error code otherwise).</returns>
		[LibraryImport(Shell32)]
		public static partial int SHGetDesktopFolder(out IShellFolder shellFolder);

		/// <summary>
		/// Creates a Shell item COM object for the item identified by a PIDL and returns the requested interface pointer.
		/// </summary>
		/// <param name="pidl">A pointer to an absolute ITEMIDLIST that identifies the Shell item.</param>
		/// <param name="iid">The GUID of the interface requested on the created Shell item.</param>
		/// <param name="ppv">Receives a pointer to the requested interface on success.</param>
		/// <returns>An HRESULT value: a non-negative value indicates success; a negative value indicates failure.</returns>
		[LibraryImport(Shell32)]
		public static partial int SHCreateItemFromIDList(nint pidl, ref Guid iid, out nint ppv);

		/// <summary>
			/// Creates a shell item object for a child item using an optional parent PIDL or parent IShellFolder.
			/// </summary>
			/// <param name="parentItemIdList">Pointer to the parent item's PIDL, or <c>0</c> if not used.</param>
			/// <param name="parentShellFolder">Optional parent <see cref="IShellFolder"/> COM interface, or <c>null</c> if not used.</param>
			/// <param name="childItemIdList">Pointer to the child item's PIDL relative to the parent, or an absolute PIDL if no parent is supplied.</param>
			/// <param name="riid">Reference to the IID of the interface requested on the created item.</param>
			/// <param name="ppv">Receives the created item as an <see cref="IShellItem"/> instance when the call succeeds.</param>
			/// <returns>HRESULT value: <c>S_OK</c> on success, otherwise a COM error code.</returns>
			[LibraryImport(Shell32)]
		public static partial int SHCreateItemWithParent(
			nint parentItemIdList,
			IShellFolder parentShellFolder,
			nint childItemIdList,
			ref Guid riid,
			out IShellItem ppv);

		/// <summary>
		/// Retrieves an item identifier list (PIDL) for the Shell item represented by the specified COM object pointer.
		/// </summary>
		/// <param name="punk">A pointer to a COM object (IUnknown*) that represents the Shell item.</param>
		/// <param name="piidList">When successful, receives a pointer to the PIDL. The returned PIDL is allocated with COM task memory and must be freed by the caller (for example, with Marshal.FreeCoTaskMem).</param>
		/// <returns>The HRESULT returned by the native SHGetIDListFromObject call.</returns>
		[LibraryImport(Shell32)]
		public static partial int SHGetIDListFromObject(nint punk, out nint piidList);

		/// <summary>
		/// Determines whether two PIDLs refer to the same shell item.
		/// </summary>
		/// <param name="pidl1">Pointer to the first ITEMIDLIST (PIDL) to compare.</param>
		/// <param name="pidl2">Pointer to the second ITEMIDLIST (PIDL) to compare.</param>
		/// <returns>`true` if the two PIDLs refer to the same item, `false` otherwise.</returns>
		[LibraryImport(Shell32)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ILIsEqual(nint pidl1, nint pidl2);

		/// <summary>
			/// Retrieves a file-system path for the specified PIDL and writes the null-terminated path into the provided character buffer.
			/// </summary>
			/// <param name="pidl">A pointer to an item identifier list (PIDL) that identifies the item.</param>
			/// <param name="pszPath">A character array that receives the null-terminated path string; must have room for <paramref name="cchPath"/> characters.</param>
			/// <param name="cchPath">The size of <paramref name="pszPath"/> in characters.</param>
			/// <param name="uOpts">Flags that control path extraction behavior.</param>
			/// <returns>`true` if a path was written to <paramref name="pszPath"/>, `false` otherwise.</returns>
			[LibraryImport(Shell32)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool SHGetPathFromIDListEx(
			nint pidl,
			[MarshalUsing(CountElementName = nameof(cchPath))][Out] char[] pszPath,
			uint cchPath,
			GPFIDL uOpts);

		/// <summary>
		/// Retrieves a display name for the shell item identified by an absolute PIDL.
		/// </summary>
		/// <param name="pidlAbsolute">An absolute item identifier list (PIDL) that identifies the shell item.</param>
		/// <param name="sigdnName">Specifies the type of display name to retrieve (a SIGDN value).</param>
		/// <param name="ppszName">On success, receives a pointer to a string (allocated with CoTaskMem) containing the requested display name; caller must free it with Marshal.FreeCoTaskMem or CoTaskMemFree.</param>
		/// <returns>An HRESULT value: `0` (S_OK) on success; a negative value indicates failure.</returns>
		[LibraryImport(Shell32)]
		public static partial int SHGetNameFromIDList(nint pidlAbsolute, SIGDN sigdnName, out nint ppszName);

		/// <summary>
			/// Retrieves an ITEMIDLIST (PIDL) that identifies a known folder specified by its known-folder ID.
			/// </summary>
			/// <param name="rfid">The identifier (KNOWNFOLDERID) of the known folder to retrieve.</param>
			/// <param name="dwFlags">Flags that control retrieval behavior.</param>
			/// <param name="hToken">An access token that represents a particular user, or zero to use the current user.</param>
			/// <param name="ppidl">When the method returns successfully, receives a pointer to the allocated PIDL for the known folder; the caller must free this with CoTaskMemFree.</param>
			/// <returns>An HRESULT value indicating success or failure. On success, `ppidl` contains the allocated PIDL for the requested known folder.</returns>
			[LibraryImport(Shell32)]
		public static partial int SHGetKnownFolderIDList(
			KnownFolderId rfid,
			KnownFolderFlags dwFlags,
			nint hToken,
			out nint ppidl);
	}
}

[Flags]
public enum GPFIDL
{
	/// <summary>Normal Win32 file name, servers and drive roots included.</summary>
	Default = 0x0000,

	/// <summary>Short file name.</summary>
	AltName = 0x0001,

	/// <summary>Include UNC printer names too (non file system item).</summary>
	UncPrinter = 0x0002,
}