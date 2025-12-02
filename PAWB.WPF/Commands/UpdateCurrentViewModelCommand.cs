using PAWB.WPF.State.Navigators;
using PAWB.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.Commands
{
    /// <summary>
    /// Updates viewmodel based on user navigation
    /// </summary>
    public class UpdateCurrentViewModelCommand : ICommand
    {
        // Vars
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IPAWBViewModelFactory _viewModelFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navigator"></param>
        /// <param name="viewModelFactory"></param>
        public UpdateCurrentViewModelCommand(INavigator navigator, IPAWBViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        /// <summary>
        /// Holds whether or not command can execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Updates the view model
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;

                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
