using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;

namespace Tasler.Interop.Com.Extensions;

public static partial class ComEnumeratorExtensions
{
	public abstract class FetcherOfFORMATETC : IComFetcher<IEnumFORMATETC, FORMATETC>
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Fetch(IEnumFORMATETC enumerator, FORMATETC[] elements, out int elementsFetched)
			=> enumerator.Next(elements.Length, elements, out elementsFetched);
	}
}
