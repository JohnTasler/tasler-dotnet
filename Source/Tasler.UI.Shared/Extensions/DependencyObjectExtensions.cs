using Tasler.ComponentModel.Extensions;

#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
namespace Tasler.UI.Xaml.Extensions;
#elif WINDOWS_WPF
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
namespace Tasler.Windows.Extensions;
#endif

/// <summary>
/// Extensions methods for the <see cref="DependencyObject"/> type.
/// </summary>
public static class DependencyObjectExtensions
{
#if WINDOWS_UWP

	/// <summary>
	/// Sets the <see cref="Control.DefaultStyleKey"/> property to the type of the specified <see cref="DependencyObject"/>.
	/// </summary>
	/// <param name="this">The object on which to set the <see cref="Control.DefaultStyleKey"/> property. Its
	/// <see cref="object.GetType"/> method is used as the value of the property.</param>
	public static void SetDefaultStyleKey(this DependencyObject @this)
	{
		@this.SetValue(Control.DefaultStyleKeyProperty, @this.GetType());
	}

	/// <summary>
	/// Determines whether the specified <see cref="DependencyObject"/> is a <see cref="Visual"/>.
	/// </summary>
	/// <param name="this">The <see cref="DependencyObject"/> to test.</param>
	/// <returns>
	///   <see langword="true"/> if the specied object is a <see cref="Visual"/>; otherwise,
	///   <see langword="false"/>. Also <see langword="false"/> if <paramref name="this"/> is <see langword="null"/>.
	/// </returns>
	/// <remarks>This is to used by both WPF (which also has Visual3D) and WinUI/UWP/Uno code (which does not).</remarks>
	public static bool IsVisual(this DependencyObject? @this)
		=> @this is not null && @this is UIElement;

#elif WINDOWS_WPF

	/// <summary>
	/// Sets the <see cref="FrameworkElement.DefaultStyleKey"/> property to the type of the specified <see cref="DependencyObject"/>.
	/// </summary>
	/// <param name="this">The object on which to set the <see cref="FrameworkElement.DefaultStyleKey"/> property. Its
	/// <see cref="object.GetType"/> method is used as the value of the property.</param>
	public static void SetDefaultStyleKey(this DependencyObject @this)
	{
		var thisType = @this.GetType();
		var descriptor = DependencyPropertyDescriptor.FromName("DefaultStyleKey", typeof(FrameworkElement), thisType);
		var dependencyProperty = descriptor.DependencyProperty;
		var metadata = dependencyProperty.GetMetadata(thisType);
		if ((Type)metadata.DefaultValue != thisType)
			dependencyProperty.OverrideMetadata(thisType, new PropertyMetadata(thisType));
	}

	/// <summary>
	/// Determines whether the specified <see cref="DependencyObject"/> is a <see cref="Visual"/> or <see cref="Visual3D"/>.
	/// </summary>
	/// <param name="this">The <see cref="DependencyObject"/> to test.</param>
	/// <returns>
	///   <see langword="true"/> if the specied object is a <see cref="Visual"/> or <see cref="Visual3D"/>; otherwise,
	///   <see langword="false"/>. Also <see langword="false"/> if <paramref name="this"/> is <see langword="null"/>.
	/// </returns>
	/// <remarks>This is to used by both WPF (which also has Visual3D) and WinUI/UWP/Uno code (which does not).</remarks>
	public static bool IsVisual(this DependencyObject? @this)
		=> (@this is not null) && (@this is Visual || @this is Visual3D);

	/// <summary>
	/// Gets an enumeration of the logical ancestors of the specified <see cref="DependencyObject"/>.
	/// </summary>
	/// <param name="d">The <see cref="DependencyObject"/> from which to begin the enumeration of logical ancestors.</param>
	/// <returns>An <see cref="IEnumerable{DependencyObject}"/> of the logical ancestors of <paramref name="d"/>.</returns>
	/// <remarks>
	/// To get an ancestor of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
	/// <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/> extension methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetLogicalAncestors(this DependencyObject d)
	{
		while (d is not null)
		{
			d = LogicalTreeHelper.GetParent(d);
			if (d is not null)
				yield return d;
		}
	}

