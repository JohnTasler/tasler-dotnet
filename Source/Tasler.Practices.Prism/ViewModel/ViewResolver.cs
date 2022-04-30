using System;
using System.Collections.Generic;

namespace Tasler.Practices.Prism.ViewModel
{
	public abstract class ViewResolver : IViewResolver
	{
		private Dictionary<Type, Type> resolvedTypeCache = new Dictionary<Type,Type>();

		protected abstract bool OnResolveViewFromViewModel(Type viewModelType, out Type viewType);

		#region IViewResolver Members

		public Type ResolveViewFromViewModel(Type viewModelType)
		{
			if (viewModelType == null)
				throw new ArgumentNullException("viewModelType");

			Type viewType = null;
			if (this.resolvedTypeCache.TryGetValue(viewModelType, out viewType))
				return viewType;

			if (!this.OnResolveViewFromViewModel(viewModelType, out viewType) || viewType == null)
				throw new Exception(string.Format("Resources.Cannot resolve view type from view model type: {0}", viewModelType.FullName));

			this.resolvedTypeCache.Add(viewModelType, viewType);
			return viewType;
		}

		#endregion IViewResolver Members
	}
}
