
using System.Diagnostics;
using System.Net;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using Tasler.Interop.User;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Tasler.Interop.Shell.PropertyKeys;
using static Tasler.Interop.Shell.PropertyKeys.Shell;

namespace Tasler.Interop.Shell;


[Flags]
public enum SFGAO : uint
{
	CanCopy         = 0x00000001, // Objects can be copied    (0x1)
	CanMove         = 0x00000002, // Objects can be moved     (0x2)
	CanLink         = 0x00000004, // Objects can be linked    (0x4)
	CanRename       = 0x00000010, // Objects can be renamed
	CanDelete       = 0x00000020, // Objects can be deleted
	HasPropSheet    = 0x00000040, // Objects have property sheets
	DropTarget      = 0x00000100, // Objects are drop target
	CapabilityMask  = 0x00000177,
	Link            = 0x00010000, // Shortcut (link)
	Share           = 0x00020000, // shared
	ReadOnly        = 0x00040000, // read-only
	Ghosted         = 0x00008000, // ghosted icon
	Hidden          = 0x00080000, // hidden object
	DisplayAttrMask = 0x000F0000,
	FileSysAncestor = 0x10000000, // It contains file system folder
	Folder          = 0x20000000, // It's a folder.
	FileSystem      = 0x40000000, // is a file system thing (file/folder/root)
	HasSubfolder    = 0x80000000, // Expandable in the map pane
	ContentsMask    = 0x80000000,
	Validate        = 0x01000000, // invalidate cached information
	Removable       = 0x02000000, // is this removeable media?
	Compressed      = 0x04000000, // Object is compressed (use alt color)
	Browsable       = 0x08000000, // is in-place browsable
	NonEnumerated   = 0x00100000, // is a non-enumerated object
	NewContent      = 0x00200000, // should show bold in explorer tree
	CanMoniker      = 0x00400000, // can create monikers for its objects
}

[Flags]
public enum SHGFI : uint
{
	/// <summary>get icon</summary>
	Icon              = 0x000000100,
	/// <summary>get display name</summary>
	DisplayName       = 0x000000200,
	/// <summary>get type name</summary>
	TypeName          = 0x000000400,
	/// <summary>get attributes</summary>
	Attributes        = 0x000000800,
	/// <summary>get icon location</summary>
	IconLocation      = 0x000001000,
	/// <summary>return exe type</summary>
	ExeType           = 0x000002000,
	/// <summary>get system icon index</summary>
	SysIconIndex      = 0x000004000,
	/// <summary>put a link overlay on icon</summary>
	LinkOverlay       = 0x000008000,
	/// <summary>show icon in selected state</summary>
	Selected          = 0x000010000,
	/// <summary>get only specified attributes</summary>
	AttrSpecified     = 0x000020000,
	/// <summary>get large icon (default)</summary
	LargeIcon         = 0x000000000,
	/// <summary>get small icon</summary>
	SmallIcon         = 0x000000001,
	/// <summary>get open icon</summary>
	OpenIcon          = 0x000000002,
	/// <summary>get shell size icon</summary>
	ShellIconSize     = 0x000000004,
	/// <summary>pszPath is a pidl</summary>
	Pidl              = 0x000000008,
	/// <summary>use passed dwFileAttribute</summary>
	UseFileAttributes = 0x000000010,
	/// <summary>apply the appropriate overlays</summary>
	AddOverlays       = 0x000000020,
	/// <summary>Get the index of the overlay in the upper 8 bits of the iIcon</summary>
	OverlayIndex      = 0x000000040,
}

public enum SHIL
{
	/// <summary>normally 32x32</summary>
	Large      = 0,
	/// <summary>normally 16x16</summary>
	Small = 1,
	/// <summary>normally 48x48?</summary>
	ExtraLarge = 2,
	/// <summary>like SHIL_SMALL, but tracks system small icon metric correctly</summary>
	SysSmall = 3,
	/// <summary>normally 256x256</summary>
	Jumbo = 4,
}

[Flags]
public enum ImageListDrawFlags : uint
{
	/// <summary>
	/// Draws the image using the background color for the image list. If the background color is
	/// the CLR_NONE value, the image is drawn transparently using the mask.
	/// </summary>
	Normal = 0x00000000,

	/// <summary>
	/// Draws the image transparently using the mask, regardless of the background color. This value
	/// has no effect if the image list does not contain a mask.
	/// </summary>
	Transparent = 0x00000001,

	/// <summary>
	/// Draws the image, blending 25 percent with the blend color specified by rgbFg. This value has
	/// no effect if the image list does not contain a mask.
	/// </summary>
	Blend25 = 0x00000002,

