using System.Collections.Generic;

namespace Tasler.ComponentModel
{
	public interface IMulitpleSelectionContainer
	{
		IEnumerable<object> SelectedItems { get; }

		void AddToSelectedItems(object item);
		void RemoveFromSelectedItems(object item);
	}
}
