
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static class AepService
		{
			/// <summary>
			/// Device Association Endpoint Service's Parent AEP Id
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepService.AepId -- PKEY_Devices_AepService_AepId</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{C9C141A9-1B4C-4F17-A9D1-F298538CADB8}, 6</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey AepId => new(0xC9C141A9, 0x1B4C, 0x4F17, 0xA9, 0xD1, 0xF2, 0x98, 0x53, 0x8C, 0xAD, 0xB8, 6);

			/// <summary>
			/// Bluetooth caching mode for the query.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepService.Bluetooth.CacheMode -- PKEY_Devices_AepService_Bluetooth_CacheMode</description></item>r
			///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9744311E-7951-4B2E-B6F0-ECB293CAC119}, 5</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Bluetooth_CacheMode => new(0x9744311E, 0x7951, 0x4B2E, 0xB6, 0xF0, 0xEC, 0xB2, 0x93, 0xCA, 0xC1, 0x19, 5);

			/// <summary>
			/// Possible discrete values for PKEY_Devices_AepService_Bluetooth_CacheMode.
			/// </summary>
			public enum BlooToothCacheModes : byte
			{
				Cached   = 0,
				Uncached = 1,
			}

			/// <summary>
			/// Bluetooth service GUID.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepService.Bluetooth.ServiceGuid -- PKEY_Devices_AepService_Bluetooth_ServiceGuid</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A399AAC7-C265-474E-B073-FFCE57721716}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Bluetooth_ServiceGuid => new(0xA399AAC7, 0xC265, 0x474E, 0xB0, 0x73, 0xFF, 0xCE, 0x57, 0x72, 0x17, 0x16, 2);

			/// <summary>
			/// Bluetooth parent device for the query.  Required for uncached queries.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepService.Bluetooth.TargetDevice -- PKEY_Devices_AepService_Bluetooth_TargetDevice</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
			///   <item><term><b>Format ID:</b></term><description>{9744311E-7951-4B2E-B6F0-ECB293CAC119}, 6</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Bluetooth_TargetDevice => new(0x9744311E, 0x7951, 0x4B2E, 0xB6, 0xF0, 0xEC, 0xB2, 0x93, 0xCA, 0xC1, 0x19, 6);

			/// <summary>
			/// Device Association Endpoint Service's Parent Container Id
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepService.ContainerId -- PKEY_Devices_AepService_ContainerId</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{71724756-3E74-4432-9B59-E7B2F668A593}, 4</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ContainerId => new(0x71724756, 0x3E74, 0x4432, 0x9B, 0x59, 0xE7, 0xB2, 0xF6, 0x68, 0xA5, 0x93, 4);

			/// <summary>
			/// Device Association Endpoint Service Friendly Name
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepService.FriendlyName -- PKEY_Devices_AepService_FriendlyName</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{71724756-3E74-4432-9B59-E7B2F668A593}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey FriendlyName => new(0x71724756, 0x3E74, 0x4432, 0x9B, 0x59, 0xE7, 0xB2, 0xF6, 0x68, 0xA5, 0x93, 2);

			/// <summary>
			/// List of interfaces that are available for this service.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepService.IoT.ServiceInterfaces -- PKEY_Devices_AepService_IoT_ServiceInterfaces</description></item>r
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{79D94E82-4D79-45AA-821A-74858B4E4CA6}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IoT_ServiceInterfaces => new(0x79D94E82, 0x4D79, 0x45AA, 0x82, 0x1A, 0x74, 0x85, 0x8B, 0x4E, 0x4C, 0xA6, 2);

			/// <summary>
			/// Whether the parent Device Association Endpoint is paired with the system or not
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepService.ParentAepIsPaired -- PKEY_Devices_AepService_ParentAepIsPaired</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{C9C141A9-1B4C-4F17-A9D1-F298538CADB8}, 7</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ParentAepIsPaired => new(0xC9C141A9, 0x1B4C, 0x4F17, 0xA9, 0xD1, 0xF2, 0x98, 0x53, 0x8C, 0xAD, 0xB8, 7);

			/// <summary>
			/// Identity of the protocol this Device Association Endpoint Service was discovered over
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepService.ProtocolId -- PKEY_Devices_AepService_ProtocolId</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{C9C141A9-1B4C-4F17-A9D1-F298538CADB8}, 5</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ProtocolId => new(0xC9C141A9, 0x1B4C, 0x4F17, 0xA9, 0xD1, 0xF2, 0x98, 0x53, 0x8C, 0xAD, 0xB8, 5);

			/// <summary>
			/// Identity of the service this Device Association Endpoint Service represents
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepService.ServiceClassId -- PKEY_Devices_AepService_ServiceClassId</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{71724756-3E74-4432-9B59-E7B2F668A593}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ServiceClassId => new(0x71724756, 0x3E74, 0x4432, 0x9B, 0x59, 0xE7, 0xB2, 0xF6, 0x68, 0xA5, 0x93, 3);

			/// <summary>
			/// Device Association Endpoint Service's Id
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepService.ServiceId -- PKEY_Devices_AepService_ServiceId</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{C9C141A9-1B4C-4F17-A9D1-F298538CADB8}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ServiceId => new(0xC9C141A9, 0x1B4C, 0x4F17, 0xA9, 0xD1, 0xF2, 0x98, 0x53, 0x8C, 0xAD, 0xB8, 2);
		}
	}
}
