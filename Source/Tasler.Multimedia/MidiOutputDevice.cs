using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

using Tasler.Threading;

namespace Tasler.Multimedia 
{
	public class MidiOutputDevice : IDisposable, IComparable 
	{
		#region Constants
		private const int BufferCount = 4;
		private const int BufferSize = 128;
		#endregion


		#region Instance Fields
		private IntPtr handle = IntPtr.Zero;
		private uint uDeviceID;
		private WindowsMidi.MIDIOUTCAPS2 moc;
//		private MidiOutputChannel[] channels = new MidiOutputChannel[16];
		private MidiOutProc midiOutProc;
		#endregion

		#region Construction/Disposal
		internal MidiOutputDevice(uint uDeviceID, WindowsMidi.MIDIOUTCAPS2 moc) 
		{
			// Save the specified device information
			this.uDeviceID = uDeviceID;
			this.moc = moc;

//			// Create the channels array
//			for (int i = 0; i < this.channels.Length; ++i)
//			{
//				channels[i] = new MidiOutputChannel(this, (byte)i);
//			}

			// Create the callback delegate
			this.midiOutProc = new MidiOutProc(this.ProcessDeviceMessage);
		}

		public void Dispose() 
		{
//			Close();
		}
		#endregion

		#region Properties
		/// <summary>Manufacturer ID</summary>
		public ushort ManufacturerId {get { return this.moc.wMid; } }
		/// <summary>Product ID</summary>
		public ushort ProductId      {get { return this.moc.wPid; } }
		/// <summary>Version of the driver</summary>
		public uint DriverVersion    {get { return this.moc.vDriverVersion; } }
		/// <summary>Product name</summary>
		public string ProductName    {get { return this.moc.productName; } }

		/// <summary>Type of device</summary>
		public ushort Technology     {get { return this.moc.wTechnology; } }

		/// <summary>Number of voices (internal synthesizer only).</summary>
		public ushort VoiceCount     {get { return this.moc.wVoices; } }
		/// <summary>Number of notes (internal synthesizer only).</summary>
		public ushort NoteCount      {get { return this.moc.wNotes; } }
		/// <summary>Channels used (internal synthesizer only).</summary>
		public ushort ChannelMask    {get { return this.moc.wChannelMask; } }
		
		/// <summary>Functionality supported by driver.</summary>
		public uint Support          {get { return this.moc.dwSupport; } }
		/// <summary>For extensible Manufacturer ID mapping</summary>
		public Guid ManufacturerGuid {get { return this.moc.ManufacturerGuid; } }
		/// <summary>For extensible Product ID mapping</summary>
		public Guid ProductGuid      {get { return this.moc.ProductGuid; } }
		/// <summary>For name lookup in registry</summary>
		public Guid NameGuid         {get { return this.moc.NameGuid; } }

		/// <summary>Indicates whether or not the device is open.</summary>
		public bool IsOpen 
		{
			get { return this.handle != IntPtr.Zero; }
		}

//		/// <summary>
//		/// Retrieves a collection of MIDI ports for the MIDI output device.
//		/// </summary>
//		public MidiOutputChannel[] Channels 
//		{
//			get { return this.channels.Clone() as MidiOutputChannel[]; }
//		}
		#endregion

		#region Methods
		/// <summary>
		/// Opens the MIDI output device. All properties and methods (excluding IsOpen)
		/// will fail when the device is not open. This method does nothing if the
		/// device is already open.
		/// </summary>
		public void Open() 
		{
			if (!this.IsOpen)
			{
				// Open the device
				uint result = WindowsMidi.midiOutOpen(out this.handle, this.uDeviceID,
					this.midiOutProc, IntPtr.Zero, WindowsMidi.CALLBACK_FUNCTION);
				WindowsMidi.TranslateMidiOutResult(result);
			}
		}

		/// <summary>
		/// Closes the MIDI output devive. This method does nothing if the device is already closed.
		/// </summary>
		public void Close() 
		{
			if (this.IsOpen)
			{
				// Close the device
				uint result = WindowsMidi.midiOutClose(this.handle);
				WindowsMidi.TranslateMidiOutResult(result);
			}
		}

		/// <summary>
		/// Turns off all notes on all MIDI channels of the MIDI output device.
		/// </summary>
		public void Reset() 
		{
			if (this.IsOpen)
			{
				uint result = WindowsMidi.midiOutReset(this.handle);
				WindowsMidi.TranslateMidiOutResult(result);
			}
		}
		
		
		public void SendShortMessage(byte status) 
		{
			this.SendShortMessage(status, 0);
		}

		public void SendShortMessage(byte status, byte data1) 
		{
			this.SendShortMessage(status, data1, 0);
		}

		public void SendShortMessage(byte status, byte data1, byte data2) 
		{
			// Pack the specified parameters into a uint
			uint dwMsg = 0;
			dwMsg |= status;
			dwMsg |= (uint)data1 << 8;
			dwMsg |= (uint)data2 << 16;

			// Send the message
			uint result = WindowsMidi.midiOutShortMsg(this.handle, dwMsg);
			WindowsMidi.TranslateMidiOutResult(result);
		}

