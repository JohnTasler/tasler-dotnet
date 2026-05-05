
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static class AepContainer
		{
			/// <summary>
			/// Whether one of the child Device Association Endpoints can be paired with the system or not.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.CanPair -- PKEY_Devices_AepContainer_CanPair</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{0BBA1EDE-7566-4F47-90EC-25FC567CED2A}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey CanPair => new(0x0BBA1EDE, 0x7566, 0x4F47, 0x90, 0xEC, 0x25, 0xFC, 0x56, 0x7C, 0xED, 0x2A, 3);

			/// <summary>
			/// Categories the device is part of. e.g. Printer, Camera, etc.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.Categories -- PKEY_Devices_AepContainer_Categories</description></item>r
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{0BBA1EDE-7566-4F47-90EC-25FC567CED2A}, 9</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Categories => new(0x0BBA1EDE, 0x7566, 0x4F47, 0x90, 0xEC, 0x25, 0xFC, 0x56, 0x7C, 0xED, 0x2A, 9);

			/// <summary>
			/// List of child Device Association Endpoint Identities that are part of this Device Association Endpoint Container
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.Children -- PKEY_Devices_AepContainer_Children</description></item>r
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{0BBA1EDE-7566-4F47-90EC-25FC567CED2A}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Children => new(0x0BBA1EDE, 0x7566, 0x4F47, 0x90, 0xEC, 0x25, 0xFC, 0x56, 0x7C, 0xED, 0x2A, 2);

			/// <summary>
			/// Device Association Endpoint Container's Identity
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.ContainerId -- PKEY_Devices_AepContainer_ContainerId</description></item>r
			///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
			///   <item><term><b>Format ID:</b></term><description>{0BBA1EDE-7566-4F47-90EC-25FC567CED2A}, 12</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ContainerId => new(0x0BBA1EDE, 0x7566, 0x4F47, 0x90, 0xEC, 0x25, 0xFC, 0x56, 0x7C, 0xED, 0x2A, 12);

			/// <summary>
			/// List of applications supporting DIAL protocol on the Device Association End Point Container
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.DialProtocol.InstalledApplications -- PKEY_Devices_AepContainer_DialProtocol_InstalledApplications</description></item>r
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 6</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey DialProtocol_InstalledApplications => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 6);

			/// <summary>
			/// Whether one of the child Device Association Endpoints is paired with the system or not.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.IsPaired -- PKEY_Devices_AepContainer_IsPaired</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{0BBA1EDE-7566-4F47-90EC-25FC567CED2A}, 4</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsPaired => new(0x0BBA1EDE, 0x7566, 0x4F47, 0x90, 0xEC, 0x25, 0xFC, 0x56, 0x7C, 0xED, 0x2A, 4);

			/// <summary>
			/// Whether one of the Device Association Endpoints is currently present or not
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.IsPresent -- PKEY_Devices_AepContainer_IsPresent</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{0BBA1EDE-7566-4F47-90EC-25FC567CED2A}, 11</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsPresent => new(0x0BBA1EDE, 0x7566, 0x4F47, 0x90, 0xEC, 0x25, 0xFC, 0x56, 0x7C, 0xED, 0x2A, 11);

			/// <summary>
			/// Manufacturer of the device
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.Manufacturer -- PKEY_Devices_AepContainer_Manufacturer</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{0BBA1EDE-7566-4F47-90EC-25FC567CED2A}, 6</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Manufacturer => new(0x0BBA1EDE, 0x7566, 0x4F47, 0x90, 0xEC, 0x25, 0xFC, 0x56, 0x7C, 0xED, 0x2A, 6);

			/// <summary>
			/// List of Model Ids for the device. Each Model Id is a Guid in string form.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.ModelIds -- PKEY_Devices_AepContainer_ModelIds</description></item>r
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{0BBA1EDE-7566-4F47-90EC-25FC567CED2A}, 8</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ModelIds => new(0x0BBA1EDE, 0x7566, 0x4F47, 0x90, 0xEC, 0x25, 0xFC, 0x56, 0x7C, 0xED, 0x2A, 8);

			/// <summary>
			/// Model Name of the device
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.ModelName -- PKEY_Devices_AepContainer_ModelName</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{0BBA1EDE-7566-4F47-90EC-25FC567CED2A}, 7</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ModelName => new(0x0BBA1EDE, 0x7566, 0x4F47, 0x90, 0xEC, 0x25, 0xFC, 0x56, 0x7C, 0xED, 0x2A, 7);

			/// <summary>
			/// List of Protocol Ids that have contributed to building the Device Association Endpoint Container
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.ProtocolIds -- PKEY_Devices_AepContainer_ProtocolIds</description></item>r
			///   <item><term><b>Type:     </b></term><description>Multivalue Guid -- VT_VECTOR | VT_CLSID  (For variants: VT_ARRAY | VT_CLSID)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{0BBA1EDE-7566-4F47-90EC-25FC567CED2A}, 13</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ProtocolIds => new(0x0BBA1EDE, 0x7566, 0x4F47, 0x90, 0xEC, 0x25, 0xFC, 0x56, 0x7C, 0xED, 0x2A, 13);

			/// <summary>
			/// List of Casting Uri Schemes Supported by the Device Association Endpoint Container
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportedUriSchemes -- PKEY_Devices_AepContainer_SupportedUriSchemes</description></item>r
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 5</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportedUriSchemes => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 5);

			/// <summary>
			/// Indicates if the Device Association Endpoint Container Supports Audio Casting
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportsAudio -- PKEY_Devices_AepContainer_SupportsAudio</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportsAudio => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 2);

			/// <summary>
			/// Indicates if the Device Association Endpoint Container Supports Capturing
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportsCapturing -- PKEY_Devices_AepContainer_SupportsCapturing</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 11</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportsCapturing => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 11);

			/// <summary>
			/// Indicates if the Device Association Endpoint Container Supports Image Casting
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportsImages -- PKEY_Devices_AepContainer_SupportsImages</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 4</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportsImages => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 4);

			/// <summary>
			/// Indicates if the Device Association Endpoint Container Supports Information
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportsInformation -- PKEY_Devices_AepContainer_SupportsInformation</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 14</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportsInformation => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 14);

			/// <summary>
			/// Indicates if the Device Association Endpoint Container Supports Limited Discovery
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportsLimitedDiscovery -- PKEY_Devices_AepContainer_SupportsLimitedDiscovery</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 7</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportsLimitedDiscovery => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 7);

			/// <summary>
			/// Indicates if the Device Association Endpoint Container Supports SupportsNetworking
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportsNetworking -- PKEY_Devices_AepContainer_SupportsNetworking</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 9</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportsNetworking => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 9);

			/// <summary>
			/// Indicates if the Device Association Endpoint Container Supports Object Transfer
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportsObjectTransfer -- PKEY_Devices_AepContainer_SupportsObjectTransfer</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 12</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportsObjectTransfer => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 12);

			/// <summary>
			/// Indicates if the Device Association Endpoint Container Supports Positioning
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportsPositioning -- PKEY_Devices_AepContainer_SupportsPositioning</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 8</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportsPositioning => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 8);

			/// <summary>
			/// Indicates if the Device Association Endpoint Container Supports Rendering
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportsRendering -- PKEY_Devices_AepContainer_SupportsRendering</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 10</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportsRendering => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 10);

			/// <summary>
			/// Indicates if the Device Association Endpoint Container Supports Telephony
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportsTelephony -- PKEY_Devices_AepContainer_SupportsTelephony</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 13</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportsTelephony => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 13);

			/// <summary>
			/// Indicates if the Device Association Endpoint Container Supports Video Casting
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AepContainer.SupportsVideo -- PKEY_Devices_AepContainer_SupportsVideo</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6AF55D45-38DB-4495-ACB0-D4728A3B8314}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SupportsVideo => new(0x6AF55D45, 0x38DB, 0x4495, 0xAC, 0xB0, 0xD4, 0x72, 0x8A, 0x3B, 0x83, 0x14, 3);
		}
	}
}
