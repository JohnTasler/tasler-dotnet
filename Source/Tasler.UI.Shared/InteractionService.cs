using System.ComponentModel;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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
		if (_viewModelMapper.GetViewInstanceFor<TViewModel>(_host) is not Window window)
			throw CreateNoViewFoundException<TViewModel>();

		_logger.LogInformation("Showing modal dialog of type {WindowType} for view model of type {ViewModelType}", window.GetType().FullName, typeof(TViewModel).FullName);
		var dialogResult = window?.ShowDialog();

		return dialogResult.GetValueOrDefault()
			? (TViewModel)window!.DataContext
			: default;
	}

	public void ShowWindow<TViewModel>(TViewModel viewModel, bool showActivated)
		where TViewModel : class, INotifyPropertyChanged
	{
		if (_viewModelMapper.GetViewInstanceFor<TViewModel>(_host) is not Window window)
			throw CreateNoViewFoundException<TViewModel>();

		_logger.LogInformation("Showing window of type {WindowType} for view model of type {ViewModelType}", window.GetType().FullName, typeof(TViewModel).FullName);
		window.DataContext = viewModel;
		window.ShowActivated = showActivated;
		window.Show();
	}
#endif

	private static ArgumentException CreateNoViewFoundException<TViewModel>()
	{
		// Figure out how to use RESX file for this message (in Shared project type, and still share the RESX):
		// Properties.Resources.NoViewFoundForViewModelFormat1
		var message = string.Format("No view found for view model of type {0}", typeof(TViewModel).FullName);
		return new ArgumentException(message);
	}
}
