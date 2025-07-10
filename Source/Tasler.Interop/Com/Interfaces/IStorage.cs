using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Kernel;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000000B-0000-0000-C000-000000000046")]
public partial interface IStorage
{
	int CreateStream(string pwcsName, STGM mode, uint reserved1, uint reserved2, out IStream ppstm);

	int OpenStream(string pwcsName, nint reserved1, STGM mode, uint reserved2, out IStream ppstm);

	int CreateStorage(string pwcsName, STGM mode, uint reserved1, uint reserved2, out IStorage ppstg);

	int OpenStorage(string pwcsName, IStorage pstgPriority, STGM mode, nint snbExclude, uint reserved, out IStorage ppstg);

	int CopyTo(uint ciidExclude, ref Guid rgiidExclude, nint snbExclude, IStorage pstgDest);

	int MoveElementTo(string pwcsName, IStorage pstgDest, nint pwcsNewName, STGMOVE moveFlags);

	int Commit(STGCOMMIT commitFlags);

	int Revert();

	int EnumElements(uint reserved1, nint reserved2, uint reserved3, out IEnumSTATSTG ppenum);

	int DestroyElement(string pwcsName);

	int RenameElement(string pwcsOldName, string pwcsNewName);

	int SetElementTimes(string pwcsName, ref FILETIME pctime, ref FILETIME patime, ref FILETIME pmtime);

	int SetClass(ref Guid clsid);

	int SetStateBits(uint grfStateBits, uint grfMask);

	int Stat(out STATSTG pstatstg, STATFLAG statFlag);
}
