using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000010A-0000-0000-C000-000000000046")]
public partial interface IPersistStorage : IPersist
{
	/// <summary>
	/// Determines whether the object has unsaved changes.
	/// </summary>
	/// <returns>
	/// An HRESULT: `S_OK` if the object has unsaved changes, `S_FALSE` if it does not, or an error HRESULT on failure.
	/// </returns>
	[PreserveSig]
	int IsDirty();

	/// <summary>
/// Initializes the instance to use the provided storage for its persistent state.
/// </summary>
/// <param name="storage">The IStorage to initialize for storing the object's persistent state.</param>
void InitNew(IStorage storage);

	/// <summary>
/// Loads the object's persisted state from the specified storage.
/// </summary>
/// <param name="storage">The storage object to read the persisted state from.</param>
void Load(IStorage storage);

	/// <summary>
/// Saves the object's persistent state to the specified storage.
/// </summary>
/// <param name="storage">The storage object to receive the saved state.</param>
/// <param name="fSameAsLoad">`true` if the provided storage is the same one used when the object was loaded; `false` if the storage is different.</param>
void Save(IStorage storage, [MarshalAs(UnmanagedType.Bool)] bool fSameAsLoad);

	/// <summary>
/// Signals that a previously initiated Save operation has completed for the specified storage.
/// </summary>
/// <param name="storage">The storage object for which the save completed; the caller may resume using or release this storage.</param>
void SaveCompleted(IStorage storage);

	/// <summary>
/// Releases the object's reference to its current storage.
/// </summary>
void HandsOffStorage();
}