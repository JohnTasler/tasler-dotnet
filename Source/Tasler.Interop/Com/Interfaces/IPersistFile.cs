using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000010B-0000-0000-C000-000000000046")]
public partial interface IPersistFile : IPersist
{
	/// <summary>
	/// Indicates whether the object has changed since it was last saved.
	/// </summary>
	/// <returns>
	/// An HRESULT value: S_OK if the object has changed since it was last saved, S_FALSE if it has not, or an error code otherwise.
	/// </returns>
	[PreserveSig]
	int IsDirty();

	/// <summary>
/// Loads the object's state from the specified file using the provided storage mode.
/// </summary>
/// <param name="fileName">Path to the file to load the object's state from.</param>
/// <param name="mode">STGM flags that specify access, sharing, and creation semantics for opening the file.</param>
void Load(string fileName, STGM mode);

	/// <summary>
	/// Saves the object to the specified file and optionally remembers the file name for future saves.
	/// </summary>
	/// <param name="fileName">The path of the file to save.</param>
	/// <param name="fRemember">If <c>true</c>, the object should remember <paramref name="fileName"/> for subsequent save operations.</param>
	/// <returns>An HRESULT value: <c>0</c> (S_OK) on success, otherwise an error code.</returns>
	[PreserveSig]
	int Save(string fileName, [MarshalAs(UnmanagedType.Bool)] bool fRemember);

	/// <summary>
/// Notifies the object that a save operation has completed for the specified file.
/// </summary>
/// <param name="fileName">The path of the file for which the save operation has completed.</param>
void SaveCompleted(string fileName);

	/// <summary>
	/// Retrieves the current file path associated with the object.
	/// </summary>
	/// <param name="fileName">When the method returns, contains the current file path, or null if no file is associated.</param>
	/// <returns>HRESULT status code: S_OK on success, or a COM error code on failure.</returns>
	[PreserveSig]
	int GetCurFile(out string? fileName);
}