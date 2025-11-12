using PAWB.WPF.Commands;
using PAWB.WPF.State.Authenticators;
using PAWB.WPF.State.Navigators;
using PAWB.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IPAWBViewModelFactory _viewModelFactory;
        public INavigator Navigator { get; set; }
        public IAuthenticator Authenticator { get; }
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(INavigator navigator, IAuthenticator authenticator, IPAWBViewModelFactory viewModelFactory)
        {
            Navigator = navigator;
            _viewModelFactory = viewModelFactory;
            Authenticator = authenticator;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }
    }

}
