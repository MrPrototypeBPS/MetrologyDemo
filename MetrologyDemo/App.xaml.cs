using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MetrologyDemo.Services;
using MetrologyDemo.ViewModels;
using MetrologyDemo.Views;

namespace MetrologyDemo;

/// <summary>
/// Interaction logic for App.xaml. Acts as the Composition Root for the application,
/// configuring Dependency Injection and application lifecycle events.
/// </summary>
public partial class App : Application
{
    private readonly IHost _host;

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// Sets up the Generic Host and registers all services, ViewModels, and Views.
    /// </summary>
    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                // Register Services (Singleton: One instance for the whole app lifecycle)
                services.AddSingleton<IMeasurementDataService, SimulationDataService>();

                // Register ViewModels (Transient: A new instance every time it is requested)
                services.AddTransient<MainViewModel>();

                // Register Views
                services.AddTransient<MainWindow>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();

        // Resolve MainWindow from the DI container. 
        // The container will automatically inject MainViewModel into it!
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();

        // We manually assign the DataContext here to keep MainWindow.xaml.cs empty
        mainWindow.DataContext = _host.Services.GetRequiredService<MainViewModel>();

        mainWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        _host.Dispose();
        base.OnExit(e);
    }
}