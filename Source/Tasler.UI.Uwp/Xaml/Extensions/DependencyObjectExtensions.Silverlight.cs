using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Tasler.Windows.Extensions;

/// <summary>
/// Extensions methods for the <see cref="DependencyObject"/> type.
/// </summary>
public static class DependencyObjectExtensions
{
	/// <summary>
	/// Gets an enumeration of the visual ancestors of the specified <see cref="DependencyObject"/>.
	/// </summary>
	/// <param name="d">The <see cref="DependencyObject"/> from which to begin the enumeration of visual ancestors.</param>
	/// <returns>An <see cref="IEnumerable{DependencyObject}"/> of the visual ancestors of <paramref name="d"/>.</returns>
	/// <remarks>
	/// To get an ancestor of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
	/// <see cref="System.Linq.Enumerable.FirstOrDefault"/> extension methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetVisualAncestors(this DependencyObject d)
	{
		while (d != null)
		{
			d = VisualTreeHelper.GetParent(d);
			if (d != null)
				yield return d;
		}
	}

	/// <summary>
	/// Gets an enumeration of the specified <see cref="DependencyObject"/> and its visual ancestors.
	/// </summary>
	/// <param name="d">The <see cref="DependencyObject"/> from which to begin the enumeration of visual ancestors.</param>
	/// <returns>An <see cref="IEnumerable{DependencyObject}"/> of <paramref name="d"/> and its visual ancestors.</returns>
	/// <remarks>
	/// To get an ancestor of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
	/// <see cref="System.Linq.Enumerable.FirstOrDefault"/> extension methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetSelfAndVisualAncestors(this DependencyObject d)
	{
		while (d != null)
		{
			yield return d;
			d = VisualTreeHelper.GetParent(d);
		}
	}

	/// <summary>
	/// Gets an enumeration of the visual children of the specified <see cref="DependencyObject"/>.
	/// </summary>
	/// <param name="d">The <see cref="DependencyObject"/> for which to the enumeration of visual
	/// children.</param>
	/// <returns>An <see cref="IEnumerable{DependencyObject}"/> of the visual children of
	/// <paramref name="d"/>.</returns>
	/// <remarks>
	/// To get a descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
	/// <see cref="System.Linq.Enumerable.FirstOrDefault"/> extension methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetVisualChildren(this DependencyObject d)
	{
		var childCount = VisualTreeHelper.GetChildrenCount(d);
		for (int childIndex = 0; childIndex < childCount; ++childIndex)
		{
			var child = VisualTreeHelper.GetChild(d, childIndex);
			if (child != null)
				yield return child;
		}
	}

	/// <summary>
	/// Gets a recursive enumeration of the visual descendants of the specified <see cref="DependencyObject"/>.
	/// </summary>
	/// <param name="d">The <see cref="DependencyObject"/> from which to begin the recursive enumeration of visual
	/// descendants.</param>
	/// <returns>An <see cref="IEnumerable{DependencyObject}"/> of the recursive visual descendants of
	/// <paramref name="d"/>.</returns>
	/// <remarks>
	/// To get a descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
	/// <see cref="System.Linq.Enumerable.FirstOrDefault"/> extension methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetVisualDescendantsRecursive(this DependencyObject d)
	{
		var childCount = VisualTreeHelper.GetChildrenCount(d);
		for (int childIndex = 0; childIndex < childCount; ++childIndex)
		{
			var child = VisualTreeHelper.GetChild(d, childIndex);
			if (child != null)
			{
				yield return child;

				foreach (var grandchild in child.GetVisualDescendantsRecursive())
					yield return grandchild;
			}
		}
	}

	public static void SetDefaultStyleKeyValue(this DependencyObject @this, DependencyProperty defaultStyleKeyProperty)
	{
		@this.SetValue(defaultStyleKeyProperty, @this.GetType());
	}
}
