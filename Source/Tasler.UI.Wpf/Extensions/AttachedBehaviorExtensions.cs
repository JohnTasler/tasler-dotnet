using System.Windows;
using CommunityToolkit.Diagnostics;
using Microsoft.Xaml.Behaviors;

namespace Tasler.Windows.Extensions;

public static class AttachedBehaviorExtensions
{
	public static void BehaviorPropertyChanged<TElement, TBehavior, TValue>(
		this DependencyPropertyKey dpk,
		DependencyObject d,
		DependencyPropertyChangedEventArgs e)
		where TElement : FrameworkElement
		where TBehavior : Behavior<TElement>, new()
	{
		Guard.IsNotNull(dpk);
		Guard.IsNotNull(d);
		Guard.IsNotNull(e);

		var element = (TElement)d;
		var behavior = (TBehavior)element.GetValue(dpk.DependencyProperty);
		var newValue = (TValue)e.NewValue;
		var defaultValue = dpk.DependencyProperty.GetMetadata(d).DefaultValue;
		if (object.Equals(newValue, defaultValue))
		{
			int remainingReferences = (behavior is ICountReferences countReferences)
				? countReferences.Release()
				: 0;

			if (behavior is not null)
			{
				if (remainingReferences == 0)
				{
					// Detach and dereference the behavior when the newValue is its default value
					behavior.Detach();
					element.ClearValue(dpk);
				}
			}
		}
		else
		{
			behavior ??= new TBehavior();
			int remainingReferences = behavior is ICountReferences countReferences
				? countReferences.Add()
				: 1;

			if (remainingReferences == 1)
			{
				behavior.Attach(element);
				element.SetValue(dpk, behavior);
			}
		}
	}
}
