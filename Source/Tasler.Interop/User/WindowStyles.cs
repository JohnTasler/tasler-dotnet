using System;

namespace Tasler.Interop.User
{
	#region Class Styles
	[Flags]
	public enum CS
	{
		None = 0,
		VRedraw = 0x0001,
		HRedraw = 0x0002,
		DblClks = 0x0008,
		OwnDC = 0x0020,
		ClassDC = 0x0040,
		ParentDC = 0x0080,
		NoClose = 0x0200,
		SaveBits = 0x0800,
		ByteAlignClient = 0x1000,
		ByteAlignWindow = 0x2000,
		GlobalClass = 0x4000,
		Ime = 0x00010000,
		DropShadow = 0x00020000,
	}
	#endregion Class Styles

	#region Window Styles
	[Flags]
	public enum WS
	{
		None = 0,
		Overlapped = 0x00000000,
		Popup = unchecked((int)0x80000000L),
		Child = 0x40000000,
		Minimize = 0x20000000,
		Visible = 0x10000000,
		Disabled = 0x08000000,
		ClipSiblings = 0x04000000,
		ClipChildren = 0x02000000,
		Maximize = 0x01000000,
		Caption = 0x00C00000,     /* WS_BORDER | WS_DLGFRAME  */
		Border = 0x00800000,
		DlgFrame = 0x00400000,
		VScroll = 0x00200000,
		HScroll = 0x00100000,
		SysMenu = 0x00080000,
		ThickFrame = 0x00040000,
		Group = 0x00020000,
		Tabstop = 0x00010000,
		MinimizeBox = 0x00020000,
		MaximizeBox = 0x00010000,
	}
	#endregion Window Styles

	#region Extended Window Styles
	[Flags]
	public enum WS_EX
	{
		None = 0,
		DlgModalFrame = 0x00000001,
		NoParentNotify = 0x00000004,
		Topmost = 0x00000008,
		AcceptFiles = 0x00000010,
		Transparent = 0x00000020,
		MdiChild = 0x00000040,
		ToolWindow = 0x00000080,
		WindowEdge = 0x00000100,
		ClientEdge = 0x00000200,
		ContextHelp = 0x00000400,
		Right = 0x00001000,
		Left = 0x00000000,
		RtlReading = 0x00002000,
		LtrReading = 0x00000000,
		LeftScrollbar = 0x00004000,
		RightScrollbar = 0x00000000,
		ControlParent = 0x00010000,
		StaticEdge = 0x00020000,
		AppWindow = 0x00040000,
		OverlappedWindow = (WindowEdge | ClientEdge),
		PaletteWindow = (WindowEdge | ToolWindow | Topmost),
		Layered = 0x00080000,
		NoInheritLayout = 0x00100000, // Disable inheritence of mirroring by children
		LayoutRtl = 0x00400000, // Right to left mirroring
		Composited = 0x02000000,
		NoActivate = 0x08000000,
	}
	#endregion Extended Window Styles
}
