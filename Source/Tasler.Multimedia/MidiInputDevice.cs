using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

using Tasler.Threading;

namespace Tasler.Multimedia
{
	public class MidiInputDevice : IDisposable, IComparable
	{
		#region Constants
		private const int BufferCount = 4;
		private const int BufferSize = 128;
		#endregion

		#region Instance Fields
		private uint uDeviceID;
		private int inResetCount = 0;
		private IntPtr handle = IntPtr.Zero;
		private WindowsMidi.MIDIINCAPS2 mic;
		private MidiInputOmniChannel omniChannel;
		private MidiInputChannel[] channels = new MidiInputChannel[16];
		private MemoryStream currentStream;
		private MidiInProc midiInProc;
		#endregion

		#region Construction/Disposal
		internal MidiInputDevice(uint uDeviceID, WindowsMidi.MIDIINCAPS2 mic)
		{
			// Save the specified device information
			this.uDeviceID = uDeviceID;
			this.mic = mic;

			// Create the Omni channel
			this.omniChannel = new MidiInputOmniChannel(this);

			// Create the channels array
			for (int i = 0; i < this.channels.Length; ++i)
			{
				channels[i] = new MidiInputChannel(this, (byte)i);
			}

			// Create the callback delegate
			this.midiInProc = new MidiInProc(this.ProcessDeviceMessage);
		}

		public void Dispose()
		{
			Close();
		}
		#endregion

		#region Properties
		/// <summary>Manufacturer ID</summary>
		public ushort ManufacturerId {get { return this.mic.wMid; } }
		/// <summary>Product ID</summary>
		public ushort ProductId      {get { return this.mic.wPid; } }
		/// <summary>Version of the driver</summary>
		public uint DriverVersion    {get { return this.mic.vDriverVersion; } }
		/// <summary>Product name</summary>
		public string ProductName    {get { return this.mic.productName; } }
		/// <summary>Functionality supported by driver. Not used. Always zero.</summary>
		public uint Support          {get { return this.mic.dwSupport; } }
		/// <summary>For extensible Manufacturer ID mapping</summary>
		public Guid ManufacturerGuid {get { return this.mic.ManufacturerGuid; } }
		/// <summary>For extensible Product ID mapping</summary>
		public Guid ProductGuid      {get { return this.mic.ProductGuid; } }
		/// <summary>For name lookup in registry</summary>
		public Guid NameGuid         {get { return this.mic.NameGuid; } }

		/// <summary>Indicates whether or not the device is open.</summary>
		public bool IsOpen
		{
			get { return this.handle != IntPtr.Zero; }
		}

		/// <summary>
		/// Retrieves a collection of MIDI ports for the MIDI input device.
		/// </summary>
		public MidiInputChannel[] Channels
		{
			get { return this.channels.Clone() as MidiInputChannel[]; }
		}

