using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.Commands
{
    // Minimal async-capable ICommand implementation used by view models.
    public class DelegateCommand : ICommand
    {
        private readonly Func<object, Task> _executeAsync;
        private readonly Predicate<object>? _canExecute;

        public DelegateCommand(Func<object, Task> executeAsync, Predicate<object>? canExecute = null)
        {
            _executeAsync = executeAsync ?? throw new ArgumentNullException(nameof(executeAsync));
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter!) ?? true;

        public async void Execute(object? parameter) => await _executeAsync(parameter!);

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
