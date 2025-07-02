using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("0000000E-0000-0000-C000-000000000046")]
public partial interface IBindCtx
{
	void RegisterObjectBound([MarshalAs(UnmanagedType.Interface)] object unknown);

	void RevokeObjectBound([MarshalAs(UnmanagedType.Interface)] object unknown);

	void ReleaseBoundObjects();

	void SetBindOptions(ref BIND_OPTS pbindopts);

	void GetBindOptions(ref BIND_OPTS pbindopts);

	IRunningObjectTable GetRunningObjectTable();

	void RegisterObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey, [MarshalAs(UnmanagedType.Interface)] object unknown);

	[return: MarshalAs(UnmanagedType.Interface)]
	object GetObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey);

	IEnumString EnumObjectParam();

	[PreserveSig]
	int RevokeObjectParam([MarshalAs(UnmanagedType.LPWStr)] string pszKey);
}
