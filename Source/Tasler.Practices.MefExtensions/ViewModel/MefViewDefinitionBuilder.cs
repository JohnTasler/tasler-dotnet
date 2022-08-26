using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using Tasler.Practices.Prism.ViewModel;

namespace Tasler.Practices.Prism.MefExtensions.ViewModel
{
	using ExportMetadataItems = IDictionary<string, object>;

	public static class MefViewDefinitionBuilder
	{
		public static IEnumerable<IViewDefinition> GetViewDefinitions(ExportProvider exportProvider, string viewDefinitionContractName)
		{
			var viewDefinitionsExports = exportProvider.GetExports(
				typeof(object),
				typeof(ExportMetadataItems),
				viewDefinitionContractName);

			var viewDefinitions = viewDefinitionsExports.Select(m => new MefViewDefinition((ExportMetadataItems)m.Metadata));
			return viewDefinitions;
		}
	}
}
