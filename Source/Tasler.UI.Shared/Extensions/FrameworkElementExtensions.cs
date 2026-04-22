using System.ComponentModel;
using System.Windows;
using Tasler.ComponentModel;

namespace Tasler.Windows;

public static class FrameworkElementExtensions
{
	public static void HookDataContextAsViewModel<T, TViewModel>(this T @this, TViewModel viewModel, PropertyChangedEventHandler? handler)
		where T : FrameworkElement, INotifyPropertyChanged
		where TViewModel : INotifyPropertyChanged
	{
		DependencyPropertyDescriptor
			.FromProperty(FrameworkElement.DataContextProperty, typeof(T))
			.AddValueChanged(@this, Element_DataContextChanged);

		@this.DataContext = viewModel;

		void Element_DataContextChanged(object? sender, EventArgs e)
		{
			handler?.Raise(@this, "ViewModel");
			@this.InvalidateVisual();
		}
	}
}
