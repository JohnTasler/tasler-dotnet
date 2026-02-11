using System.Windows;
using CommunityToolkit.Diagnostics;
using Microsoft.Xaml.Behaviors;

namespace Tasler.Windows.Extensions;

public static class AttachedBehaviorExtensions
{
	public static void BehaviorPropertyChanged<TElement, TBehavior, TValue>(
		this DependencyPropertyKey dpk,
		DependencyObject d,
		DependencyPropertyChangedEventArgs e,
		Func<TValue, bool>? isDefaultTest)
		where TElement : FrameworkElement
		where TBehavior : Behavior<TElement>, new()
	{
		Guard.IsNotNull(dpk);
		Guard.IsNotNull(d);
		Guard.IsNotNull(e);
		Guard.IsNotNull(isDefaultTest);

		var element = (TElement)d;
		var newValue = (TValue)e.NewValue;
		if (isDefaultTest is not null && isDefaultTest(newValue))
		{
			var behavior = (TBehavior)element.GetValue(dpk.DependencyProperty);
			if (behavior is not null)
			{
				// Detach and dereference the behavior when the newValue is its default value
				behavior.Detach();
				element.ClearValue(dpk.DependencyProperty);
			}
		}
		else
		{
			// Create and attach the behavior or reuse the existing behavior
			if (element.GetValue(dpk.DependencyProperty) is TBehavior existing)
			{
				var behavior = existing is null ? new TBehavior() : existing;
				if (behavior != existing)
				{
					behavior.Attach(element);
					element.SetValue(dpk, behavior);
				}
			}
		}
	}

	public static void BehaviorPropertyChanged<TElement, TBehavior, TValue>(
		this DependencyPropertyKey dpk,
		DependencyObject d,
		DependencyPropertyChangedEventArgs e,
		TValue defaultValue = default(TValue)!)
		where TElement : FrameworkElement
		where TBehavior : Behavior<TElement>, new()
	{
		dpk.BehaviorPropertyChanged<TElement, TBehavior, TValue>(d, e, v => e.NewValue.Equals((object)defaultValue!));
	}
}
