using Tasler.Windows.Extensions;

namespace Tasler.Windows.Controls;

/// <summary>
/// An derivation of <see cref="SegmentBarBase"/> with the rendering implemented using an opacity brush.
/// TODO: Incomplete. See remarks
/// </summary>
/// <remarks>
/// Stopped working on this because it occurred to me that creating a new brush 100 times per second could
/// quickly exaust the GC small object pool. Since a Brush is a Freezable, it seems there's no way to reuse
/// the same brush for each update. Revisit when more options come to mind.
/// </remarks>
[Obsolete("SegmentOpacityBar is not yet implemented. Use SegmentItemBar instead.", true)]
public class SegmentOpacityBar : SegmentBarBase
{
	#region Instance Fields
	#endregion Instance Fields

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the <see cref="SegmentItemBar"/> class.
	/// </summary>
	public SegmentOpacityBar()
	{
		this.SetDefaultStyleKey();
	}
	#endregion Constructors

	//#region SegmentGapThickness

	//public static readonly DependencyProperty SegmentGapThicknessProperty =
	//	DependencyProperty.Register("SegmentGapThickness", typeof(Thickness), typeof(SegmentOpacityBar),
	//		new PropertyMetadata(default(Thickness)));

	//public Thickness SegmentGapThickness
	//{
	//	get { return (Thickness)GetValue(SegmentGapThicknessProperty); }
	//	private set { SetValue(SegmentGapThicknessProperty, value); }
	//}

	//#endregion SegmentGapThickness

	#region Overrides

	protected override void OnUpdateSegments()
	{
		var extent = this.Orientation == System.Windows.Controls.Orientation.Horizontal ? this.ActualWidth : this.ActualHeight;
		var calcExtent = extent + this.SegmentGapExtent - 1;
		var fullSegmentExtent = this.SegmentExtent + this.SegmentGapExtent;
		var newSegmentCount = (int)(calcExtent / fullSegmentExtent);
		//var oldSegmentCount = _segmentItems.Count;

		//// Grow or shrink the collection as needed
		//if (newSegmentCount > oldSegmentCount)
		//	_segmentItems.Grow(newSegmentCount, () => new SegmentItem(this));
		//else if (newSegmentCount < oldSegmentCount)
		//	_segmentItems.Shrink(newSegmentCount);

		//// Project the current value across the segments
		//var range = this.Maximum - this.Minimum;
		//var value = (this.Value - this.Minimum) / range;
		//var quotient = value * newSegmentCount;
		//var flooredQuotient = (int)quotient;
		//var remainder = quotient - flooredQuotient;

		//// Recompute the intensity of each segment
		//var index = 0;
		//while (index < flooredQuotient && index < newSegmentCount)
		//	_segmentItems[index++].Intensity = 1.0;
		//if (index < newSegmentCount)
		//	_segmentItems[index++].Intensity = remainder;
		//while (index < newSegmentCount)
		//	_segmentItems[index++].Intensity = 0.0;
	}

	#endregion Overrides

	#region Private Implementation

	#endregion Private Implementation

	#region Nested Types
	#endregion Nested Types
}
