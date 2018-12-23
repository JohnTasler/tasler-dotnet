using System;
using System.IO;
using System.Text;
using Tasler.IO;

namespace Tasler.Text
{
    public class IndentationService
    {
        #region Constants

        public const string DefaultIndentationString = "    ";

        private const int _lineFeedLineEndingsIndex = 1;
        private const int _carriageReturnLineEndingsIndex = 2;

        #endregion Constants

        #region Fields

        private bool _isAtLineStart = true;
        private readonly IIndentationWriter _writer;
        private readonly ValueTuple<string, string>[] _lineEndings = new ValueTuple<string, string>[]
        {
            ValueTuple.Create(Environment.NewLine, Environment.NewLine),
            ValueTuple.Create("\n", default(string)),  // Initialized by constructor call to SubstituteNewLineForLineFeed
            ValueTuple.Create("\r", default(string)),  // Initialized by constructor call to SubstituteNewLineForCarriageReturn
        };

        #endregion Fields

        #region Constructors

        public IndentationService(IIndentationWriter writer, string indentationString = null, string newLine = null)
        {
            ValidateArgument.IsNotNull(writer, nameof(writer));
            _writer = writer;

            this.IndentationString = indentationString ?? DefaultIndentationString;
            this.NewLine = newLine ?? Environment.NewLine;
            this.SubstituteNewLineForCarriageReturn = true;
            this.SubstituteNewLineForLineFeed = true;
        }

        #endregion Constructors

        #region Properties

        public string IndentationString { get; }

        public int IndentationLevel { get; private set; }

        public string NewLine { get; }

        public bool SubstituteNewLineForLineFeed
        {
            get { return _lineEndings[_lineFeedLineEndingsIndex].Item2 == this.NewLine; }
            set { _lineEndings[_lineFeedLineEndingsIndex].Item2 = value ? this.NewLine : "\n"; }
        }

        public bool SubstituteNewLineForCarriageReturn
        {
            get { return _lineEndings[_carriageReturnLineEndingsIndex].Item2 == this.NewLine; }
            set { _lineEndings[_carriageReturnLineEndingsIndex].Item2 = value ? this.NewLine : "\r"; }
        }

        #endregion Properties

        #region Methods

        public IDisposable CreateIndentationScope(int indentLevelIncrement = 1)
        {
            return new DisposeScopeExit(
                () => this.IndentationLevel += indentLevelIncrement,
                () => this.IndentationLevel -= indentLevelIncrement);
        }

        public static IIndentationWriter CreateStringBuilderIndentationWriter(StringBuilder stringBuilder)
        {
            ValidateArgument.IsNotNull(stringBuilder, nameof(stringBuilder));
            return new StringBuilderIndentWriter(stringBuilder);
        }

        public static IIndentationWriter CreateTextWriterIndentationWriter(TextWriter textWriter)
        {
            ValidateArgument.IsNotNull(textWriter, nameof(textWriter));

            var stringBuilder = (textWriter as StringWriter)?.GetStringBuilder();

            return stringBuilder == null
                ? (IIndentationWriter)new TextWriterIndentWriter(textWriter)
                : (IIndentationWriter)new StringBuilderIndentWriter(stringBuilder);
        }

        public IndentationService Write(string text) => this.Write(text.AsSpan());

        public IndentationService WriteLine(string text) => this.WriteLine(text.AsSpan());

        public IndentationService Write(ReadOnlySpan<char> text)
        {
            var startIndex = 0;
            var endIndex = text.Length;
            var newLineIndex = this.IndexOfLineEnd(text, out var lineEndLength, out var outputLineEnd);
            while (true)
            {
                if (newLineIndex >= 0)
                {
                    WriteLineSegment(text.Slice(startIndex, newLineIndex - startIndex), outputLineEnd);
                    startIndex = newLineIndex + lineEndLength;
                    newLineIndex = this.IndexOfLineEnd(text.Slice(startIndex), out lineEndLength, out outputLineEnd);
                    continue;
                }

                if (startIndex < endIndex)
                {
                    WriteLineSegment(text.Slice(startIndex), null);
                }
                break;
            }

            return this;
        }

