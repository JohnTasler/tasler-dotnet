
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static partial class Interface
		{
			public static class Serial
			{
				/// <summary>
				/// Serial device friendly name
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Serial.PortName -- PKEY_DeviceInterface_Serial_PortName</description></item>r
				///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
				///   <item><term><b>Format ID:</b></term><description>{4C6BF15C-4C03-4AAC-91F5-64C0F852BCF4}, 4</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey PortName => new(0x4C6BF15C, 0x4C03, 0x4AAC, 0x91, 0xF5, 0x64, 0xC0, 0xF8, 0x52, 0xBC, 0xF4, 4);

				/// <summary>
				/// Serial device USB Product Id
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Serial.UsbProductId -- PKEY_DeviceInterface_Serial_UsbProductId</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{4C6BF15C-4C03-4AAC-91F5-64C0F852BCF4}, 3</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey UsbProductId => new(0x4C6BF15C, 0x4C03, 0x4AAC, 0x91, 0xF5, 0x64, 0xC0, 0xF8, 0x52, 0xBC, 0xF4, 3);

				/// <summary>
				/// Serial device USB Vendor Id.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Serial.UsbVendorId -- PKEY_DeviceInterface_Serial_UsbVendorId</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{4C6BF15C-4C03-4AAC-91F5-64C0F852BCF4}, 2</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey UsbVendorId => new(0x4C6BF15C, 0x4C03, 0x4AAC, 0x91, 0xF5, 0x64, 0xC0, 0xF8, 0x52, 0xBC, 0xF4, 2);
			}
		}
	}
}
