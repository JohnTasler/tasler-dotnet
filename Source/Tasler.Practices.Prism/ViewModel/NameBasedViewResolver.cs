using System;
using System.Linq;

namespace Tasler.Practices.Prism.ViewModel
{
	public class NameBasedViewResolver : ViewResolver
	{
		protected override bool OnResolveViewFromViewModel(Type viewModelType, out Type viewType)
		{
			viewType = null;

			var suffix = "ViewModel";
			var nameParts = viewModelType.FullName.Split('.');
			var name = nameParts[nameParts.Length - 1];
			var vmIndex = name.LastIndexOf(suffix);
			if (vmIndex < 0 || (vmIndex + suffix.Length) != name.Length)
				return false;
			nameParts[nameParts.Length - 1] = name.Substring(0, vmIndex) + "View";

			var suffixMappings = new []
			{
				new { VmSuffix = "ViewModel" , ViewSuffix = "View"  },
				new { VmSuffix = "ViewModels", ViewSuffix = "Views" },
			};

			var indices = nameParts.Reverse().Skip(1)
				.Where(np => suffixMappings.Any(sf => np.EndsWith(sf.VmSuffix)))
				.Select((np, i) => nameParts.Length - 2 - i);

			foreach (var index in indices)
			{
				var namePart = nameParts[index];
				var mapping = suffixMappings
					.Where(sf => namePart.EndsWith(sf.VmSuffix))
					.First();

				nameParts[index] = namePart.Substring(0, namePart.Length - mapping.VmSuffix.Length) + mapping.ViewSuffix;
			}

			var viewTypeName = string.Join(".", nameParts);
			viewType = viewModelType.Assembly.GetType(viewTypeName);
			return viewType != null;
		}
	}
}
