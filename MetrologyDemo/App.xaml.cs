using System.Windows;
using MetrologyDemo.ViewModels;
using MetrologyDemo.Views;

namespace MetrologyDemo
{
    /// <summary>
    /// Interaction logic for App.xaml.
    /// Acts as the Composition Root for the application, handling manual dependency injection
    /// and ViewModel-First or View-First wiring.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Handles the application startup event to initialize and wire the main UI components.
        /// </summary>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // NOTE: In a full-scale .NET 10 production app, this manual wiring would be 
            // replaced by a DI container (e.g., Microsoft.Extensions.DependencyInjection).
            // For this demo, manual composition is used to keep dependencies lightweight.

            var mainViewModel = new MainViewModel();
            var mainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };

            mainWindow.Show();
        }
    }
}