namespace Tasler.ComponentModel
{
	public interface IMulitpleSelectionContainer
	{
		IEnumerable<object>? SelectedItems { get; }

		void AddToSelectedItems(object item);
		void RemoveFromSelectedItems(object item);
	}

	public interface IMulitpleSelectionContainer<TItem>
	{
		IEnumerable<TItem>? SelectedItems { get; }

		void AddToSelectedItems(TItem item);
		void RemoveFromSelectedItems(TItem item);
	}
}
