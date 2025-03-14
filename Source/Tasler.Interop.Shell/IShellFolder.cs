using System.Collections;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Tasler.Interop.Shell;

/// <summary>
/// Defines the values used with the <see cref="IShellFolder.GetDisplayNameOf"/> and <see cref="IShellFolder.SetNameOf"/>
/// methods to specify the type of file or folder names used by those methods.
/// </summary>
[Flags]
public enum SHGDNF
{
	/// <summary>
	/// The full name relative to the desktop, not relative to a specific folder. This name is used for generic display.
	/// </summary>
	Normal = 0,

	/// <summary>
	/// The name is relative to the folder from which the request was made. The result, though not the underlying
	/// value (0x0001), is equivalent to <see cref="Normal"/> or null. Use in combinations with <see cref="ForParsing" />
	/// and <see cref="ForEditing"/>.
	/// </summary>
	InFolder = 0x1,

	/// <summary>
	/// The name is used for in-place editing when the user renames the item.
	/// </summary>
	ForEditing = 0x1000,

	/// <summary>
	/// The name is displayed in an address bar combo box.
	/// </summary>
	ForAddressBar = 0x4000,

	/// <summary>
	/// The name is used for parsing. That is, it can be passed to <see cref="IShellFolder.ParseDisplayName"/> to recover
	/// the object's pointer to an item identifier list (PIDL). The form this name takes depends on the particular object.
	/// When <see cref="ForParsing"/> is used alone, the name is relative to the desktop.
	/// When combined with <see cref="InFolder"/>, the name is relative to the folder from which the request was made.
	/// </summary>
	ForParsing = 0x8000
}

[Flags]
public enum SHCONTF
{
	Folders = 0x0020,
	NonFolders = 0x0040,
	IncludeHidden = 0x0080,
	InitOnFirstNext = 0x0100,
	NetPrinterSearch = 0x0200,
	Shareable = 0x0400,
	Storage = 0x0800,
	FastItems = 0x2000,
	FlatList = 0x4000,
	EnableAsync = 0x8000
}

