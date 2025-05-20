using CommunityToolkit.Diagnostics;

namespace Tasler;

public delegate Task AsyncAction();

public class AsyncDisposeScopeExit : IAsyncDisposable
{
	#region Instance Fields
	private AsyncAction? _disposeAsyncAction;
	#endregion Instance Fields

	#region Constructors / Finalizer

	public AsyncDisposeScopeExit(AsyncAction disposeAsyncAction)
		: this(null, disposeAsyncAction)
	{
	}

	public AsyncDisposeScopeExit(Action? initializeAction, AsyncAction asyncDisposeAction)
	{
		Guard.IsNotNull(asyncDisposeAction);

		initializeAction?.Invoke();
		_disposeAsyncAction = asyncDisposeAction;
	}

	~AsyncDisposeScopeExit()
	{
		DisposeAsync().AsTask().Wait();
	}

	public void DetachDisposeAction()
		=> Interlocked.Exchange(ref _disposeAsyncAction, null);

	#endregion Constructors / Finalizer

	#region IAsyncDisposable Members

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
