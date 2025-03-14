
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Search
	{
		/// <summary>
		/// General Summary of the document.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.AutoSummary -- PKEY_AutoSummary</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>560C36C0-503A-11CF-BAA1-00004C752A9A, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AutoSummary => new PropertyKey(0x560C36C0, 0x503A, 0x11CF, 0xBA, 0xA1, 0x00, 0x00, 0x4C, 0x75, 0x2A, 0x9A, 2);

		/// <summary>
		/// Hash code used to identify attachments to be deleted based on a common container url</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.ContainerHash -- PKEY_ContainerHash</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>BCEEE283-35DF-4D53-826A-F36A3EEFC6BE, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ContainerHash => new PropertyKey(0xBCEEE283, 0x35DF, 0x4D53, 0x82, 0x6A, 0xF3, 0x6A, 0x3E, 0xEF, 0xC6, 0xBE, 100);

		/// <summary>
		/// The contents of the item. This property is for query restrictions only; it cannot be retrieved in a query result.
		/// The Indexing Service friendly name is 'contents'.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.Contents -- PKEY_Contents</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Storage) B725F130-47EF-101A-A5F1-02608C9EEBAC, 19 (PID_STG_CONTENTS)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Contents => new PropertyKey(0xB725F130, 0x47EF, 0x101A, 0xA5, 0xF1, 0x02, 0x60, 0x8C, 0x9E, 0xEB, 0xAC, 19);

		/// <summary>
		/// The entry ID for an item within a given catalog in the Windows Search Index.
		/// This value may be recycled, and therefore is not considered unique over time.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.EntryID -- PKEY_EntryID</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Query) 49691C90-7E17-101A-A91C-08002B2ECDA9, 5 (PROPID_QUERY_WORKID)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey EntryID => new PropertyKey(0x49691C90, 0x7E17, 0x101A, 0xA9, 0x1C, 0x08, 0x00, 0x2B, 0x2E, 0xCD, 0xA9, 5);

		/// <summary>
		/// The Datetime that the Windows Search Gatherer process last pushed properties of this document to the Windows Search Gatherer Plugins.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.GatherTime -- PKEY_GatherTime</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>0B63E350-9CCC-11D0-BCDB-00805FCCCE04, 8</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey GatherTime => new PropertyKey(0x0B63E350, 0x9CCC, 0x11D0, 0xBC, 0xDB, 0x00, 0x80, 0x5F, 0xCC, 0xCE, 0x04, 8);

		/// <summary>
		/// If this property is emitted with a value of TRUE, then it indicates that this URL's last modified time applies to all of it's children, and if this URL is deleted then all of it's children are deleted as well.  For example, this would be emitted as TRUE when emitting the URL of an email so that all attachments are tied to the last modified time of that email.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.IsClosedDirectory -- PKEY_IsClosedDirectory</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>0B63E343-9CCC-11D0-BCDB-00805FCCCE04, 23</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsClosedDirectory => new PropertyKey(0x0B63E343, 0x9CCC, 0x11D0, 0xBC, 0xDB, 0x00, 0x80, 0x5F, 0xCC, 0xCE, 0x04, 23);

		/// <summary>
		/// Any child URL of a URL which has System.Search.IsClosedDirectory=TRUE must emit System.Search.IsFullyContained=TRUE.
		/// This ensures that the URL is not deleted at the end of a crawl because it hasn't been visited
		/// (which is the normal mechanism for detecting deletes). For example an email attachment would emit this property</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.IsFullyContained -- PKEY_IsFullyContained</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>0B63E343-9CCC-11D0-BCDB-00805FCCCE04, 24</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsFullyContained => new PropertyKey(0x0B63E343, 0x9CCC, 0x11D0, 0xBC, 0xDB, 0x00, 0x80, 0x5F, 0xCC, 0xCE, 0x04, 24);

		/// <summary>
		/// Query Focused Summary of the document.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.QueryFocusedSummary -- PKEY_QueryFocusedSummary</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>560C36C0-503A-11CF-BAA1-00004C752A9A, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey QueryFocusedSummary => new PropertyKey(0x560C36C0, 0x503A, 0x11CF, 0xBA, 0xA1, 0x00, 0x00, 0x4C, 0x75, 0x2A, 0x9A, 3);

		/// <summary>
		/// Relevance rank of row. Ranges from 0-1000. Larger numbers = better matches.
		/// Query-time only, not defined in Search schema, retrievable but not searchable.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.Rank -- PKEY_Rank</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Query) 49691C90-7E17-101A-A91C-08002B2ECDA9, 3 (PROPID_QUERY_RANK)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Rank => new PropertyKey(0x49691C90, 0x7E17, 0x101A, 0xA9, 0x1C, 0x08, 0x00, 0x2B, 0x2E, 0xCD, 0xA9, 3);

		/// <summary>
		/// The identifier for the protocol handler that produced this item. (E.g. MAPI, CSC, FILE etc.)</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.Store -- PKEY_Store</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>A06992B3-8CAF-4ED7-A547-B259E32AC9FC, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Store => new PropertyKey(0xA06992B3, 0x8CAF, 0x4ED7, 0xA5, 0x47, 0xB2, 0x59, 0xE3, 0x2A, 0xC9, 0xFC, 100);

		/// <summary>
		/// This property should be emitted by a container IFilter for each child URL within the container.  The children will eventually be crawled by the indexer if they are within scope.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.UrlToIndex -- PKEY_UrlToIndex</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>0B63E343-9CCC-11D0-BCDB-00805FCCCE04, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey UrlToIndex => new PropertyKey(0x0B63E343, 0x9CCC, 0x11D0, 0xBC, 0xDB, 0x00, 0x80, 0x5F, 0xCC, 0xCE, 0x04, 2);

		/// <summary>
		/// This property is the same as System.Search.UrlToIndex except that it includes the time the URL was last modified.  This is an optimization for the indexer as it doesn't have to call back into the protocol handler to ask for this information to determine if the content needs to be indexed again.  The property is a vector with two elements, a VT_LPWSTR with the URL and a VT_FILETIME for the last modified time.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Search.UrlToIndexWithModificationTime -- PKEY_UrlToIndexWithModificationTime</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue Any -- VT_VECTOR | VT_NULL  (For variants: VT_ARRAY | VT_NULL)</description></item>
		///   <item><term><b>Format ID:</b></term><description>0B63E343-9CCC-11D0-BCDB-00805FCCCE04, 12</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey UrlToIndexWithModificationTime => new PropertyKey(0x0B63E343, 0x9CCC, 0x11D0, 0xBC, 0xDB, 0x00, 0x80, 0x5F, 0xCC, 0xCE, 0x04, 12);
	}
}
