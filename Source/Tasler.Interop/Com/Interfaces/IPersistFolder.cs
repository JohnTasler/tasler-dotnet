using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

namespace Tasler.Interop.Shell;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("000214EA-0000-0000-C000-000000000046")]
[SuppressMessage("ComInterfaceGenerator", "SYSLIB1230:Specifying 'GeneratedComInterfaceAttribute' on an interface that has a base interface defined in another assembly is not supported", Justification = "Allowed")]
public partial interface IPersistFolder : IPersist
{
	/// <summary>
	/// Initializes the folder object with the specified ITEMIDLIST (PIDL).
	/// </summary>
	/// <param name="pidl">A pointer to an ITEMIDLIST (PIDL) that identifies the folder to initialize.</param>
	void Initialize(nint pidl);
}
