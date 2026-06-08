using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MetrologyDemo.Models;
using MetrologyDemo.Commands;

namespace MetrologyDemo.ViewModels
{
    /// <summary>
    /// Orchestrates the data flow and user interactions for the primary CMM dashboard.
    /// Completely isolated from UI framework dependencies to allow for easy unit testing.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private bool _isBusy;

        /// <summary>
        /// Exposes the coordinate dataset to the View. 
        /// Using ObservableCollection ensures the DataGrid updates automatically when points are added/removed.
        /// </summary>
        public ObservableCollection<MeasurementPoint> MeasurementPoints { get; }

        /// <summary>
        /// Command bound to the UI to trigger the coordinate parsing process.
        /// </summary>
        public ICommand LoadDataCommand { get; }

        /// <summary>
        /// Indicates if a background operation (like parsing a massive point cloud) is running.
        /// Used by the View to toggle loading indicators and disable redundant button clicks.
        /// </summary>
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public MainViewModel()
        {
            MeasurementPoints = new ObservableCollection<MeasurementPoint>();

            // The command is disabled automatically if IsBusy is true
            LoadDataCommand = new RelayCommand(async () => await LoadDataAsync(), () => !IsBusy);
        }

        /// <summary>
        /// Simulates the asynchronous ingestion of a Point Cloud CSV or direct CMM hardware feed.
        /// </summary>
        private async Task LoadDataAsync()
        {
            IsBusy = true;
            CommandManager.InvalidateRequerySuggested(); // Force UI to disable the Load button

            try
            {
                MeasurementPoints.Clear();

                // Simulate the latency of I/O operations (e.g., reading a multi-gigabyte .csv or .xyz file)
                // Using Task.Delay prevents blocking the primary UI thread.
                await Task.Delay(1500);

                var random = new Random();

                // TODO: Replace simulation with an actual IDataReader implementation or hardware SDK hook.
                // Generate a bounding box of 100x100x50mm for demo visualization.
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
                CommandManager.InvalidateRequerySuggested(); // Force UI to re-enable the Load button
            }
        }
    }
}