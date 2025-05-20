using Tasler.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace Tasler.Windows.Controls;

[ContentProperty(Name = nameof(Child))]
public partial class Decorator : Panel
{
	public static readonly DependencyProperty ChildProperty =
		DependencyPropertyFactory<Decorator>.Register<UIElement>(nameof(Child), ChildPropertyChanged);

	public UIElement Child
	{
		get => (UIElement)GetValue(ChildProperty);
		set => SetValue(ChildProperty, value);
	}

	protected virtual void OnChildPropertyChanged(UIElement oldValue, UIElement newValue)
	{
		var children = this.Children;
		if (oldValue != null)
			children.Remove(oldValue);
		if (newValue != null)
			children.Add(newValue);
	}

	private static void ChildPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var instance = (Decorator)d;
		var oldValue = (UIElement)e.OldValue;
		var newValue = (UIElement)e.NewValue;
		instance.OnChildPropertyChanged(oldValue, newValue);
	}

	private new UIElementCollection Children => this.Children;
}
