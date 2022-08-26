using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;

namespace Tasler.Windows.ComponentModel.MefExtensions.Regions
{
	[PartCreationPolicy(CreationPolicy.Shared)]
	[Export(typeof(ContentControlRegionAdapter))]
	public class MefContentControlRegionAdapter : Tasler.Windows.ComponentModel.Regions.ContentControlRegionAdapter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MefContentControlRegionAdapter"/> class.
		/// </summary>
		/// <param name="regionBehaviorFactory">The region behavior factory.</param>
		[ImportingConstructor]
		public MefContentControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
			: base(regionBehaviorFactory)
		{
		}
	}
}
