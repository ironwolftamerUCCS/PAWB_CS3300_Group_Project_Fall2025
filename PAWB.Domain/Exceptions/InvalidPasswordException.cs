using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.Domain.Exceptions
{
    /// <summary>
    ///  Defines custom exception for a user entering an invalid password
    /// </summary>
    public class InvalidPasswordException : Exception
    {
        // Vars
        public string Username { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public InvalidPasswordException(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
