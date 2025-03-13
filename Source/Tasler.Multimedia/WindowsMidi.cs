using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;


namespace Tasler.Multimedia 
{
	// Delegates
	public delegate void MidiInProc(
		IntPtr hMidiIn,
		uint wMsg,
		IntPtr dwInstance,
		IntPtr dwParam1,
		UIntPtr dwParam2
	);

	public delegate void MidiOutProc(
		IntPtr hMidiOut,
		uint wMsg,
		IntPtr dwInstance,
		IntPtr dwParam1,
		UIntPtr dwParam2
	);


	public enum MidiStatus : byte 
	{
		NoteOn             = 0x90,
		NoteOff            = 0x80,
		KeyAfterTouch      = 0xA0,
		ControlChange      = 0xB0,
		ProgramChange      = 0xC0,
		ChanAfterTouch     = 0xD0,
		PitchBend          = 0xE0,
		SystemMessage      = 0xF0,
		BeginSysex         = 0xF0,
		MtcQuarterFrame    = 0xF1,
		SongPosPtr         = 0xF2,
		SongSelect         = 0xF3,
		TuneRequest        = 0xF6,
		SystemExclusiveEnd = 0xF7,
		TimingClock        = 0xF8,
		Start              = 0xFA,
		Continue           = 0xFB,
		Stop               = 0xFC,
		ActiveSensing      = 0xFE,
		SystemReset        = 0xFF,
	}

	[ComVisible(false)]
	[SuppressUnmanagedCodeSecurity]
	public class WindowsMidi 
	{
		public static void TranslateMidiInResult(uint result) 
		{
			if (result != WindowsMidi.MMSYSERR_NOERROR)
			{
				StringBuilder sb = new StringBuilder(MAXERRORLENGTH);
				WindowsMidi.midiInGetErrorText(result, sb, sb.Capacity);

				// TODO: Translate error code to an exception
				throw new Exception(sb.ToString());
			}
		}
		
		public static void TranslateMidiOutResult(uint result) 
		{
			if (result != WindowsMidi.MMSYSERR_NOERROR)
			{
				StringBuilder sb = new StringBuilder(MAXERRORLENGTH);
				WindowsMidi.midiOutGetErrorText(result, sb, sb.Capacity);

				// TODO: Translate error code to an exception
				throw new Exception(sb.ToString());
			}
		}
		
		#region MIDI error return values
		public const int MIDIERR_BASE = 64;
		public const int MIDIERR_UNPREPARED    = (MIDIERR_BASE + 0);   /* header not prepared */
		public const int MIDIERR_STILLPLAYING  = (MIDIERR_BASE + 1);   /* still something playing */
		public const int MIDIERR_NOMAP         = (MIDIERR_BASE + 2);   /* no configured instruments */
		public const int MIDIERR_NOTREADY      = (MIDIERR_BASE + 3);   /* hardware is still busy */
		public const int MIDIERR_NODEVICE      = (MIDIERR_BASE + 4);   /* port no longer connected */
		public const int MIDIERR_INVALIDSETUP  = (MIDIERR_BASE + 5);   /* invalid MIF */
		public const int MIDIERR_BADOPENMODE   = (MIDIERR_BASE + 6);   /* operation unsupported w/ open mode */
		public const int MIDIERR_DONT_CONTINUE = (MIDIERR_BASE + 7);   /* thru device 'eating' a message */
		public const int MIDIERR_LASTERROR     = (MIDIERR_BASE + 7);   /* last error in range */
		#endregion

		public const int MIDIPATCHSIZE   = 128;

		#region MIDI callback messages
			public const int CALLBACK_FUNCTION = 0x00030000;    /* dwCallback is a FARPROC */

			#region MIDI input
				public const int MM_MIM_OPEN      = 0x3C1;
				public const int MM_MIM_CLOSE     = 0x3C2;
				public const int MM_MIM_DATA      = 0x3C3;
				public const int MM_MIM_LONGDATA  = 0x3C4;
				public const int MM_MIM_ERROR     = 0x3C5;
				public const int MM_MIM_LONGERROR = 0x3C6;
				public const int MM_MIM_MOREDATA  = 0x3CC;  // MIM_DONE w/ pending events
				public const int MIM_OPEN      = MM_MIM_OPEN;
				public const int MIM_CLOSE     = MM_MIM_CLOSE;
				public const int MIM_DATA      = MM_MIM_DATA;
				public const int MIM_LONGDATA  = MM_MIM_LONGDATA;
				public const int MIM_ERROR     = MM_MIM_ERROR;
				public const int MIM_LONGERROR = MM_MIM_LONGERROR;
				public const int MIM_MOREDATA  = MM_MIM_MOREDATA;
			#endregion

