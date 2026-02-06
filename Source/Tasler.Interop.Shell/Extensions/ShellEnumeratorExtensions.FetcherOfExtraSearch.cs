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
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumExtraSearch enumerator, EXTRASEARCH[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);
	}
}
