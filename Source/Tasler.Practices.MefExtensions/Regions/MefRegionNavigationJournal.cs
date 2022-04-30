using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;

namespace Tasler.Practices.Prism.MefExtensions.Regions
{
	[Export(typeof(IRegionNavigationJournal))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class MefRegionNavigationJournal : Tasler.Practices.Prism.Regions.RegionNavigationJournal
	{
	}
}
