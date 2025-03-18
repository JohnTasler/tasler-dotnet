using System.Runtime.InteropServices;

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

#region SetWindowPos() Flags
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
#endregion SetWindowPos() Flags

#region ShowWindow() Commands
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
#endregion ShowWindow() Commands

#region System Menu Commands
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
#endregion System Menu Commands

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
	TEXT = 1,

	/// <summary>CF_BITMAP</summary>
	BITMAP = 2,

	/// <summary>CF_METAFILEPICT</summary>
	METAFILEPICT = 3,

	/// <summary>CF_SYLK</summary>
	SYLK = 4,

	/// <summary>CF_DIF</summary>
	DIF = 5,

	/// <summary>CF_TIFF</summary>
	TIFF = 6,

	/// <summary>CF_OEMTEXT</summary>
	OEMTEXT = 7,

	/// <summary>CF_DIB</summary>
	DIB = 8,

	/// <summary>CF_PALETTE</summary>
	PALETTE = 9,

	/// <summary>CF_PENDATA</summary>
	PENDATA = 10,

	/// <summary>CF_RIFF</summary>
	RIFF = 11,

	/// <summary>CF_WAVE</summary>
	WAVE = 12,

	/// <summary>CF_UNICODETEXT</summary>
	UNICODETEXT = 13,

	/// <summary>CF_ENHMETAFILE</summary>
	ENHMETAFILE = 14,

	/// <summary>CF_HDROP</summary>
	HDROP = 15,

	/// <summary>CF_LOCALE</summary>
	LOCALE = 16,

	/// <summary>CF_DIBV5</summary>
	DIBV5 = 17,

	/// <summary>CF_OWNERDISPLAY</summary>
	OWNERDISPLAY = 0x0080,

	/// <summary>CF_DSPTEXT</summary>
	DSPTEXT = 0x0081,

	/// <summary>CF_DSPBITMAP</summary>
	DSPBITMAP = 0x0082,

	/// <summary>CF_DSPMETAFILEPICT</summary>
	DSPMETAFILEPICT = 0x0083,

	/// <summary>CF_DSPENHMETAFILE</summary>
	DSPENHMETAFILE = 0x008E,

	/// <summary>CF_PRIVATEFIRST</summary>
	PRIVATEFIRST = 0x0200,

	/// <summary>CF_PRIVATELAST</summary>
	PRIVATELAST = 0x02FF,

	/// <summary>CF_GDIOBJFIRST</summary>
	GDIOBJFIRST = 0x0300,

	/// <summary>CF_GDIOBJLAST</summary>
	GDIOBJLAST = 0x03FF,
}
