
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static partial class Aep
		{
			/// <summary>
			/// Identity of the Device Association Endpoint
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.AepId -- PKEY_Devices_Aep_AepId</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{3B2CE006-5E61-4FDE-BAB8-9B8AAC9B26DF}, 8</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey AepId => new(0x3B2CE006, 0x5E61, 0x4FDE, 0xBA, 0xB8, 0x9B, 0x8A, 0xAC, 0x9B, 0x26, 0xDF, 8);

			/// <summary>
			/// Whether the Device Association Endpoint can be paired with the system or not
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.CanPair -- PKEY_Devices_Aep_CanPair</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{E7C3FB29-CAA7-4F47-8C8B-BE59B330D4C5}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey CanPair => new(0xE7C3FB29, 0xCAA7, 0x4F47, 0x8C, 0x8B, 0xBE, 0x59, 0xB3, 0x30, 0xD4, 0xC5, 3);

			/// <summary>
			/// Categories the device is part of. e.g. Printer, Camera, etc.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Category -- PKEY_Devices_Aep_Category</description></item>r
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A35996AB-11CF-4935-8B61-A6761081ECDF}, 17</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Category => new(0xA35996AB, 0x11CF, 0x4935, 0x8B, 0x61, 0xA6, 0x76, 0x10, 0x81, 0xEC, 0xDF, 17);

			/// <summary>
			/// Device Association Endpoint's Parent Container Id
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.ContainerId -- PKEY_Devices_Aep_ContainerId</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{E7C3FB29-CAA7-4F47-8C8B-BE59B330D4C5}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ContainerId => new(0xE7C3FB29, 0xCAA7, 0x4F47, 0x8C, 0x8B, 0xBE, 0x59, 0xB3, 0x30, 0xD4, 0xC5, 2);

			/// <summary>
			/// Address based on the protocol of the Device Association Endpoint. IP Address for an IP device, Bluetooth address for Bluetooth device, etc.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.DeviceAddress -- PKEY_Devices_Aep_DeviceAddress</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A35996AB-11CF-4935-8B61-A6761081ECDF}, 12</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey DeviceAddress => new(0xA35996AB, 0x11CF, 0x4935, 0x8B, 0x61, 0xA6, 0x76, 0x10, 0x81, 0xEC, 0xDF, 12);

			/// <summary>
			/// Whether the device is currently connected to the system or or not
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.IsConnected -- PKEY_Devices_Aep_IsConnected</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A35996AB-11CF-4935-8B61-A6761081ECDF}, 7</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsConnected => new(0xA35996AB, 0x11CF, 0x4935, 0x8B, 0x61, 0xA6, 0x76, 0x10, 0x81, 0xEC, 0xDF, 7);

			/// <summary>
			/// Whether the Device Association Endpoint is paired with the system or not
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.IsPaired -- PKEY_Devices_Aep_IsPaired</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A35996AB-11CF-4935-8B61-A6761081ECDF}, 16</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsPaired => new(0xA35996AB, 0x11CF, 0x4935, 0x8B, 0x61, 0xA6, 0x76, 0x10, 0x81, 0xEC, 0xDF, 16);

			/// <summary>
			/// Whether the device is currently present or not
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.IsPresent -- PKEY_Devices_Aep_IsPresent</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A35996AB-11CF-4935-8B61-A6761081ECDF}, 9</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsPresent => new(0xA35996AB, 0x11CF, 0x4935, 0x8B, 0x61, 0xA6, 0x76, 0x10, 0x81, 0xEC, 0xDF, 9);

			/// <summary>
			/// Device Association Endpoint's Manufacturer
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Manufacturer -- PKEY_Devices_Aep_Manufacturer</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A35996AB-11CF-4935-8B61-A6761081ECDF}, 5</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Manufacturer => new(0xA35996AB, 0x11CF, 0x4935, 0x8B, 0x61, 0xA6, 0x76, 0x10, 0x81, 0xEC, 0xDF, 5);

			/// <summary>
			/// Device Association Endpoint's Model Id
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.ModelId -- PKEY_Devices_Aep_ModelId</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A35996AB-11CF-4935-8B61-A6761081ECDF}, 4</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ModelId => new(0xA35996AB, 0x11CF, 0x4935, 0x8B, 0x61, 0xA6, 0x76, 0x10, 0x81, 0xEC, 0xDF, 4);

			/// <summary>
			/// Device Association Endpoint's Model Name
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.ModelName -- PKEY_Devices_Aep_ModelName</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A35996AB-11CF-4935-8B61-A6761081ECDF}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ModelName => new(0xA35996AB, 0x11CF, 0x4935, 0x8B, 0x61, 0xA6, 0x76, 0x10, 0x81, 0xEC, 0xDF, 3);

			/// <summary>
			/// A bit mask that specifies which connection types should be included in the search.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.PointOfService.ConnectionTypes -- PKEY_Devices_Aep_PointOfService_ConnectionTypes</description></item>r
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>{D4BF61B3-442E-4ADA-882D-FA7B70C832D9}, 6</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey PointOfService_ConnectionTypes => new(0xD4BF61B3, 0x442E, 0x4ADA, 0x88, 0x2D, 0xFA, 0x7B, 0x70, 0xC8, 0x32, 0xD9, 6);

			/// <summary>
			/// Identity of the protocol this Device Association Endpoint was discovered over
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.ProtocolId -- PKEY_Devices_Aep_ProtocolId</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{3B2CE006-5E61-4FDE-BAB8-9B8AAC9B26DF}, 5</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ProtocolId => new(0x3B2CE006, 0x5E61, 0x4FDE, 0xBA, 0xB8, 0x9B, 0x8A, 0xAC, 0x9B, 0x26, 0xDF, 5);

			/// <summary>
			/// Signal strength of the device. Only applicable for some protocols.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.SignalStrength -- PKEY_Devices_Aep_SignalStrength</description></item>r
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A35996AB-11CF-4935-8B61-A6761081ECDF}, 6</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SignalStrength => new(0xA35996AB, 0x11CF, 0x4935, 0x8B, 0x61, 0xA6, 0x76, 0x10, 0x81, 0xEC, 0xDF, 6);
		}
	}
}
