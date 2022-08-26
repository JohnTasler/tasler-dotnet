using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

#if WINDOWS_UWP
using Windows.UI.Xaml;
namespace Tasler.UI.Xaml
#elif WINDOWS_WPF
using System.Windows;
namespace Tasler.Windows.Extensions
#endif
{
    /// <summary>
    /// Extensions methods for the <see cref="DependencyObject"/> type.
    /// </summary>
    public static class DependencyObjectExtensions
    {
        /// <summary>
        /// Gets an enumeration of the logical ancestors of the specified <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject"/> from which to begin the enumeration of logical ancestors.</param>
        /// <returns>An <see cref="IEnumerable{DependencyObject}"/> of the logical ancestors of <paramref name="d"/>.</returns>
        /// <remarks>
        /// To get an ancestor of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
        /// <see cref="System.Linq.Enumerable.FirstOrDefault"/> extension methods on the return value.
        /// </remarks>
        public static IEnumerable<DependencyObject> GetLogicalAncestors(this DependencyObject d)
        {
            while (d != null)
            {
                d = LogicalTreeHelper.GetParent(d);
                if (d != null)
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
        /// <see cref="System.Linq.Enumerable.FirstOrDefault"/> extension methods on the return value.
        /// </remarks>
        public static IEnumerable<DependencyObject> GetSelfAndLogicalAncestors(this DependencyObject d)
        {
            while (d != null)
            {
                yield return d;
                d = LogicalTreeHelper.GetParent(d);
            }
        }

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
            while (d != null && (d is Visual || d is Visual3D))
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
            while (d != null && (d is Visual || d is Visual3D))
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
                if (child is Visual || child is Visual3D)
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
                if (child is Visual || child is Visual3D)
                {
                    yield return child;

                    foreach (var grandchild in child.GetVisualDescendantsRecursive())
                        yield return grandchild;
                }
            }
        }

        /// <summary>
        /// Gets a recursive enumeration of the logical descendants of the specified <see cref="DependencyObject"/>.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject"/> from which to begin the recursive enumeration of logical
        /// descendants.</param>
        /// <returns>An <see cref="IEnumerable{object}"/> of the recursive logical descendants of
        /// <paramref name="d"/>.</returns>
        /// <remarks>
        /// To get a descendant of a specific type, use the <see cref="System.Linq.Enumerable.OfType"/> and
        /// <see cref="System.Linq.Enumerable.FirstOrDefault"/> extension methods on the return value.
        /// </remarks>
        public static IEnumerable<object> GetLogicalDescendantsRecursive(this DependencyObject d)
        {
            foreach (var child in LogicalTreeHelper.GetChildren(d))
            {
                yield return child;

                var dependencyObjectChild = child as DependencyObject;
                if (dependencyObjectChild != null)
                    foreach (var grandchild in dependencyObjectChild.GetLogicalDescendantsRecursive())
                        yield return grandchild;
            }
        }

        public static void SetDefaultStyleKeyValue(this DependencyObject @this, DependencyProperty defaultStyleKeyProperty)
        {
            var type = @this.GetType();
            var metadata = defaultStyleKeyProperty.GetMetadata(type);
            if ((Type)metadata.DefaultValue != type)
                defaultStyleKeyProperty.OverrideMetadata(type, new PropertyMetadata(type));
        }
    }
}