using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;

namespace Tasler.Windows.ComponentModel.MefExtensions.Regions
{
	[Export(typeof(IRegionNavigationJournal))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class MefRegionNavigationJournal : Tasler.Windows.ComponentModel.Regions.RegionNavigationJournal
	{
	}
}
