using System.Runtime.CompilerServices;

namespace Tasler.Extensions;

/// <summary>Converts base data types to an array of bytes, and an array of bytes to base data types.</summary>
public static class BitConverterExtension
{
	/// <summary>Returns the specified Boolean value as a byte array.</summary>
	/// <param name="value">The value to convert.</param>
	/// <summary>
	/// Returns a byte array representing the specified Boolean value.
	/// </summary>
	/// <returns>A byte array of length 1 containing the byte representation of the Boolean value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this bool value) => BitConverter.GetBytes(value);

	/// <summary>Converts a Boolean into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted Boolean.</param>
	/// <param name="value">The Boolean to convert.</param>
	/// <returns>
	///   <see langword="true" /> if the conversion was successful; <see langword="false" /> otherwise.
	/// <summary>
	/// Attempts to write the byte representation of a Boolean value into the specified span.
	/// </summary>
	/// <param name="destination">The span to receive the byte representation.</param>
	/// <param name="value">The Boolean value to convert.</param>
	/// <returns>True if the operation succeeds; otherwise, false.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, bool value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified Unicode character value as an array of bytes.</summary>
	/// <param name="value">The character to convert.</param>
	/// <summary>
	/// Returns a byte array containing the binary representation of the specified char value.
	/// </summary>
	/// <returns>A 2-byte array representing the char.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this char value) => BitConverter.GetBytes(value);

	/// <summary>Converts a character into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted character.</param>
	/// <param name="value">The character to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of a <see cref="char"/> value into the provided span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The character value to convert.</param>
	/// <returns><see langword="true"/> if the bytes were successfully written; otherwise, <see langword="false"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, char value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 16-bit signed integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns a byte array containing the binary representation of the specified 16-bit signed integer.
	/// </summary>
	/// <returns>A byte array of length 2 representing the value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this short value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 16-bit signed integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted 16-bit signed integer.</param>
	/// <param name="value">The 16-bit signed integer to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of a 16-bit signed integer into the specified span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The 16-bit signed integer to convert.</param>
	/// <returns><see langword="true"/> if the bytes were written successfully; otherwise, <see langword="false"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, short value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 32-bit signed integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns the byte array representation of the specified 32-bit signed integer.
	/// </summary>
	/// <returns>A 4-byte array containing the binary representation of the integer.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this int value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 32-bit signed integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted 32-bit signed integer.</param>
	/// <param name="value">The 32-bit signed integer to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of a 32-bit signed integer into the specified span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The 32-bit signed integer to convert.</param>
	/// <returns><see langword="true"/> if the bytes were written successfully; otherwise, <see langword="false"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, int value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 64-bit signed integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns the byte array representation of the specified 64-bit signed integer.
	/// </summary>
	/// <returns>A byte array containing the bytes of the given long value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this long value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 64-bit signed integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted 64-bit signed integer.</param>
	/// <param name="value">The 64-bit signed integer to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of a 64-bit signed integer into the specified span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The 64-bit signed integer to convert.</param>
	/// <returns><see langword="true"/> if the bytes were written successfully; otherwise, <see langword="false"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, long value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 128-bit signed integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns a 16-byte array containing the binary representation of the specified 128-bit signed integer.
	/// </summary>
	/// <returns>A byte array of length 16 representing the value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this Int128 value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 128-bit signed integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted 128-bit signed integer.</param>
	/// <param name="value">The 128-bit signed integer to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of an <see cref="Int128"/> value into the provided span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The <see cref="Int128"/> value to convert.</param>
	/// <returns><see langword="true"/> if the bytes were written successfully; otherwise, <see langword="false"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, Int128 value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 16-bit unsigned integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns a byte array containing the binary representation of the specified 16-bit unsigned integer.
	/// </summary>
	/// <returns>A 2-byte array representing the value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this ushort value) => BitConverter.GetBytes(value);

