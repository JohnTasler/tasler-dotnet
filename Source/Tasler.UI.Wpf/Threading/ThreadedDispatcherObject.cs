using System.ComponentModel;
using System.Windows.Threading;

namespace Tasler.Windows.Threading;

public class ThreadedDispatcherObject
{
	#region Instance Fields
	private object _lockObject = new object();
	private Dispatcher? _dispatcher;
	#endregion Instance Fields

	#region Properties

	public Dispatcher? Dispatcher
	{
		get
		{
			lock (_lockObject)
				return _dispatcher;
		}
	}

	#endregion Properties

	#region Methods

	public void Start() => this.Start(ApartmentState.MTA);

	public void Start(ApartmentState apartmentState)
	{
		if (this.Dispatcher == null)
		{
			AutoResetEvent? dispatcherCreatedEvent = null;
			lock (_lockObject)
			{
				if (_dispatcher is null)
				{
					Thread thread = new Thread(this.ThreadProc);
					thread.SetApartmentState(apartmentState);
					thread.Name = this.ThreadName;
					dispatcherCreatedEvent = new AutoResetEvent(false);
					thread.Start(dispatcherCreatedEvent);
				}
			}

			if (dispatcherCreatedEvent is not null)
				dispatcherCreatedEvent.WaitOne();
		}
	}

	public void Shutdown()
	{
		var dispatcher = this.Dispatcher;
		if (dispatcher is not null && !dispatcher.HasShutdownStarted && !dispatcher.HasShutdownFinished)
			dispatcher.InvokeShutdown();
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public bool CheckAccess()
	{
		var dispatcher = this.Dispatcher;
		if (dispatcher is not null)
			return dispatcher.CheckAccess();
		return true;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public void VerifyAccess()
	{
		var dispatcher = this.Dispatcher;
		if (dispatcher is not null)
			dispatcher.VerifyAccess();
	}

	#endregion Methods

	#region Overridables

	protected virtual string? ThreadName => this.GetType().FullName;

	protected virtual void OnDispatcherAttached()
	{
	}

	protected virtual void OnDispatcherDetaching()
	{
	}

	#endregion Overridables

	#region Private Implementation

	private void ThreadProc(object? dispatcherCreatedEventObject)
	{
		lock (_lockObject)
			_dispatcher = Dispatcher.CurrentDispatcher;

		((EventWaitHandle?)dispatcherCreatedEventObject)?.Set();
		this.OnDispatcherAttached();

		Dispatcher.Run();

		this.OnDispatcherDetaching();

		lock (_lockObject)
			_dispatcher = null;
	}

	#endregion Private Implementation
}
