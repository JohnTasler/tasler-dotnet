using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Tasler.Multimedia
{
	#region Enumerations
	/// <summary>
	/// Represents the name and number of each MIDI note.
	/// </summary>
	public enum MidiNote : sbyte
	{
		[Description(  "C0")]       C0 =   0,
		[Description( "C#0")]  CSharp0 =   1,
		[Description(  "D0")]       D0 =   2,
		[Description( "D#0")]  DSharp0 =   3,
		[Description(  "E0")]       E0 =   4,
		[Description(  "F0")]       F0 =   5,
		[Description( "F#0")]  FSharp0 =   6,
		[Description(  "G0")]       G0 =   7,
		[Description( "G#0")]  GSharp0 =   8,
		[Description(  "A1")]       A1 =   9,
		[Description( "A#1")]  ASharp1 =  10,
		[Description(  "B1")]       B1 =  11,
		[Description(  "C1")]       C1 =  12,
		[Description( "C#1")]  CSharp1 =  13,
		[Description(  "D1")]       D1 =  14,
		[Description( "D#1")]  DSharp1 =  15,
		[Description(  "E1")]       E1 =  16,
		[Description(  "F1")]       F1 =  17,
		[Description( "F#1")]  FSharp1 =  18,
		[Description(  "G1")]       G1 =  19,
		[Description( "G#1")]  GSharp1 =  20,
		[Description(  "A2")]       A2 =  21,
		[Description( "A#2")]  ASharp2 =  22,
		[Description(  "B2")]       B2 =  23,
		[Description(  "C2")]       C2 =  24,
		[Description( "C#2")]  CSharp2 =  25,
		[Description(  "D2")]       D2 =  26,
		[Description( "D#2")]  DSharp2 =  27,
		[Description(  "E2")]       E2 =  28,
		[Description(  "F2")]       F2 =  29,
		[Description( "F#2")]  FSharp2 =  30,
		[Description(  "G2")]       G2 =  31,
		[Description( "G#2")]  GSharp2 =  32,
		[Description(  "A3")]       A3 =  33,
		[Description( "A#3")]  ASharp3 =  34,
		[Description(  "B3")]       B3 =  35,
		[Description(  "C3")]       C3 =  36,
		[Description( "C#3")]  CSharp3 =  37,
		[Description(  "D3")]       D3 =  38,
		[Description( "D#3")]  DSharp3 =  39,
		[Description(  "E3")]       E3 =  40,
		[Description(  "F3")]       F3 =  41,
		[Description( "F#3")]  FSharp3 =  42,
		[Description(  "G3")]       G3 =  43,
		[Description( "G#3")]  GSharp3 =  44,
		[Description(  "A4")]       A4 =  45,
		[Description( "A#4")]  ASharp4 =  46,
		[Description(  "B4")]       B4 =  47,
		[Description(  "C4")]       C4 =  48,
		[Description( "C#4")]  CSharp4 =  49,
		[Description(  "D4")]       D4 =  50,
		[Description( "D#4")]  DSharp4 =  51,
		[Description(  "E4")]       E4 =  52,
		[Description(  "F4")]       F4 =  53,
		[Description( "F#4")]  FSharp4 =  54,
		[Description(  "G4")]       G4 =  55,
		[Description( "G#4")]  GSharp4 =  56,
		[Description(  "A5")]       A5 =  57,
		[Description( "A#5")]  ASharp5 =  58,
		[Description(  "B5")]       B5 =  59,
		[Description(  "C5")]       C5 =  60,
		[Description( "C#5")]  CSharp5 =  61,
		[Description(  "D5")]       D5 =  62,
		[Description( "D#5")]  DSharp5 =  63,
		[Description(  "E5")]       E5 =  64,
		[Description(  "F5")]       F5 =  65,
		[Description( "F#5")]  FSharp5 =  66,
		[Description(  "G5")]       G5 =  67,
		[Description( "G#5")]  GSharp5 =  68,
		[Description(  "A6")]       A6 =  69,
		[Description( "A#6")]  ASharp6 =  70,
		[Description(  "B6")]       B6 =  71,
		[Description(  "C6")]       C6 =  72,
		[Description( "C#6")]  CSharp6 =  73,
		[Description(  "D6")]       D6 =  74,
		[Description( "D#6")]  DSharp6 =  75,
		[Description(  "E6")]       E6 =  76,
		[Description(  "F6")]       F6 =  77,
		[Description( "F#6")]  FSharp6 =  78,
		[Description(  "G6")]       G6 =  79,
		[Description( "G#6")]  GSharp6 =  80,
		[Description(  "A7")]       A7 =  81,
		[Description( "A#7")]  ASharp7 =  82,
		[Description(  "B7")]       B7 =  83,
		[Description(  "C7")]       C7 =  84,
		[Description( "C#7")]  CSharp7 =  85,
		[Description(  "D7")]       D7 =  86,
		[Description( "D#7")]  DSharp7 =  87,
		[Description(  "E7")]       E7 =  88,
		[Description(  "F7")]       F7 =  89,
		[Description( "F#7")]  FSharp7 =  90,
		[Description(  "G7")]       G7 =  91,
		[Description( "G#7")]  GSharp7 =  92,
		[Description(  "A8")]       A8 =  93,
		[Description( "A#8")]  ASharp8 =  94,
		[Description(  "B8")]       B8 =  95,
		[Description(  "C8")]       C8 =  96,
		[Description( "C#8")]  CSharp8 =  97,
		[Description(  "D8")]       D8 =  98,
		[Description( "D#8")]  DSharp8 =  99,
		[Description(  "E8")]       E8 = 100,
		[Description(  "F8")]       F8 = 101,
		[Description( "F#8")]  FSharp8 = 102,
		[Description(  "G8")]       G8 = 103,
		[Description( "G#8")]  GSharp8 = 104,
		[Description(  "A9")]       A9 = 105,
		[Description( "A#9")]  ASharp9 = 106,
		[Description(  "B9")]       B9 = 107,
		[Description(  "C9")]       C9 = 108,
		[Description( "C#9")]  CSharp9 = 109,
		[Description(  "D9")]       D9 = 110,
		[Description( "D#9")]  DSharp9 = 111,
		[Description(  "E9")]       E9 = 112,
		[Description(  "F9")]       F9 = 113,
		[Description( "F#9")]  FSharp9 = 114,
		[Description(  "G9")]       G9 = 115,
		[Description( "G#9")]  GSharp9 = 116,
		[Description( "A10")]      A10 = 117,
		[Description("A#10")] ASharp10 = 118,
		[Description( "B10")]      B10 = 119,
		[Description( "C10")]      C10 = 120,
		[Description("C#10")] CSharp10 = 121,
		[Description( "D10")]      D10 = 122,
		[Description("D#10")] DSharp10 = 123,
		[Description( "E10")]      E10 = 124,
		[Description( "F10")]      F10 = 125,
		[Description("F#10")] FSharp10 = 126,
		[Description( "G10")]      G10 = 127,
	}


	/// <summary>
	/// MIDI output device technology type constants.
	/// </summary>
	[Guid("27270FAC-EE1F-4311-8AF3-460D48EA527D")]
	public enum MidiOutType
	{
		/// <summary>The device is a MIDI hardware port.</summary>
		MidiPort        = 1,

		/// <summary>The device is a synthesizer.</summary>
		Synth           = 2,

		/// <summary>The device is a square wave synthesizer.</summary>
		SquareWaveSynth = 3,

		/// <summary>The device is an FM synthesizer.</summary>
		FMSynth         = 4,

		/// <summary>The device is the Microsoft MIDI mapper.</summary>
		Mapper          = 5,

		/// <summary>The device is a hardware wavetable synthesizer.</summary>
		WaveTable       = 6,

		/// <summary>The device is a software synthesizer.</summary>
		SoftwareSynth   = 7,
	}


	/// <summary>
	/// MIDI output device option constants.
	/// </summary>
	[Guid("05053475-EF65-4db0-A07A-E8118D3EFE1B")]
	[Flags]
	public enum MidiOutOption
	{
		/// <summary>Supports volume control.</summary>
		Volume   = 0x0001,

		/// <summary>Supports separate left and right volume control.</summary>
		LRVolume = 0x0002,

		/// <summary>Supports patch caching.</summary>
		Cache    = 0x0004,

		/// <summary>Provides direct support for streaming.</summary>
		Stream   = 0x0008,
	}


	/// <summary>
	/// MIDI subscription type constants.
	/// </summary>
	[Guid("B92D0C06-16B1-4448-B0F6-933D661CE391")]
	public enum MidiSubscriptionType
	{
		/// <summary>Subscription is for system messages.</summary>
		Device,

		/// <summary>Subscription is for events on a particular channel (or Omni).</summary>
		Channel,
	}


	/// <summary>
	/// MIDI subscription event constants.
	/// </summary>
	[Guid("7506DE79-E93D-4082-BE08-169054BDFE34")]
	public enum MidiSubscriptionEvent
	{
		NoteOff              = 0x80,
		NoteOn               = 0x90,
		KeyAftertouch        = 0xA0,
		ControlChange        = 0xB0,
		ProgramChange        = 0xC0,
		ChannelAftertouch    = 0xD0,
		PitchBend            = 0xE0,
		SystemExclusiveBegin = 0xF0,
		MTCQuarterFrame      = 0xF1,
		SongPositionPointer  = 0xF2,
		SongSelect           = 0xF3,
		TuneRequest          = 0xF6,
		SystemExclusiveEnd   = 0xF7,
		TimingClock          = 0xF8,
		Start                = 0xFA,
		Continue             = 0xFB,
		Stop                 = 0xFC,
		ActiveSensing        = 0xFE,
		SystemReset          = 0xFF,
		AllEvents          = 0xFF00,
		AllSystemMessages  = 0xFFFF,
	}
	#endregion

	public class MidiManager
	{
		#region Static Fields
		private static MidiInputDevice[] inputDevices;
		private static MidiOutputDevice[] outputDevices;
		#endregion

		/// <summary>
		/// Retrieves the collection of MIDI input devices installed on the system.
		/// </summary>
		/// <returns>A collection of type <seealso cref="MidiInputDevices"/>.</returns>
		public static MidiInputDevice[] InputDevices
		{
			get
			{
				if (MidiManager.inputDevices == null)
				{
					uint deviceCount = WindowsMidi.midiInGetNumDevs();
					MidiManager.inputDevices = new MidiInputDevice[deviceCount];
					for (uint i = 0; i < deviceCount; ++i)
					{
						WindowsMidi.MIDIINCAPS2 mic = new Tasler.Multimedia.WindowsMidi.MIDIINCAPS2();
						WindowsMidi.midiInGetDevCaps(new UIntPtr(i), out mic, WindowsMidi.SIZEOF_MIDIINCAPS2);
						MidiManager.inputDevices[i] = new MidiInputDevice(i, mic);
					}
				}
				return (MidiInputDevice[])MidiManager.inputDevices.Clone();
			}
		}

		/// <summary>
		/// Retrieves the collection of MIDI output devices installed on the system.
		/// </summary>
		/// <returns>A collection of type <see cref="MidiOutputDevices"/>.</returns>
		public static MidiOutputDevice[] OutputDevices
		{
			get
			{
				if (MidiManager.outputDevices == null)
				{
					uint deviceCount = WindowsMidi.midiOutGetNumDevs();
					MidiManager.outputDevices = new MidiOutputDevice[deviceCount];
					for (uint i = 0; i < deviceCount; ++i)
					{
						WindowsMidi.MIDIOUTCAPS2 moc = new Tasler.Multimedia.WindowsMidi.MIDIOUTCAPS2();
						WindowsMidi.midiOutGetDevCaps(new UIntPtr(i), out moc, WindowsMidi.SIZEOF_MIDIOUTCAPS2);
						MidiManager.outputDevices[i] = new MidiOutputDevice(i, moc);
					}
				}
				return (MidiOutputDevice[])MidiManager.outputDevices.Clone();
			}
		}

		/// <summary>
		/// Converts the specified note name to the corresponding MIDI note number.
		/// </summary>
		/// <param name="noteName"></param>
		/// <returns>
		/// The MIDI note number corresponding to the note name specified</returns>
		/// <remarks>For example, 'G#3' would be converted to 44.</remarks>
		public static sbyte NoteNumberFromName(string noteName)
		{
			// Remove all whitespace
			Regex reWhitespace = new Regex(@"\s");
			noteName = reWhitespace.Replace(noteName, string.Empty);

			// Convert 'sharp' (spelled-out) to '#' (pound sign)
			Regex reSharp = new Regex("sharp", RegexOptions.IgnoreCase);
			noteName = reSharp.Replace(noteName, "#");

			// Return the matching enumeration value
			return (sbyte)Enum.Parse(typeof(MidiNote), noteName, true);
		}

		/// <summary>
		/// Converts the specified MIDI note number to a corresponding name.
		/// </summary>
		/// <param name="noteNumber">The MIDI note number to be converted.</param>
		/// <returns>
		/// A human-readable string that corresponds to the specified note number.
		/// </returns>
		/// <remarks>
		/// Note that accidentals (flats and sharps) are always represented
		/// as the 'sharp' equivalent. For example, 27 would be converted to D#2.
		/// </remarks>
		public static string NoteNameFromNumber(sbyte noteNumber)
		{
			// Use the enumeration for the conversion
			string noteName = Enum.GetName(typeof(MidiNote), noteNumber);

			// Convert 'sharp' (spelled-out) to '#' (pound sign)
			Regex reSharp = new Regex("sharp", RegexOptions.IgnoreCase);
			noteName = reSharp.Replace(noteName, "#");
			return noteName;
		}
	}

}