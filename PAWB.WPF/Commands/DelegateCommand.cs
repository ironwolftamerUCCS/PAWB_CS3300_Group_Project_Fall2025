using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.Commands
{
    /// <summary>
    /// Async command ICommand implementation for view models
    /// </summary>
    public class DelegateCommand : ICommand
    {
        // Vars
        private readonly Func<object, Task> _executeAsync;
        private readonly Predicate<object>? _canExecute;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="executeAsync"></param>
        /// <param name="canExecute"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DelegateCommand(Func<object, Task> executeAsync, Predicate<object>? canExecute = null)
        {
            _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Changes the can execute bool
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Determines if the command can execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter!) ?? true;

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="parameter"></param>
        public async void Execute(object? parameter) => await _executeAsync(parameter!);

        /// <summary>
        /// Flipds the can execute bool
        /// </summary>
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
