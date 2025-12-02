using PAWB.WPF.Models;
using PAWB.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.State.Navigators
{
    /// <summary>
    /// Implements INavigator.cs
    /// Navigates to new view models
    /// </summary>
    public class Navigator : ObservableObjects, INavigator
    {
        // Vars
        private ViewModelBase _currentViewModel;

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));

            }
        }

          

    }
}
