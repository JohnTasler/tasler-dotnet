using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasler.Interop.User
{
	#region GetSystemMetrics() Indices
	/// <summary>
	/// Flags used with the Windows API (User32.dll): GetSystemMetrics(SystemMetric smIndex)
	/// </summary>
	public enum SM
	{
		/// <summary>
		///  Width of the screen of the primary display monitor, in pixels. This is the same values obtained by calling GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, HORZRES).
		/// </summary>
		ScreenWidth = 0,
		/// <summary>
		/// Height of the screen of the primary display monitor, in pixels. This is the same values obtained by calling GetDeviceCaps as follows: GetDeviceCaps( hdcPrimaryMonitor, VERTRES).
		/// </summary>
		ScreenHeight = 1,
		/// <summary>
		/// Width of a horizontal scroll bar, in pixels.
		/// </summary>
		VScrollHeight = 2,
		/// <summary>
		/// Height of a horizontal scroll bar, in pixels.
		/// </summary>
		VScrollWidth = 3,
		/// <summary>
		/// Height of a caption area, in pixels.
		/// </summary>
		CaptionHeight = 4,
		/// <summary>
		/// Width of a window border, in pixels. This is equivalent to the EdgeWidth value for windows with the 3-D look. 
		/// </summary>
		BorderWidth = 5,
		/// <summary>
		/// Height of a window border, in pixels. This is equivalent to the EdgeHeight value for windows with the 3-D look. 
		/// </summary>
		BorderHeight = 6,
		/// <summary>
		/// Thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. FixedFrameWidth is the height of the horizontal border and FixedFrameHeight is the width of the vertical border. 
		/// </summary>
		DialogFrameWidth = 7,
		/// <summary>
		/// Thickness of the frame around the perimeter of a window that has a caption but is not sizable, in pixels. FixedFrameWidth is the height of the horizontal border and FixedFrameHeight is the width of the vertical border. 
		/// </summary>
		DialogFrameHeight = 8,
		/// <summary>
		/// Height of the thumb box in a vertical scroll bar, in pixels
		/// </summary>
		VThumbHeight = 9,
		/// <summary>
		/// Width of the thumb box in a horizontal scroll bar, in pixels.
		/// </summary>
		HThumbWidth = 10,
		/// <summary>
		/// Default width of an icon, in pixels. The LoadIcon function can load only icons with the dimensions specified by IconWidth and IconHeight
		/// </summary>
		IconWidth = 11,
		/// <summary>
		/// Default height of an icon, in pixels. The LoadIcon function can load only icons with the dimensions IconWidth and IconHeight.
		/// </summary>
		IconHeight = 12,
		/// <summary>
		/// Width of a cursor, in pixels. The system cannot create cursors of other sizes.
		/// </summary>
		CursorWidth = 13,
		/// <summary>
		/// Height of a cursor, in pixels. The system cannot create cursors of other sizes.
		/// </summary>
		CursorHeight = 14,
		/// <summary>
		/// Height of a single-line menu bar, in pixels.
		/// </summary>
		MenuHeight = 15,
		/// <summary>
		/// Width of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen not obscured by the system taskbar or by application desktop toolbars, call the SystemParametersInfo function with the SPI_GETWORKAREA value.
		/// </summary>
		FullScreenWidth = 16,
		/// <summary>
		/// Height of the client area for a full-screen window on the primary display monitor, in pixels. To get the coordinates of the portion of the screen not obscured by the system taskbar or by application desktop toolbars, call the SystemParametersInfo function with the SPI_GETWORKAREA value.
		/// </summary>
		FullScreenHeight = 17,
		/// <summary>
		/// For double byte character set versions of the system, this is the height of the Kanji window at the bottom of the screen, in pixels
		/// </summary>
		KanjiWindowHeight = 18,
		/// <summary>
		/// Nonzero if a mouse with a wheel is installed; zero otherwise
		/// </summary>
		MouseWheelPresent = 75,
		/// <summary>
		/// Height of the arrow bitmap on a vertical scroll bar, in pixels.
		/// </summary>
		HScrollHeight = 20,
		/// <summary>
		/// Width of the arrow bitmap on a horizontal scroll bar, in pixels.
		/// </summary>
		HScrollWidth = 21,
		/// <summary>
		/// Nonzero if the debug version of User.exe is installed; zero otherwise.
		/// </summary>
		Debug = 22,
		/// <summary>
		/// Nonzero if the left and right mouse buttons are reversed; zero otherwise.
		/// </summary>
		SwapButton = 23,
		/// <summary>
		/// Minimum width of a window, in pixels.
		/// </summary>
		MinWidth = 28,
		/// <summary>
		/// Minimum height of a window, in pixels.
		/// </summary>
		MinHeight = 29,
		/// <summary>
		/// Width of a button in a window's caption or title bar, in pixels.
		/// </summary>
		SizeWidth = 30,
		/// <summary>
		/// Height of a button in a window's caption or title bar, in pixels.
		/// </summary>
		SizeHeight = 31,
		/// <summary>
		/// Thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SizeFrameWidth is the width of the horizontal border, and SizeFrameHeight is the height of the vertical border. 
		/// </summary>
		FrameWidth = 32,
		/// <summary>
		/// Thickness of the sizing border around the perimeter of a window that can be resized, in pixels. SizeFrameWidth is the width of the horizontal border, and SizeFrameHeight is the height of the vertical border. 
		/// </summary>
		FrameHeight = 33,
		/// <summary>
		/// Minimum tracking width of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
		/// </summary>
		MinTrackWidth = 34,
		/// <summary>
		/// Minimum tracking height of a window, in pixels. The user cannot drag the window frame to a size smaller than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message
		/// </summary>
		MinTrackHeight = 35,
		/// <summary>
		/// Width of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must occur within the rectangle defined by DoubleClickWidth and DoubleClickHeight for the system to consider the two clicks a double-click
		/// </summary>
		DoubleClickWidth = 36,
		/// <summary>
		/// Height of the rectangle around the location of a first click in a double-click sequence, in pixels. The second click must occur within the rectangle defined by DoubleClickWidth and DoubleClickHeight for the system to consider the two clicks a double-click. (The two clicks must also occur within a specified time.) 
		/// </summary>
		DoubleClickHeight = 37,
		/// <summary>
		/// Width of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size IconSpacingWidth by IconSpacingHeight when arranged. This value is always greater than or equal to IconWidth
		/// </summary>
		IconSpacingWidth = 38,
		/// <summary>
		/// Height of a grid cell for items in large icon view, in pixels. Each item fits into a rectangle of size IconSpacingWidth by IconSpacingHeight when arranged. This value is always greater than or equal to IconHeight.
		/// </summary>
		IconSpacingHeight = 39,
		/// <summary>
		/// Nonzero if drop-down menus are right-aligned with the corresponding menu-bar item; zero if the menus are left-aligned.
		/// </summary>
		MenuDropAlignment = 40,
		/// <summary>
		/// Nonzero if the Microsoft Windows for Pen computing extensions are installed; zero otherwise.
		/// </summary>
		PenWindows = 41,
		/// <summary>
		/// Nonzero if User32.dll supports Dbcs; zero otherwise. (WinMe/95/98): Unicode
		/// </summary>
		DbcsEnabled = 42,
		/// <summary>
		/// Number of buttons on mouse, or zero if no mouse is installed.
		/// </summary>
		MouseButtonCount = 43,
		/// <summary>
		/// Identical Values Changed After Windows NT 4.0  
		/// </summary>
		FixedFrameWidth = DialogFrameWidth,
		/// <summary>
		/// Identical Values Changed After Windows NT 4.0
		/// </summary>
		FixedFrameHeight = DialogFrameHeight,
		/// <summary>
		/// Identical Values Changed After Windows NT 4.0
		/// </summary>
		SizeFrameWidth = FrameWidth,
		/// <summary>
		/// Identical Values Changed After Windows NT 4.0
		/// </summary>
		SizeFrameHeight = FrameHeight,
		/// <summary>
		/// Nonzero if security is present; zero otherwise.
		/// </summary>
		Secure = 44,
		/// <summary>
		/// Width of a 3-D border, in pixels. This is the 3-D counterpart of BorderWidth
		/// </summary>
		EdgeWidth = 45,
		/// <summary>
		/// Height of a 3-D border, in pixels. This is the 3-D counterpart of BorderHeight
		/// </summary>
		EdgeHeight = 46,
		/// <summary>
		/// Width of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is always greater than or equal to MinimizedWidth.
		/// </summary>
		MinSpacingWidth = 47,
		/// <summary>
		/// Height of a grid cell for a minimized window, in pixels. Each minimized window fits into a rectangle this size when arranged. This value is always greater than or equal to MinimizedHeight.
		/// </summary>
		MinSpacingHeight = 48,
		/// <summary>
		/// Recommended width of a small icon, in pixels. Small icons typically appear in window captions and in small icon view
		/// </summary>
		SmallIconWidth = 49,
		/// <summary>
		/// Recommended height of a small icon, in pixels. Small icons typically appear in window captions and in small icon view.
		/// </summary>
		SmallIconHeight = 50,
		/// <summary>
		/// Height of a small caption, in pixels
		/// </summary>
		SmallCaptionHeight = 51,
		/// <summary>
		/// Width of small caption buttons, in pixels.
		/// </summary>
		SmallSizeWidth = 52,
		/// <summary>
		/// Height of small caption buttons, in pixels.
		/// </summary>
		SmallSizeHeight = 53,
		/// <summary>
		/// Width of menu bar buttons, such as the child window close button used in the multiple document interface, in pixels.
		/// </summary>
		MenuSizeWidth = 54,
		/// <summary>
		/// Height of menu bar buttons, such as the child window close button used in the multiple document interface, in pixels.
		/// </summary>
		MenuSizeHeight = 55,
		/// <summary>
		/// Flags specifying how the system arranged minimized windows
		/// </summary>
		Arrange = 56,
		/// <summary>
		/// Width of a minimized window, in pixels.
		/// </summary>
		MinimizedWidth = 57,
		/// <summary>
		/// Height of a minimized window, in pixels.
		/// </summary>
		MinimizedHeight = 58,
		/// <summary>
		/// Default maximum width of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
		/// </summary>
		MaxTrackWidth = 59,
		/// <summary>
		/// Default maximum height of a window that has a caption and sizing borders, in pixels. This metric refers to the entire desktop. The user cannot drag the window frame to a size larger than these dimensions. A window can override this value by processing the WM_GETMINMAXINFO message.
		/// </summary>
		MaxTrackHeight = 60,
		/// <summary>
		/// Default width, in pixels, of a maximized top-level window on the primary display monitor.
		/// </summary>
		MaximizedWidth = 61,
		/// <summary>
		/// Default height, in pixels, of a maximized top-level window on the primary display monitor.
		/// </summary>
		MaximizedHeight = 62,
		/// <summary>
		/// Least significant bit is set if a network is present; otherwise, it is cleared. The other bits are reserved for future use
		/// </summary>
		Network = 63,
		/// <summary>
		/// Value that specifies how the system was started: 0-normal, 1-failsafe, 2-failsafe /w net
		/// </summary>
		CleanBoot = 67,
		/// <summary>
		/// Width of a rectangle centered on a drag point to allow for limited movement of the mouse pointer before a drag operation begins, in pixels. 
		/// </summary>
		DragWidth = 68,
		/// <summary>
		/// Height of a rectangle centered on a drag point to allow for limited movement of the mouse pointer before a drag operation begins. This value is in pixels. It allows the user to click and release the mouse button easily without unintentionally starting a drag operation.
		/// </summary>
		DragHeight = 69,
		/// <summary>
		/// Nonzero if the user requires an application to present information visually in situations where it would otherwise present the information only in audible form; zero otherwise. 
		/// </summary>
		ShowSounds = 70,
		/// <summary>
		/// Width of the default menu check-mark bitmap, in pixels.
		/// </summary>
		MenuCheckWidth = 71,
		/// <summary>
		/// Height of the default menu check-mark bitmap, in pixels.
		/// </summary>
		MenuCheckHeight = 72,
		/// <summary>
		/// Nonzero if the computer has a low-end (slow) processor; zero otherwise
		/// </summary>
		SlowMachine = 73,
		/// <summary>
		/// Nonzero if the system is enabled for Hebrew and Arabic languages, zero if not.
		/// </summary>
		MideastEnabled = 74,
		/// <summary>
		/// Nonzero if a mouse is installed; zero otherwise. This value is rarely zero, because of support for virtual mice and because some systems detect the presence of the port instead of the presence of a mouse.
		/// </summary>
		MousePresent = 19,
		/// <summary>
		/// Windows 2000 (v5.0+) Coordinate of the top of the virtual screen
		/// </summary>
		VirtualScreenX = 76,
		/// <summary>
		/// Windows 2000 (v5.0+) Coordinate of the left of the virtual screen
		/// </summary>
		VirtualScreenY = 77,
		/// <summary>
		/// Windows 2000 (v5.0+) Width of the virtual screen
		/// </summary>
		VirtualScreenWidth = 78,
		/// <summary>
		/// Windows 2000 (v5.0+) Height of the virtual screen
		/// </summary>
		VirtualScreenHeight = 79,
		/// <summary>
		/// Number of display monitors on the desktop
		/// </summary>
		MonitorCount = 80,
		/// <summary>
		/// Windows XP (v5.1+) Nonzero if all the display monitors have the same color format, zero otherwise. Note that two displays can have the same bit depth, but different color formats. For example, the red, green, and blue pixels can be encoded with different numbers of bits, or those bits can be located in different places in a pixel's color value. 
		/// </summary>
		SameDisplayFormat = 81,
		/// <summary>
		/// Windows XP (v5.1+) Nonzero if Input Method Manager/Input Method Editor features are enabled; zero otherwise
		/// </summary>
		ImmEnabled = 82,
		/// <summary>
		/// Windows XP (v5.1+) Width of the left and right edges of the focus rectangle drawn by DrawFocusRect. This value is in pixels. 
		/// </summary>
		FocusBorderWidth = 83,
		/// <summary>
		/// Windows XP (v5.1+) Height of the top and bottom edges of the focus rectangle drawn by DrawFocusRect. This value is in pixels. 
		/// </summary>
		FocusBorderHeight = 84,
		/// <summary>
		/// Nonzero if the current operating system is the Windows XP Tablet PC edition, zero if not.
		/// </summary>
		TabletPC = 86,
		/// <summary>
		/// Nonzero if the current operating system is the Windows XP, Media Center Edition, zero if not.
		/// </summary>
		MediaCenter = 87,
		/// <summary>
		/// Nonzero if a mouse with a horizontal scroll wheel is installed; otherwise 0.
		/// </summary>
		MouseHorizontalWheelPresent = 91,
		/// <summary>
		/// <para>The amount of border padding for captioned windows, in pixels.</para>
		/// <para>Windows XP/2000:  This value is not supported.</para>
		/// </summary>
		PaddedBorderWidth = 92,
		/// <summary>
		/// Windows XP (v5.1+) This system metric is used in a Terminal Services environment. If the calling process is associated with a Terminal Services client session, the return value is nonzero. If the calling process is associated with the Terminal Server console session, the return value is zero. The console session is not necessarily the physical console - see WTSGetActiveConsoleSessionId for more information. 
		/// </summary>
		RemoteSession = 0x1000,
		/// <summary>
		/// Windows XP (v5.1+) Nonzero if the current session is shutting down; zero otherwise
		/// </summary>
		ShuttingDown = 0x2000,
		/// <summary>
		/// Windows XP (v5.1+) This system metric is used in a Terminal Services environment. Its value is nonzero if the current session is remotely controlled; zero otherwise
		/// </summary>
		RemoteControl = 0x2001,
		/// <summary>
		/// Windows XP (v5.1+) This system metric is used in a Terminal Services environment. Its value is nonzero if the current session is remotely controlled; zero otherwise
		/// </summary>
		CaretBlinkingEnabled = 0x2002,
		/// <summary>
		/// <para>Nonzero if the current operating system is Windows 7 or Windows Server 2008 R2 and the Tablet PC Input service is started; otherwise, 0. The return value is a bit mask that specifies the type of digitizer input supported by the device.</para>
		/// <para>&#9;<b>Windows Server 2008, Windows Vista, and Windows XP/2000:</b> This value is not supported.</para>
		/// </summary>
		Digitizer = 94,
		/// <summary>
		/// <para>Nonzero if there are digitizers in the system; otherwise, 0.</para>
		/// <para>SM_MAXIMUMTOUCHES returns the aggregate maximum of the maximum number of contacts supported by every digitizer in the system. If the system has only single-touch digitizers, the return value is 1. If the system has multi-touch digitizers, the return value is the number of simultaneous contacts the hardware can provide.</para>
		/// <para>&#9;<b>Windows Server 2008, Windows Vista, and Windows XP/2000:</b> This value is not supported.</para>
		/// </summary>
		MaximumTouches = 95,
	}
	#endregion GetSystemMetrics() Indices
}
