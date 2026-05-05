
namespace Tasler.Interop.Shell;

public static partial class PropertyKeys
{
	public static class Music
	{
		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.AlbumArtist -- PKEY_Music_AlbumArtist</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 13 (PIDSI_MUSIC_ALBUM_ARTIST)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AlbumArtist => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 13);

		/// <summary>
		/// This optional string value allows for overriding the standard sort order of System.Music.AlbumArtist.
		/// This is very important for proper sorting of music files in Japanese which cannot be correctly sorted
		/// phonetically (the user-expected ordering) without this field. It can also be used for customizing
		/// sorting in non-East Asian scenarios, such as allowing the user to remove articles for sorting purposes.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.AlbumArtistSortOverride -- PKEY_Music_AlbumArtistSortOverride</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{F1FDB4AF-F78C-466C-BB05-56E92DB0B8EC}, 103 (PIDSI_MUSIC_ALBUM_ARTIST_SORT_OVERRIDE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AlbumArtistSortOverride => new(0xF1FDB4AF, 0xF78C, 0x466C, 0xBB, 0x05, 0x56, 0xE9, 0x2D, 0xB0, 0xB8, 0xEC, 103);

		/// <summary>Concatenation of System.Music.AlbumArtist and System.Music.AlbumTitle, suitable for indexing and display. Used to differentiate albums with the same title from different artists.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.AlbumID -- PKEY_Music_AlbumID</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) {56A3372E-CE9C-11D2-9F0E-006097C686F6}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AlbumID => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.AlbumTitle -- PKEY_Music_AlbumTitle</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 4 (PIDSI_MUSIC_ALBUM)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AlbumTitle => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 4);

		/// <summary>
		/// This optional string value allows for overriding the standard sort order of System.Music.Album.
		/// This is very important for proper sorting of music files in Japanese which cannot be correctly
		/// sorted phonetically (the user-expected ordering) without this field. It can also be used for
		/// customizing sorting in non-East Asian scenarios, such as allowing the user to remove articles
		/// for sorting purposes.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.AlbumTitleSortOverride -- PKEY_Music_AlbumTitleSortOverride</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{13EB7FFC-EC89-4346-B19D-CCC6F1784223}, 101 (PIDSI_MUSIC_ALBUM_TITLE_SORT_OVERRIDE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey AlbumTitleSortOverride => new(0x13EB7FFC, 0xEC89, 0x4346, 0xB1, 0x9D, 0xCC, 0xC6, 0xF1, 0x78, 0x42, 0x23, 101);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.Artist -- PKEY_Music_Artist</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 2 (PIDSI_MUSIC_ARTIST)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Artist => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 2);

		/// <summary>This optional string value allows for overriding the standard sort order of System.Music.Artist. This is very important for proper sorting of music files in Japanese which cannot be correctly sorted phonetically (the user-expected ordering) without this field. It can also be used for customizing sorting in non-East Asian scenarios, such as allowing the user to remove articles for sorting purposes.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.ArtistSortOverride -- PKEY_Music_ArtistSortOverride</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{DEEB2DB5-0696-4CE0-94FE-A01F77A45FB5}, 102 (PIDSI_MUSIC_ARTIST_SORT_OVERRIDE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ArtistSortOverride => new(0xDEEB2DB5, 0x0696, 0x4CE0, 0x94, 0xFE, 0xA0, 0x1F, 0x77, 0xA4, 0x5F, 0xB5, 102);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.BeatsPerMinute -- PKEY_Music_BeatsPerMinute</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 35 (PIDSI_MUSIC_BEATS_PER_MINUTE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey BeatsPerMinute => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 35);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.Composer -- PKEY_Music_Composer</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSGUID_MEDIAFILESUMMARYINFORMATION) 64440492-4C8B-11D1-8B70-080036B11A03, 19 (PIDMSI_COMPOSER)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Composer => new(0x64440492, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 19);

		/// <summary>
		/// This optional string value allows for overriding the standard sort order of System.Music.Composer.
		/// This is very important for proper sorting of music files in Japanese which cannot be correctly sorted
		/// phonetically (the user-expected ordering) without this field. It can also be used for customizing
		/// sorting in non-East Asian scenarios, such as allowing the user to remove articles for sorting purposes.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.ComposerSortOverride -- PKEY_Music_ComposerSortOverride</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{00BC20A3-BD48-4085-872C-A88D77F5097E}, 105 (PIDSI_COMPOSER_SORT_OVERRIDE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ComposerSortOverride => new(0x00BC20A3, 0xBD48, 0x4085, 0x87, 0x2C, 0xA8, 0x8D, 0x77, 0xF5, 0x09, 0x7E, 105);


		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.Conductor -- PKEY_Music_Conductor</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 36 (PIDSI_MUSIC_CONDUCTOR)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Conductor => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 36);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.ContentGroupDescription -- PKEY_Music_ContentGroupDescription</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 33 (PIDSI_MUSIC_CONTENT_GROUP_DESCRIPTION)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey ContentGroupDescription => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 33);

