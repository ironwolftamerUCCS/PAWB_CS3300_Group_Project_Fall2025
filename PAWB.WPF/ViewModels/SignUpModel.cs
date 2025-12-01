using PAWB.Domain.Models;
using PAWB.Domain.Services.AuthenticationServices;
using PAWB.WPF.State.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.ViewModels
{
    public class SignUpModel : ViewModelBase
    {
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

        public SignUpModel(IAuthenticator authenticator, IRenavigator signUpRenavigator, IRenavigator loginRenavigator)
        {

        }
    }
}
