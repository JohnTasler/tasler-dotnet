using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Kernel;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("0000000B-0000-0000-C000-000000000046")]
public partial interface IStorage
{
	[PreserveSig]
	int CreateStream(nint pwcsName, STGM mode, uint reserved1, uint reserved2, out IStream ppstm);

	[PreserveSig]
	int OpenStream(nint pwcsName, nint reserved1, STGM mode, uint reserved2, out IStream ppstm);

	[PreserveSig]
	int CreateStorage(nint pwcsName, STGM mode, uint reserved1, uint reserved2, out IStorage ppstg);

	[PreserveSig]
	int OpenStorage(nint pwcsName, IStorage pstgPriority, STGM mode, nint snbExclude, uint reserved, out IStorage ppstg);

	[PreserveSig]
	int CopyTo(uint ciidExclude, ref Guid rgiidExclude, nint snbExclude, IStorage pstgDest);

	[PreserveSig]
	int MoveElementTo(nint pwcsName, IStorage pstgDest, nint pwcsNewName, STGMOVE moveFlags);

	[PreserveSig]
	int Commit(STGCOMMIT commitFlags);

	[PreserveSig]
	int Revert();

	[PreserveSig]
	int EnumElements(uint reserved1, nint reserved2, uint reserved3, out IEnumSTATSTG ppenum);

	[PreserveSig]
	int DestroyElement(nint pwcsName);

	[PreserveSig]
	int RenameElement(nint pwcsOldName, nint pwcsNewName);

	[PreserveSig]
	int SetElementTimes(nint pwcsName, ref FILETIME pctime, ref FILETIME patime, ref FILETIME pmtime);

	[PreserveSig]
	int SetClass(ref Guid clsid);

	[PreserveSig]
	int SetStateBits(uint grfStateBits, uint grfMask);

	[PreserveSig]
	int Stat(out STATSTG pstatstg, STATFLAG statFlag);
}
