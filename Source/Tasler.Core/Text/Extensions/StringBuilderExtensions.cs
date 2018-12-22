using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tasler.Text
{
    // TODO: NEEDS_UNIT_TEST

    /// <summary>
    /// Provides extension methods for the <see cref="StringBuilder"/> class.
    /// </summary>
    public static class StringBuilderExtensions
    {
        public static StringBuilder Append(this StringBuilder @this, IEnumerable<char> characters)
        {
            foreach (var ch in characters)
                @this.Append(ch);

            return @this;
        }

        public static StringBuilder Append(this StringBuilder @this, ReadOnlySpan<char> span)
        {
            unsafe
            {
                fixed (char* chars = &MemoryMarshal.GetReference(span))
                {
                    @this.Append(chars, span.Length);
                }
            }
            return @this;
        }
    }
}
