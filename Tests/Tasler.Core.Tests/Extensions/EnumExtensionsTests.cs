using System.ComponentModel;
using System.Text;

namespace Tasler.Extensions.Tests;

public class EnumExtensions
{
	[Fact]
	public void BasicEnumFlagsWork()
	{
		TestFlags value = TestFlags.None;
		Assert.False(value.HasFlag(TestFlags.First));
		Assert.False(value.HasFlag(TestFlags.Second));
		Assert.False(value.HasFlag(TestFlags.Third));
		Assert.False(value.HasFlag(TestFlags.Fourth));
		Assert.False(value.HasFlag(TestFlags.Fifth));

		value = ~TestFlags.None;
		Assert.True(value.HasFlag(TestFlags.First));
		Assert.True(value.HasFlag(TestFlags.Second));
		Assert.True(value.HasFlag(TestFlags.Third));
		Assert.True(value.HasFlag(TestFlags.Fourth));
		Assert.True(value.HasFlag(TestFlags.Fifth));

		value &= ~TestFlags.First;
		Assert.False(value.HasFlag(TestFlags.First));
	}

	[Fact]
	public void SetBitsOnFlagsButSigned()
	{
		#if DEBUG
		Assert.Throws<InvalidEnumArgumentException>(() =>
		{
			FlagsButSigned nonFlags = FlagsButSigned.None;
			nonFlags.SetBits(FlagsButSigned.First);
		});
		#endif
	}

	[Fact]
	public void SetBitsOnNonFlagsButUnsigned()
	{
#if DEBUG
		Assert.Throws<InvalidEnumArgumentException>(() =>
		{
			NonFlagsButUnsigned nonFlags = NonFlagsButUnsigned.None;
			nonFlags.SetBits(NonFlagsButUnsigned.First);
		});
#endif
	}

	[Fact]
	public void SetFlags()
	{
		TestFlags value = TestFlags.None;
		ref TestFlags modified = ref value.SetBits(TestFlags.First);
		Assert.True(modified.HasFlag(TestFlags.First));

		unsafe
		{
			fixed (TestFlags* modifiedAddress = &modified)
			{
				Assert.True(&value == modifiedAddress);
			}
		}

		value.SetBits(TestFlags.Third);
		value.SetBits(TestFlags.Fifth);
		value.SetBits(TestFlags.MSB);

		Assert.True(value.HasFlag(TestFlags.First));
		Assert.False(value.HasFlag(TestFlags.Second));
		Assert.True(value.HasFlag(TestFlags.Third));
		Assert.False(value.HasFlag(TestFlags.Fourth));
		Assert.True(value.HasFlag(TestFlags.Fifth));
		Assert.True(value.HasFlag(TestFlags.MSB));
	}
}

[Flags]
public enum TestFlags : ulong
{
	None = 0,
	First  = 1 << 0,
	Second = 1 << 1,
	Third  = 1 << 2,
	Fourth = 1 << 3,
	Fifth  = 1 << 4,
	MSB    = 1ul << 63,
}

public enum NonFlagsButUnsigned : ushort
{
	None = 0,
	First  = 1 << 0,
	Second = 1 << 1,
	Third  = 1 << 2,
	Fourth = 1 << 3,
	Fifth  = 1 << 4,
}

[Flags]
public enum FlagsButSigned : long
{
	None = 0,
	First  = 1 << 0,
	Second = 1 << 1,
	Third  = 1 << 2,
	Fourth = 1 << 3,
	Fifth  = 1 << 4,
}

