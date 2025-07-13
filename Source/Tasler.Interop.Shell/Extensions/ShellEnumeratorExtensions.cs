using Tasler.Interop.Com.Extensions;

namespace Tasler.Interop.Shell.Extensions;

public static partial class ShellEnumeratorExtensions
{
	/// <summary>
	/// Wraps a COM <see cref="IEnumIDList"/> as an <see cref="IEnumerable{ItemIdList}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumIDList"/> instance.</param>
	/// <returns>An <see cref="IEnumerable{ItemIdList}"/>.</returns>
	public static IEnumerable<ItemIdList> AsEnumerable(this IEnumIDList @this, int blockSize = ComEnumeratorExtensions.DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumIDList, nint, FetcherOfIDList, ItemIdList, FetcherOfIDList>(blockSize);

	/// <summary>
	/// Wraps a COM <see cref="IEnumExtraSearch"/> as an <see cref="IEnumerable{EXTRASEARCH}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumExtraSearch"/> instance.</param>
	/// <returns>An <see cref="IEnumerable{EXTRASEARCH}"/>.</returns>
	public static IEnumerable<EXTRASEARCH> AsEnumerable(this IEnumExtraSearch @this, int blockSize = ComEnumeratorExtensions.DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumExtraSearch, EXTRASEARCH, FetcherOfExtraSearch>(blockSize);
}
