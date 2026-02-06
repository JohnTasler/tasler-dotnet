using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("00000109-0000-0000-C000-000000000046")]
public partial interface IPersistStream : IPersist
{
	/// <summary>
	/// Determines whether the object has unsaved changes since it was last persisted.
	/// </summary>
	/// <returns>An HRESULT indicating the dirty state: S_OK if the object has unsaved changes, S_FALSE if it does not, or an error code on failure.</returns>
	[PreserveSig]
	int IsDirty();

	/// <summary>
	/// Loads the object's persisted state from the specified stream.
	/// </summary>
	/// <param name="stream">The stream to read the object's persisted state from.</param>
	void Load(IStream stream);

	/// <summary>
	/// Persists the object's state to the specified COM IStream.
	/// </summary>
	/// <param name="stream">The COM IStream to which the object's state will be written.</param>
	/// <param name="fClearDirty">If `true`, clear the object's "dirty" state after a successful save; otherwise leave it set.</param>
	void Save(IStream stream, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

	/// <summary>
	/// Gets the maximum size, in bytes, of the stream required to save the object's persistent data.
	/// </summary>
	/// <returns>The maximum number of bytes required to persist the object's state.</returns>
	ulong GetSizeMax();
}
