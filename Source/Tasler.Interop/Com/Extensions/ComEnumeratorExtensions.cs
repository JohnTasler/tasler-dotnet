using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Tasler.Buffers;

namespace Tasler.Interop.Com;

public static class ComEnumeratorExtensions
{
	/// <summary>
	/// The default enumeration block size.
	/// </summary>
	public const int DefaultEnumerationBlockSize = 16;

	/// <summary>
	/// Defines a function that retrieves the next elements of a COM enumeration sequence.
	/// </summary>
	/// <typeparam name="TCollection">The type of the COM enumeration sequence.</typeparam>
	/// <typeparam name="TItem">The type of the elements in the COM enumeration sequence.</typeparam>
	/// <param name="enumerator">The COM enumerator instance.</param>
	/// <param name="elements">The elements array to be filled by the COM enumerator.</param>
	/// <param name="elementsFetched">The count of elements retrieved.</param>
	/// <returns>The HRESULT of the fetch (IEnum*.Next) operation.</returns>
	public delegate int FetchFunction<TCollection, TItem>(TCollection enumerator, TItem[] elements, out int elementsFetched);

	/// <summary>
	/// A method that serves as the <see cref="FetchFunction{TCollection, TItem}"/> for an
	/// <see cref="IEnumFORMATETC"/> COM enumeration sequence.
	/// </summary>
	/// <param name="enumerator">The <see cref="IEnumFORMATETC"/> instance.</param>
	/// <param name="elements">The elements array to be filled by the COM enumerator.</param>
	/// <param name="elementsFetched">The count of elements retrieved.</param>
	/// <returns>
	/// The HRESULT of the fetch (<see cref="IEnumFORMATETC.Next(int, FORMATETC[], out int)"/>) operation.
	/// </returns>
	public static int FetchFORMATETC(IEnumFORMATETC enumerator, FORMATETC[] elements, out int elementsFetched)
		=> enumerator.Next(elements.Length, elements, out elementsFetched);

	/// <summary>
	/// A method that serves as the <see cref="FetchFunction{TCollection, TItem}"/> for an
	/// <see cref="IEnumMoniker"/> COM enumeration sequence.
	/// </summary>
	/// <param name="enumerator">The <see cref="IEnumMoniker"/> instance.</param>
	/// <param name="elements">The elements array to be filled by the COM enumerator.</param>
	/// <param name="elementsFetched">The count of elements retrieved.</param>
	/// <returns>
	/// The HRESULT of the fetch (<see cref="IEnumMoniker.Next(int, IMoniker[], out int)"/>) operation.
	/// </returns>
	public static int FetchIMoniker(IEnumMoniker enumerator, IMoniker[] elements, out int elementsFetched)
		=> enumerator.Next(elements.Length, elements, out elementsFetched);

	/// <summary>
	/// A method that serves as the <see cref="FetchFunction{TCollection, TItem}"/> for an
	/// <see cref="IEnumString"/> COM enumeration sequence.
	/// </summary>
	/// <param name="enumerator">The <see cref="IEnumString"/> instance.</param>
	/// <param name="elements">The elements array to be filled by the COM enumerator.</param>
	/// <param name="elementsFetched">The count of elements retrieved.</param>
	/// <returns>
	/// The HRESULT of the fetch (<see cref="IEnumString.Next(int, nint[], out int)"/>) operation.
	/// </returns>
	public static int FetchString(IEnumString enumerator, nint[] elements, out int elementsFetched)
		=> enumerator.Next(elements.Length, elements, out elementsFetched);

	/// <summary>
	/// Wraps a COM <see cref="IEnumFORMATETC"/> to an <see cref="IEnumerable{FORMATETC}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumFORMATETC"/> instance.</param>
	/// <returns>An <see cref="IEnumerable{FORMATETC}"/>.</returns>
	public static IEnumerable<FORMATETC> AsEnumerable(this IEnumFORMATETC @this)
		=> @this.AsEnumerable<IEnumFORMATETC, FORMATETC>(FetchFORMATETC);

	/// <summary>
	/// Wraps a COM <see cref="IEnumMoniker"/> to an <see cref="IEnumerable{IMoniker}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumMoniker"/> instance.</param>
	/// <returns>An <see cref="IEnumerable{IMoniker}"/>.</returns>
	public static IEnumerable<IMoniker?> AsEnumerable(this IEnumMoniker @this)
		=> @this.AsEnumerable<IEnumMoniker, IMoniker>(FetchIMoniker);

	/// <summary>
	/// Wraps a COM <see cref="IEnumString"/> to an <see cref="IEnumerable{String}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumString"/> instance.</param>
	/// <returns>An <see cref="IEnumerable{String}"/>.</returns>
	public static IEnumerable<string> AsEnumerable(this IEnumString @this)
		=> @this.AsEnumerable<IEnumString, nint>(FetchString).Select(s =>
		{
			using (var ms = new SafeCoTaskMemString { Handle = s })
				return ms.Value;
		});

	/// <summary>
	/// Wraps a COM enumeration sequence in an <see cref="IEnumerable{T}"/>.
	/// </summary>
	/// <typeparam name="TCollection">The type of the COM enumeration sequence.</typeparam>
	/// <typeparam name="TItem">The type of the elements in the COM enumeration sequence.</typeparam>
	/// <returns>The HRESULT of the fetch (IEnum*.Next) operation.</returns>
	/// <param name="this">The COM enumerator instance.</param>
	/// <param name="fetchFunction">The <see cref="FetchFunction{TCollection, TItem}"/> that is
	/// typed to return the correct item type.</param>
	/// <param name="blockSize">The block size to fetch at a time.</param>
	/// <returns></returns>
	public static IEnumerable<TItem> AsEnumerable<TCollection, TItem>(
		this TCollection @this,
		FetchFunction<TCollection, TItem> fetchFunction,
		int blockSize = DefaultEnumerationBlockSize)
	{
		// Allocate a block of elements
		using var renter = new SharedArrayPoolRenter<TItem>(blockSize);

		var elements = renter.Data;
		int hr;

		do
		{
			// Fetch the next block of elements
			hr = fetchFunction(@this, elements, out int fetched);
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
