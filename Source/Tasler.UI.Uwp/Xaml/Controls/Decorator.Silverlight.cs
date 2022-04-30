using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using Tasler.Windows.Media;

namespace Tasler.Windows.Controls
{
	[ContentProperty("Child")]
	public class Decorator : Panel
	{
		public static readonly DependencyProperty ChildProperty =
			DependencyProperty.Register("Child", typeof(UIElement), typeof(Decorator),
				new PropertyMetadata(ChildPropertyChanged));

		public UIElement Child
		{
			get { return (UIElement)GetValue(ChildProperty); }
			set { SetValue(ChildProperty, value); }
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

		private new UIElementCollection Children
		{
			get { return this.Children; }
		}
	}
}