using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Tasler.Windows.Controls;

[TemplateVisualState(GroupName = OrientationStateGroupName, Name = OrientationStateHorizontal)]
[TemplateVisualState(GroupName = OrientationStateGroupName, Name = OrientationStateVertical)]
public abstract class SegmentBarBase : RangeBase
{
	#region Constants
	private const string OrientationStateGroupName = "OrientationStates";
	private const string OrientationStateHorizontal = "Horizontal";
	private const string OrientationStateVertical = "Vertical";
	#endregion Constants

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the <see cref="SegmentBarBase"/> class.
	/// </summary>
	public SegmentBarBase()
	{
		this.SizeChanged += (s, e) => this.OnUpdateSegments();
	}
	#endregion Constructors

	#region Orientation

	public static readonly DependencyProperty OrientationProperty =
		DependencyProperty.Register(nameof(Orientation), typeof(System.Windows.Controls.Orientation), typeof(SegmentBarBase),
			new PropertyMetadata(System.Windows.Controls.Orientation.Horizontal, OrientationPropertyChanged));

	public System.Windows.Controls.Orientation Orientation
	{
		get => (System.Windows.Controls.Orientation)this.GetValue(OrientationProperty);
		set => this.SetValue(OrientationProperty, value);
	}

	private static void OrientationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (SegmentBarBase)d;
		var oldValue = (Orientation)e.OldValue;
		var newValue = (Orientation)e.NewValue;
		@this.OnOrientationChanged(oldValue, newValue);
	}

	private string OrientationStateName
	{
		get { return this.Orientation == Orientation.Horizontal ? OrientationStateHorizontal : OrientationStateVertical; }
	}

	#endregion Orientation

	#region SegmentExtent

	public static readonly DependencyProperty SegmentExtentProperty =
		DependencyProperty.Register(nameof(SegmentExtent), typeof(double), typeof(SegmentBarBase),
			new PropertyMetadata(4.0, SegmentExtentPropertyChanged));

	public double SegmentExtent
	{
		get => (double)GetValue(SegmentExtentProperty);
		set => SetValue(SegmentExtentProperty, value);
	}

	private static void SegmentExtentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (SegmentBarBase)d;
		var oldValue = (double)e.OldValue;
		var newValue = (double)e.NewValue;
		@this.OnSegmentExtentChanged(oldValue, newValue);
	}

	#endregion SegmentExtent

	#region SegmentGapExtent

	public static readonly DependencyProperty SegmentGapExtentProperty =
		DependencyProperty.Register(nameof(SegmentGapExtent), typeof(double), typeof(SegmentBarBase),
			new PropertyMetadata(1.0, SegmentGapExtentPropertyChanged));

	public double SegmentGapExtent
	{
		get => (double)GetValue(SegmentGapExtentProperty);
		set => SetValue(SegmentGapExtentProperty, value);
	}

	private static void SegmentGapExtentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (SegmentBarBase)d;
		var oldValue = (double)e.OldValue;
		var newValue = (double)e.NewValue;
		@this.OnSegmentGapExtentChanged(oldValue, newValue);
	}

	#endregion SegmentGapExtent

	#region PeakHoldDuration

	public static readonly DependencyProperty PeakHoldDurationProperty =
		DependencyProperty.Register(nameof(PeakHoldDuration), typeof(TimeSpan), typeof(SegmentBarBase),
			new PropertyMetadata(TimeSpan.Zero, PeakHoldDurationPropertyChanged));

	public TimeSpan PeakHoldDuration
	{
		get => (TimeSpan)GetValue(PeakHoldDurationProperty);
		set => SetValue(PeakHoldDurationProperty, value);
	}

	private static void PeakHoldDurationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (SegmentBarBase)d;
		var oldValue = (TimeSpan)e.OldValue;
		var newValue = (TimeSpan)e.NewValue;
		@this.OnPeakHoldDurationChanged(oldValue, newValue);
	}

	#endregion PeakHoldDuration

	#region PeakHoldBrush

	public static readonly DependencyProperty PeakHoldBrushProperty =
		DependencyProperty.Register("PeakHoldBrush", typeof(Brush), typeof(SegmentBarBase),
			new PropertyMetadata(null, PeakHoldBrushPropertyChanged));

	public Brush PeakHoldBrush
	{
		get { return (Brush)GetValue(PeakHoldBrushProperty); }
		set { SetValue(PeakHoldBrushProperty, value); }
	}

	private static void PeakHoldBrushPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (SegmentBarBase)d;
		var oldValue = (Brush)e.OldValue;
		var newValue = (Brush)e.NewValue;
		@this.OnPeakHoldBrushChanged(oldValue, newValue);
	}

	#endregion PeakHoldBrush

	#region PeakValue

	public static readonly DependencyProperty PeakValueProperty =
		DependencyProperty.Register("PeakValue", typeof(double), typeof(SegmentBarBase),
			new PropertyMetadata(0.0, PeakValuePropertyChanged));

	public double PeakValue
	{
		get { return (double)GetValue(PeakValueProperty); }
		set { SetValue(PeakValueProperty, value); }
	}

	private static void PeakValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (SegmentBarBase)d;
		var oldValue = (double)e.OldValue;
		var newValue = (double)e.NewValue;
		@this.OnPeakValueChanged(oldValue, newValue);
	}

	#endregion PeakValue

	#region Overridables

	protected virtual void OnOrientationChanged(Orientation oldValue, Orientation newValue)
	{
		VisualStateManager.GoToState(this, this.OrientationStateName, false);
		this.OnUpdateSegments();
	}

	protected virtual void OnSegmentExtentChanged(double oldValue, double newValue)
	{
		this.OnUpdateSegments();
	}

	protected virtual void OnSegmentGapExtentChanged(double oldValue, double newValue)
	{
		this.OnUpdateSegments();
	}

	protected virtual void OnPeakHoldDurationChanged(TimeSpan oldValue, TimeSpan newValue)
	{
	}

	protected virtual void OnPeakHoldBrushChanged(Brush oldValue, Brush newValue)
	{
	}

	protected virtual void OnPeakValueChanged(double oldValue, double newValue)
	{
		this.OnUpdatePeak();
	}

	protected override void OnValueChanged(double oldValue, double newValue)
	{
		base.OnValueChanged(oldValue, newValue);
		this.OnUpdateSegments();
	}

	protected abstract void OnUpdateSegments();

	protected virtual void OnUpdatePeak()
	{
	}

	#endregion Overridables

	#region Overrides

	/// <summary>
	/// Invoked whenever application code or internal processes (such as a rebuilding layout pass) call
	/// <see cref="M:System.Windows.Controls.Control.ApplyTemplate" />. In simplest terms, this means the
	/// method is called just before a UI element displays in an application.
	/// </summary>
	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		VisualStateManager.GoToState(this, this.OrientationStateName, false);
	}

	#endregion Overrides
}
