
namespace Tasler.Collections;

public static class CollectionExtensions
{
	/// <summary>
	/// Disposes all object in the specified collection and then clears the collection.
	/// </summary>
	/// <typeparam name="T">The type of the element sequence. Must implement <see cref="IDisposable"/>.</typeparam>
	/// <param name="this">The source collection. The method does nothing if this is <see langword="null"/>.</param>
	/// <seealso cref="Tasler.Collections.EnumerableExtensions.DisposeAll{T}(IEnumerable{T})"/>
	public static void DisposeAllAndClear<T>(this ICollection<T> @this)
		where T : IDisposable
	{
		if (@this is null)
			return;

		@this.DisposeAll();
		@this.Clear();
	}
}
