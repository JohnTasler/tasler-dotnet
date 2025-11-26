using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("00000102-0000-0000-C000-000000000046")]
public partial interface IEnumMoniker : IUnknown
{
	/// <summary>
	/// Retrieves up to <paramref name="celt"/> monikers from the current position in the enumeration.
	/// </summary>
	/// <param name="celt">The maximum number of monikers to retrieve.</param>
	/// <param name="rgelt">An array that receives the retrieved monikers; the array must have length at least <paramref name="celt"/>.</param>
	/// <param name="pceltFetched">Receives the actual number of monikers returned when fewer than <paramref name="celt"/> are retrieved (otherwise receives <paramref name="celt"/>).</param>
	/// <returns>An HRESULT: `S_OK` if the requested number of monikers were returned; `S_FALSE` if fewer were returned; otherwise a failure code.</returns>
	[PreserveSig]
	int Next(int celt, [MarshalUsing(CountElementName = "celt")] [Out] IMoniker[] rgelt, out int pceltFetched);

	/// <summary>
	/// Advances the enumerator by the specified number of monikers.
	/// </summary>
	/// <param name="celt">The number of monikers to skip.</param>
	/// <returns>An HRESULT: S_OK if the specified number of elements were skipped, S_FALSE if fewer elements were skipped, or an error code on failure.</returns>
	[PreserveSig]
	int Skip(int celt);

	/// <summary>
/// Resets the enumerator to the beginning of the moniker sequence.
/// </summary>
void Reset();

	/// <summary>
/// Creates a new enumerator positioned at the same place in the enumeration.
/// </summary>
/// <returns>A new <see cref="IEnumMoniker"/> initialized to the same enumeration state as the current enumerator.</returns>
IEnumMoniker Clone();
}