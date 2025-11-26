using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("7FD52380-4E07-101B-AE2D-08002B2EC713")]
public partial interface IPersistStreamInit : IPersist
{
	/// <summary>
	/// Checks whether the object's persistent state has been modified since it was last saved.
	/// </summary>
	/// <returns>
	/// An HRESULT: `S_OK` if the object has been modified since the last save, `S_FALSE` if not; other HRESULT values indicate error conditions.
	/// </returns>
	[PreserveSig]
	int IsDirty();

	/// <summary>
/// Loads the object's persisted state from the specified COM stream.
/// </summary>
/// <param name="stream">COM stream to read the object's persisted state from.</param>
void Load(IStream stream);

	/// <summary>
/// Persists the object's state to the provided stream.
/// </summary>
/// <param name="stream">The stream to which the object's state will be written.</param>
/// <param name="fClearDirty">If true, clears the object's modified (dirty) state after saving; if false, retains the dirty state.</param>
void Save(IStream stream, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

	/// <summary>
/// Retrieves the maximum number of bytes required to save the object's persistent state.
/// </summary>
/// <returns>The maximum size in bytes needed to persist the object.</returns>
ulong GetSizeMax();

	/// <summary>
/// Initializes the object to a new persisted state for subsequent use.
/// </summary>
/// <remarks>
/// Resets the object's persisted state so it behaves as if newly created for persistence operations.
/// </remarks>
void InitNew();
}