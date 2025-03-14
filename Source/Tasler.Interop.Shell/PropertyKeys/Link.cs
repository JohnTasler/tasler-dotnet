
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Link
	{
		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Link.Comment -- PKEY_Comment</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSGUID_LINK) B9B4B3FC-2B51-4A42-B5D8-324146AFCF25, 5</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Comment => new PropertyKey(0xB9B4B3FC, 0x2B51, 0x4A42, 0xB5, 0xD8, 0x32, 0x41, 0x46, 0xAF, 0xCF, 0x25, 5);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Link.DateVisited -- PKEY_DateVisited</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>5CBF2787-48CF-4208-B90E-EE5E5D420294, 23  (PKEYs relating to URLs.  Used by IE History.)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateVisited => new PropertyKey(0x5CBF2787, 0x48CF, 0x4208, 0xB9, 0x0E, 0xEE, 0x5E, 0x5D, 0x42, 0x02, 0x94, 23);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Link.Description -- PKEY_Description</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>5CBF2787-48CF-4208-B90E-EE5E5D420294, 21  (PKEYs relating to URLs.  Used by IE History.)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Description => new PropertyKey(0x5CBF2787, 0x48CF, 0x4208, 0xB9, 0x0E, 0xEE, 0x5E, 0x5D, 0x42, 0x02, 0x94, 21);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Link.Status -- PKEY_Status</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSGUID_LINK) B9B4B3FC-2B51-4A42-B5D8-324146AFCF25, 3 (PID_LINK_TARGET_TYPE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Status => new PropertyKey(0xB9B4B3FC, 0x2B51, 0x4A42, 0xB5, 0xD8, 0x32, 0x41, 0x46, 0xAF, 0xCF, 0x25, 3);

		/// <summary>Possible discrete values for PKEY_Status.</summary>
		public enum StatusValues : int
		{
			Resolved = 1,
			Broken = 2,
		}

		/// <summary>
		/// The file extension of the link target.  See System.File.Extension</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Link.TargetExtension -- PKEY_TargetExtension</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>7A7D76F4-B630-4BD7-95FF-37CC51A975C9, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TargetExtension => new PropertyKey(0x7A7D76F4, 0xB630, 0x4BD7, 0x95, 0xFF, 0x37, 0xCC, 0x51, 0xA9, 0x75, 0xC9, 2);

		/// <summary>
		/// This is the shell namespace path to the target of the link item.  This path may be passed to 
		/// SHParseDisplayName to parse the path to the correct shell folder.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Link.TargetParsingPath -- PKEY_TargetParsingPath</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSGUID_LINK) B9B4B3FC-2B51-4A42-B5D8-324146AFCF25, 2 (PID_LINK_TARGET)</description></item>
		/// </list>
		/// <para>
		/// If the target item is a file, the value is identical to System.ItemPathDisplay.</para>
		/// <para>
		/// If the target item cannot be accessed through the shell namespace, this value is VT_EMPTY.</para>
		/// </remarks>
		public static PropertyKey TargetParsingPath => new PropertyKey(0xB9B4B3FC, 0x2B51, 0x4A42, 0xB5, 0xD8, 0x32, 0x41, 0x46, 0xAF, 0xCF, 0x25, 2);

		/// <summary>
		/// IShellFolder::GetAttributesOf flags for the target of a link, with SFGAO_PKEYSFGAOMASK attributes masked out.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Link.TargetSFGAOFlags -- PKEY_TargetSFGAOFlags</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSGUID_LINK) B9B4B3FC-2B51-4A42-B5D8-324146AFCF25, 8</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TargetSFGAOFlags => new PropertyKey(0xB9B4B3FC, 0x2B51, 0x4A42, 0xB5, 0xD8, 0x32, 0x41, 0x46, 0xAF, 0xCF, 0x25, 8);
	}
}
