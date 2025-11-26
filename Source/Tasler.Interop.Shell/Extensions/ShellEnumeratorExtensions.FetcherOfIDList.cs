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
		/// <summary>
			/// Invokes IEnumIDList.Next to fetch item identifier list handles into the provided array.
			/// </summary>
			/// <param name="enumerator">The COM IEnumIDList enumerator to read from.</param>
			/// <param name="elements">The array to be filled with fetched nint handles; its length determines how many are requested.</param>
			/// <param name="elementsFetched">Outputs the number of handles actually retrieved.</param>
			/// <returns>The HRESULT returned by the underlying IEnumIDList.Next call.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumIDList enumerator, nint[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);

		/// <summary>
		/// Converts the specified element from an <see cref="nint"/> COM type to an <see cref="ItemIdList"/>.
		/// </summary>
		/// <param name="element">The element to convert.</param>
		/// <summary>
		/// Creates an ItemIdList that wraps the provided native item identifier.
		/// </summary>
		/// <param name="element">Native item identifier handle (ITEMIDLIST pointer) to wrap.</param>
		/// <returns>An ItemIdList whose Handle is set to the provided element.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ItemIdList Convert(nint element) => new ItemIdList { Handle = element };
	}
}