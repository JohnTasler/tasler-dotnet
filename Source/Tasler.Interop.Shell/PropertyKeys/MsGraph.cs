
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class MsGraph
	{
		/// <summary>Represents information about the activity type from activity json</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.ActivityType -- PKEY_MsGraph_ActivityType</description></item>
		///   <item><term><b>Type:     </b></term></description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 14</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ActivityType => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 14);

		/// <summary>The Microsoft Graph unique composite identifier of this item.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.CompositeId -- PKEY_MsGraph_CompositeId</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CompositeId => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 2);

		/// <summary>The latest time this file was shared by any user.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.DateLastShared -- PKEY_MsGraph_DateLastShared</description></item>
		///   <item><term><b>Type:     </b></term></description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 9</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateLastShared => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 9);

		/// <summary>The Microsoft Graph unique identifier of the drive instance that contains the item.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.DriveId -- PKEY_MsGraph_DriveId</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DriveId => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 3);

		/// <summary>A data provider defined string to represent what app (local or web) can open this graph file. Useful for telemetry if extension is not available</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.GraphFileType -- PKEY_MsGraph_GraphFileType</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 16</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey GraphFileType => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 16);

		/// <summary>A URL for an icon that represents the file</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.IconUrl -- PKEY_MsGraph_IconUrl</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 15</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IconUrl => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 15);

		/// <summary>The Microsoft Graph unique identifier of this item in the drive.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.ItemId -- PKEY_MsGraph_ItemId</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ItemId => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 4);

		/// <summary>The JSON object represents information about the Display Name of the primary actor of the activity text</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.PrimaryActivityActorDisplayName -- PKEY_MsGraph_PrimaryActivityActorDisplayName</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 13</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrimaryActivityActorDisplayName => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 13);

		/// <summary>The JSON object represents information about the User Principal Name of the primary actor of the activity text</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.PrimaryActivityActorUpn -- PKEY_MsGraph_PrimaryActivityActorUpn</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 12</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PrimaryActivityActorUpn => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 12);

		/// <summary>The JSON object representing information about the reason marker for a recommended item.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.RecommendationReason -- PKEY_MsGraph_RecommendationReason</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 8</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey RecommendationReason => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 8);

		/// <summary>The 3S Recommendations reference Id used as a unique Id for recommended items.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.RecommendationReferenceId -- PKEY_MsGraph_RecommendationReferenceId</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 5</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey RecommendationReferenceId => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 5);

		/// <summary>The recommendation result source Id.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.RecommendationResultSourceId -- PKEY_MsGraph_RecommendationResultSourceId</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 7</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey RecommendationResultSourceId => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 7);

		/// <summary>The display Email address of last person who shared the file.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.SharedByEmail -- PKEY_MsGraph_SharedByEmail</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 11</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SharedByEmail => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 11);

		/// <summary>The display name of last person who shared the file.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.SharedByName -- PKEY_MsGraph_SharedByName</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 10</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SharedByName => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 10);

		/// <summary>The WAM account identifier associated with this item.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term></description>System.MsGraph.WebAccountId -- PKEY_MsGraph_WebAccountId</description></item>
		///   <item><term><b>Type:     </b></term></description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term></description>{4F85567E-FFF0-4DF5-B1D9-98B314FF0729}, 6</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey WebAccountId => new(0x4F85567E, 0xFFF0, 0x4DF5, 0xB1, 0xD9, 0x98, 0xB3, 0x14, 0xFF, 0x07, 0x29, 6);
	}
}
