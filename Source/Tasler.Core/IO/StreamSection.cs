using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Tasler.IO
{
	// TODO: NEEDS_UNIT_TESTS

	public class StreamSection : Stream
	{
		#region Instance Fields
		private Stream? _stream;
		private long _origin;
		private long _length;
		private long _position;
		#endregion Instance Fields

		#region Construction
		/// <summary>
		/// Constructs either an empty stream or a null stream.
		/// </summary>
		/// <param name="length">The number of bytes the stream should appear to contain.</param>
		public StreamSection(long length)
		{
			_length = length;
		}

		public StreamSection(Stream stream, long origin, long length)
		{
			ValidateArgument.IsNotNull(stream, nameof(stream));
			if (!stream.CanRead)
				throw new ArgumentException("Unreadable stream specified.", "stream");
			if (!stream.CanSeek)
				throw new ArgumentException("Unseekable stream specified.", "stream");
			if (origin >= stream.Length)
				throw new ArgumentOutOfRangeException("position", "Specified position is beyond the length of the specified stream.");
			if (origin < 0)
				throw new ArgumentOutOfRangeException("position", "Specified argument must be non-negative.");
			if (length < 0)
				throw new ArgumentOutOfRangeException("length", "Specified argument must be non-negative.");
			if (origin + length > stream.Length)
				throw new ArgumentOutOfRangeException("length", "Specified length extends beyond the length of the specified stream.");

			// Save the specified parameters
			_stream = stream;
			_origin = origin;
			_length = length;
		}
		#endregion Construction

		#region Stream Overrides

		public override bool CanRead => true;

		public override bool CanSeek => true;

		public override bool CanWrite => false;

		public override void Flush() => _stream?.Flush();

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			return (_stream is not null)
				? _stream.FlushAsync(cancellationToken)
				: Task.CompletedTask;
		}

		public override long Length => _length;

		public override long Position
		{
			get { return _origin; }
			set { this.Seek(value, SeekOrigin.Begin); }
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			// TODO: RESOURCES
			ValidateArgument.IsNotNull(buffer, nameof(buffer));
			if (offset < 0)
				throw new ArgumentOutOfRangeException("position", "Specified argument must be non-negative.");
			if (count < 0)
				throw new ArgumentOutOfRangeException("count", "Specified argument must be non-negative.");
			if ((buffer.Length - offset) < count)
				throw new ArgumentException("position", "Specified range extends beyond the length of the specified buffer.");

			// Set the maximum byte count
			count = (int)Math.Min(count, _length - _position);

			if (_stream != null)
			{
				lock (_stream)
				{
					// Save current position of underlying stream
					long previousPosition = _stream.Position;

					try
					{
						_stream.Position = _origin + _position;
						int bytesRead = _stream.Read(buffer, offset, count);
						_position += bytesRead;
						return bytesRead;
					}
					finally
					{
						// Restore previous position of underlying stream
						_stream.Position = previousPosition;
					}
				}
			}
			else
			{
				Array.Clear(buffer, offset, count);
				_position += count;
				return count;
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			// TODO: RESOURCES
			switch (origin)
			{
				case SeekOrigin.Begin:
					if (offset < 0)
						throw new IOException("Attempted to seek before the beginning of the stream.");
					_position = offset;
					break;

				case SeekOrigin.Current:
					if ((offset + _position) < 0)
						throw new IOException("Attempted to seek before the beginning of the stream.");
					_position += offset;
					break;

				case SeekOrigin.End:
					if ((_length + offset) < 0)
						throw new IOException("Attempted to seek before the beginning of the stream.");
					_position = _length + offset;
					break;

				default:
					throw new ArgumentException("position", "Invalid seek position specified.");
			}

			return _position;
		}

		public override void SetLength(long value)
		{
			// TODO: RESOURCES
			throw new NotSupportedException("The current stream does not support writing.");
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			// TODO: RESOURCES
			throw new NotSupportedException("The current stream does not support writing.");
		}

		#endregion Stream Overrides
	}
}
