using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tasler
{
    // TODO: NEEDS_UNIT_TESTS

    /// <summary>
    /// Extension methods for the <see cref="StringBuilder"/> class.
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Creates an <see cref="IEnumerable{char}"/> over all of the characters of the
        /// <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder"/> on which to operate.</param>
        /// <returns>
        /// An <see cref="IEnumerable{char}"/> which can be used to iterate over all of the
        /// characters of the <see cref="StringBuilder"/> instance.
        /// </returns>
        /// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <c>null</c>.</exception>
        public static IEnumerable<char> AsEnumerable(this StringBuilder sb)
        {
            ValidateArgument.IsNotNull(sb, nameof(sb));

            return sb.AsEnumerable(0, sb.Length);
        }

        /// <summary>
        /// Creates an <see cref="IEnumerable{char}"/> over the characters in a specified section of the
        /// <see cref="StringBuilder"/> instance.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder"/> on which to operate.</param>
        /// <param name="startIndex">The character startIndex from which to begin.</param>
        /// <param name="count">The number of characters to include.</param>
        /// <returns>
        /// An <see cref="IEnumerable{char}"/> over the characters in a specified section of the
        /// <see cref="StringBuilder"/> instance.
        /// </returns>
        /// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> is outside the range of valid indexes for <paramref name="sb"/>.
        /// -or- count is less than zero. -or- startIndex and count do not specify a valid section in
        /// <paramref name="sb"/>.
        /// </exception>
        public static IEnumerable<char> AsEnumerable(this StringBuilder sb, int startIndex, int count)
        {
            var length = sb.Length;
            ValidateArgument.IsNotNull(sb, nameof(sb));
            ValidateArgument.IsInHalfOpenRange(startIndex, 0, length, nameof(startIndex));
            ValidateArgument.IsInHalfOpenRange(count, 0, length, nameof(count));

            var endIndex = startIndex + count;
            ValidateArgument.IsInHalfOpenRange(endIndex, 0, length, nameof(count));

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
        /// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <c>null</c>.</exception>
        /// <remarks>
        /// <para>The string to discard is checked on an ordinal basis; that is, it is not culture-aware. If the end
        /// of the <see cref="StringBuilder"/> does not match <paramref name="value"/>, it is not changed.</para>
        /// <para>This method is intended to undo the effect of an immediate antecedent
        /// <see cref="StringBuilder.Append"/> call.</para>
        /// </remarks>
        public static StringBuilder Discard(this StringBuilder sb, string value)
        {
            ValidateArgument.IsNotNull(sb, nameof(sb));

            if (!string.IsNullOrEmpty(value))
            {
                var count = value.Length;
                if (count <= sb.Length && value.SequenceEqual(sb.AsEnumerable(sb.Length - count, count)))
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
        /// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <c>null</c>.</exception>
        /// <remarks>
        /// This method is intended to undo the effect of an immediate antecedent <see cref="StringBuilder.Append"/> call.
        /// </remarks>
        public static StringBuilder DiscardChars(this StringBuilder sb, int count)
        {
            var length = sb.Length;
            ValidateArgument.IsNotNull(sb, nameof(sb));
            ValidateArgument.IsInHalfOpenRange(count, 0, length, nameof(count));

            return sb.Remove(length - count, count);
        }

        /// <summary>
        /// Discards the default line terminator from the end of the <see cref="StringBuilder"/> object.
        /// </summary>
        /// <param name="sb">The <see cref="StringBuilder"/> on which to operate.</param>
        /// <returns>A reference to the <see cref="StringBuilder"/> instance after the operation has completed.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <c>null</c>.</exception>
        /// <remarks>
        /// This method is intended to undo the effect of an immediate antecedent
        /// <see cref="StringBuilder.AppendLine"/> call.
        /// </remarks>
        public static StringBuilder DiscardLine(this StringBuilder sb)
        {
            ValidateArgument.IsNotNull(sb, nameof(sb));

            return sb.Discard(Environment.NewLine);
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
        /// <exception cref="ArgumentNullException">The <paramref name="sb"/> is <c>null</c>.</exception>
        /// <remarks>
        /// <para>The string to discard is checked on an ordinal basis; that is, it is not culture-aware.
        /// If the end of the <see cref="StringBuilder"/> does not match <paramref name="value"/> followed
        /// by the default line terminator, it is not changed.</para>
        /// <para>This method is intended to undo the effect of an immediate antecedent
        /// <see cref="StringBuilder.AppendLine"/> call.</para>
        /// </remarks>
        public static StringBuilder DiscardLine(this StringBuilder sb, string value)
        {
            sb.Discard(Environment.NewLine);

            if (!string.IsNullOrEmpty(value))
                sb.Discard(value);

            return sb;
        }
    }
}
