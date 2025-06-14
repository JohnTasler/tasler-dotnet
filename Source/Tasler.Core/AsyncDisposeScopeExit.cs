using CommunityToolkit.Diagnostics;

namespace Tasler;

/// <summary>
/// A delegate that represents an asynchronous action to be executed when the scope exits.
/// </summary>
/// <returns>A <see cref="Task"/> that should be executed when the object is disposed.</returns>
public delegate Task AsyncAction();

/// <summary>
/// An asynchronously disposable struct that allows you to specify an action to be executed
/// when the scope exits.
/// </summary>
/// <seealso cref="System.IDisposable" />
public class AsyncDisposeScopeExit : IAsyncDisposable
{
	#region Instance Fields
	private AsyncAction? _disposeAsyncAction;
	#endregion Instance Fields

	#region Constructors / Finalizer

	/// <summary>
	/// Initializes a new instance with the specified asynchronous dispose action.
	/// </summary>
	/// <param name="asyncDisposeAction">The asynchronous action to execute when the instance is disposed.</param>
	public AsyncDisposeScopeExit(AsyncAction asyncDisposeAction)
		: this(null, asyncDisposeAction)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="DisposeScopeExit"/> struct.
	/// </summary>
	/// <param name="initializeAction">The optional action to execute (synchronously) upon initialization of the structure.</param>
	/// <param name="asyncDisposeAction">The asynchronous action to execute upon disposal of the structure.</param>
	public AsyncDisposeScopeExit(Action? initializeAction, AsyncAction asyncDisposeAction)
	{
		initializeAction?.Invoke();
		_disposeAsyncAction = asyncDisposeAction;
	}

	~AsyncDisposeScopeExit()
	{
		DisposeAsync().AsTask().Wait();
	}

	/// <summary>
	/// Detaches the dispose action, allowing it to be garbage collected without executing it.
	/// </summary>
	public void DetachDisposeAction()
		=> Interlocked.Exchange(ref _disposeAsyncAction, null);

	#endregion Constructors / Finalizer

	#region IAsyncDisposable Members

	/// <summary>
	/// Performs application-defined tasks associated with freeing, releasing, or
	/// resetting unmanaged resources asynchronously.
	/// </summary>
	/// <returns>A task that represents the asynchronous dispose operation.</returns>
	public async ValueTask DisposeAsync()
	{
		var disposeAsyncAction = Interlocked.Exchange(ref _disposeAsyncAction, null);
		if (disposeAsyncAction != null)
		{
			GC.SuppressFinalize(this);
			await disposeAsyncAction.Invoke();
		}
	}

	#endregion IAsyncDisposable Members
}
