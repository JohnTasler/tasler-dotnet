
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Task
	{
		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Task.BillingInformation -- PKEY_BillingInformation</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>D37D52C6-261C-4303-82B3-08B926AC6F12, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BillingInformation => new PropertyKey(0xD37D52C6, 0x261C, 0x4303, 0x82, 0xB3, 0x08, 0xB9, 0x26, 0xAC, 0x6F, 0x12, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Task.CompletionStatus -- PKEY_CompletionStatus</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>084D8A0A-E6D5-40DE-BF1F-C8820E7C877C, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey CompletionStatus => new PropertyKey(0x084D8A0A, 0xE6D5, 0x40DE, 0xBF, 0x1F, 0xC8, 0x82, 0x0E, 0x7C, 0x87, 0x7C, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Task.Owner -- PKEY_Owner</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>08C7CC5F-60F2-4494-AD75-55E3E0B5ADD0, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Owner => new PropertyKey(0x08C7CC5F, 0x60F2, 0x4494, 0xAD, 0x75, 0x55, 0xE3, 0xE0, 0xB5, 0xAD, 0xD0, 100);
	}
}
