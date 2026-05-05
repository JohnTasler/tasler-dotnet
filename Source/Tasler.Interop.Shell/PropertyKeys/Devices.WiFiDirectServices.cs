
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static class WiFiDirectServices
		{
			/// <summary>
			/// Wi-Fi Direct Services Advertisement Id
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirectServices.AdvertisementId -- PKEY_Devices_WiFiDirectServices_AdvertisementId</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
			///   <item><term><b>Format ID:</b></term><description>{31B37743-7C5E-4005-93E6-E953F92B82E9}, 5</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey AdvertisementId => new(0x31B37743, 0x7C5E, 0x4005, 0x93, 0xE6, 0xE9, 0x53, 0xF9, 0x2B, 0x82, 0xE9, 5);

			/// <summary>
			/// Wi-Fi Direct Services Request Service Information
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirectServices.RequestServiceInformation -- PKEY_Devices_WiFiDirectServices_RequestServiceInformation</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{31B37743-7C5E-4005-93E6-E953F92B82E9}, 7</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey RequestServiceInformation => new(0x31B37743, 0x7C5E, 0x4005, 0x93, 0xE6, 0xE9, 0x53, 0xF9, 0x2B, 0x82, 0xE9, 7);

			/// <summary>
			/// Wi-Fi Direct Services Service Address
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirectServices.ServiceAddress -- PKEY_Devices_WiFiDirectServices_ServiceAddress</description></item>r
			///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{31B37743-7C5E-4005-93E6-E953F92B82E9}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ServiceAddress => new(0x31B37743, 0x7C5E, 0x4005, 0x93, 0xE6, 0xE9, 0x53, 0xF9, 0x2B, 0x82, 0xE9, 2);

			/// <summary>
			/// Wi-Fi Direct Services Configuration Methods
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirectServices.ServiceConfigMethods -- PKEY_Devices_WiFiDirectServices_ServiceConfigMethods</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
			///   <item><term><b>Format ID:</b></term><description>{31B37743-7C5E-4005-93E6-E953F92B82E9}, 6</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ServiceConfigMethods => new(0x31B37743, 0x7C5E, 0x4005, 0x93, 0xE6, 0xE9, 0x53, 0xF9, 0x2B, 0x82, 0xE9, 6);

			/// <summary>
			/// Wi-Fi Direct Services Service Information
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirectServices.ServiceInformation -- PKEY_Devices_WiFiDirectServices_ServiceInformation</description></item>r
			///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{31B37743-7C5E-4005-93E6-E953F92B82E9}, 4</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ServiceInformation => new(0x31B37743, 0x7C5E, 0x4005, 0x93, 0xE6, 0xE9, 0x53, 0xF9, 0x2B, 0x82, 0xE9, 4);

			/// <summary>
			/// Wi-Fi Direct Services Service Name
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirectServices.ServiceName -- PKEY_Devices_WiFiDirectServices_ServiceName</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{31B37743-7C5E-4005-93E6-E953F92B82E9}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ServiceName => new(0x31B37743, 0x7C5E, 0x4005, 0x93, 0xE6, 0xE9, 0x53, 0xF9, 0x2B, 0x82, 0xE9, 3);
		}
	}
}
