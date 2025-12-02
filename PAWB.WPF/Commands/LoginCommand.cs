using PAWB.Domain.Exceptions;
using PAWB.WPF.State.Authenticators;
using PAWB.WPF.State.Navigators;
using PAWB.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAWB.WPF.Commands
{
    /// <summary>
    /// Defines command to login user with a specified account
    /// </summary>
    public class LoginCommand : ICommand
    {
        // Vars
        private readonly LoginViewModel _loginViewModel;
        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator; 

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <param name="authenticator"></param>
        /// <param name="renavigator"></param>
        public LoginCommand(LoginViewModel loginViewModel, IAuthenticator authenticator, IRenavigator renavigator)
        {
            _loginViewModel = loginViewModel;
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        /// <summary>
        /// Runs when can execute bool changes
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Returns whether or not command can execute
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Attempts to log the user in with information given from login view
        /// </summary>
        /// <param name="parameter"></param>
        public async void Execute(object? parameter)
        {
            _loginViewModel.ErrorMessage = String.Empty;

            try
            {
                await _authenticator.Login(_loginViewModel.Username, parameter.ToString());

                _renavigator.Renavigate();
            }
            catch (UserNotFoundException)
            {
                _loginViewModel.ErrorMessage = "Username does not exist.";
            }
            catch (InvalidPasswordException)
            {
                _loginViewModel.ErrorMessage = "Password is incorrect.";
            }
            catch (Exception)
            {
                _loginViewModel.ErrorMessage = "Login failed.";
            }
        }
    }
}