	/// <summary>
	/// Gets an enumeration of the specified <see cref="DependencyObject"/> and its logical ancestors.
	/// </summary>
	/// <param name="d">The <see cref="DependencyObject"/> from which to begin the enumeration of logical ancestors.</param>
	/// <returns>An <see cref="IEnumerable{DependencyObject}"/> of <paramref name="d"/> and its logical ancestors.</returns>
	/// <remarks>
	/// To get an ancestor of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
	/// <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/> extension methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetSelfAndLogicalAncestors(this DependencyObject d)
	{
		while (d is not null)
		{
			yield return d;
			d = LogicalTreeHelper.GetParent(d);
		}
	}

	/// <summary>
	///   Gets an enumeration that produces the descendants in the logical tree of the specified
	///   <see cref="DependencyObject"/> root node.
	/// </summary>
	/// <param name="d">
	///   The <see cref="DependencyObject"/> from which to begin the traversal of logical descendants.
	/// </param>
	/// <returns>
	///   An <see cref="IEnumerable{DependencyObject}"/> that produces each logical descendant of
	///   <paramref name="d"/>.
	/// </returns>
	/// <remarks>
	/// <para>
	///   To get the first descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/>
	///   and <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/> extension
	///   methods on the return value.
	/// </para><para>
	///   When you know that the layout of tree nodes is such that you want to find a node that is
	///   closer to the sibling nodes than to the deeper ancestors, favor using this method instead of
	///   the <see cref="GetLogicalDescendantsDepthFirst{DependencyObject}" />. This can allow your
	///   enumeration (traversal) loop to exit sooner.
	/// </para>
	/// <seealso cref="GetSelfAndLogicalDescendantsDepthFirst"/>
	/// <seealso cref="GetLogicalDescendantsDepthFirst"/>
	/// </remarks>
	public static IEnumerable<DependencyObject> GetLogicalDescendantsBreadthFirst(this DependencyObject d)
	{
		return d.GetDescendantsBreadthFirst(false, GetLogicalChildren);
	}

	/// <summary>
	///   Gets an enumeration that produces the <see cref="DependencyObject"/> specified by
	///   <paramref cref="d"/> and its descendants in the logical tree.
	/// </summary>
	/// <param name="d">
	///   The <see cref="DependencyObject"/> from which to begin the traversal of logical descendants.
	/// </param>
	/// <returns>
	///   An <see cref="IEnumerable{DependencyObject}"/> that produces <paramref name="d"/> and each
	///   of its descendants in the logical tree.
	///   <paramref name="d"/>.
	/// </returns>
	/// <remarks>
	///   To get the first descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/>
	///   and <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/> extension
	///   methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetSelfAndLogicalDescendantsBreadthFirst(this DependencyObject d)
	{
		return d.GetDescendantsBreadthFirst(true, GetLogicalChildren);
	}

	/// <summary>
	///   Gets an enumeration that produces the descendants in the logical tree of the specified
	///   <see cref="DependencyObject"/> root node.
	/// </summary>
	/// <param name="d">
	///   The <see cref="DependencyObject"/> from which to begin the traversal of logical descendants.
	/// </param>
	/// <returns>
	///   An <see cref="IEnumerable{DependencyObject}"/> that produces each logical descendant of
	///   <paramref name="d"/>.
	/// </returns>
	/// <remarks>
	/// <para>
	///   To get the first descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/>
	///   and <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/> extension
	///   methods on the return value.
	/// </para><para>
	///   When you know that the layout of tree nodes is such that you want to find a node that is
	///   closer to the sibling nodes than to the deeper ancestors, favor using this method instead of
	///   the <see cref="GetLogicalDescendantsDepthFirst{DependencyObject}" />. This can allow your
	///   enumeration (traversal) loop to exit sooner.
	/// </para>
	/// <seealso cref="GetSelfAndLogicalDescendantsDepthFirst"/>
	/// <seealso cref="GetLogicalDescendantsDepthFirst"/>
	/// </remarks>
	public static IEnumerable<DependencyObject> GetLogicalDescendantsDepthFirst(this DependencyObject d)
	{
		return d.GetDescendantsDepthFirst(false, GetLogicalChildren);
	}

