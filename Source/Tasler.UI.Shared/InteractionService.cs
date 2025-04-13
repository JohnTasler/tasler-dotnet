using System.ComponentModel;
using Microsoft.Extensions.Hosting;
using Tasler.ComponentModel;

#if WINDOWS_UWP
using Windows.UI.Xaml;
namespace Tasler.UI.Xaml;

#elif WINDOWS_WPF
using System.Windows;
namespace Tasler.Windows;
#endif


public class InteractionService : IInteractionService
{
	private IHost _host;
	private IViewModelMapper _viewModelMapper;

	public InteractionService(IHost host, IViewModelMapper viewModelMapper)
	{
		_host = host;
		_viewModelMapper = viewModelMapper;
	}

#if WINDOWS_WPF

	public TViewModel? ShowDialog<TViewModel>()
		where TViewModel : class, INotifyPropertyChanged
	{
		var window = _viewModelMapper.GetViewInstanceFor<TViewModel>(_host) as Window;
		var dialogResult = window?.ShowDialog();

		return dialogResult.GetValueOrDefault()
			? (TViewModel)window!.DataContext
			: default;
	}
#endif
}
