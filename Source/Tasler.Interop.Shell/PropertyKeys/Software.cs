
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Software
	{
		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Software.DateLastUsed -- PKEY_Software_DateLastUsed</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>841E4F90-FF59-4D16-8947-E81BBFFAB36D, 16</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateLastUsed => new(0x841E4F90, 0xFF59, 0x4D16, 0x89, 0x47, 0xE8, 0x1B, 0xBF, 0xFA, 0xB3, 0x6D, 16);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Software.ProductName -- PKEY_Software_ProductName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSFMTID_VERSION) 0CEF7D53-FA64-11D1-A203-0000F81FEDEE, 7</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ProductName => new(0x0CEF7D53, 0xFA64, 0x11D1, 0xA2, 0x03, 0x00, 0x00, 0xF8, 0x1F, 0xED, 0xEE, 7);

		public static class EdgeGesture
		{
			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.EdgeGesture.DisableTouchWhenFullscreen -- PKEY_EdgeGesture_DisableTouchWhenFullscreen</description></item>
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{32CE38B2-2C9A-41B1-9BC5-B3784394AA44}, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey DisableTouchWhenFullscreen => new(0x32CE38B2, 0x2C9A, 0x41B1, 0x9B, 0xC5, 0xB3, 0x78, 0x43, 0x94, 0xAA, 0x44, 2);
		}
	}
}
