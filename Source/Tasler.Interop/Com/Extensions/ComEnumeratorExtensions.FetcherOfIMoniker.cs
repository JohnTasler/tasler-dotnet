using System.Runtime.CompilerServices;

namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	public abstract class FetcherOfIMoniker : IComFetcher<IEnumMoniker, IMoniker>
	{
		/// <summary>
		/// Fetches up to <paramref name="elements"/>.Length IMoniker instances from the specified enumerator into the provided buffer.
		/// </summary>
		/// <param name="enumerator">The source IEnumMoniker to read from.</param>
		/// <param name="elements">Preallocated buffer that receives the fetched IMoniker instances.</param>
		/// <param name="elementsFetched">The number of monikers actually written into <paramref name="elements"/>.</param>
		/// <returns>The HRESULT returned by IEnumMoniker.Next (e.g. 0 (S_OK) if the requested number was fetched, S_FALSE if fewer were fetched, or an error code).</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumMoniker enumerator, IMoniker[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);
	}
}