	/// <summary>
	///   Gets an enumeration that produces the <see cref="DependencyObject"/> specified by
	///   <paramref cref="d"/> and its descendants in the logical tree.
	/// </summary>
	/// <param name="d">
	///   The <see cref="DependencyObject"/> from which to begin the traversal of logical descendants.
	/// </param>
	/// <returns>
	///   An <see cref="IEnumerable{DependencyObject}"/> that produces <paramref name="d"/> and each
	///   of its descendants in the logical tree.
	///   <paramref name="d"/>.
	/// </returns>
	/// <remarks>
	///   To get the first descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/>
	///   and <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/> extension
	///   methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetSelfAndLogicalDescendantsDepthFirst(this DependencyObject d)
	{
		return d.GetDescendantsDepthFirst(true, GetLogicalChildren);
	}

	private static IEnumerable<DependencyObject> GetLogicalChildren(DependencyObject node)
	{
		foreach (var child in LogicalTreeHelper.GetChildren(node))
		{
			if (child is not null && child is DependencyObject dependencyChild)
			{
				yield return dependencyChild;
			}
		}
	}

#endif

	/// <summary>
	/// Gets an enumeration of the visual ancestors of the specified <see cref="DependencyObject"/>.
	/// </summary>
	/// <param name="d">The <see cref="DependencyObject"/> from which to begin the enumeration of visual ancestors.</param>
	/// <returns>An <see cref="IEnumerable{DependencyObject}"/> of the visual ancestors of <paramref name="d"/>.</returns>
	/// <remarks>
	///   To get an ancestor of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
	///   <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/> extension
	///   methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetVisualAncestors(this DependencyObject d)
	{
		// Traverse the visual tree upwards, yielding each ancestor until we reach the root.
		return d.GetAncestors(d => VisualTreeHelper.GetParent(d))
			.Where(ancestor => ancestor.IsVisual());
	}

	/// <summary>
	/// Gets an enumeration of the specified <see cref="DependencyObject"/> and its visual ancestors.
	/// </summary>
	/// <param name="d">The <see cref="DependencyObject"/> from which to begin the enumeration of visual ancestors.</param>
	/// <returns>An <see cref="IEnumerable{DependencyObject}"/> of <paramref name="d"/> and its visual ancestors.</returns>
	/// <remarks>
	///   To get an ancestor of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
	///   <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/>
	///   extension methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetSelfAndVisualAncestors(this DependencyObject d)
	{
		return d.GetSelfAndAncestors(d => VisualTreeHelper.GetParent(d))
			.Where(ancestor => ancestor.IsVisual());
	}

	/// <summary>
	///   Gets an enumeration that produces the descendants in the logical tree of the specified
	///   <see cref="DependencyObject"/> root node.
	/// </summary>
	/// <param name="d">
	///   The <see cref="DependencyObject"/> from which to begin the traversal of logical descendants.
	/// </param>
	/// <returns>
	///   An <see cref="IEnumerable{DependencyObject}"/> that produces each logical descendant of
	///   <paramref name="d"/>.
	/// </returns>
	/// <remarks>
	/// <para>
	///   To get the first descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/>
	///   and <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/>
	///   extension methods on the return value.
	/// </para><para>
	///   When you know that the layout of tree nodes is such that you want to find a node that is
	///   closer to the sibling nodes than to the deeper ancestors, favor using this method instead of
	///   the <see cref="GetVisualDescendantsDepthFirst{DependencyObject}" />. This can allow your
	///   enumeration (traversal) loop to exit sooner.
	/// </para>
	/// <seealso cref="GetSelfAndVisualDescendantsDepthFirst"/>
	/// <seealso cref="GetVisualDescendantsDepthFirst"/>
	/// </remarks>
	public static IEnumerable<DependencyObject> GetVisualDescendantsBreadthFirst(this DependencyObject d)
	{
		return d.GetDescendantsBreadthFirst(false, GetVisualChildren);
	}

