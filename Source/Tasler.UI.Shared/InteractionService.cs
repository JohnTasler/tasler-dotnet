using System.ComponentModel;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Tasler.ComponentModel;

namespace Tasler.Windows;

public class InteractionService : IInteractionService
{
	private IHost _host;
	private IViewModelMapper _viewModelMapper;

	public InteractionService(IHost host, IViewModelMapper viewModelMapper)
	{
		_host = host;
		_viewModelMapper = viewModelMapper;
	}

	public TViewModel? ShowDialog<TViewModel>()
		where TViewModel : class, INotifyPropertyChanged
	{
		var window = _viewModelMapper.GetViewInstanceFor<TViewModel>(_host) as Window;
		var dialogResult = window?.ShowDialog();

		return dialogResult.GetValueOrDefault()
			? (TViewModel)window!.DataContext
			: default;
	}
}
