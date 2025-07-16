using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

namespace Tasler.Interop.Shell.AutoComplete;

[GeneratedComInterface]
[Guid(Guids.IID_IObjMgr)]
public partial interface IObjMgr
{
	void Append(IEnumString punk);
	void Remove(IEnumString punk);
}

[Guid(Guids.IID_IEnumACString)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[System.Diagnostics.CodeAnalysis.SuppressMessage("ComInterfaceGenerator", "SYSLIB1230:Specifying 'GeneratedComInterfaceAttribute' on an interface that has a base interface defined in another assembly is not supported", Justification = "Allowed")]
public partial interface IEnumACString : IEnumString
{
	[PreserveSig]
	int NextItem(string pszUr, uint cchMax, out uint pulSortIndex);

	void SetEnumOptions(AutoCompleteOption dwOptions);

	AutoCompleteOption GetEnumOptions();
}

[Guid(Guids.IID_IACList)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IACList
{
	[PreserveSig]
	int Expand(string pszExpand);
}

[Guid(Guids.IID_IACList2)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IACList2 : IACList
{
	[PreserveSig]
	int SetOptions(AutoCompleteListOptions dwFlag);

	AutoCompleteListOptions GetOptions();
}

[Guid(Guids.IID_IAutoComplete)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IAutoComplete
{
	int Init(nint hwndEdit, IEnumString punkACL, string pwszRegKeyPath, string pwszQuickComplete);

	int Enable([MarshalAs(UnmanagedType.Bool)] bool fEnable);
}

[Guid(Guids.IID_IAutoComplete)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface IAutoComplete2 : IAutoComplete
{
	[PreserveSig]
	int SetOptions(AutoCompleteOptions dwFlag);

	AutoCompleteOptions GetOptions();
}

[Guid(Guids.IID_ICurrentWorkingDirectory)]
[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
public partial interface ICurrentWorkingDirectory : IUnknown
{
	[PreserveSig]
	int GetDirectory([MarshalUsing(CountElementName = nameof(cchSize))] [Out] char[] pwzPath, uint cchSize);

	[PreserveSig]
	int SetDirectory(string pwzPath);
}
