using System.Numerics;

namespace Tasler;

// TODO: NEEDS_UNIT_TESTS

/// <summary>
/// Provides extension methods for setting, clearing, and testing bit flags on value types that support bitwise operations.
/// </summary>
public static class BitFlagExtensions
{
	#region Bit Flipping

	/// <summary>
	/// Sets to 1 (turns on) the specified <paramref name="flags"/>.
	/// </summary>
	/// <param name="this">A reference to the <typeparamref name="T"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <typeparam name="T">A value type that supports bitwise operators <see cref="IBitwiseOperators{T, T, T}"/>.</typeparam>
	/// <param name="flags">The flags to set.</param>
	/// <summary>
	/// Sets the specified bit flags to 1 on the value.
	/// </summary>
	/// <param name="flags">The bit flags to set.</param>
	/// <returns>A reference to the value with the specified flags set.</returns>
	public static ref T SetFlags<T>(this ref T @this, T flags)
		where T : struct, IBitwiseOperators<T, T, T>
	{
		@this = @this | flags;
		return ref @this;
	}

	/// <summary>
	/// Clears to 0 (turns off) the specified <paramref name="flags"/>.
	/// </summary>
	/// <param name="this">A reference to the <typeparamref name="T"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <typeparam name="T">A value type that supports bitwise operators <see cref="IBitwiseOperators{T, T, T}"/>.</typeparam>
	/// <param name="flags">The flags to clear.</param>
	/// <summary>
	/// Clears (turns off) the specified bit flags in the value by performing a bitwise AND with the complement of the flags.
	/// </summary>
	/// <param name="flags">The bit flags to clear.</param>
	/// <returns>A reference to the modified value with the specified flags cleared.</returns>
	public static ref T ClearFlags<T>(this ref T @this, T flags)
		where T : struct, IBitwiseOperators<T, T, T>
	{
		@this &= ~flags;
		return ref @this;
	}

	/// <summary>
	/// Based on a Boolean value, either sets to 1 (turns on) or clears to 0 (turns off) the specified <paramref name="flags"/>.
	/// </summary>
	/// <param name="this">A reference to the <typeparamref name="T"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <param name="set">If set to <see langword="true"/> the specified <paramref name="flags"/> are set; otherwise they are cleared.</param>
	/// <param name="flags">The flags to either set or clear.</param>
	/// <summary>
	/// Sets or clears the specified bit flags on the instance based on the provided Boolean value.
	/// </summary>
	/// <param name="set">If true, the specified flags are set; if false, the flags are cleared.</param>
	/// <param name="flags">The bit flags to set or clear.</param>
	/// <returns>A reference to the modified instance.</returns>
	public static ref T SetOrClearFlags<T>(this ref T @this, bool set, T flags)
		where T : struct, IBitwiseOperators<T, T, T>
	{
		@this = set ? @this.SetFlags(flags) : @this.ClearFlags(flags);
		return ref @this;
	}
	#endregion Bit Flipping

	#region Bit Testing
	/// <summary>Determines whether <b>all</b> bit fields are set in the current instance.</summary>
	/// <typeparam name="T">
	///   A value type that supports bitwise and equality operators. See
	///   <see cref="IBitwiseOperators{TSelf, TOther, TResult}"/> and
	///   <see cref="IEqualityOperators{TSelf, TOther, TResult}"/>.
	/// </typeparam>
	/// <param name="flags">One or more bit flags to test.</param>
	/// <returns>
	///   <see langword="true" /> if the bit field or <b>all</b> bit fields that are set in <paramref name="flags" /> are also
	///   set in the current instance; otherwise, <see langword="false" />.
	/// <summary>
	/// Determines whether all specified bit flags are set in the value.
	/// </summary>
	/// <param name="flags">The bit flags to check for.</param>
	/// <returns>True if all bits in <paramref name="flags"/> are set in the value; otherwise, false.</returns>
	public static bool HasAllFlags<T>(this T @this, T flags)
	where T : struct, IBitwiseOperators<T, T, T>, IEqualityOperators<T, T, bool>
	{
		return (@this & flags) == flags;
	}

	/// <summary>Determines whether <b>any</b> bit fields are set in the current instance.</summary>
	/// <typeparam name="T">
	///   A value type that supports bitwise and equality operators. See
	///   <see cref="IBitwiseOperators{TSelf, TOther, TResult}"/> and
	///   <see cref="IEqualityOperators{TSelf, TOther, TResult}"/>.
	/// </typeparam>
	/// <param name="flags">One or more bit flags to test.</param>
	/// <returns>
	///   <see langword="true" /> if the bit field or <b>any</b> bit fields that are set in <paramref name="flags" /> are also
	///   set in the current instance; otherwise, <see langword="false" />.
	/// <summary>
	/// Determines whether any of the specified bit flags are set in the value.
	/// </summary>
	/// <param name="flags">The bit flags to check for.</param>
	/// <returns>True if at least one of the specified flags is set; otherwise, false.</returns>
	public static bool HasAnyFlag<T>(this T @this, T flags)
	where T : struct, IBitwiseOperators<T, T, T>, IEqualityOperators<T, T, bool>
	{
		return (@this & flags) != default(T);
	}
	#endregion Bit Testing
}
