#if WINDOWS_UWP
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Tasler.UI.Xaml.Extensions;
namespace Tasler.UI.Xaml.Controls;

#elif WINDOWS_WPF
using System.Windows;
using System.Windows.Controls;
using Tasler.Windows.Extensions;
using System.Windows.Media.Animation;
namespace Tasler.Windows.Controls;

#endif

using DPFactory = DependencyPropertyFactory<SignalLevelMeter>;

public partial class SignalLevelMeter : Control
{
	#region Constants
	public const string ValueChangeGroup = "ValueChange";
	public const string DecreasedState = "Decreased";
	public const string IncreasedState = "Increased";
	#endregion Constants

	private Storyboard? _storyboard;

	#region Constructors

	/// <summary>
	/// Initializes a new instance of the <see cref="SignalLevelMeter"/> class.
	/// </summary>
	public SignalLevelMeter()
	{
		this.SetDefaultStyleKey();
	}

	#endregion Constructors

	#region Value

	public static readonly DependencyProperty ValueProperty =
		DPFactory.Register<double>(nameof(Value), 0.0d, OnValuePropertyChanged);

	public double Value
	{
		get => (double)this.GetValue(ValueProperty);
		set => this.SetValue(ValueProperty, value);
	}

	private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (SignalLevelMeter)d;
		var oldValue = (double)e.OldValue;
		var newValue = (double)e.NewValue;
		@this.OnValuePropertyChanged(oldValue, newValue);
	}

	private void OnValuePropertyChanged(double oldValue, double newValue)
	{
		var displayValue = this.DisplayValue;

		if (newValue > displayValue)
		{
			// Create or stop the storyboard and animation
			var animation = default(DoubleAnimationUsingKeyFrames);
			var initialKeyFrame       = default(DiscreteDoubleKeyFrame);
			var responseKeyFrame      = default(EasingDoubleKeyFrame);
			var fallbackDelayKeyFrame = default(DiscreteDoubleKeyFrame);
			var fallbackKeyFrame      = default(EasingDoubleKeyFrame);

			if (_storyboard is null)
			{
				_storyboard = new Storyboard
				{
					FillBehavior = FillBehavior.Stop,
					Children =
					{
						(animation = new DoubleAnimationUsingKeyFrames
						{
							FillBehavior = FillBehavior.Stop,
							KeyFrames =
							{
								(initialKeyFrame       = new DiscreteDoubleKeyFrame { KeyTime = TimeSpan.Zero }),
								(responseKeyFrame      = new EasingDoubleKeyFrame  ()),
								(fallbackDelayKeyFrame = new DiscreteDoubleKeyFrame()),
								(fallbackKeyFrame      = new EasingDoubleKeyFrame  ()),
							}
						})
					}

				};
				Storyboard.SetTarget(animation, this);

#if WINDOWS_UWP
				Storyboard.SetTargetProperty(animation, nameof(DisplayValue));
#elif WINDOWS_WPF
				Storyboard.SetTargetProperty(animation, new PropertyPath(nameof(DisplayValue)));
#endif
			}
			else
			{
				_storyboard.Stop();
				animation = (DoubleAnimationUsingKeyFrames)_storyboard.Children[0];
				initialKeyFrame       = (DiscreteDoubleKeyFrame)animation.KeyFrames[0];
				responseKeyFrame      = (EasingDoubleKeyFrame  )animation.KeyFrames[1];
				fallbackDelayKeyFrame = (DiscreteDoubleKeyFrame)animation.KeyFrames[2];
				fallbackKeyFrame      = (EasingDoubleKeyFrame  )animation.KeyFrames[3];
			}

			initialKeyFrame.Value           = displayValue;

			responseKeyFrame.KeyTime        = this.ResponseTime;
			responseKeyFrame.Value          = newValue;
			responseKeyFrame.EasingFunction = this.ResponseEasingFunction;

			fallbackDelayKeyFrame.KeyTime   = responseKeyFrame.KeyTime.TimeSpan + this.FallbackDelay;
			fallbackDelayKeyFrame.Value     = newValue;

			fallbackKeyFrame.KeyTime        = fallbackDelayKeyFrame.KeyTime.TimeSpan + this.FallbackTime;
			fallbackKeyFrame.Value          = this.Minimum;
			fallbackKeyFrame.EasingFunction = this.FallbackEasingFunction;

			_storyboard.Begin();
		}
	}

