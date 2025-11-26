using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000000B-0000-0000-C000-000000000046")]
public partial interface IStorage : IUnknown
{
	/// <summary>
/// Creates a new stream in the storage with the specified name and creation/opening mode.
/// </summary>
/// <param name="pwcsName">The name of the stream to create.</param>
/// <param name="mode">Creation and access flags that control how the stream is created.</param>
/// <param name="reserved1">Reserved; must be zero.</param>
/// <param name="reserved2">Reserved; must be zero.</param>
/// <returns>The created <see cref="IStream"/> representing the new stream.</returns>
IStream CreateStream(string pwcsName, STGM mode, uint reserved1, uint reserved2);

	/// <summary>
/// Opens an existing stream within the storage identified by name.
/// </summary>
/// <param name="pwcsName">The name of the stream to open.</param>
/// <param name="reserved1">Reserved; must be zero.</param>
/// <param name="mode">Access and sharing mode flags for the stream.</param>
/// <param name="reserved2">Reserved; must be zero.</param>
/// <returns>An <see cref="IStream"/> representing the opened stream.</returns>
IStream OpenStream(string pwcsName, nint reserved1, STGM mode, uint reserved2);

	/// <summary>
	/// Creates a new sub-storage with the specified name within this storage object.
	/// </summary>
	/// <param name="pwcsName">Name of the sub-storage to create.</param>
	/// <param name="mode">Creation and access mode flags that specify how the new storage is to be opened.</param>
	/// <param name="reserved1">Reserved; must be zero.</param>
	/// <param name="reserved2">Reserved; must be zero.</param>
	/// <param name="ppstg">When this method returns, receives the created <see cref="IStorage"/> if the call succeeds; otherwise null.</param>
	/// <returns>An HRESULT value: `S_OK` on success, or an error code on failure.</returns>
	[PreserveSig]
	int CreateStorage(string pwcsName, STGM mode, uint reserved1, uint reserved2, out IStorage ppstg);

	/// <summary>
	/// Opens an existing sub-storage by name within this storage object.
	/// </summary>
	/// <param name="pwcsName">The name of the sub-storage to open.</param>
	/// <param name="reserved1">Reserved; must be null for future use.</param>
	/// <param name="mode">Access mode and sharing flags for opening the sub-storage.</param>
	/// <param name="reserved2">Reserved; must be zero or null.</param>
	/// <param name="reserved3">Reserved; must be zero.</param>
	/// <param name="ppstg">Receives the opened IStorage instance on success.</param>
	/// <returns>An HRESULT value: `0` (S_OK) on success, or a COM error code on failure.</returns>
	[PreserveSig]
	int OpenStorage(string pwcsName, IStorage reserved1, STGM mode, nint reserved2, uint reserved3, out IStorage ppstg);

	/// <summary>
		/// Copies elements from this storage to the specified destination storage, allowing callers to exclude specific interface IDs and named elements.
		/// </summary>
		/// <param name="ciidExclude">The number of GUIDs in <paramref name="rgiidExclude"/> to exclude from the copy operation.</param>
		/// <param name="rgiidExclude">An array of interface GUIDs to exclude from copying; only the first <paramref name="ciidExclude"/> entries are considered.</param>
		/// <param name="snbExclude">A pointer to an optional string-name-block that specifies additional elements to exclude; pass zero if not used.</param>
		/// <param name="pstgDest">The destination <see cref="IStorage"/> that will receive the copied elements.</param>
		void CopyTo(uint ciidExclude,
		[MarshalUsing(CountElementName = nameof(ciidExclude))] [In] Guid[] rgiidExclude, nint snbExclude, IStorage pstgDest);

	/// <summary>
/// Moves a named element (stream or sub-storage) from this storage into a destination storage using the specified new name.
/// </summary>
/// <param name="pwcsName">The name of the element in this storage to move.</param>
/// <param name="pstgDest">The destination storage that will receive the moved element.</param>
/// <param name="pwcsNewName">The new name to assign to the element in the destination storage.</param>
/// <param name="moveFlags">Flags that control the move operation behavior (see <see cref="STGMOVE"/>).</param>
void MoveElementTo(string pwcsName, IStorage pstgDest, string pwcsNewName, STGMOVE moveFlags);

	/// <summary>
	/// Commits changes made to this storage object using the specified commit behavior.
	/// </summary>
	/// <param name="commitFlags">Specifies the commit behavior (one of the STGCOMMIT values).</param>
	/// <returns>Zero (S_OK) on success, or an HRESULT error code on failure.</returns>
	[PreserveSig]
	int Commit(STGCOMMIT commitFlags);

	/// <summary>
/// Reverts the storage to the state of the last commit, discarding any uncommitted changes.
/// </summary>
void Revert();

	/// <summary>
/// Obtains an enumerator for the elements contained in this storage object.
/// </summary>
/// <param name="reserved1">Reserved for future use; callers must pass zero.</param>
/// <param name="reserved2">Reserved for future use; callers must pass zero or null.</param>
/// <param name="reserved3">Reserved for future use; callers must pass zero.</param>
/// <returns>An <see cref="IEnumSTATSTG"/> that enumerates <see cref="STATSTG"/> records for the storage's elements.</returns>
IEnumSTATSTG EnumElements(uint reserved1, nint reserved2, uint reserved3);

	/// <summary>
/// Deletes the specified element (stream or sub-storage) from this storage.
/// </summary>
/// <param name="pwcsName">The name of the element to remove.</param>
void DestroyElement(string pwcsName);

	/// <summary>
/// Renames an element (stream or sub-storage) within this storage.
/// </summary>
/// <param name="oldName">The current name of the element to rename.</param>
/// <param name="newName">The new name to assign to the element.</param>
void RenameElement(string oldName, string newName);

	/// <summary>
/// Sets the creation, access, and modification timestamps for the specified element in the storage.
/// </summary>
/// <param name="name">The null-terminated name of the element (stream or storage) whose times will be set.</param>
/// <param name="pctime">Pointer to a FILETIME value specifying the creation time, or IntPtr.Zero to leave the creation time unchanged.</param>
/// <param name="patime">Pointer to a FILETIME value specifying the last-access time, or IntPtr.Zero to leave the access time unchanged.</param>
/// <param name="pmtime">Pointer to a FILETIME value specifying the last-modified time, or IntPtr.Zero to leave the modification time unchanged.</param>
void SetElementTimes(string name, nint pctime, nint patime, nint pmtime);

	/// <summary>
/// Sets the class identifier (CLSID) for this storage object.
/// </summary>
/// <param name="clsid">A reference to the GUID that specifies the CLSID to assign to the storage.</param>
void SetClass(ref Guid clsid);

	/// <summary>
/// Sets the storage's state bits, changing only the bits specified by the mask.
/// </summary>
/// <param name="grfStateBits">The state bits to apply; only bits covered by <paramref name="grfMask"/> are written.</param>
/// <param name="grfMask">A mask indicating which state bits to update; bits set to 1 cause the corresponding bits in <paramref name="grfStateBits"/> to be applied.</param>
void SetStateBits(uint grfStateBits, uint grfMask);

	/// <summary>
/// Retrieves statistics for this storage object.
/// </summary>
/// <param name="pstatstg">Outputs a STATSTG structure containing the storage's statistics (for example type, size, timestamps, and other metadata).</param>
/// <param name="statFlag">Specifies which statistics are returned (for example whether the name field is populated).</param>
void Stat(out STATSTG pstatstg, STATFLAG statFlag);
}