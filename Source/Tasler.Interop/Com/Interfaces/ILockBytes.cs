using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

/// <summary>
/// Implemented on a byte array object that is backed by some physical storage, such as a disk
/// file, global memory, or a database. It is used by a COM compound file storage object to give
/// its root storage access to the physical device, while isolating the root storage from the
/// details of accessing the physical storage.
/// </summary>
[GeneratedComInterface]
[Guid("0000000A-0000-0000-C000-000000000046")]
public partial interface ILockBytes : IUnknown
{
	/// <summary>
	/// Reads a specified number of bytes starting at a specified offset from the beginning of the
	/// byte array object.
	/// </summary>
	/// <param name="offset">Specifies the starting point from the beginning of the byte array for
	/// reading data.</param>
	/// <param name="pv">Pointer to the buffer into which the byte array is read. The size of this
	/// buffer is contained in <paramref name="byteCount"/>.</param>
	/// <param name="byteCount">Specifies the number of bytes of data to attempt to read from the
	/// byte array.</param>
	/// <param name="bytesRead">Upon return this contains the actual number of bytes read from the
	/// byte array.</param>
	void ReadAt(ulong offset, nint pv, uint byteCount, out uint bytesRead);

	/// <summary>
	/// Writes the specified number of bytes starting at a specified offset from the beginning of the
	/// byte array.
	/// </summary>
	/// <param name="offset">Specifies the starting point from the beginning of the byte array for
	/// the data to be written.</param>
	/// <param name="pv">Pointer to the buffer containing the data to be written.</param>
	/// <param name="byteCount">Specifies the number of bytes of data to attempt to write into the
	/// byte array.</param>
	/// <param name="bytesWritten">Upon return this contains the actual number of bytes written to
	/// the byte array.</param>
	void WriteAt(ulong offset, nint pv, uint byteCount, out uint bytesWritten);

	/// <summary>
	/// Ensures that any internal buffers maintained by the ILockBytes implementation are written out
	/// to the underlying physical storage.
	/// </summary>
	/// <remarks>
	/// <para><see cref="ILockBytes.Flush"/> flushes internal buffers to the underlying storage device.</para>
	/// <para>The COM-provided implementation of compound files calls this method during a transacted commit
	/// operation to provide a two-phase commit process that protects against loss of data.</para>
	/// </remarks>
	void Flush();

	/// <summary>Changes the size of the byte array.</summary>
	/// <param name="byteCount">The new size of the byte array as a number of bytes.</param>
	/// <remarks>
	/// <para>If the <paramref name="byteCount"/> is larger than the current byte array, the byte
	/// array is extended to the indicated size by filling the intervening space with bytes of
	/// undefined value, as does <see cref="ILockBytes.WriteAt"/>, if the seek pointer is past the
	/// current end-of-stream.</para>
	/// <para>If the cb parameter is smaller than the current byte array, the byte array is truncated
	/// to the indicated size.</para>
	/// <para>Callers cannot rely on <c>STG_E_MEDIUMFULL</c> being returned at the appropriate time
	/// because of cache buffering in the operating system or network. However, callers must be able
	/// to deal with this return code because some <see cref="ILockBytes"/> implementations might
	/// support it.</para>
	/// </remarks>
	[PreserveSig]
	int SetSize(ulong byteCount);

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
}
