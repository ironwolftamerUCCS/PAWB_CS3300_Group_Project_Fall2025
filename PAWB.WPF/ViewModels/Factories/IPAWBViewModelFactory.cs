using PAWB.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.ViewModels.Factories
{
    public interface IPAWBViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
