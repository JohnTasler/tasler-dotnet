using System.ComponentModel;

namespace Tasler.ComponentModel;

public interface IInteractionService
{
	TViewModel? ShowDialog<TViewModel>()
		where TViewModel : class, INotifyPropertyChanged;
}
