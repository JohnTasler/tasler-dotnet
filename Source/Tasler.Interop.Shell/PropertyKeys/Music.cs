using System;

namespace Tasler.Interop.Shell
{
	public static partial class PropertyKeys
	{
		public static class Music
		{
			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.AlbumArtist -- PKEY_AlbumArtist</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 13 (PIDSI_MUSIC_ALBUM_ARTIST)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey AlbumArtist { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 13); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.AlbumTitle -- PKEY_AlbumTitle</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 4 (PIDSI_MUSIC_ALBUM)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey AlbumTitle { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 4); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.Artist -- PKEY_Artist</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 2 (PIDSI_MUSIC_ARTIST)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Artist { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 2); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.BeatsPerMinute -- PKEY_BeatsPerMinute</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 35 (PIDSI_MUSIC_BEATS_PER_MINUTE)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey BeatsPerMinute { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 35); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.Composer -- PKEY_Composer</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(PSGUID_MEDIAFILESUMMARYINFORMATION) 64440492-4C8B-11D1-8B70-080036B11A03, 19 (PIDMSI_COMPOSER)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Composer { get { return new PropertyKey(0x64440492, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 19); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.Conductor -- PKEY_Conductor</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 36 (PIDSI_MUSIC_CONDUCTOR)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Conductor { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 36); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.ContentGroupDescription -- PKEY_ContentGroupDescription</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 33 (PIDSI_MUSIC_CONTENT_GROUP_DESCRIPTION)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey ContentGroupDescription { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 33); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.Genre -- PKEY_Genre</description></item>
			///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 11 (PIDSI_MUSIC_GENRE)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Genre { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 11); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.InitialKey -- PKEY_InitialKey</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 34 (PIDSI_MUSIC_INITIAL_KEY)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey InitialKey { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 34); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.Lyrics -- PKEY_Lyrics</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 12 (PIDSI_MUSIC_LYRICS)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Lyrics { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 12); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.Mood -- PKEY_Mood</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 39 (PIDSI_MUSIC_MOOD)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Mood { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 39); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.PartOfSet -- PKEY_PartOfSet</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 37 (PIDSI_MUSIC_PART_OF_SET)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey PartOfSet { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 37); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.Period -- PKEY_Period</description></item>
			///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
			///   <item><term><b>Format ID:</b></term><description>(PSGUID_MEDIAFILESUMMARYINFORMATION) 64440492-4C8B-11D1-8B70-080036B11A03, 31 (PIDMSI_PERIOD)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey Period { get { return new PropertyKey(0x64440492, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 31); } }

			/// <summary></summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.SynchronizedLyrics -- PKEY_SynchronizedLyrics</description></item>
			///   <item><term><b>Type:     </b></term><description>Blob -- VT_BLOB</description></item>
			///   <item><term><b>Format ID:</b></term><description>6B223B6A-162E-4AA9-B39F-05D678FC6D77, 100</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey SynchronizedLyrics { get { return new PropertyKey(0x6B223B6A, 0x162E, 0x4AA9, 0xB3, 0x9F, 0x05, 0xD6, 0x78, 0xFC, 0x6D, 0x77, 100); } }

			/// <summary>
			/// </summary>
			/// <remarks>
			/// <list type="table">
			///   <item><term><b>Name:     </b></term><description>System.Music.TrackNumber -- PKEY_TrackNumber</description></item>
			///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
			///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 7 (PIDSI_MUSIC_TRACK)</description></item>
			/// </list>
			/// </remarks>
			public static PropertyKey TrackNumber { get { return new PropertyKey(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 7); } }
		}
	}
}