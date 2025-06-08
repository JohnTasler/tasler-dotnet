using System.Runtime.CompilerServices;

namespace Tasler.Extensions;

/// <summary>Converts base data types to an array of bytes, and an array of bytes to base data types.</summary>
public static class BitConverterExtension
{
	/// <summary>Returns the specified Boolean value as a byte array.</summary>
	/// <param name="value">The value to convert.</param>
	/// <returns>A byte array with length 1.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this bool value) => BitConverter.GetBytes(value);

	/// <summary>Converts a Boolean into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted Boolean.</param>
	/// <param name="value">The Boolean to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.
	/// </returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, bool value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified Unicode character value as an array of bytes.</summary>
	/// <param name="value">The character to convert.</param>
	/// <returns>An array of bytes with length 2.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this char value) => BitConverter.GetBytes(value);

	/// <summary>Converts a character into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted character.</param>
	/// <param name="value">The character to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, char value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 16-bit signed integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>An array of bytes with length 2.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this short value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 16-bit signed integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted 16-bit signed integer.</param>
	/// <param name="value">The 16-bit signed integer to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, short value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 32-bit signed integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>An array of bytes with length 4.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this int value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 32-bit signed integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted 32-bit signed integer.</param>
	/// <param name="value">The 32-bit signed integer to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, int value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 64-bit signed integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>An array of bytes with length 8.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this long value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 64-bit signed integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted 64-bit signed integer.</param>
	/// <param name="value">The 64-bit signed integer to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, long value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 128-bit signed integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>An array of bytes with length 16.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this Int128 value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 128-bit signed integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted 128-bit signed integer.</param>
	/// <param name="value">The 128-bit signed integer to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, Int128 value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 16-bit unsigned integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>An array of bytes with length 2.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this ushort value) => BitConverter.GetBytes(value);

	/// <summary>Converts an unsigned 16-bit integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted unsigned 16-bit integer.</param>
	/// <param name="value">The unsigned 16-bit integer to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, ushort value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 32-bit unsigned integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>An array of bytes with length 4.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this uint value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 32-bit unsigned integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted unsigned 32-bit integer.</param>
	/// <param name="value">The unsigned 32-bit integer to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, uint value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 64-bit unsigned integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>An array of bytes with length 8.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this ulong value) => BitConverter.GetBytes(value);

	/// <summary>Converts an unsigned 64-bit integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted unsigned 64-bit integer.</param>
	/// <param name="value">The unsigned 64-bit integer to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, ulong value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 128-bit unsigned integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>An array of bytes with length 16.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this UInt128 value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 128-bit unsigned integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted 128-bit unsigned integer.</param>
	/// <param name="value">The 128-bit unsigned integer to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, UInt128 value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified half-precision floating-point value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>An array of bytes with length 2.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this Half value) => BitConverter.GetBytes(value);

	/// <summary>Converts a half-precision floating-point value into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted half-precision floating-point value.</param>
	/// <param name="value">The half-precision floating-point value to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, Half value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified single-precision floating point value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>An array of bytes with length 4.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this float value) => BitConverter.GetBytes(value);

	/// <summary>Converts a single-precision floating-point value into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted single-precision floating-point value.</param>
	/// <param name="value">The single-precision floating-point value to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, float value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified double-precision floating-point value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>An array of bytes with length 8.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this double value) => BitConverter.GetBytes(value);

	/// <summary>Converts a double-precision floating-point value into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted double-precision floating-point value.</param>
	/// <param name="value">The double-precision floating-point value to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, double value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns a Unicode character converted from two bytes at a specified position in a byte array.</summary>
	/// <param name="value">An array that includes the two bytes to convert.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> equals the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>The character formed by two bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static char ToChar(this byte[] value, int startIndex) => BitConverter.ToChar(value, startIndex);

	/// <summary>Converts a read-only byte span into a character.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than the length of a <see cref="T:System.Char" />.</exception>
	/// <returns>A character representing the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static char ToChar(this ReadOnlySpan<byte> value) => BitConverter.ToChar(value);

	/// <summary>Returns a 16-bit signed integer converted from two bytes at a specified position in a byte array.</summary>
	/// <param name="value">An array of bytes that includes the two bytes to convert.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> equals the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A 16-bit signed integer formed by two bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short ToInt16(this byte[] value, int startIndex) => BitConverter.ToInt16(value, startIndex);

