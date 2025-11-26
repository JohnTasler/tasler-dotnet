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

[Guid("000214E6-0000-0000-C000-000000000046")]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IShellFolder
{
	/// <summary>
		/// Parses a display name and returns the item identifier list (PIDL) and the number of characters consumed from the input.
		/// </summary>
		/// <param name="hwnd">Window handle used as the owner for any UI shown during parsing.</param>
		/// <param name="pbc">Bind context used during parsing; may supply additional bind-time information.</param>
		/// <param name="pszDisplayName">The display name to parse into a PIDL.</param>
		/// <param name="pchEaten">Receives the number of characters from <paramref name="pszDisplayName"/> that were parsed.</param>
		/// <param name="ppidl">Receives a pointer to the resulting PIDL for the parsed name.</param>
		/// <param name="pdwAttributes">On input, specifies which attributes are requested; on output, receives the retrieved SFGAOF attribute flags.</param>
		void ParseDisplayName(
		nint hwnd,
		IBindCtx pbc,
		string pszDisplayName,
		out uint pchEaten,
		out nint ppidl,
		ref SFGAOF pdwAttributes);

	/// <summary>
/// Enumerates the items contained in the folder using the specified enumeration flags.
/// </summary>
/// <param name="hwnd">Window handle that can be used for any UI prompts; may be zero if no UI is required.</param>
/// <param name="grfFlags">Flags that control which items are included and how enumeration is performed.</param>
/// <returns>An <see cref="IEnumIDList"/> that yields item identifier lists (PIDLs) for the folder's contents.</returns>
IEnumIDList EnumObjects(nint hwnd, SHCONTF grfFlags);

	/// <summary>
/// Binds to the object or subobject identified by the specified PIDL and provides a pointer to the requested interface.
/// </summary>
/// <param name="pidl">A pointer to an item identifier list (PIDL) that identifies the object or subobject to bind to.</param>
/// <param name="pbc">An optional bind context (IBindCtx) used during the bind operation; may be null.</param>
/// <param name="riid">The GUID of the interface being requested; on success the returned pointer implements this interface.</param>
/// <returns>A pointer to the requested COM interface for the bound object, or zero if the bind fails.</returns>
nint BindToObject(nint pidl, IBindCtx? pbc, ref Guid riid);

	/// <summary>
/// Obtains a pointer to the storage interface for the item specified by a PIDL relative to this folder.
/// </summary>
/// <param name="pidl">A pointer to the item identifier list (PIDL) that identifies the item relative to this folder.</param>
/// <param name="pbc">An optional bind context used during the bind operation; may be null.</param>
/// <param name="riid">The GUID of the interface requested on the item's storage.</param>
/// <returns>A pointer to the requested interface for the item's storage, or zero if the interface is not available.</returns>
nint BindToStorage(nint pidl, IBindCtx? pbc, ref Guid riid);

	/// <summary>
	/// Compares two item identifier lists (PIDLs) relative to this folder.
	/// </summary>
	/// <param name="lParam">Comparison hint whose interpretation is defined by the folder.</param>
	/// <param name="pidl1">Pointer to the first item's PIDL.</param>
	/// <param name="pidl2">Pointer to the second item's PIDL.</param>
	/// <returns>
	/// A signed HRESULT-style comparison value: negative if <paramref name="pidl1"/> precedes <paramref name="pidl2"/>, zero if they are equal, positive if <paramref name="pidl1"/> follows <paramref name="pidl2"/>.
	/// </returns>
	[PreserveSig]
	int CompareIDs(nint lParam, nint pidl1, nint pidl2);

	/// <summary>
/// Creates and returns a view object for this folder suitable for the requested interface.
/// </summary>
/// <param name="hwndOwner">Handle to the window that will own any UI produced by the view object; may be zero.</param>
/// <param name="riid">The GUID of the interface being requested from the created view object.</param>
/// <returns>An unmanaged pointer to the requested interface, or zero if the view object could not be created.</returns>
nint CreateViewObject(nint hwndOwner, ref Guid riid);

	/// <summary>
		/// Retrieves the specified attributes for a set of item identifier lists (PIDLs) and updates the attribute mask.
		/// </summary>
		/// <param name="cidl">The number of item identifier lists in <paramref name="apidl"/>.</param>
		/// <param name="apidl">An array of PIDLs whose attributes are to be queried; length must be <paramref name="cidl"/>.</param>
		/// <param name="rgfInOut">
		/// On input, a mask specifying which attributes to retrieve; on output, the mask is updated with the attributes that apply to the specified items.
		/// </param>
		void GetAttributesOf(
		uint cidl,
		[MarshalUsing(CountElementName = nameof(cidl))]
		nint[] apidl,
		ref SFGAOF rgfInOut);

	/// <summary>
		/// Retrieves a COM UI object for one or more items within this folder.
		/// </summary>
		/// <param name="hwndOwner">Handle to the owner window for any UI that may be displayed; may be zero.</param>
		/// <param name="cidl">The number of item identifier lists in <paramref name="apidl"/>.</param>
		/// <param name="apidl">An array of item identifier lists (PIDLs) that identify the items, relative to this folder.</param>
		/// <param name="riid">The interface identifier (IID) of the requested COM interface.</param>
		/// <param name="rgfReserved">Reserved; must be zero.</param>
		/// <returns>A pointer to the requested COM interface for the specified items (an interface pointer cast to <see cref="nint"/>).</returns>
		nint GetUIObjectOf(
		nint hwndOwner,
		uint cidl,
		[MarshalUsing(CountElementName = nameof(cidl))]
		nint[] apidl,
		ref Guid riid,
		nint rgfReserved);

	/// <summary>
		/// Gets the display name for a shell item represented by a PIDL using the specified display-name flags.
		/// </summary>
		/// <param name="pidl">Pointer to the item identifier list (PIDL) that identifies the item within the folder.</param>
		/// <param name="uFlags">Flags specifying the form of the display name (for example, in-folder name, editing name, address-bar form, or parsing form).</param>
		/// <returns>A StrRet structure containing the requested display name for the item.</returns>
		StrRet GetDisplayNameOf(
		nint pidl,
		SHGDNF uFlags);

	/// <summary>
		/// Sets the display name of an item within the folder.
		/// </summary>
		/// <param name="hwnd">Window handle used as the owner for any UI shown during the operation; may be zero.</param>
		/// <param name="pidl">Pointer to the item's identifier (PIDL) relative to this folder.</param>
		/// <param name="pszName">The new name to assign to the item.</param>
		/// <param name="uFlags">Flags specifying the form/context for the name (see <see cref="SHGDNF"/>).</param>
		/// <returns>The item identifier list (PIDL) for the item after the name change, or zero if the operation did not produce a PIDL.</returns>
		nint SetNameOf(
		nint hwnd,
		nint pidl,
		string pszName,
		SHGDNF uFlags);
}