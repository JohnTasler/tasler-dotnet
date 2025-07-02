using System.ComponentModel;
using System.Windows;
using Tasler.ComponentModel;

namespace Tasler.Windows;

public static class FrameworkElementExtensions
{
	public static void HookDataContextAsViewModel<T>(this T @this, PropertyChangedEventHandler? handler)
		where T : FrameworkElement, INotifyPropertyChanged
	{
		DependencyPropertyDescriptor
			.FromProperty(FrameworkElement.DataContextProperty, typeof(T))
			.AddValueChanged(@this, Element_DataContextChanged);

		void Element_DataContextChanged(object? sender, EventArgs e)
		{
			handler?.Raise(@this, "ViewModel");
			@this.InvalidateVisual();
		}
	}
}
