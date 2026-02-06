using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("00000101-0000-0000-C000-000000000046")]
public partial interface IEnumString : IUnknown
{
	/// <summary>
	/// Retrieves up to <paramref name="elementCount"/> string pointers from the enumeration into <paramref name="elements"/>.
	/// </summary>
	/// <param name="elementCount">The maximum number of string pointers to retrieve.</param>
	/// <param name="elements">An output array that receives the retrieved string pointers; the array must have space for at least <paramref name="elementCount"/> entries.</param>
	/// <param name="elementsFetched">The actual number of string pointers written into <paramref name="elements"/>.</param>
	/// <returns>
	/// An HRESULT indicating the result: `S_OK` if exactly <paramref name="elementCount"/> elements were retrieved, `S_FALSE` if fewer elements were retrieved, or an error code on failure.
	/// </returns>
	[PreserveSig]
	int Next(int elementCount, [MarshalUsing(CountElementName = nameof(elementCount))] [Out] nint[] elements, out int elementsFetched);

	/// <summary>
	/// Advances the enumeration by the specified number of elements.
	/// </summary>
	/// <param name="elementCount">The number of elements to skip.</param>
	/// <returns>An HRESULT indicating the result: `S_OK` if the requested number of elements were skipped, `S_FALSE` if fewer elements were skipped, or a failure code on error.</returns>
	[PreserveSig]
	int Skip(uint elementCount);

	/// <summary>
	/// Resets the enumeration to its initial position so subsequent retrievals start from the first element.
	/// </summary>
	void Reset();

	/// <summary>
	/// Creates a new enumerator initialized to the same position as the current enumerator.
	/// </summary>
	/// <returns>An <see cref="IEnumString"/> instance that enumerates the same sequence starting at the current position.</returns>
	IEnumString Clone();
}
