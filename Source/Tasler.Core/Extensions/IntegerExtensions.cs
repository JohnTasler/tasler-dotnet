
namespace Tasler
{
	// TODO: NEEDS_UNIT_TESTS

	/// <summary>
	/// Provides extension methods for integers.
	/// </summary>
	public static class IntegerExtensions
	{
		#region Bit Flipping

		#region Int16
		/// <summary>
		/// Sets to 1 (turns on) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="short"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> set to 1 (turned on).</returns>
		public static short SetBits(this short @this, short bits)
		{
			return (short)(@this | bits);
		}

		/// <summary>
		/// Clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="short"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> cleared to 0 (turned off).</returns>
		public static short ClearBits(this short @this, short bits)
		{
			return (short)(@this & ~bits);
		}

		/// <summary>
		/// Based on a Boolean value, either sets to 1 (turns on) or clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="short"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="set">If set to <c>true</c> the specified <paramref name="bits"/> are set; otherwise they are cleared.</param>
		/// <param name="bits">The bits to either set or clear.</param>
		/// <returns></returns>
		public static short SetOrClearBits(this short @this, bool set, short bits)
		{
			return set ? @this.SetBits(bits) : @this.ClearBits(bits);
		}
		#endregion Int16

		#region UInt16
		/// <summary>
		/// Sets to 1 (turns on) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="ushort"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> set to 1 (turned on).</returns>
		public static ushort SetBits(this ushort @this, ushort bits)
		{
			return (ushort)(@this | bits);
		}

		/// <summary>
		/// Clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="ushort"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> cleared to 0 (turned off).</returns>
		public static ushort ClearBits(this ushort @this, ushort bits)
		{
			return (ushort)(@this & ~bits);
		}

		/// <summary>
		/// Based on a Boolean value, either sets to 1 (turns on) or clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="ushort"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="set">If set to <c>true</c> the specified <paramref name="bits"/> are set; otherwise they are cleared.</param>
		/// <param name="bits">The bits to either set or clear.</param>
		/// <returns></returns>
		public static ushort SetOrClearBits(this ushort @this, bool set, ushort bits)
		{
			return set ? @this.SetBits(bits) : @this.ClearBits(bits);
		}
		#endregion UInt16

		#region Int32
		/// <summary>
		/// Sets to 1 (turns on) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="int"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> set to 1 (turned on).</returns>
		public static int SetBits(this int @this, int bits)
		{
			return @this | bits;
		}

		/// <summary>
		/// Clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="int"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> cleared to 0 (turned off).</returns>
		public static int ClearBits(this int @this, int bits)
		{
			return @this & ~bits;
		}

		/// <summary>
		/// Based on a Boolean value, either sets to 1 (turns on) or clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="int"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="set">If set to <c>true</c> the specified <paramref name="bits"/> are set; otherwise they are cleared.</param>
		/// <param name="bits">The bits to either set or clear.</param>
		/// <returns></returns>
		public static int SetOrClearBits(this int @this, bool set, int bits)
		{
			return set ? @this.SetBits(bits) : @this.ClearBits(bits);
		}
		#endregion Int32

		#region UInt32
		/// <summary>
		/// Sets to 1 (turns on) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="uint"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> set to 1 (turned on).</returns>
		public static uint SetBits(this uint @this, uint bits)
		{
			return @this | bits;
		}

		/// <summary>
		/// Clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="uint"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> cleared to 0 (turned off).</returns>
		public static uint ClearBits(this uint @this, uint bits)
		{
			return @this & ~bits;
		}

		/// <summary>
		/// Based on a Boolean value, either sets to 1 (turns on) or clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="uint"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="set">If set to <c>true</c> the specified <paramref name="bits"/> are set; otherwise they are cleared.</param>
		/// <param name="bits">The bits to either set or clear.</param>
		/// <returns></returns>
		public static uint SetOrClearBits(this uint @this, bool set, uint bits)
		{
			return set ? @this.SetBits(bits) : @this.ClearBits(bits);
		}
		#endregion UInt32

		#region Int64
		/// <summary>
		/// Sets to 1 (turns on) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="long"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> set to 1 (turned on).</returns>
		public static long SetBits(this long @this, long bits)
		{
			return @this | bits;
		}

		/// <summary>
		/// Clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="long"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> cleared to 0 (turned off).</returns>
		public static long ClearBits(this long @this, long bits)
		{
			return @this & ~bits;
		}

		/// <summary>
		/// Based on a Boolean value, either sets to 1 (turns on) or clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="long"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="set">If set to <c>true</c> the specified <paramref name="bits"/> are set; otherwise they are cleared.</param>
		/// <param name="bits">The bits to either set or clear.</param>
		/// <returns></returns>
		public static long SetOrClearBits(this long @this, bool set, long bits)
		{
			return set ? @this.SetBits(bits) : @this.ClearBits(bits);
		}
		#endregion Int64

		#region UInt64
		/// <summary>
		/// Sets to 1 (turns on) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="ulong"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> set to 1 (turned on).</returns>
		public static ulong SetBits(this ulong @this, ulong bits)
		{
			return @this | bits;
		}

		/// <summary>
		/// Clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="ulong"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="bits">The bits.</param>
		/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> cleared to 0 (turned off).</returns>
		public static ulong ClearBits(this ulong @this, ulong bits)
		{
			return @this & ~bits;
		}

		/// <summary>
		/// Based on a Boolean value, either sets to 1 (turns on) or clears to 0 (turns off) the specified <paramref name="bits"/>.
		/// </summary>
		/// <param name="@this">The <see cref="ulong"/> instance on which the extension method operates.
		/// As an extension method, this is typically not specified explicitly.</param>
		/// <param name="set">If set to <c>true</c> the specified <paramref name="bits"/> are set; otherwise they are cleared.</param>
		/// <param name="bits">The bits to either set or clear.</param>
		/// <returns></returns>
		public static ulong SetOrClearBits(this ulong @this, bool set, ulong bits)
		{
			return set ? @this.SetBits(bits) : @this.ClearBits(bits);
		}
		#endregion UInt64

		#endregion Bit Flipping
	}
}
