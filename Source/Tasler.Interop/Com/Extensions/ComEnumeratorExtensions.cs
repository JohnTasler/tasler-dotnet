using System.Runtime.InteropServices.ComTypes;

namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	/// <summary>
	/// The default enumeration block size.
	/// </summary>
	public const int DefaultEnumerationBlockSize = 16;

	/// <summary>
	/// Wraps a COM <see cref="IEnumFORMATETC"/> to an <see cref="IEnumerable{FORMATETC}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumFORMATETC"/> instance.</param>
	/// <returns>An <see cref="IEnumerable{FORMATETC}"/>.</returns>
	public static IEnumerable<FORMATETC> AsEnumerable(this IEnumFORMATETC @this, int blockSize = DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumFORMATETC, FORMATETC, FetcherOfFORMATETC>(blockSize);

	/// <summary>
	/// Wraps a COM <see cref="IEnumMoniker"/> to an <see cref="IEnumerable{IMoniker}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumMoniker"/> instance.</param>
	/// <returns>An <see cref="IEnumerable{IMoniker}"/>.</returns>
	public static IEnumerable<IMoniker?> AsEnumerable(this IEnumMoniker @this, int blockSize = DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumMoniker, IMoniker, FetcherOfIMoniker>(blockSize);

	/// <summary>
	/// Wraps a COM <see cref="IEnumSTATSTG"/> to an <see cref="IEnumerable{STATSTG}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumSTATSTG"/> instance.</param>
	/// <returns>An <see cref="IEnumerable{STATSTG}"/>.</returns>
	public static IEnumerable<STATSTG> AsEnumerable(this IEnumSTATSTG @this, int blockSize = DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumSTATSTG, STATSTG, FetcherOfSTATSTG>(blockSize);

	/// <summary>
	/// Wraps a COM <see cref="IEnumString"/> to an <see cref="IEnumerable{String}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumString"/> instance.</param>
	/// <returns>An <see cref="IEnumerable{String}"/>.</returns>
	public static IEnumerable<string> AsEnumerable(this IEnumString @this, int blockSize = DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumString, nint, FetcherOfString, string, FetcherOfString>(blockSize);
}