		public void SendLongData(byte[] data) 
		{
			if (this.IsOpen)
			{
				// Create the buffer in unmanaged memory
				IntPtr buffer = Marshal.AllocHGlobal(data.Length);

				// Copy the array to the HGLOBAL
				Marshal.Copy(data, 0, buffer, data.Length);

				// Access the header for the buffer in managed memory
				WindowsMidi.MIDIHDR header = new WindowsMidi.MIDIHDR();
				header.lpData         = buffer;
				header.dwBufferLength = (uint)data.Length;

				// Copy the header to unmanaged memory
				IntPtr headerMem = Marshal.AllocHGlobal(WindowsMidi.SIZEOF_MIDIHDR);
				Marshal.StructureToPtr(header, headerMem, false);

				// Prepare the buffer for the device
				uint result = WindowsMidi.midiOutPrepareHeader(
					this.handle, headerMem, WindowsMidi.SIZEOF_MIDIHDR);
				WindowsMidi.TranslateMidiOutResult(result);

				// Send the data
				result = WindowsMidi.midiOutLongMsg(this.handle, headerMem, WindowsMidi.SIZEOF_MIDIHDR);
				WindowsMidi.TranslateMidiOutResult(result);
			}
		}
		#endregion

		#region Events
		public event MidiOpenCloseEventHandler Opened;
		public event MidiOpenCloseEventHandler Closed;
		#endregion

		#region Event Raising Methods
		protected virtual void OnOpened(EventArgs args) 
		{
			DelegateInvoker.Invoke(this.Opened, this, args);
		}
		protected virtual void OnClosed(EventArgs args) 
		{
			DelegateInvoker.Invoke(this.Closed, this, args);
		}
		#endregion

		#region Event Raising Method Thread Thunks
		private void FireOpened(object state) 
		{
			EventArgs args = (EventArgs)state;
			this.OnOpened(args);
		}

		private void FireClosed(object state) 
		{
			EventArgs args = (EventArgs)state;
			this.OnClosed(args);
		}
		#endregion

		#region Implementation Members
		private void ProcessDeviceMessage(IntPtr hMidiOut, uint wMsg, IntPtr dwInstance,
			IntPtr dwParam1, UIntPtr dwParam2) 
		{
			switch (wMsg)
			{
				case WindowsMidi.MOM_OPEN:
				{
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.FireOpened),
						EventArgs.Empty);
					return;
				}
				case WindowsMidi.MOM_CLOSE:
				{
					this.handle = IntPtr.Zero;
					ThreadPool.QueueUserWorkItem(new WaitCallback(this.FireClosed),
						EventArgs.Empty);
					return;
				}
				case WindowsMidi.MOM_DONE:
				{
					// Marshal dwParam1 as a MIDIHDR structure
					WindowsMidi.MIDIHDR midiHeader = (WindowsMidi.MIDIHDR)
						Marshal.PtrToStructure(dwParam1, typeof(WindowsMidi.MIDIHDR));

					// Unprepare the header
					uint result = WindowsMidi.midiOutUnprepareHeader(
						this.handle, dwParam1, WindowsMidi.SIZEOF_MIDIHDR);

					// Free the buffer
					Marshal.FreeHGlobal(midiHeader.lpData);

					// Free the header
					Marshal.FreeHGlobal(dwParam1);
					WindowsMidi.TranslateMidiOutResult(result);
					return;
				}

				default:
				{
					// TODO: Assert? throw? both?
					string message = string.Format("Unknown MIDI output message received: 0x{0:x}", wMsg);
					Debug.Fail(message);

					// TODO: Define a custom exception?
					throw new ApplicationException(message);
				}
			}
		}

		#endregion

		#region IComparable Members
		public int CompareTo(object obj) 
		{
			MidiOutputDevice that = obj as MidiOutputDevice;
			if (that == null)
			{
				return 1;
			}

			int diff = this.ManufacturerId - that.ManufacturerId;
			if (diff != 0)
				return diff;
			diff = this.ProductId - that.ProductId;
			if (diff != 0)
				return diff;
			return string.Compare(this.ProductName, that.ProductName, true);
		}
		#endregion
	}

	public enum MidiOutputDeviceTechnology : ushort 
	{
		/// <summary>Output port.</summary>
		OutputPort = WindowsMidi.MOD_MIDIPORT,
		/// <summary>Generic internal synthesizer.</summary>
		Synth = WindowsMidi.MOD_SYNTH,
		/// <summary>Square wave internal synthesizer.</summary>
		SquareWaveSynth = WindowsMidi.MOD_SQSYNTH,
		/// <summary>FM internal synthesizer.</summary>
		FmSynth = WindowsMidi.MOD_FMSYNTH, 
		/// <summary>MIDI Mapper</summary>
		Mapper = WindowsMidi.MOD_MAPPER,
		/// <summary>Hardware wavetable synthesizer.</summary>
		WaveTable = WindowsMidi.MOD_WAVETABLE,
		/// <summary>Sofware synthesizer.</summary>
		SoftwareSynth = WindowsMidi.MOD_SWSYNTH,
	}

	[Flags]
	public enum MidiOutputDeviceSupport : uint 
	{
		/// <summary>Supports volume control.</summary>
		Volume = WindowsMidi.MIDICAPS_VOLUME,
		/// <summary>Supports separate left and right volume controls.</summary>
		LeftRightVolume = WindowsMidi.MIDICAPS_LRVOLUME,
		/// <summary>Supports patch caching.</summary>
		Cache = WindowsMidi.MIDICAPS_CACHE,
		/// <summary>Driver supports midiStreamOut directly</summary>
		Stream = WindowsMidi.MIDICAPS_STREAM,
	}

}