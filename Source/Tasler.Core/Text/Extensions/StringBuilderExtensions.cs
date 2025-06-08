using System.Text;
using CommunityToolkit.Diagnostics;

namespace Tasler.Text;

/// <summary>
/// Provides extension methods for the <see cref="StringBuilder"/> class.
/// </summary>
public static class StringBuilderExtensions
{
	/// <summary>
	/// Creates an <see cref="IEnumerable{T}"/> over all of the characters of the
	/// <see cref="StringBuilder"/> instance.
	/// </summary>
	/// <param name="sb">The <see cref="StringBuilder"/> on which to operate.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> which can be used to iterate over all of the
	/// characters of the <see cref="StringBuilder"/> instance.
	/// </returns>
	/// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <see langword="null"/>.</exception>
	public static IEnumerable<char> AsEnumerableOfChar(this StringBuilder sb)
	{
		Guard.IsNotNull(sb);

		return sb.AsEnumerableOfChar(0, sb.Length);
	}

	/// <summary>
	/// Creates an <see cref="IEnumerable{T}"/> over the characters in a specified section of the
	/// <see cref="StringBuilder"/> instance.
	/// </summary>
	/// <param name="sb">The <see cref="StringBuilder"/> on which to operate.</param>
	/// <param name="startIndex">The character startIndex from which to begin.</param>
	/// <param name="count">
	///   The number of characters to include. If -1 (the default) is specified, all characters from
	///   the <paramref name="startIndex"/> are included.
	/// </param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> over the characters in a specified section of the
	/// <see cref="StringBuilder"/> instance.
	/// </returns>
	/// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentOutOfRangeException">
	/// <paramref name="startIndex"/> is outside the range of valid indexes for <paramref name="sb"/>.
	/// -or- count is less than -1. -or- startIndex and count do not specify a valid section in
	/// <paramref name="sb"/>.
	/// </exception>
	public static IEnumerable<char> AsEnumerableOfChar(this StringBuilder sb, int startIndex, int count = -1)
	{
		Guard.IsNotNull(sb);
		var length = sb.Length;

		if (count == -1)
			count = length - startIndex;

		Guard.IsInRange(startIndex, 0, length);
		Guard.IsBetweenOrEqualTo(count, 0, length);

		var endIndex = startIndex + count;
		Guard.IsBetweenOrEqualTo(endIndex, 0, length);

		for (var index = startIndex; index < endIndex; ++index)
			yield return sb[index];
	}

	/// <summary>
	/// Discards the specified <paramref name="value"/> from the end of the <see cref="StringBuilder"/>
	/// if the <see cref="StringBuilder"/> ends with <see cref="value"/>.
	/// </summary>
	/// <param name="sb">The <see cref="StringBuilder"/> on which to operate.</param>
	/// <param name="value">The value to be removed from the end of the <see cref="StringBuilder"/>.</param>
	/// <returns>A reference to the <see cref="StringBuilder"/> instance after the operation has completed.</returns>
	/// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <see langword="null"/>.</exception>
	/// <remarks>
	/// <para>The string to discard is checked on an ordinal basis; that is, it is not culture-aware. If the end
	/// of the <see cref="StringBuilder"/> does not match <paramref name="value"/>, it is not changed. Also if the
	/// <paramref name="value"/> is null or an empty string, the <see cref="StringBuilder"/> is not changed.</para>
	/// <para>This method effectively does an undo of an immediate antecedent <see cref="StringBuilder.Append(string)"/> call.
	/// </para>
	/// </remarks>
	public static StringBuilder DiscardFromEnd(this StringBuilder sb, string? value)
	{
		Guard.IsNotNull(sb);

		if (!string.IsNullOrEmpty(value))
		{
			var count = value.Length;
			if (count <= sb.Length && value.SequenceEqual(sb.AsEnumerableOfChar(sb.Length - count, count)))
				sb.Length -= count;
		}

		return sb;
	}

	/// <summary>
	/// Discards the specified number of characters from the end of the <see cref="StringBuilder"/>.
	/// </summary>
	/// <param name="sb">The <see cref="StringBuilder"/> on which to operate.</param>
	/// <param name="count">
	/// The number of characters to remove from the end of the <see cref="StringBuilder"/>.
	/// </param>
	/// <returns>A reference to the <see cref="StringBuilder"/> instance after the operation has completed.</returns>
	/// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <see langword="null"/>.</exception>
	/// <exception cref="ArgumentOutOfRangeException">The <paramref name="count"/> is negative or greater than the
	/// length of <paramref name="sb"/>.</exception>
	/// <remarks>
	/// This method effectively does an undo of an immediate antecedent <see cref="StringBuilder.Append(string)"/> call.
	/// </remarks>
	public static StringBuilder DiscardCharsFromEnd(this StringBuilder sb, int count)
	{
		Guard.IsNotNull(sb);
		var length = sb.Length;
		Guard.IsBetweenOrEqualTo(count, 0, length);

		sb.Length -= count;
		return sb;
	}

	/// <summary>
	/// Discards the default line terminator from the end of the <see cref="StringBuilder"/> object.
	/// </summary>
	/// <param name="sb">The <see cref="StringBuilder"/> on which to operate.</param>
	/// <returns>A reference to the <see cref="StringBuilder"/> instance after the operation has completed.</returns>
	/// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <see langword="null"/>.</exception>
	/// <remarks>
	/// This method effectively does an undo of an immediate antecedent <see cref="StringBuilder.AppendLine(string)"/> call.
	/// </remarks>
	public static StringBuilder DiscardLineFromEnd(this StringBuilder sb)
	{
		Guard.IsNotNull(sb);

		if (sb.Length == sb.DiscardFromEnd(Environment.NewLine).Length)
			sb.DiscardFromEnd("\n");
		return sb;
	}

	/// <summary>
	/// Discards the specified string followed by the default line terminator from the end of the
	/// <see cref="StringBuilder"/> object if the <see cref="StringBuilder"/> ends with <see cref="value"/>.
	/// </summary>
	/// <param name="sb">The <see cref="StringBuilder"/> on which to operate.</param>
	/// <param name="value">The value.</param>
	/// <returns>
	/// A reference to the <see cref="StringBuilder"/> instance after the operation has completed.
	/// </returns>
	/// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <see langword="null"/>.</exception>
	/// <remarks>
	/// <para>The string to discard is checked on an ordinal basis; that is, it is not culture-aware.
	/// If the end of the <see cref="StringBuilder"/> does not match <paramref name="value"/> followed
	/// by the default line terminator, it is not changed.</para>
	/// <para>This method is intended to undo the effect of an immediate antecedent
	/// <see cref="StringBuilder.AppendLine(string)"/> call.</para>
	/// </remarks>
	public static StringBuilder DiscardLineFromEnd(this StringBuilder sb, string value)
	{
		sb.DiscardLineFromEnd();

		if (!string.IsNullOrEmpty(value))
			sb.DiscardFromEnd(value);

		return sb;
	}
}
