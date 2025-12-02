using PAWB.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.State.Navigators
{
    /// <summary>
    /// Enum for view type
    /// </summary>
    public enum ViewType
    {
        Login,
        Home,
        SignUp
    }

    /// <summary>
    /// An interface declaring a method to change the current viewmodel using the navigation bar
    /// </summary>
    public interface INavigator
    {
        //Current ViewModel of the application
        ViewModelBase CurrentViewModel { get; set; }
    }
}
