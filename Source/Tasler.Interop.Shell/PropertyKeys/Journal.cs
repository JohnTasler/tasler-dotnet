
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Journal
	{
		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Journal.Contacts -- PKEY_Contacts</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>DEA7C82C-1D89-4A66-9427-A4E3DEBABCB1, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Contacts => new PropertyKey(0xDEA7C82C, 0x1D89, 0x4A66, 0x94, 0x27, 0xA4, 0xE3, 0xDE, 0xBA, 0xBC, 0xB1, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Journal.EntryType -- PKEY_EntryType</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>95BEB1FC-326D-4644-B396-CD3ED90E6DDF, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey EntryType => new PropertyKey(0x95BEB1FC, 0x326D, 0x4644, 0xB3, 0x96, 0xCD, 0x3E, 0xD9, 0x0E, 0x6D, 0xDF, 100);
	}
}
