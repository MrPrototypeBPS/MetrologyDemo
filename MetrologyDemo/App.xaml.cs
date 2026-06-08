using System.Windows;
using MetrologyDemo.ViewModels;
using MetrologyDemo.Views;

namespace MetrologyDemo
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            // Inject the ViewModel into the View
            var mainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };

            mainWindow.Show();
        }
    }
}