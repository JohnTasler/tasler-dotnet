using System;

namespace Tasler.Interop.Shell
{
	public static partial class PropertyKeys
	{
		public static class Calendar
		{
			/// <summary>
			/// The duration as specified in a string.</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.Duration -- PKEY_Duration</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>293CA35A-09AA-4DD2-B180-1FE245728A52, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Duration { get { return new PropertyKey(0x293CA35A, 0x09AA, 0x4DD2, 0xB1, 0x80, 0x1F, 0xE2, 0x45, 0x72, 0x8A, 0x52, 100); } }

			/// <summary>
			/// Identifies if the event is an online event.</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.IsOnline -- PKEY_IsOnline</description></item>
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>BFEE9149-E3E2-49A7-A862-C05988145CEC, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsOnline { get { return new PropertyKey(0xBFEE9149, 0xE3E2, 0x49A7, 0xA8, 0x62, 0xC0, 0x59, 0x88, 0x14, 0x5C, 0xEC, 100); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.IsRecurring -- PKEY_IsRecurring</description></item>
			///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
			///   <item><term><b>Format ID:</b></term><description>315B9C8D-80A9-4EF9-AE16-8E746DA51D70, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey IsRecurring { get { return new PropertyKey(0x315B9C8D, 0x80A9, 0x4EF9, 0xAE, 0x16, 0x8E, 0x74, 0x6D, 0xA5, 0x1D, 0x70, 100); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.Location -- PKEY_Location</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>F6272D18-CECC-40B1-B26A-3911717AA7BD, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Location { get { return new PropertyKey(0xF6272D18, 0xCECC, 0x40B1, 0xB2, 0x6A, 0x39, 0x11, 0x71, 0x7A, 0xA7, 0xBD, 100); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.OptionalAttendeeAddresses -- PKEY_OptionalAttendeeAddresses</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>D55BAE5A-3892-417A-A649-C6AC5AAAEAB3, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey OptionalAttendeeAddresses { get { return new PropertyKey(0xD55BAE5A, 0x3892, 0x417A, 0xA6, 0x49, 0xC6, 0xAC, 0x5A, 0xAA, 0xEA, 0xB3, 100); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.OptionalAttendeeNames -- PKEY_OptionalAttendeeNames</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>09429607-582D-437F-84C3-DE93A2B24C3C, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey OptionalAttendeeNames { get { return new PropertyKey(0x09429607, 0x582D, 0x437F, 0x84, 0xC3, 0xDE, 0x93, 0xA2, 0xB2, 0x4C, 0x3C, 100); } }

			/// <summary>
			/// Address of the organizer organizing the event.</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.OrganizerAddress -- PKEY_OrganizerAddress</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>744C8242-4DF5-456C-AB9E-014EFB9021E3, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey OrganizerAddress { get { return new PropertyKey(0x744C8242, 0x4DF5, 0x456C, 0xAB, 0x9E, 0x01, 0x4E, 0xFB, 0x90, 0x21, 0xE3, 100); } }

			/// <summary>
			/// Name of the organizer organizing the event.</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.OrganizerName -- PKEY_OrganizerName</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>AAA660F9-9865-458E-B484-01BC7FE3973E, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey OrganizerName { get { return new PropertyKey(0xAAA660F9, 0x9865, 0x458E, 0xB4, 0x84, 0x01, 0xBC, 0x7F, 0xE3, 0x97, 0x3E, 100); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.ReminderTime -- PKEY_ReminderTime</description></item>
			///   <item><term><b>Type:     </b></term><description>DateTime -- VT_FILETIME  (For variants: VT_DATE)</description></item>
			///   <item><term><b>Format ID:</b></term><description>72FC5BA4-24F9-4011-9F3F-ADD27AFAD818, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ReminderTime { get { return new PropertyKey(0x72FC5BA4, 0x24F9, 0x4011, 0x9F, 0x3F, 0xAD, 0xD2, 0x7A, 0xFA, 0xD8, 0x18, 100); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.RequiredAttendeeAddresses -- PKEY_RequiredAttendeeAddresses</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>0BA7D6C3-568D-4159-AB91-781A91FB71E5, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey RequiredAttendeeAddresses { get { return new PropertyKey(0x0BA7D6C3, 0x568D, 0x4159, 0xAB, 0x91, 0x78, 0x1A, 0x91, 0xFB, 0x71, 0xE5, 100); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.RequiredAttendeeNames -- PKEY_RequiredAttendeeNames</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>B33AF30B-F552-4584-936C-CB93E5CDA29F, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey RequiredAttendeeNames { get { return new PropertyKey(0xB33AF30B, 0xF552, 0x4584, 0x93, 0x6C, 0xCB, 0x93, 0xE5, 0xCD, 0xA2, 0x9F, 100); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.Resources -- PKEY_Resources</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>00F58A38-C54B-4C40-8696-97235980EAE1, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Resources { get { return new PropertyKey(0x00F58A38, 0xC54B, 0x4C40, 0x86, 0x96, 0x97, 0x23, 0x59, 0x80, 0xEA, 0xE1, 100); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.ShowTimeAs -- PKEY_ShowTimeAs</description></item>
			///   <item><term><b>Type:     </b></term><description>UInt16 -- VT_UI2</description></item>
			///   <item><term><b>Format ID:</b></term><description>5BF396D4-5EB2-466F-BDE9-2FB3F2361D6E, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ShowTimeAs { get { return new PropertyKey(0x5BF396D4, 0x5EB2, 0x466F, 0xBD, 0xE9, 0x2F, 0xB3, 0xF2, 0x36, 0x1D, 0x6E, 100); } }

			/// <summary>Possible discrete values for PKEY_ShowTimeAs.</summary>
			public enum ShowTimeAsValues : ushort
			{
				Free = 0,
				Tentative = 1,
				Busy = 2,
				Oof = 3,
			}

			/// <summary>
			/// This is the user-friendly form of System.Calendar.ShowTimeAs.  Not intended to be parsed
			/// programmatically.</summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Calendar.ShowTimeAsText -- PKEY_ShowTimeAsText</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>53DA57CF-62C0-45C4-81DE-7610BCEFD7F5, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ShowTimeAsText { get { return new PropertyKey(0x53DA57CF, 0x62C0, 0x45C4, 0x81, 0xDE, 0x76, 0x10, 0xBC, 0xEF, 0xD7, 0xF5, 100); } }
		}
	}
}