	/// <summary>Converts a read-only byte span into a 16-bit signed integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 2.</exception>
	/// <returns>A 16-bit signed integer representing the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short ToInt16(this ReadOnlySpan<byte> value) => BitConverter.ToInt16(value);

	/// <summary>Returns a 32-bit signed integer converted from four bytes at a specified position in a byte array.</summary>
	/// <param name="value">An array of bytes that includes the four bytes to convert.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> is greater than or equal to the length of <paramref name="value" /> minus 3, and is less than or equal to the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A 32-bit signed integer formed by four bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ToInt32(this byte[] value, int startIndex) => BitConverter.ToInt32(value, startIndex);

	/// <summary>Converts a read-only byte span into a 32-bit signed integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 4.</exception>
	/// <returns>A 32-bit signed integer representing the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ToInt32(this ReadOnlySpan<byte> value) => BitConverter.ToInt32(value);

	/// <summary>Returns a 64-bit signed integer converted from eight bytes at a specified position in a byte array.</summary>
	/// <param name="value">An array of bytes that includes the eight bytes to convert.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> is greater than or equal to the length of <paramref name="value" /> minus 7, and is less than or equal to the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A 64-bit signed integer formed by eight bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long ToInt64(this byte[] value, int startIndex) => BitConverter.ToInt64(value, startIndex);

	/// <summary>Converts a read-only byte span into a 64-bit signed integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 8.</exception>
	/// <returns>A 64-bit signed integer representing the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long ToInt64(this ReadOnlySpan<byte> value) => BitConverter.ToInt64(value);

	/// <summary>Returns a 128-bit signed integer converted from sixteen bytes at a specified position in a byte array.</summary>
	/// <param name="value">An array of bytes.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> is greater than or equal to the length of <paramref name="value" /> minus 15,
	///       and is less than or equal to the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A 128-bit signed integer formed by sixteen bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Int128 ToInt128(this byte[] value, int startIndex) => BitConverter.ToInt128(value, startIndex);

	/// <summary>Converts a read-only byte span into a 128-bit signed integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 16.</exception>
	/// <returns>A 128-bit signed integer representing the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Int128 ToInt128(this ReadOnlySpan<byte> value) => BitConverter.ToInt128(value);

	/// <summary>Returns a 16-bit unsigned integer converted from two bytes at a specified position in a byte array.</summary>
	/// <param name="value">The array of bytes that includes the two bytes to convert.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> equals the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A 16-bit unsigned integer formed by two bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ushort ToUInt16(this byte[] value, int startIndex) => BitConverter.ToUInt16(value, startIndex);

	/// <summary>Converts a read-only byte-span into a 16-bit unsigned integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 2.</exception>
	/// <returns>An 16-bit unsigned integer representing the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ushort ToUInt16(this ReadOnlySpan<byte> value) => BitConverter.ToUInt16(value);

	/// <summary>Returns a 32-bit unsigned integer converted from four bytes at a specified position in a byte array.</summary>
	/// <param name="value">An array of bytes.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> is greater than or equal to the length of <paramref name="value" /> minus 3, and is less than or equal to the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A 32-bit unsigned integer formed by four bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint ToUInt32(this byte[] value, int startIndex) => BitConverter.ToUInt32(value, startIndex);

	/// <summary>Converts a read-only byte span into a 32-bit unsigned integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 4.</exception>
	/// <returns>A 32-bit unsigned integer representing the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint ToUInt32(this ReadOnlySpan<byte> value) => BitConverter.ToUInt32(value);

	/// <summary>Returns a 64-bit unsigned integer converted from eight bytes at a specified position in a byte array.</summary>
	/// <param name="value">An array of bytes that includes the eight bytes to convert.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> is greater than or equal to the length of <paramref name="value" /> minus 7, and is less than or equal to the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A 64-bit unsigned integer formed by the eight bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong ToUInt64(this byte[] value, int startIndex) => BitConverter.ToUInt64(value, startIndex);

	/// <summary>Converts bytes into an unsigned long.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 8.</exception>
	/// <returns>A 64-bit unsigned integer representing the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong ToUInt64(this ReadOnlySpan<byte> value) => BitConverter.ToUInt64(value);

