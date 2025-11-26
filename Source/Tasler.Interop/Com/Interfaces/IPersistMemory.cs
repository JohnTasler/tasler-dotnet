using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("BD1AE5E0-A6AE-11CE-BD37-504200C10000")]
public partial interface IPersistMemory : IPersist
{
	/// <summary>
	/// Reports whether the object has unsaved changes.
	/// </summary>
	/// <returns>`S_OK` if the object has unsaved changes, `S_FALSE` if it does not, or an HRESULT error code on failure.</returns>
	[PreserveSig]
	int IsDirty();

	/// <summary>
/// Loads the object's state from the specified memory block.
/// </summary>
/// <param name="pMem">Pointer to the memory block containing the serialized object state.</param>
/// <param name="cbSize">Size of the memory block in bytes.</param>
void Load(nint pMem, uint cbSize);

	/// <summary>
/// Persists the object's state into the provided memory block.
/// </summary>
/// <param name="pMem">Pointer to the destination memory buffer where state will be written.</param>
/// <param name="fClearDirty">If `true`, clears the object's dirty (unsaved) flag after a successful save.</param>
/// <returns>A status code indicating the outcome of the save operation.</returns>
uint Save(nint pMem, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty );

	/// <summary>
/// Gets the maximum number of bytes required to persist the object's state.
/// </summary>
/// <returns>The maximum size, in bytes, required to save the object's persistent state.</returns>
uint GetSizeMax();

	/// <summary>
/// Reinitializes the object to its default (new) state for persistence.
/// </summary>
void InitNew();
}