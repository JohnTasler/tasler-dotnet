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

	public static IEnumerable<object> GetSelfAndAncestors(this IChild source)
	{
		return source.AsSingleItemEnumerable().Concat(source.GetAncestors());
	}

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
