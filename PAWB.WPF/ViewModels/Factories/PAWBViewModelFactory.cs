using PAWB.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Initilization of each view model
namespace PAWB.WPF.ViewModels.Factories
{
    public class PAWBViewModelFactory : IPAWBViewModelFactory
    {
        //Creating variables representing each view model
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;

        //Initializing each variable
        public PAWBViewModelFactory(CreateViewModel<LoginViewModel> createLoginViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
        }
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            //Method matching the ViewType is returned
            switch(viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                default:
                    throw new ArgumentException("This ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
