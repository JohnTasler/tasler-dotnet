using System.ComponentModel;

namespace Tasler.Extensions.Tests;

public class EnumExtensionsTests
{
	[Fact]
	public void SetEnumFlagsSucceeds()
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
	public void ClearEnumFlagsSucceeds()
	{
		TestFlags value = TestFlags.None;
		value.SetFlags(TestFlags.First);
		Assert.True(value.HasFlag(TestFlags.First));
		Assert.False(value.HasFlag(TestFlags.Second));

		value.ClearFlags(TestFlags.First);
		Assert.False(value.HasFlag(TestFlags.First));
	}

	[Fact]
	public void SetOrClearEnumFlagsSucceeds()
	{
		TestFlags value = TestFlags.None;
		value.SetOrClearFlags(true, TestFlags.First);
		Assert.True(value.HasFlag(TestFlags.First));
		Assert.False(value.HasFlag(TestFlags.Second));

		value.SetOrClearFlags(false, TestFlags.First);
		Assert.False(value.HasFlag(TestFlags.First));
	}

	[Fact]
	public void SetFlagsOnFlagsButSignedFails()
	{
		#if DEBUG
		Assert.Throws<InvalidEnumArgumentException>(() =>
		{
			FlagsButSigned nonFlags = FlagsButSigned.None;
			nonFlags.SetFlags(FlagsButSigned.First);
		});
		#endif
	}

#if DEBUG
	[Fact]
	public void SetFlagsOnNonFlagsButUnsignedFails()
	{
		Assert.Throws<InvalidEnumArgumentException>(() =>
		{
			NonFlagsButUnsigned nonFlags = NonFlagsButUnsigned.None;
			nonFlags.SetFlags(NonFlagsButUnsigned.First);
		});
	}
#endif

	[Fact]
	public void SetFlagsSucceeds()
	{
		TestFlags value = TestFlags.None;
		ref TestFlags modified = ref value.SetFlags(TestFlags.First);
		Assert.True(modified.HasFlag(TestFlags.First));

		unsafe
		{
			fixed (TestFlags* modifiedAddress = &modified)
			{
				Assert.True(&value == modifiedAddress);
			}
		}

		value.SetFlags(TestFlags.Third);
		value.SetFlags(TestFlags.Fifth);
		value.SetFlags(TestFlags.MSB);

		Assert.True(value.HasFlag(TestFlags.First));
		Assert.False(value.HasFlag(TestFlags.Second));
		Assert.True(value.HasFlag(TestFlags.Third));
		Assert.False(value.HasFlag(TestFlags.Fourth));
		Assert.True(value.HasFlag(TestFlags.Fifth));
		Assert.True(value.HasFlag(TestFlags.MSB));
	}

	[Fact]
	public void HasAllFlagsSucceeds()
	{
		TestFlags value = TestFlags.First | TestFlags.Second;
		Assert.True(value.HasAllFlags(TestFlags.First | TestFlags.Second));
		Assert.True(value.HasAllFlags(TestFlags.First));
		Assert.True(value.HasAllFlags(TestFlags.Second));
		value.ClearFlags(TestFlags.Second);
		Assert.False(value.HasAllFlags(TestFlags.First | TestFlags.Second));
	}

	[Fact]
	public void HasAnyFlagsSucceeds()
	{
		TestFlags value = TestFlags.First | TestFlags.Second;
		Assert.True(value.HasAnyFlag(TestFlags.First));
		Assert.True(value.HasAnyFlag(TestFlags.Second));
		value = TestFlags.First;
		Assert.True(value.HasAnyFlag(TestFlags.First | TestFlags.Second));
		Assert.False(value.HasAnyFlag(TestFlags.Third));
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

