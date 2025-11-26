using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("0000000D-0000-0000-C000-000000000046")]
public partial interface IEnumSTATSTG : IUnknown
{
	/// <summary>Retrieves the next <see cref="STATSTG"/> structures in the enumeration sequence.</summary>
	/// <param name="elementCount">The number of <see cref="STATSTG"/> structures to retrieve.</param>
	/// <param name="elements">An array to receive the retrieved <see cref="STATSTG"/> structures.</param>
	/// <param name="elementsFetched">The actual number of <see cref="STATSTG"/> structures retrieved.</param>
	/// <returns>
	/// HRESULT indicating success or failure. S_FALSE indicates that less that the specified
	/// <paramref name="elementCount"/> elements were retrieved.
	/// <summary>
	/// Retrieves up to <paramref name="elementCount"/> STATSTG structures from the enumeration sequence.
	/// </summary>
	/// <param name="elementCount">The number of STATSTG structures to retrieve.</param>
	/// <param name="elements">An output array that receives the retrieved STATSTG structures. The array is marshaled according to <paramref name="elementCount"/>.</param>
	/// <param name="elementsFetched">The actual number of STATSTG structures returned in <paramref name="elements"/>.</param>
	/// <returns>`S_OK` if exactly <paramref name="elementCount"/> elements were returned, `S_FALSE` if fewer elements were available, or an HRESULT error code on failure.</returns>
	[PreserveSig]
	int Next(int elementCount, [MarshalUsing(CountElementName = nameof(elementCount))][Out] STATSTG[] elements, out int elementsFetched);

	/// <summary>Skips a specified number of <see cref="STATSTG"/> structures in the enumeration sequence.</summary>
	/// <param name="elementCount">The number of <see cref="STATSTG"/> structures to skip.</param>
	/// <returns>
	/// HRESULT indicating success or failure. S_FALSE indicates that less that the specified
	/// <paramref name="elementCount"/> elements were skipped.
	/// <summary>
	/// Advances the enumeration by skipping a specified number of STATSTG elements.
	/// </summary>
	/// <param name="elementCount">The number of elements to skip.</param>
	/// <returns>
	/// An HRESULT indicating the result: `S_OK` if the requested number of elements were skipped, `S_FALSE` if fewer elements were skipped, or an error HRESULT on failure.
	/// </returns>
	[PreserveSig]
	int Skip(int elementCount);

	/// <summary>Resets the enumeration sequence to the beginning.</summary>
	void Reset();

	/// <summary>Clones the current enumeration object.</summary>
	/// <summary>
/// Creates a new enumerator that duplicates the current enumeration state.
/// </summary>
/// <returns>A new <see cref="IEnumSTATSTG"/> instance positioned at the same element as the current enumerator.</returns>
	IEnumSTATSTG Clone();
}