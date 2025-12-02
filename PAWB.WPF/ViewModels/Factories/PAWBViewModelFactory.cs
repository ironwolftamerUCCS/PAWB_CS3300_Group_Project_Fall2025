using PAWB.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PAWB.WPF.ViewModels; // for SignUpModel, LoginViewModel, HomeViewModel

//Initilization of each view model
namespace PAWB.WPF.ViewModels.Factories
{
    /// <summary>
    /// Implements IPAWBViewModelFactory.cs
    /// Creates view models
    /// </summary>
    public class PAWBViewModelFactory : IPAWBViewModelFactory
    {
        //Creating variables representing each view model
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<SignUpModel> _createSignUpViewModel;

        //Initializing each variable
        public PAWBViewModelFactory(
            CreateViewModel<LoginViewModel> createLoginViewModel,
            CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<SignUpModel> createSignUpViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
            _createHomeViewModel = createHomeViewModel;
            _createSignUpViewModel = createSignUpViewModel;
        }

        /// <summary>
        /// Creates the view models
        /// </summary>
        /// <param name="viewType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.SignUp:
                    return _createSignUpViewModel();
                default:
                    throw new ArgumentException("This ViewType does not have a ViewModel.", nameof(viewType));
            }
        }
    }
}