			#region MIDI output
				public const int MM_MOM_OPEN       = 0x3C7;
				public const int MM_MOM_CLOSE      = 0x3C8;
				public const int MM_MOM_DONE       = 0x3C9;
				public const int MM_MOM_POSITIONCB = 0x3CA;  // Callback for MEVT_POSITIONCB
				public const int MOM_OPEN       = MM_MOM_OPEN;
				public const int MOM_CLOSE      = MM_MOM_CLOSE;
				public const int MOM_DONE       = MM_MOM_DONE;
				public const int MOM_POSITIONCB = MM_MOM_POSITIONCB;
			#endregion

		#endregion

		/// <summary>Device ID for MIDI mapper</summary>
		public const uint MIDIMAPPER  = unchecked((uint)-1);
		/// <summary>Device ID for MIDI mapper</summary>
		public const uint MIDI_MAPPER = unchecked((uint)-1);

		/// <summary>Flags for dwFlags parm of midiInOpen()</summary>
		public const int MIDI_IO_STATUS = 0x00000020;

		#region General error return values
		public const int MMSYSERR_BASE         = 0;
		public const int MMSYSERR_NOERROR      = 0;                    /* no error */
		public const int MMSYSERR_ERROR        = (MMSYSERR_BASE +  1); /* unspecified error */
		public const int MMSYSERR_BADDEVICEID  = (MMSYSERR_BASE +  2); /* device ID out of range */
		public const int MMSYSERR_NOTENABLED   = (MMSYSERR_BASE +  3); /* driver failed enable */
		public const int MMSYSERR_ALLOCATED    = (MMSYSERR_BASE +  4); /* device already allocated */
		public const int MMSYSERR_INVALHANDLE  = (MMSYSERR_BASE +  5); /* device handle is invalid */
		public const int MMSYSERR_NODRIVER     = (MMSYSERR_BASE +  6); /* no device driver present */
		public const int MMSYSERR_NOMEM        = (MMSYSERR_BASE +  7); /* memory allocation error */
		public const int MMSYSERR_NOTSUPPORTED = (MMSYSERR_BASE +  8); /* function isn't supported */
		public const int MMSYSERR_BADERRNUM    = (MMSYSERR_BASE +  9); /* error value out of range */
		public const int MMSYSERR_INVALFLAG    = (MMSYSERR_BASE + 10); /* invalid flag passed */
		public const int MMSYSERR_INVALPARAM   = (MMSYSERR_BASE + 11); /* invalid parameter passed */
		public const int MMSYSERR_HANDLEBUSY   = (MMSYSERR_BASE + 12); /* handle being used */
																	/* simultaneously on another */
																	/* thread (eg callback) */
		public const int MMSYSERR_INVALIDALIAS = (MMSYSERR_BASE + 13); /* specified alias not found */
		public const int MMSYSERR_BADDB        = (MMSYSERR_BASE + 14); /* bad registry database */
		public const int MMSYSERR_KEYNOTFOUND  = (MMSYSERR_BASE + 15); /* registry key not found */
		public const int MMSYSERR_READERROR    = (MMSYSERR_BASE + 16); /* registry read error */
		public const int MMSYSERR_WRITEERROR   = (MMSYSERR_BASE + 17); /* registry write error */
		public const int MMSYSERR_DELETEERROR  = (MMSYSERR_BASE + 18); /* registry delete error */
		public const int MMSYSERR_VALNOTFOUND  = (MMSYSERR_BASE + 19); /* registry value not found */
		public const int MMSYSERR_NODRIVERCB   = (MMSYSERR_BASE + 20); /* driver does not call DriverCallback */
		public const int MMSYSERR_MOREDATA     = (MMSYSERR_BASE + 21); /* more data to be returned */
		#endregion

		/// <summary>
		/// Flags for wFlags parm of midiOutCachePatches(), midiOutCacheDrumPatches()
		/// </summary>
		public enum MidiCache : uint 
		{
			/// <summary>
			/// Caches all of the specified patches. If they cannot all be cached,
			/// it caches none, clears the PATCHARRAY array, and returns MMSYSERR_NOMEM.
			/// </summary>
			All     = 1,

