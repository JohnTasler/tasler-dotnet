using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Shell;

[GeneratedComInterface]
[Guid("1AC3D9F0-175C-11d1-95BE-00609797EA4F")]
public partial interface IPersistFolder2 : IPersistFolder
{
	void GetCurFolder(out ItemIdList ppidl);
}
