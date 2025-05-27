using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Controls;

///<summary>
/// Base class for the toggle switch control.
///</summary>
[TemplateVisualState(Name = CommonStates.Normal, GroupName = nameof(CommonStates))]
[TemplateVisualState(Name = CommonStates.Disabled, GroupName = nameof(CommonStates))]
[TemplateVisualState(Name = CommonStates.MouseOver, GroupName = nameof(CommonStates))]
[TemplateVisualState(Name = FocusStates.Focused, GroupName = nameof(FocusStates))]
[TemplateVisualState(Name = FocusStates.Unfocused, GroupName = nameof(FocusStates))]
[TemplateVisualState(Name = CheckStates.Checked, GroupName = nameof(CheckStates))]
[TemplateVisualState(Name = CheckStates.Unchecked, GroupName = nameof(CheckStates))]
[TemplateVisualState(Name = CheckStates.Dragging + CheckStates.Checked, GroupName = nameof(CheckStates))]
[TemplateVisualState(Name = CheckStates.Dragging + CheckStates.Unchecked, GroupName = nameof(CheckStates))]
[TemplatePart(Name = PART_SwitchChecked, Type = typeof(Control))]
[TemplatePart(Name = PART_SwitchUnchecked, Type = typeof(Control))]
[TemplatePart(Name = PART_SwitchThumb, Type = typeof(Thumb))]
[TemplatePart(Name = PART_SwitchRoot, Type = typeof(FrameworkElement))]
[TemplatePart(Name = PART_SwitchTrack, Type = typeof(FrameworkElement))]
[Description("A control, which when dragged or, optionally clicked, toggles between on and off states.")]
public abstract class ToggleSwitchBase : Control, ICommandSource
{
	#region Constants

	private static class CommonStates
	{
		//private const string CommonStates = nameof(CommonStates);
		public const string Normal = nameof(Normal);
		public const string Disabled = nameof(Disabled);
		public const string MouseOver = nameof(MouseOver);
	}

	private static class CheckStates
	{
		public const string Checked = nameof(Checked);
		public const string Dragging = nameof(Dragging);
		public const string Unchecked = nameof(Unchecked);
	}

	private static class FocusStates
	{
		public const string Focused = nameof(Focused);
		public const string Unfocused = nameof(Unfocused);
	}

	private const string PART_SwitchRoot = nameof(PART_SwitchRoot);
	private const string PART_SwitchChecked = nameof(PART_SwitchChecked);
	private const string PART_SwitchUnchecked = nameof(PART_SwitchUnchecked);
	private const string PART_SwitchThumb = nameof(PART_SwitchThumb);
	private const string PART_SwitchTrack = nameof(PART_SwitchTrack);

	private const string AppearanceCategory = "Appearance";
	private const string BehaviorCategory = "Behavior";
	private const string CommonPropertiesCategory = "Common Properties";

	#endregion Constants

	#region Fields

	/// <summary>
	/// True if the SPACE key is currently pressed, false otherwise.
	/// </summary>
	private bool _isSpaceKeyDown;

	/// <summary>
	/// True if the mouse's left button is currently down, false otherwise.
	/// </summary>
	private bool _isMouseLeftButtonDown;

	/// <summary>
	/// Bounding rectangle of valid mouse move tolerance, relative to this control.
	/// </summary>
	private Rect _clickBounds;

	/// <summary>
	/// True if visual state changes are suspended; false otherwise.
	/// </summary>
	private bool _suspendStateChanges;

	#endregion Fields

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the ToggleSwitchBase class.
	/// </summary>
	protected ToggleSwitchBase()
	{
		UpdateCommandPropertiesSource();
		UpdateCanExecute(".ctor");
		Loaded += delegate { UpdateVisualState(false); };
		IsEnabledChanged += OnIsEnabledChanged;
	}
	#endregion Constructors

	#region Properties

	protected Thumb? SwitchThumb { get; set; }
	protected Control? SwitchChecked { get; set; }
	protected Control? SwitchUnchecked { get; set; }
	protected FrameworkElement? SwitchRoot { get; set; }
	protected FrameworkElement? SwitchTrack { get; set; }

	/// <summary>
	/// The current offset of the Thumb.
	/// </summary>
	protected abstract double Offset { get; set; }

	/// <summary>
	/// The current offset of the Thumb when it's in the Checked state.
	/// </summary>
	protected double CheckedOffset { get; set; }

	/// <summary>
	/// The current offset of the Thumb when it's in the Unchecked state.
	/// </summary>
	protected double UncheckedOffset { get; set; }

	/// <summary>
	/// The offset of the thumb while it's being dragged.
	/// </summary>
	protected double DragOffset { get; set; }

	/// <summary>
	/// Gets or sets whether the thumb position is being manipulated.
	/// </summary>
	protected bool IsDragging { get; set; }

	/// <summary>
	/// Gets a value that indicates whether a ToggleSwitch is currently pressed.
	/// </summary>
	public bool IsPressed { get; protected set; }

	protected abstract PropertyPath SlidePropertyPath { get; }

