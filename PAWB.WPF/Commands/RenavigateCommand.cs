using PAWB.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.Commands
{
    /// <summary>
    /// Defines renavigate command for login and signup page navigation
    /// </summary>
    public class RenavigateCommand : ICommand
    {
        // Vars
        private readonly IRenavigator _renavigator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="renavigator"></param>
        public RenavigateCommand(IRenavigator renavigator)
        {
            _renavigator = renavigator;
        }

        /// <summary>
        /// Changes the can execute bool
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Holds whether or not command can execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            _renavigator.Renavigate();
        }
    }
}
