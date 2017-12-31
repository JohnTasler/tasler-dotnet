using System;

namespace Tasler.Interop.Shell
{
	public static partial class PropertyKeys
	{
		public static class Message
		{
			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.AttachmentContents -- PKEY_AttachmentContents</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>3143BF7C-80A8-4854-8880-E2E40189BDD0, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey AttachmentContents { get { return new PropertyKey(0x3143BF7C, 0x80A8, 0x4854, 0x88, 0x80, 0xE2, 0xE4, 0x01, 0x89, 0xBD, 0xD0, 100); } }

			/// <summary>
			/// The names of the attachments in a message</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.AttachmentNames -- PKEY_AttachmentNames</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 21</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey AttachmentNames { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 21); } }

			/// <summary>
			/// Addresses in Bcc: field</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.BccAddress -- PKEY_BccAddress</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 2</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey BccAddress { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 2); } }

			/// <summary>
			/// person names in Bcc: field</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.BccName -- PKEY_BccName</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 3</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey BccName { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 3); } }

			/// <summary>
			/// Addresses in Cc: field</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.CcAddress -- PKEY_CcAddress</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 4</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey CcAddress { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 4); } }

			/// <summary>
			/// person names in Cc: field</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.CcName -- PKEY_CcName</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 5</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey CcName { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 5); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.ConversationID -- PKEY_ConversationID</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>DC8F80BD-AF1E-4289-85B6-3DFC1B493992, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ConversationID { get { return new PropertyKey(0xDC8F80BD, 0xAF1E, 0x4289, 0x85, 0xB6, 0x3D, 0xFC, 0x1B, 0x49, 0x39, 0x92, 100); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.ConversationIndex -- PKEY_ConversationIndex</description></item>
			///   <item><term><b>Type:     </b></term><description>Buffer -- VT_VECTOR | VT_UI1  (For variants: VT_ARRAY | VT_UI1)</description></item>
			///   <item><term><b>Format ID:</b></term><description>DC8F80BD-AF1E-4289-85B6-3DFC1B493992, 101</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ConversationIndex { get { return new PropertyKey(0xDC8F80BD, 0xAF1E, 0x4289, 0x85, 0xB6, 0x3D, 0xFC, 0x1B, 0x49, 0x39, 0x92, 101); } }

			/// <summary>
			/// Date and Time communication was received</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.DateReceived -- PKEY_DateReceived</description></item>
			///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 20</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey DateReceived { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 20); } }

			/// <summary>
			/// Date and Time communication was sent</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.DateSent -- PKEY_DateSent</description></item>
			///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 19</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey DateSent { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 19); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.FromAddress -- PKEY_FromAddress</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 13</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey FromAddress { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 13); } }

			/// <summary>
			/// Address in from field as person name</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.FromName -- PKEY_FromName</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 14</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey FromName { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 14); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.HasAttachments -- PKEY_HasAttachments</description></item>
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>9C1FCF74-2D97-41BA-B4AE-CB2E3661A6E4, 8</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey HasAttachments { get { return new PropertyKey(0x9C1FCF74, 0x2D97, 0x41BA, 0xB4, 0xAE, 0xCB, 0x2E, 0x36, 0x61, 0xA6, 0xE4, 8); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.IsFwdOrReply -- PKEY_IsFwdOrReply</description></item>
			///   <item><term><b>Type:     </b></term><description>Int32 -- VT_I4</description></item>
			///   <item><term><b>Format ID:</b></term><description>9A9BC088-4F6D-469E-9919-E705412040F9, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsFwdOrReply { get { return new PropertyKey(0x9A9BC088, 0x4F6D, 0x469E, 0x99, 0x19, 0xE7, 0x05, 0x41, 0x20, 0x40, 0xF9, 100); } }

			/// <summary>
			/// What type of outlook msg this is (meeting, task, mail, etc.)</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.MessageClass -- PKEY_MessageClass</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>CD9ED458-08CE-418F-A70E-F912C7BB9C5C, 103</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey MessageClass { get { return new PropertyKey(0xCD9ED458, 0x08CE, 0x418F, 0xA7, 0x0E, 0xF9, 0x12, 0xC7, 0xBB, 0x9C, 0x5C, 103); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.SenderAddress -- PKEY_SenderAddress</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>0BE1C8E7-1981-4676-AE14-FDD78F05A6E7, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SenderAddress { get { return new PropertyKey(0x0BE1C8E7, 0x1981, 0x4676, 0xAE, 0x14, 0xFD, 0xD7, 0x8F, 0x05, 0xA6, 0xE7, 100); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.SenderName -- PKEY_SenderName</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>0DA41CFA-D224-4A18-AE2F-596158DB4B3A, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SenderName { get { return new PropertyKey(0x0DA41CFA, 0xD224, 0x4A18, 0xAE, 0x2F, 0x59, 0x61, 0x58, 0xDB, 0x4B, 0x3A, 100); } }

			/// <summary>
			/// The store (aka protocol handler) FILE, MAIL, OUTLOOKEXPRESS</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.Store -- PKEY_Store</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 15</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Store { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 15); } }

			/// <summary>
			/// Addresses in To: field</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.ToAddress -- PKEY_ToAddress</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 16</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ToAddress { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 16); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.ToDoTitle -- PKEY_ToDoTitle</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>BCCC8A3C-8CEF-42E5-9B1C-C69079398BC7, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ToDoTitle { get { return new PropertyKey(0xBCCC8A3C, 0x8CEF, 0x42E5, 0x9B, 0x1C, 0xC6, 0x90, 0x79, 0x39, 0x8B, 0xC7, 100); } }

			/// <summary>
			/// Person names in To: field</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Message.ToName -- PKEY_ToName</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>E3E0584C-B788-4A5A-BB20-7F5A44C9ACDD, 17</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ToName { get { return new PropertyKey(0xE3E0584C, 0xB788, 0x4A5A, 0xBB, 0x20, 0x7F, 0x5A, 0x44, 0xC9, 0xAC, 0xDD, 17); } }
		}
	}
}