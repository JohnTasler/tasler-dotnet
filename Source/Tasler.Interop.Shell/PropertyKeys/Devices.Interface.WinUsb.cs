
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static partial class Interface
		{
			public static class WinUsb
			{
				/// <summary>
				/// WinUSB device interface GUID(s) used to open a handle to the device.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.WinUsb.DeviceInterfaceClasses -- PKEY_DeviceInterface_WinUsb_DeviceInterfaceClasses</description></item>r
				///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
				///   <item><term><b>Format ID:</b></term><description>{95E127B5-79CC-4E83-9C9E-8422187B3E0E}, 7</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey DeviceInterfaceClasses => new(0x95E127B5, 0x79CC, 0x4E83, 0x9C, 0x9E, 0x84, 0x22, 0x18, 0x7B, 0x3E, 0x0E, 7);

				/// <summary>
				/// Class value from the USB device's first USB Interface Descriptor.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.WinUsb.UsbClass -- PKEY_DeviceInterface_WinUsb_UsbClass</description></item>r
				///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
				///   <item><term><b>Format ID:</b></term><description>{95E127B5-79CC-4E83-9C9E-8422187B3E0E}, 4</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey UsbClass => new(0x95E127B5, 0x79CC, 0x4E83, 0x9C, 0x9E, 0x84, 0x22, 0x18, 0x7B, 0x3E, 0x0E, 4);

				/// <summary>
				/// Product ID from the USB device's USB Device Descriptor.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.WinUsb.UsbProductId -- PKEY_DeviceInterface_WinUsb_UsbProductId</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{95E127B5-79CC-4E83-9C9E-8422187B3E0E}, 3</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey UsbProductId => new(0x95E127B5, 0x79CC, 0x4E83, 0x9C, 0x9E, 0x84, 0x22, 0x18, 0x7B, 0x3E, 0x0E, 3);

				/// <summary>
				/// Protocol value from the USB device's first USB Interface Descriptor.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.WinUsb.UsbProtocol -- PKEY_DeviceInterface_WinUsb_UsbProtocol</description></item>r
				///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
				///   <item><term><b>Format ID:</b></term><description>{95E127B5-79CC-4E83-9C9E-8422187B3E0E}, 6</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey UsbProtocol => new(0x95E127B5, 0x79CC, 0x4E83, 0x9C, 0x9E, 0x84, 0x22, 0x18, 0x7B, 0x3E, 0x0E, 6);

				/// <summary>
				/// SubClass value from the USB device's first USB Interface Descriptor.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.WinUsb.UsbSubClass -- PKEY_DeviceInterface_WinUsb_UsbSubClass</description></item>r
				///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
				///   <item><term><b>Format ID:</b></term><description>{95E127B5-79CC-4E83-9C9E-8422187B3E0E}, 5</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey UsbSubClass => new(0x95E127B5, 0x79CC, 0x4E83, 0x9C, 0x9E, 0x84, 0x22, 0x18, 0x7B, 0x3E, 0x0E, 5);

				/// <summary>
				/// Vendor ID from the USB device's USB Device Descriptor.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.WinUsb.UsbVendorId -- PKEY_DeviceInterface_WinUsb_UsbVendorId</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{95E127B5-79CC-4E83-9C9E-8422187B3E0E}, 2</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey UsbVendorId => new(0x95E127B5, 0x79CC, 0x4E83, 0x9C, 0x9E, 0x84, 0x22, 0x18, 0x7B, 0x3E, 0x0E, 2);
			}
		}
	}
}
