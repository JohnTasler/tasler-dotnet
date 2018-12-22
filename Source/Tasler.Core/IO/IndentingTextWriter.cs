using System;
using System.IO;
using System.Text;
using Tasler.Text;

namespace Tasler.IO
{
    public class IndentingTextWriter : TextWriter
    {
        #region Fields
        private readonly TextWriter _innerTextWriter;
        private readonly StringBuilder _stringBuilder;
        private readonly IndentationService _indenter;
        #endregion Fields

        #region Constructors

        public IndentingTextWriter(TextWriter innerTextWriter, string indentationString = "    ")
            : base(innerTextWriter.FormatProvider)
        {
            ValidateArgument.IsNotNull(innerTextWriter, nameof(innerTextWriter));

            _innerTextWriter = innerTextWriter;

            DelegateIndentationWriter.WriteLineSegmentAction writeLineSegmentAction;
            DelegateIndentationWriter.WriteLineEndAction writeLineEndAction;

            _stringBuilder = (_innerTextWriter as StringWriter)?.GetStringBuilder();
            if (_stringBuilder != null)
            {
                writeLineSegmentAction = span => _stringBuilder.Append(span);
                writeLineEndAction = lineEnd => _stringBuilder.Append(lineEnd);
            }
            else
            {
                writeLineSegmentAction = span => _innerTextWriter.Write(span.ToArray());
                writeLineEndAction = lineEnd => _innerTextWriter.Write(lineEnd);
            }

            var indenterWriter = new DelegateIndentationWriter(writeLineSegmentAction, writeLineEndAction);
            _indenter = new IndentationService(indenterWriter, indentationString, this.NewLine);

            this.SubstituteNewLineForCarriageReturn = true;
            this.SubstituteNewLineForLineFeed = true;
        }

        #endregion Constructors

        #region Properties

        public string IndentationString => _indenter.IndentationString;

        public int IndentationLevel => _indenter.IndentationLevel;

        public bool SubstituteNewLineForLineFeed
        {
            get => _indenter.SubstituteNewLineForLineFeed;
            set => _indenter.SubstituteNewLineForLineFeed = value;
        }

        public bool SubstituteNewLineForCarriageReturn
        {
            get => _indenter.SubstituteNewLineForCarriageReturn;
            set => _indenter.SubstituteNewLineForCarriageReturn = value;
        }

        #endregion Properties

        #region Methods

        public IDisposable CreateIndentationScope(int indentLevelIncrement = 1) => _indenter.CreateIndentationScope(indentLevelIncrement);

        #endregion Methods

        #region Overrides

        public override Encoding Encoding => _innerTextWriter.Encoding;

        public override void Write(char value)
        {
            ReadOnlySpan<char> charSpan;
            unsafe
            {
                charSpan = new ReadOnlySpan<char>(&value, 1);
            }

            this.Write(charSpan);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            this.Write(new ReadOnlySpan<char>(buffer, index, count));
        }

        public override void Write(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                this.Write(value.AsSpan());
            };
        }

        public void Write(ReadOnlySpan<char> value)
        {
            _indenter.Write(value);
        }

        #endregion Overrides
    }
}
