using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MetrologyDemo.ViewModels
{
    // Base class for all ViewModels, providing property change notification routing
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        // Raises the PropertyChanged event for a given property.
        // propertyName -> The name of the property which has changed (Automatically resolved via CallerMemberName)
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Helper method to set a property value and fire the PropertyChanged event (only if the value actually changed)
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}