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

//[System.Diagnostics.CodeAnalysis.SuppressMessage("ComInterfaceGenerator", "SYSLIB1230:Specifying 'GeneratedComInterfaceAttribute' on an interface that has a base interface defined in another assembly is not supported", Justification = "Allowed")]
[GeneratedComInterface]
[Guid(Guids.IID_IEnumACString)]
public partial interface IEnumACString : IEnumString
{
	[PreserveSig]
	int NextItem(nint pszUr, uint cchMax, out uint pulSortIndex);

	void SetEnumOptions(AutoCompleteOption dwOptions);

	AutoCompleteOption GetEnumOptions();
}

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid(Guids.IID_IACList)]
public partial interface IACList
{
	[PreserveSig]
	int Expand(string pszExpand);
}

[GeneratedComInterface]
[Guid(Guids.IID_IACList2)]
public partial interface IACList2 : IACList
{
	[PreserveSig]
	int SetOptions(AutoCompleteListOptions dwFlag);

	AutoCompleteListOptions GetOptions();
}

[GeneratedComInterface(StringMarshalling = StringMarshalling.Utf16)]
[Guid(Guids.IID_IAutoComplete)]
public partial interface IAutoComplete
{
	int Init(nint hwndEdit, IEnumString punkACL, string pwszRegKeyPath, string pwszQuickComplete);

	int Enable([MarshalAs(UnmanagedType.Bool)] bool fEnable);
}

[GeneratedComInterface]
[Guid(Guids.IID_IAutoComplete)]
public partial interface IAutoComplete2 : IAutoComplete
{
	[PreserveSig]
	int SetOptions(AutoCompleteOptions dwFlag);

	AutoCompleteOptions GetOptions();
}
