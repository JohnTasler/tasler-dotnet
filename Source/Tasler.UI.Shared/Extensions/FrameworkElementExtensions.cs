using System.ComponentModel;
using System.Windows;

namespace Tasler.Windows;

public static class FrameworkElementExtensions
{
	public static void HookDataContextAsViewModel<T>(this T @this, Action raiseEventHandlerAction)
		where T : FrameworkElement, INotifyPropertyChanged
	{
		DependencyPropertyDescriptor
			.FromProperty(FrameworkElement.DataContextProperty, typeof(T))
			.AddValueChanged(@this, Element_DataContextChanged);

		void Element_DataContextChanged(object? sender, EventArgs e)
		{
			raiseEventHandlerAction.Invoke();
			@this.InvalidateVisual();
		}
	}
}
