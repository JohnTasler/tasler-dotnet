using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tasler.ComponentModel;
using Tasler.ComponentModel.Hosting;

namespace Tasler.Windows;

// TODO: NEEDS_UNIT_TESTS

public abstract class HostedApplication : Application, IProvideHost
{
	protected HostedApplication(IHost host) => Host = host;

	public required IHost Host { get; init; }

	protected override void OnStartup(StartupEventArgs e)
	{
		base.OnStartup(e);
		MainWindow.Show();
	}

	protected override void OnExit(ExitEventArgs e)
	{
		Host.StopAsync().Wait();
		base.OnExit(e);
	}

	/// <summary>
	/// Application Entry Point worker
	/// </summary>
	protected static int MainCore<TApp, TMainView, TMainViewModel>(string[] args)
		where TApp
			: HostedApplication
			, IComponentConnector
			, IConfigureHostBuilder
			, IPopulateViewModelMapper
		where TMainView : Window
		where TMainViewModel : class, INotifyPropertyChanged
	{
		var builder = Microsoft.Extensions.Hosting.Host.CreateApplicationBuilder(args);

		// Add services
		builder.Services
			.AddActivatedSingleton<TApp, TApp>()
			.AddActivatedSingleton<IViewModelMapper, ViewModelMapper>()
			.AddActivatedSingleton<TMainViewModel, TMainViewModel>()
			.AddSingleton<TMainView, TMainView>()
			;
		TApp.ConfigureHostBuilder(builder);

		// Build and start the application host
		var host = builder.Build();
		host.StartAsync().Wait();

		// Create and populate the ViewModelMapper
		var viewModelMapper = host.Services.GetService<IViewModelMapper>()!;
		viewModelMapper.AddMapping<TMainViewModel, TMainView>();
		TApp.Populate(viewModelMapper);

		// Create, initialize, and run the application
		var app = host.Services.GetService<TApp>()!;
		app.InitializeComponent();
		app.MainWindow = (Window)viewModelMapper.GetViewInstanceFor<TMainViewModel>(host);
		var returnValue = app.Run()!;

		// Host shutdown will be triggered by the OnExit override
		host.WaitForShutdown();
		return returnValue;
	}
}