	/// <summary>Converts an unsigned 16-bit integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted unsigned 16-bit integer.</param>
	/// <param name="value">The unsigned 16-bit integer to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of a 16-bit unsigned integer into the specified span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The 16-bit unsigned integer to convert.</param>
	/// <returns><see langword="true"/> if the bytes were successfully written; otherwise, <see langword="false"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, ushort value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 32-bit unsigned integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns the byte array representation of the specified 32-bit unsigned integer.
	/// </summary>
	/// <returns>A 4-byte array containing the bytes of the unsigned integer.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this uint value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 32-bit unsigned integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted unsigned 32-bit integer.</param>
	/// <param name="value">The unsigned 32-bit integer to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of a 32-bit unsigned integer into the specified span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The 32-bit unsigned integer to convert.</param>
	/// <returns><see langword="true"/> if the bytes were written successfully; otherwise, <see langword="false"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, uint value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 64-bit unsigned integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns the byte array representation of the specified 64-bit unsigned integer.
	/// </summary>
	/// <returns>A byte array containing the bytes of the given ulong value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this ulong value) => BitConverter.GetBytes(value);

	/// <summary>Converts an unsigned 64-bit integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted unsigned 64-bit integer.</param>
	/// <param name="value">The unsigned 64-bit integer to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of the specified 64-bit unsigned integer into the provided span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The 64-bit unsigned integer to convert.</param>
	/// <returns><see langword="true"/> if the bytes were written successfully; otherwise, <see langword="false"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, ulong value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified 128-bit unsigned integer value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns a byte array containing the binary representation of the specified 128-bit unsigned integer.
	/// </summary>
	/// <returns>A 16-byte array representing the value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this UInt128 value) => BitConverter.GetBytes(value);

	/// <summary>Converts a 128-bit unsigned integer into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted 128-bit unsigned integer.</param>
	/// <param name="value">The 128-bit unsigned integer to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of a 128-bit unsigned integer into the specified span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The 128-bit unsigned integer to convert.</param>
	/// <returns><see langword="true"/> if the bytes were successfully written; otherwise, <see langword="false"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, UInt128 value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified half-precision floating-point value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns a byte array containing the binary representation of the specified half-precision floating-point value.
	/// </summary>
	/// <returns>A 2-byte array representing the half-precision float.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this Half value) => BitConverter.GetBytes(value);

	/// <summary>Converts a half-precision floating-point value into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted half-precision floating-point value.</param>
	/// <param name="value">The half-precision floating-point value to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of a half-precision floating-point value into the provided span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The half-precision floating-point value to convert.</param>
	/// <returns><see langword="true" /> if the bytes were successfully written; otherwise, <see langword="false" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, Half value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified single-precision floating point value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns the byte array representation of the specified single-precision floating-point value.
	/// </summary>
	/// <returns>A 4-byte array containing the binary representation of the float value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this float value) => BitConverter.GetBytes(value);

	/// <summary>Converts a single-precision floating-point value into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted single-precision floating-point value.</param>
	/// <param name="value">The single-precision floating-point value to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of a single-precision floating-point value into the provided span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The single-precision floating-point value to convert.</param>
	/// <returns><see langword="true" /> if the bytes were written successfully; otherwise, <see langword="false" />.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryWriteBytes(this Span<byte> destination, float value) => BitConverter.TryWriteBytes(destination, value);

	/// <summary>Returns the specified double-precision floating-point value as an array of bytes.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns the byte array representation of the specified double-precision floating-point value.
	/// </summary>
	/// <returns>A byte array containing the bytes of the double value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static byte[] GetBytes(this double value) => BitConverter.GetBytes(value);

	/// <summary>Converts a double-precision floating-point value into a span of bytes.</summary>
	/// <param name="destination">When this method returns, the bytes representing the converted double-precision floating-point value.</param>
	/// <param name="value">The double-precision floating-point value to convert.</param>
	/// <returns>
	/// <summary>
	/// Attempts to write the byte representation of a double-precision floating-point value into the specified span.
	/// </summary>
	/// <param name="destination">The span to receive the bytes.</param>
	/// <param name="value">The double value to convert.</param>
	/// <returns><see langword="true" /> if the bytes were written successfully; otherwise, <see langword="false" />.</returns>
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
	/// <summary>
	/// Converts two bytes from the specified array, starting at the given index, to a Unicode character.
	/// </summary>
	/// <param name="value">The byte array containing the bytes to convert.</param>
	/// <param name="startIndex">The zero-based index of the first byte to convert.</param>
	/// <returns>The character represented by the two bytes at the specified position.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static char ToChar(this byte[] value, int startIndex) => BitConverter.ToChar(value, startIndex);

