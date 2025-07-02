using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

namespace Tasler.Interop.Shell;

public static partial class ShellApi
{
	public static IShellFolder2 GetDesktopFolder()
	{
		IShellFolder folder = null!;
		var hr = NativeMethods.SHGetDesktopFolder(out folder);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (IShellFolder2)folder;
	}

	public static TInterface CreateItemFromIDList<TInterface>(ItemIdList pidl)
	{
		var iid = typeof(TInterface).GUID;
		int hr = NativeMethods.SHCreateItemFromIDList(pidl, ref iid, out nint value);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (TInterface)ComApi.Wrappers.GetOrCreateObjectForComInstance(value, CreateObjectFlags.Unwrap);
	}

	public static TInterface CreateItemWithParent<TInterface>(
		ItemIdList parentItemIdList,
		IShellFolder parentShellFolder,
		ChildItemIdList childItemIdList)
	{
		var iid = typeof(TInterface).GUID;
		var hr = NativeMethods.SHCreateItemWithParent(parentItemIdList, parentShellFolder, childItemIdList, ref iid, out nint value);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (TInterface)ComApi.Wrappers.GetOrCreateObjectForComInstance(value, CreateObjectFlags.Unwrap);
	}

	public static string GetFolderParseName(ItemIdList folderIdList)
	{
		ChildItemIdList folderInParentIdList;
		using (ItemIdList folderParentIdList = folderIdList.GetParentAndChild(out folderInParentIdList))
		using (folderInParentIdList)
		{
			Guid iid = typeof(IShellFolder).GUID;
			IShellFolder folderParent = (IShellFolder)ShellApi.GetDesktopFolder();
			var folderParentPointer = folderParent.BindToObject(folderParentIdList, null, ref iid);
			if (!folderParentIdList.IsEmpty)
				ComApi.Wrappers.GetOrCreateObjectForComInstance(folderParentPointer, CreateObjectFlags.Unwrap);

			using StrRet strRet = folderParent.GetDisplayNameOf(folderInParentIdList, SHGDNF.ForParsing);
			return strRet.Value;
		}
	}

	public static string GetNameFromIDList(ItemIdList pidlAbsolute, SIGDN sigdnName)
	{
		int hr = NativeMethods.SHGetNameFromIDList(pidlAbsolute, sigdnName, out var name);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);
		return name?.Value ?? string.Empty;
	}

	[System.Diagnostics.CodeAnalysis.SuppressMessage("ComInterfaceGenerator", "SYSLIB1051:Specified type is not supported by source-generated COM", Justification = "It works")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("LibraryImportGenerator", "SYSLIB1052:Specified configuration is not supported by source-generated P/Invokes.", Justification = "<Pending>")]
	public static partial class NativeMethods
	{
		private const string Shell32 = "shell32.dll";

		[LibraryImport(Shell32)]
		public static partial int SHGetDesktopFolder(out IShellFolder shellFolder);

		[LibraryImport(Shell32)]
		public static partial int SHCreateItemFromIDList(ItemIdList pidl, ref Guid iid, out nint ppv);

		[LibraryImport(Shell32)]
		public static partial int SHCreateItemWithParent(
			ItemIdList parentItemIdList,
			IShellFolder parentShellFolder,
			ChildItemIdList childItemIdList,
			ref Guid riid,
			out nint ppv);

		[LibraryImport(Shell32)]
		public static partial int SHGetIDListFromObject(
			[MarshalAs(UnmanagedType.IUnknown)] object punk,
			out ItemIdList piidList);

		[LibraryImport(Shell32)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ILIsEqual(
			ItemIdList pidl1,
			ItemIdList pidl2);

		[LibraryImport(Shell32)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ILIsEqual(
			ItemIdList pidl1,
			ChildItemIdList pidl2);

		[LibraryImport(Shell32)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ILIsEqual(
			ChildItemIdList pidl1,
			ItemIdList pidl2);

		[LibraryImport(Shell32)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ILIsEqual(
			ChildItemIdList pidl1,
			ChildItemIdList pidl2);

		[LibraryImport(Shell32)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool SHGetPathFromIDListEx(
			ItemIdList pidl,
			[MarshalUsing(CountElementName = nameof(cchPath))][Out] char[] pszPath,
			uint cchPath,
			GPFIDL uOpts);

		[LibraryImport(Shell32)]
		public static partial int SHGetNameFromIDList(
			ItemIdList pidlAbsolute,
			SIGDN sigdnName,
			out SafeCoTaskMemString ppszName);

		[LibraryImport(Shell32)]
		public static partial int SHGetKnownFolderIDList(
			KnownFolderId rfid,
			KnownFolderFlags dwFlags,
			nint hToken,
			out ItemIdList ppidl);
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
