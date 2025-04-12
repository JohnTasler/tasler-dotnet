using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Controls;

/// <summary>
/// </summary>
[TemplateVisualState(GroupName = AnimationStates, Name = Emerging)]
[TemplateVisualState(GroupName = AnimationStates, Name = Transitioned)]
[TemplateVisualState(GroupName = AnimationStates, Name = Transitioning)]
[TemplateVisualState(GroupName = AnimationStates, Name = ReverseTransitioning)]
[TemplatePart(Name = PART_ContentHost, Type = typeof(AnimationSizeableElement))]
[TemplatePart(Name = PART_OldContentHost, Type = typeof(AnimationSizeableElement))]
public class TransitionContentControl : ContentControl
{
	#region Constants
	public const string AnimationStates      = "AnimationStates";
	public const string Emerging             = "Emerging";
	public const string Transitioned         = "Transitioned";
	public const string Transitioning        = "Transitioning";
	public const string ReverseTransitioning = "ReverseTransitioning";
	public const string PART_ContentHost     = "PART_ContentHost";
	public const string PART_OldContentHost  = "PART_OldContentHost";
	#endregion Constants

	#region Constructors
	/// <summary>
	/// Initializes a new instance of the <see cref="TransitionContentControl"/> class.
	/// </summary>
	public TransitionContentControl()
	{
		this.SetDefaultStyleKey();
	}
	#endregion Constructors

	#region Dependency Properties

	#region BoundingRectangle
	/// <summary>
	/// Identifies the <see cref="BoundingRectangle"/> dependency property.
	/// </summary>
	private static readonly DependencyPropertyKey BoundingRectanglePropertyKey =
		DependencyPropertyFactory<TransitionContentControl>.RegisterReadOnly<Rect>(nameof(BoundingRectangle));

	/// <summary>
	/// Identifies the <see cref="BoundingRectangle"/> dependency property.
	/// </summary>
	public static readonly DependencyProperty BoundingRectangleProperty = BoundingRectanglePropertyKey.DependencyProperty;

	/// <summary>
	/// Gets a value that indicates whether the <see cref="OldContent"/> property is <c>null</c>.
	/// </summary>
	/// <value>
	/// <c>true</c> if the <see cref="OldContent"/> property is not <c>null</c>; otherwise, <c>false</c>.
	/// The default is <c>false</c>.
	/// </value>
	[Browsable(false)]
	public Rect BoundingRectangle
	{
		get => (Rect)this.GetValue(BoundingRectangleProperty);
		private set => this.SetValue(BoundingRectanglePropertyKey, value);
	}
	#endregion BoundingRectangle

	#region HasOldContent
	/// <summary>
	/// Identifies the <see cref="HasOldContent"/> dependency property.
	/// </summary>
	private static readonly DependencyPropertyKey HasOldContentPropertyKey =
			DependencyPropertyFactory<TransitionContentControl>.RegisterReadOnly<bool>(
				nameof(HasOldContent), false);

	/// <summary>
	/// Identifies the <see cref="HasOldContent"/> dependency property.
	/// </summary>
	public static readonly DependencyProperty HasOldContentProperty = HasOldContentPropertyKey.DependencyProperty;

	/// <summary>
	/// Gets a value that indicates whether the <see cref="OldContent"/> property is <c>null</c>.
	/// </summary>
	/// <value>
	/// <c>true</c> if the <see cref="OldContent"/> property is not <c>null</c>; otherwise, <c>false</c>.
	/// The default is <c>false</c>.
	/// </value>
	[Browsable(false)]
	public bool HasOldContent
	{
		get => (bool)this.GetValue(HasOldContentProperty);
		private set => this.SetValue(HasOldContentPropertyKey, value);
	}
	#endregion HasOldContent

	#region OldContent
	/// <summary>
	/// Identifies the <see cref="OldContent"/> dependency property.
	/// </summary>
	private static readonly DependencyPropertyKey OldContentPropertyKey =
		DependencyPropertyFactory<TransitionContentControl>.RegisterReadOnly<object>(
			nameof(OldContent), OnOldContentChanged);

	/// <summary>
	/// Identifies the <see cref="OldContent"/> dependency property.
	/// </summary>
	public static readonly DependencyProperty OldContentProperty = OldContentPropertyKey.DependencyProperty;

