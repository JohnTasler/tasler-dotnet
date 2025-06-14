using System.ComponentModel;

namespace Tasler.Extensions.Tests;

public class BitFlagExtensionsTests
{
	[Fact]
	public void SetFlagsSucceeds()
	{
		byte value = 0;
		Assert.False(value.HasAnyFlag((byte)1));
		Assert.False(value.HasAnyFlag((byte)2));
		Assert.False(value.HasAnyFlag((byte)4));

		value = unchecked((byte)-1);
		Assert.True(value.HasAnyFlag((byte)1));
		Assert.True(value.HasAnyFlag((byte)2));
		Assert.True(value.HasAnyFlag((byte)4));

		value &= 0xFE;
		Assert.False(value.HasAnyFlag((byte)1));
	}

	[Fact]
	public void ClearFlagsSucceeds()
	{
		ushort value = 0;
		value.SetFlags((byte)1);
		Assert.True(value.HasAnyFlag((byte)1));
		Assert.False(value.HasAnyFlag((byte)2));

		value.ClearFlags((byte)1);
		Assert.False(value.HasAnyFlag((byte)1));
	}

	[Fact]
	public void SetOrClearEnumFlagsSucceeds()
	{
		uint value = 0;
		value.SetOrClearFlags(true, (byte)1);
		Assert.True(value.HasAnyFlag((byte)1));
		Assert.False(value.HasAnyFlag((byte)2));

		value.SetOrClearFlags(false, (byte)1);
		Assert.False(value.HasAnyFlag((byte)1));
	}

	[Fact]
	public void SetFlagsReturnsSameSucceeds()
	{
		uint value = 0;
		ref uint modified = ref value.SetFlags((byte)8);
		Assert.True(modified.HasAnyFlag((byte)8));
		Assert.False(modified.HasAnyFlag((byte)2));

		unsafe
		{
			fixed (uint* modifiedAddress = &modified)
			{
				Assert.True(&value == modifiedAddress);
			}
		}
	}

	[Fact]
	public void HasAllFlagsSucceeds()
	{
		uint value = 3;
		Assert.True(value.HasAllFlags(1u | 2u));
		Assert.True(value.HasAllFlags(1u));
		Assert.True(value.HasAllFlags(2u));
		value.ClearFlags(2u);
		Assert.False(value.HasAllFlags(1u | 2u));
	}
}