	/// <summary>Returns a 128-bit unsigned integer converted from four bytes at a specified position in a byte array.</summary>
	/// <param name="value">An array of bytes.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> is greater than or equal to the length of <paramref name="value" /> minus 15,
	///       and is less than or equal to the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A 128-bit unsigned integer formed by sixteen bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static UInt128 ToUInt128(this byte[] value, int startIndex) => BitConverter.ToUInt128(value, startIndex);

	/// <summary>Converts a read-only byte span into a 128-bit unsigned integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 16.</exception>
	/// <returns>A 128-bit unsigned integer representing the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static UInt128 ToUInt128(this ReadOnlySpan<byte> value) => BitConverter.ToUInt128(value);

	/// <summary>Returns a half-precision floating point number converted from two bytes at a specified position in a byte array.</summary>
	/// <param name="value">An array of bytes that includes the two bytes to convert.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> equals the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A half-precision floating point number formed by two bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Half ToHalf(this byte[] value, int startIndex) => BitConverter.ToHalf(value, startIndex);

	/// <summary>Converts a read-only byte span into a half-precision floating-point value.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 2.</exception>
	/// <returns>A half-precision floating-point value that represents the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Half ToHalf(this ReadOnlySpan<byte> value) => BitConverter.ToHalf(value);

	/// <summary>Returns a single-precision floating point number converted from four bytes at a specified position in a byte array.</summary>
	/// <param name="value">An array of bytes.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> is greater than or equal to the length of <paramref name="value" /> minus 3, and is less than or equal to the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A single-precision floating point number formed by four bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float ToSingle(this byte[] value, int startIndex) => BitConverter.ToSingle(value, startIndex);

	/// <summary>Converts a read-only byte span into a single-precision floating-point value.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than the length of a <see cref="T:System.Single" /> value.</exception>
	/// <returns>A single-precision floating-point value representing the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float ToSingle(this ReadOnlySpan<byte> value) => BitConverter.ToSingle(value);

	/// <summary>Returns a double-precision floating point number converted from eight bytes at a specified position in a byte array.</summary>
	/// <param name="value">An array of bytes that includes the eight bytes to convert.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentException">
	///   <paramref name="startIndex" /> is greater than or equal to the length of <paramref name="value" /> minus 7, and is less than or equal to the length of <paramref name="value" /> minus 1.</exception>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A double-precision floating point number formed by eight bytes beginning at <paramref name="startIndex" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double ToDouble(this byte[] value, int startIndex) => BitConverter.ToDouble(value, startIndex);

	/// <summary>Converts a read-only byte span into a double-precision floating-point value.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than the length of a <see cref="T:System.Double" /> value.</exception>
	/// <returns>A double-precision floating-point value that represents the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double ToDouble(this ReadOnlySpan<byte> value) => BitConverter.ToDouble(value);

	/// <summary>Converts the numeric value of each element of a specified subarray of bytes to its equivalent hexadecimal string representation.</summary>
	/// <param name="value">An array of bytes that includes the bytes to convert.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <param name="length">The number of array elements in <paramref name="value" /> to convert.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> or <paramref name="length" /> is less than zero.
	///
	///  -or-
	///
	///  <paramref name="startIndex" /> is greater than zero and is greater than or equal to the length of <paramref name="value" />.</exception>
	/// <exception cref="T:System.ArgumentException">The combination of <paramref name="startIndex" /> and <paramref name="length" /> does not specify a position within <paramref name="value" />; that is, the <paramref name="startIndex" /> parameter is greater than the length of <paramref name="value" /> minus the <paramref name="length" /> parameter.</exception>
	/// <returns>A string of hexadecimal pairs separated by hyphens, where each pair represents the corresponding element in a subarray of <paramref name="value" />; for example, "7F-2C-4A-00".</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string ToString(this byte[] value, int startIndex, int length) => BitConverter.ToString(value, startIndex, length);

	/// <summary>Converts the numeric value of each element of a specified array of bytes to its equivalent hexadecimal string representation.</summary>
	/// <param name="value">An array of bytes.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <returns>A string of hexadecimal pairs separated by hyphens, where each pair represents the corresponding element in <paramref name="value" />; for example, "7F-2C-4A-00".</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string ToString(this byte[] value) => BitConverter.ToString(value);

	/// <summary>Converts the numeric value of each element of a specified subarray of bytes to its equivalent hexadecimal string representation.</summary>
	/// <param name="value">An array of bytes.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>A string of hexadecimal pairs separated by hyphens, where each pair represents the corresponding element in a subarray of <paramref name="value" />; for example, "7F-2C-4A-00".</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string ToString(this byte[] value, int startIndex) => BitConverter.ToString(value, startIndex);