	/// <summary>
	/// Same as ILD_BLEND25.
	/// </summary>
	Focus = 0x00000002,

	/// <summary>
	/// Draws the image, blending 50 percent with the blend color specified by rgbFg. This value has
	/// no effect if the image list does not contain a mask.
	/// </summary>
	Blend50 = 0x00000004,

	/// <summary>
	/// Same as ILD_BLEND50.
	/// </summary>
	Selected = 0x00000004,

	/// <summary>
	/// Same as ILD_BLEND50.
	/// </summary>
	Blend = 0x00000004,

	/// <summary>
	/// Draws the mask.
	/// </summary>
	Mask = 0x00000010,

	/// <summary>
	/// If the overlay does not require a mask to be drawn, set this flag.
	/// </summary>
	Image = 0x00000020,

	/// <summary>
	/// Draws the image using the raster operation code specified by the dwRop member.
	/// </summary>
	Rop = 0x00000040,

	/// <summary>
	/// To extract the overlay image from the fStyle member, use the logical AND to combine fStyle
	/// with the ILD_OVERLAYMASK value.
	/// </summary>
	OverlayMask = 0x00000F00,

	/// <summary>
	/// Preserves the alpha channel in the destination.
	/// </summary>
	PreserveAlpha = 0x00001000,

	/// <summary>
	/// Causes the image to be scaled to cx, cy instead of being clipped.
	/// </summary>
	Scale = 0x00002000,

	/// <summary>
	/// Scales the image to the current dpi of the display.
	/// </summary>
	DpiU= 0x00004000,

	/// <summary>
	/// Windows Vista and later. Draw the image if it is available in the cache. Do not extract it
	/// automatically.The called draw method returns E_PENDING to the calling component, which should
	/// then take an alternative action, such as, provide another image and queue a background task
	/// to force the image to be loaded via ForceImagePresent using the ILFIP_ALWAYS flag.The
	/// Async flag then prevents the extraction operation from blocking the current thread and is
	/// especially important if a draw method is called from the user interface (UI) thread.
	/// </summary>
	Async = 0x00008000,
}

[Flags]
public enum ImageListStateFlags : uint
{
	/// <summary>The image state is not modified.</summary>
	Normal = 0x00000000,

	/// <summary>Not supported.</summary>
	Glow = 0x00000001,

	/// <summary>Not supported.</summary>
	Shadow = 0x00000002,

	/// <summary>
	/// Reduces the color saturation of the icon to grayscale. This only affects 32bpp images.
	/// </summary>
	Saturate = 0x00000004,

	/// <summary>
	/// Alpha blends the icon. Alpha blending controls the transparency level of an icon, according
	/// to the value of its alpha channel. The value of the alpha channel is indicated by the frame
	/// member in the IMAGELISTDRAWPARAMS method. The alpha channel can be from 0 to 255, with 0
	/// being completely transparent, and 255 being completely opaque.
	/// </summary>
	Alpha = 0x00000008,
}

/// <summary>
/// Used in the <see cref="IImageList.Copy"/> methodd.
/// </summary>
[Flags]
public enum ImageListCopyFlags : uint
{
	/// <summary>
	/// The source image is copied to the destination image's index. This operation results in
	/// multiple instances of a given image.
	/// </summary>
	Move = 0,

	/// <summary>
	/// The source and destination images exchange positions within the image list.
	/// </summary>
	Swap = 1,
}

/// <summary>
/// Used in the <see cref="IImageList2.ForceImagePresent"/> method.
/// </summary>
public enum ImageListForceImagePresent
{
	/// <summary>Always get the image(can be slow).</summary>
	P_ALWAYS = 0x00000000,

	/// <summary>Only get if on standby.</summary>
	P_FROMSTANDBY = 0x00000001,
}

[Flags]
public enum ImageListCreationFlags : uint
{
	/// <summery>Use a mask. The image list contains two bitmaps, one of which is a monochrome bitmap used as a mask.If this value is not included, the image list contains only one bitmap.</summery>
	Mask = 0x00000001,

	/// <summery>Use the default behavior if none of the other ILC_COLORx flags is specified.Typically, the default is ILC_COLOR4, but for older display drivers, the default is ILC_COLORDDB.</summery>
	Color = 0x00000000,

	/// <summery>Use a device-dependent bitmap.</summery>
	Colorddb = 0x000000FE,

	/// <summery>Use a 4-bit (16-color) device-independent bitmap(DIB) section as the bitmap for the image list.</summery>
	Color4 = 0x00000004,