	#endregion Properties

	#region Dependency Properties

	#region ContentTemplate

	///<summary>
	/// DependencyProperty for the <see cref="ControlTemplate">ControlTemplate</see> property.
	///</summary>
	public static readonly DependencyProperty ContentTemplateProperty =
		DependencyProperty.Register("ContentTemplate", typeof(ControlTemplate), typeof(ToggleSwitchBase),
			new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure,
				OnLayoutDependencyPropertyChanged));

	///<summary>
	/// The template applied to the <see cref="CheckedContent"/> and <see cref="UncheckedContent/> properties.
	///</summary>
	[Description("The template applied to the CheckedContent and UncheckedContent properties.")]
	public ControlTemplate ContentTemplate
	{
		get { return (ControlTemplate)GetValue(ContentTemplateProperty); }
		set { SetValue(ContentTemplateProperty, value); }
	}

	#endregion ContentTemplate

	#region CheckedContent

	///<summary>
	/// DependencyProperty for the <see cref="CheckedContent/> property.
	///</summary>
	public static readonly DependencyProperty CheckedContentProperty =
		DependencyProperty.Register("CheckedContent", typeof(object), typeof(ToggleSwitchBase),
			new FrameworkPropertyMetadata("ON",
				FrameworkPropertyMetadataOptions.AffectsArrange, OnLayoutDependencyPropertyChanged));

	///<summary>
	/// The content shown on the checked side of the toggle switch
	///</summary>
	[Category(CommonPropertiesCategory)]
	[Description("The content shown on the checked side of the toggle switch")]
	public object CheckedContent
	{
		get { return GetValue(CheckedContentProperty); }
		set { SetValue(CheckedContentProperty, value); }
	}

	#endregion CheckedContent

	#region CheckedForeground

	///<summary>
	/// DependencyProperty for the <see cref="CheckedForeground">CheckedForeground</see> property.
	///</summary>
	public static readonly DependencyProperty CheckedForegroundProperty =
		DependencyProperty.Register("CheckedForeground", typeof(Brush), typeof(ToggleSwitchBase), null);

	///<summary>
	/// The brush used for the foreground of the checked side of the toggle switch.
	///</summary>
	[Description("The brush used for the foreground of the checked side of the toggle switch.")]
	public Brush CheckedForeground
	{
		get { return (Brush)GetValue(CheckedForegroundProperty); }
		set { SetValue(CheckedForegroundProperty, value); }
	}

	#endregion CheckedForeground

	#region CheckedBackground

	///<summary>
	/// DependencyProperty for the <see cref="CheckedBackground"/> property.
	///</summary>
	public static readonly DependencyProperty CheckedBackgroundProperty =
		DependencyProperty.Register("CheckedBackground", typeof(Brush), typeof(ToggleSwitchBase), null);

	///<summary>
	/// The brush used for the background of the checked side of the toggle switch.
	///</summary>
	[Description("The brush used for the background of the checked side of the toggle switch.")]
	public Brush CheckedBackground
	{
		get { return (Brush)GetValue(CheckedBackgroundProperty); }
		set { SetValue(CheckedBackgroundProperty, value); }
	}

	#endregion CheckedBackground

	#region UncheckedContent

	///<summary>
	/// DependencyProperty for the <see cref="UncheckedContent">UncheckedContent</see> property.
	///</summary>
	public static readonly DependencyProperty UncheckedContentProperty =
		DependencyProperty.Register("UncheckedContent", typeof(object), typeof(ToggleSwitchBase),
			new FrameworkPropertyMetadata("OFF", FrameworkPropertyMetadataOptions.AffectsArrange,
				OnLayoutDependencyPropertyChanged));

	///<summary>
	/// The content shown on the unchecked side of the toggle switch.
	///</summary>
	[Category(CommonPropertiesCategory)]
	[Description("The content shown on the unchecked side of the toggle switch.")]
	public object UncheckedContent
	{
		get { return GetValue(UncheckedContentProperty); }
		set { SetValue(UncheckedContentProperty, value); }
	}

	#endregion UncheckedContent

	#region UncheckedForeground

	///<summary>
	/// DependencyProperty for the <see cref="UncheckedForeground"/> property.
	///</summary>
	public static readonly DependencyProperty UncheckedForegroundProperty =
		DependencyProperty.Register("UncheckedForeground", typeof(Brush), typeof(ToggleSwitchBase), null);

	///<summary>
	/// The brush used for the foreground of the Unchecked side of the toggle switch.
	///</summary>
	[Description("The brush used for the foreground of the Unchecked side of the toggle switch.")]
	public Brush UncheckedForeground
	{
		get { return (Brush)GetValue(UncheckedForegroundProperty); }
		set { SetValue(UncheckedForegroundProperty, value); }
	}

	#endregion UncheckedForeground

	#region UncheckedBackground

	///<summary>
	/// DependencyProperty for the <see cref="UncheckedBackground> property.
	///</summary>
	public static readonly DependencyProperty UncheckedBackgroundProperty =
		DependencyProperty.Register("UncheckedBackground", typeof(Brush), typeof(ToggleSwitchBase), null);

	///<summary>
	/// The brush used for the background of the Unchecked side of the toggle switch.
	///</summary>
	[Description("The brush used for the background of the Unchecked side of the toggle switch.")]
	public Brush UncheckedBackground
	{
		get { return (Brush)GetValue(UncheckedBackgroundProperty); }
		set { SetValue(UncheckedBackgroundProperty, value); }
	}

	#endregion UncheckedBackground

	#region GestureMode

	///<summary>
	/// DependencyProperty for the <see cref="GestureMode">GestureMode</see> property.
	///</summary>
	public static readonly DependencyProperty GestureModeProperty =
		DependencyProperty.Register("GestureMode", typeof(ToggleGestureMode), typeof(ToggleSwitchBase),
			new FrameworkPropertyMetadata(ToggleGestureMode.All));

	///<summary>
	/// Gets or sets the input gesture(s) that will toggle the <see cref="IsChecked"/> state.
	/// <see cref="ToggleGestureMode.All"/> is the default.
	///</summary>
	[Category(BehaviorCategory)]
	[Description("Specifies which input gestures will toggle the IsChecked state.")]
	public ToggleGestureMode GestureMode
	{
		get { return (ToggleGestureMode)GetValue(GestureModeProperty); }
		set { SetValue(GestureModeProperty, value); }
	}

	#endregion GestureMode

	#region Elasticity

	///<summary>
	/// DependencyProperty for the <see cref="Elasticity">Elasticity</see> property.
	///</summary>
	public static readonly DependencyProperty ElasticityProperty =
		DependencyProperty.Register("Elasticity", typeof(double), typeof(ToggleSwitchBase),
			new PropertyMetadata(0.5, null, CoerceElasticityProperty));

	///<summary>
	/// Determines the percentage of the way the <see cref="Thumb">thumb</see> must be dragged before the switch changes it's <see cref="IsChecked">IsChecked</see> state.
	///</summary>
	///<remarks>
	/// This value must be within the range of 0.0 - 1.0.
	///</remarks>
	[Category(CommonPropertiesCategory)]
	[Description("Determines the percentage of the way the thumb must be dragged before the switch changes it's IsChecked state.")]
	public double Elasticity
	{
		get { return (double)GetValue(ElasticityProperty); }
		set { SetValue(ElasticityProperty, value); }
	}

	private static object CoerceElasticityProperty(DependencyObject d, object value)
	{
		var doubleValue = (double)value;
		return doubleValue.Clamp(0, 1.0);
	}

	#endregion Elasticity

	#region ThumbTemplate

	///<summary>
	/// DependencyProperty for the <see cref="ThumbTemplate">ThumbTemplate</see> property.
	///</summary>
	public static readonly DependencyProperty ThumbTemplateProperty =
		DependencyProperty.Register("ThumbTemplate", typeof(ControlTemplate), typeof(ToggleSwitchBase),
			new FrameworkPropertyMetadata(null,
				FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure,
				OnLayoutDependencyPropertyChanged));

	///<summary>
	/// The <see cref="Thumb">thumb's</see> control template.
	///</summary>
	[Description("The thumb's control template.")]
	public ControlTemplate ThumbTemplate
	{
		get { return (ControlTemplate)GetValue(ThumbTemplateProperty); }
		set { SetValue(ThumbTemplateProperty, value); }
	}

	#endregion ThumbTemplate

	#region ThumbBrush

	///<summary>
	/// DependencyProperty for the <see cref="ThumbBrush">ThumbBrush</see> property.
	///</summary>
	public static readonly DependencyProperty ThumbBrushProperty =
		DependencyProperty.Register("ThumbBrush", typeof(Brush), typeof(ToggleSwitchBase), null);

	///<summary>
	/// The brush used to fill the <see cref="Thumb">thumb</see>.
	///</summary>
	[Description("The brush used to fill the thumb.")]
	public Brush ThumbBrush
	{
		get { return (Brush)GetValue(ThumbBrushProperty); }
		set { SetValue(ThumbBrushProperty, value); }
	}

	#endregion ThumbBrush

	#region ThumbSize

	///<summary>
	/// DependencyProperty for the <see cref="ThumbSize">ThumbSize</see> property.
	///</summary>
	public static readonly DependencyProperty ThumbSizeProperty =
		DependencyProperty.Register("ThumbSize", typeof(double), typeof(ToggleSwitchBase),
			new FrameworkPropertyMetadata(40.0,
				FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure,
				OnLayoutDependencyPropertyChanged));

	///<summary>
	/// The size of the toggle switch's <see cref="Thumb">thumb</see>.
	///</summary>
	[Category(AppearanceCategory)]
	[Description("The size of the toggle switch's thumb.")]
	public double ThumbSize
	{
		get { return (double)GetValue(ThumbSizeProperty); }
		set { SetValue(ThumbSizeProperty, value); }
	}

	#endregion ThumbSize

	#region IsChecked

	///<summary>
	/// DependencyProperty for the <see cref="IsChecked">IsChecked</see> property.
	///</summary>
	public static readonly DependencyProperty IsCheckedProperty =
		DependencyProperty.Register("IsChecked", typeof(bool), typeof(ToggleSwitchBase),
			new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsArrange, OnIsCheckedChanged));

	///<summary>
	/// Gets or sets whether the control is in the checked state.
	///</summary>
	[Category(CommonPropertiesCategory)]
	[Description("Gets or sets whether the control is in the checked state.")]
	public bool IsChecked
	{
		get { return (bool)GetValue(IsCheckedProperty); }
		set { SetValue(IsCheckedProperty, value); }
	}

	private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var instance = (ToggleSwitchBase)d;
		var oldValue = (bool)e.OldValue;
		var newValue = (bool)e.NewValue;
		instance.OnIsCheckedChanged(oldValue, newValue);
	}

	private void OnIsCheckedChanged(bool oldValue, bool newValue)
	{
		if (newValue)
			InvokeChecked();
		else
			InvokeUnchecked();

		this.ExecuteCommandSource();
		UpdateCommandPropertiesSource();
		UpdateCanExecute("OnIsCheckedChanged");

		ChangeCheckStates(true);
	}

	#endregion IsChecked

	#region CheckedCommand trio

	#region CheckedCommand

	public static readonly DependencyProperty CheckedCommandProperty =
		DependencyProperty.Register("CheckedCommand", typeof(ICommand), typeof(ToggleSwitchBase));

	public ICommand CheckedCommand
	{
		get { return (ICommand)GetValue(CheckedCommandProperty); }
		set { SetValue(CheckedCommandProperty, value); }
	}

	#endregion CheckedCommand

	#region CheckedCommandParameter

	public static readonly DependencyProperty CheckedCommandParameterProperty =
		DependencyProperty.Register("CheckedCommandParameter", typeof(object), typeof(ToggleSwitchBase));

	public object CheckedCommandParameter
	{
		get { return GetValue(CheckedCommandParameterProperty); }
		set { SetValue(CheckedCommandParameterProperty, value); }
	}

	#endregion CommandParameter

	#region CheckedCommandTarget

	public static readonly DependencyProperty CheckedCommandTargetProperty =
		DependencyProperty.Register("CheckedCommandTarget", typeof(IInputElement), typeof(ToggleSwitchBase));

	public IInputElement CheckedCommandTarget
	{
		get { return (IInputElement)GetValue(CheckedCommandTargetProperty); }
		set { SetValue(CheckedCommandTargetProperty, value); }
	}

	#endregion CheckedCommandTarget

	#endregion CheckedCommand trio

	#region UncheckedCommand trio

	#region UncheckedCommand

	public static readonly DependencyProperty UncheckedCommandProperty =
		DependencyProperty.Register("UncheckedCommand", typeof(ICommand), typeof(ToggleSwitchBase));

	public ICommand UncheckedCommand
	{
		get { return (ICommand)GetValue(UncheckedCommandProperty); }
		set { SetValue(UncheckedCommandProperty, value); }
	}

	#endregion UncheckedCommand

	#region UncheckedCommandParameter

	public static readonly DependencyProperty UncheckedCommandParameterProperty =
		DependencyProperty.Register("UncheckedCommandParameter", typeof(object), typeof(ToggleSwitchBase));

	public object UncheckedCommandParameter
	{
		get { return GetValue(UncheckedCommandParameterProperty); }
		set { SetValue(UncheckedCommandParameterProperty, value); }
	}

	#endregion CommandParameter

	#region UncheckedCommandTarget

	public static readonly DependencyProperty UncheckedCommandTargetProperty =
		DependencyProperty.Register("UncheckedCommandTarget", typeof(IInputElement), typeof(ToggleSwitchBase));

	public IInputElement UncheckedCommandTarget
	{
		get { return (IInputElement)GetValue(UncheckedCommandTargetProperty); }
		set { SetValue(UncheckedCommandTargetProperty, value); }
	}

	#endregion UncheckedCommandTarget

	#endregion UncheckedCommand trio

	#region Command trio (private except for ICommandSource implemenation)

	#region Command

	private static readonly DependencyProperty CommandProperty =
		DependencyProperty.Register("Command", typeof(ICommand), typeof(ToggleSwitchBase),
			new FrameworkPropertyMetadata(CommandPropertyChanged));

	public ICommand Command
	{
		get { return (ICommand)GetValue(CommandProperty); }
		private set { SetValue(CommandProperty, value); }
	}

	private static void CommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var instance = (ToggleSwitchBase)d;
		instance.CommandPropertyChanged((ICommand)e.OldValue, (ICommand)e.NewValue);
	}

	private void CommandPropertyChanged(ICommand oldValue, ICommand newValue)
	{
		if (oldValue is not null)
		{
			Debug.WriteLine("ToggleSwitchBase.CommandPropertyChanged: unsubscribing from CanExecuteChanged of oldValue {0:X8}", oldValue.GetHashCode());
			oldValue.CanExecuteChanged -= CanExecuteChanged;
			CanExecuteChangedHandler = null;
		}

		if (newValue is not null)
		{
			Debug.WriteLine("ToggleSwitchBase.CommandPropertyChanged: subscribing to CanExecuteChanged of newValue {0:X8}", newValue.GetHashCode());
			newValue.CanExecuteChanged += CanExecuteChangedHandler = CanExecuteChanged;
		}

		UpdateCanExecute("CommandPropertyChanged");
	}

	#endregion Command

	#region CommandParameter

	private static readonly DependencyProperty CommandParameterProperty =
		DependencyProperty.Register(nameof(CommandParameter), typeof(object), typeof(ToggleSwitchBase),
			new FrameworkPropertyMetadata(CommandParameterPropertyChanged));

	public object CommandParameter
	{
		get { return GetValue(CommandParameterProperty); }
		private set { SetValue(CommandParameterProperty, value); }
	}

	private static void CommandParameterPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var instance = (ToggleSwitchBase)d;
		instance.UpdateCanExecute("CommandParameterPropertyChanged");
	}

	#endregion CommandParameter

	#region CommandTarget

	private static readonly DependencyProperty CommandTargetProperty =
		DependencyProperty.Register("CommandTarget", typeof(IInputElement), typeof(ToggleSwitchBase),
			new FrameworkPropertyMetadata(CommandTargetPropertyChanged));

	public IInputElement CommandTarget
	{
		get { return (IInputElement)GetValue(CommandTargetProperty); }
		private set { SetValue(CommandTargetProperty, value); }
	}

	private static void CommandTargetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var instance = (ToggleSwitchBase)d;
		instance.UpdateCanExecute("CommandTargetPropertyChanged");
	}

	#endregion CommandTarget

	#endregion Command trio (private except for ICommandSource implemenation)

	#endregion Dependency Properties

	#region Events

	///<summary>
	/// Event raised when the toggle switch is unchecked.
	///</summary>
	public event RoutedEventHandler? Unchecked;

	protected void InvokeUnchecked() => this.Unchecked?.Invoke(this, new RoutedEventArgs());

	///<summary>
	/// Event raised when the toggle switch is checked.
	///</summary>
	public event RoutedEventHandler? Checked;

	protected void InvokeChecked() => this.Checked?.Invoke(this, new RoutedEventArgs());

	#endregion Events

	#region Overridables
	/// <summary>
	/// Raised while dragging the <see cref="Thumb">Thumb</see>.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected abstract void OnDragDelta(object? sender, DragDeltaEventArgs e);

	/// <summary>
	/// Raised when the dragging of the <see cref="Thumb"/> has completed.
	/// </summary>
	/// <param name="sender">The sender.</param>
	/// <param name="e">The <see cref="DragCompletedEventArgs"/> instance containing the event data.</param>
	/// <returns><see cref="ToggleGestureMode.Slide"/> to indicate that the <see cref="Thumb"/> was dragged enough to be considered a
	/// <see cref="ToggleGestureMode.Slide">slide</see> gesture. Otherwise, <see langword="false"/>, in which case the
	/// base class will perform normal click processing, as indicated by the <see cref="GestureMode"/> property.
	/// </returns>
	protected abstract ToggleGestureMode OnDragCompleted(object? sender, DragCompletedEventArgs e);

	/// <summary>
	/// Recalculated the layout of the control.
	/// </summary>
	protected abstract void LayoutControls();

	/// <summary>
	/// Initializes the control's template parts.
	/// </summary>
	protected virtual void GetTemplateChildren()
	{
		SwitchRoot = GetTemplateChild(PART_SwitchRoot) as FrameworkElement;
		SwitchThumb = GetTemplateChild(PART_SwitchThumb) as Thumb;
		SwitchChecked = GetTemplateChild(PART_SwitchChecked) as Control;
		SwitchUnchecked = GetTemplateChild(PART_SwitchUnchecked) as Control;
		SwitchTrack = GetTemplateChild(PART_SwitchTrack) as FrameworkElement;
	}

	/// <summary>
	/// Subscribe event listeners.
	/// </summary>
	protected virtual void AddEventHandlers()
	{
		if (SwitchThumb is not null)
		{
			SwitchThumb.DragStarted += SwitchThumb_DragStarted;
			SwitchThumb.DragDelta += SwitchThumb_DragDelta;
			SwitchThumb.DragCompleted += SwitchThumb_DragCompleted;
		}

		SizeChanged += OnSizeChanged;
	}

	/// <summary>
	/// Unsubscribe event listeners.
	/// </summary>
	protected virtual void RemoveEventHandlers()
	{
		if (SwitchThumb is not null)
		{
			SwitchThumb.DragStarted -= SwitchThumb_DragStarted;
			SwitchThumb.DragDelta -= SwitchThumb_DragDelta;
			SwitchThumb.DragCompleted -= SwitchThumb_DragCompleted;
		}

		SizeChanged -= OnSizeChanged;
	}

	/// <summary>
	/// Raised when a drag has started on the <see cref="Thumb">Thumb</see>.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected virtual void OnDragStarted(object? sender, DragStartedEventArgs e)
	{
		IsDragging = true;
		DragOffset = Offset;
		ChangeCheckStates(false);
	}

	/// <summary>
	/// Raised when the size of the control has changed.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected virtual void OnSizeChanged(object? sender, SizeChangedEventArgs e)
	{
		LayoutControls();
	}

	protected virtual void ChangeVisualState(bool useTransitions)
	{
		if (!IsEnabled)
			GoToState(useTransitions, CommonStates.Disabled);
		else
			GoToState(useTransitions, IsMouseOver ? CommonStates.MouseOver : CommonStates.Normal);

		if (IsFocused && IsEnabled)
			GoToState(useTransitions, FocusStates.Focused);
		else
			GoToState(useTransitions, FocusStates.Unfocused);
	}

	/// <summary>
	/// Updates the control's layout to reflect the current <see cref="IsChecked">IsChecked</see> state.
	/// </summary>
	/// <param name="useTransitions">Whether to use transitions during the layout change.</param>
	protected virtual void ChangeCheckStates(bool useTransitions)
	{
		var state = IsChecked ? CheckStates.Checked : CheckStates.Unchecked;

		if (IsDragging)
		{
			VisualStateManager.GoToState(this, CheckStates.Dragging + state, useTransitions);
		}
		else
		{
			VisualStateManager.GoToState(this, state, useTransitions);

			if (SwitchThumb is not null)
				VisualStateManager.GoToState(SwitchThumb, state, useTransitions);
		}

		if (SwitchThumb is null || SwitchTrack is null)
			return;

		var storyboard = new Storyboard();
		var duration = new Duration(useTransitions ? TimeSpan.FromMilliseconds(100) : TimeSpan.Zero);
		var backgroundAnimation = new DoubleAnimation();
		var thumbAnimation = new DoubleAnimation();

		backgroundAnimation.Duration = duration;
		thumbAnimation.Duration = duration;

		var offset = IsChecked ? CheckedOffset : UncheckedOffset;
		backgroundAnimation.To = offset;
		thumbAnimation.To = offset;

		storyboard.Children.Add(backgroundAnimation);
		storyboard.Children.Add(thumbAnimation);

		Storyboard.SetTarget(backgroundAnimation, SwitchTrack);
		Storyboard.SetTarget(thumbAnimation, SwitchThumb);

		Storyboard.SetTargetProperty(backgroundAnimation, SlidePropertyPath);
		Storyboard.SetTargetProperty(thumbAnimation, SlidePropertyPath);

		storyboard.Begin();
	}
	#endregion Overridables

	#region Overrides
	/// <summary>
	/// Invoked whenever application code or internal processes call
	/// <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
	/// </summary>
	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();

		RemoveEventHandlers();
		GetTemplateChildren();
		AddEventHandlers();

		LayoutControls();

		VisualStateManager.GoToState(this, IsEnabled ? CommonStates.Normal : CommonStates.Disabled, false);
		ChangeCheckStates(false);
	}

	/// <summary>
	/// Responds to the LostFocus event.
	/// </summary>
	/// <param name="e">The event data for the LostFocus event.</param>
	protected override void OnLostFocus(RoutedEventArgs e)
	{
		base.OnLostFocus(e);

		ReleaseMouseCapture();

		_suspendStateChanges = false;
		UpdateVisualState();
	}

	/// <summary>
	/// Responds to the KeyDown event.
	/// </summary>
	/// <param name="e">The event data for the KeyDown event.</param>
	protected override void OnKeyDown(KeyEventArgs e)
	{
		base.OnKeyDown(e);
		if (e.Handled)
			return;

		if (OnKeyDownInternal(e.Key))
			e.Handled = true;
	}

	/// <summary>
	/// Responds to the KeyUp event.
	/// </summary>
	/// <param name="e">The event data for the KeyUp event.</param>
	protected override void OnKeyUp(KeyEventArgs e)
	{
		base.OnKeyUp(e);
		if (e.Handled)
			return;

		if (OnKeyUpInternal(e.Key))
			e.Handled = true;
	}

	protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		if (!GestureMode.HasFlag(ToggleGestureMode.Slide))
		{
			if (e.OriginalSource is DependencyObject originalSource)
			{
				if (originalSource.GetVisualAncestors().FirstOrDefault(a => a == SwitchThumb) is not null)
				{
					// Copy event args for the PreviewMouseDown and MouseDown routed events
					var args = new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, e.ChangedButton)
					{
						RoutedEvent = PreviewMouseDownEvent,
						Source = e.OriginalSource
					};
					args.Source = e.Source;

					e.Handled = true;
					OnMouseLeftButtonDown(args);
					return;
				}
			}
		}

		base.OnPreviewMouseLeftButtonDown(e);
	}

	/// <summary>
	/// Responds to the MouseLeftButtonDown event.
	/// </summary>
	/// <param name="e">
	/// The event data for the MouseLeftButtonDown event.
	/// </param>
	protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
	{
		base.OnMouseLeftButtonDown(e);
		if (e.Handled)
			return;

		Focus();

		if (!GestureMode.HasFlag(ToggleGestureMode.Click))
			return;

		if (!IsEnabled)
			return;

		_suspendStateChanges = true;

		if (CaptureMouseInternal())
		{
			Debug.WriteLine("ToggleSwitchBase.OnMouseLeftButtonDown: Mouse was captured");
			e.Handled = true;
			IsPressed = true;
			_isMouseLeftButtonDown = true;

			_clickBounds = new Rect(e.GetPosition(this), new Size(0, 0));
			_clickBounds.Inflate(SystemParameters.MouseHoverWidth / 2, SystemParameters.MouseHoverHeight / 2);
		}

		_suspendStateChanges = false;
		UpdateVisualState();
	}

	/// <summary>
	/// Responds to the MouseLeftButtonUp event.
	/// </summary>
	/// <param name="e">
	/// The event data for the MouseLeftButtonUp event.
	/// </param>
	protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
	{
		base.OnMouseLeftButtonUp(e);
		if (e.Handled)
			return;

		_isMouseLeftButtonDown = false;

		if (!GestureMode.HasFlag(ToggleGestureMode.Click))
			return;

		if (!IsEnabled)
			return;

		e.Handled = true;
		if (!_isSpaceKeyDown && IsPressed)
			OnClick();

		if (!_isSpaceKeyDown)
			ReleaseMouseCapture();
	}

	/// <summary>
	/// Responds to the MouseMove event.
	/// </summary>
	/// <param name="e">The event data for the MouseMove event.</param>
	protected override void OnMouseMove(MouseEventArgs e)
	{
		base.OnMouseMove(e);

		if (IsMouseCaptured && IsEnabled && _isMouseLeftButtonDown && !_isSpaceKeyDown)
		{
			var mousePosition = e.GetPosition(this);
			IsPressed = IsValidMousePosition(mousePosition);
			if (!IsPressed)
				ReleaseMouseCapture();

			Debug.WriteLine("ToggleSwitchBase.OnMouseMove: IsValidMousePosition({0}, {1}) = {2} _clickBounds={3}",
				mousePosition.X, mousePosition.Y, IsPressed, _clickBounds);
		}
	}

	protected override void OnGotMouseCapture(MouseEventArgs e)
	{
		base.OnGotMouseCapture(e);
	}

	protected override void OnLostMouseCapture(MouseEventArgs e)
	{
		base.OnLostMouseCapture(e);

		IsPressed = false;
		_isSpaceKeyDown = false;
		_isMouseLeftButtonDown = false;
		_clickBounds = new Rect();
	}

	protected override bool IsEnabledCore => CanExecute;

	#endregion Overrides

	#region Protected Methods
	protected void UpdateVisualState(bool useTransitions = true)
	{
		if (!_suspendStateChanges)
			ChangeVisualState(useTransitions);
	}

	protected bool GoToState(bool useTransitions, string stateName)
	{
		return VisualStateManager.GoToState(this, stateName, useTransitions);
	}

	/// <summary>
	/// Called when the control is clicked.
	/// </summary>
	protected void OnClick()
	{
		IsChecked = !IsChecked;
	}

	#endregion Protected Methods

	#region Internal and Private Implementation
	/// <summary>
	/// Capture the mouse.
	/// </summary>
	/// <returns></returns>
	internal bool CaptureMouseInternal()
	{
		var wasCaptured = IsMouseCaptured;
		var isCaptured = !wasCaptured && !IsMouseCaptureWithin && CaptureMouse();
		if (isCaptured)
			IsPressed = true;
		return isCaptured;
	}

	/// <summary>
	/// Handles the KeyDown event for ButtonBase.
	/// </summary>
	/// <param name="key">
	/// The keyboard key associated with the event.
	/// </param>
	/// <returns>True if the event was handled, false otherwise.</returns>
	/// <remarks>
	/// This method exists for the purpose of unit testing since we can't
	/// set KeyEventArgs.Key to simulate key press events.
	/// </remarks>
	private bool OnKeyDownInternal(Key key)
	{
		var handled = false;

		if (IsEnabled)
		{
			if (key == Key.Space && GestureMode.HasFlag(ToggleGestureMode.Space))
			{
				if (!IsMouseCaptureWithin && !_isSpaceKeyDown)
				{
					if (CaptureMouseInternal())
					{
						_isSpaceKeyDown = true;
						handled = true;
					}
				}
			}
			else if (key == Key.Enter && GestureMode.HasFlag(ToggleGestureMode.Enter))
			{
				_isSpaceKeyDown = false;
				ReleaseMouseCapture();

				OnClick();

				handled = true;
			}
			else if (_isSpaceKeyDown)
			{
				_isSpaceKeyDown = false;
				ReleaseMouseCapture();
			}
		}

		return handled;
	}

	/// <summary>
	/// Handles the KeyUp event for ButtonBase.
	/// </summary>
	/// <param name="key">The keyboard key associated with the event.</param>
	/// <returns>True if the event was handled, false otherwise.</returns>
	/// <remarks>
	/// This method exists for the purpose of unit testing since we can't
	/// set KeyEventArgs.Key to simulate key press events.
	/// </remarks>
	private bool OnKeyUpInternal(Key key)
	{
		var handled = false;

		if (IsEnabled && key == Key.Space && GestureMode.HasFlag(ToggleGestureMode.Space))
		{
			_isSpaceKeyDown = false;

			if (!_isMouseLeftButtonDown)
			{
				if (IsPressed)
				{
					ReleaseMouseCapture();
					OnClick();
				}
			}
			else if (IsMouseCaptured)
			{
				if (!IsValidMousePosition(Mouse.GetPosition(this)))
					ReleaseMouseCapture();
			}

			handled = true;
		}

		return handled;
	}

	/// <summary>
	/// Determines if the mouse is above the button based on its last known position.
	/// </summary>
	/// <returns>
	/// True if the mouse is considered above the button, false otherwise.
	/// </returns>
	private bool IsValidMousePosition(Point mousePosition)
	{
		return (mousePosition.X >= 0.0)
			&& (mousePosition.X <= ActualWidth)
			&& (mousePosition.Y >= 0.0)
			&& (mousePosition.Y <= ActualHeight)
			&& _clickBounds.Contains(mousePosition);
	}

	/// <summary>
	/// Raised when a dependency property that affects the control's layout has changed.
	/// </summary>
	/// <param name="d">The ToggleSwitch control</param>
	/// <param name="e"></param>
	private static void OnLayoutDependencyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var instance = (ToggleSwitchBase)d;
		instance.LayoutControls();
	}

	/// <summary>
	/// Called when the IsEnabled property changes.
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	private void OnIsEnabledChanged(object? sender, DependencyPropertyChangedEventArgs e)
	{
		_suspendStateChanges = true;
		if (!IsEnabled)
			ReleaseMouseCapture();
		_suspendStateChanges = false;

		UpdateVisualState();
	}

	private void UpdateCommandPropertiesSource()
	{
		DependencyProperty sourceCommandProperty;
		DependencyProperty sourceCommandParameterProperty;
		DependencyProperty sourceCommandTargetProperty;
		if (IsChecked)
		{
			sourceCommandProperty = UncheckedCommandProperty;
			sourceCommandParameterProperty = UncheckedCommandParameterProperty;
			sourceCommandTargetProperty = UncheckedCommandTargetProperty;
		}
		else
		{
			sourceCommandProperty = CheckedCommandProperty;
			sourceCommandParameterProperty = CheckedCommandParameterProperty;
			sourceCommandTargetProperty = CheckedCommandTargetProperty;
		}

		SetBinding(CommandTargetProperty, new Binding(sourceCommandTargetProperty.Name) { Mode = BindingMode.OneWay, Source = this });
		SetBinding(CommandParameterProperty, new Binding(sourceCommandParameterProperty.Name) { Mode = BindingMode.OneWay, Source = this });
		SetBinding(CommandProperty, new Binding(sourceCommandProperty.Name) { Mode = BindingMode.OneWay, Source = this });
	}

	private void CanExecuteChanged(object? sender, EventArgs e)
	{
		UpdateCanExecute("CanExecuteChanged");
	}

	private void UpdateCanExecute(string fromMethod)
	{
		CanExecute = this.CanExecuteCommandSource();
		Debug.WriteLine("ToggleSwitchBase.{0}: canExecute={1}", fromMethod, CanExecute);
	}

	private bool CanExecute
	{
		get => _canExecute;
		set
		{
			if (_canExecute != value)
			{
				_canExecute = value;
				CoerceValue(UIElement.IsEnabledProperty);
			}
		}
	}
	private bool _canExecute = true;

	/// <summary>
	/// Maintains a strong reference since some ICommand implementations maintain a weak reference.
	/// </summary>
	private EventHandler? CanExecuteChangedHandler { get; set; }

	#endregion Internal and Private Implementation

	#region Event Handlers

	private void SwitchThumb_DragStarted(object? sender, DragStartedEventArgs e)
	{
		this.OnDragStarted(sender, e);
	}

	private void SwitchThumb_DragDelta(object? sender, DragDeltaEventArgs e)
	{
		this.OnDragDelta(sender, e);
	}

	private void SwitchThumb_DragCompleted(object? sender, DragCompletedEventArgs e)
	{
		var inputGesture = this.OnDragCompleted(sender, e);
		var isNone = (inputGesture & GestureMode) == ToggleGestureMode.None;
		if (!isNone)
		{
			var doClick = GestureMode.HasFlag(inputGesture & ToggleGestureMode.Click);
			doClick = doClick || GestureMode.HasFlag(inputGesture & ToggleGestureMode.Slide);
			if (doClick)
				OnClick();
		}
	}

	#endregion Event Handlers
}
