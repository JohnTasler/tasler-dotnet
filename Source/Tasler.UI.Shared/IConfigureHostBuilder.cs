using Microsoft.Extensions.Hosting;

#if WINDOWS_UWP
namespace Tasler.UI.Xaml;
#elif WINDOWS_WPF
namespace Tasler.Windows;
#endif

// TODO: NEEDS_UNIT_TESTS

public interface IConfigureHostBuilder
{
	static abstract void ConfigureHostBuilder(IHostApplicationBuilder builder);
}
