using System.Windows;

namespace Tasler.Windows.Controls
{
	public partial class AnimationSizeableElement
	{
		#region Dependency Property Static Fields

		#region ChildProperty
		public static readonly DependencyProperty ChildProperty = DependencyProperty.Register(
				"Child", typeof(FrameworkElement), typeof(AnimationSizeableElement),
				new PropertyMetadata(null, OnAffectsMeasurePropertyChanged));
		#endregion ChildProperty

		#region ChildHorizontalOffsetMultiplierProperty
		public static readonly DependencyProperty ChildHorizontalOffsetMultiplierProperty =
			DependencyProperty.Register("ChildHorizontalOffsetMultiplier", typeof(double), typeof(AnimationSizeableElement),
				new PropertyMetadata(0.0, OnAffectsArrangePropertyChanged));
		#endregion ChildHorizontalOffsetMultiplierProperty

		#region ChildVerticalOffsetMultiplierProperty
		public static readonly DependencyProperty ChildVerticalOffsetMultiplierProperty =
			DependencyProperty.Register("ChildVerticalOffsetMultiplier", typeof(double), typeof(AnimationSizeableElement),
				new PropertyMetadata(0.0, OnAffectsArrangePropertyChanged));
		#endregion ChildVerticalOffsetMultiplierProperty

		#region WidthMultiplierProperty
		public static readonly DependencyProperty WidthMultiplierProperty =
			DependencyProperty.Register("WidthMultiplier", typeof(double), typeof(AnimationSizeableElement),
				new PropertyMetadata((double)1, OnAffectsMeasurePropertyChanged));
		#endregion WidthMultiplierProperty

		#region HeightMultiplierProperty
		public static readonly DependencyProperty HeightMultiplierProperty =
			DependencyProperty.Register("HeightMultiplier", typeof(double), typeof(AnimationSizeableElement),
				new PropertyMetadata((double)1, OnAffectsMeasurePropertyChanged));
		#endregion HeightMultiplierProperty

		#region UseMinWidthProperty
		public static readonly DependencyProperty UseMinWidthProperty =
			DependencyProperty.Register("UseMinWidth", typeof(bool), typeof(AnimationSizeableElement),
				new PropertyMetadata(false, OnAffectsMeasurePropertyChanged));
		#endregion UseMinWidthProperty

		#region UseMinHeightProperty
		public static readonly DependencyProperty UseMinHeightProperty =
			DependencyProperty.Register("UseMinHeight", typeof(bool), typeof(AnimationSizeableElement),
				new PropertyMetadata(false, OnAffectsMeasurePropertyChanged));
		#endregion UseMinHeightProperty

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
}
