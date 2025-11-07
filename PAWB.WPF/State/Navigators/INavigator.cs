using PAWB.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.State.Navigators
{
    public enum ViewType
    {
        Login,
        Home
    }
    public interface INavigator
    {
        //Current ViewModel of the application
        ViewModelBase CurrentViewModel { get; set; }
    }
}
