using System.Runtime.InteropServices;
using Tasler.Buffers;

namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	/// <summary>
	/// Wraps a COM enumeration sequence in an <see cref="IEnumerable{TItem}"/>.
	/// </summary>
	/// <typeparam name="TComCollection">The type of the COM enumeration sequence.</typeparam>
	/// <typeparam name="TComItem">The type of the elements in the COM enumeration sequence.</typeparam>
	/// <returns>The HRESULT of the fetch (IEnum*.Next) operation.</returns>
	/// <param name="this">The COM enumerator instance.</param>
	/// <param name="fetchFunction">The <see cref="FetchFunction{TCollection, TItem}"/> that is
	/// typed to return the correct item type.</param>
	/// <param name="blockSize">The block size to fetch at a time.</param>
	/// <returns></returns>
	public static IEnumerable<TItem> AsEnumerable<TComCollection, TComItem, TFetcher, TItem, TConverter>(
		this TComCollection @this,
		int blockSize = DefaultEnumerationBlockSize)
		where TFetcher : IComFetcher<TComCollection, TComItem>
		where TConverter : IComFetchConverter<TComItem, TItem>
		=> @this.AsEnumerable<TComCollection, TComItem, TFetcher>(blockSize).Select(TConverter.Convert);

	/// <summary>
	/// Wraps a COM enumeration sequence in an <see cref="IEnumerable{TComItem}"/>.
	/// </summary>
	/// <typeparam name="TComCollection">The type of the COM enumeration sequence.</typeparam>
	/// <typeparam name="TComItem">The type of the elements in the COM enumeration sequence.</typeparam>
	/// <returns>The HRESULT of the fetch (IEnum*.Next) operation.</returns>
	/// <param name="this">The COM enumerator instance.</param>
	/// <param name="fetchFunction">The <see cref="FetchFunction{TCollection, TItem}"/> that is
	/// typed to return the correct item type.</param>
	/// <param name="blockSize">The block size to fetch at a time.</param>
	/// <returns></returns>
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
