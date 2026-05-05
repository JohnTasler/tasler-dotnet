namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static partial class Shell
	{
		/// <summary>
		/// The date and time of when the activity described in System.ActivityInfo took place for this item.
		/// If System.ActivityInfo is VT_EMPTY, then this property should be too.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ActivityDate -- PKEY_ActivityDate</description></item>r
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{30C8EEF4-A832-41E2-AB32-E3C3CA28FD29}, 23</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ActivityDate => new(0x30C8EEF4, 0xA832, 0x41E2, 0xAB, 0x32, 0xE3, 0xC3, 0xCA, 0x28, 0xFD, 0x29, 23);

		/// <summary>
		/// The string corresponding to a glyph in the Segoe Fluent Icons font that represents the activity
		/// described in System.ActivityInfo. For example, "\xE70F" for a file that was recently edited, or "\xE716"
		/// for a file that was recently shared. If System.ActivityInfo is VT_EMPTY, then this property should be too.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ActivityIcon -- PKEY_ActivityIcon</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{30C8EEF4-A832-41E2-AB32-E3C3CA28FD29}, 24</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ActivityIcon => new(0x30C8EEF4, 0xA832, 0x41E2, 0xAB, 0x32, 0xE3, 0xC3, 0xCA, 0x28, 0xFD, 0x29, 24);

		/// <summary>
		/// A user-friendly description of activity that took place on this file or folder. This can be used to
		/// provide context as to why an item has been recommended to the user, or to describe a recent action
		/// taken on the item. For example, "You edited this" for a file the user recently edited, or
		/// "John Doe shared this with you" for a file that was recently shared.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.ActivityInfo -- PKEY_ActivityInfo</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{30C8EEF4-A832-41E2-AB32-E3C3CA28FD29}, 17</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ActivityInfo => new(0x30C8EEF4, 0xA832, 0x41E2, 0xAB, 0x32, 0xE3, 0xC3, 0xCA, 0x28, 0xFD, 0x29, 17);

		/// <summary>
		/// The contents of a SHDESCRIPTIONID structure as a buffer of bytes.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DescriptionID -- PKEY_DescriptionID</description></item>
		///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 2 (PID_DESCRIPTIONID)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DescriptionID => new(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 2);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.InternalName -- PKEY_InternalName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSFMTID_VERSION) {0CEF7D53-FA64-11D1-A203-0000F81FEDEE}, 5 (PIDVSI_InternalName)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey InternalName => new(0x0CEF7D53, 0xFA64, 0x11D1, 0xA2, 0x03, 0x00, 0x00, 0xF8, 0x1F, 0xED, 0xEE, 5);

		/// <summary>
		/// Library locations count
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.LibraryLocationsCount -- PKEY_LibraryLocationsCount</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{908696C7-8F87-44F2-80ED-A8C1C6894575}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey LibraryLocationsCount => new(0x908696C7, 0x8F87, 0x44F2, 0x80, 0xED, 0xA8, 0xC1, 0xC6, 0x89, 0x45, 0x75, 2);


		/// <summary>
		/// Expresses the SFGAO flags of a link as string values and is used as a query optimization.
		/// See PKEY_SFGAOFlagsStrings for possible values of this.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Link.TargetSFGAOFlagsStrings -- PKEY_TargetSFGAOFlagsStrings</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D6942081-D53B-443D-AD47-5E059D9CD27A, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey LinkTargetSFGAOFlagsStrings => new(0xD6942081, 0xD53B, 0x443D, 0xAD, 0x47, 0x5E, 0x05, 0x9D, 0x9C, 0xD2, 0x7A, 3);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Link.TargetUrl -- PKEY_TargetUrl</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>5CBF2787-48CF-4208-B90E-EE5E5D420294, 2  (PKEYs relating to URLs.  Used by IE History.)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey LinkTargetUrl => new(0x5CBF2787, 0x48CF, 0x4208, 0xB9, 0x0E, 0xEE, 0x5E, 0x5D, 0x42, 0x02, 0x94, 2);

		/// <summary>
		/// The CLSID of the name space extension for an item, the object that implements IShellFolder for this item.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.NamespaceCLSID -- PKEY_NamespaceCLSID</description></item>r
		///   <item><term><b>Type:     </b></term><description>Guid -- VT_CLSID</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) {28636AA6-953D-11D2-B5D6-00C04FD918D0}, 6</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey NamespaceCLSID => new(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 6);

		/// <summary>
		/// Property for Copilot Key Provider application to opt in to fastpath activation.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Shell.CopilotKeyProviderFastPathMessage -- PKEY_Shell_CopilotKeyProviderFastPathMessage</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{38652BCA-4329-4E74-86F9-39CF29345EEA}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Shell_CopilotKeyProviderFastPathMessage => new(0x38652BCA, 0x4329, 0x4E74, 0x86, 0xF9, 0x39, 0xCF, 0x29, 0x34, 0x5E, 0xEA, 2);


		/// <summary>
		/// Expresses the SFGAO flags as string values and is used as a query optimization.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Shell.SFGAOFlagsStrings -- PKEY_SFGAOFlagsStrings</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D6942081-D53B-443D-AD47-5E059D9CD27A, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SFGAOFlagsStrings => new(0xD6942081, 0xD53B, 0x443D, 0xAD, 0x47, 0x5E, 0x05, 0x9D, 0x9C, 0xD2, 0x7A, 2);

		/// <summary>Possible discrete values for PKEY_SFGAOFlagsStrings.
		/// </summary>
		public static class SFGAOFlags
		{
			public const string FileSystem      = "filesys";
			public const string FileAncestor    = "fileanc";
			public const string StorageAncestor = "storageanc";
			public const string Stream          = "stream";
			public const string Link            = "link";
			public const string Hidden          = "hidden";
			public const string Folder          = "folder";
			public const string NonEnumerated   = "nonenum";
			public const string Browsable       = "browsable";
		}

		/// <summary>
		/// Count of selected items in the view and estimated total size
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.StatusBarSelectedItemCount -- PKEY_StatusBarSelectedItemCount</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{26DC287C-6E3D-4BD3-B2B0-6A26BA2E346D}, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StatusBarSelectedItemCount => new(0x26DC287C, 0x6E3D, 0x4BD3, 0xB2, 0xB0, 0x6A, 0x26, 0xBA, 0x2E, 0x34, 0x6D, 3);

		/// <summary>
		/// Count of items in the view
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.StatusBarViewItemCount -- PKEY_StatusBarViewItemCount</description></item>r
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{26DC287C-6E3D-4BD3-B2B0-6A26BA2E346D}, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StatusBarViewItemCount => new(0x26DC287C, 0x6E3D, 0x4BD3, 0xB2, 0xB0, 0x6A, 0x26, 0xBA, 0x2E, 0x34, 0x6D, 2);

		/// <summary>
		/// Property for the cloud file state icon.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.StorageProviderState -- PKEY_StorageProviderState</description></item>r
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{E77E90DF-6271-4F5B-834F-2DD1F245DDA4}, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StorageProviderState => new(0xE77E90DF, 0x6271, 0x4F5B, 0x83, 0x4F, 0x2D, 0xD1, 0xF2, 0x45, 0xDD, 0xA4, 3);

		/// <summary>Possible discrete values for PKEY_StorageProviderState.</summary>
		public enum StorageProviderStates
		{
			None               = 0,
			Sparse             = 1,
			InSync             = 2,
			Pinned             = 3,
			PendingUpload      = 4,
			PendingDownload    = 5,
			Transferring       = 6,
			Error              = 7,
			Warning            = 8,
			Excluded           = 9,
			PendingUnspecified = 10,
		}

		/// <summary>
		/// An array of two UInt32 values (max value, current value).
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.StorageProviderTransferProgress -- PKEY_StorageProviderTransferProgress</description></item>r
		///   <item><term><b>Type:     </b></term><description>Multivalue UInt32 -- VT_VECTOR | VT_UI4  (For variants: VT_ARRAY | VT_UI4)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{E77E90DF-6271-4F5B-834F-2DD1F245DDA4}, 4</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey StorageProviderTransferProgress => new(0xE77E90DF, 0x6271, 0x4F5B, 0x83, 0x4F, 0x2D, 0xD1, 0xF2, 0x45, 0xDD, 0xA4, 4);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.WebAccountID -- PKEY_WebAccountID</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{30C8EEF4-A832-41E2-AB32-E3C3CA28FD29}, 7</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey WebAccountID => new(0x30C8EEF4, 0xA832, 0x41E2, 0xAB, 0x32, 0xE3, 0xC3, 0xCA, 0x28, 0xFD, 0x29, 7);

	}
}
