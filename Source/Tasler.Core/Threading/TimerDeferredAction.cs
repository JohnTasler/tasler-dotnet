using System;

namespace Tasler.Threading
{
	/// <summary>
	/// Manages a timer that, when expired, will trigger an <see cref="Action"/> to be executed.
	/// </summary>
	/// <remarks>
	/// <para>This class helps to coalesce multiple similar actions within a timeframe into a single action. The
	/// classic example is persisting a window's size/position when the user changes it. Rather than persisting the
	/// values each time one changes, the change events can simply trigger an instance of
	/// <see cref="TimerDeferredActionBase"/>. The interval timer is reset each time the <see cref="Trigger"/>
	/// method is called.</para>
	/// <para>When creating an instance of this class, you must specify a <see cref="TimeSpan"/> and an
	/// <see cref="Action"/>. To trigger the action for deferred execution, you call the <see cref="Trigger"/> method.
	/// To force a triggered action to execute immediately, call the <see cref="Expire"/> method. Referring again to
	/// the example of persisting the window size, the application should call <see cref="Expire"/> be when the
	/// window is closed. 
	/// </remarks>
	public abstract class TimerDeferredActionBase
	{
		#region Instance Fields
		private ITimerAdapter timer;
		private Action action;
		private bool isStarted;
		#endregion Instance Fields

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="TimerDeferredActionDeferredAction"/> class.
		/// </summary>
		/// <param name="timeSpan">The time span.</param>
		/// <param name="action">The action to execute after each expiration of the timer <see cref="Interval"/>.</param>
		protected TimerDeferredActionBase(ITimerAdapter timerAdapter, TimeSpan timeSpan, Action action)
		{
			if (timerAdapter == null)
				throw new ArgumentNullException("timerAdapter");
			if (action == null)
				throw new ArgumentNullException("action");

			this.timer = timerAdapter;
			this.timer.Tick += this.timer_Tick;
			this.timer.Interval = timeSpan;
			this.action = action;
		}

		#endregion Constructors

		#region Properties
		public TimeSpan Interval
		{
			get { return this.timer.Interval; }
		}
		#endregion Properties

		#region Methods
		/// <summary>
		/// Starts or restarts the timer interval.
		/// </summary>
		public void Trigger()
		{
			// Stop any pending timer
			this.timer.Stop();

			// Start the timer
			this.timer.Start();
			this.isStarted = true;
		}

		/// <summary>
		/// Immediately expires the timer interval, forcing the action to execute.
		/// </summary>
		/// <remarks>
		/// This method does nothing if called when no deferral interval has been triggered.
		/// </remarks>
		public void Expire()
		{
			if (this.isStarted)
				this.timer_Tick(this.timer, EventArgs.Empty);
		}

		#endregion Methods

		#region Private Implementation
		private void timer_Tick(object sender, EventArgs e)
		{
			// Stop the timer
			this.timer.Stop();
			this.isStarted = false;

			// Perform the action
			if (this.action != null)
				this.action();
		}
		#endregion Private Implementation
	}
}
