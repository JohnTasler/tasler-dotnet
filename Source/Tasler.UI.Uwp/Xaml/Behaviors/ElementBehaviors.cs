using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Tasler.UI.Xaml.Behaviors
{
	using attached = AttachedPropertyFactory<ElementBehaviors>;

	// TODO: NEEDS_UNIT_TESTS

	public sealed class ElementBehaviors
	{
		public ElementBehaviors() { }

		#region ClipThickness

		public static readonly DependencyProperty ClipThicknessProperty = attached.Register<Thickness>(
			"ClipThickness", new Thickness(double.NaN), ClipThicknessPropertyChanged);

		public static Thickness GetClipThickness(FrameworkElement element)
		{
			return (Thickness)element.GetValue(ClipThicknessProperty);
		}

		public static void SetClipThickness(FrameworkElement element, Thickness value)
		{
			element.SetValue(ClipThicknessProperty, value);
		}

		private static void ClipThicknessPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var element = (FrameworkElement)d;
			var newValue = (Thickness)e.NewValue;
			var oldValue = (Thickness)e.OldValue;

			if (!oldValue.IsNan())
			{
				element.ClearValue(UIElement.ClipProperty);
				element.SizeChanged -= ClipThicknessElement_SizeChanged;
			}

			if (newValue.IsNan())
			{
				element.ClearValue(UIElement.ClipProperty);
				element.SizeChanged -= ClipThicknessElement_SizeChanged;
			}
			else
			{
				element.SizeChanged += ClipThicknessElement_SizeChanged;
				element.Clip = new RectangleGeometry { Rect = new Rect() };
			}
		}

		private static void ClipThicknessElement_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			var element = (FrameworkElement)sender;

			element.Clip = new RectangleGeometry
			{
				Rect = new Rect(new Point(), e.NewSize).Deflate(GetClipThickness(element))
			};
		}

		#endregion ClipThickness
	}
}
