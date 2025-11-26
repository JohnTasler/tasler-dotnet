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
	/// <summary>
		/// Wraps an IEnumFORMATETC COM enumerator as an IEnumerable of FORMATETC.
		/// </summary>
		/// <param name="blockSize">Maximum number of FORMATETC items retrieved from the COM enumerator per enumeration block.</param>
		/// <returns>An <see cref="IEnumerable{FORMATETC}"/> that enumerates FORMATETC values from the COM enumerator.</returns>
	public static IEnumerable<FORMATETC> AsEnumerable(this IEnumFORMATETC @this, int blockSize = DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumFORMATETC, FORMATETC, FetcherOfFORMATETC>(blockSize);

	/// <summary>
	/// Wraps a COM <see cref="IEnumMoniker"/> to an <see cref="IEnumerable{IMoniker}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumMoniker"/> instance.</param>
	/// <summary>
		/// Wraps a COM <see cref="IEnumMoniker"/> enumerator as an <see cref="IEnumerable{T}"/> of <see cref="IMoniker"/> values.
		/// </summary>
		/// <param name="blockSize">Maximum number of items to request from the COM enumerator at a time.</param>
		/// <returns>An enumerable sequence of <see cref="IMoniker"/> instances (elements may be null) produced by the COM enumerator.</returns>
	public static IEnumerable<IMoniker?> AsEnumerable(this IEnumMoniker @this, int blockSize = DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumMoniker, IMoniker, FetcherOfIMoniker>(blockSize);

	/// <summary>
	/// Wraps a COM <see cref="IEnumSTATSTG"/> to an <see cref="IEnumerable{STATSTG}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumSTATSTG"/> instance.</param>
	/// <summary>
		/// Wraps the COM IEnumSTATSTG enumerator as an IEnumerable of STATSTG.
		/// </summary>
		/// <param name="blockSize">The number of items to request from the COM enumerator per batch.</param>
		/// <returns>An enumerable that yields STATSTG structures from the COM enumerator.</returns>
	public static IEnumerable<STATSTG> AsEnumerable(this IEnumSTATSTG @this, int blockSize = DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumSTATSTG, STATSTG, FetcherOfSTATSTG>(blockSize);

	/// <summary>
	/// Wraps a COM <see cref="IEnumString"/> to an <see cref="IEnumerable{String}"/>.
	/// </summary>
	/// <param name="this">The <see cref="IEnumString"/> instance.</param>
	/// <summary>
		/// Wraps an <see cref="IEnumString"/> COM enumerator as an <see cref="IEnumerable{String}"/> sequence.
		/// </summary>
		/// <param name="blockSize">Maximum number of elements requested from the COM enumerator per fetch operation; must be greater than zero.</param>
		/// <returns>An <see cref="IEnumerable{String}"/> that yields each string produced by the COM enumerator until enumeration is complete.</returns>
	public static IEnumerable<string> AsEnumerable(this IEnumString @this, int blockSize = DefaultEnumerationBlockSize)
		=> @this.AsEnumerable<IEnumString, nint, FetcherOfString, string, FetcherOfString>(blockSize);
}