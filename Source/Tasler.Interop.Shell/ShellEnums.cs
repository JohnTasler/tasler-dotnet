
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
