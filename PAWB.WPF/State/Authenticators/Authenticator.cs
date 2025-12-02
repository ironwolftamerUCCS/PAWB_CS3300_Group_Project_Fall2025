using PAWB.Domain.Model;
using PAWB.Domain.Models;
using PAWB.Domain.Services.AuthenticationServices;
using PAWB.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.State.Authenticators
{
    /// <summary>
    /// Implements IAuthenticator.cs 
    /// Calls login and register functions initiated by the view models and keeps track of current user and logged in status
    /// </summary>
    public class Authenticator : ObservableObjects, IAuthenticator
    {
        // Vars
        private readonly IAuthenticationService _authenticationService;

        private Account _currentAccount;

        public Account CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            private set
            {
                _currentAccount = value;
                OnPropertyChanged(nameof(CurrentAccount));
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationService"></param>
        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Attempts login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task Login(string username, string password)
        {
            CurrentAccount = await _authenticationService.Login(username, password);
        }

        /// <summary>
        /// Logs out current user
        /// </summary>
        public void Logout()
        {
            CurrentAccount = null;
        }

        /// <summary>
        /// Attempts registration
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="confirmPassword"></param>
        /// <returns></returns>
        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            return await _authenticationService.Register(email, username, password, confirmPassword);
        }
    }
}
