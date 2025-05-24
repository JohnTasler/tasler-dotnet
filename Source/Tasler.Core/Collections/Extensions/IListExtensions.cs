using System.Collections;
using CommunityToolkit.Diagnostics;

namespace Tasler.Collections;

// TODO: NEEDS_UNIT_TESTS

public static class IListExtensions
{
	public static TList GrowBy<TItem, TList>(this TList @this, int incrementAmount, Func<TItem> instantiator)
		where TList : IList<TItem>, new()
	{
		return @this.Grow(@this.Count + incrementAmount, instantiator);
	}

	public static TList Grow<TList, TItem>(this TList @this, int newSize, Func<TItem> instantiator)
		where TList : IList<TItem>, new()
	{
		@this ??= new TList();

		var oldSize = @this.Count;
		Guard.IsGreaterThanOrEqualTo(newSize, oldSize);

		for (var index = oldSize; index < newSize; ++index)
			@this.Add(instantiator());

		return @this;
	}

	public static TList Shrink<TList>(this TList @this, int newSize)
		where TList : IList, new()
	{
		@this ??= new TList();

		var oldSize = @this.Count;
		Guard.IsLessThanOrEqualTo(newSize, oldSize);

		for (var index = oldSize; index > newSize; --index)
			@this.RemoveAt(index - 1);

		return @this;
	}

	public static TList ShrinkBy<TItem, TList>(this TList @this, int decrementAmount, Func<TItem> instantiator)
		where TList : IList<TItem>, new()
	{
		return @this.Grow(@this.Count - decrementAmount, instantiator);
	}
}
