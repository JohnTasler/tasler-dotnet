#if WINDOWS_UWP
using System.ComponentModel;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace Tasler.UI.Xaml.Controls;

#elif WINDOWS_WPF
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
namespace Tasler.Windows.Controls;
#endif

/// <summary>
/// A framework element that provides properties to easily animate the width, height, and offsets of a
/// <see cref="Child"/> element.
/// </summary>
/// <remarks>
/// FrameworkElement default values for the <see cref="Width"/> and <see cref="Height"/> properties are Auto, which
/// are seldom changed in actual usage of the derived types. This makes it difficult to animate those properties.
/// For many animations, this is very inconvenient, as we typically want to animate something into and out-of view.
/// This class provides multiplier properties (<see cref="WidthMultiplier"/>, <see cref="HeightMultiplier"/>,
/// <see cref="ChildHorizontalOffsetMultiplier"/>, and <see cref="ChildVerticalOffsetMultiplier"/>) which can
/// easily be animated (using a <see cref="T:System.Windows.Media.Animation.DoubleAnimation"/> to produce the
/// desired animation effects.
/// </remarks>
public partial class AnimationSizeableElement : Panel
{
	#region Instance Fields
	private Size _cachedAvailableSize;
	#endregion Instance Fields

	#region Dependency Properties

	#region Child
	public static partial DependencyProperty ChildProperty { get; }

	[Category("Content")]
	public FrameworkElement? Child
	{
		get => (FrameworkElement?)base.GetValue(ChildProperty);
		set => base.SetValue(ChildProperty, value);
	}
	#endregion Child

	#region ChildHorizontalOffsetMultiplier

	public static partial DependencyProperty ChildHorizontalOffsetMultiplierProperty { get; }

	public double ChildHorizontalOffsetMultiplier
	{
		get => (double)this.GetValue(ChildHorizontalOffsetMultiplierProperty);
		set => this.SetValue(ChildHorizontalOffsetMultiplierProperty, value);
	}
	#endregion ChildHorizontalOffsetMultiplier

	#region ChildVerticalOffsetMultiplier
	public static partial DependencyProperty ChildVerticalOffsetMultiplierProperty { get; }

	public double ChildVerticalOffsetMultiplier
	{
		get => (double)this.GetValue(ChildVerticalOffsetMultiplierProperty);
		set => this.SetValue(ChildVerticalOffsetMultiplierProperty, value);
	}
	#endregion ChildVerticalOffsetMultiplier

	#region WidthMultiplier
	public static partial DependencyProperty WidthMultiplierProperty { get; }

	public double WidthMultiplier
	{
		get => (double)this.GetValue(WidthMultiplierProperty);
		set => this.SetValue(WidthMultiplierProperty, value);
	}
	#endregion WidthMultiplier

	#region HeightMultiplier
	public static partial DependencyProperty HeightMultiplierProperty { get; }

	public double HeightMultiplier
	{
		get => (double)this.GetValue(HeightMultiplierProperty);
		set => this.SetValue(HeightMultiplierProperty, value);
	}
	#endregion HeightMultiplier

	#region UseMinWidth
	public static partial DependencyProperty UseMinWidthProperty { get; }

	public bool UseMinWidth
	{
		get => (bool)this.GetValue(UseMinWidthProperty);
		set => this.SetValue(UseMinWidthProperty, value);
	}
	#endregion UseMinWidth

	#region UseMinHeight
	public static partial DependencyProperty UseMinHeightProperty { get; }

	public bool UseMinHeight
	{
		get => (bool)this.GetValue(UseMinHeightProperty);
		set => this.SetValue(UseMinHeightProperty, value);
	}
	#endregion UseMinHeight

	#endregion Dependency Properties

	#region Overrides

	protected override Size ArrangeOverride(Size arrangeSize)
	{
		var child = this.Child;
		if (child is not null)
		{
			var childSize = child.DesiredSize;

			if (child.HorizontalAlignment == HorizontalAlignment.Stretch && !double.IsInfinity(_cachedAvailableSize.Width))
				childSize.Width = _cachedAvailableSize.Width;
			if (child.VerticalAlignment == VerticalAlignment.Stretch && !double.IsInfinity(_cachedAvailableSize.Height))
				childSize.Height = _cachedAvailableSize.Height;

			var horizontalOffset = childSize.Width * this.ChildHorizontalOffsetMultiplier;
			var verticalOffset = childSize.Height * this.ChildVerticalOffsetMultiplier;
			child.Arrange(new Rect(horizontalOffset, verticalOffset, childSize.Width, childSize.Height));
		}

		return arrangeSize;
	}

	protected override Size MeasureOverride(Size availableSize)
	{
		// Cache the available size for use in ArrangeOverride
		_cachedAvailableSize = availableSize;

		var child = this.Child;
		if (child is null)
			return availableSize;

		// Measure the child
		child.Measure(availableSize);
		var desiredSize = child.DesiredSize;

		// Multiply the width, taking into account MinWidth if UseMinWidth is specified
		double width;
		if (this.UseMinWidth)
			width = ((desiredSize.Width - this.MinWidth) * this.WidthMultiplier) + this.MinWidth;
		else
			width = desiredSize.Width * this.WidthMultiplier;

		// Multiply the height, taking into account MinHeight if UseMinHeight is specified
		double height;
		if (this.UseMinHeight)
			height = ((desiredSize.Height - this.MinHeight) * this.HeightMultiplier) + this.MinHeight;
		else
			height = desiredSize.Height * this.HeightMultiplier;

		// Limit the width and height to the available size
		if (width > availableSize.Width)
			width = availableSize.Width;
		if (height > availableSize.Height)
			height = availableSize.Height;

		// Return the new size
		return new Size(width, height);
	}

	#endregion Overrides
}
