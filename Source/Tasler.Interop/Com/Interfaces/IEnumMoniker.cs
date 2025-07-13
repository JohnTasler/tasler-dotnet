using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("00000102-0000-0000-C000-000000000046")]
public partial interface IEnumMoniker : IUnknown
{
	[PreserveSig]
	int Next(int celt, [MarshalUsing(CountElementName = "celt")] [Out] IMoniker[] rgelt, out int pceltFetched);

	[PreserveSig]
	int Skip(int celt);

	void Reset();

	IEnumMoniker Clone();
}
