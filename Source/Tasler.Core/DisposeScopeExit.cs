namespace Tasler;

// TODO: NEEDS_UNIT_TESTS

public class DisposeScopeExit : IDisposable
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
		ValidateArgument.IsNotNull(disposeAction, nameof(disposeAction));

		initializeAction?.Invoke();
		_disposeAction = disposeAction;
	}

	public void DetachDisposeAction() => _disposeAction = null;

	~DisposeScopeExit()
	{
		this.Dispose();
	}
	#endregion Constructors / Finalizer

	#region IDisposable Members

	public void Dispose()
	{
		_disposeAction?.Invoke();
		_disposeAction = null;

		GC.SuppressFinalize(this);
	}

	#endregion IDisposable Members
}
