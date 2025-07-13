using System.Runtime.CompilerServices;

namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	public abstract class FetcherOfSTATSTG : IComFetcher<IEnumSTATSTG, STATSTG>
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumSTATSTG enumerator, STATSTG[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);
	}
}
