using System.Runtime.CompilerServices;

namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	public abstract class FetcherOfIMoniker : IComFetcher<IEnumMoniker, IMoniker>
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumMoniker enumerator, IMoniker[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);
	}
}
