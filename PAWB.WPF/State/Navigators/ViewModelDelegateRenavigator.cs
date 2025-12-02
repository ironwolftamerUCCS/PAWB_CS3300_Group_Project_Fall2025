using PAWB.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.State.Navigators
{
    /// <summary>
    /// Defines methods to delegate a navigator to change the viewmodel without using the navigation bar
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public class ViewModelDelegateRenavigator<TViewModel> : IRenavigator where TViewModel : ViewModelBase
    {
        // Vars
        private readonly INavigator _navigator;
        private readonly CreateViewModel<TViewModel> _createViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="navigator"></param>
        /// <param name="createViewModel"></param>
        public ViewModelDelegateRenavigator(INavigator navigator, CreateViewModel<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        /// <summary>
        /// Navigates to new view model
        /// </summary>
        public void Renavigate()
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