	/// <summary>
	/// Called when the OldContent property of a <see cref="TransitionContentControl"/> changes.
	/// </summary>
	/// <param name="oldValue">The old value of the <see cref="OldContent"/> property.</param>
	/// <param name="newValue">The new value of the <see cref="OldContent"/> property.</param>
	protected virtual void OnOldContentChanged(object? oldValue, object? newValue)
	{
#if WINDOWS_WPF
		this.RemoveLogicalChild(oldValue);
		this.AddLogicalChild(newValue);
#endif
	}

	private static void OnOldContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (TransitionContentControl)d;
		@this.HasOldContent = e.NewValue is not null;

		@this.OnOldContentChanged(e.OldValue, e.NewValue);

		if (e.NewValue is null)
			VisualStateManager.GoToState(@this, Transitioned, false);
	}

	/// <summary>
	/// Gets or sets the data used for the footer area of the <see cref="TransitionContentControl"/>.
	/// </summary>
	/// <value>
	/// A footer object. The default is <c>null</c>.
	/// </value>
	public object? OldContent
	{
		get => this.GetValue(OldContentProperty);
		private set => this.SetValue(OldContentPropertyKey, value);
	}
	#endregion OldContent

	#region IsReversed
	/// <summary>
	/// Identifies the <see cref="IsReversed"/> dependency property.
	/// </summary>
	public static readonly DependencyProperty IsReversedProperty =
		DependencyPropertyFactory<TransitionContentControl>.Register<bool>(nameof(IsReversed), false);

	/// <summary>
	/// Gets a value that indicates whether the transition should be reversed.
	/// </summary>
	/// <value>
	/// <c>true</c> if the transition should be reversed; otherwise, <c>false</c>.
	/// The default is <c>false</c>.
	/// </value>
	public bool IsReversed
	{
		get => (bool)this.GetValue(IsReversedProperty);
		set => this.SetValue(IsReversedProperty, value);
	}
	#endregion IsReversed

	#endregion Dependency Properties

	#region Overrides
	protected override void OnContentChanged(object oldContent, object newContent)
	{
		base.OnContentChanged(oldContent, newContent);
		if (oldContent is not null)
			this.OldContent = oldContent;

		var state = this.OldContent is null ? Emerging : this.IsReversed ? ReverseTransitioning : Transitioning;
		VisualStateManager.GoToState(this, state, false);
	}

	public override void OnApplyTemplate()
	{
		// Perform default processing
		base.OnApplyTemplate();

		// Get the template child
		var templateChild = this.GetVisualChildren().OfType<FrameworkElement>().FirstOrDefault();
		if (templateChild is not null)
		{
			// Get the visual state groups of the template child
			var stateGroups = VisualStateManager.GetVisualStateGroups(templateChild).OfType<VisualStateGroup>();

			// Get the AnimationStates group
			var stateGroup = stateGroups.FirstOrDefault(vsm => vsm.Name == AnimationStates);
			if (stateGroup != null)
			{
				// Subscribe to the Storyboard.Completed event of the states of interest
				foreach (var state in stateGroup.States.OfType<VisualState>())
					if (state.Storyboard != null && state.Name != Transitioned)
						state.Storyboard.Completed += this.Storyboard_Completed;

				// Subscribe to the Storyboard.Completed event of the transtitions of interest
				foreach (var transition in stateGroup.Transitions.OfType<VisualTransition>())
					if (transition.Storyboard != null && transition.To != Transitioned)
						transition.Storyboard.Completed += (sender, e) =>
							this.OldContent = null;
			}
		}
	}

	protected override Size ArrangeOverride(Size finalSize)
	{
		var size = base.ArrangeOverride(finalSize);
		this.BoundingRectangle = new Rect(0, 0, size.Width, size.Height);
		return size;
	}
	#endregion Overrides

	private void Storyboard_Completed(object? sender, EventArgs e)
	{
		var currentState = ClockState.Stopped;

		if (sender is Storyboard timeline)
		{
			currentState = timeline.GetCurrentState();
		}
#if WINDOWS_WPF
		else
		{
			if (sender is Clock clock)
				currentState = clock.CurrentState;
		}
#endif

		if (currentState == ClockState.Filling)
		{
			this.OldContent = null;
			//this.OldContentTemplate = null;
			//this.OldContentTemplateSelector = null;
			//this.OldContentStringFormat = null;
		}
	}
}
