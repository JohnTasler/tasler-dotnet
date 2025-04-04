using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;
using System.Windows.Input;
using Tasler.Interop.Gdi;
using Tasler.Interop.User;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tasler.Interop.RawInput.User
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTDEVICELIST
	{
		public SafeRawInputHandle DeviceHandle;
		public InterfaceDeviceType DeviceType;

		public override bool Equals(object? obj)
		{
			return obj is RAWINPUTDEVICELIST rawInputDeviceList && DeviceHandle == rawInputDeviceList.DeviceHandle;
		}

		public override readonly int GetHashCode()
		{
			return (int)(DeviceHandle.Handle.ToInt32() ^ (DeviceHandle.Handle.ToInt64() >> 32));
		}

		public static bool operator ==(RAWINPUTDEVICELIST left, RAWINPUTDEVICELIST right) => left.Equals(right);

		public static bool operator !=(RAWINPUTDEVICELIST left, RAWINPUTDEVICELIST right) => !(left == right);
	}

	/// <summary>
	/// Defines information for the raw input devices.
	/// </summary>
	/// <remarks>
	/// If <see cref="RIDEV.NoLegacy"/> is set for a mouse or a keyboard, the system does not generate any legacy message for
	/// that device for the application. For example, if the mouse TLC is set with <see cref="RIDEV.NoLegacy"/>,
	/// <see cref="WM.LBUTTONDOWN"/> and related legacy mouse messages are not generated. Likewise, if the keyboard TLC is
	/// set with <see cref="RIDEV.NoLegacy"/>, <see cref="WM.KEYDOWN"/> and related legacy keyboard messages are not generated.
	/// If <see cref="RIDEV.Remove"/> is set and the <see cref="WindowHandle"> member is not set to NULL, then
	/// <see cref="RawInputApi.RegisterRawInputDevices" /> function will fail.
	/// </remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTDEVICE
	{
		/// <summary>
		/// <a href="https://learn.microsoft.com/en-us/windows-hardware/drivers/hid/top-level-collections">Top level collection</a>
		/// <a href="https://learn.microsoft.com/en-us/windows-hardware/drivers/hid/hid-usages#usage-page">Usage page</a>
		/// for the raw input device. See
		/// <a href="https://learn.microsoft.com/en-us/windows-hardware/drivers/hid/hid-architecture#hid-clients-supported-in-windows">
		/// HID Clients Supported in Windows</a> for details on possible values.
		/// </summary>
		public ushort UsagePage;

		/// <summary>
		/// <a href="https://learn.microsoft.com/en-us/windows-hardware/drivers/hid/top-level-collections">Top level collection</a>
		/// <a href="https://learn.microsoft.com/en-us/windows-hardware/drivers/hid/hid-usages#usage-id">Usage ID</a>
		/// for the raw input device. See
		/// <a href="https://learn.microsoft.com/en-us/windows-hardware/drivers/hid/hid-architecture#hid-clients-supported-in-windows">
		/// HID Clients Supported in Windows</a> for details on possible values.
		/// </summary>
		public ushort Usage;

		/// <summary>
		/// Mode flags that specifies how to interpret the information provided by <see cref="UsagePage"/> and <see cref="Usage"/>.
		/// It can be zero (the default) or one of the following values. By default, the operating system sends
		/// raw input from devices with the specified
		/// <a href="https://learn.microsoft.com/en-us/windows-hardware/drivers/hid/top-level-collections">top
		/// level collection</a> (TLC) to the registered application as long as it has the window focus.
		/// </summary>
		public RIDEV Flags;

		/// <summary>
		/// A handle to the target window. If NULL, raw input events follow the keyboard focus to ensure only
		/// the focused application window receives the events.
		/// </summary>
		public SafeHwnd WindowHandle;
	}

	/// <summary>
	/// Value type for a raw input header.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTHEADER
	{
		/// <summary>Type of device the input is coming from.</summary>
		public InterfaceDeviceType Type;

		/// <summary>Size of the packet of data.</summary>
		public int Size;

		/// <summary>Handle to the device sending the data.</summary>
		public SafeRawInputHandle Device;

		/// <summary>wParam from the window message.</summary>
		public nint WParam;

		public static readonly int SizeOf = Marshal.SizeOf<RAWINPUTHEADER>();
	}

	/// <summary>
	/// Value type for raw input from a mouse.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTMOUSE
	{
		/// <summary>Flags for the event.</summary>
		public MouseFlags Flags;

		/// <summary>Flags for the event.</summary>
		public MouseButtons Buttons;

		/// <summary>If the mouse wheel is moved, this will contain the delta amount.</summary>
		public short ButtonData;

		/// <summary>Raw button data.</summary>
		public int RawButtons;

		/// <summary>Relative direction of motion, depending on flags.</summary>
		public int LastX;

		/// <summary>Relative direction of motion, depending on flags.</summary>
		public int LastY;

		/// <summary>Extra information.</summary>
		public int ExtraInformation;
	}

	/// <summary>
	/// Value type for raw input from a keyboard.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTKEYBOARD
	{
		/// <summary>Scan code for key depression.</summary>
		public short MakeCode;

		/// <summary>Scan code information.</summary>
		public KeyboardFlags Flags;

		/// <summary>Reserved.</summary>
		public short Reserved;

		/// <summary>Virtual key code.</summary>
		public short /* VirtualKeys */ VirtualKey;

		/// <summary>Corresponding window message.</summary>
		public int /* WindowMessages */ Message;

		/// <summary>Extra information.</summary>
		public int ExtraInformation;
	}

	/// <summary>
	/// Value type for raw input from a HID.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTHID
	{
		/// <summary>Size of the HID data in bytes.</summary>
		public int Size;

		/// <summary>Number of HID in Data.</summary>
		public int Count;

		//      /// <summary>Data for the HID.</summary>
		//      public nint Data;

		public static readonly int SizeOf = Marshal.SizeOf<RAWINPUTHID>();
	}

	/// <summary>
	/// Value type for raw input.
	/// </summary>
	[StructLayout(LayoutKind.Explicit, Pack = 1)]
	public struct RAWINPUT
	{
		/// <summary>Header for the data.</summary>
		[FieldOffset(0)]
		public RAWINPUTHEADER Header;

		/// <summary>Mouse raw input data.</summary>
		[FieldOffset(16)]
		public RAWINPUTMOUSE Mouse;

		/// <summary>Keyboard raw input data.</summary>
		[FieldOffset(16)]
		public RAWINPUTKEYBOARD Keyboard;

		/// <summary>HID raw input data.</summary>
		[FieldOffset(16)]
		public RAWINPUTHID HID;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DeviceInfo
	{
		public int Size;
		public int DeviceType;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RID_DEVICE_INFO_MOUSE
	{
		public MouseProperties Properties;
		public uint NumberOfButtons;
		public uint SampleRate;
		[MarshalAs(UnmanagedType.Bool)]
		public bool HasHorizontalWheel;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RID_DEVICE_INFO_KEYBOARD
	{
		/// <summary>The type of keyboard.See Remarks.</summary>
		public KeyboardType Type;

		/// <summary>The vendor-specific subtype of the keyboard.See Remarks.</summary>
		public uint SubType;

		/// <summary>The scan code mode.Usually 1, which means that Scan Code Set 1 is used.See Keyboard Scan Code Specification.</summary>
		public uint KeyboardMode;

		/// <summary>The number of function keys on the keyboard.</summary>
		public uint NumberOfFunctionKeys;

		/// <summary>The number of LED indicators on the keyboard.</summary>
		public uint NumberOfIndicators;

		/// <summary>The total number of keys on the keyboard. }</summary>
		public uint NumberOfKeysTotal;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RID_DEVICE_INFO_HID
	{
		/// <summary>The vendor identifier for the HID.</summary>
		public uint VendorId;

		/// <summary>The product identifier for the HID.</summary>
		public uint ProductId;

		/// <summary>The version number for the HID.</summary>
		public uint VersionNumber;

		/// <summary>The top-level collection Usage Page for the device.</summary>
		public ushort UsagePage;

		/// <summary>The top-level collection Usage for the device.</summary>
		public ushort Usage;
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct RIDDEVICEINFO
	{
		[FieldOffset(0)]
		public uint Size = unchecked((uint)Marshal.SizeOf<RIDDEVICEINFO>());

		[FieldOffset(sizeof(uint))]
		public InterfaceDeviceType DeviceType;

		[FieldOffset(sizeof(uint) + sizeof(InterfaceDeviceType))]
		public RID_DEVICE_INFO_MOUSE MouseInfo;

		[FieldOffset(sizeof(uint) + sizeof(InterfaceDeviceType))]
		public RID_DEVICE_INFO_KEYBOARD KeyboardInfo;

		[FieldOffset(sizeof(uint) + sizeof(InterfaceDeviceType))]
		public RID_DEVICE_INFO_HID HidInfo;

		public RIDDEVICEINFO() { }
	}
}
