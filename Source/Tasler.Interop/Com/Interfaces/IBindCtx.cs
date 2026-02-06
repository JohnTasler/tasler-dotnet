using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

namespace Tasler.Interop.Com;

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid("0000000E-0000-0000-C000-000000000046")]
public partial interface IBindCtx : IUnknown
{
	/// <summary>
	/// Registers a COM object as bound to this binding context.
	/// </summary>
	/// <param name="unknown">Native pointer to the object's IUnknown interface to register with the context.</param>
	void RegisterObjectBound(nint unknown);

	/// <summary>
	/// Removes a previously registered object from the binding context.
	/// </summary>
	/// <param name="unknown">Native pointer to the object's IUnknown interface that was registered with the binding context.</param>
	void RevokeObjectBound(nint unknown);

	/// <summary>
	/// Releases all objects currently registered as bound in the binding context.
	/// </summary>
	void ReleaseBoundObjects();

	/// <summary>
	/// Applies the specified binding options to this binding context.
	/// </summary>
	/// <param name="pbindopts">A reference to a BIND_OPTS structure containing the binding options to set for the context.</param>
	void SetBindOptions(ref BIND_OPTS pbindopts);

	/// <summary>
	/// Populates the provided BIND_OPTS structure with the binding options currently in effect for this binding context.
	/// </summary>
	/// <param name="pbindopts">A reference to a BIND_OPTS structure that will be filled with the current binding options.</param>
	void GetBindOptions(ref BIND_OPTS pbindopts);

	/// <summary>
	/// Retrieves the Running Object Table (ROT) associated with this binding context.
	/// </summary>
	/// <returns>The <see cref="IRunningObjectTable"/> for this binding context.</returns>
	IRunningObjectTable GetRunningObjectTable();

	/// <summary>
	/// Registers an object pointer in the binding context under the specified key.
	/// </summary>
	/// <param name="pszKey">The string key to associate with the object parameter.</param>
	/// <param name="unknown">A native pointer identifying the object to register.</param>
	void RegisterObjectParam(string pszKey, nint unknown);

	/// <summary>
/// Retrieves the native pointer value of the object parameter associated with the specified key.
/// </summary>
/// <param name="pszKey">The name of the object parameter to retrieve.</param>
/// <returns>The native pointer value associated with <paramref name="pszKey"/>.</returns>
	nint GetObjectParam(string pszKey);

	/// <summary>
	/// Creates an enumerator for the string keys of object parameters stored in the binding context.
	/// </summary>
	/// <returns>An <see cref="IEnumString"/> that enumerates the registered object parameter keys.</returns>
	IEnumString EnumObjectParam();

	/// <summary>
	/// Removes the object parameter associated with the specified key from the binding context.
	/// </summary>
	/// <param name="pszKey">The key that identifies the object parameter to remove.</param>
	void RevokeObjectParam(string pszKey);
}
