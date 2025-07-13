using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000000E-0000-0000-C000-000000000046")]
public partial interface IBindCtx : IUnknown
{
	void RegisterObjectBound(nint unknown);

	void RevokeObjectBound(nint unknown);

	void ReleaseBoundObjects();

	void SetBindOptions(ref BIND_OPTS pbindopts);

	void GetBindOptions(ref BIND_OPTS pbindopts);

	IRunningObjectTable GetRunningObjectTable();

	void RegisterObjectParam(string pszKey, nint unknown);

	nint GetObjectParam(string pszKey);

	IEnumString EnumObjectParam();

	void RevokeObjectParam(string pszKey);
}
