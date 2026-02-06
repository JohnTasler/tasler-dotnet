using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

namespace Tasler.Interop.Shell.AutoComplete;

[GeneratedComInterface]
[Guid(Guids.IID_IObjMgr)]
public partial interface IObjMgr
{
	/// <summary>
	/// Adds an IEnumString enumerator to the object manager.
	/// </summary>
	/// <param name="punk">The IEnumString enumerator to add.</param>
	void Append(IEnumString punk);

	/// <summary>
	/// Removes the specified string enumerator from the object manager.
	/// </summary>
	/// <param name="punk">The IEnumString instance to remove from the manager.</param>
	void Remove(IEnumString punk);
}

[Guid(Guids.IID_IEnumACString)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[System.Diagnostics.CodeAnalysis.SuppressMessage("ComInterfaceGenerator", "SYSLIB1230:Specifying 'GeneratedComInterfaceAttribute' on an interface that has a base interface defined in another assembly is not supported", Justification = "Allowed")]
public partial interface IEnumACString : IEnumString
{
	/// <summary>
	/// Retrieves the next auto-complete string into the provided buffer.
	/// </summary>
	/// <param name="pszUr">Buffer that receives the next item string.</param>
	/// <param name="cchMax">Maximum number of characters the buffer can hold, including the terminating null if applicable.</param>
	/// <param name="pulSortIndex">Receives the sort index associated with the returned item.</param>
	/// <returns>An HRESULT indicating success, that no more items are available, or an error code.</returns>
	[PreserveSig]
	int NextItem(string pszUr, uint cchMax, out uint pulSortIndex);

	/// <summary>
/// Sets the enumeration options that control how auto-complete strings are produced and filtered.
/// </summary>
/// <param name="dwOptions">Flags specifying the auto-complete enumeration behavior to apply.</param>
	void SetEnumOptions(AutoCompleteOption dwOptions);

	/// <summary>
/// Gets the options currently applied to auto-complete string enumeration.
/// </summary>
/// <returns>The current <see cref="AutoCompleteOption"/> flags controlling enumeration behavior.</returns>
	AutoCompleteOption GetEnumOptions();
}

[Guid(Guids.IID_IACList)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IACList
{
	/// <summary>
	/// Expands a partial input string to generate or display auto-complete suggestions.
	/// </summary>
	/// <param name="pszExpand">The input string to expand.</param>
	/// <returns>An HRESULT indicating the result of the expansion: `S_OK` if expansion succeeded, `S_FALSE` if no expansion is available, or an error code on failure.</returns>
	[PreserveSig]
	int Expand(string pszExpand);
}

[Guid(Guids.IID_IACList2)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IACList2 : IACList
{
	/// <summary>
	/// Sets the auto-complete list behavior by applying the specified list options.
	/// </summary>
	/// <param name="dwFlag">Flags that modify how the auto-complete list behaves.</param>
	/// <returns>HRESULT indicating success or failure (S_OK on success, error code otherwise).</returns>
	[PreserveSig]
	int SetOptions(AutoCompleteListOptions dwFlag);

	/// <summary>
/// Retrieves the current auto-complete list options.
/// </summary>
/// <returns>The current <see cref="AutoCompleteListOptions"/> value.</returns>
	AutoCompleteListOptions GetOptions();
}

[Guid(Guids.IID_IAutoComplete)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IAutoComplete
{
	/// <summary>
/// Initializes auto-complete support for the specified edit control.
/// </summary>
/// <param name="hwndEdit">Handle to the edit control that will receive auto-complete.</param>
/// <param name="punkACL">An <see cref="IEnumString"/> that supplies completion strings; may be null.</param>
/// <param name="pwszRegKeyPath">Optional registry key path used by the auto-complete implementation; may be null or empty.</param>
/// <param name="pwszQuickComplete">Optional quick-complete string to seed suggestions; may be null or empty.</param>
/// <returns>HRESULT-style status code: S_OK (0) on success, otherwise an HRESULT error code.</returns>
	int Init(nint hwndEdit, IEnumString punkACL, string pwszRegKeyPath, string pwszQuickComplete);

	/// <summary>
/// Enables or disables the auto-complete behavior for the associated edit control.
/// </summary>
/// <param name="fEnable">`true` to enable auto-complete, `false` to disable it.</param>
/// <returns>HRESULT indicating success or failure; `S_OK` on success.</returns>
	int Enable([MarshalAs(UnmanagedType.Bool)] bool fEnable);
}

[Guid(Guids.IID_IAutoComplete)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IAutoComplete2 : IAutoComplete
{
	/// <summary>
	/// Sets additional auto-complete behaviors specified by the provided flags.
	/// </summary>
	/// <param name="dwFlag">Flags that modify auto-complete behavior.</param>
	/// <returns>An HRESULT value: S_OK on success, or a COM error code on failure.</returns>
	[PreserveSig]
	int SetOptions(AutoCompleteOptions dwFlag);

	/// <summary>
/// Gets the currently configured auto-complete options.
/// </summary>
/// <returns>The currently configured AutoCompleteOptions flags.</returns>
	AutoCompleteOptions GetOptions();
}

[Guid(Guids.IID_ICurrentWorkingDirectory)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface ICurrentWorkingDirectory : IUnknown
{
	/// <summary>
	/// Retrieves the current working directory into the provided character buffer.
	/// </summary>
	/// <param name="pwzPath">A character buffer that receives the directory path; the buffer must have space for <paramref name="cchSize"/> characters.</param>
	/// <param name="cchSize">The size of <paramref name="pwzPath"/> in characters.</param>
	/// <returns>An HRESULT indicating the result of the operation; `S_OK` on success, otherwise an error HRESULT.</returns>
	[PreserveSig]
	int GetDirectory([MarshalUsing(CountElementName = nameof(cchSize))] [Out] char[] pwzPath, uint cchSize);

	/// <summary>
	/// Sets the current working directory to the specified path.
	/// </summary>
	/// <param name="pwzPath">The directory path to become the current working directory.</param>
	/// <returns>An HRESULT value: `S_OK` if the directory was set successfully, otherwise an error code.</returns>
	[PreserveSig]
	int SetDirectory(string pwzPath);
}
