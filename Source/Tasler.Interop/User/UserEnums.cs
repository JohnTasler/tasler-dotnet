
using System.Drawing;

namespace Tasler.Interop.User;

#region AnimateWindow() Commands
[Flags]
public enum AW
{
	None        = 0,
	HorPositive = 0x00000001,
	HorNegative = 0x00000002,
	VerPositive = 0x00000004,
	VerNegative = 0x00000008,
	Center      = 0x00000010,
	Hide        = 0x00010000,
	Activate    = 0x00020000,
	Slide       = 0x00040000,
	Blend       = 0x00080000,
}
#endregion AnimateWindow() Commands

#region GetWindow() Constants
public enum GW
{
	HwndFirst    = 0,
	HwndLast     = 1,
	HwndNext     = 2,
	HwndPrev     = 3,
	Owner        = 4,
	Child        = 5,
	EnabledPopup = 6,
}

#endregion GetWindow() Constants

[Flags]
public enum DCX : uint
{
	Default          = 0,

	// <summary>Returns a DC from the cache, rather than the OWNDC or CLASSDC window. Essentially overrides CS_OWNDC and CS_CLASSDC.</summary
	Cache            = 0x00000002,

	// <summary>Excludes the visible regions of all child windows below the window identified by hWnd.</summary
	ClipChildren     = 0x00000008,

	// <summary>Excludes the visible regions of all sibling windows above the window identified by hWnd.</summary
	ClipSiblings     = 0x00000010,

	// <summary>Uses the visible region of the parent window. The parent's WS_CLIPCHILDREN and CS_PARENTDC style bits are ignored. The origin is set to the upper-left corner of the window identified by hWnd.</summary
	ParentClip       = 0x00000020,

	// <summary>The clipping region identified by hrgnClip is excluded from the visible region of the returned DC.</summary
	ExcludeRgn       = 0x00000040,

	// <summary>The clipping region identified by hrgnClip is intersected with the visible region of the returned DC.</summary
	IntersectRgn     = 0x00000080,

	// <summary>Allows drawing even if there is a LockWindowUpdate call in effect that would otherwise exclude this window.Used for drawing during tracking.</summary
	LockWindowUpdate = 0x00000400,
}

[Flags]
public enum CS : uint
{
	/// <summary>Redraws the entire window if a movement or size adjustment changes the height of the client area.</summary>
	VerticaRedraw    = 0x00000001,

	/// <summary>Redraws the entire window if a movement or size adjustment changes the width of the client area.</summary>
	HorizontalRedraw = 0x00000002,

	/// <summary>Sends a double-click message to the window procedure when the user double-clicks the mouse while the cursor is within a window belonging to the class.</summary>
	DoubleClicks     = 0x00000008,

	/// <summary>Allocates a unique device context for each window in the class.</summary>
	OwnDC            = 0x00000020,

	/// <summary>Allocates one device context to be shared by all windows in the class. Because window classes are process specific, it is possible for multiple threads of an application to create a window of the same class. It is also possible for the threads to attempt to use the device context simultaneously. When this happens, the system allows only one thread to successfully finish its drawing operation.</summary>
	ClassDC          = 0x00000040,

	/// <summary>Sets the clipping rectangle of the child window to that of the parent window so that the child can draw on the parent. A window with the CS_PARENTDC style bit receives a regular device context from the system's cache of device contexts. It does not give the child the parent's device context or device context settings. Specifying CS_PARENTDC enhances an application's performance.</summary>
	ParentDC         = 0x00000080,

	/// <summary>Disables Close on the window menu.</summary>
	NoClose          = 0x00000200,

	/// <summary>
	///   <para>Saves, as a bitmap, the portion of the screen image obscured by a window of this class. When the window is removed, the system uses the saved bitmap to restore the screen image, including other windows that were obscured. Therefore, the system does not send WM_PAINT messages to windows that were obscured if the memory used by the bitmap has not been discarded and if other screen actions have not invalidated the stored image.</para>
	///   <para>This style is useful for small windows (for example, menus or dialog boxes) that are displayed briefly and then removed before other screen activity takes place. This style increases the time required to display the window, because the system must first allocate memory to store the bitmap.</para>
	/// </summary>
	SaveBits         = 0x00000800,

	/// <summary>Aligns the window's client area on a byte boundary (in the x direction). This style affects the width of the window and its horizontal placement on the display.</summary>
	ByteAlignClient  = 0x00001000,

	/// <summary>Aligns the window on a byte boundary (in the x direction). This style affects the width of the window and its horizontal placement on the display.</summary>
	ByteAlignWindow  = 0x00002000,

