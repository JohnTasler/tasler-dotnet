using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Kernel;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("00000010-0000-0000-C000-000000000046")]
public partial interface IRunningObjectTable
{
	int Register(int grfFlags, nint punkObject, IMoniker pmkObjectName);

	void Revoke(int dwRegister);

	int IsRunning(IMoniker pmkObjectName);

	int GetObject(IMoniker pmkObjectName, out nint ppunkObject);

	void NoteChangeTime(int dwRegister, ref FILETIME pfiletime);

	int GetTimeOfLastChange(IMoniker pmkObjectName, out FILETIME pfiletime);

	IEnumMoniker EnumRunning();
}
