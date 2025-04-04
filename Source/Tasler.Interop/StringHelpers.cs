using System.Buffers;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tasler.Interop;

public static class StringHelpers
{
	/// <summary>
	///   <br />
	/// </summary>
	/// <param name="buffer">The buffer.</param>
	/// <param name="bufferLength">Length of the buffer.</param>
	/// <returns>
	///   <br />
	/// </returns>
	public delegate int GetTextFunc(char[] buffer, int bufferLength);

	/// <summary>Gets the variable length string.</summary>
	/// <param name="getTextFunc">
	///   The function that accepts a buffer and bufferLength as parameters, and that returns the number
	///   of characters copied to the buffer.
	/// </param>
	/// <param name="initialBufferLength">Initial length of the buffer.</param>
	/// <returns>
	///   <br />
	/// </returns>
	/// <exception cref="System.ComponentModel.Win32Exception">The func returned zero and the last error was unexpected.</exception>
	/// <exception cref="System.OutOfMemoryException">The buffer has grown pathelogically.</exception>
	public static string GetVariableLengthString(GetTextFunc getTextFunc, int initialBufferLength = 16)
	{
		var previousCch = 0;
		var cch = 1;
		var bufferLength = initialBufferLength;
		char[] buffer = [];

		do
		{
			using var bufferScope = new DisposeScopeExit(() => ArrayPool<char>.Shared.Return(buffer));

			buffer = ArrayPool<char>.Shared.Rent(bufferLength);
			cch = getTextFunc(buffer, bufferLength);
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
