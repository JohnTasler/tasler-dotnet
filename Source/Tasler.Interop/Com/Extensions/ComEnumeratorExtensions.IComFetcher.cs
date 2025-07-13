namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	/// <summary>
	/// Defines an interface with a static method to fetch items from a COM collection.
	/// </summary>
	/// <typeparam name="TComCollection">The interface type of the COM collection.</typeparam>
	/// <typeparam name="TComItem">The type of the COM item.</typeparam>
	public interface IComFetcher<TComCollection, TComItem>
{
	/// <summary>
	/// Attempts to fetch an array of elements from a COM enumerator interface.
	/// </summary>
	/// <param name="enumerator">The COM enumerator.</param>
	/// <param name="elements">The element array to fetch into.</param>
	/// <param name="elementsFetched">The count of elements fetched.</param>
	/// <returns>
	/// <c>S_OK</c> (zero) if the array was filled, or <c>S_FALSE</c> (1) if less than
	/// <paramref name="elementsFetched"/> elements were fetched; othewise a COM error code (less than 0).
	/// </returns>
	static abstract int Fetch(TComCollection enumerator, TComItem[] elements, out int elementsFetched);
}
}
