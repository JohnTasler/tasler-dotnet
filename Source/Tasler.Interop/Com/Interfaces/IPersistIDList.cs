using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

namespace Tasler.Interop.Shell;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("1079ACFC-29BD-11D3-8E0D-00C04F6837D5")]
[SuppressMessage("ComInterfaceGenerator", "SYSLIB1230:Specifying 'GeneratedComInterfaceAttribute' on an interface that has a base interface defined in another assembly is not supported", Justification = "Allowed")]
public partial interface IPersistIDList : IPersist
{
	void SetIDList(nint pidl);

	void GetIDList(out nint ppidl);
}
