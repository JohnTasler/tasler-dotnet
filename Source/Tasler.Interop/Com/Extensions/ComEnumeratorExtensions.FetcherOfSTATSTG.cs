using System.Runtime.CompilerServices;

namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	public abstract class FetcherOfSTATSTG : IComFetcher<IEnumSTATSTG, STATSTG>
	{
		/// <summary>
			/// Retrieves STATSTG structures from the specified COM enumerator into the provided array.
			/// </summary>
			/// <param name="enumerator">The COM enumerator to fetch from.</param>
			/// <param name="elements">Array that receives fetched STATSTG structures; its length determines the maximum number fetched.</param>
			/// <param name="elementsFetched">When this method returns, contains the number of structures written to <paramref name="elements"/>.</param>
			/// <returns>The HRESULT returned by the enumerator's Next method (for example, S_OK if the requested number of elements were fetched, S_FALSE if fewer were available).</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumSTATSTG enumerator, STATSTG[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);
	}
}