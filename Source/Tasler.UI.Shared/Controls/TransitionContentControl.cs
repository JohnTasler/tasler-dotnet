#if WINDOWS_UWP
using System.ComponentModel;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Tasler.UI.Xaml.Extensions;
namespace Tasler.UI.Xaml.Controls;
using DPFactory = DependencyPropertyFactory<TransitionContentControl>;

#elif WINDOWS_WPF
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Tasler.Windows.Extensions;
namespace Tasler.Windows.Controls;
using DPFactory = DependencyPropertyFactory<TransitionContentControl>;

#endif


/// <summary>
/// </summary>
[TemplateVisualState(GroupName = AnimationStates.GroupName, Name = AnimationStates.Emerging)]
[TemplateVisualState(GroupName = AnimationStates.GroupName, Name = AnimationStates.Transitioned)]
[TemplateVisualState(GroupName = AnimationStates.GroupName, Name = AnimationStates.Transitioning)]
[TemplateVisualState(GroupName = AnimationStates.GroupName, Name = AnimationStates.ReverseTransitioning)]
[TemplatePart(Name = PART_ContentHost, Type = typeof(AnimationSizeableElement))]
[TemplatePart(Name = PART_OldContentHost, Type = typeof(AnimationSizeableElement))]
public partial class TransitionContentControl : ContentControl
{
	#region Constants
	public static class AnimationStates
	{
		public const string GroupName            = nameof(AnimationStates);
		public const string Emerging             = nameof(Emerging);
		public const string Transitioned         = nameof(Transitioned);
		public const string Transitioning        = nameof(Transitioning);
		public const string ReverseTransitioning = nameof(ReverseTransitioning);
	}
	public const string PART_ContentHost     = nameof(PART_ContentHost);
	public const string PART_OldContentHost  = nameof(PART_OldContentHost);
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
		DPFactory.RegisterReadOnly<Rect>(nameof(BoundingRectangle));

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
		private set => this.SetValue(BoundingRectangleProperty, value);
	}
	#endregion BoundingRectangle

	#region HasOldContent
	/// <summary>
	/// Identifies the <see cref="HasOldContent"/> dependency property.
	/// </summary>
	private static readonly DependencyPropertyKey HasOldContentPropertyKey =
		DPFactory.RegisterReadOnly<bool>(nameof(HasOldContent), false);

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
		private set => this.SetValue(HasOldContentProperty, value);
	}
	#endregion HasOldContent

	#region OldContent
	/// <summary>
	/// Identifies the <see cref="OldContent"/> dependency property.
	/// </summary>
	private static readonly DependencyPropertyKey OldContentPropertyKey =
		DPFactory.RegisterReadOnly<object>(nameof(OldContent), OnOldContentChanged);

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
			VisualStateManager.GoToState(@this, AnimationStates.Transitioned, false);
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
		private set => this.SetValue(OldContentProperty, value);
	}
	#endregion OldContent

	#region IsReversed
	/// <summary>
	/// Identifies the <see cref="IsReversed"/> dependency property.
	/// </summary>
	public static readonly DependencyProperty IsReversedProperty =
		DPFactory.Register<bool>(nameof(IsReversed), false);

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

		var state = this.OldContent is null
			? AnimationStates.Emerging
			: this.IsReversed
				? AnimationStates.ReverseTransitioning
				: AnimationStates.Transitioning;
		VisualStateManager.GoToState(this, state, false);
	}

#if WINDOWS_UWP
	protected override void OnApplyTemplate()
#elif WINDOWS_WPF
	public override void OnApplyTemplate()
#endif
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
			var stateGroup = stateGroups.FirstOrDefault(vsm => vsm.Name == AnimationStates.GroupName);
			if (stateGroup != null)
			{
				// Subscribe to the Storyboard.Completed event of the states of interest
				foreach (var state in stateGroup.States.OfType<VisualState>())
					if (state.Storyboard != null && state.Name != AnimationStates.Transitioned)
						state.Storyboard.Completed += this.Storyboard_Completed;

				// Subscribe to the Storyboard.Completed event of the transtitions of interest
				foreach (var transition in stateGroup.Transitions.OfType<VisualTransition>())
					if (transition.Storyboard != null && transition.To != AnimationStates.Transitioned)
						transition.Storyboard.Completed += (sender, e) => this.OldContent = null;
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

	private void Storyboard_Completed(object? sender, object e)
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