	/// <summery>Use an 8-bit DIB section.The colors used for the color table are the same colors as the halftone palette.</summery>
	Color8 = 0x00000008,

	/// <summery>Use a 16-bit (32/64k-color) DIB section.</summery>
	Color16 = 0x00000010,

	/// <summery>Use a 24-bit DIB section.</summery>
	Color24 = 0x00000018,

	/// <summery>Use a 32-bit DIB section.</summery>
	Color32 = 0x00000020,

	/// <summery>Not implemented.</summery>
	Palette = 0x00000800,

	/// <summery>Mirror the icons contained, if the process is mirrored</summery>
	Mirror = 0x00002000,

	/// <summery>Causes the mirroring code to mirror each item when inserting a set of images, versus the whole strip.</summery>
	Peritemmirror = 0x00008000,

	/// <summery>Windows Vista and later. Imagelist should accept smaller than set images and apply original size based on image added.</summery>
	Originalsize = 0x00010000,

	/// <summery>Windows Vista and later. Reserved.</summery>
	Highqualityscale = 0x00020000,
}

[Flags]
public enum ImageListReplaceFlags : uint
{
	/// <summary>Horizontally align to left.</summary>
	HorizontalLeft = 0x0000,

	/// <summary>Horizontally center.</summary>
	HorizontalCenter = 0x0001,

	/// <summary>Horizontally align to right.</summary>
	HorizontalRight = 0x0002,

	/// <summary>Vertically align to top.</summary>
	VerticalTop = 0x0000,

	/// <summary>Vertically align to center.</summary>
	VerticalCenter = 0x0010,

	/// <summary>Vertically align to bottom.</summary>
	VerticalBottom = 0x0020,

	/// <summary>Do nothing.</summary>
	ScaleClip = 0x0000,

	/// <summary>Scale.</summary>
	ScaleAspectRatio = 0x0100,
}

[Flags]
public enum GetPropertyStoreFlags : uint
{
	/// <remarks>
	/// <list type="table">
	///   <item><term><b>For a calling process</b></term><description>Return a read-only property store that contains all properties. Slow items (offline files) are not opened.</description></item>
	///   <item><term><b>For a calling process</b></term><description>Return a read-only property store that contains all properties. Slow items (offline files) are not opened.</description></item>
	///   <item><term><b>Combination with other flags</b></term><description>Can be overridden by other flags.</description></item>
	/// </list>
	/// </remarks>
	Default = 0,

	/// <remarks>
	/// <list type="table">
	///   <item><term><b>For a calling process</b></term><description>Include only properties directly from the property handler, which opens the file on the disk, network, or device.</description></item>
	///   <item><term><b>For a file folder</b></term><description>Only include properties directly from the handler.</description></item>
	///   <item><term><b>For other folders</b></term><description>When delegating to a file folder, pass this flag on to the file folder; do not do any multiplexing (MUX). When not delegating to a file folder, ignore this flag instead of returning a failure code.</description></item>
	///   <item><term><b>Combination with other flags</b></term><description>Cannot be combined with 	TEMPORARY, 	FASTPROPERTIESONLY, or 	BESTEFFORT.</description></item>
	/// </list>
	/// </remarks>
	HandlerPropertiesOnly = 0x1,

	/// <remarks>
	/// <list type="table">
	///   <item><term><b>For a calling process</b></term><description>Can write properties to the item. Note</b></term><description>The store may contain fewer properties than a read-only store.</description></item>
	///   <item><term><b>For a file folder</b></term><description>ReadWrite.</description></item>
	///   <item><term><b>For other folders</b></term><description>ReadWrite. Note</b></term><description>When using default MUX, return a single unmultiplexed store because the default MUX does not support ReadWrite.</description></item>
	///   <item><term><b>Combination with other flags</b></term><description>Cannot be combined with 	TEMPORARY, 	FASTPROPERTIESONLY, 	BESTEFFORT, or 	DELAYCREATION. Implies 	HANDLERPROPERTIESONLY.</description></item>
	/// </list>
	/// </remarks>
	ReadWrite = 0x2,

	/// <remarks>
	/// <list type="table">
	///   <item><term><b>For a calling process</b></term><description>Provides a writable store, with no initial properties, that exists for the lifetime of the Shell item instance; basically, a property bag attached to the item instance.</description></item>
	///   <item><term><b>For a file folder</b></term><description>Not applicable. Handled by the Shell item.</description></item>
	///   <item><term><b>For other folders</b></term><description>Not applicable. Handled by the Shell item.</description></item>
	///   <item><term><b>Combination with other flags</b></term><description>Cannot be combined with any other flag. Implies 	READWRITE.</description></item>
	/// </list>
	/// </remarks>
	Temporary = 0x4,

