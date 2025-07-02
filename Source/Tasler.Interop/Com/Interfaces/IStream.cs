using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("0000000C-0000-0000-C000-000000000046")]
public partial interface IStream
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
	/// <returns></returns>
	[PreserveSig]
	int Seek(long offset, STREAM_SEEK origin, out ulong newPosition);

	[PreserveSig]
	int SetSize(ulong newSize);

	[PreserveSig]
	int CopyTo(IStream targetStream, ulong byteCount, out ulong bytesRead, out ulong bytesWritten);

	[PreserveSig]
	int Commit(STGCOMMIT commitFlags);

	[PreserveSig]
	int Revert();

	/// <summary>
	/// Locks the region.
	/// </summary>
	/// <param name="offset">Specifies the byte offset for the beginning of the range.</param>
	/// <param name="byteCount">Specifies, in bytes, the length of the range to be restricted.</param>
	/// <param name="lockType">Specifies the type of restrictions being requested on accessing the range.</param>
	[PreserveSig]
	int LockRegion(ulong offset, ulong byteCount, LockType lockType);

	/// <summary>
	/// Removes the access restriction on a previously locked range of bytes.
	/// </summary>
	/// <param name="offset">Specifies the byte offset for the beginning of the range.</param>
	/// <param name="byteCount">Specifies, in bytes, the length of the range that is restricted.</param>
	/// <param name="lockType">Specifies the type of access restrictions previously placed on the range.</param>
	[PreserveSig]
	int UnlockRegion(ulong offset, ulong byteCount, LockType lockType);

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
	[PreserveSig]
	int Stat(out STATSTG statStg, STATFLAG statFlag);

	[PreserveSig]
	int Clone(out IStream ppstm);

}
