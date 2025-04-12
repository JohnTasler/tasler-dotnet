using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Diagnostics;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Controls
{
	/// <summary>
	/// Positions child elements in sequential position from left to right, breaking content to the next line at the
	/// edge of the containing box. Subsequent ordering happens sequentially from top to bottom or from right to left,
	/// depending on the value of the <see cref="Orientation"/> property.
	/// </summary>
	public class WrapPanel : Panel
	{
		#region Dependency Properties

		#region ItemWidth

		public static readonly DependencyProperty ItemWidthProperty =
			DependencyProperty.Register("ItemWidth", typeof(double), typeof(WrapPanel),
				new PropertyMetadata(double.NaN, ItemWidthPropertyChanged));

		public double ItemWidth
		{
			get { return (double)base.GetValue(ItemWidthProperty); }
			set { base.SetValue(ItemWidthProperty, value); }
		}

		private static void ItemWidthPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var instance = (WrapPanel)d;
			var newValue = (double)e.NewValue;
			if (double.IsNaN(newValue) || ((newValue >= 0.0) && !double.IsPositiveInfinity(newValue)))
			{
				instance.InvalidateMeasure();
			}
			else
			{
				Debug.WriteLine("warning: forcing WrapPanel.ItemWidth to NaN (Auto) because an invalid value was specified: " + newValue);
				instance.ItemWidth = double.NaN;
			}
		}

		#endregion ItemWidth

		#region ItemHeight

		public static readonly DependencyProperty ItemHeightProperty =
			DependencyProperty.Register("ItemHeight", typeof(double), typeof(WrapPanel),
				new PropertyMetadata(double.NaN, ItemHeightPropertyChanged));

		public double ItemHeight
		{
			get { return (double)base.GetValue(ItemHeightProperty); }
			set { base.SetValue(ItemHeightProperty, value); }
		}

		private static void ItemHeightPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var instance = (WrapPanel)d;
			var newValue = (double)e.NewValue;
			if (double.IsNaN(newValue) || ((newValue >= 0.0) && !double.IsPositiveInfinity(newValue)))
			{
				instance.InvalidateMeasure();
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("warning: forcing WrapPanel.ItemHeight to NaN (Auto) because an invalid value was specified: " + newValue);
				instance.ItemHeight = double.NaN;
			}
		}

		#endregion ItemHeight

		#region ItemSpacing

		public static readonly DependencyProperty ItemSpacingProperty =
			DependencyProperty.Register("ItemSpacing", typeof(Thickness), typeof(WrapPanel),
				new PropertyMetadata(default(Thickness), PropertyAffectingMeasureChanged));

		public Thickness ItemSpacing
		{
			get { return (Thickness)base.GetValue(ItemSpacingProperty); }
			set { base.SetValue(ItemSpacingProperty, value); }
		}

		#endregion ItemSpacing

		#region Orientation

		public static readonly DependencyProperty OrientationProperty =
			DependencyProperty.Register("Orientation", typeof(Orientation), typeof(WrapPanel),
				new PropertyMetadata(Orientation.Horizontal, PropertyAffectingMeasureChanged));

		public Orientation Orientation
		{
			get { return (Orientation)base.GetValue(OrientationProperty); }
			set { base.SetValue(OrientationProperty, value); }
		}

		#endregion Orientation

		#region LineCount

		private static readonly DependencyProperty LineCountProperty =
			DependencyProperty.Register("LineCount", typeof(int), typeof(WrapPanel), new PropertyMetadata(0));

		public int LineCount
		{
			get { return (int)GetValue(LineCountProperty); }
		}

		#endregion LineCount

		#endregion Dependency Properties

		#region Attached Properties

		#region LineIndex

		private static readonly DependencyProperty LineIndexProperty =
			DependencyProperty.RegisterAttached("LineIndex", typeof(int), typeof(WrapPanel), new PropertyMetadata(-1));

		public static int GetLineIndex(UIElement d)
		{
			Guard.IsNotNull(d);
			return (int)d.GetValue(LineIndexProperty);
		}

		#endregion LineIndex

		#region ItemIndexOnLine

		private static readonly DependencyProperty ItemIndexOnLineProperty =
			DependencyProperty.RegisterAttached("ItemIndexOnLine", typeof(int), typeof(WrapPanel), new PropertyMetadata(-1));

		public static int GetItemIndexOnLine(UIElement d)
		{
			if (d is null)
				throw new ArgumentNullException("d");
			return (int)d.GetValue(ItemIndexOnLineProperty);
		}

		#endregion ItemIndexOnLine

		#region IsOnFirstLine

		private static readonly DependencyProperty IsOnFirstLineProperty =
			DependencyProperty.RegisterAttached("IsOnFirstLine", typeof(bool), typeof(WrapPanel), new PropertyMetadata(false));

		public static bool GetIsOnFirstLine(UIElement d)
		{
			if (d is null)
				throw new ArgumentNullException("d");
			return (bool)d.GetValue(IsOnFirstLineProperty);
		}

		#endregion IsOnFirstLine

		#region IsOnLastLine

		private static readonly DependencyProperty IsOnLastLineProperty =
			DependencyProperty.RegisterAttached("IsOnLastLine", typeof(bool), typeof(WrapPanel), new PropertyMetadata(false));

		public static bool GetIsOnLastLine(UIElement d)
		{
			if (d is null)
				throw new ArgumentNullException("d");
			return (bool)d.GetValue(IsOnLastLineProperty);
		}

		#endregion IsOnLastLine

		#region IsFirstItemOnLine

		private static readonly DependencyProperty IsFirstItemOnLineProperty =
			DependencyProperty.RegisterAttached("IsFirstItemOnLine", typeof(bool), typeof(WrapPanel), new PropertyMetadata(false));

		public static bool GetIsFirstItemOnLine(UIElement d)
		{
			if (d is null)
				throw new ArgumentNullException("d");
			return (bool)d.GetValue(IsFirstItemOnLineProperty);
		}

		#endregion IsFirstItemOnLine

		#region IsLastItemOnLine

		private static readonly DependencyProperty IsLastItemOnLineProperty =
			DependencyProperty.RegisterAttached("IsLastItemOnLine", typeof(bool), typeof(WrapPanel), new PropertyMetadata(false));

		public static bool GetIsLastItemOnLine(UIElement d)
		{
			if (d is null)
				throw new ArgumentNullException("d");
			return (bool)d.GetValue(IsLastItemOnLineProperty);
		}

		#endregion IsLastItemOnLine

		#endregion Attached Properties

		#region Overrides

		protected override Size MeasureOverride(Size constraint)
		{
			// Determine the size needed per item to accomodate ItemSpacing
			var itemSpacing = this.ItemSpacing;
			var itemSpacingSize = new UVSize(this.Orientation,
				itemSpacing.Left + itemSpacing.Right,
				itemSpacing.Top + itemSpacing.Bottom);

			// Determine the available size (given to each child) using the constraint and any specified uniform item extents
			var uniformWidth = this.ItemWidth;
			var uniformHeight = this.ItemHeight;
			var isWidthUniform = !double.IsNaN(uniformWidth);
			var isHeightUniform = !double.IsNaN(uniformHeight);
			var availableSize = new Size(
				isWidthUniform ? uniformWidth : constraint.Width,
				isHeightUniform ? uniformHeight : constraint.Height);

			// Extend the constraint with the ItemSpacing for wrapping computation
			var constraintSize = new UVSize(this.Orientation,
				constraint.Width + itemSpacing.Left + itemSpacing.Right,
				constraint.Height + itemSpacing.Top + itemSpacing.Bottom);

			// Begine with an empty size
			var resultSize = new UVSize(this.Orientation);

			// Only extend the result if there are children
			var children = base.Children;
			var childCount = children.Count;
			if (childCount > 0)
			{
				// Begin a new, empty line
				var lineSize = new UVSize(this.Orientation);

				// Iterate through the children
				for (var childIndex = 0; childIndex < childCount; ++childIndex)
				{
					var child = children[childIndex];
					if (child is not null && child.Visibility != Visibility.Collapsed)
					{
						// Measure the child
						child.Measure(availableSize);

						// Adjust the child size if we're using a uniform extent
						var childSize = new UVSize(this.Orientation,
							isWidthUniform ? uniformWidth : child.DesiredSize.Width,
							isHeightUniform ? uniformHeight : child.DesiredSize.Height);

						// Extend the child size to include the full ItemSpacing
						childSize.U += itemSpacingSize.U;
						childSize.V += itemSpacingSize.V;

						// Determine if the child will need to wrap
						var willWrap = lineSize.U + childSize.U > constraintSize.U;
						if (willWrap)
						{
							// Finish-up current line
							resultSize.U = Math.Max(resultSize.U, lineSize.U);
							resultSize.V += lineSize.V;

							// Begin a new line containing the child, which may itself wrap if the item alone extends beyond our constraint
							willWrap = childSize.U > constraintSize.U;
							if (willWrap)
							{
								// Finish-up this single-item line
								resultSize.U = Math.Max(resultSize.U, childSize.U);
								resultSize.V += childSize.V;

								// Begin a new, empty line
								lineSize = new UVSize(this.Orientation);
							}
							else
							{
								// Begin a new line with this single item
								lineSize = childSize;
							}
						}
						else
						{
							// Extend the line extents
							lineSize.U += childSize.U;
							lineSize.V = Math.Max(childSize.V, lineSize.V);
						}
					}
				}

				// Finish-up the final line, deflating the result by the ItemSpacing
				resultSize.U = Math.Max(resultSize.U, lineSize.U) - itemSpacingSize.U;
				resultSize.V += lineSize.V - itemSpacingSize.V;
			}

			// Return the size needed for layout
			return new Size(Math.Max(0, resultSize.Width), Math.Max(0, resultSize.Height));
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			// Determine the size needed per item to accomodate ItemSpacing
			var itemSpacing = this.ItemSpacing;
			var itemSpacingSize = new UVSize(this.Orientation,
				itemSpacing.Left + itemSpacing.Right,
				itemSpacing.Top + itemSpacing.Bottom);
			var itemSpacingLeadingSize = new UVSize(this.Orientation,
				ItemSpacing.Left,
				ItemSpacing.Top);

			// Extend the constraint with the ItemSpacing for wrapping computation
			var constraintSize = new UVSize(this.Orientation, finalSize.Width, finalSize.Height);
			constraintSize.U += itemSpacingSize.U;
			constraintSize.V += itemSpacingSize.V;

			// Determine if uniform item extents are in use
			var uniformWidth = this.ItemWidth;
			var uniformHeight = this.ItemHeight;
			var isWidthUniform = !double.IsNaN(uniformWidth);
			var isHeightUniform = !double.IsNaN(uniformHeight);
			var useUniformU = (this.Orientation == Orientation.Horizontal) ? isWidthUniform : isHeightUniform;
			var uniformU = useUniformU ? uniformWidth : uniformHeight;

			// Only extend the result if there are children
			var lineIndex = 0;
			var children = base.Children;
			var childCount = children.Count;
			if (childCount > 0)
			{
				// Begin at the start of the V extent with a new, empty line
				var lineOriginV = default(double);
				var lineExtent = new UVSize(this.Orientation);

				// Iterate through the children
				var start = 0;
				for (var end = 0; end < childCount; ++end)
				{
					var child = children[end];
					if (child is not null && child.Visibility != Visibility.Collapsed)
					{
						// Use the child's DesiredSize unless we're using a uniform extent
						var childSize = new UVSize(this.Orientation,
							isWidthUniform ? uniformWidth : child.DesiredSize.Width,
							isHeightUniform ? uniformHeight : child.DesiredSize.Height);

						// Extend the child size to include the full ItemSpacing
						childSize.U += itemSpacingSize.U;
						childSize.V += itemSpacingSize.V;

						// Determine if the child will need to wrap
						var willWrap = lineExtent.U + childSize.U > constraintSize.U;
						if (willWrap)
						{
							// Finish-up current line
							this.ArrangeLine(lineIndex++, lineOriginV, lineExtent.V, start, end, useUniformU, uniformU);
							lineOriginV += lineExtent.V;
							if (start == 0)
								lineOriginV -= itemSpacingLeadingSize.U;

							// Begin a new line containing the child, which may itself wrap if the item alone extends beyond our constraint
							willWrap = childSize.U > constraintSize.U;
							if (willWrap)
							{
								// Finish-up this single-item line
								this.ArrangeLine(lineIndex++, lineOriginV, childSize.V, end, ++end, useUniformU, uniformU);
								lineOriginV += childSize.V;

								// Begin a new, empty line
								lineExtent = new UVSize(this.Orientation);
							}
							else
							{
								// Begin a new line with this single item
								lineExtent = childSize;
							}
							start = end;
						}
						else
						{
							// Extend the line extents
							lineExtent.U += childSize.U;
							lineExtent.V = Math.Max(childSize.V, lineExtent.V);
						}
					}
					else if (child is not null)
					{
						child.ClearValue(LineIndexProperty);
						child.ClearValue(ItemIndexOnLineProperty);
						child.ClearValue(IsOnFirstLineProperty);
						child.ClearValue(IsOnLastLineProperty);
						child.ClearValue(IsFirstItemOnLineProperty);
						child.ClearValue(IsLastItemOnLineProperty);
					}
				}

				// Finish-up the final line
				if (start < children.Count)
				{
					this.ArrangeLine(lineIndex++, lineOriginV, lineExtent.V, start, children.Count, useUniformU, uniformU);
				}
			}

			SetValue(LineCountProperty, lineIndex);

			// Return the original size specified
			return finalSize;
		}

		#endregion Overrides

		#region Private Implementation

		private void ArrangeLine(int lineIndex, double lineOriginV, double lineExtentV, int start, int end, bool useUniformU, double uniformU)
		{
			var isHorizontal = this.Orientation == Orientation.Horizontal;

			// Begin the extents to offset the ItemSpacing leading values
			var itemSpacingSize = new UVSize(this.Orientation, ItemSpacing.GetWidth(), ItemSpacing.GetHeight());
			var itemSpacingLeadingSize = new UVSize(this.Orientation, ItemSpacing.Left, ItemSpacing.Top);
			if (lineOriginV == 0.0)
				lineOriginV -= itemSpacingLeadingSize.V;
			var lineOriginU = -itemSpacingLeadingSize.U;

			// Iterate through the children on this line
			var children = base.Children;
			var indexOnLine = 0;
			var isOnFirstLine = lineIndex == 0;
			var isOnLastLine = children.OfType<UIElement>().Reverse().Where(e => e is not null && e.Visibility != Visibility.Collapsed).FirstOrDefault() == children[end - 1];
			var isFirstItemOnLine = true;
			for (var i = start; i < end; ++i)
			{
				var child = children[i];
				if (child is not null && child.Visibility != Visibility.Collapsed)
				{
					// Set attached properties on the child
					SetValue(LineIndexProperty, lineIndex);
					SetValue(ItemIndexOnLineProperty, indexOnLine++);
					SetOrClearBooleanValue(IsOnFirstLineProperty, isOnFirstLine);
					SetOrClearBooleanValue(IsOnLastLineProperty, isOnLastLine);
					SetOrClearBooleanValue(IsFirstItemOnLineProperty, isFirstItemOnLine);
					SetOrClearBooleanValue(IsLastItemOnLineProperty, i == end);
					isFirstItemOnLine = false;

					// Adjust the child size if we're using a uniform extent
					var childSize = new UVSize(this.Orientation, child.DesiredSize.Width, child.DesiredSize.Height);
					var childExtentU = useUniformU ? uniformU : childSize.U;

					// Create an orientation-interpreted rectangle for the child
					var childRect = isHorizontal
						? new Rect(lineOriginU, lineOriginV, childExtentU, lineExtentV - itemSpacingSize.V)
						: new Rect(lineOriginV, lineOriginU, lineExtentV - itemSpacingSize.V, childExtentU);

					// Adjust the rectangle to offset the ItemSpacing leading values
					childRect = childRect.OffsetTopLeft(this.ItemSpacing);

					// Arrange the child into place
					child.Arrange(childRect);

					// Adjust the line pointer
					lineOriginU += childExtentU + itemSpacingSize.U;
				}
			}
		}

		private void SetOrClearBooleanValue(DependencyProperty dp, bool value)
		{
			if (value)
				SetValue(dp, true);
			else
				ClearValue(dp);
		}

		private static void PropertyAffectingMeasureChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var instance = (WrapPanel)d;
			instance.InvalidateMeasure();
		}

		#endregion Private Implementation

		#region Nested Types

		[DebuggerDisplay("U x V = {U} x {V}, Orientation={_orientation}, Width x Height = {Width} x {Height}")]
		[StructLayout(LayoutKind.Sequential)]
		private struct UVSize
		{
			public double U;
			public double V;
			private Orientation _orientation;

			public UVSize(Orientation orientation, double width, double height)
			{
				this.U = this.V = 0.0;
				this._orientation = orientation;
				this.Width = width;
				this.Height = height;
			}

			public UVSize(Orientation orientation)
			{
				this.U = this.V = 0.0;
				this._orientation = orientation;
			}

			public double Width
			{
				get
				{
					return _orientation != Orientation.Horizontal
						? this.V
						: this.U;
				}
				set
				{
					if (_orientation == Orientation.Horizontal)
						this.U = value;
					else
						this.V = value;
				}
			}

			public double Height
			{
				get
				{
					return _orientation != Orientation.Vertical
						? this.V
						: this.U;
				}
				set
				{
					if (_orientation == Orientation.Vertical)
						this.U = value;
					else
						this.V = value;
				}
			}
		}

		#endregion Nested Types
	}
}
