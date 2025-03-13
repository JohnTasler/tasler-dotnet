using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Tasler.IO;

namespace Tasler.Multimedia 
{
	public class RiffChunk : RiffNode
	{
		#region ThreadStatic Fields
		[ThreadStatic] private static byte[] buffer;
		#endregion

		#region Static Fields
		public static readonly FourCC RIFF = new FourCC("RIFF");
		public static readonly FourCC LIST = new FourCC("LIST");
		#endregion

		#region Instance Fields
		private RiffNode parent;
		private long position;
		private int dataLength;
		private FourCC chunkId;
		private FourCC listType;
		#endregion

		#region Construction
		internal RiffChunk() 
		{
		}

		internal RiffChunk(RiffChunk that) 
		{
			this.parent = that.parent;
			this.position = that.position;
			this.dataLength = that.dataLength;
			this.chunkId = that.chunkId;
			this.listType = that.listType;
		}

		internal RiffChunk(RiffNode parent, long position) 
		{

			this.Initialize(parent, position);
		}

		internal int InitializeChunkId(Stream stream, long position) 
		{
			int bytesRead = 0;
			byte[] buffer = RiffChunk.Buffer;

			lock (stream)
			{
				// Position the stream at the specified position
				stream.Seek(position, SeekOrigin.Begin);

				// Read the chunk id, data length, and possible list type
				bytesRead = stream.Read(buffer, 0, buffer.Length);
			}

			// Verify valid length
			if (bytesRead < sizeof(int) * 2)
			{
				// TODO: RESOURCES
				throw new IOException(string.Format(
					"Unexpected end of stream encountered reading header of chunk starting at position 0x{0:X8}.",
					position));
			}

			// Save the FourCC
			this.chunkId = new FourCC(RiffChunk.ReadInt32(buffer, 0, false));

			// Return the number of bytes read
			return bytesRead;
		}

		internal void Initialize(RiffNode parent, long position) 
		{
			// Save the specified parent and position
			this.parent = parent;
			this.position = position;

			// Read the chunk id, data length, and possible list type
			int bytesRead = this.InitializeChunkId(parent.Stream, position);

			// Parse the chunk data length
			byte[] buffer = RiffChunk.Buffer;
			bool isBigEndian = this.IsBigEndian;
			this.dataLength = ReadInt32(buffer, 1, isBigEndian);

			// If the chunk is a list, parse the list type
			switch (this.Id.Value)
			{
				case RiffTags.Lists.LIST.Value:
				case RiffTags.Lists.RIFF.Value:
				case RiffTags.Lists.RIFX.Value:
					if (bytesRead < sizeof(int) * 3)
					{
						// TODO: RESOURCES
						throw new IOException(string.Format(
							"Unexpected end of stream encountered reading {0} type of chunk starting at position 0x{1:X8}.",
							this.Id, position));
					}

					this.listType = new FourCC(ReadInt32(buffer, 2, isBigEndian));
					break;

				default:
					this.listType = FourCC.Empty;
					break;
			}
		}
		#endregion

		#region Properties
		private static byte[] Buffer 
		{
			get 
			{
				// Since this is a ThreadStatic field, we must initialize it here when null instead of
				// assigning it as an initial value (in the field declaration).
				if (RiffChunk.buffer == null)
				{
					RiffChunk.buffer = new byte[3 * sizeof(int)];
				}
				return RiffChunk.buffer;
			}
		}

		public FourCC Id 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.chunkId;
			}
		}

		public long Position 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.position;
			}
		}

		public int Length 
		{
			[DebuggerStepThrough]
			get 
			{
				// The FourCC + the chunk size + the data length
				return FourCC.Size + sizeof(int) + (int)this.DataLength;
			}
		}

		public override long DataPosition 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.position + sizeof(int) * 2;
			}
		}

		public override long DataLength 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.dataLength;
			}
		}

		public override bool IsBigEndian 
		{
			get 
			{
				return this.Parent.IsBigEndian;
			}
		}

		public override bool IsList 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.ListType != FourCC.Empty;
			}
		}

		public FourCC ListType 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.listType;
			}
		}

		public override RiffNode Parent 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.parent;
			}
		}

		public override Stream Stream 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.parent.Stream;
			}
		}

		protected override long ListDataPosition 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.DataPosition + FourCC.Size;
			}
		}

		protected override long ListDataEndPosition 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.Position + this.Length;
			}
		}

		public bool IsLengthValid 
		{
			get 
			{
				// Chunk data must fit within parent's chunk data
				return (this.DataPosition + this.DataLength) <=
					(this.Parent.DataPosition + this.Parent.DataLength);
			}
		}
		#endregion

		#region Methods
		public Stream CreateStreamSection() 
		{
			return new StreamSection(this.Stream, this.Position, this.Length);
		}

		public Stream CreateDataStreamSection() 
		{
			return new StreamSection(this.Stream, this.DataPosition, this.DataLength);
		}
		#endregion

		#region Implementation
		private static int ReadInt32(byte[] buffer, int intIndex, bool isBigEndian) 
		{
			int byteIndex = intIndex * sizeof(int);
			Debug.Assert(byteIndex + sizeof(int) <= buffer.Length);

			if (isBigEndian)
			{
				return buffer[byteIndex + 3]
					| (buffer[byteIndex + 2] << 8)
					| (buffer[byteIndex + 1] << 16)
					| (buffer[byteIndex] << 24);
			}
			else
			{
				return buffer[byteIndex]
					| (buffer[byteIndex + 1] << 8)
					| (buffer[byteIndex + 2] << 16)
					| (buffer[byteIndex + 3] << 24);
			}
		}
		#endregion
	}
}
