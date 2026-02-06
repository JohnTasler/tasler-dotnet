using System.Runtime.InteropServices;
using Tasler.Buffers;

namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	/// <summary>
	/// Wraps a COM collection as an <see cref="IEnumerable{TItem}"/> by fetching underlying COM items in blocks and converting each to <typeparamref name="TItem"/>.
	/// </summary>
	/// <typeparam name="TComCollection">The COM collection type that provides the enumerator.</typeparam>
	/// <typeparam name="TComItem">The raw COM item type returned by the fetcher.</typeparam>
	/// <typeparam name="TFetcher">A fetcher that reads blocks of <typeparamref name="TComItem"/> from the COM collection.</typeparam>
	/// <typeparam name="TItem">The target item type produced by the converter.</typeparam>
	/// <typeparam name="TConverter">A converter that transforms <typeparamref name="TComItem"/> instances into <typeparamref name="TItem"/>.</typeparam>
	/// <param name="this">The COM enumerator instance.</param>
	/// <param name="fetchFunction">The <see cref="FetchFunction{TCollection, TItem}"/> that is
	/// typed to return the correct item type.</param>
	/// <param name="blockSize">The number of elements to request per fetch operation.</param>
	/// <returns>An <see cref="IEnumerable{TItem}"/> that yields converted items from the underlying COM enumeration.</returns>
	public static IEnumerable<TItem> AsEnumerable<TComCollection, TComItem, TFetcher, TItem, TConverter>(
		this TComCollection @this,
		int blockSize = DefaultEnumerationBlockSize)
		where TFetcher : IComFetcher<TComCollection, TComItem>
		where TConverter : IComFetchConverter<TComItem, TItem>
		=> @this.AsEnumerable<TComCollection, TComItem, TFetcher>(blockSize).Select(TConverter.Convert);

	/// <summary>
	/// Enumerates items from a COM collection by fetching them in fixed-size blocks.
	/// </summary>
	/// <typeparam name="TComCollection">The COM collection type being enumerated.</typeparam>
	/// <typeparam name="TComItem">The COM item type returned by the native enumeration.</typeparam>
	/// <typeparam name="TFetcher">A fetcher that implements <c>IComFetcher&lt;TComCollection, TComItem&gt;</c> to retrieve blocks of items.</typeparam>
	/// <param name="this">The COM enumerator instance.</param>
	/// <param name="fetchFunction">The <see cref="FetchFunction{TCollection, TItem}"/> that is
	/// <param name="blockSize">Maximum number of items to request from the COM enumerator per fetch operation.</param>
	/// <returns>An <see cref="IEnumerable{TComItem}"/> that yields non-null items fetched from the COM collection.</returns>
	/// <exception cref="System.Exception">Thrown when the underlying fetch returns a negative HRESULT; the thrown exception corresponds to that HRESULT.</exception>
	public static IEnumerable<TComItem> AsEnumerable<TComCollection, TComItem, TFetcher>(
		this TComCollection @this,
		int blockSize = DefaultEnumerationBlockSize)
		where TFetcher : IComFetcher<TComCollection, TComItem>
	{
		// Allocate a block of elements
		using var renter = new SharedArrayPoolRenter<TComItem>(blockSize);

		var elements = renter.Data;
		int hr;

		do
		{
			// Fetch the next block of elements
			hr = TFetcher.Fetch(@this, elements, out int fetched);
			if (hr == 0 || hr == 1)
			{
				for (int index = 0; index < fetched; ++index)
				{
					// If the item is null, we skip it
					if (elements[index] is not null)
						yield return elements[index];
				}
			}
			else if (hr < 0)
			{
				throw Marshal.GetExceptionForHR(hr)!;
			}

		} while (hr == 0);
	}
}
