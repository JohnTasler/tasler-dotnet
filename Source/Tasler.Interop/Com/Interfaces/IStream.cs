using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com.Interfaces;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("0000000C-0000-0000-C000-000000000046")]
public partial interface IStream : ISequentialStream
{
	/// <summary>
	/// changes the seek pointer to a new location. The new location is relative to either the
	/// beginning of the stream, the end of the stream, or the current seek pointer.
	/// </summary>
	/// <param name="offset">The displacement to be added to the location indicated by
	/// the <paramref name="origin"/> parameter. If <paramref name="origin"/> is
	/// <see cref="STREAM_SEEK.Set"/>, this is interpreted as an unsigned value rather than a signed
	/// value.</param>
	/// <param name="origin">The origin for the displacement specified in <paramref name="offset"/>.
	/// The origin can be the beginning of the file (<see cref="STREAM_SEEK.Set"/>), the current seek
	/// pointer (<see cref="STREAM_SEEK.Current"/>), or the end of the file
	/// (<see cref="STREAM_SEEK.End"/>). For more information about values, see the
	/// <see cref="STREAM_SEEK"/> enumeration.</param>
	/// <param name="newPosition">Upon return this is set to the value of the new seek pointer from
	/// the beginning of the stream.</param>
	/// <summary>
/// Moves the stream's current seek pointer to a new position relative to the specified origin.
/// </summary>
/// <param name="offset">Byte displacement to apply from <paramref name="origin"/>. When <paramref name="origin"/> is <c>STREAM_SEEK.Set</c>, <paramref name="offset"/> is treated as an unsigned value.</param>
/// <param name="origin">Reference point used to calculate the new position (beginning, current, or end of the stream).</param>
/// <param name="newPosition">Receives the resulting position of the seek pointer measured from the beginning of the stream.</param>
	/// <returns></returns>
	void Seek(long offset, STREAM_SEEK origin, out ulong newPosition);

	/// <summary>
/// Sets the total size of the stream to the specified value.
/// </summary>
/// <param name="newSize">The desired stream size in bytes.</param>
	void SetSize(ulong newSize);

	/// <summary>
/// Copies up to a specified number of bytes from this stream into another stream.
/// </summary>
/// <param name="targetStream">The destination stream that receives the data.</param>
/// <param name="byteCount">The maximum number of bytes to copy.</param>
/// <param name="bytesRead">Receives the number of bytes actually read from this stream.</param>
/// <param name="bytesWritten">Receives the number of bytes actually written to <paramref name="targetStream"/>.</param>
	void CopyTo(IStream targetStream, ulong byteCount, out ulong bytesRead, out ulong bytesWritten);

	/// <summary>
/// Commits changes made to the stream according to the specified commit flags.
/// </summary>
/// <param name="commitFlags">Flags that control how the commit is performed (for example, whether changes are flushed to permanent storage and the commit semantics).</param>
	void Commit(STGCOMMIT commitFlags);

	/// <summary>
/// Reverts uncommitted changes made to the stream since the last commit, restoring the stream to its previous state.
/// </summary>
	void Revert();

	/// <summary>
	/// Locks the region.
	/// </summary>
	/// <param name="offset">Specifies the byte offset for the beginning of the range.</param>
	/// <param name="byteCount">Specifies, in bytes, the length of the range to be restricted.</param>
	/// <param name="lockType">Specifies the type of restrictions being requested on accessing the range.</param>
	void LockRegion(ulong offset, ulong byteCount, LockType lockType);

	/// <summary>
	/// Removes the access restriction on a previously locked range of bytes.
	/// </summary>
	/// <param name="offset">Specifies the byte offset for the beginning of the range.</param>
	/// <param name="byteCount">Specifies, in bytes, the length of the range that is restricted.</param>
	/// <param name="lockType">Specifies the type of access restrictions previously placed on the range.</param>
	void UnlockRegion(ulong offset, ulong byteCount, LockType lockType);

	/// <summary>
	/// Retrieves a <see cref="STATSTG"/> structure containing information for this byte array object.
	/// </summary>
	/// <param name="statStg">Upon return, contains information about this byte array object.</param>
	/// <param name="statFlag">Specifies whether this method should supply the
	/// <see cref="STATSTG.Name"/> member through values taken from the <see cref="STATFLAG"/>
	/// enumeration. If the <see cref="STATFLAG.NONAME"/> is specified, the
	/// <see cref="STATSTG.Name"/> member is not supplied, thus saving a memory-allocation operation.
	/// The other possible value, <see cref="STATFLAG.Default"/>, indicates that all members of the
	/// <see cref="STATSTG"/> structure be supplied.</param>
	void Stat(out STATSTG statStg, STATFLAG statFlag);

	/// <summary>
/// Creates a new stream object that references the same underlying data and has its position set to match this stream.
/// </summary>
/// <returns>An <see cref="IStream"/> representing the cloned stream positioned at the same location as the original.</returns>
	IStream Clone();
}