	/// <summary>Converts a read-only byte span into a character.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than the length of a <see cref="T:System.Char" />.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a Unicode character.
	/// </summary>
	/// <param name="value">The span containing the bytes to convert.</param>
	/// <returns>The character represented by the first two bytes of the span.</returns>
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
	/// <summary>
	/// Converts two bytes from the specified array, starting at the given index, to a 16-bit signed integer.
	/// </summary>
	/// <param name="value">The byte array containing the data.</param>
	/// <param name="startIndex">The index of the first byte to convert.</param>
	/// <returns>A 16-bit signed integer represented by the two bytes starting at <paramref name="startIndex"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short ToInt16(this byte[] value, int startIndex) => BitConverter.ToInt16(value, startIndex);

	/// <summary>Converts a read-only byte span into a 16-bit signed integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 2.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a 16-bit signed integer.
	/// </summary>
	/// <returns>The 16-bit signed integer represented by the first two bytes of the span.</returns>
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
	/// <summary>
	/// Converts four bytes from the specified array starting at the given index to a 32-bit signed integer.
	/// </summary>
	/// <param name="value">The byte array containing the bytes to convert.</param>
	/// <param name="startIndex">The index in the array at which to begin conversion.</param>
	/// <returns>A 32-bit signed integer represented by the specified bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int ToInt32(this byte[] value, int startIndex) => BitConverter.ToInt32(value, startIndex);

	/// <summary>Converts a read-only byte span into a 32-bit signed integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 4.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a 32-bit signed integer.
	/// </summary>
	/// <returns>The 32-bit signed integer represented by the specified bytes.</returns>
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
	/// <summary>
	/// Converts eight bytes from the specified array starting at the given index to a 64-bit signed integer.
	/// </summary>
	/// <param name="value">The byte array containing the bytes to convert.</param>
	/// <param name="startIndex">The starting position within the array.</param>
	/// <returns>A 64-bit signed integer represented by the specified bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long ToInt64(this byte[] value, int startIndex) => BitConverter.ToInt64(value, startIndex);

	/// <summary>Converts a read-only byte span into a 64-bit signed integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 8.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a 64-bit signed integer.
	/// </summary>
	/// <returns>The 64-bit signed integer represented by the specified bytes.</returns>
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
	/// <summary>
	/// Converts sixteen bytes from the specified array starting at the given index to a 128-bit signed integer.
	/// </summary>
	/// <param name="value">The byte array containing the bytes to convert.</param>
	/// <param name="startIndex">The starting position within the array.</param>
	/// <returns>A 128-bit signed integer represented by the specified bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Int128 ToInt128(this byte[] value, int startIndex) => BitConverter.ToInt128(value, startIndex);

	/// <summary>Converts a read-only byte span into a 128-bit signed integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 16.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a 128-bit signed integer.
	/// </summary>
	/// <returns>The 128-bit signed integer represented by the specified bytes.</returns>
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
	/// <summary>
	/// Converts two bytes from the specified array, starting at the given index, to a 16-bit unsigned integer.
	/// </summary>
	/// <param name="value">The byte array containing the bytes to convert.</param>
	/// <param name="startIndex">The index of the first byte to convert.</param>
	/// <returns>A 16-bit unsigned integer represented by the two bytes starting at <paramref name="startIndex"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ushort ToUInt16(this byte[] value, int startIndex) => BitConverter.ToUInt16(value, startIndex);

	/// <summary>Converts a read-only byte-span into a 16-bit unsigned integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 2.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a 16-bit unsigned integer.
	/// </summary>
	/// <returns>The 16-bit unsigned integer represented by the first two bytes of the span.</returns>
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
	/// <summary>
	/// Converts four bytes from the specified array starting at the given index to a 32-bit unsigned integer.
	/// </summary>
	/// <param name="value">The byte array containing the bytes to convert.</param>
	/// <param name="startIndex">The index in the array at which to begin conversion.</param>
	/// <returns>The 32-bit unsigned integer represented by the specified bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint ToUInt32(this byte[] value, int startIndex) => BitConverter.ToUInt32(value, startIndex);

