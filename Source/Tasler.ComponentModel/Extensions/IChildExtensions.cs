using Tasler.Extensions;

namespace Tasler.ComponentModel;

/// <summary>
/// Provides a set of extension methods for objects implementing the <see cref="IChild"/> interface.
/// </summary>
public static class IChildExtensions
{
	public static IEnumerable<object> GetAncestors(this IChild source)
	{
		var node = source;
		while (node != null)
		{
			var parent = node.GetParent();
			if (parent != null)
				yield return parent;
			node = parent as IChild;
		}
	}

	/// <summary>
	/// Produces a sequence that contains the specified child followed by its ancestor chain.
	/// </summary>
	/// <param name="source">The starting child whose self and ancestors to enumerate.</param>
	/// <returns>An <see cref="IEnumerable{Object}"/> containing the source as the first element, then each ancestor in order.</returns>
	public static IEnumerable<object> GetSelfAndAncestors(this IChild source)
	{
		return source.AsSingleItemEnumerable().Concat(source.GetAncestors());
	}

	/// <summary>
	/// Determines whether the given item is selected within an ancestor selection container.
	/// </summary>
	/// <param name="source">The item to check for selection state.</param>
	/// <returns>`true` if an ancestor multiple-selection container contains the item in its SelectedItems or an ancestor single-selection container has the item as its SelectedItem; `false` otherwise.</returns>
	public static bool GetIsItemSelected(this IChild source)
	{
		var ancestors = source.GetSelfAndAncestors();

		var multipleSelectionContainer = ancestors.OfType<IMulitpleSelectionContainer>().FirstOrDefault();
		if (multipleSelectionContainer is not null && multipleSelectionContainer.SelectedItems is not null)
			return multipleSelectionContainer.SelectedItems.Contains(source);

		var singleSelectionContainer = ancestors.OfType<ISingleSelectionContainer>().FirstOrDefault();
		if (singleSelectionContainer is not null)
			return singleSelectionContainer.SelectedItem == source;

		return false;
	}

	public static void SetIsItemSelected(this IChild source, bool isSelected)
	{
		var ancestors = source.GetSelfAndAncestors();

		var multipleSelectionContainer = ancestors.OfType<IMulitpleSelectionContainer>().FirstOrDefault();
		if (multipleSelectionContainer != null)
		{
			if (isSelected)
				multipleSelectionContainer.AddToSelectedItems(source);
			else
				multipleSelectionContainer.RemoveFromSelectedItems(source);
		}
		else
		{
			var singleSelectionContainer = ancestors.OfType<ISingleSelectionContainer>().FirstOrDefault();
			if (singleSelectionContainer != null)
			{
				if (isSelected)
				{
					singleSelectionContainer.SelectedItem = source;
				}
				else
				{
					if (singleSelectionContainer.SelectedItem == source)
						singleSelectionContainer.SelectedItem = null;
				}
			}
		}
	}
}