using System.Runtime.InteropServices;
using System.Text;

namespace Tasler.Interop.Shell;

public static class ShellApi
{
	private const string Shell32 = "shell32.dll";

	[DllImport(Shell32, ExactSpelling = true, PreserveSig = false)]
	public static extern IShellFolder SHGetDesktopFolder();

	public static IShellFolder2 GetDesktopFolder()
	{
		return (IShellFolder2)SHGetDesktopFolder();
	}

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
	[DllImport(Shell32, ExactSpelling = true, PreserveSig = false)]
	public static extern object SHCreateItemFromIDList(
		ItemIdList pidl,
		ref Guid iid);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)]
	[DllImport(Shell32, ExactSpelling = true, PreserveSig = false)]
	public static extern object SHCreateItemWithParent(
		ItemIdList parentItemIdList,
		IShellFolder parentShellFolder,
		ChildItemIdList childItemIdList,
		ref Guid riid);

	[DllImport(Shell32, ExactSpelling = true, PreserveSig = false)]
	public static extern ItemIdList SHGetIDListFromObject(
		[MarshalAs(UnmanagedType.IUnknown)]
		object punk);

	[return: MarshalAs(UnmanagedType.Bool)]
	[DllImport(Shell32, ExactSpelling = true)]
	public static extern bool ILIsEqual(
		ItemIdList pidl1,
		ItemIdList pidl2);

	[return: MarshalAs(UnmanagedType.Bool)]
	[DllImport(Shell32, ExactSpelling = true)]
	public static extern bool ILIsEqual(
		ItemIdList pidl1,
		ChildItemIdList pidl2);

	[return: MarshalAs(UnmanagedType.Bool)]
	[DllImport(Shell32, ExactSpelling = true)]
	public static extern bool ILIsEqual(
		ChildItemIdList pidl1,
		ItemIdList pidl2);

	[return: MarshalAs(UnmanagedType.Bool)]
	[DllImport(Shell32, ExactSpelling = true)]
	public static extern bool ILIsEqual(
		ChildItemIdList pidl1,
		ChildItemIdList pidl2);

	[return: MarshalAs(UnmanagedType.Bool)]
	[DllImport(Shell32, CharSet = CharSet.Auto)]
	public static extern bool SHGetPathFromIDListEx(
		ItemIdList pidl,
		StringBuilder pszPath,
		uint cchPath,
		GPFIDL uOpts);

	public static string GetFolderParseName(ItemIdList folderIdList)
	{
		ChildItemIdList folderInParentIdList;
		using (ItemIdList folderParentIdList = folderIdList.GetParentAndChild(out folderInParentIdList))
		using (folderInParentIdList)
		{
			Guid iid = typeof(IShellFolder).GUID;
			IShellFolder folderParent = (IShellFolder)ShellApi.GetDesktopFolder();
			if (!folderParentIdList.IsEmpty)
				folderParent = (IShellFolder)folderParent.BindToObject(folderParentIdList, null, ref iid);

			using StrRet strRet = folderParent.GetDisplayNameOf(folderInParentIdList, SHGDNF.ForParsing);
			return strRet.Value;
		}
	}


	[DllImport(Shell32, CharSet = CharSet.Auto, PreserveSig = false)]
	private static extern nint SHGetNameFromIDList(
			ItemIdList pidlAbsolute,
			SIGDN sigdnName);

	public static string GetNameFromIDList(ItemIdList pidlAbsolute, SIGDN sigdnName)
	{
		nint pszName = ShellApi.SHGetNameFromIDList(pidlAbsolute, sigdnName);
		string name = (pszName != nint.Zero) ? Marshal.PtrToStringAuto(pszName) : string.Empty;
		Marshal.FreeCoTaskMem(pszName);
		return name;
	}


	[DllImport(Shell32, CharSet = CharSet.Auto, PreserveSig = true)]
	public static extern int SHGetKnownFolderIDList(
		KnownFolderId rfid,
		KnownFolderFlags dwFlags,
		nint hToken,
		out ItemIdList ppidl);

	[DllImport(Shell32, CharSet = CharSet.Auto, PreserveSig = false)]
	public static extern ItemIdList SHGetKnownFolderIDList(
		KnownFolderId rfid,
		KnownFolderFlags dwFlags,
		nint hToken);

} // End: ShellApi

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

 // End: namespace
