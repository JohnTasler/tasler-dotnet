
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Communication
	{
		/// <summary>
		/// Account Name</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.AccountName -- PKEY_Communication_AccountName</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 9</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AccountName => new(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 9);

		/// <summary>Date the item expires due to the retention policy.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.DateItemExpires -- PKEY_Communication_DateItemExpires</description></item>
		///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{428040AC-A177-4C8A-9760-F6F761227F9A}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DateItemExpires => new(0x428040AC, 0xA177, 0x4C8A, 0x97, 0x60, 0xF6, 0xF7, 0x61, 0x22, 0x7F, 0x9A, 100);

		/// <summary>Indicates whether a communication was incoming or outgoing</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.Direction -- PKEY_Communication_Direction</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>{8E531030-B960-4346-AE0D-66BC9A86FB94}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Direction => new(0x8E531030, 0xB960, 0x4346, 0xAE, 0x0D, 0x66, 0xBC, 0x9A, 0x86, 0xFB, 0x94, 100);

		/// <summary>Possible discrete values for PKEY_Communication_Direction.</summary>
		public enum DirectionValues : short
		{
			Unknown  = 0,
			Incoming = 1,
			Outgoing = 2,
		}

		/// <summary>This is the icon index used on messages marked for followup.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.FollowupIconIndex -- PKEY_Communication_FollowupIconIndex</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{83A6347E-6FE4-4F40-BA9C-C4865240D1F4}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey FollowupIconIndex => new(0x83A6347E, 0x6FE4, 0x4F40, 0xBA, 0x9C, 0xC4, 0x86, 0x52, 0x40, 0xD1, 0xF4, 100);

		/// <summary>This property will be true if the item is a header item which means the item hasn't been fully downloaded.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.HeaderItem -- PKEY_Communication_HeaderItem</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{C9C34F84-2241-4401-B607-BD20ED75AE7F}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey HeaderItem => new(0xC9C34F84, 0x2241, 0x4401, 0xB6, 0x07, 0xBD, 0x20, 0xED, 0x75, 0xAE, 0x7F, 100);

		/// <summary>This a string used to identify the retention policy applied to the item.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.PolicyTag -- PKEY_Communication_PolicyTag</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{EC0B4191-AB0B-4C66-90B6-C6637CDEBBAB}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PolicyTag => new(0xEC0B4191, 0xAB0B, 0x4C66, 0x90, 0xB6, 0xC6, 0x63, 0x7C, 0xDE, 0xBB, 0xAB, 100);

		/// <summary>Security flags associated with the item to know if the item is encrypted, signed or DRM enabled.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.SecurityFlags -- PKEY_Communication_SecurityFlags</description></item>
		///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
		///   <item><term><b>Format ID:</b></term><description>{8619A4B6-9F4D-4429-8C0F-B996CA59E335}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SecurityFlags => new(0x8619A4B6, 0x9F4D, 0x4429, 0x8C, 0x0F, 0xB9, 0x96, 0xCA, 0x59, 0xE3, 0x35, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.Suffix -- PKEY_Communication_Suffix</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>807B653A-9E91-43EF-8F97-11CE04EE20C5, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Suffix => new(0x807B653A, 0x9E91, 0x43EF, 0x8F, 0x97, 0x11, 0xCE, 0x04, 0xEE, 0x20, 0xC5, 100);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Communication.TaskStatus -- PKEY_Communication_TaskStatus</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
		///   <item><term><b>Format ID:</b></term><description>BE1A72C6-9A1D-46B7-AFE7-AFAF8CEF4999, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TaskStatus => new(0xBE1A72C6, 0x9A1D, 0x46B7, 0xAF, 0xE7, 0xAF, 0xAF, 0x8C, 0xEF, 0x49, 0x99, 100);

		/// <summary>Possible discrete values for PKEY_Communication_TaskStatus.</summary>
		public enum TaskStatusValues : short
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
		///   <item><term><b>Name:     </b></term><description>System.Communication.TaskStatusText -- PKEY_Communication_TaskStatusText</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>A6744477-C237-475B-A075-54F34498292A, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TaskStatusText => new(0xA6744477, 0xC237, 0x475B, 0xA0, 0x75, 0x54, 0xF3, 0x44, 0x98, 0x29, 0x2A, 100);
	}
}
