using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using Tasler.Properties;

namespace Tasler.Extensions;

/// <summary>
/// Provides extension methods for enum's.
/// </summary>
public static class EnumExtensions
{
	#region Bit Flipping

	/// <summary>
	/// Sets to 1 (turns on) the specified <paramref name="flags"/>.
	/// </summary>
	/// <param name="this">The <typeparamref name="T"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <param name="flags">The flags.</param>
	/// <returns>The <paramref name="this"/> with the specified <paramref name="flags"/> set to 1 (turned on).</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ref T SetFlags<T>(this ref T @this, T flags)
		where T : struct, Enum, IConvertible
	{
		var unsignedSelf = IsEnumBitFlags(@this).ToUInt64(null);
		var unsignedFlags = flags.ToUInt64(null);
		var unsignedResult = unsignedSelf | unsignedFlags;

		@this = (T)Enum.ToObject(typeof(T), unsignedResult);
		return ref @this;
	}

	/// <summary>
	/// Clears to 0 (turns off) the specified <paramref name="flags"/>.
	/// </summary>
	/// <param name="this">The <typeparamref name="T"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <param name="flags">The flags.</param>
	/// <returns>The <paramref name="this"/> with the specified <paramref name="flags"/> cleared to 0 (turned off).</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ref T ClearFlags<T>(this ref T @this, T flags)
		where T : struct, Enum, IConvertible
	{
		var unsignedSelf = IsEnumBitFlags(@this).ToUInt64(null);
		var unsignedFlags = flags.ToUInt64(null);
		var unsignedResult = unsignedSelf & ~unsignedFlags;

		@this = (T)Enum.ToObject(typeof(T), unsignedResult);
		return ref @this;
	}

	/// <summary>
	/// Based on a Boolean value, either sets to 1 (turns on) or clears to 0 (turns off) the specified <paramref name="flags"/>.
	/// </summary>
	/// <param name="this">The <typeparamref name="T"/> instance on which the extension method operates.
	/// As an extension method, this is typically not specified explicitly.</param>
	/// <param name="set">If set to <see langword="true"/> the specified <paramref name="flags"/> are set; otherwise they are cleared.</param>
	/// <param name="flags">The flags to either set or clear.</param>
	/// <returns>
	/// The <paramref name="this"/> with the specified <paramref name="flags"/> either set or cleared
	/// based on the <paramref name="set"/> parameter.
	/// </returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T SetOrClearFlags<T>(this ref T @this, bool set, T flags)
		where T : struct, Enum, IConvertible
	{
		return set ? @this.SetFlags(flags) : @this.ClearFlags(flags);
	}

	#endregion Bit Flipping

	#region Bit Testing
	/// <summary>Determines whether <b>all</b> bit fields are set in the current instance.</summary>
	/// <typeparam name="T">A enum type that is marked with the <see cref="FlagsAttribute"/>.</typeparam>
	/// <param name="flags">One or more bit flags to test.</param>
	/// <returns>
	///   <see langword="true" /> if the bit field or <b>all</b> bit fields that are set in
	///   <paramref name="flags" /> are also set in the current instance;
	///   otherwise, <see langword="false" />.
	/// </returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HasAllFlags<T>(this T @this, T flags)
		where T : struct, Enum, IConvertible
	{
		@this.IsEnumBitFlags(); // Ensure that the enum is a bit flags enum
		var unsignedSelf = @this.ToUInt64(null);
		var unsignedFlags = flags.ToUInt64(null);
		return (unsignedSelf & unsignedFlags) == unsignedFlags;
	}

	/// <summary>Determines whether <b>any</b> bit fields are set in the current instance.</summary>
	/// <typeparam name="T">A enum type that is marked with the <see cref="FlagsAttribute"/>.</typeparam>
	/// <param name="flags">One or more bit flags to test.</param>
	/// <returns>
	///   <see langword="true" /> if the bit field or <b>any</b> bit fields that are set in
	///   <paramref name="flags" /> are also set in the current instance;
	///   otherwise, <see langword="false" />.
	/// <summary>
	/// Determines whether any of the specified flag bits are set on the enum instance.
	/// </summary>
	/// <param name="@this">The enum value to test.</param>
	/// <param name="flags">The flag or combination of flags to check for.</param>
	/// <returns>`true` if any bit in <paramref name="flags"/> is set on <paramref name="@this"/>, `false` otherwise.</returns>
	/// <exception cref="InvalidEnumArgumentException">Thrown in DEBUG builds when <typeparamref name="T"/> is not a flags-capable enum (not marked with <see cref="FlagsAttribute"/> and not using an unsigned underlying type).</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HasAnyFlag<T>(this T @this, T flags)
		where T : struct, Enum, IConvertible
	{
		@this.IsEnumBitFlags(); // Ensure that the enum is a bit flags enum
		var unsignedSelf = @this.ToUInt64(null);
		var unsignedFlags = flags.ToUInt64(null);
		return (unsignedSelf & unsignedFlags) != default(ulong);
	}
	#endregion Bit Testing

#if !DEBUG
	/// <summary>
	/// Validates that the enum type is suitable for bit-flag operations and returns the original value.
	/// </summary>
	/// <typeparam name="T">The enum type to validate.</typeparam>
	/// <returns>The original enum value.</returns>
	/// <exception cref="InvalidEnumArgumentException">In DEBUG builds, thrown when the enum's underlying type is not an unsigned numeric type and the enum is not marked with <see cref="FlagsAttribute"/>.</exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif
	private static T IsEnumBitFlags<T>(this T @this)
		where T : Enum, IConvertible
	{
	#if DEBUG
		var underlyingType = Enum.GetUnderlyingType(typeof(T));
		if (!typeof(IUnsignedNumber<uint>).IsAssignableFrom(underlyingType)
			&& !typeof(IUnsignedNumber<ushort>).IsAssignableFrom(underlyingType)
			&& !typeof(IUnsignedNumber<ulong>).IsAssignableFrom(underlyingType)
			&& !typeof(T).GetCustomAttributes<FlagsAttribute>(false).Any())
		{
			throw new InvalidEnumArgumentException(string.Format(Resources.EnumNotFlagsExceptionFormat1, typeof(T).FullName));
		}
	#endif

		return @this;
	}
}