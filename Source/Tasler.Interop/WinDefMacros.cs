using System;
using System.Numerics;

namespace Tasler.Interop;

public static class WinDef
{
	/// <summary>Retrieves the low-order word from the specified 32-bit value.</summary>
	/// <param name="dwValue">The value to be converted.</param>
	/// <returns>The low-order word of the specified value.</returns>
	public static short LOWORD(int dwValue) => (short)((uint)dwValue & 0xffffu);

	/// <summary>Retrieves the high-order word from the specified 32-bit value.</summary>
	/// <param name="dwValue">The value to be converted.</param>
	/// <returns>The high-order word of the specified value.</returns>
	public static short HIWORD(int dwValue) => (short)(((uint)dwValue >> 16) & 0xffffu);

	/// <summary>Retrieves the low-order word from the specified 32-bit value.</summary>
	/// <param name="dwValue">The value to be converted.</param>
	/// <returns>The low-order word of the specified value.</returns>
	public static ushort LOWORD(uint dwValue) => (ushort)(dwValue & 0xffffu);

	/// <summary>Retrieves the high-order word from the specified 32-bit value.</summary>
	/// <param name="dwValue">The value to be converted.</param>
	/// <returns>The high-order word of the specified value.</returns>
	public static ushort HIWORD(uint dwValue) => (ushort)(((uint)dwValue >> 16) & 0xffffu);

	/// <summary>Retrieves the signed x-coordinate from the specified LPARAM value.</summary>
	/// <param name="lParam">The value to be converted.</param>
	/// <returns>The low-order int of the specified value.</returns>
	public static int GET_X_LPARAM(uint lParam) => (short)LOWORD(lParam);

	/// <summary>Retrieves the signed y-coordinate from the specified LPARAM value.</summary>
	/// <param name="lParam">The value to be converted.</param>
	/// <returns>The high-order int of the specified value.</returns>
	public static int GET_Y_LPARAM(uint lParam)	=> (short)HIWORD(lParam);

	/// <summary>Retrieves the signed x-coordinate from the specified LPARAM value.</summary>
	/// <param name="lParam">The value to be converted.</param>
	/// <returns>The  low-order int of the specified value.</returns>
	public static int GET_X_LPARAM(nint lParam) => (short)LOWORD((int)lParam);

	/// <summary>Retrieves the signed y-coordinate from the specified LPARAM value.</summary>
	/// <param name="lParam">The value to be converted.</param>
	/// <returns>The high-order int of the specified value.</returns>
	public static int GET_Y_LPARAM(nint lParam) => (short)HIWORD((int)lParam);
}
