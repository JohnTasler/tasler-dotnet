
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Note
	{
		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Note.Color -- PKEY_Color</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>4776CAFA-BCE4-4CB1-A23E-265E76D8EB11, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Color => new(0x4776CAFA, 0xBCE4, 0x4CB1, 0xA2, 0x3E, 0x26, 0x5E, 0x76, 0xD8, 0xEB, 0x11, 100);

		/// <summary>Possible discrete values for PKEY_Color.</summary>
		public enum ColorValues : ushort
		{
			Blue = 0,
			Green = 1,
			Pink = 2,
			Yellow = 3,
			White = 4,
			LightGreen = 5,
		}

		/// <summary>
		/// This is the user-friendly form of System.Note.Color.
		/// Not intended to be parsed programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Note.ColorText -- PKEY_ColorText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>46B4E8DE-CDB2-440D-885C-1658EB65B914, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ColorText => new(0x46B4E8DE, 0xCDB2, 0x440D, 0x88, 0x5C, 0x16, 0x58, 0xEB, 0x65, 0xB9, 0x14, 100);
	}
}
