using System.Diagnostics;

namespace Tasler.Threading;

// TODO: NEEDS_UNIT_TESTS

/// <summary>
/// Manages a timer that, when expired, will trigger an <see cref="System.Action"/> to be executed.
/// </summary>
/// <remarks>
/// <para>This class helps to coalesce multiple similar actions within a timeframe into a single action. The
/// classic example is persisting a window's size/position when the user changes it. Rather than persisting the
/// values each time one of these properties changes, the change events can simply trigger an instance of
/// <see cref="TimerDeferredAction"/>. The interval timer is reset each time the <see cref="Trigger"/>
/// method is called.</para>
/// <para>When creating an instance of this class, you must specify a <see cref="TimeSpan"/> and an
/// <see cref="System.Action"/>. To trigger the action for deferred execution, you call the <see cref="Trigger"/> method.
/// When an instance of this class is finalized, if a triggered action has not executed, it will be done so at this
/// time. However, it is better to force this to happen at a more appropriate point in the application. Usually the
/// best place to do so is when the object that created the <see cref="TimerDeferredAction"/> is leaving scope.
/// Referring again to the example of persisting the window size, the appropriate place would be when the window is
/// closed. To force a triggered action to execute immediately, call the <see cref="Expire"/> method.</para>
/// </remarks>
public class TimerDeferredAction : IDisposable
{
	#region Constructors / Finalizer

	/// <summary>
	/// Initializes a new instance of the <see cref="TimerDeferredAction" /> class.
	/// </summary>
	/// <param name="timerAdapter">The timer adapter.</param>
	/// <param name="interval">The time span.</param>
	/// <param name="action">The action to execute after each expiration of the timer <see paramref="interval" />.</param>
	/// <exception cref="System.ArgumentNullException">action</exception>
	public TimerDeferredAction(ITimerAdapter timerAdapter, TimeSpan interval, Action action)
	{
		ValidateArgument.IsNotNull(timerAdapter, nameof(timerAdapter));
		ValidateArgument.IsNotNull(action, nameof(action));

		this.Interval = interval;
		_action = action;
		_timer = timerAdapter;
		_timer.Tick += this.Timer_Tick;
	}

	/// <summary>
	/// Releases unmanaged resources and performs other cleanup operations before the
	/// <see cref="TimerDeferredAction"/> is reclaimed by garbage collection.
	/// </summary>
	/// <remarks>
	/// This is just in hope that the deferred action gets run when it goes out of scope, on the
	/// collection. In practice, the application should call <see cref="Expire"/> at a time
	/// appropriate, such as a handler for <see cref="Window.Closed"/>.
	/// </remarks>
	~TimerDeferredAction()
	{
		this.Dispose();
	}
	#endregion Constructors / Finalizer

	#region Properties
	public TimeSpan Interval { get; }
	#endregion Properties

	#region Methods
	/// <summary>
	/// Starts or restarts the timer interval.
	/// </summary>
	public TimerDeferredAction Trigger()
	{
		var timer = _timer;

		// Stop any pending timer
		timer?.Stop();

		// Start the timer
		timer?.Start();
		Interlocked.Exchange(ref _hasBeenTriggered, true);

		return this;
	}

	/// <summary>
	/// Immediately expires the timer interval, forcing the action to execute.
	/// </summary>
	/// <remarks>
	/// This method does nothing if called when no deferral interval has been triggered.
	/// </remarks>
	public TimerDeferredAction Expire()
	{
		var timer = _timer;
		if (Interlocked.Exchange(ref _hasBeenTriggered, false) && timer is not null)
			this.Timer_Tick(timer, EventArgs.Empty);
		return this;
	}

	#endregion Methods

	#region IDisposable Members

	/// <summary>
	/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
	/// </summary>
	public void Dispose()
	{
		this.Expire();

		Interlocked.Exchange(ref _action, null);
		var timer = Interlocked.Exchange(ref _timer, null);
		(timer as IDisposable)?.Dispose();
		GC.SuppressFinalize(this);
	}

	#endregion IDisposable Members

	#region Instance Fields
	private ITimerAdapter? _timer;
	private Action? _action;
	private bool _hasBeenTriggered;
	#endregion Instance Fields

	#region Event Handlers
	private void Timer_Tick(object? sender, EventArgs e)
	{
		// Stop the timer
		_timer?.Stop();
		Interlocked.Exchange(ref _hasBeenTriggered, false);

		// Perform the action
		try
		{
			_action?.Invoke();
		}
		catch (Exception ex)
		{
			Debug.Fail("TimerDeferredAction.Timer_Tick: execution of action threw an exception", ex.Message);
			throw;
		}
	}
	#endregion Event Handlers
}
