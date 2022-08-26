using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;
using Tasler.Windows.Controls;

namespace Tasler.Practices.Prism.Regions
{
	public class ContentControlRegionAdapter : Microsoft.Practices.Prism.Regions.ContentControlRegionAdapter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ContentControlRegionAdapter"/> class.
		/// </summary>
		/// <param name="regionBehaviorFactory">The region behavior factory.</param>
		public ContentControlRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory)
			: base(regionBehaviorFactory)
		{
		}

		/// <summary>
		/// Adapts a <see cref="ContentControl"/> to an <see cref="IRegion"/>.
		/// </summary>
		/// <param name="region">The new region being used.</param>
		/// <param name="regionTarget">The object to adapt.</param>
		protected override void Adapt(IRegion region, ContentControl regionTarget)
		{
			if (regionTarget == null)
				throw new ArgumentNullException("regionTarget");

			var contentIsSet = regionTarget.Content != null;
#if !SILVERLIGHT
			contentIsSet = contentIsSet || (System.Windows.Data.BindingOperations.GetBinding(regionTarget, ContentControl.ContentProperty) != null);
#endif // !SILVERLIGHT
			if (contentIsSet)
				throw new InvalidOperationException("Resources.ContentControlHasContentException");

			region.ActiveViews.CollectionChanged += (sender, e) =>
			{
				if (e.Action == NotifyCollectionChangedAction.Add)
					regionTarget.Content = region.ActiveViews.FirstOrDefault();
			};

			var transitionContentControl = regionTarget as TransitionContentControl;
			if (transitionContentControl != null)
			{
				region.NavigationService.Navigating += (sender, e) =>
				{
					var journal = region.NavigationService.Journal as Tasler.Practices.Prism.Regions.RegionNavigationJournal;
					transitionContentControl.IsReversed = journal != null && journal.BackStack.Any(je => je.Uri == e.Uri);
				};
			}
		}
	}
}
