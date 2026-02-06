using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using FORMATETC = System.Runtime.InteropServices.ComTypes.FORMATETC;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("00000103-0000-0000-C000-000000000046")]
public partial interface IEnumFORMATETC : IUnknown
{
	/// <summary>Retrieves the next <see cref="FORMATETC"/> structures in the enumeration sequence.</summary>
	/// <param name="elementCount">The number of <see cref="FORMATETC"/> structures to retrieve.</param>
	/// <param name="elements">An array to receive the retrieved <see cref="FORMATETC"/> structures.</param>
	/// <param name="elementsFetched">The actual number of <see cref="FORMATETC"/> structures retrieved.</param>
	/// <returns>
	/// HRESULT indicating success or failure. S_FALSE indicates that less that the specified
	/// <paramref name="elementCount"/> elements were retrieved.
	/// <summary>
	/// Retrieves up to a specified number of FORMATETC structures from the enumeration sequence.
	/// </summary>
	/// <param name="elementCount">The maximum number of FORMATETC structures to retrieve.</param>
	/// <param name="elements">An output array that receives the retrieved FORMATETC structures; the array must have space for at least <paramref name="elementCount"/> entries.</param>
	/// <param name="elementsFetched">Outputs the actual number of FORMATETC structures written into <paramref name="elements"/>.</param>
	/// <returns>
	/// An HRESULT: S_OK if <paramref name="elementCount"/> structures were retrieved, S_FALSE if fewer structures were retrieved, or an error code on failure.
	/// </returns>
	[PreserveSig]
	int Next(int elementCount, [MarshalUsing(CountElementName = nameof(elementCount))][Out] FORMATETC[] elements, out int elementsFetched);

	/// <summary>
	/// Skips the specified number of <see cref="FORMATETC"/> structures in the enumeration sequence.
	/// </summary>
	/// <param name="elementCount">The number of elements to skip.</param>
	/// <returns>An HRESULT: `S_OK` if the requested number of elements were skipped, `S_FALSE` if fewer were skipped, or an error code on failure.</returns>
	[PreserveSig]
	int Skip(int elementCount);

	/// <summary>Resets the enumeration sequence to the beginning.</summary>
	void Reset();

	/// <summary>
	/// Clones the current enumeration object, by creating a new enumerator that represents the same position in the enumeration as the current object.
	/// </summary>
	/// <returns>An <see cref="IEnumFORMATETC"/> instance that is a clone of the current enumerator.</returns>
	IEnumFORMATETC Clone();
}
