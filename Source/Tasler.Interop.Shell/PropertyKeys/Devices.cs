
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		/// <summary>
		/// Printer information Printer URL.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Device.PrinterURL -- PKEY_Device_PrinterURL</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{0B48F35A-BE6E-4F17-B108-3C4073D1669A}, 15</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrinterURL => new(0x0B48F35A, 0xBE6E, 0x4F17, 0xB1, 0x08, 0x3C, 0x40, 0x73, 0xD1, 0x66, 0x9A, 15);

		/// <summary>
		/// The package family name registered as the app for this device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.AppPackageFamilyName -- PKEY_Devices_AppPackageFamilyName</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{51236583-0C4A-4FE8-B81F-166AEC13F510}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AppPackageFamilyName => new(0x51236583, 0x0C4A, 0x4FE8, 0xB8, 0x1F, 0x16, 0x6A, 0xEC, 0x13, 0xF5, 0x10, 100);

		/// <summary>
		/// Remaining battery life of the device as an integer between 0 and 100 percent.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.BatteryLife -- PKEY_Devices_BatteryLife</description></item>r
		///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 10</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BatteryLife => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 10);

		/// <summary>
		/// Remaining battery life of the device as an integer between 0 and 100 percent and the device's charging state.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.BatteryPlusCharging -- PKEY_Devices_BatteryPlusCharging</description></item>r
		///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 22</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BatteryPlusCharging => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 22);

		/// <summary>
		/// Remaining battery life of the device and the device's charging state as a string.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.BatteryPlusChargingText -- PKEY_Devices_BatteryPlusChargingText</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 23</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BatteryPlusChargingText => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 23);

		/// <summary>
		/// Singular form of device category.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Category -- PKEY_Devices_Category</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 91</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Category => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 91);

		/// <summary>
		/// Description of the category group the device belong to.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.CategoryGroup -- PKEY_Devices_CategoryGroup</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 94</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CategoryGroup => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 94);

		/// <summary>
		/// Indicates the actual raw category
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.CategoryIds -- PKEY_Devices_CategoryIds</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 90</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CategoryIds => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 90);

		/// <summary>
		/// Plural form of device category.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.CategoryPlural -- PKEY_Devices_CategoryPlural</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 92</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CategoryPlural => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 92);

		/// <summary>
		/// Enable or Disable device presence challenging behavior for AEPs
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.ChallengeAep -- PKEY_Devices_ChallengeAep</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{0774315E-B714-48EC-8DE8-8125C077AC11}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ChallengeAep => new(0x0774315E, 0xB714, 0x48EC, 0x8D, 0xE8, 0x81, 0x25, 0xC0, 0x77, 0xAC, 0x11, 2);

		/// <summary>
		/// Boolean value representing if the device is currently charging.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.ChargingState -- PKEY_Devices_ChargingState</description></item>r
		///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 11</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ChargingState => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 11);

		/// <summary>
		/// Device instance ids of children of this device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Children -- PKEY_Devices_Children</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{4340A6C5-93FA-4706-972C-7B648008A5A7}, 9</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Children => new(0x4340A6C5, 0x93FA, 0x4706, 0x97, 0x2C, 0x7B, 0x64, 0x80, 0x08, 0xA5, 0xA7, 9);

		/// <summary>
		/// Device Class Guid.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.ClassGuid -- PKEY_Devices_ClassGuid</description></item>r
		///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A45C254E-DF1C-4EFD-8020-67D146A850E0}, 10</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ClassGuid => new(0xA45C254E, 0xDF1C, 0x4EFD, 0x80, 0x20, 0x67, 0xD1, 0x46, 0xA8, 0x50, 0xE0, 10);

		/// <summary>
		/// Compatible Ids.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.CompatibleIds -- PKEY_Devices_CompatibleIds</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A45C254E-DF1C-4EFD-8020-67D146A850E0}, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CompatibleIds => new(0xA45C254E, 0xDF1C, 0x4EFD, 0x80, 0x20, 0x67, 0xD1, 0x46, 0xA8, 0x50, 0xE0, 4);

		/// <summary>
		/// Device connection state. If VARIANT_TRUE, indicates the device is currently connected to the computer.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Connected -- PKEY_Devices_Connected</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 55</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Connected => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 55);

		/// <summary>
		/// Device container ID.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.ContainerId -- PKEY_Devices_ContainerId</description></item>r
		///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
		///   <item><term><b>Format ID:</b></term><description>{8C7ED206-3F8A-4827-B3AB-AE9E1FAEFC6C}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ContainerId => new(0x8C7ED206, 0x3F8A, 0x4827, 0xB3, 0xAB, 0xAE, 0x9E, 0x1F, 0xAE, 0xFC, 0x6C, 2);

		/// <summary>
		/// Tooltip for default state
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.DefaultTooltip -- PKEY_Devices_DefaultTooltip</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{880F70A2-6082-47AC-8AAB-A739D1A300C3}, 153</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DefaultTooltip => new(0x880F70A2, 0x6082, 0x47AC, 0x8A, 0xAB, 0xA7, 0x39, 0xD1, 0xA3, 0x00, 0xC3, 153);

		/// <summary>
		/// Device Capabilities.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.DeviceCapabilities -- PKEY_Devices_DeviceCapabilities</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A45C254E-DF1C-4EFD-8020-67D146A850E0}, 17</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DeviceCapabilities => new(0xA45C254E, 0xDF1C, 0x4EFD, 0x80, 0x20, 0x67, 0xD1, 0x46, 0xA8, 0x50, 0xE0, 17);

		/// <summary>
		/// Device Characteristics.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.DeviceCharacteristics -- PKEY_Devices_DeviceCharacteristics</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A45C254E-DF1C-4EFD-8020-67D146A850E0}, 29</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DeviceCharacteristics => new(0xA45C254E, 0xDF1C, 0x4EFD, 0x80, 0x20, 0x67, 0xD1, 0x46, 0xA8, 0x50, 0xE0, 29);

		/// <summary>
		/// First line of descriptive text about the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.DeviceDescription1 -- PKEY_Devices_DeviceDescription1</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 81</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DeviceDescription1 => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 81);

		/// <summary>
		/// Second line of descriptive text about the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.DeviceDescription2 -- PKEY_Devices_DeviceDescription2</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 82</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DeviceDescription2 => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 82);

		/// <summary>
		/// Device has a problem.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.DeviceHasProblem -- PKEY_Devices_DeviceHasProblem</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{540B947E-8B40-45BC-A8A2-6A0B894CBDA2}, 6</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DeviceHasProblem => new(0x540B947E, 0x8B40, 0x45BC, 0xA8, 0xA2, 0x6A, 0x0B, 0x89, 0x4C, 0xBD, 0xA2, 6);

		/// <summary>
		/// Device instance Id.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.DeviceInstanceId -- PKEY_Devices_DeviceInstanceId</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 256</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DeviceInstanceId => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 256);

		/// <summary>
		/// Device manufacturer. Property on device object
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.DeviceManufacturer -- PKEY_Devices_DeviceManufacturer</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A45C254E-DF1C-4EFD-8020-67D146A850E0}, 13</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DeviceManufacturer => new(0xA45C254E, 0xDF1C, 0x4EFD, 0x80, 0x20, 0x67, 0xD1, 0x46, 0xA8, 0x50, 0xE0, 13);

		/// <summary>
		/// DevQuery Device Object Type
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.DevObjectType -- PKEY_Devices_DevObjectType</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{13673F42-A3D6-49F6-B4DA-AE46E0C5237C}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DevObjectType => new(0x13673F42, 0xA3D6, 0x49F6, 0xB4, 0xDA, 0xAE, 0x46, 0xE0, 0xC5, 0x23, 0x7C, 2);

		public static class DialProtocol
		{
			/// <summary>
			/// List of applications supporting DIAL protocol on the Device Association End Point
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.DialProtocol.InstalledApplications -- PKEY_Devices_DialProtocol_InstalledApplications</description></item>r
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6845CC72-1B71-48C3-AF86-B09171A19B14}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey InstalledApplications => new(0x6845CC72, 0x1B71, 0x48C3, 0xAF, 0x86, 0xB0, 0x91, 0x71, 0xA1, 0x9B, 0x14, 3);
		}

		/// <summary>
		/// Device discovery method. This indicates on what transport or physical connection the device is discovered.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.DiscoveryMethod -- PKEY_Devices_DiscoveryMethod</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 52</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DiscoveryMethod => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 52);

		/// <summary>
		/// Device friendly name.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.FriendlyName -- PKEY_Devices_FriendlyName</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 12288</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FriendlyName => new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 12288);

		/// <summary>
		/// Available functions for this device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.FunctionPaths -- PKEY_Devices_FunctionPaths</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FunctionPaths => new(0xD08DD4C0, 0x3A9E, 0x462E, 0x82, 0x90, 0x7B, 0x63, 0x6B, 0x25, 0x76, 0xB9, 3);

		/// <summary>
		/// Glyph Icon Path.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.GlyphIcon -- PKEY_Devices_GlyphIcon</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{51236583-0C4A-4FE8-B81F-166AEC13F510}, 123</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey GlyphIcon => new(0x51236583, 0x0C4A, 0x4FE8, 0xB8, 0x1F, 0x16, 0x6A, 0xEC, 0x13, 0xF5, 0x10, 123);

		/// <summary>
		/// Hardware Ids.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.HardwareIds -- PKEY_Devices_HardwareIds</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A45C254E-DF1C-4EFD-8020-67D146A850E0}, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HardwareIds => new(0xA45C254E, 0xDF1C, 0x4EFD, 0x80, 0x20, 0x67, 0xD1, 0x46, 0xA8, 0x50, 0xE0, 3);

		/// <summary>
		/// Icon Path.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Icon -- PKEY_Devices_Icon</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 57</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Icon => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 57);

		/// <summary>
		/// Device is in the local machine container.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.InLocalMachineContainer -- PKEY_Devices_InLocalMachineContainer</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{8C7ED206-3F8A-4827-B3AB-AE9E1FAEFC6C}, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey InLocalMachineContainer => new(0x8C7ED206, 0x3F8A, 0x4827, 0xB3, 0xAB, 0xAE, 0x9E, 0x1F, 0xAE, 0xFC, 0x6C, 4);

		/// <summary>
		/// Interface Class Guid.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.InterfaceClassGuid -- PKEY_Devices_InterfaceClassGuid</description></item>r
		///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
		///   <item><term><b>Format ID:</b></term><description>{026E516E-B814-414B-83CD-856D6FEF4822}, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey InterfaceClassGuid => new(0x026E516E, 0xB814, 0x414B, 0x83, 0xCD, 0x85, 0x6D, 0x6F, 0xEF, 0x48, 0x22, 4);

		/// <summary>
		/// Indicates if the interface is enabled or not.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.InterfaceEnabled -- PKEY_Devices_InterfaceEnabled</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{026E516E-B814-414B-83CD-856D6FEF4822}, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey InterfaceEnabled => new(0x026E516E, 0xB814, 0x414B, 0x83, 0xCD, 0x85, 0x6D, 0x6F, 0xEF, 0x48, 0x22, 3);

		/// <summary>
		/// Available interfaces for this device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.InterfacePaths -- PKEY_Devices_InterfacePaths</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey InterfacePaths => new(0xD08DD4C0, 0x3A9E, 0x462E, 0x82, 0x90, 0x7B, 0x63, 0x6B, 0x25, 0x76, 0xB9, 2);

		/// <summary>
		/// IP address of the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.IpAddress -- PKEY_Devices_IpAddress</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 12297</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IpAddress => new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 12297);

		/// <summary>
		/// If VARIANT_TRUE, the device is the default device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.IsDefault -- PKEY_Devices_IsDefault</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 86</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsDefault => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 86);

		/// <summary>
		/// If VARIANT_TRUE, the device is a network connected device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.IsNetworkConnected -- PKEY_Devices_IsNetworkConnected</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 85</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsNetworkConnected => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 85);

		/// <summary>
		/// If VARIANT_TRUE, the device is shared.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.IsShared -- PKEY_Devices_IsShared</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 84</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsShared => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 84);

		/// <summary>
		/// If VARIANT_TRUE, the device installer is currently installing software.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.IsSoftwareInstalling -- PKEY_Devices_IsSoftwareInstalling</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{83DA6326-97A6-4088-9453-A1923F573B29}, 9</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsSoftwareInstalling => new(0x83DA6326, 0x97A6, 0x4088, 0x94, 0x53, 0xA1, 0x92, 0x3F, 0x57, 0x3B, 0x29, 9);

		/// <summary>
		/// Indicates whether to launch Device Stage or not
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.LaunchDeviceStageFromExplorer -- PKEY_Devices_LaunchDeviceStageFromExplorer</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 77</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey LaunchDeviceStageFromExplorer => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 77);

		/// <summary>
		/// If VARIANT_TRUE, the device container represents the local machine itself.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.LocalMachine -- PKEY_Devices_LocalMachine</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 70</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey LocalMachine => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 70);

		/// <summary>
		/// Device LocationPaths.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.LocationPaths -- PKEY_Devices_LocationPaths</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{A45C254E-DF1C-4EFD-8020-67D146A850E0}, 37</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey LocationPaths => new(0xA45C254E, 0xDF1C, 0x4EFD, 0x80, 0x20, 0x67, 0xD1, 0x46, 0xA8, 0x50, 0xE0, 37);

		/// <summary>
		/// Device manufacturer.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Manufacturer -- PKEY_Devices_Manufacturer</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 8192</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Manufacturer => new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 8192);

		/// <summary>
		/// Path to metadata for the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.MetadataPath -- PKEY_Devices_MetadataPath</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 71</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MetadataPath => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 71);

		public static class MicrophoneArray
		{
			/// <summary>
			/// Geometry data for the microphone array.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.MicrophoneArray.Geometry -- PKEY_Devices_MicrophoneArray_Geometry</description></item>r
			///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A1829EA2-27EB-459E-935D-B2FAD7B07762}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Geometry => new(0xA1829EA2, 0x27EB, 0x459E, 0x93, 0x5D, 0xB2, 0xFA, 0xD7, 0xB0, 0x77, 0x62, 2);
		}

		/// <summary>
		/// Number of missed calls on the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.MissedCalls -- PKEY_Devices_MissedCalls</description></item>r
		///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 5</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MissedCalls => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 5);

		/// <summary>
		/// Model Id
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.ModelId -- PKEY_Devices_ModelId</description></item>r
		///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
		///   <item><term><b>Format ID:</b></term><description>{80D81EA6-7473-4B0C-8216-EFC11A2C4C8B}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ModelId => new(0x80D81EA6, 0x7473, 0x4B0C, 0x82, 0x16, 0xEF, 0xC1, 0x1A, 0x2C, 0x4C, 0x8B, 2);

		/// <summary>
		/// Model name of the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.ModelName -- PKEY_Devices_ModelName</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 8194</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ModelName => new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 8194);

		/// <summary>
		/// Model number of the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.ModelNumber -- PKEY_Devices_ModelNumber</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 8195</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ModelNumber => new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 8195);

		/// <summary>
		/// Tooltip for connection state
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.NetworkedTooltip -- PKEY_Devices_NetworkedTooltip</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{880F70A2-6082-47AC-8AAB-A739D1A300C3}, 152</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey NetworkedTooltip => new(0x880F70A2, 0x6082, 0x47AC, 0x8A, 0xAB, 0xA7, 0x39, 0xD1, 0xA3, 0x00, 0xC3, 152);

		/// <summary>
		/// Name of the device's network.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.NetworkName -- PKEY_Devices_NetworkName</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 7</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey NetworkName => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 7);

		/// <summary>
		/// String representing the type of the device's network.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.NetworkType -- PKEY_Devices_NetworkType</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 8</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey NetworkType => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 8);

		/// <summary>
		/// Number of new pictures on the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.NewPictures -- PKEY_Devices_NewPictures</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey NewPictures => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 4);

		/// <summary>
		/// Device Notification Property.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Notification -- PKEY_Devices_Notification</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{06704B0C-E830-4C81-9178-91E4E95A80A0}, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Notification => new(0x06704B0C, 0xE830, 0x4C81, 0x91, 0x78, 0x91, 0xE4, 0xE9, 0x5A, 0x80, 0xA0, 3);

		/// <summary>
		/// Device Notification Store.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.NotificationStore -- PKEY_Devices_NotificationStore</description></item>r
		///   <item><term><b>Type:     </b></term><description>Object -- VT_UNKNOWN</description></item>
		///   <item><term><b>Format ID:</b></term><description>{06704B0C-E830-4C81-9178-91E4E95A80A0}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey NotificationStore => new(0x06704B0C, 0xE830, 0x4C81, 0x91, 0x78, 0x91, 0xE4, 0xE9, 0x5A, 0x80, 0xA0, 2);

		/// <summary>
		/// If VARIANT_TRUE, the device is not working properly.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.NotWorkingProperly -- PKEY_Devices_NotWorkingProperly</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 83</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey NotWorkingProperly => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 83);

		/// <summary>
		/// Device paired state. If VARIANT_TRUE, indicates the device is not paired with the computer.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Paired -- PKEY_Devices_Paired</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{78C34FC8-104A-4ACA-9EA4-524D52996E57}, 56</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Paired => new(0x78C34FC8, 0x104A, 0x4ACA, 0x9E, 0xA4, 0x52, 0x4D, 0x52, 0x99, 0x6E, 0x57, 56);


		public static class Panel
		{
			/// <summary>
			/// The group that this panel belongs to
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Panel.PanelGroup -- PKEY_Devices_Panel_PanelGroup</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{8DBC9C86-97A9-4BFF-9BC6-BFE95D3E6DAD}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey PanelGroup => new(0x8DBC9C86, 0x97A9, 0x4BFF, 0x9B, 0xC6, 0xBF, 0xE9, 0x5D, 0x3E, 0x6D, 0xAD, 3);

			/// <summary>
			/// Identity of the Device Panel
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Panel.PanelId -- PKEY_Devices_Panel_PanelId</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{8DBC9C86-97A9-4BFF-9BC6-BFE95D3E6DAD}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey PanelId => new(0x8DBC9C86, 0x97A9, 0x4BFF, 0x9B, 0xC6, 0xBF, 0xE9, 0x5D, 0x3E, 0x6D, 0xAD, 2);
		}

		/// <summary>
		/// Parent device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Parent -- PKEY_Devices_Parent</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{4340A6C5-93FA-4706-972C-7B648008A5A7}, 8</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Parent => new(0x4340A6C5, 0x93FA, 0x4706, 0x97, 0x2C, 0x7B, 0x64, 0x80, 0x08, 0xA5, 0xA7, 8);

		public static class PhoneLineTransportDevice
		{
			/// <summary>
			/// Connection status of a PhoneLineTransportDevice.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.PhoneLineTransportDevice.Connected -- PKEY_Devices_PhoneLineTransportDevice_Connected</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{AECF2FE8-1D00-4FEE-8A6D-A70D719B772B}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey PhoneLineTransportDevice_Connected => new(0xAECF2FE8, 0x1D00, 0x4FEE, 0x8A, 0x6D, 0xA7, 0x0D, 0x71, 0x9B, 0x77, 0x2B, 2);
		}

		/// <summary>
		/// ACPI _PLD data for the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.PhysicalDeviceLocation -- PKEY_Devices_PhysicalDeviceLocation</description></item>r
		///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{540B947E-8B40-45BC-A8A2-6A0B894CBDA2}, 9</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PhysicalDeviceLocation => new(0x540B947E, 0x8B40, 0x45BC, 0xA8, 0xA2, 0x6A, 0x0B, 0x89, 0x4C, 0xBD, 0xA2, 9);

		/// <summary>
		/// Device playback position as a percent.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.PlaybackPositionPercent -- PKEY_Devices_PlaybackPositionPercent</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{3633DE59-6825-4381-A49B-9F6BA13A1471}, 5</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PlaybackPositionPercent => new(0x3633DE59, 0x6825, 0x4381, 0xA4, 0x9B, 0x9F, 0x6B, 0xA1, 0x3A, 0x14, 0x71, 5);

		/// <summary>
		/// Device playback state.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.PlaybackState -- PKEY_Devices_PlaybackState</description></item>r
		///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
		///   <item><term><b>Format ID:</b></term><description>{3633DE59-6825-4381-A49B-9F6BA13A1471}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PlaybackState => new(0x3633DE59, 0x6825, 0x4381, 0xA4, 0x9B, 0x9F, 0x6B, 0xA1, 0x3A, 0x14, 0x71, 2);

		/// <summary>
		/// Possible discrete values for PKEY_Devices_PlaybackState.
		/// </summary>
		public enum PlaybackStates : byte
		{
			Unknown         = 0,
			Stopped         = 1,
			Playing         = 2,
			Transitioning   = 3,
			Paused          = 4,
			RecordingPaused = 5,
			Recording       = 6,
			NoMedia         = 7,
		}

		/// <summary>
		/// Device current playback title.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.PlaybackTitle -- PKEY_Devices_PlaybackTitle</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{3633DE59-6825-4381-A49B-9F6BA13A1471}, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PlaybackTitle => new(0x3633DE59, 0x6825, 0x4381, 0xA4, 0x9B, 0x9F, 0x6B, 0xA1, 0x3A, 0x14, 0x71, 3);

		/// <summary>
		/// Device is present.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Present -- PKEY_Devices_Present</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{540B947E-8B40-45BC-A8A2-6A0B894CBDA2}, 5</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Present => new(0x540B947E, 0x8B40, 0x45BC, 0xA8, 0xA2, 0x6A, 0x0B, 0x89, 0x4C, 0xBD, 0xA2, 5);

		/// <summary>
		/// URL of a human readable webpage on the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.PresentationUrl -- PKEY_Devices_PresentationUrl</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 8198</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PresentationUrl => new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 8198);

		/// <summary>
		/// Primary category group for this device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.PrimaryCategory -- PKEY_Devices_PrimaryCategory</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 10</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrimaryCategory => new(0xD08DD4C0, 0x3A9E, 0x462E, 0x82, 0x90, 0x7B, 0x63, 0x6B, 0x25, 0x76, 0xB9, 10);

		/// <summary>
		/// Remaining playing time in 100ns units.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.RemainingDuration -- PKEY_Devices_RemainingDuration</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>{3633DE59-6825-4381-A49B-9F6BA13A1471}, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey RemainingDuration => new(0x3633DE59, 0x6825, 0x4381, 0xA4, 0x9B, 0x9F, 0x6B, 0xA1, 0x3A, 0x14, 0x71, 4);

		/// <summary>
		/// Indicates if the interface is restricted.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.RestrictedInterface -- PKEY_Devices_RestrictedInterface</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{026E516E-B814-414B-83CD-856D6FEF4822}, 6</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey RestrictedInterface => new(0x026E516E, 0xB814, 0x414B, 0x83, 0xCD, 0x85, 0x6D, 0x6F, 0xEF, 0x48, 0x22, 6);

		/// <summary>
		/// Status indicator used to indicate if the device is roaming.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Roaming -- PKEY_Devices_Roaming</description></item>r
		///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 9</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Roaming => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 9);

		/// <summary>
		/// Indicates if a device requires safe removal or not
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.SafeRemovalRequired -- PKEY_Devices_SafeRemovalRequired</description></item>r
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{AFD97640-86A3-4210-B67C-289C41AABE55}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SafeRemovalRequired => new(0xAFD97640, 0x86A3, 0x4210, 0xB6, 0x7C, 0x28, 0x9C, 0x41, 0xAA, 0xBE, 0x55, 2);

		/// <summary>
		/// Interface name for statically connected devices based on system schematics.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.SchematicName -- PKEY_Devices_SchematicName</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{026E516E-B814-414B-83CD-856D6FEF4822}, 9</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SchematicName => new(0x026E516E, 0xB814, 0x414B, 0x83, 0xCD, 0x85, 0x6D, 0x6F, 0xEF, 0x48, 0x22, 9);

		/// <summary>
		/// Endpoint address of the device service.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.ServiceAddress -- PKEY_Devices_ServiceAddress</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 16384</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ServiceAddress => new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 16384);

		/// <summary>
		/// Identifier of the device service.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.ServiceId -- PKEY_Devices_ServiceId</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{656A3BB3-ECC0-43FD-8477-4AE0404A96CD}, 16385</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ServiceId => new(0x656A3BB3, 0xECC0, 0x43FD, 0x84, 0x77, 0x4A, 0xE0, 0x40, 0x4A, 0x96, 0xCD, 16385);

		/// <summary>
		/// Tooltip for sharing state
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.SharedTooltip -- PKEY_Devices_SharedTooltip</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{880F70A2-6082-47AC-8AAB-A739D1A300C3}, 151</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SharedTooltip => new(0x880F70A2, 0x6082, 0x47AC, 0x8A, 0xAB, 0xA7, 0x39, 0xD1, 0xA3, 0x00, 0xC3, 151);

		/// <summary>
		/// Device signal strength.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.SignalStrength -- PKEY_Devices_SignalStrength</description></item>r
		///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SignalStrength => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 2);

		public static class SmartCards
		{
			/// <summary>
			/// Smart card reader kind.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.SmartCards.ReaderKind -- PKEY_Devices_SmartCards_ReaderKind</description></item>r
			///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
			///   <item><term><b>Format ID:</b></term><description>{D6B5B883-18BD-4B4D-B2EC-9E38AFFEDA82}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ReaderKind => new(0xD6B5B883, 0x18BD, 0x4B4D, 0xB2, 0xEC, 0x9E, 0x38, 0xAF, 0xFE, 0xDA, 0x82, 2);
		}

		/// <summary>
		/// Array of device status strings
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Status -- PKEY_Devices_Status</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 259</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Status => new(0xD08DD4C0, 0x3A9E, 0x462E, 0x82, 0x90, 0x7B, 0x63, 0x6B, 0x25, 0x76, 0xB9, 259);

		/// <summary>
		/// 1st line of device status.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Status1 -- PKEY_Devices_Status1</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 257</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Status1 => new(0xD08DD4C0, 0x3A9E, 0x462E, 0x82, 0x90, 0x7B, 0x63, 0x6B, 0x25, 0x76, 0xB9, 257);

		/// <summary>
		/// 2nd line of device status.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Status2 -- PKEY_Devices_Status2</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{D08DD4C0-3A9E-462E-8290-7B636B2576B9}, 258</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Status2 => new(0xD08DD4C0, 0x3A9E, 0x462E, 0x82, 0x90, 0x7B, 0x63, 0x6B, 0x25, 0x76, 0xB9, 258);

		/// <summary>
		/// Total storage capacity of the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.StorageCapacity -- PKEY_Devices_StorageCapacity</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 12</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StorageCapacity => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 12);

		/// <summary>
		/// Total free space of the storage of the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.StorageFreeSpace -- PKEY_Devices_StorageFreeSpace</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 13</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StorageFreeSpace => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 13);

		/// <summary>
		/// Total free space of the storage of the device as a percentage.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.StorageFreeSpacePercent -- PKEY_Devices_StorageFreeSpacePercent</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 14</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StorageFreeSpacePercent => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 14);

		/// <summary>
		/// Number of unread text messages on the device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.TextMessages -- PKEY_Devices_TextMessages</description></item>r
		///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TextMessages => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 3);

		/// <summary>
		/// Status indicator used to indicate if the device has voicemail.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.Voicemail -- PKEY_Devices_Voicemail</description></item>r
		///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
		///   <item><term><b>Format ID:</b></term><description>{49CD1F76-5626-4B17-A4E8-18B4AA1A2213}, 6</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Voicemail => new(0x49CD1F76, 0x5626, 0x4B17, 0xA4, 0xE8, 0x18, 0xB4, 0xAA, 0x1A, 0x22, 0x13, 6);

		/// <summary>
		/// Windows Image Acquisition (WIA) device type.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.WiaDeviceType -- PKEY_Devices_WiaDeviceType</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{6BDD1FC6-810F-11D0-BEC7-08002BE2092F}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey WiaDeviceType => new(0x6BDD1FC6, 0x810F, 0x11D0, 0xBE, 0xC7, 0x08, 0x00, 0x2B, 0xE2, 0x09, 0x2F, 2);

		public static class WiFi
		{
			/// <summary>
			/// Wi-Fi Interface Guid
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFi.InterfaceGuid -- PKEY_Devices_WiFi_InterfaceGuid</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{EF1167EB-CBFC-4341-A568-A7C91A68982C}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey InterfaceGuid => new(0xEF1167EB, 0xCBFC, 0x4341, 0xA5, 0x68, 0xA7, 0xC9, 0x1A, 0x68, 0x98, 0x2C, 2);
		}

		/// <summary>
		/// Flags for a WP8 camera device.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Devices.WinPhone8CameraFlags -- PKEY_Devices_WinPhone8CameraFlags</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{B7B4D61C-5A64-4187-A52E-B1539F359099}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey WinPhone8CameraFlags => new(0xB7B4D61C, 0x5A64, 0x4187, 0xA5, 0x2E, 0xB1, 0x53, 0x9F, 0x35, 0x90, 0x99, 2);

		public static class Wwan
		{
			/// <summary>
			/// WWAN Interface Guid
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Wwan.InterfaceGuid -- PKEY_Devices_Wwan_InterfaceGuid</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{FF1167EB-CBFC-4341-A568-A7C91A68982C}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey InterfaceGuid => new(0xFF1167EB, 0xCBFC, 0x4341, 0xA5, 0x68, 0xA7, 0xC9, 0x1A, 0x68, 0x98, 0x2C, 2);
		}
	}
}
