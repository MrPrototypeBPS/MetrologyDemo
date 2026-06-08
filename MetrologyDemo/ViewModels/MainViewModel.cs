using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MetrologyDemo.Models;
using MetrologyDemo.Commands;

namespace MetrologyDemo.ViewModels
{
    // Orchestrates the data flow and UI interactions for the Main Window
    public class MainViewModel : ViewModelBase
    {
        private bool _isBusy;

        // Gets the collection of spatial points currently loaded into memory
        public ObservableCollection<MeasurementPoint> MeasurementPoints { get; }

        // Command to trigger the asynchronous loading of coordinate data
        public ICommand LoadDataCommand { get; }

        // Indicates whether a background operation is currently running
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public MainViewModel()
        {
            MeasurementPoints = new ObservableCollection<MeasurementPoint>();
            LoadDataCommand = new RelayCommand(async () => await LoadDataAsync(), () => !IsBusy);
        }

        // Asynchronously loads dummy CMM coordinate data into the observable collection
        private async Task LoadDataAsync()
        {
            IsBusy = true;
            CommandManager.InvalidateRequerySuggested(); // Refresh command states

            try
            {
                MeasurementPoints.Clear();

                // Simulate file I/O or database access delay (e.g. for loading massive point clouds)
                await Task.Delay(1500);

                var random = new Random();

                // Generate a dummy dataset of simulated 3D scan points
                for (int i = 0; i < 100; i++)
                {
                    MeasurementPoints.Add(new MeasurementPoint
                    {
                        X = Math.Round(random.NextDouble() * 100, 4),
                        Y = Math.Round(random.NextDouble() * 100, 4),
                        Z = Math.Round(random.NextDouble() * 50, 4)
                    });
                }
            }
            finally
            {
                IsBusy = false;
                CommandManager.InvalidateRequerySuggested();
            }
        }
    }
}