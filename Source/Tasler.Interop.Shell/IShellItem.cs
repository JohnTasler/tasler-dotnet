using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Tasler.Interop.Shell
{
	[ComImport]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
	public interface IShellItem
	{
		[return: MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		object BindToHandler(
			IBindCtx pbc,
			ref Guid bhid,
			ref Guid riid);

		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		IShellItem GetParent();

		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		void GetDisplayName(
			SIGDN sigdnName,
			StringBuilder ppszName);

		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		SFGAOF GetAttributes(
			SFGAOF mask);

		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		int Compare(
			IShellItem shellItem,
			SHELLITEMCOMPAREHINT hint);
	}


	public enum SIGDN : uint
	{
		NormalDisplay = 0x00000000,
		ParentRelativeParsing = 0x80018001,
		DesktopAbsoluteParsing = 0x80028000,
		ParentRelativeEditing = 0x80031001,
		DesktopAbsoluteEditing = 0x8004c000,
		FileSysPath = 0x80058000,
		Url = 0x80068000,
		ParentRelativeForAddressBar = 0x8007c001,
		ParentRelative = 0x80080001,
	}

	[Flags]
	public enum SHELLITEMCOMPAREHINT : uint
	{
		Display = 0x00000000,
		AllFields = 0x80000000,
		Canonical = 0x10000000,
	}

	//BHID_SFObject
	//Restricts usage to IShellFolder::BindToObject.
	//BHID_SFUIObject
	//Restricts usage to IShellFolder::GetUIObjectOf.
	//BHID_SFViewObject
	//Restricts usage to IShellFolder::CreateViewObject.
	//BHID_Storage
	//Attempts to retrieve the storage RIID, but defaults to Shell implementation on failure.
	//BHID_Stream
	//Restricts usage to IStream.
	//BHID_LinkTargetItem
	//CLSID_ShellItem is initialized with the target of this item (can only be SFGAO_LINK). See IShellFolder::GetAttributesOf for a description of SFGAO_LINK.
	//BHID_StorageEnum
	//If the item is a folder, gets an IEnumShellItems object with which to enumerate the storage contents.
	//BHID_Transfer
	//Windows Vista and later: If the item is a folder, gets an ITransferSource or ITransferDestination object.
	//BHID_PropertyStore
	//Windows Vista and later: Restricts usage to IPropertyStore or IPropertyStoreFactory.
	//BHID_ThumbnailHandler
	//Windows Vista and later: Restricts usage to IExtractImage or IThumbnailProvider.
	//BHID_EnumItems
	//Windows Vista and later: If the item is a folder, gets an IEnumShellItems object that enumerates all items in the folder. This includes folders, nonfolders, and hidden items.
	//BHID_DataObject
	//Windows Vista and later: Gets an IDataObject object for use with an item or an array of items.
	//BHID_AssociationArray
	//Windows Vista and later: Gets an IQueryAssociations object for use with an item or an array of items.
	//BHID_Filter
	//Windows Vista and later: Restricts usage to IFilter.

	//// use this for IShellFolder::BindToObject() objects; IShellFolder
	////  {3981e224-f559-11d3-8e3a-00c04f6837d5}
	//public static readonly Guid BHID_SFObject = new Guid(0x3981e224, 0xf559, 0x11d3, 0x8e, 0x3a, 0x00, 0xc0, 0x4f, 0x68, 0x37, 0xd5);

	//// use this for IShellFolder::GetUIObject() objects; IContextMenu, IDataObject, IDropTarget, IQueryAssociation, etc.
	////  {3981e225-f559-11d3-8e3a-00c04f6837d5}
	//public static readonly Guid BHID_SFUIObject = new Guid(0x3981e225, 0xf559, 0x11d3, 0x8e, 0x3a, 0x00, 0xc0, 0x4f, 0x68, 0x37, 0xd5);

	//// use this for IShellFolder::CreateViewObject() objects; IShellView, IDropTarget, IContextMenu
	////  {3981e226-f559-11d3-8e3a-00c04f6837d5}
	//public static readonly Guid BHID_SFViewObject = new Guid(0x3981e226, 0xf559, 0x11d3, 0x8e, 0x3a, 0x00, 0xc0, 0x4f, 0x68, 0x37, 0xd5);

	//// use this for storage objects like IStream, IPropertyStore, IStorage
	////  {3981e227-f559-11d3-8e3a-00c04f6837d5}
	//public static readonly Guid BHID_Storage = new Guid(0x3981e227, 0xf559, 0x11d3, 0x8e, 0x3a, 0x00, 0xc0, 0x4f, 0x68, 0x37, 0xd5);

	//// use this to get an IStream for the item
	//// {1CEBB3AB-7C10-499a-A417-92CA16C4CB83}
	//public static readonly Guid BHID_Stream = new Guid(0x1cebb3ab, 0x7c10, 0x499a, 0xa4, 0x17, 0x92, 0xca, 0x16, 0xc4, 0xcb, 0x83);

	//// use this to deref the item if it is a link to get its target item, use IShellItem
	////  {3981e228-f559-11d3-8e3a-00c04f6837d5}
	//public static readonly Guid BHID_LinkTargetItem = new Guid(0x3981e228, 0xf559, 0x11d3, 0x8e, 0x3a, 0x00, 0xc0, 0x4f, 0x68, 0x37, 0xd5);

	//// if the item is a folder use this to get an IEnumShellItems that enumerates the storage contents
	//// {4621A4E3-F0D6-4773-8A9C-46E77B174840}
	//public static readonly Guid BHID_StorageEnum = new Guid(0x4621a4e3, 0xf0d6, 0x4773, 0x8a, 0x9c, 0x46, 0xe7, 0x7b, 0x17, 0x48, 0x40);

	//// if the item is a folder use this to get an ITransferSource or ITransferDestiation object
	//// {5D080304-FE2C-48fc-84CE-CF620B0F3C53}
	//public static readonly Guid BHID_Transfer = new Guid(0xd5e346a1, 0xf753, 0x4932, 0xb4, 0x3, 0x45, 0x74, 0x80, 0xe, 0x24, 0x98);

	//// use this to get an IPropertyStore or IPropertyStoreFactory
	//// to have more control over the property store for the item
	//// {0384e1a4-1523-439c-a4c8-ab911052f586}
	//public static readonly Guid BHID_PropertyStore = new Guid(0x0384e1a4, 0x1523, 0x439c, 0xa4, 0xc8, 0xab, 0x91, 0x10, 0x52, 0xf5, 0x86);

	//// use this to get IExtractImage / IThumbnailProvider for an item
	//// {7b2e650a-8e20-4f4a-b09e-6597afc72fb0}
	//public static readonly Guid BHID_ThumbnailHandler = new Guid(0x7b2e650a, 0x8e20, 0x4f4a, 0xb0, 0x9e, 0x65, 0x97, 0xaf, 0xc7, 0x2f, 0xb0);

	//// if the item is a folder use this to get an IEnumShellItems that enumerates all items
	//// in the folder including folders, non folders and hidden items
	//// {94f60519-2850-4924-aa5a-d15e84868039}
	//public static readonly Guid BHID_EnumItems = new Guid(0x94f60519, 0x2850, 0x4924, 0xaa, 0x5a, 0xd1, 0x5e, 0x84, 0x86, 0x80, 0x39);

	//// use this to get an IDataObject for an item or an array of items IShellItem/IShellItemArray::BindToHandler()
	//// {B8C0BD9F-ED24-455c-83E6-D5390C4FE8C4}
	//public static readonly Guid BHID_DataObject = new Guid(0xb8c0bd9f, 0xed24, 0x455c, 0x83, 0xe6, 0xd5, 0x39, 0xc, 0x4f, 0xe8, 0xc4);

	//// use this to get an IQueryAssociations for an item or an array of items IShellItem/IShellItemArray::BindToHandler()
	//// {bea9ef17-82f1-4f60-9284-4f8db75c3be9}
	//public static readonly Guid BHID_AssociationArray = new Guid(0xbea9ef17, 0x82f1, 0x4f60, 0x92, 0x84, 0x4f, 0x8d, 0xb7, 0x5c, 0x3b, 0xe9);

	//// use this to get an IFilter for an item
	//// {38d08778-f557-4690-9ebf-ba54706ad8f7}
	//public static readonly Guid BHID_Filter = new Guid(0x38d08778, 0xf557, 0x4690, 0x9e, 0xbf, 0xba, 0x54, 0x70, 0x6a, 0xd8, 0xf7);

}
