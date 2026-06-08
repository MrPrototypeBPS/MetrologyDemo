using System;
using System.Windows.Input;

namespace MetrologyDemo.Commands
{
    /// <summary>
    /// A generic command implementation that delegates its execution and 
    /// authorization logic to the ViewModel via delegates.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;

        /// <summary>
        /// Hooks into the WPF CommandManager to automatically re-evaluate command 
        /// execution states when UI interactions occur.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The synchronous action to execute.</param>
        /// <param name="canExecute">Optional function dictating whether the command can execute.</param>
        /// <exception cref="ArgumentNullException">Thrown if the execution action is null.</exception>
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

        public void Execute(object? parameter) => _execute();
    }
}