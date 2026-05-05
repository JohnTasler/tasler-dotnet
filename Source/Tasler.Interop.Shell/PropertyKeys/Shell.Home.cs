namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Shell
	{
		public static class Home
		{
			/// <summary>
			/// The group the element belongs to: frequent, pinned, recent, recommendations, or shared.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Home.Grouping -- PKEY_Home_Grouping</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
			///   <item><term><b>Format ID:</b></term><description>{30C8EEF4-A832-41E2-AB32-E3C3CA28FD29}, 2</description></item>
			/// </list>
			/// <seealso cref="HomeGrouping"/>
			/// </remarks>
			public static PropertyKey Grouping => new(0x30C8EEF4, 0xA832, 0x41E2, 0xAB, 0x32, 0xE3, 0xC3, 0xCA, 0x28, 0xFD, 0x29, 2);

			/// <summary>Possible discrete values for PKEY_Home_Grouping.</summary>
			public enum HomeGrouping
			{
				Unspecified     = 0,
				Frequent        = 1,
				Pinned          = 2,
				Recent          = 3,
				Recommendations = 4,
				Shared          = 5,
			}

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Home.IsPinned -- PKEY_Home_IsPinned</description></item>
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{30C8EEF4-A832-41E2-AB32-E3C3CA28FD29}, 4</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsPinned => new(0x30C8EEF4, 0xA832, 0x41E2, 0xAB, 0x32, 0xE3, 0xC3, 0xCA, 0x28, 0xFD, 0x29, 4);

			/// <summary>
			/// Friendly name used for the folder path when displayed on File Explorer Home.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Home.ItemFolderPathDisplay -- PKEY_Home_ItemFolderPathDisplay</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{30C8EEF4-A832-41E2-AB32-E3C3CA28FD29}, 6</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ItemFolderPathDisplay => new(0x30C8EEF4, 0xA832, 0x41E2, 0xAB, 0x32, 0xE3, 0xC3, 0xCA, 0x28, 0xFD, 0x29, 6);

			/// <summary>
			/// A timestamp representative of when the relevant activity took place for a given recommendation.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Home.RecommendationActivityDate -- PKEY_Home_RecommendationActivityDate</description></item>r
			///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{30C8EEF4-A832-41E2-AB32-E3C3CA28FD29}, 22</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey RecommendationActivityDate => new(0x30C8EEF4, 0xA832, 0x41E2, 0xAB, 0x32, 0xE3, 0xC3, 0xCA, 0x28, 0xFD, 0x29, 22);

			/// <summary>
			/// The provider source property for items in the recommended section on File Explorer home.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Home.RecommendationProviderSource -- PKEY_Home_RecommendationProviderSource</description></item>r
			///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
			///   <item><term><b>Format ID:</b></term><description>{5CA9B1CB-C69F-404B-ABC6-FD336793A6A7}, 22</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey RecommendationProviderSource => new(0x5CA9B1CB, 0xC69F, 0x404B, 0xAB, 0xC6, 0xFD, 0x33, 0x67, 0x93, 0xA6, 0xA7, 22);

			/// <summary>
			/// The string corresponding to a glyph for the recommended section in File Explorer home.
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Home.RecommendationReasonIcon -- PKEY_Home_RecommendationReasonIcon</description></item>r
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>{30C8EEF4-A832-41E2-AB32-E3C3CA28FD29}, 21</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey RecommendationReasonIcon => new(0x30C8EEF4, 0xA832, 0x41E2, 0xAB, 0x32, 0xE3, 0xC3, 0xCA, 0x28, 0xFD, 0x29, 21);

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Home.Recommended -- PKEY_Home_Recommended</description></item>
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>{30C8EEF4-A832-41E2-AB32-E3C3CA28FD29}, 20</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Recommended => new(0x30C8EEF4, 0xA832, 0x41E2, 0xAB, 0x32, 0xE3, 0xC3, 0xCA, 0x28, 0xFD, 0x29, 20);
		}
	}
}
