
namespace Tasler.Interop.RawInput.User;

/// <summary>
/// Enumeration containing the type of device the raw input is coming from.
/// </summary>
public enum InterfaceDeviceType
{
	/// <summary>Mouse input.</summary>
	Mouse = 0,
	/// <summary>Keyboard input.</summary>
	Keyboard = 1,
	/// <summary>Another device that is not a keyboard or a mouse.</summary>
	HID = 2
}

/// <summary>
/// Enumeration containing flags for a raw input device.
/// </summary>
[Flags]
public enum RIDEV : uint
{
	/// <summary>No flags.</summary>
	Default = 0,

	/// <summary>If set, this removes the top level collection from the inclusion list. This tells the operating system to stop reading from a device which matches the top level collection.</summary>
	Remove       = 0x00000001,

	/// <summary>If set, this specifies the top level collections to exclude when reading a complete usage page. This flag only affects a TLC whose usage page is already specified with PageOnly.</summary>
	Exclude      = 0x00000010,

	/// <summary>If set, this specifies all devices whose top level collection is from the specified usUsagePage. Note that Usage must be zero. To exclude a particular top level collection, use Exclude.</summary>
	PageOnly     = 0x00000020,

	/// <summary>If set, this prevents any devices specified by UsagePage or Usage from generating legacy messages. This is only for the mouse and keyboard.</summary>
	NoLegacy     = 0x00000030,

	/// <summary>If set, this enables the caller to receive the input even when the caller is not in the foreground. Note that WindowHandle must be specified.</summary>
	InputSink    = 0x00000100,

	/// <summary>If set, the mouse button click does not activate the other window.</summary>
	CaptureMouse = 0x00000200,

	/// <summary>If set, the application-defined keyboard device hotkeys are not handled. However, the system hotkeys; for example, ALT+TAB and CTRL+ALT+DEL, are still handled. By default, all keyboard hotkeys are handled. NoHotKeys can be specified even if NoLegacy is not specified and WindowHandle is NULL.</summary>
#pragma warning disable IDE0079 // Remove unnecessary suppression
#pragma warning disable CA1069 // Enums values should not be duplicated
	NoHotKeys    = 0x00000200,
#pragma warning restore CA1069 // Enums values should not be duplicated
#pragma warning restore IDE0079 // Remove unnecessary suppression

	/// <summary>If set, application keys are handled.  NoLegacy must be specified.  Keyboard only.</summary>
	AppKeys      = 0x00000400,

	/// <summary>If set, this enables the caller to receive input in the background only if the foreground application does not process it. In other words, if the foreground application is not registered for raw input, then the background application that is registered will receive the input.</summary>
	ExInputSink  = 0x00001000,

	/// <summary>If set, this enables the caller to receive WM_INPUT_DEVICE_CHANGE notifications for device arrival and device removal.</summary>
	DevNotify    = 0x00002000,
}

/// <summary>
/// Enumeration contanining the command types to issue.
/// </summary>
public enum Command
{
	/// <summary>Get input data.</summary>
	Input = 0x10000003,
	/// <summary>Get header data.</summary>
	Header = 0x10000005
}

public enum DeviceInfoItem
{
	/// <summary>pData points to the previously parsed data.</summary>
	PreparsedData = 0x20000005,
	/// <summary>pData points to a string that contains the device name. For this uiCommand only, the value in pcbSize is the character count (not the byte count).</summary>
	DeviceName = 0x20000007,
	/// <summary>pData points to a <see cref="T:DeviceInfo"/> structure.</summary>
	DeviceInfo = 0x2000000B,
}

/// <summary>
/// Enumeration containing flags for raw keyboard input.
/// </summary>
[Flags]
public enum KeyboardFlags : ushort
{
	/// <summary>The key is down.</summary>
	KeyMake = 0,
	/// <summary>The key is up.</summary>
	KeyBreak = 1,
	/// <summary>This is the left version of the key.</summary>
	KeyE0 = 2,
	/// <summary>This is the right version of the key.</summary>
	KeyE1 = 4,
}

/// <summary>
/// Enumeration containing the flags for raw mouse data.
/// </summary>
[Flags]
public enum MouseFlags : ushort
{
	/// <summary>Relative to the last position.</summary>
	MoveRelative = 0,
	/// <summary>Absolute positioning.</summary>
	MoveAbsolute = 1,
	/// <summary>Coordinate data is mapped to a virtual desktop.</summary>
	VirtualDesktop = 2,
	/// <summary>Attributes for the mouse have changed.</summary>
	AttributesChanged = 4
}

/// <summary>
/// Enumeration containing the button data for raw mouse input.
/// </summary>
[Flags]
public enum MouseButtons : ushort
{
	/// <summary>No button.</summary>
	None = 0,
	/// <summary>Left (button 1) down.</summary>
	LeftDown = 0x0001,
	/// <summary>Left (button 1) up.</summary>
	LeftUp = 0x0002,
	/// <summary>Right (button 2) down.</summary>
	RightDown = 0x0004,
	/// <summary>Right (button 2) up.</summary>
	RightUp = 0x0008,
	/// <summary>Middle (button 3) down.</summary>
	MiddleDown = 0x0010,
	/// <summary>Middle (button 3) up.</summary>
	MiddleUp = 0x0020,
	/// <summary>Button 4 down.</summary>
	Button4Down = 0x0040,
	/// <summary>Button 4 up.</summary>
	Button4Up = 0x0080,
	/// <summary>Button 5 down.</summary>
	Button5Down = 0x0100,
	/// <summary>Button 5 up.</summary>
	Button5Up = 0x0200,
	/// <summary>Mouse wheel moved.</summary>
	MouseWheel = 0x0400
}

[Flags]
public enum MouseProperties : uint
{
	/// <summary>HID mouse</summary
	MouseHIDHardware       = 0x0080,

	/// <summary>HID wheel mouse</summary
	WheelmouseHIDHardware  = 0x0100,

	/// <summary>Mouse with horizontal wheel</summary
	HorizontalWheelPresent = 0x8000,
}

public enum KeyboardType
{
	/// <summary>Enhanced 101- or 102-key keyboards(and compatibles)</summary>
	Enhanced = 0x4,

	/// <summary>Japanese Keyboard</summary>
	Japanese = 0x7,

	/// <summary>Korean Keyboard</summary>
	Korean = 0x8,

	/// <summary>Unknown type or HID keyboard</summary>
	Unknown = 0x51,
}

