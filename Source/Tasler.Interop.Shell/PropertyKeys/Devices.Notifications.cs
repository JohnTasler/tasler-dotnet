
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{

		public static class Notifications
		{
			/// <summary>
			/// Device Low Battery Notification.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Notifications.LowBattery -- PKEY_Devices_Notifications_LowBattery</description></item>r
			///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
			///   <item><term><b>Format ID:</b></term><description>{C4C07F2B-8524-4E66-AE3A-A6235F103BEB}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey LowBattery => new(0xC4C07F2B, 0x8524, 0x4E66, 0xAE, 0x3A, 0xA6, 0x23, 0x5F, 0x10, 0x3B, 0xEB, 2);

			/// <summary>
			/// Device Missed Call Notification.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Notifications.MissedCall -- PKEY_Devices_Notifications_MissedCall</description></item>r
			///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
			///   <item><term><b>Format ID:</b></term><description>{6614EF48-4EFE-4424-9EDA-C79F404EDF3E}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey MissedCall => new(0x6614EF48, 0x4EFE, 0x4424, 0x9E, 0xDA, 0xC7, 0x9F, 0x40, 0x4E, 0xDF, 0x3E, 2);

			/// <summary>
			/// Device New Message Notification.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Notifications.NewMessage -- PKEY_Devices_Notifications_NewMessage</description></item>r
			///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
			///   <item><term><b>Format ID:</b></term><description>{2BE9260A-2012-4742-A555-F41B638B7DCB}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey NewMessage => new(0x2BE9260A, 0x2012, 0x4742, 0xA5, 0x55, 0xF4, 0x1B, 0x63, 0x8B, 0x7D, 0xCB, 2);

			/// <summary>
			/// Device Voicemail Notification.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Notifications.NewVoicemail -- PKEY_Devices_Notifications_NewVoicemail</description></item>r
			///   <item><term><b>Type:     </b></term><description>Byte -- VT_UI1</description></item>
			///   <item><term><b>Format ID:</b></term><description>{59569556-0A08-4212-95B9-FAE2AD6413DB}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey NewVoicemail => new(0x59569556, 0x0A08, 0x4212, 0x95, 0xB9, 0xFA, 0xE2, 0xAD, 0x64, 0x13, 0xDB, 2);

			/// <summary>
			/// Device Storage Full Notification.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Notifications.StorageFull -- PKEY_Devices_Notifications_StorageFull</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey StorageFull => new(0xA0E00EE1, 0xF0C7, 0x4D41, 0xB8, 0xE7, 0x26, 0xA7, 0xBD, 0x8D, 0x38, 0xB0, 2);

			/// <summary>
			/// Link Text for the Device Storage Full Notification.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.Notifications.StorageFullLinkText -- PKEY_Devices_Notifications_StorageFullLinkText</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
			///   <item><term><b>Format ID:</b></term><description>{A0E00EE1-F0C7-4D41-B8E7-26A7BD8D38B0}, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey StorageFullLinkText => new(0xA0E00EE1, 0xF0C7, 0x4D41, 0xB8, 0xE7, 0x26, 0xA7, 0xBD, 0x8D, 0x38, 0xB0, 3);
		}
	}
}
