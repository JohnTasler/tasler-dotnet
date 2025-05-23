using System.Runtime.InteropServices;
using System.Text;
using Tasler.Text;

namespace Tasler.Core.Tests.Text.Extensions;

public class StringBuilderExtensionsTests
{
	[Fact]
	public void AsEnumerableOfChar()
	{
		var sb = new StringBuilder("end");
		char[] end = ['e', 'n', 'd'];
		Assert.Equal(end, sb.AsEnumerableOfChar());
	}

	[Fact]
	public void AsEnumerableOfCharException()
	{
		StringBuilder sb = null!;
		Assert.Throws<ArgumentNullException>(() => sb.AsEnumerableOfChar());
	}

	[Fact]
	public void AsEnumerableOfCharSubstring()
	{
		var sb = new StringBuilder("start:end");
		char[] end = ['e', 'n', 'd'];
		Assert.Equal(end, sb.AsEnumerableOfChar(6, 3));
		Assert.Equal(end, sb.AsEnumerableOfChar(6));
	}

	[Fact]
	public void AsEnumerableOfCharSubstringExceptions()
	{
		var sb = new StringBuilder("start:end");
		Assert.Throws<ArgumentOutOfRangeException>(() => sb.AsEnumerableOfChar(6, 4).ToList());
		Assert.Throws<ArgumentOutOfRangeException>(() => sb.AsEnumerableOfChar(-1, 4).ToList());
		Assert.Throws<ArgumentOutOfRangeException>(() => sb.AsEnumerableOfChar(0, sb.Length + 1).ToList());

		sb = null!;
		Assert.Throws<ArgumentNullException>(() => sb.AsEnumerableOfChar(0, 0).ToList());
	}

	[Fact]
	public void DiscardStringFromEnd()
	{
		var sb = new StringBuilder("start:end");
		Assert.Equal("start", sb.DiscardFromEnd(":end").ToString());
	}

	[Fact]
	public void DiscardNullAndEmptyStringsFromEnd()
	{
		var sb = new StringBuilder("start:end");
		Assert.Equal(sb.Length, sb.DiscardFromEnd("").Length);
		Assert.Equal(sb.Length, sb.DiscardFromEnd(null).Length);
	}

	[Fact]
	public void DiscardStringFromEndExceptions()
	{
		StringBuilder sb = null!;
		Assert.Throws<ArgumentNullException>(() => sb.DiscardFromEnd(""));
	}

	[Fact]
	public void DiscardCharsCountFromEnd()
	{
		var sb = new StringBuilder("start:end");
		Assert.Equal("start", sb.DiscardCharsFromEnd(4).ToString());
		Assert.Equal("start", sb.DiscardCharsFromEnd(0).ToString());
		Assert.Equal("", sb.DiscardCharsFromEnd(sb.Length).ToString());
	}

	[Fact]
	public void DiscardCharsCountFromEndExceptions()
	{
		StringBuilder sb = new("end");
		Assert.Throws<ArgumentOutOfRangeException>(() => sb.DiscardCharsFromEnd(-1));
		Assert.Throws<ArgumentOutOfRangeException>(() => sb.DiscardCharsFromEnd(sb.Length + 1));

		sb = null!;
		Assert.Throws<ArgumentNullException>(() => sb.DiscardCharsFromEnd(0));
	}

	[Fact]
	public void DiscardLineFromEnd()
	{
		var sb = new StringBuilder("start:end\n");
		Assert.Equal("start:end", sb.DiscardLineFromEnd().ToString());

		sb = new StringBuilder("start:end\r\n");
		Assert.Equal("start:end", sb.DiscardLineFromEnd().ToString());
	}

	[Fact]
	public void DiscardLineFromEndException()
	{
		StringBuilder sb = null!;
		Assert.Throws<ArgumentNullException>(() => sb.DiscardLineFromEnd());
	}

	[Fact]
	public void DiscardStringAndLineFromEnd()
	{
		var sb = new StringBuilder("start:end\n");
		Assert.Equal("start", sb.DiscardLineFromEnd(":end").ToString());

		sb = new StringBuilder("start:end\n");
		Assert.Equal("start:end", sb.DiscardLineFromEnd("").ToString());

		sb = new StringBuilder("start:end\n");
		Assert.Equal("start:end", sb.DiscardLineFromEnd(null!).ToString());
	}
}
