using System;

namespace Tasler.Interop
{
	public static class WinDef
	{
		/// <summary>Retrieves the low-order word from the specified 32-bit value.</summary>
		/// <param name="dwValue">The value to be converted.</param>
		/// <returns>The low-order word of the specified value.</returns>
		public static ushort LOWORD(int dwValue)
		{
			return (ushort)((uint)dwValue & 0xffffu);
		}

		/// <summary>Retrieves the high-order word from the specified 32-bit value.</summary>
		/// <param name="dwValue">The value to be converted.</param>
		/// <returns>The high-order word of the specified value.</returns>
		public static ushort HIWORD(int dwValue)
		{
			return (ushort)(((uint)dwValue >> 16) & 0xffffu);
		}

		/// <summary>Retrieves the signed x-coordinate from the specified LPARAM value.</summary>
		/// <param name="lParam">The value to be converted.</param>
		/// <returns>The low-order int of the specified value.</returns>
		public static int GET_X_LPARAM(int lParam)
		{
			return (short)LOWORD(lParam);
		}

		/// <summary>Retrieves the signed y-coordinate from the specified LPARAM value.</summary>
		/// <param name="lParam">The value to be converted.</param>
		/// <returns>The high-order int of the specified value.</returns>
		public static int GET_Y_LPARAM(int lParam)
		{
			return (short)HIWORD(lParam);
		}

		/// <summary>Retrieves the signed x-coordinate from the specified LPARAM value.</summary>
		/// <param name="lParam">The value to be converted.</param>
		/// <returns>The low-order int of the specified value.</returns>
		public static int GET_X_LPARAM(IntPtr lParam)
		{
			return (short)LOWORD(lParam.ToInt32());
		}

		/// <summary>Retrieves the signed y-coordinate from the specified LPARAM value.</summary>
		/// <param name="lParam">The value to be converted.</param>
		/// <returns>The high-order int of the specified value.</returns>
		public static int GET_Y_LPARAM(IntPtr lParam)
		{
			return (short)HIWORD(lParam.ToInt32());
		}
	}
}
