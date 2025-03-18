
namespace Tasler.ComponentModel
{
	public interface ISingleSelectionContainer
	{
		object? SelectedItem { get; set; }
	}

	public interface ISingleSelectionContainer<TItem>
	{
		TItem? SelectedItem { get; set; }
	}
}
