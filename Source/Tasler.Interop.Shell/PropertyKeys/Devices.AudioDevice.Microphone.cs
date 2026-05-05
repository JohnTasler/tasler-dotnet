
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Devices
	{
		public static class AudioDevice
		{
			public static class Microphone
			{
				/// <summary>
				/// Equalization coefficients for Microphone. Array of 960 DOUBLE frequency-domain gain
				/// coefficients to be applied by effect pack processing for microphone equalization, in dB.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.Devices.AudioDevice.Microphone.EqCoefficientsDb -- PKEY_Devices_AudioDevice_Microphone_EqCoefficientsDb</description></item>r
				///   <item><term><b>Type:     </b></term><description>DoubleVector -- VT_VECTOR | VT_R8  (For variants: VT_ARRAY | VT_R8)</description></item>
				///   <item><term><b>Format ID:</b></term><description>{8943B373-388C-4395-B557-BC6DBAFFAFDB}, 7</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey EqCoefficientsDb => new(0x8943B373, 0x388C, 0x4395, 0xB5, 0x57, 0xBC, 0x6D, 0xBA, 0xFF, 0xAF, 0xDB, 7);

				/// <summary>
				/// Far field capability of the microphone. If VARIANT_TRUE the microphone element will detect far field sound.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.Devices.AudioDevice.Microphone.IsFarField -- PKEY_Devices_AudioDevice_Microphone_IsFarField</description></item>r
				///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
				///   <item><term><b>Format ID:</b></term><description>{8943B373-388C-4395-B557-BC6DBAFFAFDB}, 6</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey IsFarField => new(0x8943B373, 0x388C, 0x4395, 0xB5, 0x57, 0xBC, 0x6D, 0xBA, 0xFF, 0xAF, 0xDB, 6);

				/// <summary>
				/// Sensitivity information in dBFS for a microphone device.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.Devices.AudioDevice.Microphone.SensitivityInDbfs -- PKEY_Devices_AudioDevice_Microphone_SensitivityInDbfs</description></item>r
				///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
				///   <item><term><b>Format ID:</b></term><description>{8943B373-388C-4395-B557-BC6DBAFFAFDB}, 3</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey SensitivityInDbfs => new(0x8943B373, 0x388C, 0x4395, 0xB5, 0x57, 0xBC, 0x6D, 0xBA, 0xFF, 0xAF, 0xDB, 3);

				/// <summary>
				/// Sensitivity information in dBFS for a microphone device, measured after fixed hardware gain (if available). Assumes 0dB software gain
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.Devices.AudioDevice.Microphone.SensitivityInDbfs2 -- PKEY_Devices_AudioDevice_Microphone_SensitivityInDbfs2</description></item>r
				///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
				///   <item><term><b>Format ID:</b></term><description>{8943B373-388C-4395-B557-BC6DBAFFAFDB}, 5</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey SensitivityInDbfs2 => new(0x8943B373, 0x388C, 0x4395, 0xB5, 0x57, 0xBC, 0x6D, 0xBA, 0xFF, 0xAF, 0xDB, 5);

				/// <summary>
				/// Signal to noise ratio information in dB for a microphone device.
				/// </summary>
				/// <remarks>
				/// <list type="table">
				///   <item><term><b>Name:     </b></term><description>System.Devices.AudioDevice.Microphone.SignalToNoiseRatioInDb -- PKEY_Devices_AudioDevice_Microphone_SignalToNoiseRatioInDb</description></item>r
				///   <item><term><b>Type:     </b></term><description>Double -- VT_R8</description></item>
				///   <item><term><b>Format ID:</b></term><description>{8943B373-388C-4395-B557-BC6DBAFFAFDB}, 4</description></item>
				/// </list>
				/// </remarks>
				public static PropertyKey SignalToNoiseRatioInDb => new(0x8943B373, 0x388C, 0x4395, 0xB5, 0x57, 0xBC, 0x6D, 0xBA, 0xFF, 0xAF, 0xDB, 4);
			}

			/// <summary>
			/// Raw processing mode support for the audio device. If VARIANT_TRUE the device supports raw processing mode.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AudioDevice.RawProcessingSupported -- PKEY_Devices_AudioDevice_RawProcessingSupported</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{8943B373-388C-4395-B557-BC6DBAFFAFDB}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey RawProcessingSupported => new(0x8943B373, 0x388C, 0x4395, 0xB5, 0x57, 0xBC, 0x6D, 0xBA, 0xFF, 0xAF, 0xDB, 2);

			/// <summary>
			/// Speech mode support for the audio device. If VARIANT_TRUE the device supports speech mode.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Devices.AudioDevice.SpeechProcessingSupported -- PKEY_Devices_AudioDevice_SpeechProcessingSupported</description></item>r
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{FB1DE864-E06D-47F4-82A6-8A0AEF44493C}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SpeechProcessingSupported => new(0xFB1DE864, 0xE06D, 0x47F4, 0x82, 0xA6, 0x8A, 0x0A, 0xEF, 0x44, 0x49, 0x3C, 2);
		}
	}
}
