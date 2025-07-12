using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Principal;
using Tasler.Interop.Kernel;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000000B-0000-0000-C000-000000000046")]
public partial interface IStorage
{
	IStream CreateStream(string pwcsName, STGM mode, uint reserved1, uint reserved2);

	IStream OpenStream(string pwcsName, nint reserved1, STGM mode, uint reserved2);

	[PreserveSig]
	int CreateStorage(string pwcsName, STGM mode, uint reserved1, uint reserved2, out IStorage ppstg);

	[PreserveSig]
	int OpenStorage(string pwcsName, IStorage reserved1, STGM mode, nint reserved2, uint reserved3, out IStorage ppstg);

	void CopyTo(uint ciidExclude,
		[MarshalUsing(CountElementName = nameof(ciidExclude))] [In] Guid[] rgiidExclude, nint snbExclude, IStorage pstgDest);

	void MoveElementTo(string pwcsName, IStorage pstgDest, string pwcsNewName, STGMOVE moveFlags);

	[PreserveSig]
	int Commit(STGCOMMIT commitFlags);

	void Revert();

	IEnumSTATSTG EnumElements(uint reserved1, nint reserved2, uint reserved3);

	void DestroyElement(string pwcsName);

	void RenameElement(string oldName, string newName);

	void SetElementTimes(string name, nint pctime, nint patime, nint pmtime);

	void SetClass(ref Guid clsid);

	void SetStateBits(uint grfStateBits, uint grfMask);

	void Stat(out STATSTG pstatstg, STATFLAG statFlag);
}
