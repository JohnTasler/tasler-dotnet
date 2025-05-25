using CommunityToolkit.Diagnostics;

namespace Tasler;

/// <summary>
/// A disposable struct that allows you to specify an action to be executed when the scope exits.
/// </summary>
/// <seealso cref="System.IDisposable" />
public struct DisposeScopeExit : IDisposable
{
	#region Instance Fields
	private Action? _disposeAction;
	#endregion Instance Fields

	#region Constructors / Finalizer

	/// <summary>
	/// Initializes a new instance of the <see cref="DisposeScopeExit"/> struct.
	/// </summary>
	/// <param name="disposeAction">The action to execute upon disposal of the structure.</param>
	public DisposeScopeExit(Action disposeAction)
		: this(null, disposeAction)
	{
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="DisposeScopeExit"/> struct.
	/// </summary>
	/// <param name="initializeAction">The optional action to execute upon initialization of the structure.</param>
	/// <param name="disposeAction">The action to execute upon disposal of the structure.</param>
	public DisposeScopeExit(Action? initializeAction, Action disposeAction)
	{
		Guard.IsNotNull(disposeAction);

		initializeAction?.Invoke();
		_disposeAction = disposeAction;
	}

	/// <summary>
	/// Detaches the dispose action, allowing it to be garbage collected without executing it.
	/// </summary>
	public void DetachDisposeAction() => _disposeAction = null;

	#endregion Constructors / Finalizer

	#region IDisposable Members

	/// <summary>
	/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
	/// </summary>
	public void Dispose()
	{
		_disposeAction?.Invoke();
		_disposeAction = null;
	}

	#endregion IDisposable Members
}
