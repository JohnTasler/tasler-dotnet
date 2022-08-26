using System;
using System.Linq;
using System.Text;
using Xunit;

namespace Tasler.Text.Tests
{
    public class IndenterTests
    {
        private const string _indent = "\t";

        [Fact]
        public void AppendNullAndEmpty()
        {
            var sb = new StringBuilder();
            var indentationService = new IndentationService(sb.CreateIndentationWriter(), _indent);
            indentationService.Write(default(string));
            Assert.Equal(string.Empty, sb.ToString());

            sb.Clear();
            indentationService.Write(string.Empty);
            Assert.Equal(string.Empty, sb.ToString());
        }

        [Fact]
        public void AppendSingleLineString()
        {
            var sb = new StringBuilder();
            var indentationService = new IndentationService(sb.CreateIndentationWriter(), _indent);
            indentationService.Write("Here I am");
            Assert.Equal("Here I am", sb.ToString());
        }

        [Fact]
        public void AppendMultiLineStrings()
        {
            var sb = new StringBuilder();
            var indentationService = new IndentationService(sb.CreateIndentationWriter(), _indent);
            indentationService.Write("Here I am\n");
            Assert.Equal("Here I am\r\n", sb.ToString());

            using (var indentScope = indentationService.CreateIndentationScope())
            {
                indentationService.SubstituteNewLineForLineFeed = false;
                indentationService.Write("Here I am\n");
                Assert.Equal("Here I am\r\n\tHere I am\n", sb.ToString());
            }
        }
    }
}
