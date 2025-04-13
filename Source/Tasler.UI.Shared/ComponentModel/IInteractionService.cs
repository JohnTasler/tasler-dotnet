using System.ComponentModel;

namespace Tasler.ComponentModel;

public interface IInteractionService
{
#if WINDOWS_WPF
	TViewModel? ShowDialog<TViewModel>()
		where TViewModel : class, INotifyPropertyChanged;
#endif
}
