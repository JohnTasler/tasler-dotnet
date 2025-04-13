#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;
using OrientationType = Windows.UI.Xaml.Controls.Orientation;
namespace Tasler.UI.Xaml.Controls;

#elif WINDOWS_WPF
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using OrientationType = System.Windows.Controls.Orientation;
namespace Tasler.Windows.Controls;
#endif

using DPFactory = DependencyPropertyFactory<SegmentBarBase>;

[TemplateVisualState(GroupName = OrientationStates.GroupName, Name = OrientationStates.Horizontal)]
[TemplateVisualState(GroupName = OrientationStates.GroupName, Name = OrientationStates.Vertical)]
public abstract class SegmentBarBase : RangeBase
{
	#region Constants
	private static class OrientationStates
	{
		public const string GroupName = nameof(OrientationStates);
		public const string Horizontal = nameof(Horizontal);
		public const string Vertical = nameof(Vertical);
	}
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
		DPFactory.Register<Orientation>(nameof(Orientation), OrientationType.Horizontal, OrientationPropertyChanged);

	public Orientation Orientation
	{
		get => (Orientation)this.GetValue(OrientationProperty);
		set => this.SetValue(OrientationProperty, value);
	}

	private static void OrientationPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (SegmentBarBase)d;
		var oldValue = (Orientation)e.OldValue;
		var newValue = (Orientation)e.NewValue;
		@this.OnOrientationChanged(oldValue, newValue);
	}

	private string OrientationStateName => this.Orientation == Orientation.Horizontal
		? OrientationStates.Horizontal
		: OrientationStates.Vertical;

	#endregion Orientation

	#region SegmentExtent

	public static readonly DependencyProperty SegmentExtentProperty =
		DPFactory.Register<double>(nameof(SegmentExtent), 4.0d, SegmentExtentPropertyChanged);

	public double SegmentExtent
	{
		get => (double)this.GetValue(SegmentExtentProperty);
		set => this.SetValue(SegmentExtentProperty, value);
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
		DPFactory.Register<double>(nameof(SegmentGapExtent), 1.0d, SegmentGapExtentPropertyChanged);

	public double SegmentGapExtent
	{
		get => (double)this.GetValue(SegmentGapExtentProperty);
		set => this.SetValue(SegmentGapExtentProperty, value);
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
		DPFactory.Register<TimeSpan>(nameof(PeakHoldDuration), TimeSpan.Zero, PeakHoldDurationPropertyChanged);

	public TimeSpan PeakHoldDuration
	{
		get => (TimeSpan)this.GetValue(PeakHoldDurationProperty);
		set => this.SetValue(PeakHoldDurationProperty, value);
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
		DPFactory.Register<Brush>(nameof(PeakHoldBrush), PeakHoldBrushPropertyChanged);

	public Brush PeakHoldBrush
	{
		get => (Brush)this.GetValue(PeakHoldBrushProperty);
		set => this.SetValue(PeakHoldBrushProperty, value);
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
		DPFactory.Register<double>(nameof(PeakValue), 0.0d, PeakValuePropertyChanged);

	public double PeakValue
	{
		get => (double)this.GetValue(PeakValueProperty);
		set => this.SetValue(PeakValueProperty, value);
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

	protected abstract void OnUpdateSegments();

	protected virtual void OnUpdatePeak()
	{
	}

	#endregion Overridables

	#region Overrides

	protected override void OnValueChanged(double oldValue, double newValue)
	{
		base.OnValueChanged(oldValue, newValue);
		this.OnUpdateSegments();
	}

	/// <summary>
	/// Invoked whenever application code or internal processes (such as a rebuilding layout pass) call
	/// <see cref="ApplyTemplate" />. In simplest terms, this means the
	/// method is called just before a UI element displays in an application.
	/// </summary>
#if WINDOWS_UWP
	protected override void OnApplyTemplate()
#elif WINDOWS_WPF
	public override void OnApplyTemplate()
#endif
	{
		base.OnApplyTemplate();
		VisualStateManager.GoToState(this, this.OrientationStateName, false);
	}

#endregion Overrides
}
