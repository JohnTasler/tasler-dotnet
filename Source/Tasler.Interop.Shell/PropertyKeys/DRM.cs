
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class DRM
	{
		/// <summary>
		/// Indicates when play expires for digital rights management.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DRM.DatePlayExpires -- PKEY_DatePlayExpires</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_DRM) AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED, 6 (PIDDRSI_PLAYEXPIRES)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DatePlayExpires => new PropertyKey(0xAEAC19E4, 0x89AE, 0x4508, 0xB9, 0xB7, 0xBB, 0x86, 0x7A, 0xBE, 0xE2, 0xED, 6);

		/// <summary>
		/// Indicates when play starts for digital rights management.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DRM.DatePlayStarts -- PKEY_DatePlayStarts</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_DRM) AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED, 5 (PIDDRSI_PLAYSTARTS)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DatePlayStarts => new PropertyKey(0xAEAC19E4, 0x89AE, 0x4508, 0xB9, 0xB7, 0xBB, 0x86, 0x7A, 0xBE, 0xE2, 0xED, 5);

		/// <summary>
		/// Displays the description for digital rights management.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DRM.Description -- PKEY_Description</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_DRM) AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED, 3 (PIDDRSI_DESCRIPTION)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Description => new PropertyKey(0xAEAC19E4, 0x89AE, 0x4508, 0xB9, 0xB7, 0xBB, 0x86, 0x7A, 0xBE, 0xE2, 0xED, 3);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DRM.IsProtected -- PKEY_IsProtected</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_DRM) AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED, 2 (PIDDRSI_PROTECTED)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsProtected => new PropertyKey(0xAEAC19E4, 0x89AE, 0x4508, 0xB9, 0xB7, 0xBB, 0x86, 0x7A, 0xBE, 0xE2, 0xED, 2);

		/// <summary>
		/// Indicates the play count for digital rights management.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DRM.PlayCount -- PKEY_PlayCount</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_DRM) AEAC19E4-89AE-4508-B9B7-BB867ABEE2ED, 4 (PIDDRSI_PLAYCOUNT)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PlayCount => new PropertyKey(0xAEAC19E4, 0x89AE, 0x4508, 0xB9, 0xB7, 0xBB, 0x86, 0x7A, 0xBE, 0xE2, 0xED, 4);
	}
}
