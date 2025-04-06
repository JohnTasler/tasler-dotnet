using CommunityToolkit.Diagnostics;

namespace Tasler;

// TODO: NEEDS_UNIT_TESTS

public struct DisposeScopeExit : IDisposable
{
	#region Instance Fields
	private Action? _disposeAction;
	#endregion Instance Fields

	#region Constructors / Finalizer

	public DisposeScopeExit(Action disposeAction)
		: this(null, disposeAction)
	{
	}

	public DisposeScopeExit(Action? initializeAction, Action disposeAction)
	{
		Guard.IsNotNull(disposeAction);

		initializeAction?.Invoke();
		_disposeAction = disposeAction;
	}

	public void DetachDisposeAction() => _disposeAction = null;

	#endregion Constructors / Finalizer

	#region IDisposable Members

	public void Dispose()
	{
		_disposeAction?.Invoke();
		_disposeAction = null;
	}

	#endregion IDisposable Members
}
