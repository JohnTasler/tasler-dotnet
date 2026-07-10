using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using Tasler.Interop.Com;

namespace Tasler.Interop.Shell.PropertyStore;

[Guid("886D8EEB-8CF2-4446-8D02-CDBA1DBDCF99")]
[GeneratedComInterface]
[SuppressMessage(SuppressMessage.Category.ComInterfaceGenerator, SuppressMessage.CheckId.SYSLIB1230_BaseInterfaceInOtherAssembly, Justification = SuppressMessage.Justification.IUnknownNoProblem)]
public partial interface IPropertyStore : IUnknown
{
	uint GetCount();

	PropertyKey GetAt(uint iProp);

	PROPVARIANT GetValue(ref PropertyKey key);

	void SetValue(ref PropertyKey key, ref PROPVARIANT propvar);

	void Commit();
};
