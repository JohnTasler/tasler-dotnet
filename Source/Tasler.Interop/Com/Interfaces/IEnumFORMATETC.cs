using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using FORMATETC = System.Runtime.InteropServices.ComTypes.FORMATETC;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("00000103-0000-0000-C000-000000000046")]
public partial interface IEnumFORMATETC
{
	/// <summary>Retrieves the next <see cref="FORMATETC"/> structures in the enumeration sequence.</summary>
	/// <param name="elementCount">The number of <see cref="FORMATETC"/> structures to retrieve.</param>
	/// <param name="elements">An array to receive the retrieved <see cref="FORMATETC"/> structures.</param>
	/// <param name="elementsFetched">The actual number of <see cref="FORMATETC"/> structures retrieved.</param>
	/// <returns>
	/// HRESULT indicating success or failure. S_FALSE indicates that less that the specified
	/// <paramref name="elementCount"/> elements were retrieved.
	/// </returns>
	[PreserveSig]
	int Next(int elementCount, [MarshalUsing(CountElementName = nameof(elementCount))][Out] FORMATETC[] elements, out int elementsFetched);

	/// <summary>Skips a specified number of <see cref="FORMATETC"/> structures in the enumeration sequence.</summary>
	/// <param name="elementCount">The number of <see cref="FORMATETC"/> structures to skip.</param>
	/// <returns>
	/// HRESULT indicating success or failure. S_FALSE indicates that less that the specified
	/// <paramref name="elementCount"/> elements were skipped.
	/// </returns>
	[PreserveSig]
	int Skip(int elementCount);

	/// <summary>Resets the enumeration sequence to the beginning.</summary>
	void Reset();

	/// <summary>Clones the current enumeration object.</summary>
	/// <returns>A new <see cref="IEnumFORMATETC"/> object that is a clone of the current one.</returns>
	IEnumFORMATETC Clone();
}
