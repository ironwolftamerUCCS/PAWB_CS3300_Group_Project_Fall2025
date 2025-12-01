using PAWB.WPF.State.Authenticators;
using PAWB.WPF.State.Navigators;
using PAWB.WPF.ViewModels;
using PAWB.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.Commands
{
    public class SignUpCommand : AsyncCommandBase
    {
        private readonly SignUpModel _signUpModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public SignUpCommand(SignUpModel signUpModel, IAuthenticator authenticator, IRenavigator signUpRenavigator)
        {
            _signUpModel = signUpModel;
            _authenticator = authenticator;
            _renavigator = signUpRenavigator;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _signUpModel.ErrorMessage = string.Empty;

            try
            {
                RegistrationResult registrationResult = await _authenticator.Register(
                    _signUpModel.Email,
                    _signUpModel.Username,
                    _signUpModel.Password,
                    _signUpModel.ConfirmPassword);

                switch (registrationResult)
                {
                    case RegistrationResult.Success:
                        _renavigator.Renavigate();
                        break;
                    case RegistrationResult.PasswordsDoNotMatch:
                        _signUpModel.ErrorMessage = "Passwords do not match.";
                        break;
                    case RegistrationResult.UsernameAlreadyExists:
                        _signUpModel.ErrorMessage = "Username already exists.";
                        break;
                    case RegistrationResult.EmailAlreadyExists:
                        _signUpModel.ErrorMessage = "Email already exists.";
                        break;
                    default:
                        _signUpModel.ErrorMessage = "Registration failed.";
                        break;
                }
            }
            catch (Exception)
            {
                _signUpModel.ErrorMessage = "Registration failed.";
            }
        }
    }
}