	/// <summary>Converts a read-only byte span into a 32-bit unsigned integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 4.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a 32-bit unsigned integer.
	/// </summary>
	/// <returns>The 32-bit unsigned integer represented by the first four bytes of the span.</returns>
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
	/// <summary>
	/// Converts eight bytes from the specified array starting at the given index to a 64-bit unsigned integer.
	/// </summary>
	/// <param name="value">The byte array containing the bytes to convert.</param>
	/// <param name="startIndex">The starting position within the array.</param>
	/// <returns>A 64-bit unsigned integer represented by the specified bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong ToUInt64(this byte[] value, int startIndex) => BitConverter.ToUInt64(value, startIndex);

	/// <summary>Converts bytes into an unsigned long.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 8.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a 64-bit unsigned integer.
	/// </summary>
	/// <returns>The 64-bit unsigned integer represented by the specified bytes.</returns>
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
	/// <summary>
	/// Converts sixteen bytes from the specified array starting at the given index to a 128-bit unsigned integer.
	/// </summary>
	/// <param name="value">The byte array containing the bytes to convert.</param>
	/// <param name="startIndex">The starting position within the array.</param>
	/// <returns>A 128-bit unsigned integer represented by the specified bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static UInt128 ToUInt128(this byte[] value, int startIndex) => BitConverter.ToUInt128(value, startIndex);

	/// <summary>Converts a read-only byte span into a 128-bit unsigned integer.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 16.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a 128-bit unsigned integer.
	/// </summary>
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
	/// <summary>
	/// Converts two bytes from the specified array, starting at the given index, to a half-precision floating-point value.
	/// </summary>
	/// <param name="value">The byte array containing the bytes to convert.</param>
	/// <param name="startIndex">The zero-based index at which to begin conversion.</param>
	/// <returns>The half-precision floating-point value represented by the specified bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Half ToHalf(this byte[] value, int startIndex) => BitConverter.ToHalf(value, startIndex);

	/// <summary>Converts a read-only byte span into a half-precision floating-point value.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 2.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a half-precision floating-point value.
	/// </summary>
	/// <returns>The half-precision floating-point value represented by the bytes.</returns>
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
	/// <summary>
	/// Converts four bytes from the specified array starting at the given index to a single-precision floating-point number.
	/// </summary>
	/// <param name="value">The byte array containing the value to convert.</param>
	/// <param name="startIndex">The starting position within the array.</param>
	/// <returns>The single-precision floating-point number represented by the specified bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float ToSingle(this byte[] value, int startIndex) => BitConverter.ToSingle(value, startIndex);

	/// <summary>Converts a read-only byte span into a single-precision floating-point value.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than the length of a <see cref="T:System.Single" /> value.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a single-precision floating-point value.
	/// </summary>
	/// <returns>The single-precision floating-point value represented by the specified bytes.</returns>
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
	/// <summary>
	/// Converts eight bytes from the specified array starting at the given index to a double-precision floating-point number.
	/// </summary>
	/// <param name="value">The byte array containing the value to convert.</param>
	/// <param name="startIndex">The starting position within the array.</param>
	/// <returns>A double-precision floating-point number represented by the specified bytes.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double ToDouble(this byte[] value, int startIndex) => BitConverter.ToDouble(value, startIndex);

	/// <summary>Converts a read-only byte span into a double-precision floating-point value.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than the length of a <see cref="T:System.Double" /> value.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a double-precision floating-point value.
	/// </summary>
	/// <param name="value">The span of bytes to convert.</param>
	/// <returns>A double-precision floating-point value represented by the specified bytes.</returns>
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
	/// <summary>
	/// Converts a subarray of bytes to a hyphen-separated hexadecimal string.
	/// </summary>
	/// <param name="value">The byte array to convert.</param>
	/// <param name="startIndex">The starting index of the subarray.</param>
	/// <param name="length">The number of bytes to include in the conversion.</param>
	/// <returns>A string of hexadecimal pairs separated by hyphens, where each pair represents the corresponding element in the specified subarray; for example, "7F-2C-4A-00".</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string ToString(this byte[] value, int startIndex, int length) => BitConverter.ToString(value, startIndex, length);

