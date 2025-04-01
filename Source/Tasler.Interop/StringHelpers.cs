using System.Buffers;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tasler.Interop;
public static class StringHelpers
{
	public static string GetVariableLengthString(Func<char[], int, int> func, int initialBufferLength = 16)
	{
		var previousCch = 0;
		var cch = 1;
		var bufferLength = initialBufferLength;
		char[] buffer = [];

		do
		{
			using var bufferScope = new DisposeScopeExit(() => ArrayPool<char>.Shared.Return(buffer));

			buffer = ArrayPool<char>.Shared.Rent(bufferLength);
			cch = func(buffer, bufferLength);
			var lastError = Marshal.GetLastPInvokeError();
			if (cch == 0)
			{
				if (lastError != 0 && lastError != WinError.InsufficientBuffer)
					throw new Win32Exception(lastError);
			}

			if ((bufferLength - 1) > cch || cch == previousCch)
			{
				return new string(buffer, 0, unchecked(cch));
			}
			previousCch = cch;

			// Double the buffer length and do a sanity range check
			bufferLength <<= 1;
			if ((bufferLength & 0x0040_0000) != 0)
			{
				Marshal.SetLastPInvokeError(WinError.InsufficientBuffer);
				throw new OutOfMemoryException { HResult = Marshal.GetHRForLastWin32Error() };
			}

		} while (true);
	}
}
