
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Volume
	{
		/// <summary>
		/// Indicates the filesystem of the volume.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Volume.FileSystem -- PKEY_FileSystem</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Volume) 9B174B35-40FF-11D2-A27E-00C04FC30871, 4 (PID_VOLUME_FILESYSTEM)  (Filesystem Volume Properties)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FileSystem => new(0x9B174B35, 0x40FF, 0x11D2, 0xA2, 0x7E, 0x00, 0xC0, 0x4F, 0xC3, 0x08, 0x71, 4);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Volume.IsMappedDrive -- PKEY_IsMappedDrive</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>149C0B69-2C2D-48FC-808F-D318D78C4636, 2</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsMappedDrive => new(0x149C0B69, 0x2C2D, 0x48FC, 0x80, 0x8F, 0xD3, 0x18, 0xD7, 0x8C, 0x46, 0x36, 2);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Volume.IsRoot -- PKEY_IsRoot</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_Volume) 9B174B35-40FF-11D2-A27E-00C04FC30871, 10  (Filesystem Volume Properties)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsRoot => new(0x9B174B35, 0x40FF, 0x11D2, 0xA2, 0x7E, 0x00, 0xC0, 0x4F, 0xC3, 0x08, 0x71, 10);
	}
}
