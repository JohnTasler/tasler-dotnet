using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Shell;

//[System.Diagnostics.CodeAnalysis.SuppressMessage("ComInterfaceGenerator", "SYSLIB1051:Specified type is not supported by source-generated COM", Justification = "It works")]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("000214F2-0000-0000-C000-000000000046")]
public partial interface IEnumIDList
{
	/// <param name="elementCount"></param>
	/// <param name="elements"></param>
	/// <summary>
	/// Retrieves up to a specified number of item identifier lists from the enumeration.
	/// </summary>
	/// <param name="elementCount">The maximum number of elements to retrieve.</param>
	/// <param name="elements">An array that receives pointers to the retrieved item identifier lists; its length must be at least <paramref name="elementCount"/>.</param>
	/// <param name="elementsFetched">The number of elements actually retrieved and written to <paramref name="elements"/>.</param>
	/// <returns>
	/// An HRESULT-like status code: `S_OK` if the requested number of elements was returned, `S_FALSE` if fewer elements were returned (end of enumeration), or an error code on failure.
	/// </returns>
	[PreserveSig]
	int Next(int elementCount, [MarshalUsing(CountElementName = nameof(elementCount))] [Out] nint[] elements, out int elementsFetched);

	/// <summary>
	/// Advances the enumeration position by the specified number of elements.
	/// </summary>
	/// <param name="elementsToSkip">The number of elements to skip in the enumeration.</param>
	/// <returns>An integer status code: `0` (S_OK) if the requested number of elements were skipped, or a non-zero error code otherwise.</returns>
	[PreserveSig]
	int Skip(int elementsToSkip);

	/// <summary>
/// Resets the enumerator to the beginning of the sequence so subsequent calls begin from the first element.
/// </summary>
void Reset();

	/// <summary>
/// Creates a copy of the enumerator preserving its current position.
/// </summary>
/// <returns>An IEnumIDList instance positioned at the same location as the current enumerator.</returns>
IEnumIDList Clone();
}