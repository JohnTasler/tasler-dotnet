using System.ComponentModel;
using Microsoft.Extensions.Hosting;
using Tasler.ComponentModel;
using Tasler.Windows.ComponentModel;
using Microsoft.Extensions.Logging;



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
	private ILogger _logger;
	private IViewModelMapper _viewModelMapper;

	public InteractionService(IHost host, ILogger<InteractionService> logger, IViewModelMapper viewModelMapper)
	{
		_host = host;
		_logger = logger;
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

	public void ShowWindow<TViewModel>(TViewModel viewModel, bool showActivated)
		where TViewModel : class, INotifyPropertyChanged
	{
		if (_viewModelMapper.GetViewInstanceFor<TViewModel>(_host) is Window window)
		{
			window.DataContext = viewModel;
			window.ShowActivated = showActivated;
			window.Show();
		}
	}
#endif
}
