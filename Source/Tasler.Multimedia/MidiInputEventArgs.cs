using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Tasler.Multimedia 
{
	public delegate void MidiInputOpenCloseEventHandler(object sender, EventArgs args);
	public delegate void MidiOpenCloseEventHandler(object sender, EventArgs args);

	public class MidiInputEventArgsBase : System.EventArgs 
	{
		#region Instance Fields
		private uint timeStamp;
		#endregion

		#region Construction
		public MidiInputEventArgsBase(uint timeStamp) 
		{
			// Save the specified values
			this.timeStamp = timeStamp;
		}
		#endregion

		#region Properties
		public uint TimeStamp { get { return this.timeStamp; } }
		#endregion
	}

	public class MidiInputEventArgs : MidiInputEventArgsBase 
	{
		#region Instance Fields
		private int midiMessageData;
		#endregion

		#region Construction
		public MidiInputEventArgs(int midiMessageData, uint timeStamp) 
			: base(timeStamp) 
		{
			this.midiMessageData = midiMessageData;
		}

		public MidiInputEventArgs(IntPtr param1, UIntPtr param2) 
			: this(param1.ToInt32(), param2.ToUInt32()) 
		{
		}
		#endregion

		#region Properties
		public int MidiMessageData { get { return this.midiMessageData; } }
		public byte StatusRaw { get { return MidiInputEventArgs.GetStatusRaw(this.MidiMessageData); } }
		public byte Status    { get { return MidiInputEventArgs.GetStatus   (this.MidiMessageData); } }
		public byte Channel   { get { return MidiInputEventArgs.GetChannel  (this.MidiMessageData); } }
		public byte Data1     { get { return MidiInputEventArgs.GetData1    (this.MidiMessageData); } }
		public byte Data2     { get { return MidiInputEventArgs.GetData2    (this.MidiMessageData); } }
		#endregion

		#region Static Methods
		public static byte GetStatusRaw(int midiMessageData) { return (byte)(midiMessageData & 0x000000FF); }
		public static byte GetStatus   (int midiMessageData) { return (byte)(GetStatusRaw(midiMessageData) & 0xF0); }
		public static byte GetChannel  (int midiMessageData) { return (byte)(GetStatusRaw(midiMessageData) & 0x0F); }
		public static byte GetData1    (int midiMessageData) { return (byte)((midiMessageData & 0x0000FF00) >>  8); }
		public static byte GetData2    (int midiMessageData) { return (byte)((midiMessageData & 0x00FF0000) >> 16); }
		#endregion
	}
	public delegate void MidiInputEventHandler(object sender, MidiInputEventArgs args);

	public class MidiInputExceptionEventArgs : MidiInputEventArgs 
	{
		#region Instance Fields
		private uint wMsg;
		private Exception e;
		#endregion

		#region Construction
		public MidiInputExceptionEventArgs(uint wMsg, IntPtr param1, UIntPtr param2, Exception e) 
			: base(param1, param2)
		{
			this.wMsg = wMsg;
			this.e = e;
		}
		#endregion

		#region Properties
		public Exception Exception { get { return this.e; } }
		public uint InputMessage { get { return this.wMsg; } }
		#endregion
	}
	public delegate void MidiInputExceptionEventHandler(object sender, MidiInputExceptionEventArgs args);

	public class MidiInputLongEventArgs : MidiInputEventArgsBase 
	{
		#region Instance Fields
		private Stream stream;
		#endregion

		#region Construction
		public MidiInputLongEventArgs(Stream stream, UIntPtr timeStamp) 
			: base(timeStamp.ToUInt32()) 
		{
			this.stream = stream;
		}
		#endregion

		#region Properties
		public Stream LongData
		{
			get 
			{
				return this.stream;
			}
		}
		#endregion
	}

	public delegate void MidiInputLongEventHandler(object sender, MidiInputLongEventArgs args);
}