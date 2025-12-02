using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.Domain.Exceptions
{
    /// <summary>
    /// Defines custom exception for a user entering an invalid username
    /// </summary>
    public class UserNotFoundException : Exception
    {
        // Vars
        public string Username { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="username"></param>
        public UserNotFoundException(string username)
        {
            Username = username;
        }
    }
}
