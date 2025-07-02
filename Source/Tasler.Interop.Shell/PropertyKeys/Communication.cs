
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Communication
	{
		/// <summary>
		/// Account Name</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.AccountName -- PKEY_AccountName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 9</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AccountName => new(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 9);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.Suffix -- PKEY_Suffix</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>807B653A-9E91-43EF-8F97-11CE04EE20C5, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Suffix => new(0x807B653A, 0x9E91, 0x43EF, 0x8F, 0x97, 0x11, 0xCE, 0x04, 0xEE, 0x20, 0xC5, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.TaskStatus -- PKEY_TaskStatus</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>BE1A72C6-9A1D-46B7-AFE7-AFAF8CEF4999, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TaskStatus => new(0xBE1A72C6, 0x9A1D, 0x46B7, 0xAF, 0xE7, 0xAF, 0xAF, 0x8C, 0xEF, 0x49, 0x99, 100);

		/// <summary>Possible discrete values for PKEY_TaskStatus.</summary>
		public enum TaskStatusValues : ushort
		{
			NotStarted = 0,
			InProgress = 1,
			Complete = 2,
			Waiting = 3,
			Deferred = 4,
		}

		/// <summary>
		/// This is the user-friendly form of System.Communication.TaskStatus.  Not intended to be parsed
		/// programmatically.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.TaskStatusText -- PKEY_TaskStatusText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>A6744477-C237-475B-A075-54F34498292A, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TaskStatusText => new(0xA6744477, 0xC237, 0x475B, 0xA0, 0x75, 0x54, 0xF3, 0x44, 0x98, 0x29, 0x2A, 100);
	}
}
