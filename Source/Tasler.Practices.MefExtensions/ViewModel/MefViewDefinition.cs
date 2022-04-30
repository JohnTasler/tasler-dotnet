using System;
using System.Collections.Generic;
using System.Linq;
using Tasler.Extensions;
using Tasler.Practices.Prism.ViewModel;

namespace Tasler.Practices.Prism.MefExtensions.ViewModel
{
	public class MefViewDefinition : ViewDefinitionBase
	{
		private IDictionary<string, object> exportMetadataDictionary;

		public MefViewDefinition(IDictionary<string, object> exportMetadataDictionary)
		{
			this.exportMetadataDictionary = exportMetadataDictionary;
		}

		#region IViewDefinition Members

		public override string DisplayName
		{
			get
			{
				return this.exportMetadataDictionary.GetValueAsType<string>(ViewDefinitionKeys.DisplayName, null)
					?? ViewIdentity.Split('.').Last();
			}
		}

		public override string Description
		{
			get { return this.exportMetadataDictionary.GetValueAsType<string>(ViewDefinitionKeys.Description, string.Empty); }
		}

		public override string ViewIdentity
		{
			get
			{
				var result = this.exportMetadataDictionary.GetValueAsType<string>(ViewDefinitionKeys.ViewIdentity, null);
				if (result == null)
					throw new InvalidOperationException();
				return result;
			}
		}

		public override Type ViewModelType
		{
			get { return this.exportMetadataDictionary.GetValueAsType<Type>(ViewDefinitionKeys.ViewModelType, typeof(object)); }
		}

		#endregion IViewDefinition Members
	}
}