	/// <summary>Converts the numeric value of each element of a specified array of bytes to its equivalent hexadecimal string representation.</summary>
	/// <param name="value">An array of bytes.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <summary>
	/// Converts the entire byte array to a hyphen-separated hexadecimal string.
	/// </summary>
	/// <returns>A string of hexadecimal pairs separated by hyphens, where each pair represents the corresponding element in <paramref name="value"/>; for example, "7F-2C-4A-00".</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static string ToString(this byte[] value) => BitConverter.ToString(value);

	/// <summary>Converts the numeric value of each element of a specified subarray of bytes to its equivalent hexadecimal string representation.</summary>
	/// <param name="value">An array of bytes.</param>
	/// <param name="startIndex">The starting position within <paramref name="value" />.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///   <paramref name="value" /> is <see langword="null" />.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">
	///   <paramref name="startIndex" /> is less than zero or greater than the length of <paramref name="value" /> minus 1.</exception>
	/// <summary>
	/// Converts a subarray of bytes to a hyphen-separated hexadecimal string representation.
	/// </summary>
	/// <param name="value">The byte array to convert.</param>
	/// <param name="startIndex">The starting index of the subarray to convert.</param>
	/// <returns>A string of hexadecimal pairs separated by hyphens, where each pair represents the corresponding element in the subarray; for example, "7F-2C-4A-00".</returns>
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
	/// <summary>
	/// Converts the byte at the specified index in the array to a Boolean value.
	/// </summary>
	/// <param name="value">The byte array containing the value to convert.</param>
	/// <param name="startIndex">The index of the byte to convert.</param>
	/// <returns><see langword="true"/> if the byte at <paramref name="startIndex"/> is nonzero; otherwise, <see langword="false"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ToBoolean(this byte[] value, int startIndex) => BitConverter.ToBoolean(value, startIndex);

	/// <summary>Converts a read-only byte span to a Boolean value.</summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException">The length of <paramref name="value" /> is less than 1.</exception>
	/// <summary>
	/// Converts a read-only span of bytes to a Boolean value.
	/// </summary>
	/// <param name="value">A read-only span containing the bytes to convert.</param>
	/// <returns>The Boolean value represented by the first byte of the span.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool ToBoolean(this ReadOnlySpan<byte> value) => BitConverter.ToBoolean(value);

	/// <summary>Converts the specified double-precision floating point number to a 64-bit signed integer.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Converts the bit pattern of a double-precision floating-point value to a 64-bit signed integer.
	/// </summary>
	/// <param name="value">The double-precision floating-point value to convert.</param>
	/// <returns>A 64-bit signed integer representing the bitwise equivalent of the specified double value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static long DoubleToInt64Bits(this double value) => BitConverter.DoubleToInt64Bits(value);

	/// <summary>Reinterprets the specified 64-bit signed integer to a double-precision floating point number.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Converts a 64-bit signed integer bit pattern to its equivalent double-precision floating-point value.
	/// </summary>
	/// <param name="value">The 64-bit signed integer whose bit pattern will be interpreted as a double.</param>
	/// <returns>The double-precision floating-point value represented by the specified bit pattern.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double Int64BitsToDouble(this long value) => BitConverter.Int64BitsToDouble(value);

	/// <summary>Converts a single-precision floating-point value into an integer.</summary>
	/// <param name="value">The single-precision floating-point value to convert.</param>
	/// <summary>
	/// Returns the bitwise representation of a single-precision floating-point value as a 32-bit signed integer.
	/// </summary>
	/// <param name="value">The single-precision floating-point value to convert.</param>
	/// <returns>The 32-bit signed integer representing the bit pattern of the input value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SingleToInt32Bits(this float value) => BitConverter.SingleToInt32Bits(value);

	/// <summary>Reinterprets the specified 32-bit integer as a single-precision floating-point value.</summary>
	/// <param name="value">The integer to convert.</param>
	/// <summary>
	/// Converts a 32-bit signed integer bit pattern to its equivalent single-precision floating-point value.
	/// </summary>
	/// <returns>The single-precision floating-point value represented by the specified bit pattern.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float Int32BitsToSingle(this int value) => BitConverter.Int32BitsToSingle(value);

