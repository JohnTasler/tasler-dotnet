using System.Diagnostics;
using System.Runtime.CompilerServices;
using Tasler.Threading;

#if WINDOWS_UWP
using Dispatcher = Windows.UI.Core.CoreDispatcher;
using DispatcherPriority = Windows.UI.Core.CoreDispatcherPriority;
namespace Tasler.UI.Core;
#elif WINDOWS_WPF
using System.Windows.Threading;
namespace Tasler.Windows.Threading;
#endif

// TODO: Needs unit tests
// TODO: Needs document comments

public abstract class DispatcherThreadBase : IDisposable
{
	#region Static Fields
	private static int s_count = 0;
	#endregion Static Fields

	#region Instance Fields
	private volatile Dispatcher _dispatcher;
	private volatile Thread _thread;
	#endregion Instance Fields

	#region Constructors and Finalizer

	protected DispatcherThreadBase() : this(null)
	{
	}

	protected DispatcherThreadBase(string? threadName)
	{
		var instanceCount = Interlocked.Increment(ref s_count);
		this.ThreadName = threadName ??
				$"{this.GetType().Name}[{instanceCount}]";
	}

	~DispatcherThreadBase()
	{
		this.Dispose();
	}

	#endregion Constructors and Finalizer

	#region Events

	public event EventHandler<Dispatcher>? DispatcherAttached;

	public event EventHandler<Dispatcher>? DispatcherDetached;

	#endregion Events

	#region Properties

	public string ThreadName { get; }

	public bool HasThreadAccess => this.GetHasThreadAccess(this.VerifyNotDisposed());

	#endregion Properties

	#region Methods

	public void Start(ApartmentState apartmentState = ApartmentState.MTA)
	{
		if (_dispatcher == null)
		{
			var thread = ThreadExtensions.Create<AutoResetEvent>(this.ThreadProc);
			try
			{
				thread.SetApartmentState(apartmentState);
			}
			catch (PlatformNotSupportedException ex)
			{
				Debug.WriteLine($"{ex.GetType().Name}: {thread.GetApartmentState()}");
			}
			thread.Name = this.ThreadName;

			var dispatcherCreatedSignal = new AutoResetEvent(false);
			thread.Start(dispatcherCreatedSignal);
			dispatcherCreatedSignal.WaitOne();
			_thread = thread;
		}
		else
		{
			throw new InvalidOperationException($"{this.GetType().FullName}.{nameof(this.Start)} called while already running: ThreadName={this.ThreadName}");
		}
	}

	public void Stop()
	{
		var dispatcher = _dispatcher;
		if (dispatcher != null)
			this.StopDispatcher(dispatcher);
	}

	public void VerifyHasThreadAccess()
	{
		this.VerifyThreadAccess(_dispatcher);
	}

	#endregion Methods

	#region Dispatcher Access Methods

	#region Non-waiting (fire-and-forget) Methods

	public void RunAsyncNoWait(Action action)
	{
		this.VerifyNotDisposed().RunAsyncNoWait(DispatcherPriority.Normal, action);
	}

	public void RunAsyncNoWait(DispatcherPriority priority, Action action)
	{
		var assignmentPreventsWarning = this.VerifyNotDisposed().RunAsync(priority, () => action());
	}

	public void RunIdleAsyncNoWait(Action action)
	{
		var assignmentPreventsWarning = this.VerifyNotDisposed().RunIdleAsync(() => action());
	}

	#endregion Non-waiting (fire-and-forget) Methods

	#region Awaitable Methods

	public Task RunAsync(Action action)
	{
		return this.VerifyNotDisposed().RunAsync(action);
	}

	public Task RunAsync(DispatcherPriority priority, Action action)
	{
		return this.VerifyNotDisposed().RunAsync(priority, action);
	}

	public Task RunIdleAsync(Action action)
	{
		return this.VerifyNotDisposed().RunIdleAsync(action);
	}

	#endregion Awaitable Methods

	#region Awaitable Methods with result

	public Task<TResult> RunAsync<TResult>(Func<TResult> func)
	{
		return this.VerifyNotDisposed().RunAsync(DispatcherPriority.Normal, func);
	}

	public Task<TResult> RunAsync<TResult>(DispatcherPriority priority, Func<TResult> func)
	{
		return this.VerifyNotDisposed().RunAsync(priority, func);
	}

	public Task<TResult> RunIdleAsync<TResult>(Func<TResult> func)
	{
		return this.VerifyNotDisposed().RunIdleAsync(func);
	}

	#endregion Awaitable Methods

	#endregion Dispatcher Access Methods

	#region Overridables

	protected virtual void OnDispatcherAttached(Dispatcher dispatcher)
	{
	}

	protected virtual void OnDispatcherDetached(Dispatcher dispatcher)
	{
	}

	protected abstract Dispatcher CreateDispatcher();

	protected abstract void EnterDispatcherLoop(Dispatcher dispatcher);

	protected abstract void ExitDispatcherLoop(Dispatcher dispatcher);

	protected abstract bool GetHasThreadAccess(Dispatcher dispatcher);

	protected abstract void VerifyThreadAccess(Dispatcher dispatcher);

	#endregion Overridables

	#region Private Implementation

	private void RaiseDispatcherAttached(Dispatcher dispatcher)
	{
		this.OnDispatcherAttached(dispatcher);
		this.DispatcherAttached?.Invoke(this, dispatcher);
	}

	private void RaiseDispatcherDetached(Dispatcher dispatcher)
	{
		this.OnDispatcherDetached(dispatcher);
		this.DispatcherDetached?.Invoke(this, dispatcher);
	}

	private void StopDispatcher(Dispatcher dispatcher)
	{
		if (dispatcher != null)
			this.ExitDispatcherLoop(dispatcher);
	}

	private Dispatcher VerifyNotDisposed([CallerMemberName] string fromMethod = null)
	{
		var dispatcher = _dispatcher;
		if (dispatcher == null)
			throw new ObjectDisposedException($"{this.ThreadName}", $"Cannot access the ${fromMethod} member of a non-running {this.GetType().FullName} instance");

		return dispatcher;
	}

	private void ThreadProc(AutoResetEvent? dispatcherCreatedSignal)
	{


		var dispatcher = this.CreateDispatcher();
		_dispatcher = dispatcher;

		dispatcherCreatedSignal.Set();
		this.RaiseDispatcherAttached(dispatcher);

		try
		{
			this.EnterDispatcherLoop(dispatcher);
		}
		finally
		{
			_dispatcher = null;
			this.RaiseDispatcherDetached(dispatcher);

			_thread = null;
		}
	}

	#endregion Private Implementation

	#region IDisposable

	public void Dispose()
	{
		var dispatcher = _dispatcher;
		if (dispatcher != null)
		{
			this.StopDispatcher(dispatcher);
			GC.SuppressFinalize(this);
		}

		this.DispatcherAttached = null;
		this.DispatcherDetached = null;
	}

	#endregion IDisposable
}
