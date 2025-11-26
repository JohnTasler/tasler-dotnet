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
	/// <summary>
/// Sets the object's pointer to an item identifier list (PIDL).
/// </summary>
/// <param name="pidl">A native pointer to an item ID list (PIDL).</param>
void SetIDList(nint pidl);

	/// <summary>
/// Retrieves the pointer to the item's ID list (PIDL).
/// </summary>
/// <param name="ppidl">When this method returns, contains a native pointer to the item's PIDL.</param>
void GetIDList(out nint ppidl);
}