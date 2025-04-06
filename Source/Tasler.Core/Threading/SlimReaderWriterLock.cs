using System.Diagnostics;
using CommunityToolkit.Diagnostics;

// TODO: REALLY NEEDS UNIT TESTS
// TODO: Figure out a way to add low-cost/no-cost diagnostics

namespace Tasler.Threading;

public class SlimReaderWriterLock : IDisposable
{
	internal static string GetCallingFrameInfo(string middleText)
	{
		StackFrame frame = new StackTrace(2, true).GetFrame(0)!;
		return string.Format(
			"{0}.{1}: {2}\n{3}({4}, {5})",
			frame.GetMethod()!.DeclaringType!.Name, frame.GetMethod()!.Name, middleText,
			frame.GetFileName(), frame.GetFileLineNumber(), frame.GetFileColumnNumber());
	}

	#region Instance Fields
	private ReaderWriterLockSlim? _readerWriterLockSlim;
	#endregion Instance Fields

	#region Construction
	public SlimReaderWriterLock()
		: this(new ReaderWriterLockSlim())
	{
	}

	private SlimReaderWriterLock(ReaderWriterLockSlim readerWriterLockSlim)
	{
		Guard.IsNotNull(readerWriterLockSlim);
		_readerWriterLockSlim = readerWriterLockSlim;
	}
	#endregion Construction

	public IDisposable GetReadLock()
	{
		if (_readerWriterLockSlim is not null)
		{
			_readerWriterLockSlim.EnterReadLock();
			return new DisposeScopeExit(() => _readerWriterLockSlim.ExitReadLock());
		}

		throw new ObjectDisposedException(nameof(ReaderWriterLockSlim));
	}

	public IDisposable GetUpgradeableReadLock()
	{
		if (_readerWriterLockSlim is not null)
		{
			_readerWriterLockSlim.EnterUpgradeableReadLock();
			return new UpgradeableLockScope(_readerWriterLockSlim);
		}

		throw new ObjectDisposedException(nameof(ReaderWriterLockSlim));
	}

	public IDisposable GetWriteLock()
	{
		if (_readerWriterLockSlim is not null)
		{
			_readerWriterLockSlim.EnterWriteLock();
			return new DisposeScopeExit(() => _readerWriterLockSlim.ExitWriteLock());
		}

		throw new ObjectDisposedException(nameof(ReaderWriterLockSlim));
	}

	public IDisposable? TryGetReadLock(int millisecondsTimeout)
	{
		if (_readerWriterLockSlim is not null)
		{
			return _readerWriterLockSlim.TryEnterReadLock(millisecondsTimeout)
				? new DisposeScopeExit(() => _readerWriterLockSlim.ExitReadLock())
				: null;
		}

		throw new ObjectDisposedException(nameof(ReaderWriterLockSlim));
	}

	public IDisposable? TryGetReadLock(TimeSpan timeout) => TryGetReadLock((int)timeout.TotalMilliseconds);

	public IDisposable? TryGetUpgradeableReadLock(int millisecondsTimeout)
	{
		if (_readerWriterLockSlim is not null)
		{
			return _readerWriterLockSlim.TryEnterUpgradeableReadLock(millisecondsTimeout)
				? new UpgradeableLockScope(_readerWriterLockSlim)
				: null;
		}

		throw new ObjectDisposedException(nameof(ReaderWriterLockSlim));
	}

	public IDisposable? TryGetUpgradeableReadLock(TimeSpan timeout) => TryGetUpgradeableReadLock((int)timeout.TotalMilliseconds);

	public IDisposable? TryGetWriteLock(int millisecondsTimeout)
	{
		if (_readerWriterLockSlim is not null)
		{
			return _readerWriterLockSlim.TryEnterWriteLock(millisecondsTimeout)
				? new DisposeScopeExit(() => _readerWriterLockSlim.ExitWriteLock())
				: null;
		}

		throw new ObjectDisposedException(nameof(ReaderWriterLockSlim));
	}

