using System.Runtime.CompilerServices;
using Tasler.Interop.Com.Extensions;

namespace Tasler.Interop.Shell.Extensions;

public static partial class ShellEnumeratorExtensions
{
	/// <summary>
	/// Fetches and converts items from an <see cref="IEnumExtraSearch"/> COM enumerator.
	/// </summary>
	/// <seealso cref="Tasler.Interop.Com.Extensions.ComEnumeratorExtensions.IComFetcher{IEnumExtraSearch, EXTRASEARCH}" />
	private abstract class FetcherOfExtraSearch : ComEnumeratorExtensions.IComFetcher<IEnumExtraSearch, EXTRASEARCH>
	{
		/// <summary>
		/// Fetches an array of <see cref="EXTRASEARCH"/> from an <see cref="IEnumExtraSearch"/> COM enumeration sequence.
		/// </summary>
		/// <param name="enumerator">The <see cref="IEnumExtraSearch"/> instance.</param>
		/// <param name="elements">The array of elements to be filled by the COM enumerator.</param>
		/// <param name="elementsFetched">The count of elements retrieved.</param>
		/// <returns>
		/// The HRESULT of the fetch (<see cref="IEnumExtraSearch.Next"/>) operation.
		/// <summary>
			/// Fetches up to the provided array's length of EXTRASEARCH items from the specified IEnumExtraSearch into the array.
			/// </summary>
			/// <param name="enumerator">The COM enumerator to read items from.</param>
			/// <param name="elements">The destination array to receive fetched EXTRASEARCH items.</param>
			/// <param name="elementsFetched">The number of items actually written into <paramref name="elements"/>.</param>
			/// <returns>The HRESULT returned by IEnumExtraSearch.Next.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumExtraSearch enumerator, EXTRASEARCH[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);
	}
}