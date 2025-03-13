using System.Linq;
using Microsoft.Practices.ServiceLocation;

namespace Tasler.ComponentModel.Extensions
{
	public static class ServiceLocatorExtensions
	{
		public static TService GetInstanceIfAny<TService>(this IServiceLocator @this)
			where TService : class
		{
			return @this.GetAllInstances<TService>().FirstOrDefault();
		}
	}
}
