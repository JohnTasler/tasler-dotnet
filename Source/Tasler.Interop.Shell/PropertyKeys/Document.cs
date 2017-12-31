using System;

namespace Tasler.Interop.Shell
{
	public static partial class PropertyKeys
	{
		public static class Document
		{
			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.ByteCount -- PKEY_ByteCount</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 4 (PIDDSI_BYTECOUNT)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ByteCount { get { return new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 4); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.CharacterCount -- PKEY_CharacterCount</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 16 (PIDSI_CHARCOUNT)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey CharacterCount { get { return new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 16); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.ClientID -- PKEY_ClientID</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>276D7BB0-5B34-4FB0-AA4B-158ED12A1809, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ClientID { get { return new PropertyKey(0x276D7BB0, 0x5B34, 0x4FB0, 0xAA, 0x4B, 0x15, 0x8E, 0xD1, 0x2A, 0x18, 0x09, 100); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.Contributor -- PKEY_Contributor</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>F334115E-DA1B-4509-9B3D-119504DC7ABB, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Contributor { get { return new PropertyKey(0xF334115E, 0xDA1B, 0x4509, 0x9B, 0x3D, 0x11, 0x95, 0x04, 0xDC, 0x7A, 0xBB, 100); } }

			/// <summary>
			/// This property is stored in the document, not obtained from the file system.</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.DateCreated -- PKEY_DateCreated</description></item>
			///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 12 (PIDSI_CREATE_DTM)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey DateCreated { get { return new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 12); } }

			/// <summary>
			/// Legacy name: "DocLastPrinted".</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.DatePrinted -- PKEY_DatePrinted</description></item>
			///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 11 (PIDSI_LASTPRINTED)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey DatePrinted { get { return new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 11); } }

			/// <summary>
			/// Legacy name: "DocLastSavedTm".</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.DateSaved -- PKEY_DateSaved</description></item>
			///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 13 (PIDSI_LASTSAVE_DTM)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey DateSaved { get { return new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 13); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.Division -- PKEY_Division</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>1E005EE6-BF27-428B-B01C-79676ACD2870, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Division { get { return new PropertyKey(0x1E005EE6, 0xBF27, 0x428B, 0xB0, 0x1C, 0x79, 0x67, 0x6A, 0xCD, 0x28, 0x70, 100); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.DocumentID -- PKEY_DocumentID</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E08805C8-E395-40DF-80D2-54F0D6C43154, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey DocumentID { get { return new PropertyKey(0xE08805C8, 0xE395, 0x40DF, 0x80, 0xD2, 0x54, 0xF0, 0xD6, 0xC4, 0x31, 0x54, 100); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.HiddenSlideCount -- PKEY_HiddenSlideCount</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 9 (PIDDSI_HIDDENCOUNT)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey HiddenSlideCount { get { return new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 9); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.LastAuthor -- PKEY_LastAuthor</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 8 (PIDSI_LASTAUTHOR)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey LastAuthor { get { return new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 8); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.LineCount -- PKEY_LineCount</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 5 (PIDDSI_LINECOUNT)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey LineCount { get { return new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 5); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.Manager -- PKEY_Manager</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 14 (PIDDSI_MANAGER)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Manager { get { return new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 14); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.MultimediaClipCount -- PKEY_MultimediaClipCount</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 10 (PIDDSI_MMCLIPCOUNT)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey MultimediaClipCount { get { return new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 10); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.NoteCount -- PKEY_NoteCount</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 8 (PIDDSI_NOTECOUNT)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey NoteCount { get { return new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 8); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.PageCount -- PKEY_PageCount</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 14 (PIDSI_PAGECOUNT)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey PageCount { get { return new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 14); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.ParagraphCount -- PKEY_ParagraphCount</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 6 (PIDDSI_PARCOUNT)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ParagraphCount { get { return new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 6); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.PresentationFormat -- PKEY_PresentationFormat</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 3 (PIDDSI_PRESFORMAT)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey PresentationFormat { get { return new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 3); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.RevisionNumber -- PKEY_RevisionNumber</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 9 (PIDSI_REVNUMBER)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey RevisionNumber { get { return new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 9); } }

			/// <summary>
			/// Access control information, from SummaryInfo propset</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.Security -- PKEY_Security</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 19</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Security { get { return new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 19); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.SlideCount -- PKEY_SlideCount</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 7 (PIDDSI_SLIDECOUNT)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SlideCount { get { return new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 7); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.Template -- PKEY_Template</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 7 (PIDSI_TEMPLATE)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Template { get { return new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 7); } }

			/// <summary>
			/// 100ns units, not milliseconds. VT_FILETIME for IPropertySetStorage handlers (legacy)</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.TotalEditingTime -- PKEY_TotalEditingTime</description></item>
			///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 10 (PIDSI_EDITTIME)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey TotalEditingTime { get { return new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 10); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.Version -- PKEY_Version</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 29</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Version { get { return new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 29); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Document.WordCount -- PKEY_WordCount</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 15 (PIDSI_WORDCOUNT)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey WordCount { get { return new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 15); } }
		}
	}
}