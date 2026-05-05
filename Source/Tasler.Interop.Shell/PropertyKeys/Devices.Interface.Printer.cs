
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static partial class Interface
		{
			public static class Printer
			{
				/// <summary>
				/// Printer information Printer Driver Directory.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.PrinterDriverDirectory -- PKEY_DeviceInterface_PrinterDriverDirectory</description></item>r
				///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
				///   <item><term><b>Format ID:</b></term><description>{847C66DE-B8D6-4AF9-ABC3-6F4F926BC039}, 14</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey DriverDirectory => new(0x847C66DE, 0xB8D6, 0x4AF9, 0xAB, 0xC3, 0x6F, 0x4F, 0x92, 0x6B, 0xC0, 0x39, 14);

				/// <summary>
				/// Printer information Driver Name.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.PrinterDriverName -- PKEY_DeviceInterface_PrinterDriverName</description></item>r
				///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
				///   <item><term><b>Format ID:</b></term><description>{AFC47170-14F5-498C-8F30-B0D19BE449C6}, 11</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey DriverName => new(0xAFC47170, 0x14F5, 0x498C, 0x8F, 0x30, 0xB0, 0xD1, 0x9B, 0xE4, 0x49, 0xC6, 11);

				/// <summary>
				/// Printer information Printer Enumeration Flag.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.PrinterEnumerationFlag -- PKEY_DeviceInterface_PrinterEnumerationFlag</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
				///   <item><term><b>Format ID:</b></term><description>{A00742A1-CD8C-4B37-95AB-70755587767A}, 3</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey EnumerationFlag => new(0xA00742A1, 0xCD8C, 0x4B37, 0x95, 0xAB, 0x70, 0x75, 0x55, 0x87, 0x76, 0x7A, 3);

				/// <summary>
				/// Printer information Printer Name.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.PrinterName -- PKEY_DeviceInterface_PrinterName</description></item>r
				///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
				///   <item><term><b>Format ID:</b></term><description>{0A7B84EF-0C27-463F-84EF-06C5070001BE}, 10</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey Name => new(0x0A7B84EF, 0x0C27, 0x463F, 0x84, 0xEF, 0x06, 0xC5, 0x07, 0x00, 0x01, 0xBE, 10);

				/// <summary>
				/// Printer information Port Name.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.PrinterPortName -- PKEY_DeviceInterface_PrinterPortName</description></item>r
				///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
				///   <item><term><b>Format ID:</b></term><description>{EEC7B761-6F94-41B1-949F-C729720DD13C}, 12</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey PortName => new(0xEEC7B761, 0x6F94, 0x41B1, 0x94, 0x9F, 0xC7, 0x29, 0x72, 0x0D, 0xD1, 0x3C, 12);
			}
		}
	}
}
