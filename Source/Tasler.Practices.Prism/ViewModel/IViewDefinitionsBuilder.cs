using System.Collections.Generic;

namespace Tasler.Practices.Prism.ViewModel
{
	public interface IViewDefinitionsBuilder
	{
		IEnumerable<IViewDefinition> ViewDefinitions { get; }
	}
}
