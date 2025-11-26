using System.Runtime.CompilerServices;

namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	public abstract class FetcherOfString : IComFetcher<IEnumString, nint>, IComFetchConverter<nint, string>
	{
		/// <summary>
			/// Retrieves a batch of native string pointers from the provided COM string enumerator into the supplied buffer.
			/// </summary>
			/// <param name="enumerator">The COM enumerator to read from.</param>
			/// <param name="elements">Preallocated buffer that will receive native string handles (nint) for each fetched element.</param>
			/// <param name="elementsFetched">When the call returns, contains the number of elements actually written into <paramref name="elements"/>.</param>
			/// <returns>The COM result code returned by the enumerator's Next call (e.g. `0` for S_OK when the requested count was fetched, `1` for S_FALSE if fewer elements were available).</returns>
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumString enumerator, nint[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);

		/// <summary>
		/// Marshals a native CoTaskMem-allocated string pointer to a managed string.
		/// </summary>
		/// <param name="element">A native pointer to a CoTaskMem-allocated, null-terminated string.</param>
		/// <returns>The managed string represented by the native pointer, or <c>null</c> if the pointer is zero.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string Convert(nint element)
		{
			using var result = new SafeCoTaskMemString{ Handle = element };
			return result.Value;
		}
	}
}