using Tasler.Interop.Com.Extensions;

namespace Tasler.Interop.Shell.Extensions;

public static partial class ShellEnumeratorExtensions
{
	/// <summary>
	/// Wraps an <see cref="IEnumIDList"/> COM enumerator as an <see cref="IEnumerable{ItemIdList}"/>.
	/// </summary>
	/// <param name="this">The COM <see cref="IEnumIDList"/> to enumerate.</param>
	/// <param name="blockSize">Maximum number of items fetched from the COM enumerator per batch; defaults to <see cref="ComEnumeratorExtensions.DefaultEnumerationBlockSize"/>.</param>
	/// <returns>An enumerable sequence of <see cref="ItemIdList"/> instances from the provided COM enumerator.</returns>
	public static IEnumerable<ItemIdList> AsEnumerable(this IEnumIDList @this, int blockSize = ComEnumeratorExtensions.DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumIDList, nint, FetcherOfIDList, ItemIdList, FetcherOfIDList>(blockSize);

	/// <summary>
	/// Wraps an <see cref="IEnumExtraSearch"/> COM enumerator as a sequence of <see cref="EXTRASEARCH"/> items.
	/// </summary>
	/// <param name="this">The <see cref="IEnumExtraSearch"/> instance to enumerate.</param>
	/// <param name="blockSize">Maximum number of items to fetch per underlying COM enumeration call.</param>
	/// <returns>A sequence of <see cref="EXTRASEARCH"/> structures retrieved from the COM enumerator.</returns>
	public static IEnumerable<EXTRASEARCH> AsEnumerable(this IEnumExtraSearch @this, int blockSize = ComEnumeratorExtensions.DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumExtraSearch, EXTRASEARCH, FetcherOfExtraSearch>(blockSize);
}
