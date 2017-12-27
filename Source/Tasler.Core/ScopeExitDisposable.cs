using System;

namespace Tasler
{
	// TODO: NEEDS_UNIT_TESTS

	public class ScopeExitDisposable : IDisposable
	{
		#region Instance Fields
		private Action _disposeAction;
		#endregion Instance Fields

		#region Constructors / Finalizer

		public ScopeExitDisposable(Action disposeAction)
			: this(null, disposeAction)
		{
		}

		public ScopeExitDisposable(Action initializeAction, Action disposeAction)
		{
			if (disposeAction == null)
				throw new ArgumentNullException("disposeAction");

			initializeAction?.Invoke();
			_disposeAction = disposeAction;
		}

		~ScopeExitDisposable()
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
}
