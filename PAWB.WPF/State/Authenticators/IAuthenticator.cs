using PAWB.Domain.Model;
using PAWB.Domain.Models;
using PAWB.Domain.Services.AuthenticationServices;
using PAWB.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        Account CurrentAccount { get; }
        bool IsLoggedIn { get; }

        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);

        /// <summary>
        /// Login to the application
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <exception cref="UserNotFoundException">Thrown if the user does not exist</exception>
        /// <exception cref="InvalidPasswordException">Thrown if the password is invalid</exception>
        /// <exception cref="Exception">Thrown if the login fails</exception>
        Task Login(string username, string password);
        void Logout();
    }
}
