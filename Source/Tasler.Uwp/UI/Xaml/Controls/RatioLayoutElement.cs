using System;
using System.ComponentModel;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;

namespace Tasler.UI.Xaml.Controls
{
	using dpFactory = DependencyPropertyFactory<RatioLayoutElement>;

	// TODO: NEEDS_UNIT_TESTS

	/// <summary>
	/// An element that provides multiplier properties to easily animate the width, height, and offsets of a
	/// <see cref="Child"/> element, relative to the child's .
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
	[ContentProperty(Name = nameof(Child))]
	public partial class RatioLayoutElement : Panel
	{
		#region Instance Fields
		private Size _cachedAvailableSize;
		#endregion Instance Fields

		#region Dependency Properties

		#region Child

		public static readonly DependencyProperty ChildProperty =
			dpFactory.Register<FrameworkElement>(nameof(Child), ChildPropertyChanged);

		[Category("Content")]
		public FrameworkElement Child
		{
			get { return (FrameworkElement)this.GetValue(ChildProperty); }
			set { this.SetValue(ChildProperty, value); }
		}

		private static void ChildPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var @this = (RatioLayoutElement)d;
			var newValue = e.NewValue as UIElement;

			@this.Children.Clear();

			if (newValue != null)
				@this.Children.Add(newValue);

			@this.InvalidateArrange();
		}

		#endregion Child

		#region ChildHorizontalOffsetMultiplier
		public static readonly DependencyProperty ChildHorizontalOffsetMultiplierProperty =
			dpFactory.Register<double>(nameof(ChildHorizontalOffsetMultiplier), OnAffectsArrangePropertyChanged);

		public double ChildHorizontalOffsetMultiplier
		{
			get { return (double)this.GetValue(ChildHorizontalOffsetMultiplierProperty); }
			set { this.SetValue(ChildHorizontalOffsetMultiplierProperty, value); }
		}
		#endregion ChildHorizontalOffsetMultiplier

		#region ChildVerticalOffsetMultiplier
		public static readonly DependencyProperty ChildVerticalOffsetMultiplierProperty =
			dpFactory.Register<double>(nameof(ChildVerticalOffsetMultiplier), OnAffectsArrangePropertyChanged);

		public double ChildVerticalOffsetMultiplier
		{
			get { return (double)this.GetValue(ChildVerticalOffsetMultiplierProperty); }
			set { this.SetValue(ChildVerticalOffsetMultiplierProperty, value); }
		}
		#endregion ChildVerticalOffsetMultiplier

		#region ClipChild
		public static readonly DependencyProperty ClipChildProperty =
			dpFactory.Register<bool>(nameof(ClipChild), true, OnAffectsArrangePropertyChanged);

		public bool ClipChild
		{
			get { return (bool)this.GetValue(ClipChildProperty); }
			set { this.SetValue(ClipChildProperty, value); }
		}
		#endregion ClipChild

		#region WidthMultiplier
		public static readonly DependencyProperty WidthMultiplierProperty =
			dpFactory.Register<double>(nameof(WidthMultiplier), 1, OnAffectsMeasurePropertyChanged);

		public double WidthMultiplier
		{
			get { return (double)this.GetValue(WidthMultiplierProperty); }
			set { this.SetValue(WidthMultiplierProperty, value); }
		}
		#endregion WidthMultiplier

		#region HeightMultiplier
		public static readonly DependencyProperty HeightMultiplierProperty =
			dpFactory.Register<double>(nameof(HeightMultiplier), 1, OnAffectsMeasurePropertyChanged);

		public double HeightMultiplier
		{
			get { return (double)this.GetValue(HeightMultiplierProperty); }
			set { this.SetValue(HeightMultiplierProperty, value); }
		}
		#endregion HeightMultiplier

		#region UseMinWidth
		public static readonly DependencyProperty UseMinWidthProperty =
			dpFactory.Register<bool>(nameof(UseMinWidth), OnAffectsMeasurePropertyChanged);

		public bool UseMinWidth
		{
			get { return (bool)this.GetValue(UseMinWidthProperty); }
			set { this.SetValue(UseMinWidthProperty, value); }
		}
		#endregion UseMinWidth

		#region UseMinHeight
		public static readonly DependencyProperty UseMinHeightProperty =
			dpFactory.Register<bool>(nameof(UseMinHeight), OnAffectsMeasurePropertyChanged);

		public bool UseMinHeight
		{
			get { return (bool)this.GetValue(UseMinHeightProperty); }
			set { this.SetValue(UseMinHeightProperty, value); }
		}
		#endregion UseMinHeight

		#endregion Dependency Properties

		#region Overrides
		protected override Size ArrangeOverride(Size arrangeSize)
		{
			var child = this.Child;
			if (child != null)
			{
				var childSize = child.DesiredSize;

				if (child.HorizontalAlignment == HorizontalAlignment.Stretch && !double.IsInfinity(this._cachedAvailableSize.Width))
					childSize.Width = this._cachedAvailableSize.Width;
				if (child.VerticalAlignment == VerticalAlignment.Stretch && !double.IsInfinity(this._cachedAvailableSize.Height))
					childSize.Height = this._cachedAvailableSize.Height;

				var horizontalOffset = childSize.Width * this.ChildHorizontalOffsetMultiplier;
				if (horizontalOffset < 0 && this.UseMinWidth)
					horizontalOffset = Math.Max(horizontalOffset, this.MinWidth - childSize.Width);

				var verticalOffset = childSize.Height * this.ChildVerticalOffsetMultiplier;
				if (verticalOffset < 0 && this.UseMinHeight)
					verticalOffset = Math.Max(verticalOffset, this.MinHeight - childSize.Height);

				child.Arrange(new Rect(horizontalOffset, verticalOffset, childSize.Width, childSize.Height));
			}

			if (this.ClipChild)
			{
				this.Clip = new RectangleGeometry
				{
					Rect = new Rect(0, 0, arrangeSize.Width, arrangeSize.Height)
				};
			}
			else
			{
				this.SetValue(ClipProperty, null);
			}

			return arrangeSize;
		}

		protected override Size MeasureOverride(Size availableSize)
		{
			// Cache the available size for use in ArrangeOverride
			this._cachedAvailableSize = availableSize;

			var child = this.Child;
			if (child == null)
				return availableSize;

			// Measure the child
			child.Measure(availableSize);
			var desiredSize = child.DesiredSize;

			// Multiply the width, taking into account MinWidth if UseMinWidth is specified
			var width = this.UseMinWidth
				? ((desiredSize.Width - this.MinWidth) * this.WidthMultiplier) + this.MinWidth
				: desiredSize.Width * this.WidthMultiplier;

			// Multiply the height, taking into account MinHeight if UseMinHeight is specified
			var height = this.UseMinHeight
				? ((desiredSize.Height - this.MinHeight) * this.HeightMultiplier) + this.MinHeight
				: desiredSize.Height * this.HeightMultiplier;

			// Limit the width and height to the available size
			if (width > availableSize.Width)
				width = availableSize.Width;
			if (height > availableSize.Height)
				height = availableSize.Height;

			// Return the new size
			return new Size(width, height);
		}
		#endregion Overrides

		#region Private Implementation

		private static void OnAffectsArrangePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var @this = (RatioLayoutElement)d;
			@this.InvalidateArrange();
		}

		private static void OnAffectsMeasurePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var @this = (RatioLayoutElement)d;
			@this.InvalidateMeasure();
		}

		#endregion Private Implementation
	}
}