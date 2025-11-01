using PAWB.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        Task<bool> Resister(string email, string username, string password, string confirmPassword);
        Task<Account> Login(string username, string password);
    }
}
