using System;

namespace Tasler.Interop.Shell
{
    public static partial class PropertyKeys
    {
        public static class Audio
        {
            /// <summary>Indicates the channel count for the audio file.  Values: 1 (mono), 2 (stereo).</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Audio.ChannelCount -- PKEY_ChannelCount</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(FMTID_AudioSummaryInformation) 64440490-4C8B-11D1-8B70-080036B11A03, 7 (PIDASI_CHANNEL_COUNT)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey ChannelCount { get { return new PropertyKey(0x64440490, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 7); } }

            /// <summary>
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Audio.Compression -- PKEY_Compression</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(FMTID_AudioSummaryInformation) 64440490-4C8B-11D1-8B70-080036B11A03, 10 (PIDASI_COMPRESSION)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Compression { get { return new PropertyKey(0x64440490, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 10); } }

            /// <summary>
            /// Indicates the average data rate in Hz for the audio file in "bits per second".</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Audio.EncodingBitrate -- PKEY_EncodingBitrate</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(FMTID_AudioSummaryInformation) 64440490-4C8B-11D1-8B70-080036B11A03, 4 (PIDASI_AVG_DATA_RATE)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey EncodingBitrate { get { return new PropertyKey(0x64440490, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 4); } }

            /// <summary>
            /// Indicates the format of the audio file.</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Audio.Format -- PKEY_Format</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)  Legacy code may treat this as VT_BSTR.</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(FMTID_AudioSummaryInformation) 64440490-4C8B-11D1-8B70-080036B11A03, 2 (PIDASI_FORMAT)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey Format { get { return new PropertyKey(0x64440490, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 2); } }

            /// <summary></summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Audio.IsVariableBitRate -- PKEY_IsVariableBitRate</description></item>
            ///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
            ///   <item><term><b>Format ID:</b></term><description>E6822FEE-8C17-4D62-823C-8E9CFCBD1D5C, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey IsVariableBitRate { get { return new PropertyKey(0xE6822FEE, 0x8C17, 0x4D62, 0x82, 0x3C, 0x8E, 0x9C, 0xFC, 0xBD, 0x1D, 0x5C, 100); } }

            /// <summary></summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Audio.PeakValue -- PKEY_PeakValue</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>2579E5D0-1116-4084-BD9A-9B4F7CB4DF5E, 100</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey PeakValue { get { return new PropertyKey(0x2579E5D0, 0x1116, 0x4084, 0xBD, 0x9A, 0x9B, 0x4F, 0x7C, 0xB4, 0xDF, 0x5E, 100); } }

            /// <summary>
            /// Indicates the audio sample rate for the audio file in "samples per second".</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Audio.SampleRate -- PKEY_SampleRate</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(FMTID_AudioSummaryInformation) 64440490-4C8B-11D1-8B70-080036B11A03, 5 (PIDASI_SAMPLE_RATE)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey SampleRate { get { return new PropertyKey(0x64440490, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 5); } }

            /// <summary>
            /// Indicates the audio sample size for the audio file in "bits per sample".</summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Audio.SampleSize -- PKEY_SampleSize</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(FMTID_AudioSummaryInformation) 64440490-4C8B-11D1-8B70-080036B11A03, 6 (PIDASI_SAMPLE_SIZE)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey SampleSize { get { return new PropertyKey(0x64440490, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 6); } }

            /// <summary>
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Audio.StreamName -- PKEY_StreamName</description></item>
            ///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(FMTID_AudioSummaryInformation) 64440490-4C8B-11D1-8B70-080036B11A03, 9 (PIDASI_STREAM_NAME)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey StreamName { get { return new PropertyKey(0x64440490, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 9); } }

            /// <summary>
            /// </summary>
            /// <remarks>
            /// <list type="table">
            ///   <item><term><b>Name:     </b></term><description>System.Audio.StreamNumber -- PKEY_StreamNumber</description></item>
            ///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
            ///   <item><term><b>Format ID:</b></term><description>(FMTID_AudioSummaryInformation) 64440490-4C8B-11D1-8B70-080036B11A03, 8 (PIDASI_STREAM_NUMBER)</description></item>
            /// </list>
            /// </remarks>
            public static PropertyKey StreamNumber { get { return new PropertyKey(0x64440490, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 8); } }
        }
    }
}