using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Controls
{
	public class SignalLevelMeter : Control
	{
		#region Constants
		public const string ValueChangeGroup = "ValueChange";
		public const string DecreasedState = "Decreased";
		public const string IncreasedState = "Increased";
		#endregion Constants

		private Storyboard storyboard;

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SignalLevelMeter"/> class.
		/// </summary>
		public SignalLevelMeter()
		{
			this.SetDefaultStyleKeyValue(DefaultStyleKeyProperty);
		}

		#endregion Constructors

		#region Value

		public static readonly DependencyProperty ValueProperty =
			DependencyProperty.Register("Value", typeof(double), typeof(SignalLevelMeter),
				new PropertyMetadata(0.0, OnValuePropertyChanged));

		public double Value
		{
			get { return (double)this.GetValue(ValueProperty); }
			set { this.SetValue(ValueProperty, value); }
		}

		private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var instance = (SignalLevelMeter)d;
			var oldValue = (double)e.OldValue;
			var newValue = (double)e.NewValue;
			instance.OnValuePropertyChanged(oldValue, newValue);
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

				if (this.storyboard == null)
				{
					this.storyboard = new Storyboard
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
					Storyboard.SetTargetProperty(animation, new PropertyPath(DisplayValueProperty));
				}
				else
				{
					this.storyboard.Stop();
					animation = (DoubleAnimationUsingKeyFrames)this.storyboard.Children[0];
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

				this.storyboard.Begin();
			}
		}

		#endregion Value

		#region DisplayValue

		public static readonly DependencyProperty DisplayValueProperty =
			DependencyProperty.Register("DisplayValue", typeof(double), typeof(SignalLevelMeter),
				new PropertyMetadata(0.0));

		public double DisplayValue
		{
			get { return (double)this.GetValue(DisplayValueProperty); }
			/*private*/ set { this.SetValue(DisplayValueProperty, value); }
		}

		#endregion DisplayValue

		#region ResponseTime

		public static readonly DependencyProperty ResponseTimeProperty =
			DependencyProperty.Register("ResponseTime", typeof(TimeSpan), typeof(SignalLevelMeter),
				new PropertyMetadata(TimeSpan.Zero));

		public TimeSpan ResponseTime
		{
			get { return (TimeSpan)this.GetValue(ResponseTimeProperty); }
			set { this.SetValue(ResponseTimeProperty, value); }
		}

		#endregion ResponseTime

		#region FallbackDelay

		public static readonly DependencyProperty FallbackDelayProperty =
			DependencyProperty.Register("FallbackDelay", typeof(TimeSpan), typeof(SignalLevelMeter),
				new PropertyMetadata(TimeSpan.Zero));

		public TimeSpan FallbackDelay
		{
			get { return (TimeSpan)this.GetValue(FallbackDelayProperty); }
			set { this.SetValue(FallbackDelayProperty, value); }
		}

		#endregion FallbackDelay

		#region FallbackTime

		public static readonly DependencyProperty FallbackTimeProperty =
			DependencyProperty.Register("FallbackTime", typeof(TimeSpan), typeof(SignalLevelMeter),
				new PropertyMetadata(TimeSpan.Zero));

		public TimeSpan FallbackTime
		{
			get { return (TimeSpan)this.GetValue(FallbackTimeProperty); }
			set { this.SetValue(FallbackTimeProperty, value); }
		}

		#endregion FallbackTime

		#region ResponseEasingFunction

		public static readonly DependencyProperty ResponseEasingFunctionProperty =
			DependencyProperty.Register("ResponseEasingFunction", typeof(IEasingFunction), typeof(SignalLevelMeter),
				new PropertyMetadata(null));

		public IEasingFunction ResponseEasingFunction
		{
			get { return (IEasingFunction)this.GetValue(ResponseEasingFunctionProperty); }
			set { this.SetValue(ResponseEasingFunctionProperty, value); }
		}

		#endregion ResponseEasingFunction

		#region FallbackEasingFunction

		public static readonly DependencyProperty FallbackEasingFunctionProperty =
			DependencyProperty.Register("FallbackEasingFunction", typeof(IEasingFunction), typeof(SignalLevelMeter),
				new PropertyMetadata(null));

		public IEasingFunction FallbackEasingFunction
		{
			get { return (IEasingFunction)this.GetValue(FallbackEasingFunctionProperty); }
			set { this.SetValue(FallbackEasingFunctionProperty, value); }
		}

		#endregion FallbackEasingFunction

		#region Minimum

		public static readonly DependencyProperty MinimumProperty =
			DependencyProperty.Register("Minimum", typeof(double), typeof(SignalLevelMeter),
			new PropertyMetadata(OnMinimumChanged));

		public double Minimum
		{
			get { return (double)this.GetValue(MinimumProperty); }
			set { this.SetValue(MinimumProperty, value); }
		}

		private static void OnMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var instance = (SignalLevelMeter)d;
			var oldValue = (double)e.OldValue;
			var newValue = (double)e.NewValue;

			instance.OnMinimumChanged(oldValue, newValue);
		}

		protected virtual void OnMinimumChanged(double oldValue, double newValue)
		{
		}

		#endregion Minimum

		#region Maximum

		public static readonly DependencyProperty MaximumProperty =
			DependencyProperty.Register("Maximum", typeof(double), typeof(SignalLevelMeter),
				new PropertyMetadata(OnMaximumChanged));

		public double Maximum
		{
			get { return (double)this.GetValue(MaximumProperty); }
			set { this.SetValue(MaximumProperty, value); }
		}

		private static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var instance = (SignalLevelMeter)d;
			var oldValue = (double)e.OldValue;
			var newValue = (double)e.NewValue;

			instance.OnMaximumChanged(oldValue, newValue);
		}

		protected virtual void OnMaximumChanged(double oldValue, double newValue)
		{
		}

		#endregion Maximum

		#region Orientation

		public static readonly DependencyProperty OrientationProperty =
			DependencyProperty.Register("Orientation", typeof(Orientation), typeof(SignalLevelMeter),
				new PropertyMetadata(Orientation.Horizontal));

		public Orientation Orientation
		{
			get { return (Orientation)this.GetValue(OrientationProperty); }
			set { this.SetValue(OrientationProperty, value); }
		}

		#endregion Orientation
	}
}
