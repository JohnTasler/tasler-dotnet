
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Supplemental
	{
		/// <summary>
		/// Contains list of the album where the item belongs or is associated with.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Supplemental.Album -- PKEY_Supplemental_Album</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{0C73B141-39D6-4653-A683-CAB291EAF95B}, 6</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Album => new(0x0C73B141, 0x39D6, 0x4653, 0xA6, 0x83, 0xCA, 0xB2, 0x91, 0xEA, 0xF9, 0x5B, 6);

		/// <summary>
		/// Contains the identifiers of the albums that the item is a member of. Can be used in
		/// conjunction with the Album item in the Content Indexer APIs to notify other apps about
		/// picture albums either the user created or apps have already created.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Supplemental.AlbumID -- PKEY_Supplemental_AlbumID</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{0C73B141-39D6-4653-A683-CAB291EAF95B}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AlbumID => new(0x0C73B141, 0x39D6, 0x4653, 0xA6, 0x83, 0xCA, 0xB2, 0x91, 0xEA, 0xF9, 0x5B, 2);

		/// <summary>
		/// Contains list of location information identified by client such as Photo app.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Supplemental.Location -- PKEY_Supplemental_Location</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{0C73B141-39D6-4653-A683-CAB291EAF95B}, 5</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Location => new(0x0C73B141, 0x39D6, 0x4653, 0xA6, 0x83, 0xCA, 0xB2, 0x91, 0xEA, 0xF9, 0x5B, 5);

		/// <summary>
		/// Contains list of person identified by client such as Photo app.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Supplemental.Person -- PKEY_Supplemental_Person</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{0C73B141-39D6-4653-A683-CAB291EAF95B}, 7</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Person => new(0x0C73B141, 0x39D6, 0x4653, 0xA6, 0x83, 0xCA, 0xB2, 0x91, 0xEA, 0xF9, 0x5B, 7);

		/// <summary>
		/// Contains the identifier for the item on the remote sync service. Used for comparing a file
		/// on the system to ones that are available in the cloud.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Supplemental.ResourceId -- PKEY_Supplemental_ResourceId</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{0C73B141-39D6-4653-A683-CAB291EAF95B}, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ResourceId => new(0x0C73B141, 0x39D6, 0x4653, 0xA6, 0x83, 0xCA, 0xB2, 0x91, 0xEA, 0xF9, 0x5B, 3);

		/// <summary>
		/// Contains list of tag associated with the item.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Supplemental.Tag -- PKEY_Supplemental_Tag</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{0C73B141-39D6-4653-A683-CAB291EAF95B}, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Tag => new(0x0C73B141, 0x39D6, 0x4653, 0xA6, 0x83, 0xCA, 0xB2, 0x91, 0xEA, 0xF9, 0x5B, 4);
	}
}
