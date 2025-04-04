using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Tasler.ComponentModel;
using Tasler.Extensions;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Controls
{
	public class SegmentItemBar : SegmentBarBase
	{
		#region Instance Fields
		private ObservableCollection<SegmentItem> _segmentItems;
		#endregion Instance Fields

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="SegmentItemBar"/> class.
		/// </summary>
		public SegmentItemBar()
		{
			this.SetDefaultStyleKey();

			_segmentItems = new ObservableCollection<SegmentItem>();
			this.SegmentItems = new ReadOnlyObservableCollection<SegmentItem>(_segmentItems);
		}
		#endregion Constructors

		#region SegmentGapThickness

		public static readonly DependencyProperty SegmentGapThicknessProperty =
			DependencyProperty.Register("SegmentGapThickness", typeof(Thickness), typeof(SegmentItemBar),
				new PropertyMetadata(default(Thickness)));

		public Thickness SegmentGapThickness
		{
			get { return (Thickness)GetValue(SegmentGapThicknessProperty); }
			private set { SetValue(SegmentGapThicknessProperty, value); }
		}

		#endregion SegmentGapThickness

		#region SegmentItems

		public static readonly DependencyProperty SegmentItemsProperty =
			DependencyProperty.Register("SegmentItems", typeof(IEnumerable<SegmentItem>), typeof(SegmentItemBar),
				new PropertyMetadata(null));

		public IEnumerable<SegmentItem> SegmentItems
		{
			get { return (IEnumerable<SegmentItem>)GetValue(SegmentItemsProperty); }
			private set { SetValue(SegmentItemsProperty, value); }
		}

		#endregion SegmentItems

		#region Overrides

		protected override void OnOrientationChanged(Orientation oldValue, Orientation newValue)
		{
			base.OnOrientationChanged(oldValue, newValue);
			this.RecalculateSegmentGapThickness();
		}

		protected override void OnSegmentGapExtentChanged(double oldValue, double newValue)
		{
			base.OnSegmentGapExtentChanged(oldValue, newValue);
			this.RecalculateSegmentGapThickness();
		}

		protected override void OnUpdateSegments()
		{
			var extent = this.Orientation == Orientation.Horizontal ? this.ActualWidth : this.ActualHeight;
			var calcExtent = extent + this.SegmentGapExtent - 1;
			var fullSegmentExtent = this.SegmentExtent + this.SegmentGapExtent;
			var newSegmentCount = (int)(calcExtent / fullSegmentExtent);
			var oldSegmentCount = _segmentItems.Count;

			// Grow or shrink the collection as needed
			if (newSegmentCount > oldSegmentCount)
				_segmentItems.Grow(newSegmentCount, () => new SegmentItem(this));
			else if (newSegmentCount < oldSegmentCount)
				_segmentItems.Shrink(newSegmentCount);

			// Project the current value across the segments
			var range = this.Maximum - this.Minimum;
			var value = (this.Value - this.Minimum) / range;
			var quotient = value * newSegmentCount;
			var flooredQuotient = (int)quotient;
			var remainder = quotient - flooredQuotient;

			// Recompute the intensity of each segment
			var index = 0;
			while (index < flooredQuotient && index < newSegmentCount)
				_segmentItems[index++].Intensity = 1.0;
			if (index < newSegmentCount)
				_segmentItems[index++].Intensity = remainder;
			while (index < newSegmentCount)
				_segmentItems[index++].Intensity = 0.0;
		}

		#endregion Overrides

		#region Private Implementation

		private void RecalculateSegmentGapThickness()
		{
			this.SegmentGapThickness = this.Orientation == Orientation.Horizontal
				? new Thickness(0, 0, this.SegmentGapExtent, 0)
				: new Thickness(0, 0, 0, this.SegmentGapExtent);
		}

		#endregion Private Implementation

		#region Nested Types
		public class SegmentItem : ModelBase
		{
			public SegmentItem(SegmentItemBar owner)
			{
				_owner = owner;
			}

			#region Owner

			public SegmentItemBar Owner
			{
				get { return _owner; }
			}
			private SegmentItemBar _owner;

			#endregion Owner

			#region Intensity

			public double Intensity
			{
				get { return _intensity; }
				set { this.SetProperty(ref _intensity, value, () => Intensity); }
			}
			private double _intensity;

			#endregion Intensity

		}
		#endregion Nested Types
	}
}
