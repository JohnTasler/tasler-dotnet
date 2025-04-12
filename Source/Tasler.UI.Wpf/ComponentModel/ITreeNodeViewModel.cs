using System.ComponentModel;

namespace Tasler.Windows.ComponentModel;

public interface ITreeNodeViewModel
{
	bool IsExpanded { get; set; }
	bool IsSelected { get; set; }
	ICollectionView? Children { get; }
}
