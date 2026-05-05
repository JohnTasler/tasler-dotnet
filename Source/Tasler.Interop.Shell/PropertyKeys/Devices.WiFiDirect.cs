
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{

		public static class WiFiDirect
		{
			/// <summary>
			/// Wi-Fi Direct Device Address
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.DeviceAddress -- PKEY_Devices_WiFiDirect_DeviceAddress</description></item>r
			///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 13</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey DeviceAddress => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 13);

			/// <summary>
			/// Wi-Fi Direct Group Id
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.GroupId -- PKEY_Devices_WiFiDirect_GroupId</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 4</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey GroupId => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 4);

			/// <summary>
			/// Indicates full set of Information Elements provided by the Wi-Fi Direct Device
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.InformationElements -- PKEY_Devices_WiFiDirect_InformationElements</description></item>r
			///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 12</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey InformationElements => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 12);

			/// <summary>
			/// Wi-Fi Direct Interface Address
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.InterfaceAddress -- PKEY_Devices_WiFiDirect_InterfaceAddress</description></item>r
			///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey InterfaceAddress => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 2);

			/// <summary>
			/// Wi-Fi Direct Interface GUID
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.InterfaceGuid -- PKEY_Devices_WiFiDirect_InterfaceGuid</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey InterfaceGuid => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 3);

			/// <summary>
			/// Indicates Wi-Fi Direct Device's Connectivity State
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.IsConnected -- PKEY_Devices_WiFiDirect_IsConnected</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 5</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsConnected => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 5);

			/// <summary>
			/// Indicates if Wi-Fi Direct Device is a legacy device
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.IsLegacyDevice -- PKEY_Devices_WiFiDirect_IsLegacyDevice</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 7</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsLegacyDevice => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 7);

			/// <summary>
			/// Indicates if link content protection is supported by the Wi-Fi Direct Device if it is Miracast capable
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.IsMiracastLcpSupported -- PKEY_Devices_WiFiDirect_IsMiracastLcpSupported</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 9</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsMiracastLcpSupported => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 9);

			/// <summary>
			/// Indicates Wi-Fi Direct Device's Current Visibility
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.IsVisible -- PKEY_Devices_WiFiDirect_IsVisible</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 6</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsVisible => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 6);

			/// <summary>
			/// Indicates version of Miracast protocol if Wi-Fi Direct Device is Miracast capable
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.MiracastVersion -- PKEY_Devices_WiFiDirect_MiracastVersion</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 8</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey MiracastVersion => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 8);

			/// <summary>
			/// Indicates services supported by the Wi-Fi Direct Device
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.Services -- PKEY_Devices_WiFiDirect_Services</description></item>r
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 10</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Services => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 10);

			/// <summary>
			/// Wi-Fi Direct device's channel list
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.WiFiDirect.SupportedChannelList -- PKEY_Devices_WiFiDirect_SupportedChannelList</description></item>r
			///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{1506935D-E3E7-450F-8637-82233EBE5F6E}, 11</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportedChannelList => new(0x1506935D, 0xE3E7, 0x450F, 0x86, 0x37, 0x82, 0x23, 0x3E, 0xBE, 0x5F, 0x6E, 11);
		}
	}
}
