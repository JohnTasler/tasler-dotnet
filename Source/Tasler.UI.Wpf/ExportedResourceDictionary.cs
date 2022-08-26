using System.ComponentModel.Composition;
using System.Windows;

namespace Tasler.Windows
{
	[InheritedExport]
	[PartCreationPolicy(CreationPolicy.Shared)]
	public class ExportedResourceDictionary : ResourceDictionary
	{
	}
}
