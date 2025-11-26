using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	public abstract class FetcherOfFORMATETC : IComFetcher<IEnumFORMATETC, FORMATETC>
	{
		/// <summary>
			/// Retrieves FORMATETC entries from the COM enumerator into the supplied buffer.
			/// </summary>
			/// <param name="enumerator">The COM enumerator to fetch from.</param>
			/// <param name="elements">Preallocated buffer to receive fetched FORMATETC structures; its length is the requested count.</param>
			/// <param name="elementsFetched">When the method returns, the number of elements actually written into <paramref name="elements"/>.</param>
			/// <returns>The result code returned by the enumerator's Next call.</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumFORMATETC enumerator, FORMATETC[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);
	}
}