		public MidiInputOmniChannel OmniChannel
		{
			get { return this.omniChannel; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Opens the MIDI input device. All properties and methods (excluding IsOpen)
		/// will fail when the device is not open. This method does nothing if the
		/// device is already open.
		/// </summary>
		public void Open()
		{
			if (!this.IsOpen)
			{
				// Open the device
				uint result = WindowsMidi.midiInOpen(out this.handle, this.uDeviceID,
					this.midiInProc, IntPtr.Zero,
					WindowsMidi.CALLBACK_FUNCTION | WindowsMidi.MIDI_IO_STATUS);
				WindowsMidi.TranslateMidiInResult(result);

				// Prepare and add system exclusive buffers
				for (int i = 0; i < BufferCount; ++i)
				{
					// Create the buffer in unmanaged memory
					IntPtr buffer = Marshal.AllocHGlobal(BufferSize);

					// Access the header for the buffer in managed memory
					WindowsMidi.MIDIHDR header = new WindowsMidi.MIDIHDR();
					header.lpData         = buffer;
					header.dwBufferLength = (uint)BufferSize;

					// Copy the header to unmanaged memory
					IntPtr headerMem = Marshal.AllocHGlobal(WindowsMidi.SIZEOF_MIDIHDR);
					Marshal.StructureToPtr(header, headerMem, false);

					// Prepare the buffer for the device
					result = WindowsMidi.midiInPrepareHeader(
						this.handle, headerMem, WindowsMidi.SIZEOF_MIDIHDR);
					WindowsMidi.TranslateMidiInResult(result);

					// Add the buffer to the device
					result = WindowsMidi.midiInAddBuffer(
						this.handle, headerMem, WindowsMidi.SIZEOF_MIDIHDR);
					WindowsMidi.TranslateMidiInResult(result);
				}
			}
		}

		/// <summary>
		/// Closes the MIDI input devive. This method does nothing if the device is already closed.
		/// </summary>
		public void Close()
		{
			if (this.IsOpen)
			{
				this.Stop();
				this.Reset();

				// Close the device
				uint result = WindowsMidi.midiInClose(this.handle);
				WindowsMidi.TranslateMidiInResult(result);
			}
		}

		/// <summary>
		/// Starts MIDI input on the MIDI input device.
		/// </summary>
		public void Start()
		{
			if (this.IsOpen)
			{
				uint result = WindowsMidi.midiInStart(this.handle);
				WindowsMidi.TranslateMidiInResult(result);
			}
		}

		/// <summary>
		/// Stops input on the MIDI input device.
		/// </summary>
		public void Reset()
		{
			if (this.IsOpen)
			{
				uint result = 0;
				++this.inResetCount;
				try
				{
					result = WindowsMidi.midiInReset(this.handle);
				}
				catch (Exception e)
				{
					Debug.WriteLine(e.ToString());
				}
				--this.inResetCount;
				WindowsMidi.TranslateMidiInResult(result);
			}
		}

		/// <summary>
		/// Stops input on the MIDI input device.
		/// </summary>
		public void Stop()
		{
			if (this.IsOpen)
			{
				uint result = WindowsMidi.midiInStop(this.handle);
				WindowsMidi.TranslateMidiInResult(result);
			}
		}
		#endregion

		#region Events
		public event MidiInputOpenCloseEventHandler Opened;
		public event MidiInputOpenCloseEventHandler Closed;

		public event MidiInputEventHandler DataReceived;
		public event MidiInputEventHandler MoreDataReceived;
		public event MidiInputEventHandler ErrorReceived;
		public event MidiInputLongEventHandler LongDataReceived;
		public event MidiInputLongEventHandler LongErrorReceived;
		public event MidiInputExceptionEventHandler ExceptionOccurred;

		public event MidiInputEventHandler SystemMessageReceived;
		public event MidiInputEventHandler SystemExclusiveBeginReceived;
		public event MidiInputEventHandler MTCQuarterFrameReceived;
		public event MidiInputEventHandler SongPositionPointerReceived;
		public event MidiInputEventHandler SongSelectReceived;
		public event MidiInputEventHandler TuneRequestReceived;
		public event MidiInputEventHandler SystemExclusiveEndReceived;
		public event MidiInputEventHandler TimingClockReceived;
		public event MidiInputEventHandler StartReceived;
		public event MidiInputEventHandler ContinueReceived;
		public event MidiInputEventHandler StopReceived;
		public event MidiInputEventHandler ActiveSensingReceived;
		public event MidiInputEventHandler SystemResetReceived;
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

		protected virtual void OnDataReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.DataReceived, this, args);
			this.ProcessChannelDataMessage(args);
		}
		protected virtual void OnMoreDataReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.MoreDataReceived, this, args);
		}
		protected virtual void OnErrorReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.ErrorReceived, this, args);
		}

		protected virtual void OnLongDataReceived(MidiInputLongEventArgs args)
		{
			DelegateInvoker.Invoke(this.LongDataReceived, this, args);
		}
		protected virtual void OnLongErrorReceived(MidiInputLongEventArgs args)
		{
			DelegateInvoker.Invoke(this.LongErrorReceived, this, args);
		}

		protected virtual void OnExceptionOccurred(MidiInputExceptionEventArgs args)
		{
			DelegateInvoker.Invoke(this.ExceptionOccurred, this, args);
		}

		protected virtual void OnSystemMessageReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.SystemMessageReceived, this, args);
		}
		protected virtual void OnSystemExclusiveBeginReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.SystemExclusiveBeginReceived, this, args);
		}
		protected virtual void OnMTCQuarterFrameReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.MTCQuarterFrameReceived, this, args);
		}
		protected virtual void OnSongPositionPointerReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.SongPositionPointerReceived, this, args);
		}
		protected virtual void OnSongSelectReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.SongSelectReceived, this, args);
		}
		protected virtual void OnTuneRequestReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.TuneRequestReceived, this, args);
		}
		protected virtual void OnSystemExclusiveEndReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.SystemExclusiveEndReceived, this, args);
		}
		protected virtual void OnTimingClockReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.TimingClockReceived, this, args);
		}
		protected virtual void OnStartReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.StartReceived, this, args);
		}
		protected virtual void OnContinueReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.ContinueReceived, this, args);
		}
		protected virtual void OnStopReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.StopReceived, this, args);
		}
		protected virtual void OnActiveSensingReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.ActiveSensingReceived, this, args);
		}
		protected virtual void OnSystemResetReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.SystemResetReceived, this, args);
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

		private void FireDataReceived(object state)
		{
			MidiInputEventArgs args = (MidiInputEventArgs)state;
			this.OnDataReceived(args);
		}

		private void FireMoreDataReceived(object state)
		{
			MidiInputEventArgs args = (MidiInputEventArgs)state;
			this.OnMoreDataReceived(args);
		}

		private void FireErrorReceived(object state)
		{
			MidiInputEventArgs args = (MidiInputEventArgs)state;
			this.OnErrorReceived(args);
		}

		private void FireLongDataReceived(object state)
		{
			MidiInputLongEventArgs args = (MidiInputLongEventArgs)state;
			using (args.LongData)
			{
				this.OnLongDataReceived(args);
			}
		}

		private void FireLongErrorReceived(object state)
		{
			MidiInputLongEventArgs args = (MidiInputLongEventArgs)state;
			using (args.LongData)
			{
				this.OnLongErrorReceived(args);
			}
		}

		private void FireExceptionOccurred(object state)
		{
			MidiInputExceptionEventArgs args = (MidiInputExceptionEventArgs)state;
			this.OnExceptionOccurred(args);
		}
		#endregion

		#region Callback Function
		private void ProcessDeviceMessage(IntPtr hMidiIn, uint wMsg, IntPtr dwInstance, IntPtr dwParam1, UIntPtr dwParam2)
		{
			try
			{
				switch (wMsg)
				{
					case WindowsMidi.MIM_OPEN:
					{
						ThreadPool.QueueUserWorkItem(new WaitCallback(this.FireOpened),
							EventArgs.Empty);
						return;
					}
					case WindowsMidi.MIM_CLOSE:
					{
						this.handle = IntPtr.Zero;
						ThreadPool.QueueUserWorkItem(new WaitCallback(this.FireClosed),
							EventArgs.Empty);
						return;
					}

					case WindowsMidi.MIM_DATA:
					{
						ThreadPool.QueueUserWorkItem(new WaitCallback(this.FireDataReceived),
							new MidiInputEventArgs(dwParam1, dwParam2));
						return;
					}
					case WindowsMidi.MIM_MOREDATA:
					{
						ThreadPool.QueueUserWorkItem(new WaitCallback(this.FireMoreDataReceived),
							new MidiInputEventArgs(dwParam1, dwParam2));
						return;
					}
					case WindowsMidi.MIM_ERROR:
					{
						ThreadPool.QueueUserWorkItem(new WaitCallback(this.FireErrorReceived),
							new MidiInputEventArgs(dwParam1, dwParam2));
						return;
					}

					case WindowsMidi.MIM_LONGERROR:
					case WindowsMidi.MIM_LONGDATA :
					{
						// Marshal dwParam1 as a MIDIHDR structure
						WindowsMidi.MIDIHDR midiHeader = (WindowsMidi.MIDIHDR)
							Marshal.PtrToStructure(dwParam1, typeof(WindowsMidi.MIDIHDR));

						// Copy buffer to current stream if it contains any data
						bool lastBufferOfSysEx = (wMsg == WindowsMidi.MIM_LONGERROR);
						if (midiHeader.dwBytesRecorded > 0)
						{
							// Create a stream if one is not already in progress
							if (this.currentStream == null)
							{
								this.currentStream = new MemoryStream();
							}

							// Append the new data into the stream
							this.currentStream.SetLength(this.currentStream.Length + (int)midiHeader.dwBytesRecorded);
							Marshal.Copy(midiHeader.lpData, this.currentStream.GetBuffer(),
								(int)this.currentStream.Position, (int)midiHeader.dwBytesRecorded);
							this.currentStream.Position += (int)midiHeader.dwBytesRecorded;

							// Check for being the last buffer of sysex message
							if (!lastBufferOfSysEx)
							{
								byte lastByte = this.currentStream.GetBuffer()[this.currentStream.Position - 1];
								lastBufferOfSysEx = (lastByte == (byte)MidiStatus.SystemExclusiveEnd);
							}
						}

						// Queue the stream for deferred processing
						if (this.currentStream != null && lastBufferOfSysEx)
						{
							MidiInputLongEventArgs args =
								new MidiInputLongEventArgs(this.currentStream, dwParam2);
							if (wMsg == WindowsMidi.MIM_LONGDATA)
							{
								ThreadPool.QueueUserWorkItem(new WaitCallback(this.FireLongDataReceived), args);
							}
							else
							{
								ThreadPool.QueueUserWorkItem(new WaitCallback(this.FireLongErrorReceived), args);
							}
							this.currentStream = null;
						}

						// Unless we're within a Reset method call, re-add the buffer
						if (this.inResetCount == 0)
						{
							uint result = WindowsMidi.midiInAddBuffer(
								this.handle, dwParam1, WindowsMidi.SIZEOF_MIDIHDR);
							WindowsMidi.TranslateMidiInResult(result);
						}
						else
						{
							// Unprepare the header
							uint result = WindowsMidi.midiInUnprepareHeader(
								this.handle, dwParam1, WindowsMidi.SIZEOF_MIDIHDR);
							WindowsMidi.TranslateMidiInResult(result);

							// Free the buffer
							Marshal.FreeHGlobal(midiHeader.lpData);

							// Free the header
							Marshal.FreeHGlobal(dwParam1);
						}
						return;
					}

					default:
					{
						// TODO: Define a custom exception?
						string message = string.Format("Unknown MIDI input message received: 0x{0:x}", wMsg);
						throw new ApplicationException(message);
					}
				}
			}
			catch (Exception e)
			{
				ThreadPool.QueueUserWorkItem(new WaitCallback(this.FireExceptionOccurred),
					new MidiInputExceptionEventArgs(wMsg, dwParam1, dwParam2, e));
			}
		}
		#endregion

		#region Implementation
		private void ProcessChannelDataMessage(MidiInputEventArgs args)
		{
			if (args.Status == (byte)MidiStatus.SystemMessage)
			{
				this.OnSystemMessageReceived(args);
				this.ProcessSystemMessage(args);
				return;
			}

			// Send to the omni channel for processing
			this.omniChannel.ProcessChannelData(args);

			// Send to the specific numbered channel for processing
			MidiInputChannel channel = this.channels[args.Channel];
			channel.ProcessChannelData(args);
		}

		private void ProcessSystemMessage(MidiInputEventArgs args)
		{
			switch ((MidiStatus)args.StatusRaw)
			{
				case MidiStatus.BeginSysex        : { this.OnSystemExclusiveBeginReceived(args); break; }
				case MidiStatus.MtcQuarterFrame   : { this.OnMTCQuarterFrameReceived     (args); break; }
				case MidiStatus.SongPosPtr        : { this.OnSongPositionPointerReceived (args); break; }
				case MidiStatus.SongSelect        : { this.OnSongSelectReceived          (args); break; }
				case MidiStatus.TuneRequest       : { this.OnTuneRequestReceived         (args); break; }
				case MidiStatus.SystemExclusiveEnd: { this.OnSystemExclusiveEndReceived  (args); break; }
				case MidiStatus.TimingClock       : { this.OnTimingClockReceived         (args); break; }
				case MidiStatus.Start             : { this.OnStartReceived               (args); break; }
				case MidiStatus.Continue          : { this.OnContinueReceived            (args); break; }
				case MidiStatus.Stop              : { this.OnStopReceived                (args); break; }
				case MidiStatus.ActiveSensing     : { this.OnActiveSensingReceived       (args); break; }
				case MidiStatus.SystemReset       : { this.OnSystemResetReceived         (args); break; }
				default                           :
				{
					// TODO: Assert? throw? both?
					string message = string.Format(
						"Unknown MIDI System Exclusive input message received: 0x{0:X}", args.StatusRaw);
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
			MidiInputDevice that = obj as MidiInputDevice;
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

}