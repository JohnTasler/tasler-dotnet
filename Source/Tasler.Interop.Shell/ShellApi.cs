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
		int hr = NativeMethods.SHCreateItemFromIDList(pidl.Handle, ref iid, out nint value);
		if (hr < 0)
			Marshal.ThrowExceptionForHR(hr);

		return (TInterface)ComApi.Wrappers.GetOrCreateObjectForComInstance(value, CreateObjectFlags.Unwrap);
	}

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

		[LibraryImport(Shell32)]
		public static partial int SHGetDesktopFolder(out IShellFolder shellFolder);

		[LibraryImport(Shell32)]
		public static partial int SHCreateItemFromIDList(nint pidl, ref Guid iid, out nint ppv);

		[LibraryImport(Shell32)]
		public static partial int SHCreateItemWithParent(
			nint parentItemIdList,
			IShellFolder parentShellFolder,
			nint childItemIdList,
			ref Guid riid,
			out IShellItem ppv);

		[LibraryImport(Shell32)]
		public static partial int SHGetIDListFromObject(nint punk, out nint piidList);

		[LibraryImport(Shell32)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool ILIsEqual(nint pidl1, nint pidl2);

		[LibraryImport(Shell32)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static partial bool SHGetPathFromIDListEx(
			nint pidl,
			[MarshalUsing(CountElementName = nameof(cchPath))][Out] char[] pszPath,
			uint cchPath,
			GPFIDL uOpts);

		[LibraryImport(Shell32)]
		public static partial int SHGetNameFromIDList(nint pidlAbsolute, SIGDN sigdnName, out nint ppszName);

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
