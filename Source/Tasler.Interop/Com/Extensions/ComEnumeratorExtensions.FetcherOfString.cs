using System.Runtime.CompilerServices;

namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	public abstract class FetcherOfString : IComFetcher<IEnumString, nint>, IComFetchConverter<nint, string>
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumString enumerator, nint[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string Convert(nint element)
		{
			using var result = new SafeCoTaskMemString{ Handle = element };
			return result.Value;
		}
	}
}
