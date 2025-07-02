
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class RecordedTV
	{
		/// <summary>
		/// Example: 42</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.ChannelNumber -- PKEY_ChannelNumber</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 7</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ChannelNumber => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 7);

		/// <summary>
		/// Example: "Don Messick/Frank Welker/Casey Kasem/Heather North/Nicole Jaffe;;;"</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.Credits -- PKEY_Credits</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Credits => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 4);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.DateContentExpires -- PKEY_DateContentExpires</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 15</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateContentExpires => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 15);

		/// <summary>
		/// Example: "Nowhere to Hyde"</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.EpisodeName -- PKEY_EpisodeName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey EpisodeName => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 2);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.IsATSCContent -- PKEY_IsATSCContent</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 16</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsATSCContent => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 16);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.IsClosedCaptioningAvailable -- PKEY_IsClosedCaptioningAvailable</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 12</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsClosedCaptioningAvailable => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 12);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.IsDTVContent -- PKEY_IsDTVContent</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 17</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsDTVContent => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 17);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.IsHDContent -- PKEY_IsHDContent</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 18</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsHDContent => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 18);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.IsRepeatBroadcast -- PKEY_IsRepeatBroadcast</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 13</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsRepeatBroadcast => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 13);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.IsSAP -- PKEY_IsSAP</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 14</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsSAP => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 14);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.NetworkAffiliation -- PKEY_NetworkAffiliation</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>2C53C813-FB63-4E22-A1AB-0B331CA1E273, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey NetworkAffiliation => new(0x2C53C813, 0xFB63, 0x4E22, 0xA1, 0xAB, 0x0B, 0x33, 0x1C, 0xA1, 0xE2, 0x73, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.OriginalBroadcastDate -- PKEY_OriginalBroadcastDate</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>4684FE97-8765-4842-9C13-F006447B178C, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OriginalBroadcastDate => new(0x4684FE97, 0x8765, 0x4842, 0x9C, 0x13, 0xF0, 0x06, 0x44, 0x7B, 0x17, 0x8C, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.ProgramDescription -- PKEY_ProgramDescription</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ProgramDescription => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 3);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.RecordingTime -- PKEY_RecordingTime</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>A5477F61-7A82-4ECA-9DDE-98B69B2479B3, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey RecordingTime => new(0xA5477F61, 0x7A82, 0x4ECA, 0x9D, 0xDE, 0x98, 0xB6, 0x9B, 0x24, 0x79, 0xB3, 100);

		/// <summary>
		/// Example: "TOONP"</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.StationCallSign -- PKEY_StationCallSign</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D748DE2-8D38-4CC3-AC60-F009B057C557, 5</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StationCallSign => new(0x6D748DE2, 0x8D38, 0x4CC3, 0xAC, 0x60, 0xF0, 0x09, 0xB0, 0x57, 0xC5, 0x57, 5);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RecordedTV.StationName -- PKEY_StationName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>1B5439E7-EBA1-4AF8-BDD7-7AF1D4549493, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StationName => new(0x1B5439E7, 0xEBA1, 0x4AF8, 0xBD, 0xD7, 0x7A, 0xF1, 0xD4, 0x54, 0x94, 0x93, 100);
	}
}
