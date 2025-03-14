
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Software
	{
		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Software.DateLastUsed -- PKEY_DateLastUsed</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>841E4F90-FF59-4D16-8947-E81BBFFAB36D, 16</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateLastUsed => new PropertyKey(0x841E4F90, 0xFF59, 0x4D16, 0x89, 0x47, 0xE8, 0x1B, 0xBF, 0xFA, 0xB3, 0x6D, 16);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Software.ProductName -- PKEY_ProductName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSFMTID_VERSION) 0CEF7D53-FA64-11D1-A203-0000F81FEDEE, 7</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ProductName => new PropertyKey(0x0CEF7D53, 0xFA64, 0x11D1, 0xA2, 0x03, 0x00, 0x00, 0xF8, 0x1F, 0xED, 0xEE, 7);
	}
}