	/// <summary>Indicates that the window class is an application global class. For more information, see the "Application Global Classes" section of About Window Classes.</summary>
	GlobalClass      = 0x00004000,

	/// <summary>The IME (Input Method Editor>.</summary>
	IME              = 0x00010000,

	/// <summary>Enables the drop shadow effect on a window. The effect is turned on and off through SPI_SETDROPSHADOW. Typically, this is enabled for small, short-lived windows such as menus to emphasize their Z-order relationship to other windows. Windows created from a class with this style must be top-level windows; they may not be child windows.</summary>
	DropShadow       = 0x00020000,
}


#region GetWindowLongPtr/SetWindowLongPtr Indices
public enum GWLP
{
	WndProc    =  -4,
	Hinstance  =  -6,
	HwndParent =  -8,
	Style      = -16,
	ExStyle    = -20,
	UserData   = -21,
	Id         = -12,
}
#endregion GetWindowLongPtr/SetWindowLongPtr Indices

/// <summary>SetWindowPos() Flags</summary>
[Flags]
public enum SWP : uint
{
	NoSize         = 0x0001,
	NoMove         = 0x0002,
	NoZOrder       = 0x0004,
	NoRedraw       = 0x0008,
	NoActivate     = 0x0010,
	FrameChanged   = 0x0020,  /* The frame changed: send WM_NCCALCSIZE */
	ShowWindow     = 0x0040,
	HideWindow     = 0x0080,
	NoCopyBits     = 0x0100,
	NoOwnerZOrder  = 0x0200,  /* Don't do owner Z ordering */
	NoSendChanging = 0x0400,  /* Don't send WM_WINDOWPOSCHANGING */
	DrawFrame      = SWP.FrameChanged,
	NoReposition   = SWP.NoOwnerZOrder,
	DeferErase     = 0x2000,
	AsyncWindowpos = 0x4000,
}

public static class HWND
{
	public static readonly SafeHwnd Top       = new SafeHwnd { Handle =  nint.Zero };
	public static readonly SafeHwnd Bottom    = new SafeHwnd { Handle = (nint)  1  };
	public static readonly SafeHwnd Topmost   = new SafeHwnd { Handle = (nint)(-1) };
	public static readonly SafeHwnd NoTopmost = new SafeHwnd { Handle = (nint)(-2) };
}

/// <summary>ShowWindow() Commands</summary>
public enum SW
{
	/// <summary>
	/// <b>Windows 2000/XP:</b> Minimizes a window, even if the thread that owns the window is not responding. This flag should only be used when minimizing windows from a different thread.
	/// </summary>
	ForceMinimize = 11,

	/// <summary>
	/// Hides the window and activates another window.
	/// </summary>
	Hide = 0,

	/// <summary>
	/// Maximizes the specified window.
	/// </summary>
	Maximize = 3,

	/// <summary>
	/// Minimizes the specified window and activates the next top-level window in the Z order.
	/// </summary>
	Minimize = 6,

	/// <summary>
	/// Activates and displays the window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when restoring a minimized window.
	/// </summary>
	Restore = 9,

	/// <summary>
	/// Activates the window and displays it in its current size and position.
	/// </summary>
	Show = 5,

	/// <summary>
	/// Sets the show state based on the SW_ value specified in the STARTUPINFO structure passed to the CreateProcess function by the program that started the application.
	/// </summary>
	ShowDefault = 10,

	/// <summary>
	/// Activates the window and displays it as a maximized window.
	/// </summary>
	ShowMaximized = 3,

	/// <summary>
	/// Activates the window and displays it as a minimized window.
	/// </summary>
	ShowMinimized = 2,

	/// <summary>
	/// Displays the window as a minimized window. This value is similar to SW_SHOWMINIMIZED, except the window is not activated.
	/// </summary>
	ShowMinNoActivate = 7,

	/// <summary>
	/// Displays the window in its current size and position. This value is similar to SW_SHOW, except the window is not activated.
	/// </summary>
	ShowNA = 8,

	/// <summary>
	/// Displays a window in its most recent size and position. This value is similar to SW_SHOWNORMAL, except the window is not actived.
	/// </summary>
	ShowNoActivate = 4,

	/// <summary>
	/// Activates and displays a window. If the window is minimized or maximized, the system restores it to its original size and position. An application should specify this flag when displaying the window for the first time.
	/// </summary>
	ShowNormal = 1,
}

