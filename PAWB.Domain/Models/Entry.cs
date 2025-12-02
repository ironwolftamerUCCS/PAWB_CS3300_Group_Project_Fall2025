using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.Domain.Model
{
    /// <summary>
    /// Defines a model “Entry” containing information attached to a credential entry
    /// </summary>
    public class Entry : DomainObject
    {
        // Vars
        public string Title { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public User Owner { get; set; }
        public string? Note { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime PasswordLastUpdated { get; set; }
        public LinkedList<string>? PreviousPasswords { get; set; }
    }
}
