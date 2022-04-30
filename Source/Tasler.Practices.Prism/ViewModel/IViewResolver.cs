using System;

namespace Tasler.Practices.Prism.ViewModel
{
	public interface IViewResolver
	{
		Type ResolveViewFromViewModel(Type viewModelType);
	}
}
