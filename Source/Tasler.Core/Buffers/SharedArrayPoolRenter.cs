using System.Buffers;

namespace Tasler.Buffers;

public class SharedArrayPoolRenter<T> : IDisposable
{
	private IDisposable _disposableScope;
	public T[] Data { get; private set; }

	public SharedArrayPoolRenter(int minimumLength)
	{
		this.Data = ArrayPool<T>.Shared.Rent(minimumLength);
		_disposableScope = new DisposeScopeExit(() => ArrayPool<T>.Shared.Return(this.Data, clearArray: true));
	}

	public void Dispose()
	{
		if (this.Data is not null)
		{
			// Return the array to the pool, clearing it to avoid accidental use after disposal
			ArrayPool<T>.Shared.Return(this.Data, clearArray: true);
			this.Data = null!; // Clear reference to avoid accidental use after disposal

			using (var disposable = _disposableScope)
			{
				_disposableScope = null!; // Prevent double disposal
				disposable.Dispose();
			}

			GC.SuppressFinalize(this); // Suppress finalization as we have already cleaned up
		}
	}

	~SharedArrayPoolRenter()
	{
		// Finalizer to ensure resources are cleaned up if Dispose is not called
		Dispose();
	}
}
