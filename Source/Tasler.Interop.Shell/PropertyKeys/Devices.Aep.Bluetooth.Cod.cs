
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static partial class Aep
		{
			public static partial class Bluetooth
			{
				public static class Cod
				{
					/// <summary>
					/// Bluetooth class of device major code.
					/// </summary>
					/// <remarks>
					/// <list type="table">
					///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Cod.Major -- PKEY_Devices_Aep_Bluetooth_Cod_Major</description></item>r
					///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
					///   <item><term><b>Format ID:</b></term><description>{5FBD34CD-561A-412E-BA98-478A6B0FEF1D}, 2</description></item>
					/// </list>
					/// </remarks>
					public static PropertyKey Major => new(0x5FBD34CD, 0x561A, 0x412E, 0xBA, 0x98, 0x47, 0x8A, 0x6B, 0x0F, 0xEF, 0x1D, 2);

					/// <summary>
					/// Bluetooth class of device minor code.
					/// </summary>
					/// <remarks>
					/// <list type="table">
					///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Cod.Minor -- PKEY_Devices_Aep_Bluetooth_Cod_Minor</description></item>r
					///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
					///   <item><term><b>Format ID:</b></term><description>{5FBD34CD-561A-412E-BA98-478A6B0FEF1D}, 3</description></item>
					/// </list>
					/// </remarks>
					public static PropertyKey Minor => new(0x5FBD34CD, 0x561A, 0x412E, 0xBA, 0x98, 0x47, 0x8A, 0x6B, 0x0F, 0xEF, 0x1D, 3);

					public static class Services
					{
						/// <summary>
						/// Bluetooth class of device service audio.
						/// </summary>
						/// <remarks>
						/// <list type="table">
						///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Cod.Services.Audio -- PKEY_Devices_Aep_Bluetooth_Cod_Services_Audio</description></item>r
						///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
						///   <item><term><b>Format ID:</b></term><description>{5FBD34CD-561A-412E-BA98-478A6B0FEF1D}, 10</description></item>
						/// </list>
						/// </remarks>
						public static PropertyKey Audio => new(0x5FBD34CD, 0x561A, 0x412E, 0xBA, 0x98, 0x47, 0x8A, 0x6B, 0x0F, 0xEF, 0x1D, 10);

						/// <summary>
						/// Bluetooth class of device service capturing.
						/// </summary>
						/// <remarks>
						/// <list type="table">
						///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Cod.Services.Capturing -- PKEY_Devices_Aep_Bluetooth_Cod_Services_Capturing</description></item>r
						///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
						///   <item><term><b>Format ID:</b></term><description>{5FBD34CD-561A-412E-BA98-478A6B0FEF1D}, 8</description></item>
						/// </list>
						/// </remarks>
						public static PropertyKey Capturing => new(0x5FBD34CD, 0x561A, 0x412E, 0xBA, 0x98, 0x47, 0x8A, 0x6B, 0x0F, 0xEF, 0x1D, 8);

						/// <summary>
						/// Bluetooth class of device service information
						/// </summary>
						/// <remarks>
						/// <list type="table">
						///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Cod.Services.Information -- PKEY_Devices_Aep_Bluetooth_Cod_Services_Information</description></item>r
						///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
						///   <item><term><b>Format ID:</b></term><description>{5FBD34CD-561A-412E-BA98-478A6B0FEF1D}, 12</description></item>
						/// </list>
						/// </remarks>
						public static PropertyKey Information => new(0x5FBD34CD, 0x561A, 0x412E, 0xBA, 0x98, 0x47, 0x8A, 0x6B, 0x0F, 0xEF, 0x1D, 12);

						/// <summary>
						/// Bluetooth class of device service limited discovery.
						/// </summary>
						/// <remarks>
						/// <list type="table">
						///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Cod.Services.LimitedDiscovery -- PKEY_Devices_Aep_Bluetooth_Cod_Services_LimitedDiscovery</description></item>r
						///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
						///   <item><term><b>Format ID:</b></term><description>{5FBD34CD-561A-412E-BA98-478A6B0FEF1D}, 4</description></item>
						/// </list>
						/// </remarks>
						public static PropertyKey LimitedDiscovery => new(0x5FBD34CD, 0x561A, 0x412E, 0xBA, 0x98, 0x47, 0x8A, 0x6B, 0x0F, 0xEF, 0x1D, 4);

						/// <summary>
						/// Bluetooth class of device service networking.
						/// </summary>
						/// <remarks>
						/// <list type="table">
						///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Cod.Services.Networking -- PKEY_Devices_Aep_Bluetooth_Cod_Services_Networking</description></item>r
						///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
						///   <item><term><b>Format ID:</b></term><description>{5FBD34CD-561A-412E-BA98-478A6B0FEF1D}, 6</description></item>
						/// </list>
						/// </remarks>
						public static PropertyKey Networking => new(0x5FBD34CD, 0x561A, 0x412E, 0xBA, 0x98, 0x47, 0x8A, 0x6B, 0x0F, 0xEF, 0x1D, 6);

						/// <summary>
						/// Bluetooth class of device service object transfer.
						/// </summary>
						/// <remarks>
						/// <list type="table">
						///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Cod.Services.ObjectXfer -- PKEY_Devices_Aep_Bluetooth_Cod_Services_ObjectXfer</description></item>r
						///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
						///   <item><term><b>Format ID:</b></term><description>{5FBD34CD-561A-412E-BA98-478A6B0FEF1D}, 9</description></item>
						/// </list>
						/// </remarks>
						public static PropertyKey ObjectXfer => new(0x5FBD34CD, 0x561A, 0x412E, 0xBA, 0x98, 0x47, 0x8A, 0x6B, 0x0F, 0xEF, 0x1D, 9);

						/// <summary>
						/// Bluetooth class of device service positioning.
						/// </summary>
						/// <remarks>
						/// <list type="table">
						///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Cod.Services.Positioning -- PKEY_Devices_Aep_Bluetooth_Cod_Services_Positioning</description></item>r
						///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
						///   <item><term><b>Format ID:</b></term><description>{5FBD34CD-561A-412E-BA98-478A6B0FEF1D}, 5</description></item>
						/// </list>
						/// </remarks>
						public static PropertyKey Positioning => new(0x5FBD34CD, 0x561A, 0x412E, 0xBA, 0x98, 0x47, 0x8A, 0x6B, 0x0F, 0xEF, 0x1D, 5);

						/// <summary>
						/// Bluetooth class of device service rendering.
						/// </summary>
						/// <remarks>
						/// <list type="table">
						///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Cod.Services.Rendering -- PKEY_Devices_Aep_Bluetooth_Cod_Services_Rendering</description></item>r
						///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
						///   <item><term><b>Format ID:</b></term><description>{5FBD34CD-561A-412E-BA98-478A6B0FEF1D}, 7</description></item>
						/// </list>
						/// </remarks>
						public static PropertyKey Rendering => new(0x5FBD34CD, 0x561A, 0x412E, 0xBA, 0x98, 0x47, 0x8A, 0x6B, 0x0F, 0xEF, 0x1D, 7);

						/// <summary>
						/// Bluetooth class of device service telephony.
						/// </summary>
						/// <remarks>
						/// <list type="table">
						///   <item><term><b>Name:     </b></term><description>System.Devices.Aep.Bluetooth.Cod.Services.Telephony -- PKEY_Devices_Aep_Bluetooth_Cod_Services_Telephony</description></item>r
						///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
						///   <item><term><b>Format ID:</b></term><description>{5FBD34CD-561A-412E-BA98-478A6B0FEF1D}, 11</description></item>
						/// </list>
						/// </remarks>
						public static PropertyKey Telephony => new(0x5FBD34CD, 0x561A, 0x412E, 0xBA, 0x98, 0x47, 0x8A, 0x6B, 0x0F, 0xEF, 0x1D, 11);
					}
				}
			}
		}
	}
}
