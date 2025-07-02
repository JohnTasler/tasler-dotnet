using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("0000000D-0000-0000-C000-000000000046")]
public partial interface IEnumSTATSTG
{
	/// <summary>Retrieves the next <see cref="STATSTG"/> structures in the enumeration sequence.</summary>
	/// <param name="elementCount">The number of <see cref="STATSTG"/> structures to retrieve.</param>
	/// <param name="elements">An array to receive the retrieved <see cref="STATSTG"/> structures.</param>
	/// <param name="elementsFetched">The actual number of <see cref="STATSTG"/> structures retrieved.</param>
	/// <returns>
	/// HRESULT indicating success or failure. S_FALSE indicates that less that the specified
	/// <paramref name="elementCount"/> elements were retrieved.
	/// </returns>
	[PreserveSig]
	int Next(int elementCount, [MarshalUsing(CountElementName = nameof(elementCount))][Out] STATSTG[] elements, out int elementsFetched);

	/// <summary>Skips a specified number of <see cref="STATSTG"/> structures in the enumeration sequence.</summary>
	/// <param name="elementCount">The number of <see cref="STATSTG"/> structures to skip.</param>
	/// <returns>
	/// HRESULT indicating success or failure. S_FALSE indicates that less that the specified
	/// <paramref name="elementCount"/> elements were skipped.
	/// </returns>
	[PreserveSig]
	int Skip(int elementCount);

	/// <summary>Resets the enumeration sequence to the beginning.</summary>
	void Reset();

	/// <summary>Clones the current enumeration object.</summary>
	/// <returns>A new <see cref="IEnumSTATSTG"/> object that is a clone of the current one.</returns>
	IEnumSTATSTG Clone();
}