	/// <summary>
	///   Gets an enumeration that produces the <see cref="DependencyObject"/> specified by
	///   <paramref cref="d"/> and its descendants in the logical tree.
	/// </summary>
	/// <param name="d">
	///   The <see cref="DependencyObject"/> from which to begin the traversal of logical descendants.
	/// </param>
	/// <returns>
	///   An <see cref="IEnumerable{DependencyObject}"/> that produces <paramref name="d"/> and each
	///   of its descendants in the logical tree.
	///   <paramref name="d"/>.
	/// </returns>
	/// <remarks>
	///   To get the first descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/>
	///   and <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/> extension
	///   methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetSelfAndVisualDescendantsBreadthFirst(this DependencyObject d)
	{
		return d.GetDescendantsBreadthFirst(true, GetVisualChildren);
	}

	/// <summary>
	///   Gets an enumeration that produces the descendants in the logical tree of the specified
	///   <see cref="DependencyObject"/> root node.
	/// </summary>
	/// <param name="d">
	///   The <see cref="DependencyObject"/> from which to begin the traversal of logical descendants.
	/// </param>
	/// <returns>
	///   An <see cref="IEnumerable{DependencyObject}"/> that produces each logical descendant of
	///   <paramref name="d"/>.
	/// </returns>
	/// <remarks>
	/// <para>
	///   To get the first descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/>
	///   and <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/>
	///   extension methods on the return value.
	/// </para><para>
	///   When you know that the layout of tree nodes is such that you want to find a node that is
	///   closer to the sibling nodes than to the deeper ancestors, favor using this method instead of
	///   the <see cref="GetVisualDescendantsDepthFirst{DependencyObject}" />. This can allow your
	///   enumeration (traversal) loop to exit sooner.
	/// </para>
	/// <seealso cref="GetSelfAndVisualDescendantsDepthFirst"/>
	/// <seealso cref="GetVisualDescendantsDepthFirst"/>
	/// </remarks>
	public static IEnumerable<DependencyObject> GetVisualDescendantsDepthFirst(this DependencyObject d)
	{
		return d.GetDescendantsDepthFirst<DependencyObject>(false, GetVisualChildren);
	}

	/// <summary>
	///   Gets an enumeration that produces the <see cref="DependencyObject"/> specified by
	///   <paramref cref="d"/> and its descendants in the logical tree.
	/// </summary>
	/// <param name="d">
	///   The <see cref="DependencyObject"/> from which to begin the traversal of logical descendants.
	/// </param>
	/// <returns>
	///   An <see cref="IEnumerable{DependencyObject}"/> that produces <paramref name="d"/> and each
	///   of its descendants in the logical tree.
	///   <paramref name="d"/>.
	/// </returns>
	/// <remarks>
	///   To get the first descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/>
	///   and <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/>
	///   extension methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetSelfAndVisualDescendantsDepthFirst(this DependencyObject d)
	{
		return d.GetDescendantsDepthFirst<DependencyObject>(true, GetVisualChildren);
	}

	/// <summary>
	/// Gets an enumeration of the direct visual children of the specified <see cref="DependencyObject"/>.
	/// </summary>
	/// <param name="d">The <see cref="DependencyObject"/> for which to the enumeration of visual
	/// children.</param>
	/// <returns>An <see cref="IEnumerable{DependencyObject}"/> of the visual children of
	/// <paramref name="d"/>.</returns>
	/// <remarks>
	///   To get the first descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/>
	///   and <see cref="Enumerable.FirstOrDefault{DependencyObject}(IEnumerable{DependencyObject})"/>
	///   extension methods on the return value.
	/// </remarks>
	public static IEnumerable<DependencyObject> GetVisualChildren(this DependencyObject d)
	{
		var childCount = VisualTreeHelper.GetChildrenCount(d);
		for (int childIndex = 0; childIndex < childCount; ++childIndex)
		{
			var child = VisualTreeHelper.GetChild(d, childIndex);
			if (child.IsVisual())
				yield return child;
		}
	}
}
