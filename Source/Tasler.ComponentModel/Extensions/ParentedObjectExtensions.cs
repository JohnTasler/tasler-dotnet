using System.Collections.Generic;
using System.Linq;
using Tasler.Extensions;

namespace Tasler.ComponentModel
{
	/// <summary>
	/// Provides a set of extension methods for objects implementing the <see cref="IParentedObject"/> interface.
	/// </summary>
	public static class ParentedObjectExtensions
	{
		public static IEnumerable<object> GetAncestors(this IParentedObject source)
		{
			var node = source;
			while (node != null)
			{
				var parent = node.GetParent();
				if (parent != null)
					yield return parent;
				node = parent as IParentedObject;
			}
		}

		public static IEnumerable<object> GetSelfAndAncestors(this IParentedObject source)
		{
			return source.AsEnumerable<object>().Concat(source.GetAncestors());
		}

		public static bool GetIsItemSelected(this IParentedObject source)
		{
			var ancestors = source.GetSelfAndAncestors();

			var multipleSelectionContainer = ancestors.OfType<IMulitpleSelectionContainer>().FirstOrDefault();
			if (multipleSelectionContainer != null)
				return multipleSelectionContainer.SelectedItems.Contains(source);

			var singleSelectionContainer = ancestors.OfType<ISingleSelectionContainer>().FirstOrDefault();
			if (singleSelectionContainer != null)
				return singleSelectionContainer.SelectedItem == source;

			return false;
		}

		public static void SetIsItemSelected(this IParentedObject source, bool isSelected)
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
}
