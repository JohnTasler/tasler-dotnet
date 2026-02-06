using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface]
[Guid("00000010-0000-0000-C000-000000000046")]
public partial interface IRunningObjectTable : IUnknown
{
	/// <summary>
	/// Registers an object in the Running Object Table and provides a cookie that identifies the registration.
	/// </summary>
	/// <param name="grfFlags">Registration flags that control how the object is registered.</param>
	/// <param name="punkObject">Pointer to the object to register.</param>
	/// <param name="pmkObjectName">Moniker that names the object.</param>
	/// <param name="cookie">Receives the registration cookie that identifies the registered object.</param>
	/// <returns>An HRESULT value; S_OK on success or a COM error code on failure.</returns>
	[PreserveSig]
	int Register(int grfFlags, nint punkObject, IMoniker pmkObjectName, out uint cookie);

	/// <summary>
	/// Removes a previously registered object from the running object table using its registration cookie.
	/// </summary>
	/// <param name="cookie">The registration cookie returned by Register that identifies the entry to revoke.</param>
	void Revoke(uint cookie);

	/// <summary>
	/// Determines whether the object identified by the specified moniker is currently registered as running.
	/// </summary>
	/// <param name="pmkObjectName">The moniker that names the object to check.</param>
	/// <returns>An HRESULT indicating whether the moniker identifies a running object: `S_OK` if running, `S_FALSE` if not; other HRESULT values indicate failure.</returns>
	[PreserveSig]
	int IsRunning(IMoniker pmkObjectName);

	/// <summary>
	/// Retrieves the running object associated with the specified moniker.
	/// </summary>
	/// <param name="pmkObjectName">The moniker that identifies the running object to retrieve.</param>
	/// <param name="ppunkObject">Receives a pointer to the object's IUnknown on success; receives zero on failure.</param>
	/// <returns>An HRESULT code: `S_OK` if the object pointer was returned, or an error code otherwise.</returns>
	[PreserveSig]
	int GetObject(IMoniker pmkObjectName, out nint ppunkObject);

	/// <summary>
	/// Notifies the running object table of an updated change time for a registered object.
	/// </summary>
	/// <param name="dwRegister">Identifier of the registration whose change time is being updated.</param>
	/// <param name="pfiletime">New change time as a 64-bit Windows FILETIME value.</param>
	void NoteChangeTime(int dwRegister, in ulong pfiletime);

	/// <summary>
	/// Retrieves the last-modified time for the running object identified by the specified moniker.
	/// </summary>
	/// <param name="pmkObjectName">Moniker that identifies the running object whose last change time is requested.</param>
	/// <param name="pfiletime">Receives the last change time as a 64-bit FILETIME value (number of 100-nanosecond intervals since January 1, 1601 UTC).</param>
	/// <returns>HRESULT indicating success or failure of the operation.</returns>
	[PreserveSig]
	int GetTimeOfLastChange(IMoniker pmkObjectName, out ulong pfiletime);

	/// <summary>
	/// Obtains an enumerator for the monikers of all objects currently registered in the running object table.
	/// </summary>
	/// <returns>An <see cref="IEnumMoniker"/> that enumerates the monikers of running objects.</returns>
	IEnumMoniker EnumRunning();
}
