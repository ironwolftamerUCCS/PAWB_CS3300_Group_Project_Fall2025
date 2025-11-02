using PAWB.Domain.Model;
using PAWB.Domain.Models;
using PAWB.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public Account CurrentAccount { get; private set; }

        public bool IsLoggedIn => CurrentAccount != null;

        public event Action StateChanged;

        public async Task<bool> Login(string username, string password)
        {
            bool success = true;
            try
            {
                CurrentAccount = await _authenticationService.Login(username, password);
            }
            catch (Exception)
            {

                success = false;
            }
            return success;
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            return await _authenticationService.Resister(email, username, password, confirmPassword);
        }
    }
}
