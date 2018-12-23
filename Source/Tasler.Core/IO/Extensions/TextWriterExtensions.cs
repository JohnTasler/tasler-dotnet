using System;
using System.IO;

namespace Tasler.IO.Extensions
{
    public static class TextWriterExtensions
    {
        public static void Write(this TextWriter @this, ReadOnlySpan<char> span) => @this.Write(span.ToArray());

        public static TextWriter Append(this TextWriter @this, ReadOnlySpan<char> span)
        {
            @this.Write(span.ToArray());
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, ulong value)
        {
            @this.Write(value);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, uint value)
        {
            @this.Write(value);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, string format, params object[] arg)
        {
            @this.Write(format, arg);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, string format, object arg0, object arg1, object arg2)
        {
            @this.Write(format, arg0, arg1, arg2);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, string format, object arg0, object arg1)
        {
            @this.Write(format, arg0, arg1);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, string format, object arg0)
        {
            @this.Write(format, arg0);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, string value)
        {
            @this.Write(value);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, object value)
        {
            @this.Write(value);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, long value)
        {
            @this.Write(value);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, int value)
        {
            @this.Write(value);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, double value)
        {
            @this.Write(value);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, decimal value)
        {
            @this.Write(value);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, char[] buffer, int index, int count)
        {
            @this.Write(buffer, index, count);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, char[] buffer)
        {
            @this.Write(buffer);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, char value)
        {
            @this.Write(value);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, bool value)
        {
            @this.Write(value);
            return @this;
        }

        public static TextWriter Append(this TextWriter @this, float value)
        {
            @this.Write(value);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, string format, object arg0)
        {
            @this.WriteLine(format, arg0);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, ulong value)
        {
            @this.WriteLine(value);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, uint value)
        {
            @this.WriteLine(value);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, string format, params object[] arg)
        {
            @this.WriteLine(format, arg);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, string format, object arg0, object arg1, object arg2)
        {
            @this.WriteLine(format, arg0, arg1, arg2);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, string format, object arg0, object arg1)
        {
            @this.WriteLine(format, arg0, arg1);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, string value)
        {
            @this.WriteLine(value);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, float value)
        {
            @this.WriteLine(value);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this)
        {
            @this.WriteLine();
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, long value)
        {
            @this.WriteLine(value);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, int value)
        {
            @this.WriteLine(value);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, double value)
        {
            @this.WriteLine(value);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, decimal value)
        {
            @this.WriteLine(value);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, char[] buffer, int index, int count)
        {
            @this.WriteLine(buffer, index, count);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, char[] buffer)
        {
            @this.WriteLine(buffer);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, char value)
        {
            @this.WriteLine(value);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, bool value)
        {
            @this.WriteLine(value);
            return @this;
        }

        public static TextWriter AppendLine(this TextWriter @this, object value)
        {
            @this.WriteLine(value);
            return @this;
        }
    }
}