[Flags]
public enum SHCOLSTATEF : uint
{
	TypeStr = 0x1,
	TypeInt = 0x2,
	TypeDate = 0x3,
	TypeMask = 0xf,
	OnByDefault = 0x10,
	Slow = 0x20,
	Extended = 0x40,
	SecondaryUi = 0x80,
	Hidden = 0x100,
	PreferVarCmp = 0x200,
	PreferFmtCmp = 0x400,
	NoSortByFolderness = 0x800,
	ViewOnly = 0x10000,
	BatchRead = 0x20000,
	NoGroupBy = 0x40000,
	FixedWidth = 0x1000,
	NoDpiScale = 0x2000,
	FixedRatio = 0x4000,
	DisplayMask = 0xf000
}

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("000214E6-0000-0000-C000-000000000046")]
public interface IShellFolder
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ParseDisplayName(
		IntPtr hwnd,
		IBindCtx pbc,
		[MarshalAs(UnmanagedType.LPWStr)]
		string pszDisplayName,
		out uint pchEaten,
		out ItemIdList ppidl, // IntPtr
		ref SFGAOF pdwAttributes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	IEnumIDList EnumObjects(
		IntPtr hwnd,
		SHCONTF grfFlags);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	object BindToObject(
		ItemIdList pidl,
		IBindCtx? pbc,
		ref Guid riid);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	object BindToStorage(
		ItemIdList pidl,
		IBindCtx? pbc,
		ref Guid riid);

	[PreserveSig]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	int CompareIDs(
		IntPtr lParam,
		ItemIdList pidl1,
		ItemIdList pidl2);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	object CreateViewObject(
		IntPtr hwndOwner,
		ref Guid riid);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetAttributesOf(
		uint cidl,
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
		ChildItemIdList[] apidl,
		ref SFGAOF rgfInOut);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	object GetUIObjectOf(
		IntPtr hwndOwner,
		uint cidl,
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
		ItemIdList[] apidl,
		ref Guid riid,
		IntPtr rgfReserved);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	StrRet GetDisplayNameOf(
		ChildItemIdList pidl,
		SHGDNF uFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	IntPtr SetNameOf(
		IntPtr hwnd,
		ChildItemIdList pidl,
		[MarshalAs(UnmanagedType.LPWStr)]
		string pszName,
		SHGDNF uFlags);
}

[ComImport]
[Guid("93F2F68C-1D1B-11d3-A30E-00C04F79ABD1")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IShellFolder2
{
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void ParseDisplayName(
		IntPtr hwnd,
		IBindCtx? pbc,
		[MarshalAs(UnmanagedType.LPWStr)]
		string pszDisplayName,
		out uint pchEaten,
		out ItemIdList ppidl, // IntPtr
		ref SFGAOF pdwAttributes);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	IEnumIDList EnumObjects(
		IntPtr hwnd,
		SHCONTF grfFlags);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	object BindToObject(
		ItemIdList pidl,
		IBindCtx? pbc,
		ref Guid riid);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	object BindToStorage(
		ItemIdList pidl,
		IBindCtx? pbc,
		ref Guid riid);

	[PreserveSig]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	int CompareIDs(
		IntPtr lParam,
		ItemIdList pidl1,
		ItemIdList pidl2);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	object CreateViewObject(
		IntPtr hwndOwner,
		ref Guid riid);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void GetAttributesOf(
		uint cidl,
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
		ChildItemIdList[] apidl,
		ref SFGAOF rgfInOut);

	[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	object GetUIObjectOf(
		IntPtr hwndOwner,
		uint cidl,
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]
		ChildItemIdList[] apidl,
		ref Guid riid,
		IntPtr rgfReserved);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	StrRet GetDisplayNameOf(
		ChildItemIdList pidl,
		SHGDNF uFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	IntPtr SetNameOf(
		IntPtr hwnd,
		ChildItemIdList pidl,
		[MarshalAs(UnmanagedType.LPWStr)]
		string pszName,
		SHGDNF uFlags);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	Guid GetDefaultSearchGUID();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	IEnumExtraSearch EnumSearches();

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	uint GetDefaultColumn(
			uint dwRes,
			out uint pSort);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	SHCOLSTATEF GetDefaultColumnState(
			uint iColumn);

	[return: MarshalAs(UnmanagedType.Struct)]
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	object GetDetailsEx(
		ChildItemIdList pidl,
		PropertyKey pscid);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	SHELLDETAILS GetDetailsOf(
		ChildItemIdList pidl,
		uint iColumn);

	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	PropertyKey MapColumnToSCID(
		uint iColumn);
}


/// <summary>
/// Structure for returning strings from <see cref="IShellFolder2.GetDetailsOf"/>.
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SHELLDETAILS
{
	/// <summary>LVCFMT_* value (header only).</summary>
	public LVCFMT fmt;

	/// <summary>Number of 'average' characters (header only).</summary>
	public int cxChar;

	/// <summary>String information.</summary>
	public StrRet str;
}

[Flags]
public enum LVCFMT : uint
{
	/// <summary>Same as HDF_LEFT</summary>
	Left = 0x0000,
	/// <summary>Same as HDF_RIGHT</summary>
	Right = 0x0001,
	/// <summary>Same as HDF_CENTER</summary>
	Center = 0x0002,
	/// <summary>Same as HDF_JUSTIFYMASK</summary>
	JustifyMask = 0x0003,

	/// <summary>Same as HDF_IMAGE</summary>
	Image = 0x0800,
	/// <summary>Same as HDF_BITMAP_ON_RIGHT</summary>
	BitmapOnRight = 0x1000,
	/// <summary>Same as HDF_OWNERDRAW</summary>
	ColHasImages = 0x8000,

	/// <summary>Can't resize the column; same as HDF_FIXEDWIDTH</summary>
	FixedWidth = 0x00100,
	/// <summary>If not set, CCM_DPISCALE will govern scaling up fixed width</summary>
	NoDpiScale = 0x40000,
	/// <summary>Width will augment with the row height</summary>
	FixedRatio = 0x80000,

	/// <summary>Move to the top of the next list of columns</summary>
	LineBreak = 0x100000,
	/// <summary>Fill the remainder of the tile area. Might have a title.</summary>
	Fill = 0x200000,
	/// <summary>This sub-item can be wrapped.</summary>
	Wrap = 0x400000,
	/// <summary>This sub-item doesn't have an title.</summary>
	NoTitle = 0x800000,

	TilePlacementMask = (LVCFMT.LineBreak | LVCFMT.Fill),

	/// <summary>Column is a split button; same as HDF_SPLITBUTTON</summary>
	SplitButton = 0x1000000,
}

[ComImport]
[Guid("000214F2-0000-0000-C000-000000000046")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IEnumIDList
{
	/// <param name="celt"></param>
	/// <param name="rgelt"></param>
	/// <param name="pceltFetched"></param>
	[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	int Next(
		[In] uint celt,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
		IntPtr[] rgelt,
		out uint pceltFetched);

	/// <param name="celt"></param>
	[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	int Skip(
		[In] uint celt);

	[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	int Reset();

	/// <param name="ppEnum"></param>
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Clone(
		[MarshalAs(UnmanagedType.Interface)]
		out IEnumIDList ppEnum);
}

public class EnumIdList : IEnumerable<ChildItemIdList>
{
	#region Static Fields
	[ThreadStatic]
	private static IntPtr[] _items = new IntPtr[512];
	#endregion Static Fields

	#region Instance Fields
	private IEnumIDList _enumIdList;
	#endregion Instance Fields

	#region Construction
	public EnumIdList(IEnumIDList enumIdList)
	{
		_enumIdList = enumIdList;
	}
	#endregion Construction

	#region IEnumerable<ChildItemIdList> Members
	public IEnumerator<ChildItemIdList> GetEnumerator()
	{
		int hr = 0;
		do
		{
			uint fetched;
			hr = _enumIdList.Next((uint)EnumIdList._items.Length, _items, out fetched);
			if (hr == 0 || hr == 1)
			{
				for (int index = 0; index < fetched; ++index)
				{
					ChildItemIdList childItem = new ChildItemIdList(EnumIdList._items[index]);
					yield return childItem;
				}
			}
			else
			{
				throw Marshal.GetExceptionForHR(hr);
			}

		} while (hr == 0);
	}
	#endregion IEnumerable<ChildItemIdList> Members

	#region IEnumerable Members
	IEnumerator IEnumerable.GetEnumerator()
	{
		return this.GetEnumerator();
	}
	#endregion IEnumerable Members
}


[ComImport]
[Guid("0E700BE1-9DB6-11d1-A1CE-00C04FD75D13")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface IEnumExtraSearch
{
	/// <param name="celt"></param>
	/// <param name="rgelt"></param>
	/// <param name="pceltFetched"></param>
	[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	int Next(
		[In] uint celt,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)]
		EXTRASEARCH[] rgelt,
		out uint pceltFetched);

	/// <param name="celt"></param>
	[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	int Skip(
		[In] uint celt);

	[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	int Reset();

	/// <param name="ppEnum"></param>
	[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
	void Clone(
		[MarshalAs(UnmanagedType.Interface)]
		out IEnumExtraSearch ppEnum);
}

[StructLayout(LayoutKind.Sequential)]
public struct EXTRASEARCH
{
	public Guid guidSearch;

	[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPWStr, SizeConst = 80)]
	public string wszFriendlyName;

	[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.LPWStr, SizeConst = 2084)]
	public string wszUrl;
}

[Flags]
public enum SFGAOF : uint
{
	None = 0x00000000,
	/// <summary>Objects can be copied (DROPEFFECT_COPY)</summary>
	CanCopy = 0x00000001,
	/// <summary>Objects can be moved (DROPEFFECT_MOVE)</summary>
	CanMove = 0x00000002,
	/// <summary>Objects can be linked (DROPEFFECT_LINK)</summary>
	CanLink = 0x00000008,
	/// <summary>supports BindToObject(IID_IStorage)</summary>
	Storage = 0x00000008,
	/// <summary>Objects can be renamed</summary>
	CanRename = 0x00000010,
	/// <summary>Objects can be deleted</summary>
	CanDelete = 0x00000020,
	/// <summary>Objects have property sheets</summary>
	HasPropSheet = 0x00000040,
	/// <summary>Objects are drop target</summary>
	DropTarget = 0x00000100,
	/// <summary></summary>
	CapabilityMask = 0x00000177,
	/// <summary>Object is encrypted (use alt color)</summary>
	Encrypted = 0x00002000,
	/// <summary>'Slow' object</summary>
	IsSlow = 0x00004000,
	/// <summary>Ghosted icon</summary>
	Ghosted = 0x00008000,
	/// <summary>Shortcut (link)</summary>
	Link = 0x00010000,
	/// <summary>Shared</summary>
	Share = 0x00020000,
	/// <summary>Read-only</summary>
	ReadOnly = 0x00040000,
	/// <summary>Hidden object</summary>
	Hidden = 0x00080000,
	/// <summary></summary>
	DisplayAttrMask = 0x000FC000,
	/// <summary>May contain children with SFGAO_FILESYSTEM</summary>
	FileSysAncestor = 0x10000000,
	/// <summary>Support BindToObject(IID_IShellFolder)</summary>
	Folder = 0x20000000,
	/// <summary>Is a win32 file system object (file/folder/root)</summary>
	FileSystem = 0x40000000,
	/// <summary>May contain children with SFGAO_FOLDER (may be slow)</summary>
	HasSubfolder = 0x80000000,
	/// <summary></summary>
	ContentsMask = 0x80000000,
	/// <summary>Invalidate cached information (may be slow)</summary>
	Validate = 0x01000000,
	/// <summary>Is this removeable media?</summary>
	Removable = 0x02000000,
	/// <summary>Object is compressed (use alt color)</summary>
	Compressed = 0x04000000,
	/// <summary>Supports IShellFolder, but only implements CreateViewObject() (non-folder view)</summary>
	Browsable = 0x08000000,
	/// <summary>Is a non-enumerated object (should be hidden)</summary>
	NonEnumerated = 0x00100000,
	/// <summary>Should show bold in explorer tree</summary>
	NewContent = 0x00200000,
	/// <summary>Obsolete</summary>
	CanMoniker = 0x00400000,
	/// <summary>Obsolete</summary>
	HasStorage = 0x00400000,
	/// <summary>Supports BindToObject(IID_IStream)</summary>
	Stream = 0x00400000,
	/// <summary>May contain children with SFGAO_STORAGE or SFGAO_STREAM</summary>
	StorageAncestor = 0x00800000,
	/// <summary>For determining storage capabilities, ie for open/save semantics</summary>
	StorageCapMask = 0x70C50008,
	/// <summary>Attributes that are masked out for PKEY_SFGAOFlags because they are considered to cause slow calculations or lack context (SFGAO_VALIDATE | SFGAO_ISSLOW | SFGAO_HASSUBFOLDER and others)</summary>
	PkeySFGAOMask = 0x81044010,
}
