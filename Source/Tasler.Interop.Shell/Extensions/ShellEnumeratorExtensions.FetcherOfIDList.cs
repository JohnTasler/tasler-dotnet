using System.Runtime.CompilerServices;
using Tasler.Interop.Com.Extensions;

namespace Tasler.Interop.Shell.Extensions;

public static partial class ShellEnumeratorExtensions
{
	/// <summary>
	/// Fetches and converts items from an <see cref="IEnumIDList"/> COM enumerator.
	/// </summary>
	/// <seealso cref="Tasler.Interop.Com.Extensions.ComEnumeratorExtensions.IComFetcher{IEnumIDList, nint}" />
	/// <seealso cref="Tasler.Interop.Com.Extensions.ComEnumeratorExtensions.IComFetchConverter{nint, ItemIdList}" />
	private abstract class FetcherOfIDList
		: ComEnumeratorExtensions.IComFetcher<IEnumIDList, nint>
		, ComEnumeratorExtensions.IComFetchConverter<nint, ItemIdList>
	{
		/// <summary>
		/// Fetches an array of <see cref="nint"/> from an <see cref="IEnumIDList"/> COM enumeration sequence.
		/// </summary>
		/// <param name="enumerator">The <see cref="IEnumIDList"/> instance.</param>
		/// <param name="elements">The array of elements to be filled by the COM enumerator.</param>
		/// <param name="elementsFetched">The count of elements retrieved.</param>
		/// <returns>
		/// The HRESULT of the fetch (<see cref="IEnumIDList.Next"/>) operation.
		/// </returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumIDList enumerator, nint[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);

		/// <summary>
		/// Converts the specified element from an <see cref="nint"/> COM type to an <see cref="ItemIdList"/>.
		/// </summary>
		/// <param name="element">The element to convert.</param>
		/// <returns>The converted element.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ItemIdList Convert(nint element) => new ItemIdList { Handle = element };
	}
}
