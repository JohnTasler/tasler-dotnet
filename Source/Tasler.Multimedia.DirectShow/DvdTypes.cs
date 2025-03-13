using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Tasler.Multimedia.DirectShow.DvdTypes
{
	#region Classes
	public class DvdGraphBuilder : DvdGraphBuilderBase
	{
		#region Helper Methods

		public ITF GetDvdInterface<ITF>(out int hr)
			where ITF : class
		{
			object theObject;
			hr = this.GetDvdInterface(typeof(ITF).GUID, out theObject);
			return (hr == 0) ? theObject as ITF : null;
		}

		public ITF GetDvdInterface<ITF>()
			where ITF : class
		{
			int hr;
			return this.GetDvdInterface<ITF>(out hr);
		}

		public ITF GetFiltergraphInterface<ITF>(out int hr)
			where ITF : class
		{
			IGraphBuilder graphBuilder;
			hr = this.GetFiltergraph(out graphBuilder);
			return (hr == 0) ? graphBuilder as ITF : null;
		}

		public ITF GetFiltergraphInterface<ITF>()
			where ITF : class
		{
			int hr;
			return this.GetFiltergraphInterface<ITF>(out hr);
		}

		#endregion Helper Methods

		#region IDvdGraphBuilder Wrappers
		public int GetFiltergraph(out IGraphBuilder graphBuilder)
		{
			return ((IDvdGraphBuilder)this).GetFiltergraph(out graphBuilder);
		}

		public int GetDvdInterface(Guid riid, out object itf)
		{
			return ((IDvdGraphBuilder)this).GetDvdInterface(ref riid, out itf);
		}

		public int RenderDvdVideoVolume(string pathName, DVD_GRAPH_FLAGS flags, out DVD_RENDERSTATUS status)
		{
			return ((IDvdGraphBuilder)this).RenderDvdVideoVolume(pathName, flags, out status);
		}
		#endregion IDvdGraphBuilder Wrappers
	}

	[ComImport]
	[Guid("FCC152B7-F372-11d0-8E00-00C04FD7C08B")]
	public class DvdGraphBuilderBase
	{
	}

	#endregion

	#region Interfaces
	[ComImport]
	[Guid("FCC152B6-F372-11d0-8E00-00C04FD7C08B")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CoClass(typeof(DvdGraphBuilderBase))]
	public interface IDvdGraphBuilder
	{
		[PreserveSig]
		int GetFiltergraph(
			[Out] out IGraphBuilder ppGB);

		/// <summary>
		/// Gets specific interface pointers in the DVD-Video playback graph to 
		/// make DVD-Video playback development easier.
		/// </summary>
		/// <remarks>
		/// It helps get the following interfaces to control playback/show CC/
		/// position window/control volume etc:
		/// <list type="">
		///		<item><term><see cref="IDvdControl2"/>, <see cref="IDvdInfo2"/></term></item>
		///		<item><term><see cref="ILine21Decoder"/></term></item>
		///		<item><term><see cref="IVideoWindow"/>, IBasicVideo</term></item>
		///		<item><term>IBasicAudio</term></item>
		/// </list>
		/// </remarks>
		/// <param name="riid">IID of the interface required.</param>
		/// <param name="ppvIF">Returns pointer to the required interface.</param>
		/// <returns>
		/// One of the following values:
		/// <list type="table">
		///   <item><term>E_INVALIDARG</term>
		///         <description>If ppvIF is invalid.</description></item>
		///   <item><term>E_NOINTERFACE</term>
		///         <description>If riid is an IID we don't know about.</description></item>
		///   <item><term>VFW_E_DVD_GRAPHNOTREADY</term>
		///         <description>If the graph has not been built through RenderDvdVideoVolume() yet.</description></item>
		/// </list>
		/// </returns>
		[PreserveSig]
		int GetDvdInterface(
			[In] ref Guid riid,
			[Out][MarshalAs(UnmanagedType.Interface)] out object ppvIF);

		/// <summary>
		/// Builds a filter graph according to user specs for playing back a DVD-Video volume.
		/// </summary>
		/// <param name="lpcwszPathName">Can be <b>null</b> too.</param>
		/// <param name="dwFlags">0 is the default (use max HW).</param>
		/// <param name="pStatus">Returns indications of ANY failure.</param>
		/// <remarks>
		/// This method returns S_FALSE if
		/// 1.  the graph has been either built, but either
		///     a) VPE mixing doesn't work (app didn't use AM_DVD_NOVPE flag)
		///     b) video decoder doesn't produce line21 data
		///     c) line21 data couldn't be rendered (decoding/mixing problem)
		///     d) the call specified an invalid volume path or DVD Nav couldn't
		///        locate any DVD-Video volume to be played.
		/// 2.  some streams didn't render (completely), but the others have
		///     been rendered so that the volume can be partially played back.
		/// The status is indicated through the fields of the pStatus (out)
		/// parameter.
		/// About 1(a), the app will have enough info to tell the user that the
		/// video won't be visible unless a TV is connected to the NTSC out 
		/// port of the DVD decoder (presumably HW in this case).
		/// For case 1(b) & (c), the app "can" put up a warning/informative message
		/// that closed captioning is not available because of the decoder.
		/// 1(d) helps an app to ask the user to insert a DVD-Video disc if none 
		/// is specified/available in the drive when playback is started.
		/// This method builds the graph even if 
		/// - an invalid DVD-Video volume is specified
		/// - the caller uses lpwszPathName = NULL to make the DVD Nav to locate
		///   the default volume to be played back, but DVD Nav doesn't find a 
		///   default DVD-Video volume to be played back.
		/// An app can later specify the volume using IDvdControl::SetRoot() 
		/// method.
		/// #2 will help the app indicate to the user that some of the streams
		/// can't be played.
		/// 
		/// The graph is built using filters based on the dwFlags value (to use 
		/// HW decoders or SW decoders or a mix of them).
		/// The dwFlags value is one of the values in AM_DVD_GRAPH_FLAGS enum
		/// type.  The default value is AM_DVD_HWDEC_PREFER. None of the 
		/// AM_DVD_HWDEC_xxx or AM_DVD_SWDEC_xxx flags can be mixed. However
		/// AM_DVD_NOVPE can be OR-ed with any of the AM_DVD_HWDEC_xxx flags.
		/// 
		/// The method returns S_OK if the playback graph is built successfully
		/// with all the streams completely rendered and a valid DVD-Video volume 
		/// is specified or a default one has been located.
		/// 
		/// If the dwFlags specify conflicting options, E_INVALIDARG is returned.
		/// If the graph building fails, the method returns one of the following 
		/// error codes:
		///    VFW_E_DVD_RENDERFAIL, VFW_E_DVD_DECNOTENOUGH
		/// </remarks>
		/// <returns>See remarks.</returns>
		[PreserveSig]
		int RenderDvdVideoVolume(
			[In][MarshalAs(UnmanagedType.LPWStr)] string lpcwszPathName,
			[In][MarshalAs(UnmanagedType.U4)] DVD_GRAPH_FLAGS dwFlags,
			[Out] out DVD_RENDERSTATUS pStatus);
	}

	[ComImport]
	[Guid("56A8689F-0AD4-11CE-B03A-0020AF0BA770")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFilterGraph
	{
		[PreserveSig]
		int AddFilter( 
			[In][MarshalAs(UnmanagedType.Interface)] object pFilter,
			[In][MarshalAs(UnmanagedType.LPWStr)] string pName);

		[PreserveSig]
		int RemoveFilter( 
			[In][MarshalAs(UnmanagedType.Interface)] object pFilter);

		[PreserveSig]
		int EnumFilters( 
			[MarshalAs(UnmanagedType.Interface)] out object ppEnum);

		[PreserveSig]
		int FindFilterByName( 
			[In][MarshalAs(UnmanagedType.LPWStr)] string pName,
			[MarshalAs(UnmanagedType.Interface)] out object ppFilter);

		[PreserveSig]
		int ConnectDirect( 
			[In][MarshalAs(UnmanagedType.Interface)] object ppinOut,
			[In][MarshalAs(UnmanagedType.Interface)] object ppinIn,
			[In] ref AM_MEDIA_TYPE pmt);

		[PreserveSig]
		int Reconnect( 
			[In][MarshalAs(UnmanagedType.Interface)] object ppin);

		[PreserveSig]
		int Disconnect( 
			[In][MarshalAs(UnmanagedType.Interface)] object ppin);

		[PreserveSig]
		int SetDefaultSyncSource();
	}

	[ComImport]
	[Guid("56A868A9-0AD4-11CE-B03A-0020AF0BA770")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IGraphBuilder
	{
		#region IFilterGraph Methods

		[PreserveSig]
		int AddFilter( 
			[In][MarshalAs(UnmanagedType.Interface)] object pFilter,
			[In][MarshalAs(UnmanagedType.LPWStr)] string pName);

		[PreserveSig]
		int RemoveFilter( 
			[In][MarshalAs(UnmanagedType.Interface)] object pFilter);

		[PreserveSig]
		int EnumFilters( 
			[MarshalAs(UnmanagedType.Interface)] out object ppEnum);

		[PreserveSig]
		int FindFilterByName( 
			[In][MarshalAs(UnmanagedType.LPWStr)] string pName,
			[MarshalAs(UnmanagedType.Interface)] out object ppFilter);

		[PreserveSig]
		int ConnectDirect( 
			[In][MarshalAs(UnmanagedType.Interface)] object ppinOut,
			[In][MarshalAs(UnmanagedType.Interface)] object ppinIn,
			[In] ref AM_MEDIA_TYPE pmt);

		[PreserveSig]
		int Reconnect( 
			[In][MarshalAs(UnmanagedType.Interface)] object ppin);

		[PreserveSig]
		int Disconnect( 
			[In][MarshalAs(UnmanagedType.Interface)] object ppin);

		[PreserveSig]
		int SetDefaultSyncSource();

		#endregion IFilterGraph Methods

		[PreserveSig]
		int Connect( 
			[In][MarshalAs(UnmanagedType.Interface)] object ppinOut,
			[In][MarshalAs(UnmanagedType.Interface)] object ppinIn);

		[PreserveSig]
		int Render( 
			[In][MarshalAs(UnmanagedType.Interface)] object ppinOut);

		[PreserveSig]
		int RenderFile( 
			[In][MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFile,
			[In][MarshalAs(UnmanagedType.LPWStr)] string lpcwstrPlayList);

		[PreserveSig]
		int AddSourceFilter( 
			[In][MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFileName,
			[In][MarshalAs(UnmanagedType.LPWStr)] string lpcwstrFilterName,
			[Out][MarshalAs(UnmanagedType.Interface)] out object ppFilter);

		[PreserveSig]
		int SetLogFile( 
			[In] IntPtr hFile);

		[PreserveSig]
		int Abort();

		[PreserveSig]
		int ShouldOperationContinue();
	}

	[ComImport]
	[Guid("56A868B1-0AD4-11CE-B03A-0020AF0BA770")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IMediaControl
	{
		[DispId(0x60020000)]
		void Run();

		[DispId(0x60020001)]
		void Pause();

		[DispId(0x60020002)]
		void Stop();
		
		[DispId(0x60020003)]
		void GetState(
			[In] int msTimeout,
			out int pfs);
		
		[DispId(0x60020004)]
		void RenderFile(
			[In][MarshalAs(UnmanagedType.BStr)] string strFilename);
		
		[DispId(0x60020005)]
		void AddSourceFilter(
			[In][MarshalAs(UnmanagedType.BStr)] string strFilename,
			[MarshalAs(UnmanagedType.IDispatch)] out object ppUnk);
		
		[DispId(0x60020006)]
		object FilterCollection
		{
			[return: MarshalAs(UnmanagedType.IDispatch)]
			[DispId(0x60020006)]
			get;
		}

		[DispId(0x60020007)]
		object RegFilterCollection
		{
			[return: MarshalAs(UnmanagedType.IDispatch)]
			[DispId(0x60020007)]
			get;
		}

		[DispId(0x60020008)]
		void StopWhenReady();
	}

	[ComImport]
	[Guid("33BC7430-EEC0-11D2-8201-00A0C9D74842")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDvdInfo2
	{
		// Returns the current DVD Domain of the DVD player.
		[PreserveSig]
		int GetCurrentDomain(
			out DVD_DOMAIN pDomain);

		// Returns information sufficient to restart playback of a video
		// from the current playback location in titles that don't explicitly
		// disable seeking to the current location.
		[PreserveSig]
		int GetCurrentLocation(
			out DVD_PLAYBACK_LOCATION2 pLocation);

		// Returns the total playback time for the current title.  Only works
		// for One_Sequential_PGC_Titles.
		// THIS SHOULD CHANGE, RIGHT?
		[PreserveSig]
		int GetTotalTitleTime(
			out DVD_HMSF_TIMECODE pTotalTime,
			[MarshalAs(UnmanagedType.U4)] out int ulTimeCodeFlags  // union of DVD_TIMECODE_FLAGS
		);

		// Indicates the number of currently available buttons and the current
		// selected button number. If buttons are not present it returns 0 for
		// both pulButtonsAvailable and pulCurrentButton
		[PreserveSig]
		int GetCurrentButton(
			[MarshalAs(UnmanagedType.U4)] out int pulButtonsAvailable,
			[MarshalAs(UnmanagedType.U4)] out int pulCurrentButton);

		// Indicates the number of currently available angles and the current
		// selected angle number.  If *pulAnglesAvailable is returned as 1 then 
		// the current content is not multiangle.
		[PreserveSig]
		int GetCurrentAngle(
			[MarshalAs(UnmanagedType.U4)] out int pulAnglesAvailable,
			[MarshalAs(UnmanagedType.U4)] out int pulCurrentAngle);

		// Indicates the number of currently available audio streams and 
		// the currently selected audio stream number.
		// This only works inside the Title domain.
		[PreserveSig]
		int GetCurrentAudio(
			[MarshalAs(UnmanagedType.U4)] out int pulStreamsAvailable,
			[MarshalAs(UnmanagedType.U4)] out int pulCurrentStream
		);

		// Indicates the number of currently available subpicture streams,
		// the currently selected subpicture stream number, and if the 
		// subpicture display is currently disabled.  Subpicture streams 
		// authored as "Forcedly Activated" stream will be displayed even if
		// subpicture display has been disabled by the app with 
		// IDVDControl::SetSubpictureState.
		// This only works inside the Title domain.
		[PreserveSig]
		int GetCurrentSubpicture(
			[MarshalAs(UnmanagedType.U4)] out int pulStreamsAvailable,
			[MarshalAs(UnmanagedType.U4)] out int pulCurrentStream,
			[MarshalAs(UnmanagedType.Bool)] out bool pbIsDisabled);

		// Indicates which IDVDControl methods (Annex J user operations) are 
		// currently valid.  DVD titles can enable or disable individual user 
		// operations at almost any point during playback.
		[PreserveSig]
		int GetCurrentUOPS(
			[MarshalAs(UnmanagedType.U4)] out int pulUOPs);

		// Returns the current contents of all DVD System Parameter Registers.
		// See DVD-Video spec for use of individual registers.
		// WE SHOULD DOC THE SPRMs RATHER THAN ASKING TO REFER TO DVD SPEC.
		[PreserveSig]
		int GetAllSPRMs(
			out SystemParameterRegisters pRegisterArray);

		// Returns the current contents of all DVD General Parameter Registers.
		// Use of GPRMs is title specific.
		// WE SHOULD DOC THE GPRMs RATHER THAN ASKING TO REFER TO DVD SPEC.
		[PreserveSig]
		int GetAllGPRMs(
			out GeneralParameterRegisters pRegisterArray);

		// Returns the language of the specified stream within the current title.
		// Does not return languages for menus.  Returns *pLanguage as 0 if the
		// stream does not include language.
		// Use Win32 API GetLocaleInfo(*pLanguage, LOCALE_SENGLANGUAGE, pszString, cbSize)
		// to create a human readable string name from the returned LCID.
		[PreserveSig]
		int GetAudioLanguage(
			[In][MarshalAs(UnmanagedType.U4)] int ulStream, 
			[MarshalAs(UnmanagedType.U4)] out int pLanguage);

		// Returns the language of the specified stream within the current title.
		// Does not return languages for menus.  Returns *pLanguage=0 as 0 if the
		// stream does not include language.
		// Use Win32 API GetLocaleInfo(*pLanguage, LOCALE_SENGLANGUAGE, pszString, cbSize)
		// to create a human readable string name from the returned LCID.
		[PreserveSig]
		int GetSubpictureLanguage(
			[In][MarshalAs(UnmanagedType.U4)] int ulStream, 
			[MarshalAs(UnmanagedType.U4)] out int pLanguage);

		// Returns attributes of all video, audio, and subpicture streams for the 
		// specified title including menus.  
		// If 0xffffffff is specified as ulTitle, attributes for the current title 
		// are returned.
		[PreserveSig]
		int GetTitleAttributes(
			[In][MarshalAs(UnmanagedType.U4)] int ulTitle, // requested title number
			out DVD_MenuAttributes pMenu,
			out DVD_TitleAttributes pTitle);

		// Returns attributes of all video, audio, and subpicture 
		// streams for Video Manager Menus.  This method suppliments GetTitleAttributes()
		// for some menus, such as the Title menu, which are in a separate group of 
		// streams called the VMG (Video Manager) and are not associated with any 
		// particular title number.
		[PreserveSig]
		int GetVMGAttributes(
			out DVD_MenuAttributes pATR);

		// Returns the video attributes for the current title or menu.
		[PreserveSig]
		int GetCurrentVideoAttributes(
			out DVD_VideoAttributes pATR);

		// Returns the audio attributes for the specified stream in the current title 
		// or menu.
		[PreserveSig]
		int GetAudioAttributes(
			[In][MarshalAs(UnmanagedType.U4)] int ulStream,
			out DVD_AudioAttributes pATR);

		// Returns the karaoke contents of each channel of the specified stream in the current title 
		// or menu.
		[PreserveSig]
		int GetKaraokeAttributes(
			[In][MarshalAs(UnmanagedType.U4)] int ulStream,
			out DVD_KaraokeAttributes pAttributes);

		// Returns the subpicture attributes for the specified stream in the current
		// title or menu.
		[PreserveSig]
		int GetSubpictureAttributes(
			[In][MarshalAs(UnmanagedType.U4)] int ulStream,
			out DVD_SubpictureAttributes pATR);

		// Returns current DVD volume information.
		[PreserveSig]
		int GetDVDVolumeInfo(
			[MarshalAs(UnmanagedType.U4)] out int pulNumOfVolumes,  // number of volumes (disc sides?) in a volume set
			[MarshalAs(UnmanagedType.U4)] out int pulVolume,        // volume number for current DVD directory
			out DVD_DISC_SIDE pSide,    // current disc side
			[MarshalAs(UnmanagedType.U4)] out int pulNumOfTitles    // number of titles available in this volume
		);

		// Returns the number of text languages for the current DVD directory.
		// Should return some error code if no root directory is found.
		[PreserveSig]
		int GetDVDTextNumberOfLanguages(
			[MarshalAs(UnmanagedType.U4)] out int pulNumOfLangs);

		// Returns the text languages information (number of strings, language code, 
		// char set) for the specified language index.
		// Should return some error code if an invalid text index is specified.
		[PreserveSig]
		int GetDVDTextLanguageInfo(
			[In][MarshalAs(UnmanagedType.U4)] int ulLangIndex,
			[MarshalAs(UnmanagedType.U4)] out int pulNumOfStrings, 
			[MarshalAs(UnmanagedType.U4)] out int pLangCode, 
			out DVD_TextCharSet pbCharacterSet);

		// Returns the text string as an array of bytes for the specified language 
		// index.and string index.
		// Should return some error code if an invalid text or string index is specified.
		// It also just returns the length of the string if pchBuffer is specified as NULL.
		[PreserveSig]
		int GetDVDTextStringAsNative(
			[In][MarshalAs(UnmanagedType.U4)] int ulLangIndex, 
			[In][MarshalAs(UnmanagedType.U4)] int ulStringIndex, 
			[MarshalAs(UnmanagedType.LPArray, SizeParamIndex=4)] out byte[] pbBuffer, 
			[In][MarshalAs(UnmanagedType.U4)] int ulMaxBufferSize, 
			[MarshalAs(UnmanagedType.U4)] out int pulActualSize, 
			out DVD_TextStringType pType);

		// Returns the text string in Unicode for the specified language index.and string index.
		// Should return some error code if an invalid text or string index is specified.
		// It also just returns the length of the string if pchBuffer is specified as NULL.
		[PreserveSig]
		int GetDVDTextStringAsUnicode(
			[In][MarshalAs(UnmanagedType.U4)] int ulLangIndex, 
			[In][MarshalAs(UnmanagedType.U4)] int ulStringIndex,
			[In][Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pchwBuffer,
			[In][MarshalAs(UnmanagedType.U4)] int ulMaxBufferSize, 
			[MarshalAs(UnmanagedType.U4)] out int pulActualSize, 
			out DVD_TextStringType pType);

		// Returns the current parental level and the current country code that has 
		// been set in the system registers in player.
		// See Table 3.3.4-1 of the DVD-Video spec for the defined parental levels.
		// Valid Parental Levels range from 1 to 8 if parental management is enabled.
		// Returns 0xffffffff if parental management is disabled
		// See ISO3166 : Alpha-2 Code for the country codes.
		[PreserveSig]
		int GetPlayerParentalLevel(
			[MarshalAs(UnmanagedType.U4)] out int pulParentalLevel,    // current parental level
			[MarshalAs(UnmanagedType.U4)] out int pulCountryCode       // current country code
		);

		//  Returns the number of chapters that are defined for a
		//  given title.
		[PreserveSig]
		int GetNumberOfChapters(
			[In][MarshalAs(UnmanagedType.U4)] int ulTitle,           // Title for which number of chapters is requested
			[MarshalAs(UnmanagedType.U4)] out int pulNumOfChapters  // Number of chapters for the specified title
		);

		// Returns the parental levels that are defined for a particular title. 
		// pulParentalLevels will be combination of DVD_PARENTAL_LEVEL_8, 
		// DVD_PARENTAL_LEVEL_6, or DVD_PARENTAL_LEVEL_1 OR-ed together
		[PreserveSig]
		int GetTitleParentalLevels(
			[In][MarshalAs(UnmanagedType.U4)] int ulTitle,            // Title for which parental levels are requested
			[MarshalAs(UnmanagedType.U4)] out int pulParentalLevels  // Parental levels defined for the title "OR"ed together
		);

		// Returns the root directory that is set in the player. If a valid root
		// has been found, it returns the root string. Otherwise, it returns 0 for
		// pcbActualSize indicating that a valid root directory has not been found
		// or initialized.
		//
		// !!! used to return LPTSTR. interface was changed to return
		// LPSTR (ansi) for compatibility. COM APIs should pass with
		// UNICODE strings only.
		// 
		[PreserveSig]
		int GetDVDDirectory(
			[Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszwPath,   // pointer to buffer to get root string
			[In][MarshalAs(UnmanagedType.U4)] int ulMaxSize,                     // size of buffer in WCHARs passed in
			[MarshalAs(UnmanagedType.U4)] out int pulActualSize                  // size of actual data returned (in WCHARs)
		);


		// Determines if the specified audio stream is enabled/disabled in the current PGC.
		// ulStreamNum - audio stream number to test
		// pbEnabled   - where to place the result
		[PreserveSig]
		int IsAudioStreamEnabled(
			[In][MarshalAs(UnmanagedType.U4)] int ulStreamNum,   // stream number to test
			[MarshalAs(UnmanagedType.Bool)] out bool pbEnabled     // returned state
		);

		// Returns a 64-bit identification number for the specified DVD disc.
		// If pszwPath is specified as NULL, DVD Navigator will use the current path
		// that would be returned by GetDVDDirectory() at this point.
		[PreserveSig]
		int GetDiscID(
			[In][MarshalAs(UnmanagedType.LPWStr)] string pszwPath,  // root path (should we rather use const WCHAR*?)
			[MarshalAs(UnmanagedType.U8)] out long pullDiscID    // 64-bit unique id for the disc
		);

		// The navigator will create a new state object and save the current location into it.
		// The state object can be used to restore the navigator the saved location at a later time.
		// A new IDvdState object is created (with a single AddRef) and returned in *pStateData.
		// The object must be Released() when the application is finished with it.
		[PreserveSig]
		int GetState(
			out IDvdState pStateData // returned object
		);

		// Navigator gets all of the menu languages for the VMGM and VTSM domains.
		[PreserveSig]
		int GetMenuLanguages(
			[MarshalAs(UnmanagedType.U4)] out int pLanguages,                     // data buffer (NULL returns #languages) 
			[In][MarshalAs(UnmanagedType.U4)] int ulMaxLanguages,                  // maxiumum number of languages to retrieve
			[MarshalAs(UnmanagedType.U4)] out int pulActualLanguages               // actual number of languages retrieved
		);

		// This is typically called in response to a mouse move within the 
		// display window.
		// It returns the button located at the specified point within the display window.
		// If no button is present at that position, then VFW_E_DVD_NO_BUTTON is returned.
		// Button indices start at 1. 
		//
		// NOTE: DVD Buttons do not all necessarily have highlight rects,
		// button rects can overlap, and button rects do not always
		// correspond to the visual representation of DVD buttons.
		[PreserveSig]
		int GetButtonAtPosition(
			[In] POINT point,
			[MarshalAs(UnmanagedType.U4)] out int pulButtonIndex);

		// This method maps an EC_DVD_CMD_BEGIN/COMPLETE/CANCEL event's lParam1 into an AddRef'd
		// IDvdCmd pointer.  You must Release the returned pointer.  NULL is returned if the function
		// fails.
		//
		[PreserveSig]
		int GetCmdFromEvent(
			[In] IntPtr lParam1,
			out IDvdCmd pCmdObj);

		// Returns the default language for menus.
		[PreserveSig]
		int GetDefaultMenuLanguage(
			[MarshalAs(UnmanagedType.U4)] out int pLanguage);

		// Gets the default audio language.  
		// Languages are specified with Windows standard LCIDs.
		[PreserveSig]
		int GetDefaultAudioLanguage(
			[MarshalAs(UnmanagedType.U4)] out int pLanguage,
			out DVD_AUDIO_LANG_EXT pAudioExtension);

		// Gets the default subpicture language.  
		// Languages are specified with Windows standard LCIDs.
		[PreserveSig]
		int GetDefaultSubpictureLanguage(
			[MarshalAs(UnmanagedType.U4)] out int pLanguage,
			out DVD_SUBPICTURE_LANG_EXT pSubpictureExtension);

		// Retrieves the DVD decoder's details about max data rate for video, audio
		// and subpicture (going backward and forward) as well as support for various
		// types of audio (AC3, MPEG2, DTS, SDDS, LPCM).
		[PreserveSig]
		int GetDecoderCaps(
			out DVD_DECODER_CAPS pCaps) ;

		// Retrieves the coordinates for a given button number
		[PreserveSig]
		int GetButtonRect(
			[In][MarshalAs(UnmanagedType.U4)] int ulButton,
			out RECT pRect);

		// Determines if the specified subpicture stream is enabled/disabled in the current PGC.
		// ulStreamNum - Subpicture stream number to test
		// pbEnabled   - where to place the result // returned state
		[PreserveSig]
		int IsSubpictureStreamEnabled(
			[In][MarshalAs(UnmanagedType.U4)] int ulStreamNum,
			[MarshalAs(UnmanagedType.Bool)] out bool pbEnabled);
	}

	[ComImport]
	[Guid("33BC7430-EEC0-11D2-8201-00A0C9D74842")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDvdControl2
	{
		[PreserveSig]
		int PlayTitle( 
			[In][MarshalAs(UnmanagedType.U4)] int ulTitle,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int PlayChapterInTitle( 
			[In][MarshalAs(UnmanagedType.U4)] int ulTitle,
			[In][MarshalAs(UnmanagedType.U4)] int ulChapter,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int PlayAtTimeInTitle( 
			[In][MarshalAs(UnmanagedType.U4)] int ulTitle,
			[In] ref DVD_HMSF_TIMECODE pStartTime,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int Stop();

		[PreserveSig]
		int ReturnFromSubmenu( 
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int PlayAtTime( 
			[In] ref DVD_HMSF_TIMECODE pTime,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int PlayChapter( 
			[In][MarshalAs(UnmanagedType.U4)] int ulChapter,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int PlayPrevChapter(
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int ReplayChapter( 
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int PlayNextChapter( 
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int PlayForwards( 
			[In] double dSpeed,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int PlayBackwards( 
			[In] double dSpeed,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int ShowMenu( 
			[In] DVD_MENU_ID MenuID,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int Resume( 
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int SelectRelativeButton( 
			DVD_RELATIVE_BUTTON buttonDir);

		[PreserveSig]
		int ActivateButton();

		[PreserveSig]
		int SelectButton( 
			[In][MarshalAs(UnmanagedType.U4)] int ulButton);

		[PreserveSig]
		int SelectAndActivateButton( 
			[In][MarshalAs(UnmanagedType.U4)] int ulButton);

		[PreserveSig]
		int StillOff();

		[PreserveSig]
		int Pause( 
			[In][MarshalAs(UnmanagedType.Bool)] bool bState);

		[PreserveSig]
		int SelectAudioStream( 
			[In][MarshalAs(UnmanagedType.U4)] int ulAudio,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int SelectSubpictureStream( 
			[In][MarshalAs(UnmanagedType.U4)] int ulSubPicture,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int SetSubpictureState( 
			[In][MarshalAs(UnmanagedType.Bool)] bool bState,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int SelectAngle( 
			[In][MarshalAs(UnmanagedType.U4)] int ulAngle,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int SelectParentalLevel( 
			[In][MarshalAs(UnmanagedType.U4)] int ulParentalLevel);

		[PreserveSig]
		int SelectParentalCountry( 
			[In] CountryCode countryCode);

		[PreserveSig]
		int SelectKaraokeAudioPresentationMode( 
			[In][MarshalAs(UnmanagedType.U4)] int ulMode);

		[PreserveSig]
		int SelectVideoModePreference( 
			[In][MarshalAs(UnmanagedType.U4)] int ulPreferredDisplayMode);

		[PreserveSig]
		int SetDVDDirectory( 
			[In][MarshalAs(UnmanagedType.LPWStr)] string pszwPath);

		[PreserveSig]
		int ActivateAtPosition( 
			[In] POINT point);

		[PreserveSig]
		int SelectAtPosition( 
			[In] POINT point);

		[PreserveSig]
		int PlayChaptersAutoStop( 
			[In][MarshalAs(UnmanagedType.U4)] int ulTitle,
			[In][MarshalAs(UnmanagedType.U4)] int ulChapter,
			[In][MarshalAs(UnmanagedType.U4)] int ulChaptersToPlay,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int AcceptParentalLevelChange( 
			[In][MarshalAs(UnmanagedType.Bool)] bool bAccept);

		[PreserveSig]
		int SetOption( 
			[In] DVD_OPTION_FLAG flag,
			[In][MarshalAs(UnmanagedType.Bool)] bool fState);

		[PreserveSig]
		int SetState( 
			[In] IDvdState pState,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int PlayPeriodInTitleAutoStop( 
			[In][MarshalAs(UnmanagedType.U4)] int ulTitle,
			[In] ref DVD_HMSF_TIMECODE pStartTime,
			[In] ref DVD_HMSF_TIMECODE pEndTime,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int SetGPRM( 
			[In][MarshalAs(UnmanagedType.U4)] int ulIndex,
			[In][MarshalAs(UnmanagedType.U2)] short wValue,
			[In][MarshalAs(UnmanagedType.U4)] DVD_CMD_FLAGS flags,
			[Out] out IDvdCmd ppCmd);

		[PreserveSig]
		int SelectDefaultMenuLanguage( 
			[In][MarshalAs(UnmanagedType.U4)] int lcidLanguage);

		[PreserveSig]
		int SelectDefaultAudioLanguage( 
			[In][MarshalAs(UnmanagedType.U4)] int lcidLanguage,
			[In] DVD_AUDIO_LANG_EXT audioExtension);

		[PreserveSig]
		int SelectDefaultSubpictureLanguage( 
			[In][MarshalAs(UnmanagedType.U4)] int lcidLanguage,
			[In] DVD_SUBPICTURE_LANG_EXT subpictureExtension);
	}

	[ComImport]
	[Guid("5A4A97E4-94EE-4A55-9751-74B5643AA27D")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDvdCmd
	{
		/// <summary>Blocks the application until the command has begun.</summary>
		/// <returns></returns>
		[PreserveSig]
		int WaitForStart();

		/// <summary>Blocks until the command has completed or has been cancelled.</summary>
		/// <returns></returns>
		[PreserveSig]
		int WaitForEnd();
	}

	[ComImport]
	[Guid("86303D6D-1C4A-4087-AB42-F711167048EF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDvdState
	{
		/// <summary>Returns the disc ID from which the bookmark was made.</summary>
		/// <param name="pUniqueID">64-bit unique id for the disc</param>
		/// <returns>HRESULT</returns>
		[PreserveSig]
		int GetDiscID(
			[MarshalAs(UnmanagedType.U8)] out long pUniqueID);

		/// <summary>Returns the state's parental level</summary>
		/// <param name="pParentalLevel"></param>
		/// <returns>HRESULT</returns>
		[PreserveSig]
		int GetParentalLevel(
			[MarshalAs(UnmanagedType.U4)] out int pParentalLevel);
	}

	[ComImport]
	[Guid("56A868B4-0AD4-11CE-B03A-0020AF0BA770")]
	[TypeLibType((short) 0x01040)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IVideoWindow
	{
		#region Properties

		/// <summary>Gets or sets the window title caption.</summary>
		[DispId(0x60020000)]
		string Caption
		{
			[param: MarshalAs(UnmanagedType.BStr)]
			set;
			[return: MarshalAs(UnmanagedType.BStr)]
			get;
		}

		/// <summary>Gets or sets the window styles (as per Win32).</summary>
		[DispId(0x60020000)]
		WindowStyle WindowStyle
		{
			set;
			get;
		}

		/// <summary>Gets or sets the extended window styles (as per Win32).</summary>
		[DispId(0x60020002)]
		WindowStyleEx WindowStyleEx
		{
			set;
			get;
		}

		/// <summary></summary>
		[DispId(0x60020002)]
		OABool AutoShow
		{
			set;
			get;
		}

		/// <summary>Gets or sets the window state (as per Win32)</summary>
		[DispId(0x60020004)]
		WindowState WindowState
		{
			set;
			get;
		}

		/// <summary>
		/// Gets or sets an indicator of whether the video window realizes its palette in the background.
		/// </summary>
		[DispId(0x60020004)]
		OABool BackgroundPalette
		{
			set;
			get;
		}

		/// <summary>
		/// Gets or sets an indicator of whether the window is visible or hidden.
		/// </summary>
		[DispId(0x60020006)]
		OABool Visible
		{
			set;
			get;
		}

		/// <summary>
		/// Gets or sets the x-coordinate of the video window.
		/// </summary>
		[DispId(0x60020006)]
		int Left
		{
			set;
			get;
		}

		/// <summary>
		/// Gets or sets the width of the video window.
		/// </summary>
		[DispId(0x60020008)]
		int Width
		{
			set;
			get;
		}

		/// <summary>
		/// Gets or sets the y-coordinate of the video window.
		/// </summary>
		[DispId(0x60020008)]
		int Top
		{
			set;
			get;
		}

		/// <summary>
		/// Gets or sets the height of the video window.
		/// </summary>
		[DispId(0x6002000A)]
		int Height
		{
			set;
			get;
		}

		/// <summary>
		/// Gets or sets the owning window of the video.
		/// </summary>
		[DispId(0x6002000A)]
		IntPtr Owner
		{
			set;
			get;
		}

		/// <summary>
		/// Gets or sets the window to receive posted messages.
		/// </summary>
		[DispId(0x6002000C)]
		IntPtr MessageDrain
		{
			set;
			get;
		}

		[DispId(0x6002000C)]
		int BorderColor
		{
			get;
			set;
		}

		[DispId(0x6002000E)]
		OABool FullScreenMode
		{
			get;
			set;
		}

		#endregion Properties

		#region Methods
		/// <summary>Places the video window at the top of the Z order.</summary>
		/// <param name="Focus">Specifies whether to give the window focus.</param>
		[DispId(0x6002001e)]
		void SetWindowForeground(
			[In] OABool Focus);

		/// <summary>
		/// TODO:
		/// </summary>
		/// <param name="hwnd"></param>
		/// <param name="uMsg"></param>
		/// <param name="wParam"></param>
		/// <param name="lParam"></param>
		[DispId(0x6002001f)]
		void NotifyOwnerMessage(
			[In] IntPtr hwnd,
			[In] int uMsg,
			[In] IntPtr wParam,
			[In] IntPtr lParam);

		/// <summary>
		/// TODO:
		/// </summary>
		/// <param name="Left"></param>
		/// <param name="Top"></param>
		/// <param name="Width"></param>
		/// <param name="Height"></param>
		[DispId(0x60020020)]
		void SetWindowPosition(
			[In] int Left,
			[In] int Top,
			[In] int Width,
			[In] int Height);

		/// <summary>
		/// TODO:
		/// </summary>
		/// <param name="pLeft"></param>
		/// <param name="pTop"></param>
		/// <param name="pWidth"></param>
		/// <param name="pHeight"></param>
		[DispId(0x60020021)]
		void GetWindowPosition(
			out int pLeft,
			out int pTop,
			out int pWidth,
			out int pHeight);

		/// <summary>
		/// TODO:
		/// </summary>
		/// <param name="pWidth"></param>
		/// <param name="pHeight"></param>
		[DispId(0x60020022)]
		void GetMinIdealImageSize(
			out int pWidth,
			out int pHeight);

		/// <summary>
		/// TODO:
		/// </summary>
		/// <param name="pWidth"></param>
		/// <param name="pHeight"></param>
		[DispId(0x60020023)]
		void GetMaxIdealImageSize(
			out int pWidth,
			out int pHeight);

		/// <summary>
		/// TODO:
		/// </summary>
		/// <param name="pLeft"></param>
		/// <param name="pTop"></param>
		/// <param name="pWidth"></param>
		/// <param name="pHeight"></param>
		[DispId(0x60020024)]
		void GetRestorePosition(
			out int pLeft,
			out int pTop,
			out int pWidth,
			out int pHeight);

		/// <summary>
		/// TODO:
		/// </summary>
		/// <param name="HideCursor"></param>
		[DispId(0x60020025)]
		void HideCursor(
			[In] OABool HideCursor);

		/// <summary>
		/// TODO:
		/// </summary>
		/// <returns></returns>
		[DispId(0x60020026)]
		OABool IsCursorHidden();

		#endregion Methods
	}

	[ComImport]
	[Guid("6E8D4A21-310C-11d0-B79A-00AA003767A7")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComVisible(true)]
	public interface ILine21Decoder
	{
		#region Decoder Options


		/// <summary>
		/// Gets the decoder's level. Supported level value is <see cref="AM_LINE21_CCLEVEL.TC2"/> only.
		/// </summary>
		AM_LINE21_CCLEVEL DecoderLevel { get; }

		/// <summary>
		/// Gets or sets which of the services is being currently used.
		/// </summary>
		/// <value>
		/// Supported service values are:
		/// <list type="">
		///		<item><term><see cref="AM_LINE21_CCSERVICE.Caption1"/></term></item>
		///		<item><term><see cref="AM_LINE21_CCSERVICE.Caption2"/></term></item>
		///		<item><term><see cref="AM_LINE21_CCSERVICE.Text1"/></term></item>
		///		<item><term><see cref="AM_LINE21_CCSERVICE.Text2"/></term></item>
		///		<item><term><see cref="AM_LINE21_CCSERVICE.XDS"/></term></item>
		///		<item><term><see cref="AM_LINE21_CCSERVICE.None"/></term></item>
		/// </list>
		/// </value>
		AM_LINE21_CCSERVICE CurrentService
		{
			get;
			set;
		}


		/// <summary>
		/// Gets or sets the service state (On/Off).
		/// </summary>
		/// <value>
		/// Supported state values are <see cref="AM_LINE21_CCSTATE.On"/> and <see cref="AM_LINE21_CCSTATE.Off"/>.
		/// </value>
		AM_LINE21_CCSTATE ServiceState
		{
			get;
			set;
		}
		#endregion Decoder Options

		#region Output Options

		/// <summary>
		/// Gets the size, bitdepth, etc, that the output video should be.
		/// </summary>
		/// <param name="lpbmih"></param>
		/// <returns>
		///	If successful:
		/// <list type="table">
		///   <item>
		///			<term>S_FALSE</term>
		///			<description>If no output format has so far been defined by downstream filters.</description>
		///		</item>
		///   <item>
		///			<term>S_OK</term>
		///			<description>If an output format has already been defined by downstream filters.</description>
		///		</item>
		/// </list>
		/// </returns>
		[PreserveSig]
		int GetOutputFormat(out BITMAPINFOHEADER lpbmih);

		/// <summary>
		/// Sets the size, bitdepth, etc, that the output video should be.
		/// </summary>
		[PreserveSig]
		int SetOutputFormat(IntPtr lpbmi);

		/// <summary>
		/// Gets or sets the physical color to be used in colorkeying the background for overlay mixing.
		/// </summary>
		/// <value>The background color as a pixel color value. The meaning of the pixel value is
		/// defined by the bit depth of the filter's current output format.</value>
		int BackgroundColor
		{
			[return: MarshalAs(UnmanagedType.U4)]
			get;
			[param: MarshalAs(UnmanagedType.U4)]
			set;
		}

		/// <summary>
		/// Gets or sets whether the whole output bitmap should be redrawn for each sample.
		/// </summary>
		bool RedrawAlways
		{
			[return: MarshalAs(UnmanagedType.Bool)]
			get;
			[param: MarshalAs(UnmanagedType.Bool)]
			set;
		}

		/// <summary>
		/// Gets or sets whether the caption text background should be opaque or transparent.
		/// </summary>
		/// <value>Supported mode values are <see cref="AM_LINE21_DRAWBGMODE.Opaque"/> and
		/// <see cref="AM_LINE21_DRAWBGMODE.Transparent"/>.</value>
		AM_LINE21_DRAWBGMODE DrawBackgroundMode
		{
			get;
			set;
		}
		#endregion Output Options
	}
	#endregion

	#region Structures
	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_HMSF_TIMECODE
	{
		public byte bHours;
		public byte bMinutes;
		public byte bSeconds;
		public byte bFrames;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_PLAYBACK_LOCATION2
  {
		[MarshalAs(UnmanagedType.U4)]
		public int TitleNum;
		[MarshalAs(UnmanagedType.U4)]
		public int ChapterNum;
		public DVD_HMSF_TIMECODE TimeCode;
		[MarshalAs(UnmanagedType.U4)]
		public int TimeCodeFlags;
  }

	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		public int x;
		public int y;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int left;
		public int top;
		public int right;
		public int bottom;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_AudioAttributes
	{
		public DVD_AUDIO_APPMODE   AppMode;
		public byte                AppModeData;

		/// <summary>Use GetKaraokeAttributes()</summary>
		public DVD_AUDIO_FORMAT    AudioFormat;

		/// <summary>0 if no language is present</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int                 Language;

		/// <summary>(captions, if for children etc)</summary>
		public DVD_AUDIO_LANG_EXT  LanguageExtension;

		/// <summary>multichannel attributes are present (Use GetMultiChannelAudioAttributes())</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool                fHasMultichannelInfo;

		/// <summary>in hertz (48k, 96k)</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int                 dwFrequency;

		/// <summary>resolution (16, 20, 24 bits etc), 0 is unknown</summary>
		public byte                bQuantization;

		/// <summary>5.1 AC3 has 6 channels</summary>
		public byte                bNumberOfChannels;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst=2)]
		public int[]               dwReserved;
	}

	/// <summary>
	/// Surround sound mixing information.
	/// </summary>
	/// <remarks>
	/// Surround sound mixing information applied when:
	/// <list type="table">
	///   <item><term>AppMode</term><description>DVD_AudioMode_Surround</description></item>
	///   <item><term>AudioFormat</term><description>DVD_AudioFormat_LPCM</description></item>
	///   <item><term>fHasMultichannelInfo=1</term><description>modes are all on</description></item>
	/// </list>
	/// </remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_MUA_MixingInfo
	{
		[MarshalAs(UnmanagedType.Bool)]
		public bool    fMixTo0;
		[MarshalAs(UnmanagedType.Bool)]
		public bool    fMixTo1;

		[MarshalAs(UnmanagedType.Bool)]
		public bool    fMix0InPhase;
		[MarshalAs(UnmanagedType.Bool)]
		public bool    fMix1InPhase;

		/// <summary>see ksmedia.h: SPEAKER_FRONT_LEFT, SPEAKER_FRONT_RIGHT, etc</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int     dwSpeakerPosition;
	}

	/// <summary>The alpha coeff is used to mix to ACH0 and beta is used to mix to ACH1.</summary>
	/// <remarks>
	/// In general:
	/// <list type="">
	///   <item><term>ACH0 = coeff[0].alpha * value[0] + coeff[1].alpha * value[1] + ...</term></item>
	///   <item><term>ACH1 = coeff[0].beta * value[0]  + coeff[1].beta * value[1] + ...</term></item>
	/// </list>
	/// </remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_MUA_Coeff
	{
		/// <summary>actual coeff = 2^alpha</summary>
		public double log2_alpha;

		/// <summary>actual coeff = 2^beta</summary>
		public double log2_beta;
	}

	/// <summary>actual Data for each data stream</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_MultichannelAudioAttributes
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
		public DVD_MUA_MixingInfo[] Info;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
		public DVD_MUA_Coeff[]      Coeff;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_KaraokeAttributes
	{
		public byte            bVersion;

		[MarshalAs(UnmanagedType.Bool)]
		public bool            fMasterOfCeremoniesInGuideVocal1;

		/// <summary>false = solo</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool            fDuet;

		public DVD_KARAOKE_ASSIGNMENT  ChannelAssignment;

		/// <summary>logical OR of DVD_KARAOKE_CONTENTS</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
		public short[]         wChannelContents;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_VideoAttributes
	{
		/// <summary>if a 4x3 display, can be shown as PanScan</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool        fPanscanPermitted;

		/// <summary>if a 4x3 display, can be shown as Letterbox</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool        fLetterboxPermitted;

		/// <summary>4x3 or 16x9</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int         ulAspectX;

		[MarshalAs(UnmanagedType.U4)]
		public int         ulAspectY;

		/// <summary>50hz or 60hz</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int         ulFrameRate;

		/// <summary>525 (60hz) or 625 (50hz)</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int         ulFrameHeight;

		/// <summary>MPEG1 or MPEG2</summary>
		public DVD_VIDEO_COMPRESSION   Compression;

		/// <summary>true if there is user data in field 1 of GOP of video stream</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool        fLine21Field1InGOP;

		/// <summary>true if there is user data in field 1 of GOP of video stream</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool        fLine21Field2InGOP;

		/// <summary>X source resolution (352,704, or 720)</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int         ulSourceResolutionX;

		/// <summary>Y source resolution (240,480, 288 or 576)</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int         ulSourceResolutionY;

		/// <summary>
		/// subpictures and highlights (e.g. subtitles or menu buttons) are only displayed
		/// in the active video area and cannot be displayed in the top/bottom 'black' bars
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool        fIsSourceLetterboxed;
																				
		/// <summary>for 625/50hz systems, is film mode (true) or camera mode (false)</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool        fIsFilmMode;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_SubpictureAttributes
	{
		public DVD_SUBPICTURE_TYPE     Type;
		public DVD_SUBPICTURE_CODING   CodingMode;
		[MarshalAs(UnmanagedType.U4)]
		public int                     Language;
		public DVD_SUBPICTURE_LANG_EXT LanguageExtension;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_TitleAttributes
	{
		/// <summary>for Titles</summary>
		public DVD_TITLE_APPMODE           AppMode;

		/// <summary>Attributes about the 'main' video of the menu or title</summary> 
		public DVD_VideoAttributes         VideoAttributes;

		[MarshalAs(UnmanagedType.U4)]
		public int                         ulNumberOfAudioStreams;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
		public DVD_AudioAttributes[]       AudioAttributes;

		/// <summary>Present if the multichannel bit is set in the corresponding stream's audio attributes.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=8)]
		public DVD_MultichannelAudioAttributes[]  MultichannelAudioAttributes;

		[MarshalAs(UnmanagedType.U4)]
		public int                         ulNumberOfSubpictureStreams;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst=32)]
		public DVD_SubpictureAttributes[]  SubpictureAttributes;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_MenuAttributes
	{
		/// <summary>for VMG only. Indices 0..7 correspond to regions 1..8</summary>
		[MarshalAs(UnmanagedType.Bool, SizeConst=8)]
		public bool[]                   fCompatibleRegion;

		/// <summary>Attributes about the main menu (VMGM or VTSM).</summary>
		public DVD_VideoAttributes      VideoAttributes;

		[MarshalAs(UnmanagedType.Bool)]
		public bool                     fAudioPresent;
		public DVD_AudioAttributes      AudioAttributes;

		[MarshalAs(UnmanagedType.Bool)]
		public bool                     fSubpicturePresent;
		public DVD_SubpictureAttributes SubpictureAttributes;
	}

	// DVD Decoder Caps data
	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_DECODER_CAPS
	{
		/// <summary>size of this struct</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int     dwSize;
		/// <summary>bits indicating audio support (AC3, DTS, SDDS, LPCM etc.) of decoder</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int dwAudioCaps;
		/// <summary>max data rate for video going forward</summary>
		public double  dFwdMaxRateVideo;
		/// <summary>max data rate for audio going forward</summary>
		public double  dFwdMaxRateAudio;
		/// <summary>max data rate for   SP  going forward</summary>
		public double  dFwdMaxRateSP;
		/// <summary>if smooth reverse is not available, this will be set to 0</summary>
		public double  dBwdMaxRateVideo;
		/// <summary>if smooth reverse is not available, this will be set to 0</summary>
		public double  dBwdMaxRateAudio;
		/// <summary>if smooth reverse is not available, this will be set to 0</summary>
		public double  dBwdMaxRateSP;
		/// <summary>reserved for future expansion</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int dwRes1;
		/// <summary>reserved for future expansion</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int dwRes2;
		/// <summary>reserved for future expansion</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int dwRes3;
		/// <summary>reserved for future expansion</summary>
		[MarshalAs(UnmanagedType.U4)]
		public int dwRes4;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct SystemParameterRegisters
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
		public short[] Registers;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct GeneralParameterRegisters
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public short[] Registers;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct CountryCode
	{
		/// <summary>The Alpha-2 code of the ISO-3166 standard.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] Code;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BITMAPINFOHEADER
	{
		public uint biSize;
		public int biWidth;
		public int biHeight;
		public ushort biPlanes;
		public ushort biBitCount;
		public int biCompression;
		public uint biSizeImage;
		public int biXPelsPerMeter;
		public int biYPelsPerMeter;
		public uint biClrUsed;
		public uint biClrImportant;
	}

	public struct BITMAPINFO
	{
		public BITMAPINFOHEADER bmiHeader;
		[MarshalAs(UnmanagedType.ByValArray, SizeConst=16)]
		public RGBQUAD[]        bmiColors;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct RGBQUAD
	{
		public byte blue;
		public byte green;
		public byte red;
		public byte reserved;
	}
	#endregion

	#region Enumerations
	[Flags]
	public enum DVD_GRAPH_FLAGS
	{
		DEFAULT      =      0,
		HWDEC_PREFER =   0x01,  // default 
		HWDEC_ONLY   =   0x02,
		SWDEC_PREFER =   0x04,
		SWDEC_ONLY   =   0x08,
		NOVPE        =  0x100,
		DO_NOT_CLEAR =  0x200,  // do not clear graph before building
		VMR9_ONLY    = 0x0800,  // only use VMR9 (otherwise fail) for rendering
		EVR_ONLY     = 0x1000,  // only use EVR (otherwise fail) for rendering
	}

	[Flags]
	public enum DVD_CMD_FLAGS
	{
		None	= 0,
		Flush	= 0x1,
		SendEvents	= 0x2,
		Block	= 0x4,
		StartWhenRendered	= 0x8,
		EndAfterRendered	= 0x10
	}

	[Flags]
	public enum DVD_STREAM_FLAGS
	{
		STREAM_VIDEO  = 0x01,
		STREAM_AUDIO  = 0x02,
		STREAM_SUBPIC = 0x04
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct DVD_RENDERSTATUS
	{
		public int  hrVPEStatus ;       // VPE mixing error code (0 => success)
		[MarshalAs(UnmanagedType.Bool)]
		public bool isDvdVolInvalid;    // Is specified DVD volume invalid?
		[MarshalAs(UnmanagedType.Bool)]
		public bool isDvdVolUnknown;    // Is DVD volume to be played not specified/not found?
		[MarshalAs(UnmanagedType.Bool)]
		public bool isNoLine21In;       // video decoder doesn't produce line21 (CC) data
		[MarshalAs(UnmanagedType.Bool)]
		public bool isNoLine21Out;      // can't show decoded line21 data as CC on video
		public int iNumStreams;         // number of DVD streams to render
		public int iNumStreamsFailed;   // number of streams failed to render
		[MarshalAs(UnmanagedType.U4)]
		public int dwFailedStreamsFlag; // combination of flags to indicate failed streams
	};

	[StructLayout(LayoutKind.Sequential)]
	public struct AM_MEDIA_TYPE
  {
		public Guid majortype;
		public Guid subtype;
		[MarshalAs(UnmanagedType.Bool)]
		public bool bFixedSizeSamples;
		[MarshalAs(UnmanagedType.Bool)]
		public bool bTemporalCompression;
		[MarshalAs(UnmanagedType.U4)]
		public int lSampleSize;
		public Guid formattype;
		[MarshalAs(UnmanagedType.Interface)]
		public object pUnk;
		[MarshalAs(UnmanagedType.U4)]
		public int cbFormat;
		public IntPtr pbFormat;
	}

	public enum DVD_OPTION_FLAG
	{
		ResetOnStop               = 1,  // default TRUE
		NotifyParentalLevelChange = 2,  // default FALSE
		HMSF_TimeCodeEvents       = 3,  // default FALSE (send DVD_CURRENT_TIME events)
		AudioDuringFFwdRew        = 4,  // default FALSE (or by reg)
		EnableNonblockingAPIs     = 5,  // default FALSE
		CacheSizeInMB             = 6,  // default FALSE (or by reg)
		EnablePortableBookmarks   = 7,  // default FALSE
		EnableExtendedCopyProtectErrors   = 8,  // default FALSE
	}

	public enum DVD_TextStringType
	{
		#region disc structure (0x00..0x0f)
		Struct_Volume               = 0x01, 
		Struct_Title                = 0x02, 
		Struct_ParentalID           = 0x03,
		Struct_PartOfTitle          = 0x04,
		Struct_Cell                 = 0x05,
		#endregion disc structure (0x00..0x0f)

		#region stream (0x10..0x1f)
		Stream_Audio                = 0x10,
		Stream_Subpicture           = 0x11,
		Stream_Angle                = 0x12,
		#endregion stream (0x10..0x1f)

		#region channel in stream (0x20..0x2f)
		Channel_Audio               = 0x20,
		#endregion channel in stream (0x20..0x2f)

		#region Application information

		#region General (0x30..0x37)
		General_Name                = 0x30,
		General_Comments            = 0x31,
		#endregion General (0x30..0x37)

		#region Title (0x38..0x3f)
		Title_Series                = 0x38,
		Title_Movie                 = 0x39,
		Title_Video                 = 0x3a,
		Title_Album                 = 0x3b,
		Title_Song                  = 0x3c,
		Title_Other                 = 0x3f,
		#endregion Title (0x38..0x3f)

		#region Title (sub) (0x40..0x47)
		Title_Sub_Series            = 0x40,
		Title_Sub_Movie             = 0x41,
		Title_Sub_Video             = 0x42,
		Title_Sub_Album             = 0x43,
		Title_Sub_Song              = 0x44,
		Title_Sub_Other             = 0x47,
		#endregion Title (sub) (0x40..0x47)

		#region Title (original) (0x48..0x4f)
		Title_Orig_Series           = 0x48,
		Title_Orig_Movie            = 0x49,
		Title_Orig_Video            = 0x4a,
		Title_Orig_Album            = 0x4b,
		Title_Orig_Song             = 0x4c,
		Title_Orig_Other            = 0x4f,
		#endregion Title (original) (0x48..0x4f)

		#region Other info (0x50..0x57)
		Other_Scene                 = 0x50,
		Other_Cut                   = 0x51,
		Other_Take                  = 0x52,
		#endregion Other info (0x50..0x57)

		// Language     0x58..0x5b
		// Work         0x5c..0x6b
		// Character    0x6c..0x8f
		// Data         0x90..0x93
		// Karaoke      0x94..0x9b
		// Category     0x9c..0x9f
		// Lyrics       0xa0..0xa3
		// Document     0xa4..0xa7
		// Others       0xa8..0xab
		// Reserved     0xac..0xaf
		// Admin        0xb0..0xb7
		// more admin   0xb8..0xc0
		// Reserved     0xd0..0xdf
		// vendor       0xe0..0xef
		// extension    0xf0..0xf7
		// reserved     0xf8..0xff
		#endregion Application information
	}

	public enum DVD_TextCharSet
	{
		CharSet_Unicode                       = 0,
		CharSet_ISO646                        = 1,
		CharSet_JIS_Roman_Kanji               = 2,
		CharSet_ISO8859_1                     = 3,
		CharSet_ShiftJIS_Kanji_Roman_Katakana = 4
	}

	/// <summary>Used to indicate the stat of a DVD player.</summary>
	public enum DVD_DOMAIN
	{
		/// <summary>doing default initialization of a dvd disc</summary>
		FirstPlay=1,
		/// <summary>displaying menus for whole disc</summary>
		VideoManagerMenu,
		/// <summary>displaying menus for current title set</summary>
		VideoTitleSetMenu,
		/// <summary>displaying current title</summary>
		Title,
		/// <summary>player is in stopped state</summary>
		Stop
	}

	/// <summary>
	/// Menu identifier.
	/// </summary>
	/// <remarks>The Root menu always provides a means of getting to to Subpicture,
	/// Audio, Angle and Chapter menus if they exist.</remarks>
	public enum DVD_MENU_ID
	{
		/// <summary>to choose a title from any VTS in a DVD-Video volume</summary>
		Title = 2,
		/// <summary>main menu for a specific VTS </summary>
		Root = 3,
		/// <summary>to choose subpicture stream in a VTS</summary>
		Subpicture = 4,
		/// <summary>to choose audio stream in a VTS</summary>
		Audio = 5,
		/// <summary>to choose angle num in a VTS</summary>
		Angle = 6,
		/// <summary>to choose a chapter in a VTS</summary>
		Chapter = 7
	}

	public enum DVD_DISC_SIDE
	{
		A = 1,
		B = 2
	}


	/// <summary>
	/// Used to indicate the user's preferred window aspect ratio and preferred method of
	/// converion of 16x9 content to a 4x3 window aspect ratio.
	/// </summary>
	/// <remarks>
	/// Pan-scan and letterboxing are the two conversion methods. This enum is used to
	/// indicate only a preference of conversion mechinism since some content can only be
	/// converted using one of these methods. 4x3 content is converted to a 16x9 window
	/// always by using "reverse" letterboxing where black bars are added to the right
	/// and left sides of the display instead of the top and bottom of the display as in
	/// the 16x9 to 4x3 conversion useing letterboxing.
	/// </remarks>
	public enum DVD_PREFERRED_DISPLAY_MODE
	{
		/// <summary>default to content</summary>
		CONTENT_DEFAULT = 0,
		/// <summary>16x9 display</summary>
		DISPLAY_16x9 = 1,
		/// <summary>4x3 display with pan-scan preferrence</summary>
		DISPLAY_4x3_PANSCAN_PREFERRED = 2,
		/// <summary>4x3 display with letterbox preferrence</summary>
		DISPLAY_4x3_LETTERBOX_PREFERRED = 3
	}

	public enum DVD_AUDIO_LANG_EXT
	{
		NotSpecified      = 0,
		Captions          = 1,
		VisuallyImpaired  = 2,
		DirectorComments1 = 3,
		DirectorComments2 = 4,
	}

	public enum DVD_SUBPICTURE_LANG_EXT
	{
		NotSpecified              = 0,
		Caption_Normal            = 1,
		Caption_Big               = 2,
		Caption_Children          = 3,
		CC_Normal                 = 5,
		CC_Big                    = 6,
		CC_Children               = 7,
		Forced                    = 9,
		DirectorComments_Normal   = 13,
		DirectorComments_Big      = 14,
		DirectorComments_Children = 15,
	}

	public enum DVD_AUDIO_APPMODE
	{
		None     = 0,
		Karaoke  = 1,
		Surround = 2,
		Other    = 3
	}

	public enum DVD_AUDIO_FORMAT
	{
		AC3       = 0,
		MPEG1     = 1,
		MPEG1_DRC = 2,
		MPEG2     = 3,
		MPEG2_DRC = 4,
		LPCM      = 5,
		DTS       = 6,
		SDDS      = 7,
		Other     = 8
	}

	/// <summary>
	/// Flags for SelectKaraokeAudioPresentationMode.
	/// </summary>
	[Flags]
	public enum DVD_KARAOKE_DOWNMIX
	{
		/// <summary>unused - reserved for future use</summary>
		Mix_0to0 = 0x0001,
		/// <summary>unused - reserved for future use</summary>
		Mix_1to0 = 0x0002,
		Mix_2to0 = 0x0004,
		Mix_3to0 = 0x0008,
		Mix_4to0 = 0x0010,
		/// <summary>mix auxillary L to channel 0 (left speaker)</summary>
		Mix_Lto0 = 0x0020,
		/// <summary>mix auxillary R to channel 0 (left speaker)</summary>
		Mix_Rto0 = 0x0040,

		/// <summary>unused - reserved for future use</summary>
		Mix_0to1 = 0x0100,
		/// <summary>unused - reserved for future use</summary>
		Mix_1to1 = 0x0200,
		Mix_2to1 = 0x0400,
		Mix_3to1 = 0x0800,
		Mix_4to1 = 0x1000,
		/// <summary>mix auxillary L to channel 1 (right speaker)</summary>
		Mix_Lto1 = 0x2000,
		/// <summary>mix auxillary R to channel 1 (right speaker)</summary>
		Mix_Rto1 = 0x4000,
	}

	public enum DVD_RELATIVE_BUTTON
	{
		Upper = 1,
		Lower = 2,
		Left  = 3,
		Right = 4
	}

	/// <summary>Bitwise OR of these flags descript the contents of each channel</summary>
	[Flags]
	public enum DVD_KARAOKE_CONTENTS
	{
		GuideVocal1  = 0x0001,
		GuideVocal2  = 0x0002,
		GuideMelody1 = 0x0004,
		GuideMelody2 = 0x0008,
		GuideMelodyA = 0x0010,
		GuideMelodyB = 0x0020,
		SoundEffectA = 0x0040,
		SoundEffectB = 0x0080
	}

	public enum DVD_KARAOKE_ASSIGNMENT
	{
		reserved0   = 0,
		reserved1   = 1,
		LR    = 2,   // left right
		LRM   = 3,   // left right middle
		LR1   = 4,   // left right audio1
		LRM1  = 5,   // left right middle audio1
		LR12  = 6,   // left right audio1 audio2
		LRM12 = 7    // left right middle audio1 audio2
	}

	public enum DVD_VIDEO_COMPRESSION
	{
		Other = 0,
		MPEG1 = 1,
		MPEG2 = 2,
	}

	public enum DVD_SUBPICTURE_TYPE
	{
		DVD_SPType_NotSpecified = 0,
		DVD_SPType_Language     = 1,
		DVD_SPType_Other        = 2,
	}

	public enum DVD_SUBPICTURE_CODING
	{
		DVD_SPCoding_RunLength    = 0,
		DVD_SPCoding_Extended     = 1,
		DVD_SPCoding_Other        = 2,
	}

	public enum DVD_TITLE_APPMODE
	{
		DVD_AppMode_Not_Specified = 0, // no special mode
		DVD_AppMode_Karaoke  = 1,
		DVD_AppMode_Other    = 3,
	}

	/// <summary>
	/// From #define OATRUE/OAFALSE
	/// </summary>
	public enum OABool
	{
		False = 0,
		True = -1 // bools in .NET use 1, not -1
	}

	/// <summary>
	/// From WS_* defines
	/// </summary>
	[Flags]
	public enum WindowStyle
	{
		Overlapped     =  0x00000000,
		Popup       =     unchecked((int)0x80000000),
		Child       =     0x40000000,
		Minimize    =     0x20000000,
		Visible     =     0x10000000,
		Disabled    =     0x08000000,
		ClipSiblings =    0x04000000,
		ClipChildren =    0x02000000,
		Maximize      =   0x01000000,
		Caption       =   0x00C00000,
		Border        =   0x00800000,
		DlgFrame      =   0x00400000,
		VScroll       =   0x00200000,
		HScroll       =   0x00100000,
		SysMenu       =   0x00080000,
		ThickFrame    =   0x00040000,
		Group         =   0x00020000,
		TabStop       =   0x00010000,
		MinimizeBox   =   0x00020000,
		MaximizeBox   =   0x00010000
	}

	/// <summary>
	/// From WS_EX_* defines
	/// </summary>
	[Flags]
	public enum WindowStyleEx
	{
		DlgModalFrame   =  0x00000001,
		NoParentNotify  =  0x00000004,
		Topmost         =  0x00000008,
		AcceptFiles     =  0x00000010,
		Transparent     =  0x00000020,
		MDIChild        =  0x00000040,
		ToolWindow      =  0x00000080,
		WindowEdge      =  0x00000100,
		ClientEdge      =  0x00000200,
		ContextHelp     =  0x00000400,
		Right           =  0x00001000,
		Left            =  0x00000000,
		RTLReading      =  0x00002000,
		LTRReading      =  0x00000000,
		LeftScrollBar   =  0x00004000,
		RightScrollBar  =  0x00000000,
		ControlParent   =  0x00010000,
		StaticEdge      =  0x00020000,
		APPWindow       =  0x00040000,
		Layered         =  0x00080000,
		NoInheritLayout =  0x00100000,
		LayoutRTL       =  0x00400000,
		Composited      =  0x02000000,
		NoActivate      =  0x08000000
	}

	/// <summary>
	/// From SW_* defines
	/// </summary>
	public enum WindowState
	{
		Hide = 0,
		Normal,
		ShowMinimized,
		ShowMaximized,
		ShowNoActivate,
		Show,
		Minimize,
		ShowMinNoActive,
		ShowNA,
		Restore,
		ShowDefault,
		ForceMinimize
	}

	public enum AM_LINE21_CCLEVEL
	{
		TC2 = 0
	}

	public enum AM_LINE21_CCSERVICE
	{
		None = 0,
		Caption1,
		Caption2,
		Text1,
		Text2,
		XDS,
		DefChannel = 10,
		Invalid
	}

	public enum AM_LINE21_CCSTATE
	{
		Off = 0,
		On
	}

	public enum AM_LINE21_CCSTYLE
	{
		None = 0,
		PopOn,
		PaintOn,
		RollUp
	}

	public enum AM_LINE21_DRAWBGMODE
	{
		Opaque,
		Transparent
	}
	#endregion
}
