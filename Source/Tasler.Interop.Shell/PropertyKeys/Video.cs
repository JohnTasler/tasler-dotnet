
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Video
	{
		/// <summary>
		/// Indicates the level of compression for the video stream.  "Compression".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.Compression -- PKEY_Compression</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 10 (PIDVSI_COMPRESSION)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Compression => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 10);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.Director -- PKEY_Director</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSGUID_MEDIAFILESUMMARYINFORMATION) 64440492-4C8B-11D1-8B70-080036B11A03, 20 (PIDMSI_DIRECTOR)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Director => new PropertyKey(0x64440492, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 20);

		/// <summary>
		/// Indicates the data rate in "bits per second" for the video stream. "DataRate".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.EncodingBitrate -- PKEY_EncodingBitrate</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 8 (PIDVSI_DATA_RATE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey EncodingBitrate => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 8);

		/// <summary>
		/// Indicates the 4CC for the video stream.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.FourCC -- PKEY_FourCC</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 44</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FourCC => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 44);

		/// <summary>
		/// Indicates the frame height for the video stream.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.FrameHeight -- PKEY_FrameHeight</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FrameHeight => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 4);

		/// <summary>
		/// Indicates the frame rate in "frames per millisecond" for the video stream.  "FrameRate".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.FrameRate -- PKEY_FrameRate</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 6 (PIDVSI_FRAME_RATE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FrameRate => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 6);

		/// <summary>
		/// Indicates the frame width for the video stream.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.FrameWidth -- PKEY_FrameWidth</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FrameWidth => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 3);

		/// <summary>
		/// Indicates the horizontal portion of the aspect ratio. The X portion of XX:YY, like 16:9.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.HorizontalAspectRatio -- PKEY_HorizontalAspectRatio</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 42</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HorizontalAspectRatio => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 42);

		/// <summary>
		/// Indicates the sample size in bits for the video stream.  "SampleSize".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.SampleSize -- PKEY_SampleSize</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 9 (PIDVSI_SAMPLE_SIZE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SampleSize => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 9);

		/// <summary>
		/// Indicates the name for the video stream. "StreamName".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.StreamName -- PKEY_StreamName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 2 (PIDVSI_STREAM_NAME)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StreamName => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 2);

		/// <summary>
		/// "Stream Number".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.StreamNumber -- PKEY_StreamNumber</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 11 (PIDVSI_STREAM_NUMBER)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StreamNumber => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 11);

		/// <summary>
		/// Indicates the total data rate in "bits per second" for all video and audio streams.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.TotalBitrate -- PKEY_TotalBitrate</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 43 (PIDVSI_TOTAL_BITRATE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TotalBitrate => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 43);

		/// <summary>
		/// Indicates the vertical portion of the aspect ratio. The Y portion of XX:YY, like 16:9.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Video.VerticalAspectRatio -- PKEY_VerticalAspectRatio</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_VideoSummaryInformation) 64440491-4C8B-11D1-8B70-080036B11A03, 45</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey VerticalAspectRatio => new PropertyKey(0x64440491, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 45);
	}
}
