
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static partial class Aep
		{
			public static partial class Bluetooth
			{
				public static partial class Le
				{
					/// <summary>
					/// Bluetooth LE device address type.
					/// </summary>
					/// <remarks>
					/// <list type="table">
					///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Le.AddressType -- PKEY_Devices_Aep_Bluetooth_Le_AddressType</description></item>r
					///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
					///   <item><term><b>Format ID:</b></term><description>{995EF0B0-7EB3-4A8B-B9CE-068BB3F4AF69}, 4</description></item>
					/// </list>
					/// </remarks>
					public static PropertyKey AddressType => new(0x995EF0B0, 0x7EB3, 0x4A8B, 0xB9, 0xCE, 0x06, 0x8B, 0xB3, 0xF4, 0xAF, 0x69, 4);

					/// <summary>
					/// Possible discrete values for PKEY_Devices_Aep_Bluetooth_Le_AddressType.
					/// </summary>
					public enum AddressTypes : byte
					{
						Public = 0,
						Random = 1,
					}

					//  Name:     System.Devices.Aep.Bluetooth.Le.Appearance -- PKEY_Devices_Aep_Bluetooth_Le_Appearance
					//  Type:     UInt16 -- VT_UI2
					//  Format ID: {995EF0B0-7EB3-4A8B-B9CE-068BB3F4AF69}, 1
					//
					//  Bluetooth LE device appearance.
					public static PropertyKey AppearanceValue => new(0x995EF0B0, 0x7EB3, 0x4A8B, 0xB9, 0xCE, 0x06, 0x8B, 0xB3, 0xF4, 0xAF, 0x69, 1);

					public static class Appearance
					{
						/// <summary>
						/// Bluetooth LE device appearance.
						/// </summary>
						/// <remarks>
						/// <list type="table">
						///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Le.Appearance.Category -- PKEY_Devices_Aep_Bluetooth_Le_Appearance_Category</description></item>r
						///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
						///   <item><term><b>Format ID:</b></term><description>{995EF0B0-7EB3-4A8B-B9CE-068BB3F4AF69}, 5</description></item>
						/// </list>
						/// </remarks>
						public static PropertyKey Category => new(0x995EF0B0, 0x7EB3, 0x4A8B, 0xB9, 0xCE, 0x06, 0x8B, 0xB3, 0xF4, 0xAF, 0x69, 5);

						/// <summary>
						/// Bluetooth LE device appearance.
						/// </summary>
						/// <remarks>
						/// <list type="table">
						///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Le.Appearance.Subcategory -- PKEY_Devices_Aep_Bluetooth_Le_Appearance_Subcategory</description></item>r
						///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
						///   <item><term><b>Format ID:</b></term><description>{995EF0B0-7EB3-4A8B-B9CE-068BB3F4AF69}, 6</description></item>
						/// </list>
						/// </remarks>
						public static PropertyKey Subcategory => new(0x995EF0B0, 0x7EB3, 0x4A8B, 0xB9, 0xCE, 0x06, 0x8B, 0xB3, 0xF4, 0xAF, 0x69, 6);
					}
					/// <summary>
					/// Whether the Bluetooth LE device is a call control client.
					/// </summary>
					/// <remarks>
					/// <list type="table">
					///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Le.IsCallControlClient -- PKEY_Devices_Aep_Bluetooth_Le_IsCallControlClient</description></item>r
					///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
					///   <item><term><b>Format ID:</b></term><description>{995EF0B0-7EB3-4A8B-B9CE-068BB3F4AF69}, 12</description></item>
					/// </list>
					/// </remarks>
					public static PropertyKey IsCallControlClient => new(0x995EF0B0, 0x7EB3, 0x4A8B, 0xB9, 0xCE, 0x06, 0x8B, 0xB3, 0xF4, 0xAF, 0x69, 12);

					/// <summary>
					/// Whether the Bluetooth LE device is currently advertising a connectable advertisement.
					/// </summary>
					/// <remarks>
					/// <list type="table">
					///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Le.IsConnectable -- PKEY_Devices_Aep_Bluetooth_Le_IsConnectable</description></item>r
					///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
					///   <item><term><b>Format ID:</b></term><description>{995EF0B0-7EB3-4A8B-B9CE-068BB3F4AF69}, 8</description></item>
					/// </list>
					/// </remarks>
					public static PropertyKey IsConnectable => new(0x995EF0B0, 0x7EB3, 0x4A8B, 0xB9, 0xCE, 0x06, 0x8B, 0xB3, 0xF4, 0xAF, 0x69, 8);

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
				}
			}
		}
	}
}
