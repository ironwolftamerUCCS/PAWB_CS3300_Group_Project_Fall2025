using PAWB.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.Domain.Services
{
    /// <summary>
    /// Defines an interface containing methods declared to get a user’s account by username and by email
    /// </summary>
    public interface IAccountService : IDataService<Account>
    {
        Task<Account> GetByUsername(string username);
        Task<Account> GetByEmail(string email);
    }
}
