using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Shell;

[System.Diagnostics.CodeAnalysis.SuppressMessage("ComInterfaceGenerator", "SYSLIB1051:Specified type is not supported by source-generated COM", Justification = "It works")]
[GeneratedComInterface]
[Guid("000214F2-0000-0000-C000-000000000046")]
public partial interface IEnumIDList
{
	/// <param name="elementCount"></param>
	/// <param name="elements"></param>
	/// <param name="elementsFetched"></param>
	[PreserveSig]
	int Next(int elementCount, [MarshalUsing(CountElementName = nameof(elementCount))] [Out] ItemIdList[] elements, out int elementsFetched);

	/// <param name="elementsToSkip"></param>
	[PreserveSig]
	int Skip(int elementsToSkip);

	void Reset();

	IEnumIDList Clone();
}
