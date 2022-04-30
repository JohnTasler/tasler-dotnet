using System;
using System.Diagnostics;

namespace Tasler.Practices.Prism.ViewModel
{
	[DebuggerDisplay("{DisplayName}")]
	public abstract class ViewDefinitionBase : IViewDefinition
	{
		public abstract string DisplayName   { get; }
		public abstract string Description   { get; }
		public abstract string ViewIdentity  { get; }
		public abstract Type   ViewModelType { get; }
	}
}
