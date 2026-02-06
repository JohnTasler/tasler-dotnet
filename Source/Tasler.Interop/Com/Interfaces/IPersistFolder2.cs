using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Shell;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("1AC3D9F0-175C-11d1-95BE-00609797EA4F")]
public partial interface IPersistFolder2 : IPersistFolder
{
	/// <summary>
	/// Retrieves the PIDL (pointer to an item identifier list) that identifies the current folder.
	/// </summary>
	/// <param name="ppidl">Receives a pointer to the ITEMIDLIST for the current folder. The caller is responsible for freeing the returned PIDL when it is no longer needed.</param>
	void GetCurFolder(out nint ppidl);
}
