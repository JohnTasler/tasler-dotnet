using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace Tasler.UI.Xaml.Controls;

using DPFactory = DependencyPropertyFactory<AnimationSizeableElement>;

[ContentProperty(Name = "Child")]
public partial class AnimationSizeableElement
{
	#region Dependency Property Static Fields

	#region Child
	public static partial DependencyProperty ChildProperty => s_ChildProperty;
	private static readonly DependencyProperty s_ChildProperty =
		DPFactory.Register<FrameworkElement>(nameof(Child), OnAffectsMeasurePropertyChanged);
	#endregion Child

	#region ChildHorizontalOffsetMultiplier
	public static partial DependencyProperty ChildHorizontalOffsetMultiplierProperty => s_ChildHorizontalOffsetMultiplierProperty;
	private static readonly DependencyProperty s_ChildHorizontalOffsetMultiplierProperty =
		DPFactory.Register<double>(nameof(ChildHorizontalOffsetMultiplier), 0.0, OnAffectsArrangePropertyChanged);
	#endregion ChildHorizontalOffsetMultiplier

	#region ChildVerticalOffsetMultiplier
	public static partial DependencyProperty ChildVerticalOffsetMultiplierProperty => s_ChildVerticalOffsetMultiplierProperty;
	private static readonly DependencyProperty s_ChildVerticalOffsetMultiplierProperty =
		DPFactory.Register<double>(nameof(ChildVerticalOffsetMultiplier),0.0, OnAffectsArrangePropertyChanged);
	#endregion ChildVerticalOffsetMultiplier

	#region WidthMultiplier
	public static partial DependencyProperty WidthMultiplierProperty => s_WidthMultiplierProperty;
	private static readonly DependencyProperty s_WidthMultiplierProperty =
		DPFactory.Register<double>(nameof(WidthMultiplier), 1.0d, OnAffectsMeasurePropertyChanged);
	#endregion WidthMultiplier

	#region HeightMultiplier
	public static partial DependencyProperty HeightMultiplierProperty => s_HeightMultiplierProperty;
	private static readonly DependencyProperty s_HeightMultiplierProperty =
		DPFactory.Register<double>(nameof(HeightMultiplier), 1.0d, OnAffectsMeasurePropertyChanged);
	#endregion HeightMultiplier

	#region UseMinWidth
	public static partial DependencyProperty UseMinWidthProperty => s_UseMinWidthProperty;
	private static readonly DependencyProperty s_UseMinWidthProperty =
		DPFactory.Register<bool>(nameof(UseMinWidth), false, OnAffectsMeasurePropertyChanged);
	#endregion UseMinWidth

	#region UseMinHeight
	public static partial DependencyProperty UseMinHeightProperty => s_UseMinHeightProperty;
	private static readonly DependencyProperty s_UseMinHeightProperty =
		DPFactory.Register<bool>(nameof(UseMinHeight), false, OnAffectsMeasurePropertyChanged);
	#endregion UseMinHeight

	#endregion Dependency Property Static Fields

	#region Private Implementation

	private static void OnAffectsArrangePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var instance = (AnimationSizeableElement)d;
		instance.InvalidateArrange();
	}

	private static void OnAffectsMeasurePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var instance = (AnimationSizeableElement)d;
		instance.InvalidateMeasure();
	}

	#endregion Private Implementation
}
