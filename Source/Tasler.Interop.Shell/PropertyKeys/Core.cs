
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Core
	{
		/// <summary>
		/// Hash to determine acquisition session.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.AcquisitionID -- PKEY_AcquisitionID</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>65A98875-3C80-40AB-ABBC-EFDAF77DBEE2, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AcquisitionID => new PropertyKey(0x65A98875, 0x3C80, 0x40AB, 0xAB, 0xBC, 0xEF, 0xDA, 0xF7, 0x7D, 0xBE, 0xE2, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ApplicationName -- PKEY_ApplicationName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)  Legacy code may treat this as VT_LPSTR.</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 18 (PIDSI_APPNAME)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ApplicationName => new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 18);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Author -- PKEY_Author</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)  Legacy code may treat this as VT_LPSTR.</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 4 (PIDSI_AUTHOR)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Author => new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 4);

		/// <summary>
		/// The amount of total space in bytes.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Capacity -- PKEY_Capacity</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Volume) 9B174B35-40FF-11D2-A27E-00C04FC30871, 3 (PID_VOLUME_CAPACITY)  (Filesystem Volume Properties)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Capacity => new PropertyKey(0x9B174B35, 0x40FF, 0x11D2, 0xA2, 0x7E, 0x00, 0xC0, 0x4F, 0xC3, 0x08, 0x71, 3);

		/// <summary>
		/// Legacy code treats this as VT_LPSTR.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Category -- PKEY_Category</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 2 (PIDDSI_CATEGORY)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Category => new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 2);

		/// <summary>
		/// Comments.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Comment -- PKEY_Comment</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)  Legacy code may treat this as VT_LPSTR.</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 6 (PIDSI_COMMENTS)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Comment => new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 6);

		/// <summary>
		/// The company or publisher.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Company -- PKEY_Company</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 15 (PIDDSI_COMPANY)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Company => new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 15);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ComputerName -- PKEY_ComputerName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 5 (PID_COMPUTERNAME)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ComputerName => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 5);

		/// <summary>
		/// The list of type of items, this item contains. For example, this item contains urls, attachments etc.
		/// This is represented as a vector array of GUIDs where each GUID represents certain type.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ContainedItems -- PKEY_ContainedItems</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue Guid -- VT_VECTOR | VT_CLSID  (For variants: VT_ARRAY | VT_CLSID)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 29</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ContainedItems => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 29);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ContentStatus -- PKEY_ContentStatus</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 27</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ContentStatus => new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 27);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ContentType -- PKEY_ContentType</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 26</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ContentType => new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 26);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Copyright -- PKEY_Copyright</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSGUID_MEDIAFILESUMMARYINFORMATION) 64440492-4C8B-11D1-8B70-080036B11A03, 11 (PIDMSI_COPYRIGHT)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Copyright => new PropertyKey(0x64440492, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 11);

		/// <summary>
		/// The time of the last access to the item.  The Indexing Service friendly name is 'access'.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DateAccessed -- PKEY_DateAccessed</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Storage) B725F130-47EF-101A-A5F1-02608C9EEBAC, 16 (PID_STG_ACCESSTIME)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateAccessed => new PropertyKey(0xB725F130, 0x47EF, 0x101A, 0xA5, 0xF1, 0x02, 0x60, 0x8C, 0x9E, 0xEB, 0xAC, 16);

		/// <summary>
		/// The time the file entered the system via acquisition.  This is not the same as System.DateImported.
		/// Examples are when pictures are acquired from a camera, or when music is purchased online.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DateAcquired -- PKEY_DateAcquired</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>2CBAA8F5-D81F-47CA-B17A-F8D822300131, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateAcquired => new PropertyKey(0x2CBAA8F5, 0xD81F, 0x47CA, 0xB1, 0x7A, 0xF8, 0xD8, 0x22, 0x30, 0x01, 0x31, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DateArchived -- PKEY_DateArchived</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>43F8D7B7-A444-4F87-9383-52271C9B915C, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateArchived => new PropertyKey(0x43F8D7B7, 0xA444, 0x4F87, 0x93, 0x83, 0x52, 0x27, 0x1C, 0x9B, 0x91, 0x5C, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DateCompleted -- PKEY_DateCompleted</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>72FAB781-ACDA-43E5-B155-B2434F85E678, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateCompleted => new PropertyKey(0x72FAB781, 0xACDA, 0x43E5, 0xB1, 0x55, 0xB2, 0x43, 0x4F, 0x85, 0xE6, 0x78, 100);

		/// <summary>
		/// The date and time the item was created. The Indexing Service friendly name is 'create'.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DateCreated -- PKEY_DateCreated</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Storage) B725F130-47EF-101A-A5F1-02608C9EEBAC, 15 (PID_STG_CREATETIME)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateCreated => new PropertyKey(0xB725F130, 0x47EF, 0x101A, 0xA5, 0xF1, 0x02, 0x60, 0x8C, 0x9E, 0xEB, 0xAC, 15);

		/// <summary>
		/// The time the file is imported into a separate database.  This is not the same as System.DateAcquired.  (Eg, 2003:05:22 13:55:04)</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DateImported -- PKEY_DateImported</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 18258</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateImported => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 18258);

		/// <summary>
		/// The date and time of the last write to the item. The Indexing Service friendly name is 'write'.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DateModified -- PKEY_DateModified</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Storage) B725F130-47EF-101A-A5F1-02608C9EEBAC, 14 (PID_STG_WRITETIME)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateModified => new PropertyKey(0xB725F130, 0x47EF, 0x101A, 0xA5, 0xF1, 0x02, 0x60, 0x8C, 0x9E, 0xEB, 0xAC, 14);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DueDate -- PKEY_DueDate</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>3F8472B5-E0AF-4DB2-8071-C53FE76AE7CE, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DueDate => new PropertyKey(0x3F8472B5, 0xE0AF, 0x4DB2, 0x80, 0x71, 0xC5, 0x3F, 0xE7, 0x6A, 0xE7, 0xCE, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.EndDate -- PKEY_EndDate</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>C75FAA05-96FD-49E7-9CB4-9F601082D553, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey EndDate => new PropertyKey(0xC75FAA05, 0x96FD, 0x49E7, 0x9C, 0xB4, 0x9F, 0x60, 0x10, 0x82, 0xD5, 0x53, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FileAllocationSize -- PKEY_FileAllocationSize</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Storage) B725F130-47EF-101A-A5F1-02608C9EEBAC, 18 (PID_STG_ALLOCSIZE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FileAllocationSize => new PropertyKey(0xB725F130, 0x47EF, 0x101A, 0xA5, 0xF1, 0x02, 0x60, 0x8C, 0x9E, 0xEB, 0xAC, 18);

		/// <summary>
		/// This is the WIN32_FIND_DATA dwFileAttributes for the file-based item.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FileAttributes -- PKEY_FileAttributes</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Storage) B725F130-47EF-101A-A5F1-02608C9EEBAC, 13 (PID_STG_ATTRIBUTES)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FileAttributes => new PropertyKey(0xB725F130, 0x47EF, 0x101A, 0xA5, 0xF1, 0x02, 0x60, 0x8C, 0x9E, 0xEB, 0xAC, 13);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FileCount -- PKEY_FileCount</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 12</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FileCount => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 12);

		/// <summary>
		/// This is a user-friendly description of the file.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FileDescription -- PKEY_FileDescription</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSFMTID_VERSION) 0CEF7D53-FA64-11D1-A203-0000F81FEDEE, 3 (PIDVSI_FileDescription)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FileDescription => new PropertyKey(0x0CEF7D53, 0xFA64, 0x11D1, 0xA2, 0x03, 0x00, 0x00, 0xF8, 0x1F, 0xED, 0xEE, 3);

		/// <summary>
		/// This is the file extension of the file based item, including the leading period.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FileExtension -- PKEY_FileExtension</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>E4F10A3C-49E6-405D-8288-A23BD4EEAA6C, 100</description></item>
		/// </list>
		/// <para>
		/// If System.FileName is VT_EMPTY, then this property should be too.  Otherwise, it should be derived
		/// appropriately by the data source from System.FileName.  If System.FileName does not have a file 
		/// extension, this value should be VT_EMPTY.</para>
		/// <para>
		/// To obtain the type of any item (including an item that is not a file), use System.ItemType.</para>
		/// </remarks>
		/// <example>
		/// <list type="table">
		///   <listheader><term>If the path is...</term><description>The property value is...</description></listheader>
		///   <item><term>"c:\foo\bar\hello.txt"               </term><description>".txt"</description></item>
		///   <item><term>"\\server\share\mydir\goodnews.doc"  </term><description>".doc"</description></item>
		///   <item><term>"\\server\share\numbers.xls"         </term><description>".xls"</description></item>
		///   <item><term>"\\server\share\folder"              </term><description>VT_EMPTY</description></item>
		///   <item><term>"c:\foo\MyFolder"                    </term><description>VT_EMPTY</description></item>
		///   <item><term>[desktop]                            </term><description>VT_EMPTY</description></item>
		/// </list>
		/// </example>
		public static PropertyKey FileExtension => new PropertyKey(0xE4F10A3C, 0x49E6, 0x405D, 0x82, 0x88, 0xA2, 0x3B, 0xD4, 0xEE, 0xAA, 0x6C, 100);

		/// <summary>
		/// This is the unique file ID, also known as the File Reference Number. For a given file, this is the same value
		/// as is found in the structure variable FILE_ID_BOTH_DIR_INFO.FileId, via GetFileInformationByHandleEx().</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FileFRN -- PKEY_FileFRN</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Storage) B725F130-47EF-101A-A5F1-02608C9EEBAC, 21 (PID_STG_FRN)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FileFRN => new PropertyKey(0xB725F130, 0x47EF, 0x101A, 0xA5, 0xF1, 0x02, 0x60, 0x8C, 0x9E, 0xEB, 0xAC, 21);

		/// <summary>
		/// This is the file name (including extension) of the file.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FileName -- PKEY_FileName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>41CF5AE0-F75A-4806-BD87-59C7D9248EB9, 100</description></item>
		/// </list>
		/// <para>
		/// It is possible that the item might not exist on a filesystem (ie, it may not be opened 
		/// using CreateFile).  Nonetheless, if the item is represented as a file from the logical sense 
		/// (and its name follows standard Win32 file-naming syntax), then the data source should emit this property.</para>
		/// <para>
		/// If an item is not a file, then the value for this property is VT_EMPTY.  See 
		/// System.ItemNameDisplay.</para>
		/// <para>
		/// This has the same value as System.ParsingName for items that are provided by the Shell's file folder.</para>
		/// </remarks>
		/// <example>
		/// <list type="table">
		///   <listheader><term>If the path is...</term><description>The property value is...</description></listheader>
		///   <item><term>"c:\foo\bar\hello.txt"               </term><description>"hello.txt"</description></item>
		///   <item><term>"\\server\share\mydir\goodnews.doc"  </term><description>"goodnews.doc"</description></item>
		///   <item><term>"\\server\share\numbers.xls"         </term><description>"numbers.xls"</description></item>
		///   <item><term>"c:\foo\MyFolder"                    </term><description>"MyFolder"</description></item>
		///   <item><term>(email message)                      </term><description>VT_EMPTY</description></item>
		///   <item><term>(song on portable device)            </term><description>"song.wma"</description></item>
		/// </list>
		/// </example>
		public static PropertyKey FileName => new PropertyKey(0x41CF5AE0, 0xF75A, 0x4806, 0xBD, 0x87, 0x59, 0xC7, 0xD9, 0x24, 0x8E, 0xB9, 100);

		/// <summary>
		/// This is the owner of the file, according to the file system.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FileOwner -- PKEY_FileOwner</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Misc) 9B174B34-40FF-11D2-A27E-00C04FC30871, 4 (PID_MISC_OWNER)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FileOwner => new PropertyKey(0x9B174B34, 0x40FF, 0x11D2, 0xA2, 0x7E, 0x00, 0xC0, 0x4F, 0xC3, 0x08, 0x71, 4);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FileVersion -- PKEY_FileVersion</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSFMTID_VERSION) 0CEF7D53-FA64-11D1-A203-0000F81FEDEE, 4 (PIDVSI_FileVersion)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FileVersion => new PropertyKey(0x0CEF7D53, 0xFA64, 0x11D1, 0xA2, 0x03, 0x00, 0x00, 0xF8, 0x1F, 0xED, 0xEE, 4);

		/// <summary>
		/// WIN32_FIND_DATAW in buffer of bytes.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FindData -- PKEY_FindData</description></item>
		///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 0 (PID_FINDDATA)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FindData => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 0);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FlagColor -- PKEY_FlagColor</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>67DF94DE-0CA7-4D6F-B792-053A3E4F03CF, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FlagColor => new PropertyKey(0x67DF94DE, 0x0CA7, 0x4D6F, 0xB7, 0x92, 0x05, 0x3A, 0x3E, 0x4F, 0x03, 0xCF, 100);

		/// <summary>Possible discrete values for PKEY_FlagColor.</summary>
		public enum FlagColors : ushort
		{
			Purple = 1,
			Orange = 2,
			Green = 3,
			Yellow = 4,
			Blue = 5,
			Red = 6,
		}

		/// <summary>
		/// This is the user-friendly form of System.FlagColor.  Not intended to be parsed programmatically.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FlagColorText -- PKEY_FlagColorText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>45EAE747-8E2A-40AE-8CBF-CA52ABA6152A, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FlagColorText => new PropertyKey(0x45EAE747, 0x8E2A, 0x40AE, 0x8C, 0xBF, 0xCA, 0x52, 0xAB, 0xA6, 0x15, 0x2A, 100);

		/// <summary>
		/// Status of Flag. Values : (0=none 1=white 2=Red).  cdoPR_FLAG_STATUS</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FlagStatus -- PKEY_FlagStatus</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 12</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FlagStatus => new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 12);

		/// <summary>Possible discrete values for PKEY_FlagStatus.</summary>
		public enum FlagStatusValues : int
		{
			NotFlagged = 0,
			Completed = 1,
			FollowUp = 2,
		}

		/// <summary>
		/// This is the user-friendly form of System.FlagStatus.  Not intended to be parsed programmatically.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FlagStatusText -- PKEY_FlagStatusText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>DC54FD2E-189D-4871-AA01-08C2F57A4ABC, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FlagStatusText => new PropertyKey(0xDC54FD2E, 0x189D, 0x4871, 0xAA, 0x01, 0x08, 0xC2, 0xF5, 0x7A, 0x4A, 0xBC, 100);

		/// <summary>
		/// The amount of free space in bytes.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.FreeSpace -- PKEY_FreeSpace</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Volume) 9B174B35-40FF-11D2-A27E-00C04FC30871, 2 (PID_VOLUME_FREE)  (Filesystem Volume Properties)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FreeSpace => new PropertyKey(0x9B174B35, 0x40FF, 0x11D2, 0xA2, 0x7E, 0x00, 0xC0, 0x4F, 0xC3, 0x08, 0x71, 2);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Identity -- PKEY_Identity</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>A26F4AFC-7346-4299-BE47-EB1AE613139F, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Identity => new PropertyKey(0xA26F4AFC, 0x7346, 0x4299, 0xBE, 0x47, 0xEB, 0x1A, 0xE6, 0x13, 0x13, 0x9F, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Importance -- PKEY_Importance</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 11</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Importance => new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 11);

		/// <summary>Possible range of values for PKEY_Importance.</summary>
		public enum ImportanceValues : int
		{
			LowMin = 0,
			LowSet = 1,
			LowMax = 1,

			NormaLMin = 2,
			NormaLSet = 3,
			NormaLMax = 4,

			HighMin = 5,
			HighSet = 5,
			HighMax = 5,
		}


		/// <summary>
		/// This is the user-friendly form of System.Importance.  Not intended to be parsed programmatically.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ImportanceText -- PKEY_ImportanceText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>A3B29791-7713-4E1D-BB40-17DB85F01831, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ImportanceText => new PropertyKey(0xA3B29791, 0x7713, 0x4E1D, 0xBB, 0x40, 0x17, 0xDB, 0x85, 0xF0, 0x18, 0x31, 100);

		/// <summary>
		/// Identifies if this item is an attachment.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.IsAttachment -- PKEY_IsAttachment</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>F23F425C-71A1-4FA8-922F-678EA4A60408, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsAttachment => new PropertyKey(0xF23F425C, 0x71A1, 0x4FA8, 0x92, 0x2F, 0x67, 0x8E, 0xA4, 0xA6, 0x04, 0x08, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.IsDeleted -- PKEY_IsDeleted</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>5CDA5FC8-33EE-4FF3-9094-AE7BD8868C4D, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsDeleted => new PropertyKey(0x5CDA5FC8, 0x33EE, 0x4FF3, 0x90, 0x94, 0xAE, 0x7B, 0xD8, 0x86, 0x8C, 0x4D, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.IsFlagged -- PKEY_IsFlagged</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>5DA84765-E3FF-4278-86B0-A27967FBDD03, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsFlagged => new PropertyKey(0x5DA84765, 0xE3FF, 0x4278, 0x86, 0xB0, 0xA2, 0x79, 0x67, 0xFB, 0xDD, 0x03, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.IsFlaggedComplete -- PKEY_IsFlaggedComplete</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>A6F360D2-55F9-48DE-B909-620E090A647C, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsFlaggedComplete => new PropertyKey(0xA6F360D2, 0x55F9, 0x48DE, 0xB9, 0x09, 0x62, 0x0E, 0x09, 0x0A, 0x64, 0x7C, 100);

		/// <summary>
		/// Identifies if the message was not completely received for some error condition.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.IsIncomplete -- PKEY_IsIncomplete</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>346C8BD1-2E6A-4C45-89A4-61B78E8E700F, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsIncomplete => new PropertyKey(0x346C8BD1, 0x2E6A, 0x4C45, 0x89, 0xA4, 0x61, 0xB7, 0x8E, 0x8E, 0x70, 0x0F, 100);

		/// <summary>
		/// Has the item been read?</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.IsRead -- PKEY_IsRead</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 10</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsRead => new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 10);

		/// <summary>
		/// Provided by certain shell folders. Return TRUE if the folder is a valid Send To target.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.IsSendToTarget -- PKEY_IsSendToTarget</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 33</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsSendToTarget => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 33);

		/// <summary>
		/// Is this item shared?</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.IsShared -- PKEY_IsShared</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsShared => new PropertyKey(0xEF884C5B, 0x2BFE, 0x41BB, 0xAA, 0xE5, 0x76, 0xEE, 0xDF, 0x4F, 0x99, 0x02, 100);

		/// <summary>
		/// <para>
		/// This is the generic list of authors associated with an item.</para>
		/// <para>
		/// For example, the artist name for a track is the item author.</para>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemAuthors -- PKEY_ItemAuthors</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D0A04F0A-462A-48A4-BB2F-3706E88DBD7D, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ItemAuthors => new PropertyKey(0xD0A04F0A, 0x462A, 0x48A4, 0xBB, 0x2F, 0x37, 0x06, 0xE8, 0x8D, 0xBD, 0x7D, 100);

		/// <summary>
		/// This is the main date for an item. The date of interest. 
		/// For example, for photos this maps to System.Photo.DateTaken.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemDate -- PKEY_ItemDate</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>F7DB74B4-4287-4103-AFBA-F1B13DCD75CF, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ItemDate => new PropertyKey(0xF7DB74B4, 0x4287, 0x4103, 0xAF, 0xBA, 0xF1, 0xB1, 0x3D, 0xCD, 0x75, 0xCF, 100);

		/// <summary>
		/// This is the user-friendly display name of the parent folder of an item.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemFolderNameDisplay -- PKEY_ItemFolderNameDisplay</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Storage) B725F130-47EF-101A-A5F1-02608C9EEBAC, 2 (PID_STG_DIRECTORY)</description></item>
		/// </list>
		/// If System.ItemFolderPathDisplay is VT_EMPTY, then this property should be too.  Otherwise, it 
		/// should be derived appropriately by the data source from System.ItemFolderPathDisplay.
		/// </remarks>
		/// <example>
		/// <list type="table">
		///   <listheader><term>If the path is...</term><description>The property value is...</description></listheader>
		///   <item><term>"c:\foo\bar\hello.txt"               </term><description>"bar"</description></item>
		///   <item><term>"\\server\share\mydir\goodnews.doc"  </term><description>"mydir"</description></item>
		///   <item><term>"\\server\share\numbers.xls"         </term><description>"share"</description></item>
		///   <item><term>"c:\foo\MyFolder"                    </term><description>"foo"</description></item>
		///   <item><term>"/Mailbox Account/Inbox/'Re: Hello!'"</term><description>"Inbox"</description></item>
		/// </list>
		/// </example>
		public static PropertyKey ItemFolderNameDisplay => new PropertyKey(0xB725F130, 0x47EF, 0x101A, 0xA5, 0xF1, 0x02, 0x60, 0x8C, 0x9E, 0xEB, 0xAC, 2);

		/// <summary>
		/// This is the user-friendly display path of the parent folder of an item.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemFolderPathDisplay -- PKEY_ItemFolderPathDisplay</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 6</description></item>
		/// </list>
		/// If System.ItemPathDisplay is VT_EMPTY, then this property should be too.  Otherwise, it should 
		/// be derived appropriately by the data source from System.ItemPathDisplay.
		/// </remarks>
		/// <example>
		/// <list type="table">
		///   <listheader><term>If the path is...</term><description>The property value is...</description></listheader>
		///   <item><term>"c:\foo\bar\hello.txt"               </term><description>"c:\foo\bar"</description></item>
		///   <item><term>"\\server\share\mydir\goodnews.doc"  </term><description>"\\server\share\mydir"</description></item>
		///   <item><term>"\\server\share\numbers.xls"         </term><description>"\\server\share"</description></item>
		///   <item><term>"c:\foo\MyFolder"                    </term><description>"c:\foo"</description></item>
		///   <item><term>"/Mailbox Account/Inbox/'Re: Hello!'" </term><description>"/Mailbox Account/Inbox"</description></item>
		/// </list>
		/// </example>
		public static PropertyKey ItemFolderPathDisplay => new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 6);

		/// <summary>
		/// This is the user-friendly display path of the parent folder of an item.  The format of the string
		/// should be tailored such that the folder name comes first, to optimize for a narrow viewing column.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemFolderPathDisplayNarrow -- PKEY_ItemFolderPathDisplayNarrow</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>DABD30ED-0043-4789-A7F8-D013A4736622, 100</description></item>
		/// </list>
		/// <para>
		/// If the folder is a file folder, the value includes localized names if they are present.</para>
		/// <para>
		/// If System.ItemFolderPathDisplay is VT_EMPTY, then this property should be too.  Otherwise, it should
		/// be derived appropriately by the data source from System.ItemFolderPathDisplay.</para>
		/// </remarks>
		/// <example>
		/// <list type="table">
		///   <listheader><term>If the path is...</term><description>The property value is...</description></listheader>
		///   <item><term>"c:\foo\bar\hello.txt"                </term><description>"bar(c:\foo)"</description></item>
		///   <item><term>"\\server\share\mydir\goodnews.doc"   </term><description>"mydir(\\server\share)"</description></item>
		///   <item><term>"\\server\share\numbers.xls"          </term><description>"share(\\server)"</description></item>
		///   <item><term>"c:\foo\MyFolder"                     </term><description>"foo(c:\)"</description></item>
		///   <item><term>"/Mailbox Account/Inbox/'Re: Hello!'" </term><description>"Inbox (/Mailbox Account)"</description></item>
		/// </list>
		/// </example>
		public static PropertyKey ItemFolderPathDisplayNarrow => new PropertyKey(0xDABD30ED, 0x0043, 0x4789, 0xA7, 0xF8, 0xD0, 0x13, 0xA4, 0x73, 0x66, 0x22, 100);

		/// <summary>
		/// This is the base-name of the System.ItemNameDisplay.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemName -- PKEY_ItemName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>6B8DA074-3B5C-43BC-886F-0A2CDCE00B6F, 100</description></item>
		/// </list>
		/// <para>
		/// If the item is a file this property
		/// includes the extension in all cases, and will be localized if a localized name is available.</para>
		/// <para>
		/// If the item is a message, then the value of this property does not include the forwarding or
		/// reply prefixes (see System.ItemNamePrefix).</para>
		/// </remarks>
		public static PropertyKey ItemName => new PropertyKey(0x6B8DA074, 0x3B5C, 0x43BC, 0x88, 0x6F, 0x0A, 0x2C, 0xDC, 0xE0, 0x0B, 0x6F, 100);

		/// <summary>
		/// This is the display name in "most complete" form.  This is the best effort unique representation
		/// of the name of an item that makes sense for end users to read.  It is the concatentation of
		/// System.ItemNamePrefix and System.ItemName.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemNameDisplay -- PKEY_ItemNameDisplay</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Storage) B725F130-47EF-101A-A5F1-02608C9EEBAC, 10 (PID_STG_NAME)</description></item>
		/// </list>
		/// <para>
		/// If the item is a file this property
		/// includes the extension in all cases, and will be localized if a localized name is available.</para>
		/// <para>
		/// There are acceptable cases when System.FileName is not VT_EMPTY, yet the value of this property 
		/// is completely different.  Email messages are a key example.  If the item is an email message, 
		/// the item name is likely the subject.  In that case, the value must be the concatenation of the
		/// System.ItemNamePrefix and System.ItemName.  Since the value of System.ItemNamePrefix excludes
		/// any trailing whitespace, the concatenation must include a whitespace when generating System.ItemNameDisplay.</para>
		/// <para>
		/// Note that this property is not guaranteed to be unique, but the idea is to promote the most likely
		/// candidate that can be unique and also makes sense for end users. For example, for documents, you
		/// might think about using System.Title as the System.ItemNameDisplay, but in practice the title of
		/// the documents may not be useful or unique enough to be of value as the sole System.ItemNameDisplay.  
		/// Instead, providing the value of System.FileName as the value of System.ItemNameDisplay is a better
		/// candidate.  In Windows Mail, the emails are stored in the file system as .eml files and the 
		/// System.FileName for those files are not human-friendly as they contain GUIDs. In this example, 
		/// promoting System.Subject as System.ItemNameDisplay makes more sense.</para>
		/// <para>
		/// Compatibility notes:</para>
		/// <para>
		/// Shell folder implementations on Vista: use PKEY_ItemNameDisplay for the name column when
		/// you want Explorer to call ISF::GetDisplayNameOf(SHGDN_NORMAL) to get the value of the name. Use
		/// another PKEY (like PKEY_ItemName) when you want Explorer to call either the folder's property store or
		/// ISF2::GetDetailsEx in order to get the value of the name.</para>
		/// <para>
		/// Shell folder implementations on XP: the first column needs to be the name column, and Explorer
		/// will call ISF::GetDisplayNameOf to get the value of the name.  The PKEY/SCID does not matter.</para>
		/// </remarks>
		/// <example>
		/// <list type="table">
		///   <item><term>File:          </term><description>"hello.txt"</description></item>
		///   <item><term>Message:       </term><description>"Re: Let's talk about Tom's argyle socks!"</description></item>
		///   <item><term>Device folder: </term><description>"song.wma"</description></item>
		///   <item><term>Folder:        </term><description>"Documents"</description></item>
		/// </list>
		/// </example>
		public static PropertyKey ItemNameDisplay => new PropertyKey(0xB725F130, 0x47EF, 0x101A, 0xA5, 0xF1, 0x02, 0x60, 0x8C, 0x9E, 0xEB, 0xAC, 10);


		/// <summary>
		/// This is the prefix of an item, used for email messages where the subject begins with "Re:" which is the prefix.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemNamePrefix -- PKEY_ItemNamePrefix</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D7313FF1-A77A-401C-8C99-3DBDD68ADD36, 100</description></item>
		/// </list>
		/// <para>
		/// If the item is a file, then the value of this property is VT_EMPTY.</para>
		/// <para>
		/// If the item is a message, then the value of this property is the forwarding or reply 
		/// prefixes (including delimiting colon, but no whitespace), or VT_EMPTY if there is no prefix.</para>
		/// </remarks>
		/// <example>
		/// <list type="table">
		///  <listheader>
		///        <term><code>System.ItemNamePrefix</code></term><description><code>System.ItemName      System.ItemNameDisplay</code></description>
		///  </listheader>
		///  <item><term><code>VT_EMPTY             </code></term><description><code>"Great day"          "Great day"           </code></description></item>
		///  <item><term><code>"Re:"                </code></term><description><code>"Great day"          "Re: Great day"       </code></description></item>
		///  <item><term><code>"Fwd: "              </code></term><description><code>"Monthly budget"     "Fwd: Monthly budget" </code></description></item>
		///  <item><term><code>VT_EMPTY             </code></term><description><code>"accounts.xls"       "accounts.xls"        </code></description></item>
		/// </list>
		/// </example>
		public static PropertyKey ItemNamePrefix => new PropertyKey(0xD7313FF1, 0xA77A, 0x401C, 0x8C, 0x99, 0x3D, 0xBD, 0xD6, 0x8A, 0xDD, 0x36, 100);

		/// <summary>
		/// This is the generic list of people associated with an item and who contributed to the item.
		/// For example, this is the combination of people in the To list, Cc list and sender of an email message.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemParticipants -- PKEY_ItemParticipants</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D4D0AA16-9948-41A4-AA85-D97FF9646993, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ItemParticipants => new PropertyKey(0xD4D0AA16, 0x9948, 0x41A4, 0xAA, 0x85, 0xD9, 0x7F, 0xF9, 0x64, 0x69, 0x93, 100);

		/// <summary>
		/// This is the user-friendly display path to the item.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemPathDisplay -- PKEY_ItemPathDisplay</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 7</description></item>
		/// </list>
		/// <para>
		/// If the item is a file or folder this property
		/// includes the extension in all cases, and will be localized if a localized name is available.</para>
		/// <para>
		/// For other items,this is the user-friendly equivalent, assuming the item exists in hierarchical storage.</para>
		/// <para>
		/// Unlike System.ItemUrl, this property value does not include the URL scheme.</para>
		/// <para>
		/// To parse an item path, use System.ItemUrl or System.ParsingPath.  To reference shell 
		/// namespace items using shell APIs, use System.ParsingPath.</para>
		/// </remarks>
		/// <example>
		/// <list type="table">
		///   <listheader><term>If the path is...</term><description>The property value is...</description></listheader>
		///   <item><term>"c:\foo\bar\hello.txt"               </term><description>"c:\foo\bar\hello.txt"</description></item>
		///   <item><term>"\\server\share\mydir\goodnews.doc"  </term><description>"\\server\share\mydir\goodnews.doc"</description></item>
		///   <item><term>"\\server\share\numbers.xls"         </term><description>"\\server\share\numbers.xls"</description></item>
		///   <item><term>"c:\foo\MyFolder"                    </term><description>"c:\foo\MyFolder"</description></item>
		///   <item><term>"/Mailbox Account/Inbox/'Re: Hello!'" </term><description>"/Mailbox Account/Inbox/'Re: Hello!'"</description></item>
		/// </list>
		/// </example>
		public static PropertyKey ItemPathDisplay => new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 7);

		/// <summary>
		/// This is the user-friendly display path to the item. The format of the string should be 
		/// tailored such that the name comes first, to optimize for a narrow viewing column.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemPathDisplayNarrow -- PKEY_ItemPathDisplayNarrow</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 8</description></item>
		/// </list>
		/// <para>
		/// If the item is a file, the value excludes the file extension, and includes localized names if they are present.
		/// If the item is a message, the value includes the System.ItemNamePrefix.</para>
		/// <para>
		/// To parse an item path, use System.ItemUrl or System.ParsingPath.</para>
		/// </remarks>
		/// <example>
		/// <list type="table">
		///   <listheader><term>If the path is...</term><description>The property value is...</description></listheader>
		///   <item><term>"c:\foo\bar\hello.txt"                </term><description>"hello(c:\foo\bar)"</description></item>
		///   <item><term>"\\server\share\mydir\goodnews.doc"   </term><description>"goodnews(\\server\share\mydir)"</description></item>
		///   <item><term>"\\server\share\folder"               </term><description>"folder(\\server\share)"</description></item>
		///   <item><term>"c:\foo\MyFolder"                     </term><description>"MyFolder(c:\foo)"</description></item>
		///   <item><term>"/Mailbox Account/Inbox/'Re: Hello!'" </term><description>"Re: Hello! (/Mailbox Account/Inbox)"</description></item>
		/// </list>
		/// </example>
		public static PropertyKey ItemPathDisplayNarrow => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 8);

		/// <summary>
		/// This is the canonical type of the item and is intended to be programmatically parsed.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemType -- PKEY_ItemType</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 11</description></item>
		/// </list>
		/// <para>
		/// If there is no canonical type, the value is VT_EMPTY.</para>
		/// <para>
		/// If the item is a file (ie, System.FileName is not VT_EMPTY), the value is the same as
		/// System.FileExtension.</para>
		/// <para>
		/// Use System.ItemTypeText when you want to display the type to end users in a view.
		/// (If the item is a file, passing the System.ItemType value to PSFormatForDisplay will
		/// result in the same value as System.ItemTypeText.)</para>
		/// </remarks>
		/// <example>
		/// <list type="table">
		///   <listheader><term>If the path is...</term><description>The property value is...</description></listheader>
		///   <item><term>"c:\foo\bar\hello.txt"               </term><description>".txt"</description></item>
		///   <item><term>"\\server\share\mydir\goodnews.doc"  </term><description>".doc"</description></item>
		///   <item><term>"\\server\share\folder"              </term><description>"Directory"</description></item>
		///   <item><term>"c:\foo\MyFolder"                    </term><description>"Directory"</description></item>
		///   <item><term>[desktop]                            </term><description>"Folder"</description></item>
		///   <item><term>"/Mailbox Account/Inbox/'Re: Hello!'"</term><description>"MAPI/IPM.Message"</description></item>
		/// </list>
		/// </example>
		public static PropertyKey ItemType => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 11);

		/// <summary>
		/// This is the user friendly type name of the item.
		/// This is not intended to be programmatically parsed.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemTypeText -- PKEY_ItemTypeText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Storage) B725F130-47EF-101A-A5F1-02608C9EEBAC, 4 (PID_STG_STORAGETYPE)</description></item>
		/// </list>
		/// <para>
		/// If System.ItemType is VT_EMPTY, the value of this property is also VT_EMPTY.</para>
		/// <para>
		/// If the item is a file, the value of this property is the same as if you passed the 
		/// file's System.ItemType value to PSFormatForDisplay.</para>
		/// <para>
		/// This property should not be confused with System.Kind, where System.Kind is a high-level
		/// user friendly kind name. For example, for a document, System.Kind = "Document" and 
		/// System.Item.Type = ".doc" and System.Item.TypeText = "Microsoft Word Document"</para>
		/// </remarks>
		/// <example>
		/// <list type="table">
		///   <listheader><term>If the path is...</term><description>The property value is...</description></listheader>
		///   <item><term>"c:\foo\bar\hello.txt"                </term><description>"Text File"</description></item>
		///   <item><term>"\\server\share\mydir\goodnews.doc"   </term><description>"Microsoft Word Document"</description></item>
		///   <item><term>"\\server\share\folder"               </term><description>"File Folder"</description></item>
		///   <item><term>"c:\foo\MyFolder"                     </term><description>"File Folder"</description></item>
		///   <item><term>"/Mailbox Account/Inbox/'Re: Hello!'" </term><description>"Outlook E-Mail Message"</description></item>
		/// </list>
		/// </example>
		public static PropertyKey ItemTypeText => new PropertyKey(0xB725F130, 0x47EF, 0x101A, 0xA5, 0xF1, 0x02, 0x60, 0x8C, 0x9E, 0xEB, 0xAC, 4);

		/// <summary>
		/// This always represents a well formed URL that points to the item.  
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ItemUrl -- PKEY_ItemUrl</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Query) 49691C90-7E17-101A-A91C-08002B2ECDA9, 9 (PROPID_QUERY_VIRTUALPATH)</description></item>
		/// </list>
		/// To reference shell namespace items using shell APIs, use System.ParsingPath.
		/// </remarks>
		/// <example>
		/// <list type="table">
		///   <item><term>Files:   </term><description>"file:///c:/foo/bar/hello.txt"</description></item>
		///   <item><term>         </term><description>"csc://{GUID}/..."</description></item>
		///   <item><term>Messages:</term><description>"mapi://..."</description></item>
		/// </list>
		/// </example>
		public static PropertyKey ItemUrl => new PropertyKey(0x49691C90, 0x7E17, 0x101A, 0xA9, 0x1C, 0x08, 0x00, 0x2B, 0x2E, 0xCD, 0xA9, 9);

		/// <summary>
		/// The keywords for the item.  Also referred to as tags.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Keywords -- PKEY_Keywords</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)  Legacy code may treat this as VT_LPSTR.</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 5 (PIDSI_KEYWORDS)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Keywords => new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 5);

		/// <summary>
		/// System.Kind is used to map extensions to various Search folders.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Kind -- PKEY_Kind</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>1E3EE840-BC2B-476C-8237-2ACD1A839B22, 3</description></item>
		/// </list>
		/// Extensions are mapped to Kinds at HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Explorer\KindMap
		/// The list of kinds is not extensible.
		/// </remarks>
		public static PropertyKey Kind => new PropertyKey(0x1E3EE840, 0xBC2B, 0x476C, 0x82, 0x37, 0x2A, 0xCD, 0x1A, 0x83, 0x9B, 0x22, 3);

		/// <summary>Possible discrete values for PKEY_Kind.</summary>
		public static class KindValues
		{
			public const string Calendar = "calendar";
			public const string Communication = "communication";
			public const string Contact = "contact";
			public const string Document = "document";
			public const string Email = "email";
			public const string Feed = "feed";
			public const string Folder = "folder";
			public const string Game = "game";
			public const string InstantMessage = "instantmessage";
			public const string Journal = "journal";
			public const string Link = "link";
			public const string Movie = "movie";
			public const string Music = "music";
			public const string Note = "note";
			public const string Picture = "picture";
			public const string Program = "program";
			public const string RecordedTV = "recordedtv";
			public const string SearchFolder = "searchfolder";
			public const string Task = "task";
			public const string Video = "video";
			public const string WebHistory = "webhistory";
		}

		/// <summary>
		/// This is the user-friendly form of System.Kind.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.KindText -- PKEY_KindText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>F04BEF95-C585-4197-A2B7-DF46FDC9EE6D, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey KindText => new PropertyKey(0xF04BEF95, 0xC585, 0x4197, 0xA2, 0xB7, 0xDF, 0x46, 0xFD, 0xC9, 0xEE, 0x6D, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Language -- PKEY_Language</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_DocumentSummaryInformation) D5CDD502-2E9C-101B-9397-08002B2CF9AE, 28</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Language => new PropertyKey(0xD5CDD502, 0x2E9C, 0x101B, 0x93, 0x97, 0x08, 0x00, 0x2B, 0x2C, 0xF9, 0xAE, 28);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.MileageInformation -- PKEY_MileageInformation</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>FDF84370-031A-4ADD-9E91-0D775F1C6605, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MileageInformation => new PropertyKey(0xFDF84370, 0x031A, 0x4ADD, 0x9E, 0x91, 0x0D, 0x77, 0x5F, 0x1C, 0x66, 0x05, 100);

		/// <summary>
		/// The MIME type.  Eg, for EML files: 'message/rfc822'.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.MIMEType -- PKEY_MIMEType</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>0B63E350-9CCC-11D0-BCDB-00805FCCCE04, 5</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey MIMEType => new PropertyKey(0x0B63E350, 0x9CCC, 0x11D0, 0xBC, 0xDB, 0x00, 0x80, 0x5F, 0xCC, 0xCE, 0x04, 5);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Null -- PKEY_Null</description></item>
		///   <item><term><b>Type:     </b></term><description>Null -- VT_NULL</description></item>
		///   <item><term><b>Format ID:</b></term><description>00000000-0000-0000-0000-000000000000, 0</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Null => new PropertyKey(0x00000000, 0x0000, 0x0000, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.OfflineAvailability -- PKEY_OfflineAvailability</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>A94688B6-7D9F-4570-A648-E3DFC0AB2B3F, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OfflineAvailability => new PropertyKey(0xA94688B6, 0x7D9F, 0x4570, 0xA6, 0x48, 0xE3, 0xDF, 0xC0, 0xAB, 0x2B, 0x3F, 100);

		/// <summary>Possible discrete values for PKEY_OfflineAvailability.</summary>
		public enum OfflineAvailabilityValues : uint
		{
			NotAvailable = 0,
			Available = 1,
			AlwaysAvailable = 2,
		}

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.OfflineStatus -- PKEY_OfflineStatus</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>6D24888F-4718-4BDA-AFED-EA0FB4386CD8, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OfflineStatus => new PropertyKey(0x6D24888F, 0x4718, 0x4BDA, 0xAF, 0xED, 0xEA, 0x0F, 0xB4, 0x38, 0x6C, 0xD8, 100);

		/// <summary>Possible discrete values for PKEY_OfflineStatus.</summary>
		public enum OfflineStatusValues : uint
		{
			Online = 0,
			Offline = 1,
			OfflineForced = 2,
			OfflineSlow = 3,
			OfflineError = 4,
			OfflineItemVersionConflict = 5,
			OfflineSuspended = 6,
		}

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.OriginalFileName -- PKEY_OriginalFileName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSFMTID_VERSION) 0CEF7D53-FA64-11D1-A203-0000F81FEDEE, 6</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OriginalFileName => new PropertyKey(0x0CEF7D53, 0xFA64, 0x11D1, 0xA2, 0x03, 0x00, 0x00, 0xF8, 0x1F, 0xED, 0xEE, 6);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ParentalRating -- PKEY_ParentalRating</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSGUID_MEDIAFILESUMMARYINFORMATION) 64440492-4C8B-11D1-8B70-080036B11A03, 21 (PIDMSI_PARENTAL_RATING)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ParentalRating => new PropertyKey(0x64440492, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 21);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ParentalRatingReason -- PKEY_ParentalRatingReason</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>10984E0A-F9F2-4321-B7EF-BAF195AF4319, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ParentalRatingReason => new PropertyKey(0x10984E0A, 0xF9F2, 0x4321, 0xB7, 0xEF, 0xBA, 0xF1, 0x95, 0xAF, 0x43, 0x19, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ParentalRatingsOrganization -- PKEY_ParentalRatingsOrganization</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>A7FE0840-1344-46F0-8D37-52ED712A4BF9, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ParentalRatingsOrganization => new PropertyKey(0xA7FE0840, 0x1344, 0x46F0, 0x8D, 0x37, 0x52, 0xED, 0x71, 0x2A, 0x4B, 0xF9, 100);

		/// <summary>
		/// used to get the IBindCtx for an item for parsing</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ParsingBindContext -- PKEY_ParsingBindContext</description></item>
		///   <item><term><b>Type:     </b></term><description>Any -- VT_NULL  Legacy code may treat this as VT_UNKNOWN.</description></item>
		///   <item><term><b>Format ID:</b></term><description>DFB9A04D-362F-4CA3-B30B-0254B17B5B84, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ParsingBindContext => new PropertyKey(0xDFB9A04D, 0x362F, 0x4CA3, 0xB3, 0x0B, 0x02, 0x54, 0xB1, 0x7B, 0x5B, 0x84, 100);

		/// <summary>
		/// The shell namespace name of an item relative to a parent folder.
		/// This name may be passed to IShellFolder::ParseDisplayName() of the parent shell folder.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ParsingName -- PKEY_ParsingName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 24</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ParsingName => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 24);

		/// <summary>
		/// This is the shell namespace path to the item.  This path may be passed to SHParseDisplayName
		/// to parse the path to the correct shell folder.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ParsingPath -- PKEY_ParsingPath</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 30</description></item>
		/// </list>
		/// <para>
		/// If the item is a file, the value is identical to System.ItemPathDisplay.</para>
		/// <para>
		/// If the item cannot be accessed through the shell namespace, this value is VT_EMPTY.</para>
		/// </remarks>
		public static PropertyKey ParsingPath => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 30);

		/// <summary>
		/// The perceived type of a shell item, based upon its canonical type.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PerceivedType -- PKEY_PerceivedType</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 9</description></item>
		/// </list>
		/// For the enumerated values of PKEY_PerceivedType, see the PERCEIVED_TYPE_* values in shtypes.idl.
		/// </remarks>
		public static PropertyKey PerceivedType => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 9);

		/// <summary>
		/// The amount filled as a percentage, multiplied by 100 (ie, the valid range is 0 through 100).</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PercentFull -- PKEY_PercentFull</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Volume) 9B174B35-40FF-11D2-A27E-00C04FC30871, 5  (Filesystem Volume Properties)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PercentFull => new PropertyKey(0x9B174B35, 0x40FF, 0x11D2, 0xA2, 0x7E, 0x00, 0xC0, 0x4F, 0xC3, 0x08, 0x71, 5);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Priority -- PKEY_Priority</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4, 5</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Priority => new PropertyKey(0x9C1FCF74, 0x2D97, 0x41BA, 0xB4, 0xAE, 0xCB, 0x2E, 0x36, 0x61, 0xA6, 0xE4, 5);

		/// <summary>Possible discrete values for PKEY_Priority.</summary>
		public enum PriorityValues : ushort
		{
			Low = 0,
			Normal = 1,
			High = 2,
		}

		/// <summary>
		/// This is the user-friendly form of System.Priority.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.PriorityText -- PKEY_PriorityText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D98BE98B-B86B-4095-BF52-9D23B2E0A752, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PriorityText => new PropertyKey(0xD98BE98B, 0xB86B, 0x4095, 0xBF, 0x52, 0x9D, 0x23, 0xB2, 0xE0, 0xA7, 0x52, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Project -- PKEY_Project</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>39A7F922-477C-48DE-8BC8-B28441E342E3, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Project => new PropertyKey(0x39A7F922, 0x477C, 0x48DE, 0x8B, 0xC8, 0xB2, 0x84, 0x41, 0xE3, 0x42, 0xE3, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ProviderItemID -- PKEY_ProviderItemID</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>F21D9941-81F0-471A-ADEE-4E74B49217ED, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ProviderItemID => new PropertyKey(0xF21D9941, 0x81F0, 0x471A, 0xAD, 0xEE, 0x4E, 0x74, 0xB4, 0x92, 0x17, 0xED, 100);

		/// <summary>
		/// Indicates the users preference rating of an item on a scale of 0-99
		/// (0 = unrated, 1-12 = One Star, 13-37 = Two Stars, 38-62 = Three Stars, 63-87 = Four Stars, 88-99 = Five Stars).</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Rating -- PKEY_Rating</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSGUID_MEDIAFILESUMMARYINFORMATION) 64440492-4C8B-11D1-8B70-080036B11A03, 9 (PIDMSI_RATING)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Rating => new PropertyKey(0x64440492, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 9);

		/// <summary>Use the following constants to convert between visual stars and the ratings value.</summary>
		public static class Ratings
		{
			public static class Unrated { public const uint Min = 0; public const uint Set = 0; public const uint Max = 0; }
			public static class OneStar { public const uint Min = 1; public const uint Set = 1; public const uint Max = 12; }
			public static class TwoStars { public const uint Min = 13; public const uint Set = 25; public const uint Max = 37; }
			public static class ThreeStars { public const uint Min = 38; public const uint Set = 50; public const uint Max = 62; }
			public static class FourStars { public const uint Min = 63; public const uint Set = 75; public const uint Max = 87; }
			public static class FiveStars { public const uint Min = 88; public const uint Set = 99; public const uint Max = 99; }
		}


		/// <summary>
		/// This is the user-friendly form of System.Rating.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.RatingText -- PKEY_RatingText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>90197CA7-FD8F-4E8C-9DA3-B57E1E609295, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey RatingText => new PropertyKey(0x90197CA7, 0xFD8F, 0x4E8C, 0x9D, 0xA3, 0xB5, 0x7E, 0x1E, 0x60, 0x92, 0x95, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Sensitivity -- PKEY_Sensitivity</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>F8D3F6AC-4874-42CB-BE59-AB454B30716A, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Sensitivity => new PropertyKey(0xF8D3F6AC, 0x4874, 0x42CB, 0xBE, 0x59, 0xAB, 0x45, 0x4B, 0x30, 0x71, 0x6A, 100);

		/// <summary>Possible discrete values for PKEY_Sensitivity.</summary>
		public enum SensitivityValues : ushort
		{
			Normal = 0,
			Personal = 1,
			Private = 2,
			Confidential = 3,
		}

		/// <summary>
		/// This is the user-friendly form of System.Sensitivity.  Not intended to be parsed
		/// programmatically.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.SensitivityText -- PKEY_SensitivityText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D0C7F054-3F72-4725-8527-129A577CB269, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SensitivityText => new PropertyKey(0xD0C7F054, 0x3F72, 0x4725, 0x85, 0x27, 0x12, 0x9A, 0x57, 0x7C, 0xB2, 0x69, 100);

		/// <summary>
		/// IShellFolder::GetAttributesOf flags, with SFGAO_PKEYSFGAOMASK attributes masked out.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.SFGAOFlags -- PKEY_SFGAOFlags</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 25</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SFGAOFlags => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 25);

		/// <summary>
		/// Who is the item shared with?</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.SharedWith -- PKEY_SharedWith</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>EF884C5B-2BFE-41BB-AAE5-76EEDF4F9902, 200</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SharedWith => new PropertyKey(0xEF884C5B, 0x2BFE, 0x41BB, 0xAA, 0xE5, 0x76, 0xEE, 0xDF, 0x4F, 0x99, 0x02, 200);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ShareUserRating -- PKEY_ShareUserRating</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSGUID_MEDIAFILESUMMARYINFORMATION) 64440492-4C8B-11D1-8B70-080036B11A03, 12 (PIDMSI_SHARE_USER_RATING)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ShareUserRating => new PropertyKey(0x64440492, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 12);

		/// <summary>
		/// Set this to a string value of 'True' to omit this item from shell views</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Shell.OmitFromView -- PKEY_OmitFromView</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>DE35258C-C695-4CBC-B982-38B0AD24CED0, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey OmitFromView => new PropertyKey(0xDE35258C, 0xC695, 0x4CBC, 0xB9, 0x82, 0x38, 0xB0, 0xAD, 0x24, 0xCE, 0xD0, 2);

		/// <summary>
		/// Indicates the users preference rating of an item on a scale of 0-5
		/// (0=unrated, 1=One Star, 2=Two Stars, 3=Three Stars,4=Four Stars, 5=Five Stars)
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.SimpleRating -- PKEY_SimpleRating</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>A09F084E-AD41-489F-8076-AA5BE3082BCA, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SimpleRating => new PropertyKey(0xA09F084E, 0xAD41, 0x489F, 0x80, 0x76, 0xAA, 0x5B, 0xE3, 0x08, 0x2B, 0xCA, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Size -- PKEY_Size</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Storage) B725F130-47EF-101A-A5F1-02608C9EEBAC, 12 (PID_STG_SIZE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Size => new PropertyKey(0xB725F130, 0x47EF, 0x101A, 0xA5, 0xF1, 0x02, 0x60, 0x8C, 0x9E, 0xEB, 0xAC, 12);

		/// <summary>
		/// PropertyTagSoftwareUsed</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.SoftwareUsed -- PKEY_SoftwareUsed</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ImageProperties) 14B81DA1-0135-4D31-96D9-6CBFC9671A99, 305</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SoftwareUsed => new PropertyKey(0x14B81DA1, 0x0135, 0x4D31, 0x96, 0xD9, 0x6C, 0xBF, 0xC9, 0x67, 0x1A, 0x99, 305);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.SourceItem -- PKEY_SourceItem</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>668CDFA5-7A1B-4323-AE4B-E527393A1D81, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SourceItem => new PropertyKey(0x668CDFA5, 0x7A1B, 0x4323, 0xAE, 0x4B, 0xE5, 0x27, 0x39, 0x3A, 0x1D, 0x81, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.StartDate -- PKEY_StartDate</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>48FD6EC8-8A12-4CDF-A03E-4EC5A511EDDE, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StartDate => new PropertyKey(0x48FD6EC8, 0x8A12, 0x4CDF, 0xA0, 0x3E, 0x4E, 0xC5, 0xA5, 0x11, 0xED, 0xDE, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Status -- PKEY_Status</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_IntSite) 000214A1-0000-0000-C000-000000000046, 9</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Status => new PropertyKey(0x000214A1, 0x0000, 0x0000, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 9);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Subject -- PKEY_Subject</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 3 (PIDSI_SUBJECT)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Subject => new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 3);

		/// <summary>
		/// A data that represents the thumbnail in VT_CF format.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Thumbnail -- PKEY_Thumbnail</description></item>
		///   <item><term><b>Type:     </b></term><description>Clipboard -- VT_CF</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 17 (PIDSI_THUMBNAIL)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Thumbnail => new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 17);

		/// <summary>
		/// Unique value that can be used as a key to cache thumbnails. The value changes when the name,
		/// volume, or data modified of an item changes.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ThumbnailCacheId -- PKEY_ThumbnailCacheId</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>446D16B1-8DAD-4870-A748-402EA43D788C, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ThumbnailCacheId => new PropertyKey(0x446D16B1, 0x8DAD, 0x4870, 0xA7, 0x48, 0x40, 0x2E, 0xA4, 0x3D, 0x78, 0x8C, 100);

		/// <summary>
		/// Data that represents the thumbnail in VT_STREAM format that GDI+/WindowsCodecs supports (jpg, png, etc).</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ThumbnailStream -- PKEY_ThumbnailStream</description></item>
		///   <item><term><b>Type:     </b></term><description>Stream -- VT_STREAM</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 27</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ThumbnailStream => new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 27);

		/// <summary>
		/// Title of item.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Title -- PKEY_Title</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)  Legacy code may treat this as VT_LPSTR.</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_SummaryInformation) F29F85E0-4FF9-1068-AB91-08002B27B3D9, 2 (PIDSI_TITLE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Title => new PropertyKey(0xF29F85E0, 0x4FF9, 0x1068, 0xAB, 0x91, 0x08, 0x00, 0x2B, 0x27, 0xB3, 0xD9, 2);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.TotalFileSize -- PKEY_TotalFileSize</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt64 -- VT_UI8</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 14</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TotalFileSize => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 14);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Trademarks -- PKEY_Trademarks</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSFMTID_VERSION) 0CEF7D53-FA64-11D1-A203-0000F81FEDEE, 9 (PIDVSI_Trademarks)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Trademarks => new PropertyKey(0x0CEF7D53, 0xFA64, 0x11D1, 0xA2, 0x03, 0x00, 0x00, 0xF8, 0x1F, 0xED, 0xEE, 9);
	}
}