/// <summary>System Menu Commands</summary>
public enum SC
{
	Size            = 0xF000,
	SizeLeft        = 0xF001,
	SizeRight       = 0xF002,
	SizeTop         = 0xF003,
	SizeTopLeft     = 0xF004,
	SizeTopRight    = 0xF005,
	SizeBottom      = 0xF006,
	SizeBottemLeft  = 0xF007,
	SizeBottomRight = 0xF008,
	Move            = 0xF010,
	MoveCaption     = 0xF012,
	Minimize        = 0xF020,
	Maximize        = 0xF030,
	NextWindow      = 0xF040,
	PrevWindow      = 0xF050,
	Close           = 0xF060,
	VScroll         = 0xF070,
	HScroll         = 0xF080,
	MouseMenu       = 0xF090,
	KeyMenu         = 0xF100,
	Arrange         = 0xF110,
	Restore         = 0xF120,
	TaskList        = 0xF130,
	ScreenSave      = 0xF140,
	HotKey          = 0xF150,
	Default         = 0xF160,
	MonitorPower    = 0xF170,
	ContextHelp     = 0xF180,
	Separator       = 0xF00F,
}

[Flags]
public enum KF : ushort
{
	/// <summary>Manipulates the extended key flag.</summary>
	Extended = 0x0100,

	/// <summary>Manipulates the "do not care" key flag.</summary>
	DoNotCare = 0x0200,

	/// <summary>Manipulates the dialog mode flag, which indicates whether a dialog box is active.</summary>
	DlgMode  = 0x0800,

	/// <summary>Manipulates the menu mode flag, which indicates whether a menu is active.</summary>
	Menumode = 0x1000,

	/// <summary>Manipulates the context code flag.</summary>
	AltDown  = 0x2000,

	/// <summary>Manipulates the previous key state flag.</summary>
	Repeat   = 0x4000,

	/// <summary>Manipulates the transition state flag.</summary>
	Up       = 0x8000,
}

#region WM_ACTIVATE state values
public enum WA
{
	Inactive    = 0,
	Active      = 1,
	ClickActive = 2,
}
#endregion WM_ACTIVATE state values

#region WM_MOUSEACTIVATE Return Codes
public enum MA
{
	Activate         = 1,
	ActivateAndEat   = 2,
	NoActivate       = 3,
	NoActivateAndEat = 4,
}
#endregion WM_MOUSEACTIVATE Return Codes

#region WM_NCHITTEST Return Codes
public enum HT
{
	Error = (-2),
	Transparent = (-1),
	NoWhere = 0,
	Client = 1,
	Caption = 2,
	SysMenu = 3,
	GrowBox = 4,
	Size = GrowBox,
	Menu = 5,
	HScroll = 6,
	VScroll = 7,
	MinButton = 8,
	MaxButton = 9,
	Left = 10,
	Right = 11,
	Top = 12,
	TopLeft = 13,
	TopRight = 14,
	Bottom = 15,
	BottomLeft = 16,
	BottomRight = 17,
	Border = 18,
	Reduce = MinButton,
	Zoom = MaxButton,
	SizeFirst = Left,
	SizeLast = BottomRight,
	Object = 19,
	Close = 20,
	Help = 21,
}
#endregion WM_NCHITTEST Return Codes

#region WM_PRINT Flags
[Flags]
public enum PRF
{
	None = 0,
	CheckVisible = 0x00000001,
	NonClient = 0x00000002,
	Client = 0x00000004,
	EraseBkgnd = 0x00000008,
	Children = 0x00000010,
	Owned = 0x00000020,
}
#endregion WM_PRINT Flags

#region WM_SIZE Sizing Types
public enum SizeType
{
	/// <summary>
	/// The window has been resized, but neither the <see cref="Minimized"/> nor <see cref="Maximized"/> value applies.
	/// </summary>
	Restored = 0,

	/// <summary>
	/// The window has been minimized.
	/// </summary>
	Minimized = 1,

	/// <summary>
	/// The window has been maximized.
	/// </summary>
	Maximized = 2,

	/// <summary>
	/// Message is sent to all pop-up windows when some other window has been restored to its former size.
	/// </summary>
	MaxShow = 3,

	/// <summary>
	/// Message is sent to all pop-up windows when some other window is maximized.
	/// </summary>
	MaxHide = 4,
}
#endregion WM_SIZE Sizing Types

