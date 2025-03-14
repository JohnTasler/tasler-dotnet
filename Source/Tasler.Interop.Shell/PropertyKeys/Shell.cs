namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Shell
	{
		/// <summary>
		/// The contents of a SHDESCRIPTIONID structure as a buffer of bytes.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.DescriptionID -- PKEY_DescriptionID</description></item>
		///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_ShellDetails) 28636AA6-953D-11D2-B5D6-00C04FD918D0, 2 (PID_DESCRIPTIONID)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DescriptionID => new PropertyKey(0x28636AA6, 0x953D, 0x11D2, 0xB5, 0xD6, 0x00, 0xC0, 0x4F, 0xD9, 0x18, 0xD0, 2);

		/// <summary>
		/// Expresses the SFGAO flags of a link as string values and is used as a query optimization.
		/// See PKEY_SFGAOFlagsStrings for possible values of this.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Link.TargetSFGAOFlagsStrings -- PKEY_TargetSFGAOFlagsStrings</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D6942081-D53B-443D-AD47-5E059D9CD27A, 3</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TargetSFGAOFlagsStrings => new PropertyKey(0xD6942081, 0xD53B, 0x443D, 0xAD, 0x47, 0x5E, 0x05, 0x9D, 0x9C, 0xD2, 0x7A, 3);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Link.TargetUrl -- PKEY_TargetUrl</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>5CBF2787-48CF-4208-B90E-EE5E5D420294, 2  (PKEYs relating to URLs.  Used by IE History.)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TargetUrl => new PropertyKey(0x5CBF2787, 0x48CF, 0x4208, 0xB9, 0x0E, 0xEE, 0x5E, 0x5D, 0x42, 0x02, 0x94, 2);

		/// <summary>
		/// Expresses the SFGAO flags as string values and is used as a query optimization.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Shell.SFGAOFlagsStrings -- PKEY_SFGAOFlagsStrings</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D6942081-D53B-443D-AD47-5E059D9CD27A, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SFGAOFlagsStrings => new PropertyKey(0xD6942081, 0xD53B, 0x443D, 0xAD, 0x47, 0x5E, 0x05, 0x9D, 0x9C, 0xD2, 0x7A, 2);

		/// <summary>Possible discrete values for PKEY_SFGAOFlagsStrings.</summary>
		public static class SFGAOFlags
		{
			public const string FileSystem = "filesys";
			public const string FileAncestor = "fileanc";
			public const string StorageAncestor = "storageanc";
			public const string Stream = "stream";
			public const string Link = "link";
			public const string Hidden = "hidden";
			public const string Folder = "folder";
			public const string NonEnumerated = "nonenum";
			public const string Browsable = "browsable";
		}
	}
}