//  Name:      System.Music.DiscNumber -- PKEY_Music_DiscNumber
//  Type:      UInt32 -- VT_UI4
//  Format ID: {6AFE7437-9BCD-49C7-80FE-4A5C65FA5874}, 104
		public static PropertyKey DiscNumber => new(0x6AFE7437, 0x9BCD, 0x49C7, 0x80, 0xFE, 0x4A, 0x5C, 0x65, 0xFA, 0x58, 0x74, 104);

		/// <summary>
		/// This property returns the best representation of Album Artist for a given music file based
		/// upon AlbumArtist, ContributingArtist and compilation info.
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.DisplayArtist -- PKEY_Music_DisplayArtist</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>{FD122953-FA93-4EF7-92C3-04C946B2F7C8}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey DisplayArtist => new(0xFD122953, 0xFA93, 0x4EF7, 0x92, 0xC3, 0x04, 0xC9, 0x46, 0xB2, 0xF7, 0xC8, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.Genre -- PKEY_Music_Genre</description></item>
		///   <item><term><b>Type:     </b></term><description>Multivalue String -- VT_VECTOR | VT_LPWSTR  (For variants: VT_ARRAY | VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 11 (PIDSI_MUSIC_GENRE)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Genre => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 11);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.InitialKey -- PKEY_Music_InitialKey</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 34 (PIDSI_MUSIC_INITIAL_KEY)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey InitialKey => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 34);

		/// <summary>Indicates whether the file is part of a compilation.</summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.IsCompilation -- PKEY_Music_IsCompilation</description></item>
		///   <item><term><b>Type:     </b></term><description>Boolean -- VT_BOOL</description></item>
		///   <item><term><b>Format ID:</b></term><description>{C449D5CB-9EA4-4809-82E8-AF9D59DED6D1}, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey IsCompilation => new(0xC449D5CB, 0x9EA4, 0x4809, 0x82, 0xE8, 0xAF, 0x9D, 0x59, 0xDE, 0xD6, 0xD1, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.Lyrics -- PKEY_Music_Lyrics</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 12 (PIDSI_MUSIC_LYRICS)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Lyrics => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 12);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.Mood -- PKEY_Mood</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 39 (PIDSI_MUSIC_MOOD)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Mood => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 39);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.PartOfSet -- PKEY_Music_PartOfSet</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 37 (PIDSI_MUSIC_PART_OF_SET)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey PartOfSet => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 37);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.Period -- PKEY_Music_Period</description></item>
		///   <item><term><b>Type:     </b></term><description>String -- VT_LPWSTR  (For variants: VT_BSTR)</description></item>
		///   <item><term><b>Format ID:</b></term><description>(PSGUID_MEDIAFILESUMMARYINFORMATION) 64440492-4C8B-11D1-8B70-080036B11A03, 31 (PIDMSI_PERIOD)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey Period => new(0x64440492, 0x4C8B, 0x11D1, 0x8B, 0x70, 0x08, 0x00, 0x36, 0xB1, 0x1A, 0x03, 31);

		/// <summary></summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.SynchronizedLyrics -- PKEY_Music_SynchronizedLyrics</description></item>
		///   <item><term><b>Type:     </b></term><description>Blob -- VT_BLOB</description></item>
		///   <item><term><b>Format ID:</b></term><description>6B223B6A-162E-4AA9-B39F-05D678FC6D77, 100</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey SynchronizedLyrics => new(0x6B223B6A, 0x162E, 0x4AA9, 0xB3, 0x9F, 0x05, 0xD6, 0x78, 0xFC, 0x6D, 0x77, 100);

		/// <summary>
		/// </summary>
		/// <remarks>
		/// <list type="table">
		///   <item><term><b>Name:     </b></term><description>System.Music.TrackNumber -- PKEY_Music_TrackNumber</description></item>
		///   <item><term><b>Type:     </b></term><description>UInt32 -- VT_UI4</description></item>
		///   <item><term><b>Format ID:</b></term><description>(FMTID_MUSIC) 56A3372E-CE9C-11D2-9F0E-006097C686F6, 7 (PIDSI_MUSIC_TRACK)</description></item>
		/// </list>
		/// </remarks>
		public static PropertyKey TrackNumber => new(0x56A3372E, 0xCE9C, 0x11D2, 0x9F, 0x0E, 0x00, 0x60, 0x97, 0xC6, 0x86, 0xF6, 7);
	}
}
