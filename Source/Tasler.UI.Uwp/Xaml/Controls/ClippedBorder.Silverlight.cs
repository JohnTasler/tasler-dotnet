using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using Tasler.Windows.Extensions;
using Tasler.Windows.Media;

namespace Tasler.Windows.Controls
{
	public class ClippedBorder : Decorator
	{
		#region Instance Fields
		private Border _innerBorder;
		#endregion Instance Fields

		#region Constructor

		public ClippedBorder()
		{
			_innerBorder = new Border();
			this.Children.Add(_innerBorder);

			this.SetBorderBinding(Border.BackgroundProperty, BackgroundProperty);
			this.SetBorderBinding(Border.BorderBrushProperty, BorderBrushProperty);
			this.SetBorderBinding(Border.BorderThicknessProperty, BorderThicknessProperty);
			this.SetBorderBinding(Border.CornerRadiusProperty, CornerRadiusProperty);
			this.SetBorderBinding(Border.PaddingProperty, PaddingProperty);
		}

		#endregion Constructor

		#region Dependency Properties

		#region Background

		public static readonly new DependencyProperty BackgroundProperty =
			DependencyProperty.Register("Background", typeof(Brush), typeof(ClippedBorder),
			new PropertyMetadata(default(Brush)));

		public new Brush Background
		{
			get { return (Brush)this.GetValue(BackgroundProperty); }
			set { this.SetValue(BackgroundProperty, value); }
		}

		#endregion Background

		#region BorderBrush

		public static readonly DependencyProperty BorderBrushProperty =
			DependencyProperty.Register("BorderBrush", typeof(Brush), typeof(ClippedBorder),
			new PropertyMetadata(default(Brush)));

		public Brush BorderBrush
		{
			get { return (Brush)this.GetValue(BorderBrushProperty); }
			set { this.SetValue(BorderBrushProperty, value); }
		}

		#endregion BorderBrush

		#region BorderThickness

		public static readonly DependencyProperty BorderThicknessProperty =
			DependencyProperty.Register("BorderThickness", typeof(Thickness), typeof(ClippedBorder),
			new PropertyMetadata(default(Thickness)));

		public Thickness BorderThickness
		{
			get { return (Thickness)this.GetValue(BorderThicknessProperty); }
			set { this.SetValue(BorderThicknessProperty, value); }
		}

		#endregion BorderThickness

		#region CornerRadius

		public static readonly DependencyProperty CornerRadiusProperty =
			DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(ClippedBorder),
			new PropertyMetadata(default(CornerRadius)));

		public CornerRadius CornerRadius
		{
			get { return (CornerRadius)this.GetValue(CornerRadiusProperty); }
			set { this.SetValue(CornerRadiusProperty, value); }
		}

		#endregion CornerRadius

		#region Padding

		public static readonly DependencyProperty PaddingProperty =
			DependencyProperty.Register("Padding", typeof(Thickness), typeof(ClippedBorder),
			new PropertyMetadata(default(Thickness)));

		public Thickness Padding
		{
			get { return (Thickness)this.GetValue(PaddingProperty); }
			set { this.SetValue(PaddingProperty, value); }
		}

		#endregion Padding

		#endregion Dependency Properties

		#region Overrides
		protected override void OnChildPropertyChanged(UIElement oldValue, UIElement newValue)
		{
			_innerBorder.Child = newValue;
		}

		protected override Size MeasureOverride(Size constraint)
		{
			// Allow the inner Border to use the entire size
			_innerBorder.Measure(constraint);
			return _innerBorder.DesiredSize;
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			// Move the inner Border to use the entire size
			_innerBorder.Arrange(new Rect(new Point(), finalSize));

			// Clip to the interior
			if (_innerBorder.Child != null)
				_innerBorder.Child.Clip = this.GenerateChildClipGeometry(finalSize);

			// Return the final size
			return finalSize;
		}
		#endregion Overrides

		#region Private Implementation
		private void SetBorderBinding(DependencyProperty targetProperty, DependencyProperty sourceProperty)
		{
			_innerBorder.SetBinding(targetProperty, new Binding
			{
				Source = this,
				Path = new PropertyPath(sourceProperty),
				Mode = BindingMode.OneWay
			});
		}

		private Geometry GenerateChildClipGeometry(Size finalSize)
		{
			var cornerRadius = this.CornerRadius;
			if (cornerRadius.TopLeft == 0.0 && cornerRadius.BottomLeft == 0.0
			 && cornerRadius.TopRight == 0.0 && cornerRadius.BottomRight == 0.0)
				return null;

			var bounds = new Rect(0, 0, finalSize.Width, finalSize.Height);
			var tranform = this.TransformToVisual(_innerBorder.Child);
			var childBounds = tranform.TransformBounds(bounds);

			var geometry = GeometryBuilder.BuildRoundedRectangle(
				childBounds.Deflate(this.BorderThickness), this.CornerRadius, this.BorderThickness, false);
			return geometry;
		}
		#endregion Private Implementation
	}
}