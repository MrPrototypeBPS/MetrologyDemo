using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using MetrologyDemo.Models;
using MetrologyDemo.Commands;
using MetrologyDemo.Services;

namespace MetrologyDemo.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly IMeasurementDataService _dataService;
    private bool _isBusy;
    private string? _errorMessage;

    public ObservableCollection<MeasurementPoint> MeasurementPoints { get; }
    public ICommand LoadDataCommand { get; }

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    // New property to expose errors to the UI
    public string? ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    // DEPENDENCY INJECTION: We ask for the interface, not the concrete implementation
    public MainViewModel(IMeasurementDataService dataService)
    {
        _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));

        MeasurementPoints = new ObservableCollection<MeasurementPoint>();
        LoadDataCommand = new RelayCommand(async () => await LoadDataAsync(), () => !IsBusy);
    }

    private async Task LoadDataAsync()
    {
        IsBusy = true;
        ErrorMessage = null; // Clear previous errors
        CommandManager.InvalidateRequerySuggested();

        // Set up cancellation (e.g., timeout after 5 seconds)
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

        try
        {
            MeasurementPoints.Clear();

            // Await the service, passing the cancellation token
            var data = await _dataService.GetMeasurementDataAsync(cts.Token);

            foreach (var point in data)
            {
                MeasurementPoints.Add(point);
            }
        }
        catch (OperationCanceledException)
        {
            ErrorMessage = "The data loading operation timed out.";
        }
        catch (Exception ex)
        {
            // Catching hardware failures or other unexpected errors
            ErrorMessage = $"Error loading data: {ex.Message}";
        }
        finally
        {
            IsBusy = false;
            CommandManager.InvalidateRequerySuggested();
        }
    }
}