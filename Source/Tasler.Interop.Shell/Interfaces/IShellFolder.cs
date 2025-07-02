using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

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
	Folders          = 0x0020,
	NonFolders       = 0x0040,
	IncludeHidden    = 0x0080,
	InitOnFirstNext  = 0x0100,
	NetPrinterSearch = 0x0200,
	Shareable        = 0x0400,
	Storage          = 0x0800,
	FastItems        = 0x2000,
	FlatList         = 0x4000,
	EnableAsync      = 0x8000
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

[System.Diagnostics.CodeAnalysis.SuppressMessage("ComInterfaceGenerator", "SYSLIB1051:Specified type is not supported by source-generated COM", Justification = "It works")]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("000214E6-0000-0000-C000-000000000046")]
public partial interface IShellFolder
{
	void ParseDisplayName(
		nint hwnd,
		IBindCtx pbc,
		string pszDisplayName,
		out uint pchEaten,
		out ItemIdList ppidl, // nint
		ref SFGAOF pdwAttributes);

	IEnumIDList EnumObjects(nint hwnd, SHCONTF grfFlags);

	nint BindToObject(
		ItemIdList pidl,
		IBindCtx? pbc,
		ref Guid riid);

	nint BindToStorage(
		ItemIdList pidl,
		IBindCtx? pbc,
		ref Guid riid);

	[PreserveSig]
	int CompareIDs(
		nint lParam,
		ItemIdList pidl1,
		ItemIdList pidl2);

	nint CreateViewObject(
		nint hwndOwner,
		ref Guid riid);

	void GetAttributesOf(
		uint cidl,
		[MarshalUsing(CountElementName = nameof(cidl))]
		ChildItemIdList[] apidl,
		ref SFGAOF rgfInOut);

	nint GetUIObjectOf(
		nint hwndOwner,
		uint cidl,
		[MarshalUsing(CountElementName = nameof(cidl))]
		ItemIdList[] apidl,
		ref Guid riid,
		nint rgfReserved);

	StrRet GetDisplayNameOf(
		ChildItemIdList pidl,
		SHGDNF uFlags);

	ChildItemIdList SetNameOf(
		nint hwnd,
		ChildItemIdList pidl,
		string pszName,
		SHGDNF uFlags);
}
