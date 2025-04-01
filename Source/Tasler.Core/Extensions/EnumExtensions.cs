using System;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using Tasler.Properties;

namespace Tasler;

// TODO: NEEDS_UNIT_TESTS

/// <summary>
/// Provides extension methods for enum's.
/// </summary>
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "<Pending>")]
public static class EnumExtensions
{
	#region Bit Flipping

	/// <summary>
	/// Sets to 1 (turns on) the specified <paramref name="bits"/>.
	/// </summary>
	/// <param name="@this">The <see cref="uint"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <param name="bits">The bits.</param>
	/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> set to 1 (turned on).</returns>
	public static ref T SetBits<T>(this ref T @this, T bits)
		where T : struct, Enum, IConvertible
	{
		var unsignedSelf = ValidateArgument.IsEnumBitFlags(@this).ToUInt64(null);
		var unsignedBits = bits.ToUInt64(null);
		var unsignedResult = unsignedSelf | unsignedBits;

		@this = (T)Enum.ToObject(typeof(T), unsignedResult);
		return ref @this;
	}

	/// <summary>
	/// Clears to 0 (turns off) the specified <paramref name="bits"/>.
	/// </summary>
	/// <param name="@this">The <typeparamref name="T"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <param name="bits">The bits.</param>
	/// <returns>The <paramref name="@this"/> with the specified <paramref name="bits"/> cleared to 0 (turned off).</returns>
	public static ref T ClearBits<T>(this ref T @this, T bits)
		where T : struct, Enum, IConvertible
	{
		var unsignedSelf = ValidateArgument.IsEnumBitFlags(@this).ToUInt64(null);
		var unsignedBits = bits.ToUInt64(null);
		var unsignedResult = unsignedSelf & ~unsignedBits;

		@this = (T)Enum.ToObject(typeof(T), unsignedResult);
		return ref @this;
	}

	/// <summary>
	/// Based on a Boolean value, either sets to 1 (turns on) or clears to 0 (turns off) the specified <paramref name="bits"/>.
	/// </summary>
	/// <param name="@this">The <see cref="uint"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <param name="set">If set to <c>true</c> the specified <paramref name="bits"/> are set; otherwise they are cleared.</param>
	/// <param name="bits">The bits to either set or clear.</param>
	/// <returns></returns>
	public static T SetOrClearBits<T>(this ref T @this, bool set, T bits)
		where T : struct, Enum, IConvertible
	{
		return set ? @this.SetBits(bits) : @this.ClearBits(bits);
	}

	#endregion Bit Flipping
}
