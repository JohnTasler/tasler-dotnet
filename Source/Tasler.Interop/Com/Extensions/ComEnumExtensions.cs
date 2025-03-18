using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Tasler.Interop.Com;

public static class ComEnumExtensions
{
	public const int DefaultEnumerationBlockSize = 16;

	public delegate int FetchFunction<TCollection, TItem>(TCollection enumerator, TItem[] items, out int fetched);

	public static int FetchFORMATETC(IEnumFORMATETC enumerator, FORMATETC[] items, out int fetchedCount)
	{
		// Fetch the next block of items
		var fetched = new int[1];
		var hr = enumerator.Next(items.Length, items, fetched);
		fetchedCount = fetched[0];
		return hr;
	}

	public static int FetchIMoniker(IEnumMoniker enumerator, IMoniker[] items, out int fetchedCount)
	{
		unsafe
		{
			var fetched = stackalloc int[1];
			var hr = enumerator.Next(items.Length, items, new IntPtr(fetched));
			fetchedCount = fetched[0];
			return hr;
		}
	}

	public static IEnumerator<TItem> AsEnumerator<TCollection, TItem>(
		this TCollection @this,
		FetchFunction<TCollection, TItem> fetchFunction,
		int blockSize = DefaultEnumerationBlockSize)
	{
		// Allocate a block of items
		var items = new TItem[blockSize];
		int hr;

		do
		{
			// Fetch the next block of items
			hr = fetchFunction(@this, items, out int fetched);

			if (hr == 0 || hr == 1)
			{
				for (int index = 0; index < fetched; ++index)
				{
					yield return items[index];
				}
			}
			else if (hr < 0)
			{
				throw Marshal.GetExceptionForHR(hr)!;
			}

		} while (hr == 0);
	}
}
