using System.Windows;

namespace MetrologyDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    /// <remarks>
    /// Strict MVVM architectural constraint: This code-behind file is intentionally left 
    /// devoid of business logic, event handlers, or UI manipulation. All view state 
    /// and interaction routing is handled via Data Binding and ICommands in the XAML.
    /// </remarks>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}