	/// <summary>Returns a Boolean value converted from the byte at a specified position in a byte array.</summary>
	/// <param name="value">A byte array.</param>
	/// <param name="startIndex">The index of the byte within <paramref name="value" /> to convert.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <returns>
	///   <see langword="true" /> if the byte at <paramref name="startIndex" /> in <paramref name="value" /> is nonzero; otherwise, <see langword="false" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ToBoolean(this byte[] value, int startIndex) => BitConverter.ToBoolean(value, startIndex);

	/// <summary>Converts a read-only byte span to a Boolean value.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 1.</exception>
	/// <returns>A Boolean representing the converted bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ToBoolean(this ReadOnlySpan<byte> value) => BitConverter.ToBoolean(value);

	/// <summary>Converts the specified double-precision floating point number to a 64-bit signed integer.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>A 64-bit signed integer whose value is equivalent to <paramref name="value" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long DoubleToInt64Bits(this double value) => BitConverter.DoubleToInt64Bits(value);

	/// <summary>Reinterprets the specified 64-bit signed integer to a double-precision floating point number.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>A double-precision floating point number whose value is equivalent to <paramref name="value" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Int64BitsToDouble(this long value) => BitConverter.Int64BitsToDouble(value);

	/// <summary>Converts a single-precision floating-point value into an integer.</summary>
	/// <param name="value">The single-precision floating-point value to convert.</param>
	/// <returns>An integer representing the converted single-precision floating-point value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SingleToInt32Bits(this float value) => BitConverter.SingleToInt32Bits(value);

	/// <summary>Reinterprets the specified 32-bit integer as a single-precision floating-point value.</summary>
	/// <param name="value">The integer to convert.</param>
	/// <returns>A single-precision floating-point value that represents the converted integer.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Int32BitsToSingle(this int value) => BitConverter.Int32BitsToSingle(value);

	/// <summary>Converts a half-precision floating-point value into a 16-bit integer.</summary>
	/// <param name="value">The half-precision floating-point value to convert.</param>
	/// <returns>An integer representing the converted half-precision floating-point value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short HalfToInt16Bits(this Half value) => BitConverter.HalfToInt16Bits(value);

	/// <summary>Reinterprets the specified 16-bit signed integer value as a half-precision floating-point value.</summary>
	/// <param name="value">The 16-bit signed integer value to convert.</param>
	/// <returns>A half-precision floating-point value that represents the converted integer.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Half Int16BitsToHalf(this short value) => BitConverter.Int16BitsToHalf(value);

	/// <summary>Converts the specified double-precision floating point number to a 64-bit unsigned integer.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>A 64-bit unsigned integer whose bits are identical to <paramref name="value" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong DoubleToUInt64Bits(this double value) => BitConverter.DoubleToUInt64Bits(value);

	/// <summary>Converts the specified 64-bit unsigned integer to a double-precision floating point number.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>A double-precision floating point number whose bits are identical to <paramref name="value" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double UInt64BitsToDouble(this ulong value) => BitConverter.UInt64BitsToDouble(value);

	/// <summary>Converts the specified single-precision floating point number to a 32-bit unsigned integer.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>A 32-bit unsigned integer whose bits are identical to <paramref name="value" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint SingleToUInt32Bits(this float value) => BitConverter.SingleToUInt32Bits(value);

	/// <summary>Converts the specified 32-bit unsigned integer to a single-precision floating point number.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>A single-precision floating point number whose bits are identical to <paramref name="value" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float UInt32BitsToSingle(this uint value) => BitConverter.UInt32BitsToSingle(value);

	/// <summary>Converts the specified half-precision floating point number to a 16-bit unsigned integer.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>A 16-bit unsigned integer whose bits are identical to <paramref name="value" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ushort HalfToUInt16Bits(this Half value) => BitConverter.HalfToUInt16Bits(value);

	/// <summary>Converts the specified 16-bit unsigned integer to a half-precision floating point number.</summary>
	/// <param name="value">The number to convert.</param>
	/// <returns>A half-precision floating point number whose bits are identical to <paramref name="value" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Half UInt16BitsToHalf(this ushort value) => BitConverter.UInt16BitsToHalf(value);
}
