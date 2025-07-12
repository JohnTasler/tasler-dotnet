using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000010C-0000-0000-C000-000000000046")]
public partial interface IPersist
{
	Guid GetClassID();
}