        public IndentationService WriteLine(ReadOnlySpan<char> text) => this.Write(text).Write(this.NewLine.AsSpan());

        #endregion Methods

        #region Private Implementation

        private void WriteLineSegment(ReadOnlySpan<char> lineSegment, string lineEnd)
        {
            if (_isAtLineStart)
            {
                this.AppendIndentation();
            }

            _writer.WriteLineSegment(lineSegment);
            _isAtLineStart = lineEnd != null;
            if (_isAtLineStart)
            {
                _writer.WriteLineEnd(lineEnd);
            }
        }

        private int IndexOfLineEnd(ReadOnlySpan<char> text, out int lineEndLength, out string outputLineEnd)
        {
            foreach (var lineEnding in _lineEndings)
            {
                var lineEndIndex = text.IndexOf(lineEnding.Item1.AsSpan());
                if (lineEndIndex >= 0)
                {
                    lineEndLength = lineEnding.Item1.Length;
                    outputLineEnd = lineEnding.Item2;
                    return lineEndIndex;
                }
            }

            lineEndLength = 0;
            outputLineEnd = null;
            return -1;
        }

        private void AppendIndentation()
        {
            for (int index = 0; index < this.IndentationLevel; ++index)
            {
                _writer.WriteLineEnd(this.IndentationString);
            }
        }

        #endregion Private Implementation

        #region Nested Types

        private sealed class StringBuilderIndentWriter : IIndentationWriter
        {
            public readonly StringBuilder _stringBuilder;
            public StringBuilderIndentWriter() : this(new StringBuilder()) { }
            public StringBuilderIndentWriter(StringBuilder stringBuilder) => _stringBuilder = stringBuilder;
            void IIndentationWriter.WriteLineSegment(ReadOnlySpan<char> lineSegment) => _stringBuilder.Append(lineSegment);
            void IIndentationWriter.WriteLineEnd(string lineEnd) => _stringBuilder.Append(lineEnd);
        }

        private sealed class TextWriterIndentWriter : IIndentationWriter
        {
            private readonly TextWriter _textWriter;
            public TextWriterIndentWriter(TextWriter textWriter) => _textWriter = textWriter;
            void IIndentationWriter.WriteLineSegment(ReadOnlySpan<char> lineSegment) => _textWriter.Write(lineSegment);
            void IIndentationWriter.WriteLineEnd(string lineEnd) => _textWriter.Write(lineEnd);
        }

        #endregion Nested Types
    }

    public interface IIndentationWriter
    {
        void WriteLineSegment(ReadOnlySpan<char> lineSegment);

        void WriteLineEnd(string lineEnd);
    }

    public class DelegateIndentationWriter : IIndentationWriter
    {
        public delegate void WriteLineSegmentAction(ReadOnlySpan<char> lineSegment);
        public delegate void WriteLineEndAction(string lineEnd);

        private readonly WriteLineSegmentAction _writeLineSegmentAction;
        private readonly WriteLineEndAction _writeLineEndAction;

        public DelegateIndentationWriter(WriteLineSegmentAction writeLineSegmentAction, WriteLineEndAction writeLineEndAction)
        {
            ValidateArgument.IsNotNull(writeLineSegmentAction, nameof(writeLineSegmentAction));
            ValidateArgument.IsNotNull(writeLineEndAction, nameof(writeLineEndAction));
            _writeLineSegmentAction = writeLineSegmentAction;
            _writeLineEndAction = writeLineEndAction;
        }

        public void WriteLineSegment(ReadOnlySpan<char> lineSegment)
        {
            _writeLineSegmentAction(lineSegment);
        }

        public void WriteLineEnd(string text)
        {
            _writeLineEndAction(text);
        }
    }

    public static class IndentationWriterExtensions
    {
        public static IIndentationWriter CreateIndentationWriter(this StringBuilder @this)
            => IndentationService.CreateStringBuilderIndentationWriter(@this);

        public static IIndentationWriter CreateIndentationWriter(this TextWriter @this)
            => IndentationService.CreateTextWriterIndentationWriter(@this);
    }
}
