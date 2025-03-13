using System;
using System.Diagnostics;

using Tasler.Threading;

namespace Tasler.Multimedia 
{
	public class MidiInputOmniChannel 
	{
		#region Instance Fields
		private MidiInputDevice device;
		#endregion

		#region Construction
		internal MidiInputOmniChannel(MidiInputDevice device) 
		{
			this.device = device;
		}
		#endregion

		#region Properties
		public MidiInputDevice Device { get { return this.device; } }
		#endregion
		
		#region Events
		public event MidiInputEventHandler ChannelMessageReceived;
		public event MidiInputEventHandler NoteOffReceived;
		public event MidiInputEventHandler NoteOnReceived;
		public event MidiInputEventHandler KeyAftertouchReceived;
		public event MidiInputEventHandler ControlChangeReceived;
		public event MidiInputEventHandler ProgramChangeReceived;
		public event MidiInputEventHandler ChannelAftertouchReceived;
		public event MidiInputEventHandler PitchBendReceived;
		#endregion

		#region Event Raising Methods

		protected virtual void OnChannelMessageReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.ChannelMessageReceived, this, args);
		}
		protected virtual void OnNoteOffReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.NoteOffReceived, this, args);
		}
		protected virtual void OnNoteOnReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.NoteOnReceived, this, args);
		}
		protected virtual void OnKeyAftertouchReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.KeyAftertouchReceived, this, args);
		}
		protected virtual void OnControlChangeReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.ControlChangeReceived, this, args);
		}
		protected virtual void OnProgramChangeReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.ProgramChangeReceived, this, args);
		}
		protected virtual void OnChannelAftertouchReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.ChannelAftertouchReceived, this, args);
		}
		protected virtual void OnPitchBendReceived(MidiInputEventArgs args)
		{
			DelegateInvoker.Invoke(this.PitchBendReceived, this, args);
		}
		#endregion
	
		#region Implementation Methods
		internal void ProcessChannelData(MidiInputEventArgs args) 
		{
			this.OnChannelMessageReceived(args);
			switch ((MidiStatus)args.Status)
			{
				case MidiStatus.NoteOn         : { this.OnNoteOnReceived           (args); break; }
				case MidiStatus.NoteOff        : { this.OnNoteOffReceived          (args); break; }
				case MidiStatus.KeyAfterTouch  : { this.OnKeyAftertouchReceived    (args); break; }
				case MidiStatus.ControlChange  : { this.OnControlChangeReceived    (args); break; }
				case MidiStatus.ProgramChange  : { this.OnProgramChangeReceived    (args); break; }
				case MidiStatus.ChanAfterTouch : { this.OnChannelAftertouchReceived(args); break; }
				case MidiStatus.PitchBend      : { this.OnPitchBendReceived        (args); break; }
				default                        :
				{
					// TODO: Assert? throw? both?
					string message = string.Format(
						"Unknown MIDI status input message received: 0x{0:x}", args.Status);
					Debug.Fail(message);

					// TODO: Define a custom exception?
					throw new ApplicationException(message);
				}
			}
		}
		#endregion
	}
	
	public class MidiInputChannel : MidiInputOmniChannel 
	{
		#region Instance Fields
		private byte number;
		#endregion

		#region Construction
		internal MidiInputChannel(MidiInputDevice device, byte number) 
			: base(device) 
		{
			this.number = number;
		}
		#endregion

		#region Properties
		public byte Number { get { return this.number; } }
		#endregion
	}
}