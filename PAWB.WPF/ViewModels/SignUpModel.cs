using Microsoft.EntityFrameworkCore;
using PAWB.Domain.Model;
using PAWB.Domain.Services.AuthenticationServices;
using PAWB.EntityFramework;
using PAWB.EntityFramework.Services;
using PAWB.WPF.Commands;
using PAWB.WPF.State.Authenticators;
using PAWB.WPF.State.Navigators;
using PAWB.WPF.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PAWB.WPF.ViewModels
{
    /// <summary>
    /// Initializes SignUpViewModel
    /// </summary>
    public class SignUpModel : ViewModelBase
    {
        // Vars
        private string _email; 
        public string Email 
        { 
            get 
            { 
                return _email; 
            } 
            set 
            { 
                _email = value; 
                OnPropertyChanged(nameof(Email));
            } 
        }

        private string _username;
        public string Username
        {
            get 
            {
                return _username; 
            }
            set 
            { 
                _username = value; 
                OnPropertyChanged(nameof(Username)); 
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _confirmPassword;
        public string ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }
            set
            {
                _confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }

        public ICommand SignUpCommand { get; }

        public ICommand ViewLoginCommand { get; }

        public MessageViewModel ErrorMessageViewModel { get; }
        
        public string ErrorMessage
        {
            set => ErrorMessageViewModel.Message = value;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticator"></param>
        /// <param name="signUpRenavigator"></param>
        /// <param name="loginRenavigator"></param>
        public SignUpModel(IAuthenticator authenticator, IRenavigator signUpRenavigator, IRenavigator loginRenavigator)
        {
            ErrorMessageViewModel = new MessageViewModel();

            SignUpCommand = new SignUpCommand(this, authenticator, signUpRenavigator);
            ViewLoginCommand = new RenavigateCommand(loginRenavigator);
        }
    }
}
