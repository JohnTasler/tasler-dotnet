using Tasler.Interop.Com;

namespace Tasler.Interop.Shell.Extensions;

public static class ShellEnumeratorExtensions
{
	#region Fetch Wrapper Functions

	/// <summary>
	/// A method that serves as the <see cref="FetchFunction{TCollection, TItem}"/> for an
	/// <see cref="IEnumIDList"/> COM enumeration sequence.
	/// </summary>
	/// <param name="enumerator">The <see cref="IEnumIDList"/> instance.</param>
	/// <param name="elements">The elements array to be filled by the COM enumerator.</param>
	/// <param name="elementsFetched">The count of elements retrieved.</param>
	/// <returns>
	/// The HRESULT of the fetch (<see cref="IEnumIDList.Next(int, ItemIdList[], out int)"/>) operation.
	/// </returns>
	public static int FetchIDList(IEnumIDList enumerator, nint[] elements, out int elementsFetched)
		=> enumerator.Next(elements.Length, elements, out elementsFetched);

	/// <summary>
	/// A method that serves as the <see cref="FetchFunction{TCollection, TItem}"/> for an
	/// <see cref="IEnumIDList"/> COM enumeration sequence.
	/// </summary>
	/// <param name="enumerator">The <see cref="IEnumExtraSearch"/> instance.</param>
	/// <param name="elements">The elements array to be filled by the COM enumerator.</param>
	/// <param name="elementsFetched">The count of elements retrieved.</param>
	/// <returns>
	/// The HRESULT of the fetch (<see cref="IEnumExtraSearch.Next(int, EXTRASEARCH[], out int)"/>) operation.
	/// </returns>
	public static int FetchExtraSearch(IEnumExtraSearch enumerator, EXTRASEARCH[] elements, out int elementsFetched)
		=> enumerator.Next(elements.Length, elements, out elementsFetched);

	#endregion Fetch Wrapper Functions

	#region AsEnumerable Extension Methods

	/// <summary>
	/// Wraps a COM <see cref="IEnumIDList"/> to an <see cref="IEnumerable{ItemIdList}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumIDList"/> instance.</param>
	/// <returns>An <see cref="IEnumerable{ItemIdList}"/>.</returns>
	public static IEnumerable<ItemIdList> AsEnumerable(this IEnumIDList @this)
		=> @this.AsEnumerable<IEnumIDList, nint>(FetchIDList).Select(n => new ItemIdList { Handle = n });

	/// <summary>
	/// Wraps a COM <see cref="IEnumExtraSearch"/> to an <see cref="IEnumerable{EXTRASEARCH}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumExtraSearch"/> instance.</param>
	/// <returns>An <see cref="IEnumerable{EXTRASEARCH}"/>.</returns>
	public static IEnumerable<EXTRASEARCH> AsEnumerable(this IEnumExtraSearch @this)
		=> @this.AsEnumerable<IEnumExtraSearch, EXTRASEARCH>(FetchExtraSearch);

	#endregion AsEnumerable Extension Methods
}
