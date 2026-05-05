
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static class DnsSd
		{
			/// <summary>
			/// Domain portion of DNS-SD service instance name. (e.g. ".local" in "myservice._http._tcp.local")
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Dnssd.Domain -- PKEY_Devices_Dnssd_Domain</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{BF79C0AB-BB74-4CEE-B070-470B5AE202EA}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Domain => new(0xBF79C0AB, 0xBB74, 0x4CEE, 0xB0, 0x70, 0x47, 0x0B, 0x5A, 0xE2, 0x02, 0xEA, 3);

			/// <summary>
			/// Complete DNS-SD service instance name, including instance, service, and domain.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Dnssd.FullName -- PKEY_Devices_Dnssd_FullName</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{BF79C0AB-BB74-4CEE-B070-470B5AE202EA}, 5</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey FullName => new(0xBF79C0AB, 0xBB74, 0x4CEE, 0xB0, 0x70, 0x47, 0x0B, 0x5A, 0xE2, 0x02, 0xEA, 5);

			/// <summary>
			/// DNS name of device is hosting the service.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Dnssd.HostName -- PKEY_Devices_Dnssd_HostName</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{BF79C0AB-BB74-4CEE-B070-470B5AE202EA}, 7</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey HostName => new(0xBF79C0AB, 0xBB74, 0x4CEE, 0xB0, 0x70, 0x47, 0x0B, 0x5A, 0xE2, 0x02, 0xEA, 7);

			/// <summary>
			/// Instance portion of DNS-SD service instance name.(e.g. "myservice" in "myservice._http._tcp.local")
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Dnssd.InstanceName -- PKEY_Devices_Dnssd_InstanceName</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{BF79C0AB-BB74-4CEE-B070-470B5AE202EA}, 4</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey InstanceName => new(0xBF79C0AB, 0xBB74, 0x4CEE, 0xB0, 0x70, 0x47, 0x0B, 0x5A, 0xE2, 0x02, 0xEA, 4);

			/// <summary>
			/// GUID for the network adapter on which to search for a service.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Dnssd.NetworkAdapterId -- PKEY_Devices_Dnssd_NetworkAdapterId</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{BF79C0AB-BB74-4CEE-B070-470B5AE202EA}, 11</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey NetworkAdapterId => new(0xBF79C0AB, 0xBB74, 0x4CEE, 0xB0, 0x70, 0x47, 0x0B, 0x5A, 0xE2, 0x02, 0xEA, 11);

			/// <summary>
			/// Port number on which the service is listening.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Dnssd.PortNumber -- PKEY_Devices_Dnssd_PortNumber</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
			///   <item><term><b>Format ID:</b></term><description>{BF79C0AB-BB74-4CEE-B070-470B5AE202EA}, 12</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey PortNumber => new(0xBF79C0AB, 0xBB74, 0x4CEE, 0xB0, 0x70, 0x47, 0x0B, 0x5A, 0xE2, 0x02, 0xEA, 12);

			/// <summary>
			/// SRV record priority field.  Not usually used.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Dnssd.Priority -- PKEY_Devices_Dnssd_Priority</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
			///   <item><term><b>Format ID:</b></term><description>{BF79C0AB-BB74-4CEE-B070-470B5AE202EA}, 9</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Priority => new(0xBF79C0AB, 0xBB74, 0x4CEE, 0xB0, 0x70, 0x47, 0x0B, 0x5A, 0xE2, 0x02, 0xEA, 9);

			/// <summary>
			/// Service type portion of DNS-SD service instance name. (e.g. "_http._tcp" in "myservice._http._tcp.local")
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Dnssd.ServiceName -- PKEY_Devices_Dnssd_ServiceName</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{BF79C0AB-BB74-4CEE-B070-470B5AE202EA}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ServiceName => new(0xBF79C0AB, 0xBB74, 0x4CEE, 0xB0, 0x70, 0x47, 0x0B, 0x5A, 0xE2, 0x02, 0xEA, 2);

			/// <summary>
			/// Text data associated with the service instance.  Each string is typically a key-value pair, separated by "=".
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Dnssd.TextAttributes -- PKEY_Devices_Dnssd_TextAttributes</description></item>r
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{BF79C0AB-BB74-4CEE-B070-470B5AE202EA}, 6</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey TextAttributes => new(0xBF79C0AB, 0xBB74, 0x4CEE, 0xB0, 0x70, 0x47, 0x0B, 0x5A, 0xE2, 0x02, 0xEA, 6);

			/// <summary>
			/// SRV record Time-To-Live field.  Not usually used.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Dnssd.Ttl -- PKEY_Devices_Dnssd_Ttl</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
			///   <item><term><b>Format ID:</b></term><description>{BF79C0AB-BB74-4CEE-B070-470B5AE202EA}, 10</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Ttl => new(0xBF79C0AB, 0xBB74, 0x4CEE, 0xB0, 0x70, 0x47, 0x0B, 0x5A, 0xE2, 0x02, 0xEA, 10);

			/// <summary>
			/// SRV record weight field.  Not usually used.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Dnssd.Weight -- PKEY_Devices_Dnssd_Weight</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
			///   <item><term><b>Format ID:</b></term><description>{BF79C0AB-BB74-4CEE-B070-470B5AE202EA}, 8</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Weight => new(0xBF79C0AB, 0xBB74, 0x4CEE, 0xB0, 0x70, 0x47, 0x0B, 0x5A, 0xE2, 0x02, 0xEA, 8);
		}
	}
}
