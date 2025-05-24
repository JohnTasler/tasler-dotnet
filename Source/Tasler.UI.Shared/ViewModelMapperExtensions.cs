using System.ComponentModel;
using Microsoft.Extensions.Hosting;
using Tasler.ComponentModel;

#if WINDOWS_UWP
using Windows.Foundation;
using Windows.UI.Xaml;
namespace Tasler.UI.Xaml;
#elif WINDOWS_WPF
using System.Windows;
namespace Tasler.Windows;
#endif

// TODO: NEEDS_UNIT_TESTS

public static class ViewModelMapperExtensions
{
	public static IViewModelMapper AddMapping<TViewModel, TView>(this IViewModelMapper @this)
		where TViewModel : class, INotifyPropertyChanged
		where TView : FrameworkElement
	{
		@this.AddMapping(typeof(TViewModel), typeof(TView));
		return @this;
	}

	public static FrameworkElement GetViewInstanceFor(this IViewModelMapper @this, IHost host, Type viewModelType)
	{
		Type viewType = @this.GetViewTypeForViewModelType(viewModelType);
		return (FrameworkElement)host.Services.GetService(viewType)!;
	}

	public static FrameworkElement GetViewInstanceFor<TViewModel>(this IViewModelMapper @this, IHost host)
	{
		return @this.GetViewInstanceFor(host, typeof(TViewModel));
	}
}
