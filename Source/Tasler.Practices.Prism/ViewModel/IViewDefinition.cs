using System;

namespace Tasler.Practices.Prism.ViewModel
{
	public interface IViewDefinition
	{
		string DisplayName   { get; }
		string Description   { get; }
		string ViewIdentity  { get; }
		Type   ViewModelType { get; }
	}
}