			/// <summary>
			/// Caches all of the specified patches. If they cannot all be cached,
			/// it caches as many patches as possible, changes the PATCHARRAY array
			/// to reflect which patches were cached, and returns MMSYSERR_NOMEM.
			/// </summary>
			BestFit = 2,

			/// <summary>
			/// Changes the PATCHARRAY array to indicate which patches are currently cached.
			/// </summary>
			Query   = 3,

			/// <summary>
			/// Uncaches the specified patches and clears the PATCHARRAY array.
			/// </summary>
			Uncache = 4,
		}


		/// <summary>Maximum product name length (including NULL).</summary>
		public const int MAXPNAMELEN = 32;
		/// <summary>Maximum error text length (including NULL).</summary>
		public const int MAXERRORLENGTH = 256;


		/// <summary>
		/// MIDI output device capabilities structure.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
		public struct MIDIOUTCAPS 
		{
			public ushort    wMid;                  /* public manufacturer ID */
			public ushort    wPid;                  /* public product ID */
			public uint      vDriverVersion;        /* public version of public the driver */
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=MAXPNAMELEN)]
			public string    productName;           // public product name
			public ushort    wTechnology;           /* public type of device */
			public ushort    wVoices;               /* # public of voices (public internal synth only) */
			public ushort    wNotes;                /* max # public of notes (public internal synth only) */
			public ushort    wChannelMask;          /* public channels used (public internal synth only) */
			public uint      dwSupport;             /* public functionality supported public by driver */
		}
		public const int SIZEOF_MIDIOUTCAPS = 52;

		[StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
		public struct MIDIOUTCAPS2 
		{
			public ushort    wMid;                /* public manufacturer ID */
			public ushort    wPid;                /* public product ID */
			public uint      vDriverVersion;      /* public version of public the driver */
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=MAXPNAMELEN)]
			public string    productName;         // public product name
			public ushort    wTechnology;         /* public type of device */
			public ushort    wVoices;             /* # public of voices (public internal synth only) */
			public ushort    wNotes;              /* max # public of notes (public internal synth only) */
			public ushort    wChannelMask;        /* public channels used (public internal synth only) */
			public uint      dwSupport;           /* public functionality supported public by driver */
			public Guid      ManufacturerGuid;    /* public for extensible public MID mapping */
			public Guid      ProductGuid;         /* public for extensible public PID mapping */
			public Guid      NameGuid;            /* public for name public lookup in registry */
		}
		public const int SIZEOF_MIDIOUTCAPS2 = SIZEOF_MIDIOUTCAPS + 48;

		/* flags for wTechnology field of MIDIOUTCAPS structure */
		public const int MOD_MIDIPORT    = 1;  /* output port */
		public const int MOD_SYNTH       = 2;  /* generic internal synth */
		public const int MOD_SQSYNTH     = 3;  /* square wave internal synth */
		public const int MOD_FMSYNTH     = 4;  /* FM internal synth */
		public const int MOD_MAPPER      = 5;  /* MIDI mapper */
		public const int MOD_WAVETABLE   = 6;  /* hardware wavetable synth */
		public const int MOD_SWSYNTH     = 7;  /* software synth */

		/* flags for dwSupport field of MIDIOUTCAPS structure */
		public const int MIDICAPS_VOLUME          = 0x0001;  /* supports volume control */
		public const int MIDICAPS_LRVOLUME        = 0x0002;  /* separate left-right volume control */
		public const int MIDICAPS_CACHE           = 0x0004;
		public const int MIDICAPS_STREAM          = 0x0008;  /* driver supports midiStreamOut directly */

		/* MIDI input device capabilities structure */
		[StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
		public struct MIDIINCAPS 
		{
			public ushort wMid;                   /* public manufacturer ID */
			public ushort wPid;                   /* public product ID */
			public uint   vDriverVersion;         /* public version of public the driver */
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=MAXPNAMELEN)]
			public string productName;            // public product name
			public uint   dwSupport;              /* public functionality supported public by driver */
		}
		public const int SIZEOF_MIDIINCAPS = 44;

		[StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Auto)]
		public struct MIDIINCAPS2 
		{
			public ushort wMid;                   /* public manufacturer ID */
			public ushort wPid;                   /* public product ID */
			public uint   vDriverVersion;         /* public version of public the driver */
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst=MAXPNAMELEN)]
			public string productName;            // public product name
			public uint   dwSupport;              /* public functionality supported public by driver */
			public Guid   ManufacturerGuid;       /* public for extensible public MID mapping */
			public Guid   ProductGuid;            /* public for extensible public PID mapping */
			public Guid   NameGuid;               /* public for name public lookup in registry */
		}
		public const int SIZEOF_MIDIINCAPS2 = SIZEOF_MIDIINCAPS + 48;

		[Flags]
		public enum MidiHeaderFlags : uint 
		{
			/// <summary>
			///	Set by the device driver to indicate that it is finished with the buffer
			///	and is returning it to the application.
			/// </summary>
			Done = 0x00000001,

			/// <summary>
			/// Set by Windows to indicate that the buffer has been prepared by using the
			/// midiInPrepareHeader or midiOutPrepareHeader function.
			/// </summary>
			Prepared = 0x00000002,

			/// <summary>
			/// Set by Windows to indicate that the buffer is queued for playback.
			/// </summary>
			InQueue = 0x00000004,

			/// <summary>
			/// Set to indicate that the buffer is a stream buffer.
			/// </summary>
			IsStream = 0x00000008
		}

		/* MIDI data block header */
		[StructLayout(LayoutKind.Sequential, Pack=1)]
		public struct MIDIHDR 
		{
			/// <summary>pointer to locked data block</summary>
			public IntPtr  lpData;               
			/// <summary>length of data in data block</summary>
			public uint    dwBufferLength;       
			/// <summary>used for input only</summary>
			public uint    dwBytesRecorded;      
			/// <summary>for client's use</summary>
			public IntPtr  dwUser;               
			/// <summary>assorted flags (see defines)</summary>
			public MidiHeaderFlags flags;              
			/// <summary>reserved for driver</summary>
			private IntPtr lpNext;               
			/// <summary>reserved for driver</summary>
			private IntPtr reserved;             
			/// <summary>Callback offset into buffer</summary>
			public uint    dwOffset;             
			/// <summary>Reserved for MMSYSTEM</summary>
			private IntPtr dwReserved1;
			/// <summary>Reserved for MMSYSTEM</summary>
			private IntPtr dwReserved2;
			/// <summary>Reserved for MMSYSTEM</summary>
			private IntPtr dwReserved3;
			/// <summary>Reserved for MMSYSTEM</summary>
			private IntPtr dwReserved4;
			/// <summary>Reserved for MMSYSTEM</summary>
			private IntPtr dwReserved5;
			/// <summary>Reserved for MMSYSTEM</summary>
			private IntPtr dwReserved6;
			/// <summary>Reserved for MMSYSTEM</summary>
			private IntPtr dwReserved7;
			/// <summary>Reserved for MMSYSTEM</summary>
			private IntPtr dwReserved8;
		}
		public const int SIZEOF_MIDIHDR = 64;

		[StructLayout(LayoutKind.Sequential, Pack=1)]
		public struct MIDIEVENT
		{
			/// <summary>Ticks since last event</summary>
			public uint dwDeltaTime;          
			/// <summary>Reserved; must be zero</summary>
			public uint dwStreamID;           
			/// <summary>Event type and parameters</summary>
			public uint dwEvent;              
			/// <summary>Parameters if this is a long event</summary>
			public uint dwParms;           
		}

		[StructLayout(LayoutKind.Sequential, Pack=1)]
		public struct MIDISTRMBUFFVER 
		{
			/// <summary>Stream buffer format version</summary>
			public uint dwVersion;                  
			/// <summary>Manufacturer ID as defined in MMREG.H</summary>
			public uint dwMid;                      
			/// <summary>Manufacturer version for custom ext</summary>
			public uint dwOEMVersion;               
		}

		/* flags for dwFlags field of MIDIHDR structure */
		public const uint MHDR_DONE       = 0x00000001;       /* done bit */
		public const uint MHDR_PREPARED   = 0x00000002;       /* set if header prepared */
		public const uint MHDR_INQUEUE    = 0x00000004;       /* reserved for driver */
		public const uint MHDR_ISSTRM     = 0x00000008;       /* Buffer is stream buffer */
		/* */
		/* Type codes which go in the high byte of the event uint of a stream buffer */
		/* */
		/* Type codes 00-7F contain parameters within the low 24 bits */
		/* Type codes 80-FF contain a length of their parameter in the low 24 */
		/* bits, followed by their parameter data in the buffer. The event */
		/* uint contains the exact byte length; the parm data itself must be */
		/* padded to be an even multiple of 4 bytes long. */
		/* */

		public const uint MEVT_F_SHORT        = 0x00000000;
		public const uint MEVT_F_LONG         = 0x80000000;
		public const uint MEVT_F_CALLBACK     = 0x40000000;

		public byte MEVT_EVENTTYPE(uint x) 
		{
			return (byte)((x >> 24) & 0xFF);
		}

		public uint MEVT_EVENTPARM(uint x) 
		{
			return x & 0x00FFFFFF;
		}

		public const byte MEVT_SHORTMSG       = 0x00;    /* parm = shortmsg for midiOutShortMsg */
		public const byte MEVT_TEMPO          = 0x01;    /* parm = new tempo in microsec/qn     */
		public const byte MEVT_NOP            = 0x02;    /* parm = unused; does nothing         */

		/* 0x04-0x7F reserved */

		public const byte MEVT_LONGMSG        = 0x80;    /* parm = bytes to send verbatim       */
		public const byte MEVT_COMMENT        = 0x82;    /* parm = comment data                 */
		public const byte MEVT_VERSION        = 0x84;    /* parm = MIDISTRMBUFFVER struct       */

		/* 0x81-0xFF reserved */

		public const int MIDISTRM_ERROR      = -2;

		/* */
		/* Structures and defines for midiStreamProperty */
		/* */
		public const uint MIDIPROP_SET        = 0x80000000;
		public const uint MIDIPROP_GET        = 0x40000000;

		/* These are intentionally both non-zero so the app cannot accidentally */
		/* leave the operation off and happen to appear to work due to default */
		/* action. */

		public const uint MIDIPROP_TIMEDIV    = 0x00000001;
		public const uint MIDIPROP_TEMPO      = 0x00000002;

		[StructLayout(LayoutKind.Sequential, Pack=1)]
		public struct MIDIPROPTIMEDIV 
		{
			public uint cbStruct;
			public uint dwTimeDiv;
		}

		[StructLayout(LayoutKind.Sequential, Pack=1)]
		public struct MIDIPROPTEMPO 
		{
			public uint cbStruct;
			public uint dwTempo;
		}

		[StructLayout(LayoutKind.Explicit, Pack=1)]
		public struct MMTIME 
		{
			/// <summary>indicates the contents of the union</summary>
			[FieldOffset(0)] public uint wType;

			/// <summary>milliseconds</summary>
			[FieldOffset(4)] public uint milliseconds;         
			/// <summary>samples</summary>
			[FieldOffset(4)] public uint samples;     
			/// <summary>byte count</summary>
			[FieldOffset(4)] public uint byteCount;         
			/// <summary>ticks in MIDI stream</summary>
			[FieldOffset(4)] public uint midiTicks;      
			/// <summary>MIDI song pointer position</summary>
			[FieldOffset(4)] public uint midiSongPtrPos; 
			/// <summary>SMPTE</summary>
			[FieldOffset(4)] public SMPTE smpte;

			#region Nested Types
			[StructLayout(LayoutKind.Sequential, Pack=1)]
			public struct SMPTE 
			{
				/// <summary>hours</summary>
				public byte	hour;       
				/// <summary>minutes</summary>
				public byte	min;        
				/// <summary>seconds</summary>
				public byte	sec;        
				/// <summary>frames </summary>
				public byte	frame;      
				/// <summary>frames per second</summary>
				public byte	fps;        
				/// <summary>pad byte</summary>
				private byte pad1;      
				/// <summary>pad byte</summary>
				private byte pad2;      
				/// <summary>pad byte</summary>
				private byte pad3;      
			}
			#endregion
		}


		/* types for wType field in MMTIME struct */
		public const int TIME_MS      = 0x0001;  /* time in milliseconds */
		public const int TIME_SAMPLES = 0x0002;  /* number of wave samples */
		public const int TIME_BYTES   = 0x0004;  /* current byte offset */
		public const int TIME_SMPTE   = 0x0008;  /* SMPTE time */
		public const int TIME_MIDI    = 0x0010;  /* MIDI time */
		public const int TIME_TICKS   = 0x0020;  /* Ticks within MIDI stream */

		#region MIDI function prototypes

		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutGetNumDevs();
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiStreamOpen( [Out] out IntPtr phms, [In] UIntPtr puDeviceID, [In] uint cMidi, [In] IntPtr dwCallback, [In] IntPtr dwInstance, [In] uint fdwOpen);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiStreamClose( [In] IntPtr hms);

		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiStreamProperty( [In] IntPtr hms, [In, Out] byte[] lppropdata, [In] uint dwProperty);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiStreamPosition( [In] IntPtr hms, [Out] out MMTIME lpmmt, [In] uint cbmmt);

		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiStreamOut( [In] IntPtr hms, [In] MIDIHDR pmh, [In] uint cbmh);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiStreamPause( [In] IntPtr hms);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiStreamRestart( [In] IntPtr hms);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiStreamStop( [In] IntPtr hms);

		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiConnect( [In] IntPtr hmi, [In] IntPtr hmo, [In] IntPtr pReserved);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiDisconnect( [In] IntPtr hmi, [In] IntPtr hmo, [In] IntPtr pReserved);

		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi, CharSet=CharSet.Auto)]
		public static extern uint midiOutGetDevCaps( [In] UIntPtr uDeviceID, [Out] out MIDIOUTCAPS pmoc, [In] uint cbmoc);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi, CharSet=CharSet.Auto)]
		public static extern uint midiOutGetDevCaps( [In] UIntPtr uDeviceID, [Out] out MIDIOUTCAPS2 pmoc, [In] uint cbmoc);


		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutGetVolume( [In] IntPtr hmo, [Out] out uint pdwVolume);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutSetVolume( [In] IntPtr hmo, [In] uint dwVolume);

		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi, CharSet=CharSet.Auto)]
		public static extern uint midiOutGetErrorText( [In] uint mmrError, StringBuilder text, [In] int cchText);

		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutOpen( [Out] out IntPtr phmo, [In] uint uDeviceID,
			[In] MidiOutProc callback, [In] IntPtr dwInstance, [In] uint fdwOpen);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutClose( [In] IntPtr hmo);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutPrepareHeader( [In] IntPtr hmo, [In] IntPtr pmh, [In] uint cbmh);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutUnprepareHeader([In] IntPtr hmo, [In] IntPtr pmh, [In] uint cbmh);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutShortMsg( [In] IntPtr hmo, [In] uint dwMsg);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutLongMsg([In] IntPtr hmo, [In] IntPtr pmh, [In] uint cbmh);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutReset( [In] IntPtr hmo);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutCachePatches( [In] IntPtr hmo, [In] uint uBank, [Out] out ushort pwpa, [In] MidiCache cacheFlags);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutCacheDrumPatches( [In] IntPtr hmo, [In] uint uPatch, [Out] out ushort pwkya, [In] MidiCache cacheFlags);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutGetID( [In] IntPtr hmo, [Out] out uint puDeviceID);

		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiOutMessage( [In] IntPtr hmo, [In] uint uMsg, [In] IntPtr dw1, [In] IntPtr dw2);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiInGetNumDevs();

		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi, CharSet=CharSet.Auto)]
		public static extern uint midiInGetDevCaps( [In] UIntPtr uDeviceID, [Out] out MIDIINCAPS pmic, [In] uint cbmic);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi, CharSet=CharSet.Auto)]
		public static extern uint midiInGetDevCaps( [In] UIntPtr uDeviceID, [Out] out MIDIINCAPS2 pmic, [In] uint cbmic);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi, CharSet=CharSet.Auto)]
		public static extern uint midiInGetErrorText( [In] uint mmrError, StringBuilder text, [In] int cchText);

		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiInOpen( [Out] out IntPtr phmi, [In] uint uDeviceID,
			[In] MidiInProc callback, [In] IntPtr dwInstance, [In] uint fdwOpen);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiInClose( [In] IntPtr hmi);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiInPrepareHeader( [In] IntPtr hmi, [In] IntPtr pmh, [In] uint cbmh);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiInUnprepareHeader( [In] IntPtr hmi, [In] IntPtr pmh, [In] uint cbmh);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiInAddBuffer( [In] IntPtr hmi, [In] IntPtr pmh, [In] uint cbmh);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiInStart( [In] IntPtr hmi);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiInStop( [In] IntPtr hmi);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiInReset( [In] IntPtr hmi);
		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiInGetID( [In] IntPtr hmi, [Out] out uint puDeviceID);

		[DllImport("winmm.dll", CallingConvention=CallingConvention.Winapi)]
		public static extern uint midiInMessage( [In] IntPtr hmi, [In] uint uMsg, [In] IntPtr dw1, [In] IntPtr dw2);
		#endregion

	}
}


