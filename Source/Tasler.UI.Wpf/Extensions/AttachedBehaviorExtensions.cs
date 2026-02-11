
using System.Windows;
using CommunityToolkit.Diagnostics;
using Microsoft.Xaml.Behaviors;

namespace Tasler.Windows.Extensions;

public static class AttachedBehaviorExtensions
{
	public static void BehaviorPropertyChanged<TElement, TBehacvior, TValue>(
		this DependencyPropertyKey dpk,
		DependencyObject d,
		DependencyPropertyChangedEventArgs e,
		Func<TValue, bool>? isDefaultTest)
		where TElement : FrameworkElement
		where TBehacvior : Behavior<TElement>, new()
	{
		Guard.IsNotNull(dpk);
		Guard.IsNotNull(d);
		Guard.IsNotNull(e);
		Guard.IsNotNull(isDefaultTest);

		var element = (TElement)d;
		var newValue = (TValue)e.NewValue;
		if (isDefaultTest is not null && isDefaultTest(newValue))
		{
			var behavior = (TBehacvior)element.GetValue(dpk.DependencyProperty);
			if (behavior is not null)
			{
				// Detach and dereference the behavior when the newValue is its default value
				behavior.Detach();
				element.ClearValue(dpk.DependencyProperty);
			}
		}
		else
		{
			// Detach any existing behavior before creating a new one
			var existing = (TBehacvior)element.GetValue(dpk.DependencyProperty);
			existing?.Detach();

			// Create and attach the behavior only when the newValue is not its default value
			var behavior = new TBehacvior();
			behavior.Attach(element);
			element.SetValue(dpk, behavior);
		}
	}

	public static void BehaviorPropertyChanged<TElement, TBehacvior, TValue>(
		this DependencyPropertyKey dpk,
		DependencyObject d,
		DependencyPropertyChangedEventArgs e,
		TValue defaultValue = default(TValue)!)
		where TElement : FrameworkElement
		where TBehacvior : Behavior<TElement>, new()
	{
		dpk.BehaviorPropertyChanged<TElement, TBehacvior, TValue>(d, e, v => e.NewValue.Equals((object)defaultValue!));
	}
}