	/// <remarks>
	/// <list type="table">
	///   <item><term><b>For a calling process</b></term><description>Provides a store that does not involve reading from the disk or network. Note</b></term><description>Some values may be different, or missing, compared to a store without this flag.</description></item>
	///   <item><term><b>For a file folder</b></term><description>Include the "innate" and "fallback" stores only. Do not load the handler.</description></item>
	///   <item><term><b>For other folders</b></term><description>Include only properties that are available in memory or can be computed very quickly (no properties from disk, network, or peripheral IO devices). This is normally only data sources from the IDLIST. When delegating to other folders, pass this flag on to them.</description></item>
	///   <item><term><b>Combination with other flags</b></term><description>Cannot be combined with 	TEMPORARY, 	READWRITE, 	HANDLERPROPERTIESONLY, or 	DELAYCREATION.</description></item>
	/// </list>
	/// </remarks>
	FastPropertiesOnly = 0x8,

	/// <remarks>
	/// <list type="table">
	///   <item><term><b>For a calling process</b></term><description>Open a slow item (offline file) if necessary.</description></item>
	///   <item><term><b>For a file folder</b></term><description>Retrieve a file from offline storage, if necessary. Note</b></term><description>Without this flag, the handler is not created for offline files.</description></item>
	///   <item><term><b>For other folders</b></term><description>Do not return any properties that are very slow.</description></item>
	///   <item><term><b>Combination with other flags</b></term><description>Cannot be combined with 	TEMPORARY or 	FASTPROPERTIESONLY.</description></item>
	/// </list>
	/// </remarks>
	OpenSlowItem = 0x10,

	/// <remarks>
	/// <list type="table">
	///   <item><term><b>For a calling process</b></term><description>Delay memory-intensive operations, such as file access, until a property is requested that requires such access.</description></item>
	///   <item><term><b>For a file folder</b></term><description>Do not create the handler until needed; for example, either GetCount/GetAt or GetValue, where the innate store does not satisfy the request. Note</b></term><description>GetValue might fail due to file access problems.</description></item>
	///   <item><term><b>For other folders</b></term><description>If the folder has memory-intensive properties, such as delegating to a file folder or network access, it can optimize performance by supporting IDelayedPropertyStoreFactory and splitting up its properties into a fast and a slow store. It can then use delayed MUX to recombine them.</description></item>
	///   <item><term><b>Combination with other flags</b></term><description>Cannot be combined with 	TEMPORARY or 	READWRITE.</description></item>
	/// </list>
	/// </remarks>
	DelayCreation = 0x20,

	/// <remarks>
	/// <list type="table">
	///   <item><term><b>For a calling process</b></term><description>Succeed at getting the store, even if some properties are not returned. Note</b></term><description>Some values may be different, or missing, compared to a store without this flag.</description></item>
	///   <item><term><b>For a file folder</b></term><description>Succeed and return a store, even if the handler or innate store has an error during creation. Only fail if substores fail.</description></item>
	///   <item><term><b>For other folders</b></term><description>Succeed on getting the store, even if some properties are not returned.</description></item>
	///   <item><term><b>Combination with other flags</b></term><description>Cannot be combined with 	TEMPORARY, 	READWRITE, or 	HANDLERPROPERTIESONLY.</description></item>
	/// </list>
	/// </remarks>
	BestEffort = 0x40,

	/// <remarks>
	/// <list type="table">
	///   <item><term><b>Windows 7 and later</b></term><description>Callers should use this flag only if they are already holding an opportunistic lock (oplock) on the file because without an oplock, the bind operation cannot continue. By default, the Shell requests an oplock on a file before binding to the property handler. This flag disables the default behavior.</description></item>
	///   <item><term><b>Windows Server 2008 and Windows Vista</b></term><description> This flag is not available.</description></item>
	/// </list>
	/// </remarks>
	NoOpLock = 0x80,

	/// <remarks>
	/// <list type="table">
	///   <item><term><b>Windows 8 and later</b></term><description>Use this flag to retrieve only properties from the indexer for WDS results.</descriptiont>	ription></item>
	/// </list>
	/// </remarks>
	PreferQueryProperties = 0x100,

	ExtrinsicProperties = 0x200,

	/// <summary>Include only properties from the file's secondary stream.</summary>
	ExtrinsicPropertiesOnly = 0x400,

	VolatileProperties = 0x800,

	VolatilePropertiesOnly = 0x1000,

	/// <summary>Mask for valid GETPROPERTYSTOREFLAGS values.</summary
	MaskValid = 0x1fff,
}
