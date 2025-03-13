using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Tasler.Multimedia 
{
	public class RiffReader : RiffNode, IDisposable 
	{
		#region Instance Fields
		private Stream stream;
		private RiffChunk firstChunk;
		#endregion

		#region Construction / Disposal
		public RiffReader(string path) 
		{
			if (path == null)
			{
				throw new ArgumentNullException("path");
			}

			this.Init(new FileStream(path, FileMode.Open, FileAccess.Read));
		}

		public RiffReader(Stream stream) 
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}

			if (!stream.CanRead)
			{
				throw new ArgumentException("Unreadable stream specified.", "stream");
			}

			if (!stream.CanSeek)
			{
				throw new ArgumentException("Unseekable stream specified.", "stream");
			}

			this.Init(stream);
		}

		private void Init(Stream stream) 
		{
			this.stream = stream;
		}

		public void Dispose() 
		{
			using (this.stream)
			{
				this.stream = null;
			}

			GC.SuppressFinalize(this);
		}

		~RiffReader() 
		{
			this.Dispose();
		}
		#endregion

		#region Properties
		public RiffChunk FirstChunk 
		{
			get 
			{
				if (this.firstChunk == null)
				{
					this.firstChunk = new RiffChunk();
					this.firstChunk.InitializeChunkId(this.Stream, 0);
					this.firstChunk.Initialize(this, 0);
				}

				return this.firstChunk;
			}
		}

		public virtual bool IsValid 
		{
			get 
			{
				if (this.FirstChunk.IsLengthValid)
				{
					switch (this.FirstChunk.Id.Value)
					{
						case RiffTags.Lists.RIFF.Value:
						case RiffTags.Lists.RIFX.Value:
							return true;
					}
				}

				// Failed all tests
				return false;
			}
		}

		#endregion

		#region RiffNode Overrides
		public override bool IsBigEndian 
		{
			get 
			{
				return this.FirstChunk.Id.Value == RiffTags.Lists.RIFX.Value;
			}
		}

		public override bool IsList 
		{
			[DebuggerStepThrough]
			get 
			{
				return true;
			}
		}

		public override RiffNode Parent 
		{
			[DebuggerStepThrough]
			get 
			{
				return null;
			}
		}

		public override Stream Stream 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.stream;
			}
		}

		public override long DataPosition 
		{
			[DebuggerStepThrough]
			get 
			{
				return 0;
			}
		}

		public override long DataLength 
		{
			get 
			{
				return this.Stream.Length;
			}
		}

		protected override long ListDataPosition 
		{
			[DebuggerStepThrough]
			get 
			{
				return 0;
			}
		}

		protected override long ListDataEndPosition 
		{
			[DebuggerStepThrough]
			get 
			{
				return this.Stream.Length;
			}
		}

		#endregion
	}
}
