using System;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Tasler.Practices.Prism.ViewModel;

namespace Tasler.Practices.Prism.Extensions
{
	public static class RegionManagerExtensions
	{
		public static void RequestNavigate(this IRegionManager source, string regionName, Type viewModelType, Action<NavigationResult> navigationCallback)
		{
			var viewResolver = ServiceLocator.Current.GetInstance<IViewResolver>();
			if (viewResolver != null)
			{
				var viewType = viewResolver.ResolveViewFromViewModel(viewModelType);

				if (source.Regions.ContainsRegionWithName(regionName) && !source.Regions[regionName].Views.Any(v => v.GetType() == viewType))
					source.RegisterViewWithRegion(regionName, viewType);

				source.RequestNavigate(regionName, viewType.FullName, navigationCallback);
			}
		}

		public static void RequestNavigate(this IRegionManager source, string regionName, Type viewModelType)
		{
			source.RequestNavigate(regionName, viewModelType, nr => {});
		}
	}
}
