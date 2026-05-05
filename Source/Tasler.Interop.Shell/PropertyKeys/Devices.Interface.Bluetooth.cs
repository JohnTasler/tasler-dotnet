
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static partial class Interface
		{
			public static class Bluetooth
			{
				/// <summary>
				/// Bluetooth device address.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Bluetooth.DeviceAddress -- PKEY_DeviceInterface_Bluetooth_DeviceAddress</description></item>r
				///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
				///   <item><term><b>Format ID:</b></term><description>{2BD67D8B-8BEB-48D5-87E0-6CDA3428040A}, 1</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey DeviceAddress => new(0x2BD67D8B, 0x8BEB, 0x48D5, 0x87, 0xE0, 0x6C, 0xDA, 0x34, 0x28, 0x04, 0x0A, 1);

				/// <summary>
				/// Bluetooth device flags.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Bluetooth.Flags -- PKEY_DeviceInterface_Bluetooth_Flags</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
				///   <item><term><b>Format ID:</b></term><description>{2BD67D8B-8BEB-48D5-87E0-6CDA3428040A}, 3</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey Flags => new(0x2BD67D8B, 0x8BEB, 0x48D5, 0x87, 0xE0, 0x6C, 0xDA, 0x34, 0x28, 0x04, 0x0A, 3);

				/// <summary>
				/// Bluetooth device last connected time.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Bluetooth.LastConnectedTime -- PKEY_DeviceInterface_Bluetooth_LastConnectedTime</description></item>r
				///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
				///   <item><term><b>Format ID:</b></term><description>{2BD67D8B-8BEB-48D5-87E0-6CDA3428040A}, 11</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey LastConnectedTime => new(0x2BD67D8B, 0x8BEB, 0x48D5, 0x87, 0xE0, 0x6C, 0xDA, 0x34, 0x28, 0x04, 0x0A, 11);

				/// <summary>
				/// Bluetooth device manufacturer.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Bluetooth.Manufacturer -- PKEY_DeviceInterface_Bluetooth_Manufacturer</description></item>r
				///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
				///   <item><term><b>Format ID:</b></term><description>{2BD67D8B-8BEB-48D5-87E0-6CDA3428040A}, 4</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey Manufacturer => new(0x2BD67D8B, 0x8BEB, 0x48D5, 0x87, 0xE0, 0x6C, 0xDA, 0x34, 0x28, 0x04, 0x0A, 4);

				/// <summary>
				/// Bluetooth device model number.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Bluetooth.ModelNumber -- PKEY_DeviceInterface_Bluetooth_ModelNumber</description></item>r
				///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
				///   <item><term><b>Format ID:</b></term><description>{2BD67D8B-8BEB-48D5-87E0-6CDA3428040A}, 5</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey ModelNumber => new(0x2BD67D8B, 0x8BEB, 0x48D5, 0x87, 0xE0, 0x6C, 0xDA, 0x34, 0x28, 0x04, 0x0A, 5);

				/// <summary>
				/// Bluetooth device product identifier.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Bluetooth.ProductId -- PKEY_DeviceInterface_Bluetooth_ProductId</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{2BD67D8B-8BEB-48D5-87E0-6CDA3428040A}, 8</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey ProductId => new(0x2BD67D8B, 0x8BEB, 0x48D5, 0x87, 0xE0, 0x6C, 0xDA, 0x34, 0x28, 0x04, 0x0A, 8);

				/// <summary>
				/// Bluetooth device product version.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Bluetooth.ProductVersion -- PKEY_DeviceInterface_Bluetooth_ProductVersion</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{2BD67D8B-8BEB-48D5-87E0-6CDA3428040A}, 9</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey ProductVersion => new(0x2BD67D8B, 0x8BEB, 0x48D5, 0x87, 0xE0, 0x6C, 0xDA, 0x34, 0x28, 0x04, 0x0A, 9);

				/// <summary>
				/// Bluetooth service GUID.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Bluetooth.ServiceGuid -- PKEY_DeviceInterface_Bluetooth_ServiceGuid</description></item>r
				///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
				///   <item><term><b>Format ID:</b></term><description>{2BD67D8B-8BEB-48D5-87E0-6CDA3428040A}, 2</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey ServiceGuid => new(0x2BD67D8B, 0x8BEB, 0x48D5, 0x87, 0xE0, 0x6C, 0xDA, 0x34, 0x28, 0x04, 0x0A, 2);

				/// <summary>
				/// Bluetooth device vendor identifier.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Bluetooth.VendorId -- PKEY_DeviceInterface_Bluetooth_VendorId</description></item>r
				///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
				///   <item><term><b>Format ID:</b></term><description>{2BD67D8B-8BEB-48D5-87E0-6CDA3428040A}, 7</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey VendorId => new(0x2BD67D8B, 0x8BEB, 0x48D5, 0x87, 0xE0, 0x6C, 0xDA, 0x34, 0x28, 0x04, 0x0A, 7);

				/// <summary>
				/// Bluetooth device vendor identifier source.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Bluetooth.VendorIdSource -- PKEY_DeviceInterface_Bluetooth_VendorIdSource</description></item>r
				///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
				///   <item><term><b>Format ID:</b></term><description>{2BD67D8B-8BEB-48D5-87E0-6CDA3428040A}, 6</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey VendorIdSource => new(0x2BD67D8B, 0x8BEB, 0x48D5, 0x87, 0xE0, 0x6C, 0xDA, 0x34, 0x28, 0x04, 0x0A, 6);
			}
		}
	}
}
