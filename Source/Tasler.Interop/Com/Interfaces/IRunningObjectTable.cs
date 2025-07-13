using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("00000010-0000-0000-C000-000000000046")]
public partial interface IRunningObjectTable : IUnknown
{
	[PreserveSig]
	int Register(int grfFlags, nint punkObject, IMoniker pmkObjectName, out uint cookie);

	void Revoke(uint cookie);

	[PreserveSig]
	int IsRunning(IMoniker pmkObjectName);

	[PreserveSig]
	int GetObject(IMoniker pmkObjectName, out nint ppunkObject);

	void NoteChangeTime(int dwRegister, out ulong pfiletime);

	[PreserveSig]
	int GetTimeOfLastChange(IMoniker pmkObjectName, out ulong pfiletime);

	IEnumMoniker EnumRunning();
}
