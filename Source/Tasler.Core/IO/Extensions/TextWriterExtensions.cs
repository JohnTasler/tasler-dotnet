using System;
using System.IO;

namespace Tasler.IO.Extensions
{
    public static class TextWriterExtensions
    {
        public static void Write(this TextWriter @this, ReadOnlySpan<char> span) => @this.Write(span.ToArray());
    }
}