#region WM_DEVICECHANGE Events
/// <summary>
/// The device events broadcast by the system using the <see cref="WM.DEVICECHANGE"/> message.
/// </summary>
public enum DBT
{
	/// <summary>A request to change the current configuration (dock or undock) has been canceled.</summary>
	ConfigChangeCanceled    = 0x0019,
	/// <summary>The current configuration has changed, due to a dock or undock.</summary>
	ConfigChanged           = 0x0018,
	/// <summary>A custom event has occurred.</summary>
	CustomEvent             = 0x8006,
	/// <summary>A device or piece of media has been inserted and is now available.</summary>
	DeviceArrival           = 0x8000,
	/// <summary>Permission is requested to remove a device or piece of media. Any application can deny this request and cancel the removal.</summary>
	DeviceQueryRemove       = 0x8001,
	/// <summary>A request to remove a device or piece of media has been canceled.</summary>
	DeviceQueryRemoveFailed = 0x8002,
	/// <summary>A device or piece of media has been removed.</summary>
	DeviceRemoveComplete    = 0x8004,
	/// <summary>A device or piece of media is about to be removed. Cannot be denied.</summary>
	DeviceRemovePending     = 0x8003,
	/// <summary>A device-specific event has occurred.</summary>
	DeviceTypeSpecific      = 0x8005,
	/// <summary>A device has been added to or removed from the system.</summary>
	DevNodesChanged         = 0x0007,
	/// <summary>Permission is requested to change the current configuration (dock or undock).</summary>
	QueryChangeConfig       = 0x0017,
	/// <summary>The meaning of this message is user-defined.</summary>
	UserDefined             = 0xFFFF,
}
#endregion WM_DEVICECHANGE Events

public enum ClipboardFormat : short
{
	/// <summary>CF_TEXT</summary>
	Text = 1,

	/// <summary>CF_BITMAP</summary>
	Bitmap = 2,

	/// <summary>CF_METAFILEPICT</summary>
	MetafilePict = 3,

	/// <summary>CF_SYLK</summary>
	SYLK = 4,

	/// <summary>CF_DIF</summary>
	DIF = 5,

	/// <summary>CF_TIFF</summary>
	TIFF = 6,

	/// <summary>CF_OEMTEXT</summary>
	OemText = 7,

	/// <summary>CF_DIB</summary>
	DIB = 8,

	/// <summary>CF_PALETTE</summary>
	Palette = 9,

	/// <summary>CF_PENDATA</summary>
	PenData = 10,

	/// <summary>CF_RIFF</summary>
	RIFF = 11,

	/// <summary>CF_WAVE</summary>
	WAVE = 12,

	/// <summary>CF_UNICODETEXT</summary>
	UnicodeText = 13,

	/// <summary>CF_ENHMETAFILE</summary>
	EnhancedMetafile = 14,

	/// <summary>CF_HDROP</summary>
	HDROP = 15,

	/// <summary>CF_LOCALE</summary>
	Locale = 16,

	/// <summary>CF_DIBV5</summary>
	DIBV5 = 17,

	/// <summary>CF_OWNERDISPLAY</summary>
	OwnerDisplay = 0x0080,

	/// <summary>CF_DSPTEXT</summary>
	DSPText = 0x0081,

	/// <summary>CF_DSPBITMAP</summary>
	DSPBitmap = 0x0082,

	/// <summary>CF_DSPMETAFILEPICT</summary>
	DSPMetafilePict = 0x0083,

	/// <summary>CF_DSPENHMETAFILE</summary>
	DSPEnhancedMetafile = 0x008E,

	/// <summary>CF_PRIVATEFIRST</summary>
	PrivateFirst = 0x0200,

	/// <summary>CF_PRIVATELAST</summary>
	PrivateLast = 0x02FF,

	/// <summary>CF_GDIOBJFIRST</summary>
	GdiObjectFirst = 0x0300,

	/// <summary>CF_GDIOBJLAST</summary>
	GdiObjectLast = 0x03FF,
}

public enum COLOR
{
	/// <summary>Face color for three-dimensional display elements and for dialog box backgrounds.</summary
	ThreeDFace = 15,

	/// <summary>Text on push buttons. The associated background color is COLOR_BTNFACE.</summary
	ButtonText= 18,

	/// <summary>Grayed (disabled) text. This color is set to 0 if the current display driver does not support a solid gray color.</summary
	GrayText = 17,

	/// <summary>Item(s) selected in a control. The associated foreground color is COLOR_HIGHLIGHTTEXT.</summary
	Highlight = 13,

	/// <summary>Text of item(s) selected in a control. The associated background color is COLOR_HIGHLIGHT.</summary
	HighlightText = 14,

	/// <summary>Color for a hyperlink or hot-tracked item. The associated background color is COLOR_WINDOW.</summary
	HotLight = 26,

	/// <summary>Window background. The associated foreground colors are COLOR_WINDOWTEXT and COLOR_HOTLITE.</summary
	Window = 5,

	/// <summary>Text in windows.The associated background color is COLOR_WINDOW.</summary
	WindowText = 8,
}