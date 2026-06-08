using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MetrologyDemo.ViewModels
{
    /// <summary>
    /// Base class for all ViewModels, providing standard INotifyPropertyChanged implementation
    /// to facilitate decoupled two-way data binding in WPF.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes, notifying the View to update its rendering.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">
        /// The name of the property that changed. Automatically resolved by the compiler 
        /// via [CallerMemberName] to prevent magic string errors.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Updates the backing field and triggers UI notification only if the new value 
        /// differs from the current value. Prevents infinite binding loops and redundant UI layouts.
        /// </summary>
        /// <typeparam name="T">The type of the property.</typeparam>
        /// <param name="storage">Reference to the backing field.</param>
        /// <param name="value">The new value to apply.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>True if the value was changed; otherwise, false.</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}