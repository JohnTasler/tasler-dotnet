using System.ComponentModel;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Markup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tasler.ComponentModel;
using Tasler.ComponentModel.Hosting;

namespace Tasler.Windows;

// TODO: NEEDS_UNIT_TESTS

public abstract class HostedApplication : Application, IProvideHost
{
	protected HostedApplication(IHost host) => Host = host;

	public required IHost Host { get; init; }

	public static new HostedApplication Current => (HostedApplication)Application.Current;

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
	/// <summary>
	/// Initializes and runs a hosted WPF application with dependency injection, view-model mapping,
	/// and host lifecycle management.
	/// </summary>
	/// <typeparam name="TApp">
	/// The application type, which must inherit from <see cref="HostedApplication"/> and implement
	/// <see cref="IComponentConnector"/>, <see cref="IConfigureHostBuilder"/>,
	/// and <see cref="IPopulateViewModelMapper"/>.
	/// </typeparam>
	/// <typeparam name="TMainView">
	/// The main window type, which must inherit from <see cref="Window"/>.
	/// </typeparam>
	/// <typeparam name="TMainViewModel">
	/// The main view model type, which must be a class implementing <see cref="INotifyPropertyChanged"/>.
	/// </typeparam>
	/// <param name="args">Command-line arguments for the application.</param>
	/// <returns>The application's exit code.</returns>
	protected static async Task<int> MainCore<
		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TApp,
		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TMainView,
		[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TMainViewModel>(string[] args)
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
			.AddSingleton<TApp, TApp>()
			.AddSingleton<IViewModelMapper, ViewModelMapper>()
			.AddSingleton<TMainViewModel, TMainViewModel>()
			.AddSingleton<TMainView, TMainView>()
			;
		TApp.ConfigureHostBuilder(builder);

		// Build and start the application host
		var host = builder.Build();
		await host.StartAsync();

		// Create and populate the ViewModelMapper
		var viewModelMapper = host.Services.GetService<IViewModelMapper>()!;
		viewModelMapper.AddMapping<TMainViewModel, TMainView>();
		TApp.Populate(viewModelMapper);

		var loggerProvider = host.Services.GetService<ILoggerProvider>();
		var logger = loggerProvider?.CreateLogger("Tasler.Windows");
		logger?.LogInformation(
			$"Config location: {ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath}");

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