	/// <summary>Converts a half-precision floating-point value into a 16-bit integer.</summary>
	/// <param name="value">The half-precision floating-point value to convert.</param>
	/// <summary>
	/// Converts a half-precision floating-point value to its 16-bit signed integer bit representation.
	/// </summary>
	/// <param name="value">The half-precision floating-point value to convert.</param>
	/// <returns>The 16-bit signed integer representing the bit pattern of the half-precision value.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short HalfToInt16Bits(this Half value) => BitConverter.HalfToInt16Bits(value);

	/// <summary>Reinterprets the specified 16-bit signed integer value as a half-precision floating-point value.</summary>
	/// <param name="value">The 16-bit signed integer value to convert.</param>
	/// <summary>
	/// Converts a 16-bit signed integer bit pattern to its equivalent half-precision floating-point value.
	/// </summary>
	/// <param name="value">The 16-bit signed integer whose bit pattern will be interpreted as a half-precision float.</param>
	/// <returns>A half-precision floating-point value represented by the specified bit pattern.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Half Int16BitsToHalf(this short value) => BitConverter.Int16BitsToHalf(value);

	/// <summary>Converts the specified double-precision floating point number to a 64-bit unsigned integer.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns the 64-bit unsigned integer representation of the specified double-precision floating-point value's bit pattern.
	/// </summary>
	/// <param name="value">The double-precision floating-point number to convert.</param>
	/// <returns>A 64-bit unsigned integer whose bits correspond to the bit pattern of <paramref name="value"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ulong DoubleToUInt64Bits(this double value) => BitConverter.DoubleToUInt64Bits(value);

	/// <summary>Converts the specified 64-bit unsigned integer to a double-precision floating point number.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Converts a 64-bit unsigned integer bit pattern to its equivalent double-precision floating-point value.
	/// </summary>
	/// <param name="value">The 64-bit unsigned integer whose bit pattern will be interpreted as a double.</param>
	/// <returns>A double-precision floating-point number with the same bit representation as <paramref name="value"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static double UInt64BitsToDouble(this ulong value) => BitConverter.UInt64BitsToDouble(value);

	/// <summary>Converts the specified single-precision floating point number to a 32-bit unsigned integer.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns the 32-bit unsigned integer representation of the bit pattern of the specified single-precision floating-point value.
	/// </summary>
	/// <param name="value">The single-precision floating-point value to convert.</param>
	/// <returns>A 32-bit unsigned integer whose bits correspond to those of <paramref name="value"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint SingleToUInt32Bits(this float value) => BitConverter.SingleToUInt32Bits(value);

	/// <summary>Converts the specified 32-bit unsigned integer to a single-precision floating point number.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Converts a 32-bit unsigned integer bit pattern to its equivalent single-precision floating-point value.
	/// </summary>
	/// <param name="value">The 32-bit unsigned integer whose bit pattern will be interpreted as a float.</param>
	/// <returns>A single-precision floating-point number with the same bit representation as <paramref name="value"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static float UInt32BitsToSingle(this uint value) => BitConverter.UInt32BitsToSingle(value);

	/// <summary>Converts the specified half-precision floating point number to a 16-bit unsigned integer.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Returns the 16-bit unsigned integer representation of the specified half-precision floating-point value's bit pattern.
	/// </summary>
	/// <param name="value">The half-precision floating-point value to convert.</param>
	/// <returns>A 16-bit unsigned integer whose bits correspond to the bit pattern of <paramref name="value"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ushort HalfToUInt16Bits(this Half value) => BitConverter.HalfToUInt16Bits(value);

	/// <summary>Converts the specified 16-bit unsigned integer to a half-precision floating point number.</summary>
	/// <param name="value">The number to convert.</param>
	/// <summary>
	/// Converts a 16-bit unsigned integer bit pattern to its equivalent half-precision floating-point value.
	/// </summary>
	/// <param name="value">The 16-bit unsigned integer whose bit pattern will be interpreted as a half-precision float.</param>
	/// <returns>A half-precision floating-point number with the same bit representation as <paramref name="value"/>.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Half UInt16BitsToHalf(this ushort value) => BitConverter.UInt16BitsToHalf(value);
}