	public IDisposable? TryGetWriteLock(TimeSpan timeout) => TryGetWriteLock((int)timeout.TotalMilliseconds);

	#region IDisposable Members

	public void Dispose()
	{
		if (_readerWriterLockSlim is not null)
		{
			using (_readerWriterLockSlim)
			_readerWriterLockSlim = null;
		}
	}

	#endregion IDisposable Members

	#region Nested Types
	private class UpgradeableLockScope : IUpgradeableLockScope
	{
		private ReaderWriterLockSlim? _readerWriterLockSlim;

		public UpgradeableLockScope(ReaderWriterLockSlim readerWriterLockSlimAction)
		{
			Guard.IsNotNull(readerWriterLockSlimAction);
			_readerWriterLockSlim = readerWriterLockSlimAction;
		}

		~UpgradeableLockScope() => this.Dispose();

		public void Dispose()
		{
			var readerWriterLockSlim = Interlocked.Exchange(ref _readerWriterLockSlim, null);
			if (readerWriterLockSlim is not null)
			{
				readerWriterLockSlim.ExitUpgradeableReadLock();
				GC.SuppressFinalize(this);
			}
		}

		public IDisposable GetUpgradeToWriteLock()
		{
			if (_readerWriterLockSlim is not null)
			{
				_readerWriterLockSlim.EnterWriteLock();
				return new DisposeScopeExit(() => _readerWriterLockSlim.ExitWriteLock());
			}

			throw new ObjectDisposedException(nameof(UpgradeableLockScope));
		}

		public IDisposable GetDowngradeToReadLock()
		{
			var readerWriterLockSlim = Interlocked.Exchange(ref _readerWriterLockSlim, null);
			if (readerWriterLockSlim is not null)
			{
				readerWriterLockSlim.EnterReadLock();
				readerWriterLockSlim.ExitUpgradeableReadLock();
				return new DisposeScopeExit(() => readerWriterLockSlim.ExitReadLock());
			}

			throw new ObjectDisposedException(nameof(UpgradeableLockScope));
		}

		public IDisposable? TryGetUpgradeToWriteLock(int milliseconds)
		{
			if (_readerWriterLockSlim is not null)
			{
				return _readerWriterLockSlim.TryEnterWriteLock(milliseconds)
					? new DisposeScopeExit(() => _readerWriterLockSlim.ExitWriteLock())
					: null;
			}

			throw new ObjectDisposedException(nameof(UpgradeableLockScope));
		}

		public IDisposable? TryGetUpgradeToWriteLock(TimeSpan timeout)
		=> TryGetUpgradeToWriteLock((int)timeout.TotalMilliseconds);

		public IDisposable? TryGetDowngradeToReadLock(int milliseconds)
		{
			var readerWriterLockSlim = Interlocked.Exchange(ref _readerWriterLockSlim, null);
			if (readerWriterLockSlim is not null)
			{
				if (readerWriterLockSlim.TryEnterReadLock(milliseconds))
				{
					readerWriterLockSlim.ExitUpgradeableReadLock();
					return new DisposeScopeExit(() => readerWriterLockSlim.ExitReadLock());
				}
				return null;
			}

			throw new ObjectDisposedException(nameof(UpgradeableLockScope));
		}

		public IDisposable? TryGetDowngradeToReadLock(TimeSpan timeout)
			=> TryGetDowngradeToReadLock((int)timeout.TotalMilliseconds);
	}
	#endregion Nested Types
}

//#region Diagnostics

//private const bool IsLogging = false;

//internal static string GetCallingFrameInfo(string middleText)
//{
//	StackFrame frame = new StackTrace(2, true).GetFrame(0)!;
//	return string.Format(
//		"{0}.{1}: {2}\n{3}({4}, {5})",
//		frame.GetMethod()?.DeclaringType?.Name, frame.GetMethod()?.Name, middleText,
//		frame.GetFileName(), frame.GetFileLineNumber(), frame.GetFileColumnNumber());
//}

//#endregion Diagnostics

