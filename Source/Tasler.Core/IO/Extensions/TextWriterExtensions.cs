using System;
using System.IO;

namespace Tasler.IO
{
    public static class TextWriterExtensions
    {
        public static void Write(this TextWriter @this, ReadOnlySpan<char> span) => @this.Write(span.ToArray());

        public static T Append<T>(this T @this, ReadOnlySpan<char> span)
            where T : TextWriter
        {
            @this.Write(span.ToArray());
            return @this;
        }

        public static T Append<T>(this T @this, ulong value)
            where T : TextWriter
        {
            @this.Write(value);
            return @this;
        }

        public static T Append<T>(this T @this, uint value)
            where T : TextWriter
        {
            @this.Write(value);
            return @this;
        }

        public static T Append<T>(this T @this, string format, params object[] arg)
            where T : TextWriter
        {
            @this.Write(format, arg);
            return @this;
        }

        public static T Append<T>(this T @this, string format, object arg0, object arg1, object arg2)
            where T : TextWriter
        {
            @this.Write(format, arg0, arg1, arg2);
            return @this;
        }

        public static T Append<T>(this T @this, string format, object arg0, object arg1)
            where T : TextWriter
        {
            @this.Write(format, arg0, arg1);
            return @this;
        }

        public static T Append<T>(this T @this, string format, object arg0)
            where T : TextWriter
        {
            @this.Write(format, arg0);
            return @this;
        }

        public static T Append<T>(this T @this, string value)
            where T : TextWriter
        {
            @this.Write(value);
            return @this;
        }

        public static T Append<T>(this T @this, object value)
            where T : TextWriter
        {
            @this.Write(value);
            return @this;
        }

        public static T Append<T>(this T @this, long value)
            where T : TextWriter
        {
            @this.Write(value);
            return @this;
        }

        public static T Append<T>(this T @this, int value)
            where T : TextWriter
        {
            @this.Write(value);
            return @this;
        }

        public static T Append<T>(this T @this, double value)
            where T : TextWriter
        {
            @this.Write(value);
            return @this;
        }

        public static T Append<T>(this T @this, decimal value)
            where T : TextWriter
        {
            @this.Write(value);
            return @this;
        }

        public static T Append<T>(this T @this, char[] buffer, int index, int count)
            where T : TextWriter
        {
            @this.Write(buffer, index, count);
            return @this;
        }

        public static T Append<T>(this T @this, char[] buffer)
            where T : TextWriter
        {
            @this.Write(buffer);
            return @this;
        }

        public static T Append<T>(this T @this, char value)
            where T : TextWriter
        {
            @this.Write(value);
            return @this;
        }

        public static T Append<T>(this T @this, bool value)
            where T : TextWriter
        {
            @this.Write(value);
            return @this;
        }

        public static T Append<T>(this T @this, float value)
            where T : TextWriter
        {
            @this.Write(value);
            return @this;
        }

        public static T AppendLine<T>(this T @this, string format, object arg0)
            where T : TextWriter
        {
            @this.WriteLine(format, arg0);
            return @this;
        }

        public static T AppendLine<T>(this T @this, ulong value)
            where T : TextWriter
        {
            @this.WriteLine(value);
            return @this;
        }

        public static T AppendLine<T>(this T @this, uint value)
            where T : TextWriter
        {
            @this.WriteLine(value);
            return @this;
        }

        public static T AppendLine<T>(this T @this, string format, params object[] arg)
            where T : TextWriter
        {
            @this.WriteLine(format, arg);
            return @this;
        }

        public static T AppendLine<T>(this T @this, string format, object arg0, object arg1, object arg2)
            where T : TextWriter
        {
            @this.WriteLine(format, arg0, arg1, arg2);
            return @this;
        }

        public static T AppendLine<T>(this T @this, string format, object arg0, object arg1)
            where T : TextWriter
        {
            @this.WriteLine(format, arg0, arg1);
            return @this;
        }

        public static T AppendLine<T>(this T @this, string value)
            where T : TextWriter
        {
            @this.WriteLine(value);
            return @this;
        }

        public static T AppendLine<T>(this T @this, float value)
            where T : TextWriter
        {
            @this.WriteLine(value);
            return @this;
        }

        public static T AppendLine<T>(this T @this)
            where T : TextWriter
        {
            @this.WriteLine();
            return @this;
        }

        public static T AppendLine<T>(this T @this, long value)
            where T : TextWriter
        {
            @this.WriteLine(value);
            return @this;
        }

        public static T AppendLine<T>(this T @this, int value)
            where T : TextWriter
        {
            @this.WriteLine(value);
            return @this;
        }

        public static T AppendLine<T>(this T @this, double value)
            where T : TextWriter
        {
            @this.WriteLine(value);
            return @this;
        }

        public static T AppendLine<T>(this T @this, decimal value)
            where T : TextWriter
        {
            @this.WriteLine(value);
            return @this;
        }

        public static T AppendLine<T>(this T @this, char[] buffer, int index, int count)
            where T : TextWriter
        {
            @this.WriteLine(buffer, index, count);
            return @this;
        }

        public static T AppendLine<T>(this T @this, char[] buffer)
            where T : TextWriter
        {
            @this.WriteLine(buffer);
            return @this;
        }

        public static T AppendLine<T>(this T @this, char value)
            where T : TextWriter
        {
            @this.WriteLine(value);
            return @this;
        }

        public static T AppendLine<T>(this T @this, bool value)
            where T : TextWriter
        {
            @this.WriteLine(value);
            return @this;
        }

        public static T AppendLine<T>(this T @this, object value)
            where T : TextWriter
        {
            @this.WriteLine(value);
            return @this;
        }
    }
}
