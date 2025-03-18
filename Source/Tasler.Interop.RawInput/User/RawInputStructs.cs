using System;
using System.Runtime.InteropServices;

namespace Tasler.Interop.RawInput.User
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RAWINPUTDEVICELIST
    {
        public nint hDevice;
        public InterfaceDeviceType dwType;

        public override bool Equals(object obj)
        {
            return obj is RAWINPUTDEVICELIST && this.hDevice == ((RAWINPUTDEVICELIST)obj).hDevice;
        }

        public override int GetHashCode()
        {
            return (int)(this.hDevice.ToInt32() ^ (this.hDevice.ToInt64() >> 32));
        }
    }

    /// <summary>
    /// Value type for raw input devices.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct RAWINPUTDEVICE
    {
        /// <summary>Top level collection Usage page for the raw input device.</summary>
        public short UsagePage;
        /// <summary>Top level collection Usage for the raw input device. </summary>
        public short Usage;
        /// <summary>Mode flag that specifies how to interpret the information provided by UsagePage and Usage.</summary>
        public RegistrationFlags Flags;
        /// <summary>Handle to the target device. If NULL, it follows the keyboard focus.</summary>
        public nint WindowHandle;
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
        public nint Device;
        /// <summary>wParam from the window message.</summary>
        public nint wParam;

        public static readonly int SizeOf = Marshal.SizeOf(typeof(RAWINPUTHEADER));
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

        public static readonly int SizeOf = Marshal.SizeOf(typeof(RAWINPUTHID));
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
    public class DeviceInfo
    {
        public int Size;
        public int DeviceType;
    }
}
