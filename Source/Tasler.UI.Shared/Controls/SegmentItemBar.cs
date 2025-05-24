using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Tasler.UI.Xaml.Extensions;
namespace Tasler.UI.Xaml.Controls;

#elif WINDOWS_WPF
using System.Windows;
using System.Windows.Controls;
using Tasler.Collections;
using Tasler.Windows.Extensions;
namespace Tasler.Windows.Controls;

#endif

using DPFactory = DependencyPropertyFactory<SegmentItemBar>;

public partial class SegmentItemBar : SegmentBarBase
{
	#region Instance Fields
	private ObservableCollection<SegmentItem> _segmentItems = [];
	#endregion Instance Fields

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the <see cref="SegmentItemBar"/> class.
	/// </summary>
	public SegmentItemBar()
	{
		this.SetDefaultStyleKey();

		this.SegmentItems = new ReadOnlyObservableCollection<SegmentItem>(_segmentItems);
	}
	#endregion Constructors

	#region SegmentGapThickness

	public static readonly DependencyProperty SegmentGapThicknessProperty =
		DPFactory.Register<Thickness>(nameof(SegmentGapThickness), default(Thickness));

	public Thickness SegmentGapThickness
	{
		get => (Thickness)this.GetValue(SegmentGapThicknessProperty);
		private set => this.SetValue(SegmentGapThicknessProperty, value);
	}

	#endregion SegmentGapThickness

	#region SegmentItems

	public static readonly DependencyProperty SegmentItemsProperty =
		DPFactory.Register<IEnumerable<SegmentItem>>(nameof(SegmentItems));

	public IEnumerable<SegmentItem> SegmentItems
	{
		get => (IEnumerable<SegmentItem>)GetValue(SegmentItemsProperty);
		private set => SetValue(SegmentItemsProperty, value);
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
	public partial class SegmentItem : ObservableObject
	{
		public SegmentItem(SegmentItemBar owner) => _owner = owner;

		#region Owner

		public SegmentItemBar Owner => _owner;
		private SegmentItemBar _owner;

		#endregion Owner

		#region Intensity

		[ObservableProperty]
		public partial double Intensity { get; set; }

		#endregion Intensity

	}
	#endregion Nested Types
}
