
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static partial class Interface
		{
			public static class Proximity
			{
				/// <summary>
				/// Indicates whether the device supports NFC communications (NDEF).
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.DeviceInterface.Proximity.SupportsNfc -- PKEY_DeviceInterface_Proximity_SupportsNfc</description></item>r
				///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
				///   <item><term><b>Format ID:</b></term><description>{FB3842CD-9E2A-4F83-8FCC-4B0761139AE9}, 2</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey SupportsNfc => new(0xFB3842CD, 0x9E2A, 0x4F83, 0x8F, 0xCC, 0x4B, 0x07, 0x61, 0x13, 0x9A, 0xE9, 2);
			}
		}
	}
}