#endregion Value

	#region DisplayValue

	public static readonly DependencyProperty DisplayValueProperty =
		DPFactory.Register<double>(nameof(DisplayValue), 0.0d);

	public double DisplayValue
	{
		get => (double)this.GetValue(DisplayValueProperty);
		/*private*/ set => this.SetValue(DisplayValueProperty, value);
	}

	#endregion DisplayValue

	#region ResponseTime

	public static readonly DependencyProperty ResponseTimeProperty =
		DPFactory.Register<TimeSpan>(nameof(ResponseTime), TimeSpan.Zero);

	public TimeSpan ResponseTime
	{
		get => (TimeSpan)this.GetValue(ResponseTimeProperty);
		set => this.SetValue(ResponseTimeProperty, value);
	}

	#endregion ResponseTime

	#region FallbackDelay

	public static readonly DependencyProperty FallbackDelayProperty =
		DPFactory.Register<TimeSpan>(nameof(FallbackDelay), TimeSpan.Zero);

	public TimeSpan FallbackDelay
	{
		get => (TimeSpan)this.GetValue(FallbackDelayProperty);
		set => this.SetValue(FallbackDelayProperty, value);
	}

	#endregion FallbackDelay

	#region FallbackTime

	public static readonly DependencyProperty FallbackTimeProperty =
		DPFactory.Register<TimeSpan>(nameof(FallbackTime), TimeSpan.Zero);

	public TimeSpan FallbackTime
	{
		get => (TimeSpan)this.GetValue(FallbackTimeProperty);
		set => this.SetValue(FallbackTimeProperty, value);
	}

	#endregion FallbackTime

	#region ResponseEasingFunction

	public static readonly DependencyProperty ResponseEasingFunctionProperty =
		DPFactory.Register<EasingFunctionBase>(nameof(ResponseEasingFunction));

	public EasingFunctionBase ResponseEasingFunction
	{
		get => (EasingFunctionBase)this.GetValue(ResponseEasingFunctionProperty);
		set => this.SetValue(ResponseEasingFunctionProperty, value);
	}

	#endregion ResponseEasingFunction

	#region FallbackEasingFunction

	public static readonly DependencyProperty FallbackEasingFunctionProperty =
		DPFactory.Register<EasingFunctionBase>(nameof(FallbackEasingFunction));

	public EasingFunctionBase FallbackEasingFunction
	{
		get => (EasingFunctionBase)this.GetValue(FallbackEasingFunctionProperty);
		set => this.SetValue(FallbackEasingFunctionProperty, value);
	}

	#endregion FallbackEasingFunction

	#region Minimum

	public static readonly DependencyProperty MinimumProperty =
		DPFactory.Register<double>(nameof(Minimum), OnMinimumChanged);

	public double Minimum
	{
		get => (double)this.GetValue(MinimumProperty);
		set => this.SetValue(MinimumProperty, value);
	}

	private static void OnMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (SignalLevelMeter)d;
		var oldValue = (double)e.OldValue;
		var newValue = (double)e.NewValue;

		@this.OnMinimumChanged(oldValue, newValue);
	}

	protected virtual void OnMinimumChanged(double oldValue, double newValue)
	{
	}

	#endregion Minimum

	#region Maximum

	public static readonly DependencyProperty MaximumProperty =
		DPFactory.Register<double>(nameof(Maximum), OnMaximumChanged);

	public double Maximum
	{
		get => (double)this.GetValue(MaximumProperty);
		set => this.SetValue(MaximumProperty, value);
	}

	private static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
	{
		var @this = (SignalLevelMeter)d;
		var oldValue = (double)e.OldValue;
		var newValue = (double)e.NewValue;

		@this.OnMaximumChanged(oldValue, newValue);
	}

	protected virtual void OnMaximumChanged(double oldValue, double newValue)
	{
	}

	#endregion Maximum

	#region Orientation

	public static readonly DependencyProperty OrientationProperty =
		DPFactory.Register<Orientation>(nameof(Orientation), Orientation.Horizontal);

	public Orientation Orientation
	{
		get => (Orientation)this.GetValue(OrientationProperty);
		set => this.SetValue(OrientationProperty, value);
	}

	#endregion Orientation
}
