using System.Buffers;

namespace Tasler.Buffers;

public class SharedArrayPoolRenter<T> : IDisposable
{
	public T[] Data { get; private set; }

	/// <summary>
	/// Rents an array of at least the specified minimum length from the shared array pool.
	/// </summary>
	/// <param name="minimumLength">The minimum required length of the rented array.</param>
	/// <summary>
	/// Rents an array from ArrayPool&lt;T&gt;.Shared with at least the specified minimum length.
	/// </summary>
	/// <param name="minimumLength">Minimum required length of the rented array.</param>
	/// <param name="clearArray">Whether to clear the rented array's contents after renting.</param>
	public SharedArrayPoolRenter(int minimumLength, bool clearArray = true)
	{
		this.Data = ArrayPool<T>.Shared.Rent(minimumLength);
		if (clearArray)
			Array.Clear(this.Data);
	}

	/// <summary>
	/// Releases the rented array back to the shared pool, clears its contents, and suppresses finalization.
	/// </summary>
	public void Dispose()
	{
		if (this.Data is not null)
		{
			// Return the array to the pool, clearing it to avoid accidental use after disposal
			ArrayPool<T>.Shared.Return(this.Data, clearArray: true);
			this.Data = null!; // Clear reference to avoid accidental use after disposal

			GC.SuppressFinalize(this); // Suppress finalization as we have already cleaned up
		}
	}

	~SharedArrayPoolRenter()
	{
		// Finalizer to ensure resources are cleaned up if Dispose is not called
		Dispose();
	}
}