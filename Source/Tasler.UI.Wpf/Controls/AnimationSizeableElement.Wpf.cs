using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace Tasler.Windows.Controls;

using DPFactory = DependencyPropertyFactory<AnimationSizeableElement>;

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
[ContentProperty(nameof(Child))]
public partial class AnimationSizeableElement : IAddChild
{
	#region Dependency Property Static Fields

	#region ChildProperty
	public static partial DependencyProperty ChildProperty => s_ChildProperty;
	private static readonly DependencyProperty s_ChildProperty =
		DPFactory.Register<FrameworkElement>(nameof(Child), OnChildChanged);

	private static void OnChildChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (AnimationSizeableElement)d;
		var oldValue = (FrameworkElement)e.OldValue;
		var newValue = (FrameworkElement)e.NewValue;

		@this.RemoveLogicalChild(oldValue);
		@this.RemoveVisualChild(oldValue);
		@this.AddLogicalChild(newValue);
		@this.AddVisualChild(newValue);
	}
	#endregion ChildProperty

	#region ChildHorizontalOffsetMultiplierProperty
	public static partial DependencyProperty ChildHorizontalOffsetMultiplierProperty => s_ChildHorizontalOffsetMultiplierProperty;
	private static readonly DependencyProperty s_ChildHorizontalOffsetMultiplierProperty =
		DependencyProperty.Register(nameof(ChildHorizontalOffsetMultiplier), typeof(double), typeof(AnimationSizeableElement),
			new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsArrange));
	#endregion ChildHorizontalOffsetMultiplierProperty

	#region ChildVerticalOffsetMultiplierProperty
	public static partial DependencyProperty ChildVerticalOffsetMultiplierProperty => s_ChildVerticalOffsetMultiplierProperty;
	private static readonly DependencyProperty s_ChildVerticalOffsetMultiplierProperty =
		DependencyProperty.Register(nameof(ChildVerticalOffsetMultiplier), typeof(double), typeof(AnimationSizeableElement),
			new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsArrange));
	#endregion ChildVerticalOffsetMultiplierProperty

	#region WidthMultiplierProperty
	public static partial DependencyProperty WidthMultiplierProperty => s_WidthMultiplierProperty;
	private static readonly DependencyProperty s_WidthMultiplierProperty =
		DependencyProperty.Register(nameof(WidthMultiplier), typeof(double), typeof(AnimationSizeableElement),
			new FrameworkPropertyMetadata((double)1, FrameworkPropertyMetadataOptions.AffectsMeasure));
	#endregion WidthMultiplierProperty

	#region HeightMultiplierProperty
	public static partial DependencyProperty HeightMultiplierProperty => s_HeightMultiplierProperty;
	private static readonly DependencyProperty s_HeightMultiplierProperty =
		DependencyProperty.Register(nameof(HeightMultiplier), typeof(double), typeof(AnimationSizeableElement),
			new FrameworkPropertyMetadata((double)1, FrameworkPropertyMetadataOptions.AffectsMeasure));
	#endregion HeightMultiplierProperty

	#region UseMinWidthProperty
	public static partial DependencyProperty UseMinWidthProperty => s_UseMinWidthProperty;
	private static readonly DependencyProperty s_UseMinWidthProperty =
		DependencyProperty.Register(nameof(UseMinWidth), typeof(bool), typeof(AnimationSizeableElement),
			new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure));
	#endregion UseMinWidthProperty

	#region UseMinHeightProperty
	public static partial DependencyProperty UseMinHeightProperty => s_UseMinHeightProperty;
	private static readonly DependencyProperty s_UseMinHeightProperty =
		DependencyProperty.Register(nameof(UseMinHeight), typeof(bool), typeof(AnimationSizeableElement),
			new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsMeasure));
	#endregion UseMinHeightProperty

	#endregion Dependency Property Static Fields

	#region Overrides
	protected override int VisualChildrenCount => this.Child is not null ? 1 : 0;

	protected override Visual GetVisualChild(int index)
	{
		if (this.Child is null || index != 0)
			throw new ArgumentOutOfRangeException("index", index, "Properties.Resources.Visual_ArgumentOutOfRangeException");

		return this.Child;
	}
	#endregion Overrides

	#region IAddChild Members
	/// <summary>
	/// Adds a child object.
	/// </summary>
	/// <param name="value">The child object to add.</param>
	void IAddChild.AddChild(object value)
	{
		if (value is FrameworkElement element)
		{
			this.Child = element;
		}
		else if (value is not null)
		{
			throw new ArgumentException(string.Format(
				Properties.Resources.UnexpectedParameterTypeExceptionFormat_2,
				value.GetType(), typeof(FrameworkElement)), nameof(value));
		}
	}

	/// <summary>
	/// Adds the text content of a node to the object.
	/// </summary>
	/// <param name="text">The text to add to the object.</param>
	void IAddChild.AddText(string text)
	{
		var block = string.IsNullOrEmpty(text) ? null : new TextBlock { Text = text };
		this.Child = block;
	}
	#endregion IAddChild Members
}
