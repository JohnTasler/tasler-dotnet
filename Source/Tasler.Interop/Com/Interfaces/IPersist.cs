using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000010C-0000-0000-C000-000000000046")]
public partial interface IPersist : IUnknown
{
	/// <summary>
	/// Retrieves the class identifier (CLSID) of the object.
	/// </summary>
	/// <returns>The class identifier (CLSID) as a <see cref="Guid"/>.</returns>
	Guid GetClassID();
}
