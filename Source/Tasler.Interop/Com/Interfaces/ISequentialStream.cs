using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com.Interfaces;

[GeneratedComInterface]
[Guid("0C733A30-2A1C-11CE-ADE5-00AA0044773D")]
public partial interface ISequentialStream
{
	[PreserveSig]
	int Read(nint pv, uint byteCount, out uint bytesRead);

	[PreserveSig]
	int Write(nint pv, uint byteCount, out uint bytesWritten);
}
