using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.Commands
{
    /// <summary>
    /// Class to handle async commands
    /// </summary>
    public abstract class AsyncCommandBase : ICommand
    {
        // Vars
        private bool _isExecuting;
        public bool IsExecuting
        {
            get { return _isExecuting; }
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return !IsExecuting;
        }

        /// <summary>
        /// Executes the command normally
        /// </summary>
        /// <param name="parameter"></param>
        public async void Execute(object parameter)
        {
            IsExecuting = true;

            await ExecuteAsync(parameter);

            IsExecuting = false;
        }

        /// <summary>
        /// Executes the command async style
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract Task ExecuteAsync(object parameter);
    }
}
