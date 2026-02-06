using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com.Interfaces;

[GeneratedComInterface]
[Guid("0C733A30-2A1C-11CE-ADE5-00AA0044773D")]
public partial interface ISequentialStream : IUnknown
{
	/// <summary>
	/// Reads up to <paramref name="byteCount"/> bytes from the stream into the provided buffer.
	/// </summary>
	/// <param name="data">Buffer that receives the bytes; the callee writes into this array based on <paramref name="byteCount"/>.</param>
	/// <param name="byteCount">Maximum number of bytes to read into <paramref name="data"/>.</param>
	/// <param name="bytesRead">The actual number of bytes read into <paramref name="data"/>.</param>
	/// <returns>An HRESULT code indicating success or failure of the read operation.</returns>
	[PreserveSig]
	int Read([MarshalUsing(CountElementName = nameof(byteCount))] [Out] byte[] data, uint byteCount, out uint bytesRead);

	/// <summary>
	/// Writes up to <paramref name="byteCount"/> bytes from the provided buffer into the stream.
	/// </summary>
	/// <param name="data">Buffer containing the bytes to write.</param>
	/// <param name="byteCount">Maximum number of bytes to write from <paramref name="data"/>.</param>
	/// <param name="bytesWritten">Receives the number of bytes actually written.</param>
	/// <returns>An HRESULT as an int: `0` (S_OK) on success, or a COM error code on failure.</returns>
	[PreserveSig]
	int Write([MarshalUsing(CountElementName = nameof(byteCount))] [In] byte[] data, uint byteCount, out uint bytesWritten);
}
