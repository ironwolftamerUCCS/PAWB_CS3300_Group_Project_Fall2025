using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.Domain.Model
{
    /// <summary>
    /// Defines a model “User” containing information on a user 
    /// </summary>
    public class User : DomainObject
    {
        // Vars
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
