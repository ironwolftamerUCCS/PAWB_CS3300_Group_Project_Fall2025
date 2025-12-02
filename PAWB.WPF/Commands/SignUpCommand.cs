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
using Microsoft.IdentityModel.Tokens;
using System.Windows.Documents;

namespace PAWB.WPF.Commands
{
    /// <summary>
    /// Completes new user registration
    /// </summary>
    public class SignUpCommand : AsyncCommandBase
    {
        // Vars
        private readonly SignUpModel _signUpModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signUpModel"></param>
        /// <param name="authenticator"></param>
        /// <param name="signUpRenavigator"></param>
        public SignUpCommand(SignUpModel signUpModel, IAuthenticator authenticator, IRenavigator signUpRenavigator)
        {
            _signUpModel = signUpModel;
            _authenticator = authenticator;
            _renavigator = signUpRenavigator;
        }

        /// <summary>
        /// Attempts to execute a new registration for a new user. Will error if unsuccessful
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task ExecuteAsync(object parameter)
        {
            _signUpModel.ErrorMessage = string.Empty;

            try
            {
                if (_signUpModel.Email.IsNullOrEmpty() || _signUpModel.Username.IsNullOrEmpty() ||
                    _signUpModel.Password.IsNullOrEmpty() || _signUpModel.ConfirmPassword.IsNullOrEmpty())
                {
                    _signUpModel.ErrorMessage = "One of more fields are empty. Please fill out all fields.";
                    return;
                }

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
