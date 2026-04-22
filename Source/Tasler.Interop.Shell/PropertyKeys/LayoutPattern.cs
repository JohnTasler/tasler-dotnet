
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class LayoutPattern
	{
		/// <summary>Specifies the layout pattern that the content view mode should apply for this item in the context of browsing. Register the regvalue under the name of "ContentViewModeLayoutPatternForBrowse".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term>Name</term>     <description>System.LayoutPattern.ContentViewModeForBrowse -- PKEY_LayoutPattern_ContentViewModeForBrowse</description></item>
		///   <item><term>Type</term>     <description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term>Format ID</term><description>{C9944A21-A406-48FE-8225-AEC7E24C211B}, 500</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ContentViewModeForBrowse => new(0xC9944A21, 0xA406, 0x48FE, 0x82, 0x25, 0xAE, 0xC7, 0xE2, 0x4C, 0x21, 0x1B, 500);

		/// <summary>Specifies the layout pattern that the content view mode should apply for this item in the context of searching. Register the regvalue under the name of "ContentViewModeLayoutPatternForSearch".</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term>Name</term>     <description>System.LayoutPattern.ContentViewModeForSearch -- PKEY_LayoutPattern_ContentViewModeForSearch</description></item>
		///   <item><term>Type</term>     <description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term>Format ID</term><description>{C9944A21-A406-48FE-8225-AEC7E24C211B}, 501</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ContentViewModeForSearch => new(0xC9944A21, 0xA406, 0x48FE, 0x82, 0x25, 0xAE, 0xC7, 0xE2, 0x4C, 0x21, 0x1B, 501);

		/// <summary>Possible discrete values for PKEY_LayoutPattern_ContentViewModeForBrowse.</summary>
		public static class LayoutPatternContentViewMode
		{
			public const string Beta  = "beta";
			public const string Alpha = "alpha";
			public const string Gamma = "gamma";
			public const string Delta = "delta";
		}
	}
}
