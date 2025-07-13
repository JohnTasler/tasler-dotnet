using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("00000101-0000-0000-C000-000000000046")]
public partial interface IEnumString : IUnknown
{
	/// <summary>Retrieves the next <see cref="nint"/> string pointers in the enumeration sequence.</summary>
	/// <param name="elementCount">The number of <see cref="nint"/> string pointers to retrieve.</param>
	/// <param name="elements">An array to receive the retrieved <see cref="nint"/> string pointers.</param>
	/// <param name="elementsFetched">The actual number of <see cref="nint"/> string pointers retrieved.</param>
	/// <returns>
	/// HRESULT indicating success or failure. S_FALSE indicates that less that the specified
	/// <paramref name="elementCount"/> elements were retrieved.
	/// </returns>
	[PreserveSig]
	int Next(int elementCount, [MarshalUsing(CountElementName = nameof(elementCount))] [Out] nint[] elements, out int elementsFetched);

	[PreserveSig]
	int Skip(uint elementCount);

	void Reset();

	IEnumString Clone();
}
