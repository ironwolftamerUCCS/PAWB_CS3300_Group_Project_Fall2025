using PAWB.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.ViewModels.Factories
{
    /// <summary>
    /// An interface declaring a method to initialize a requested viewmodel
    /// </summary>
    public interface IPAWBViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
