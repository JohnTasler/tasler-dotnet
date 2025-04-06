namespace Tasler.Threading;

public interface IUpgradeableLockScope : IDisposable
{
	IDisposable GetUpgradeToWriteLock();

	IDisposable GetDowngradeToReadLock();

	IDisposable? TryGetUpgradeToWriteLock(int milliseconds);

	IDisposable? TryGetUpgradeToWriteLock(TimeSpan timeout);

	IDisposable? TryGetDowngradeToReadLock(int milliseconds);

	IDisposable? TryGetDowngradeToReadLock(TimeSpan timeout);
}
