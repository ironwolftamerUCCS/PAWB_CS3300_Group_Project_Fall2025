using PAWB.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.Domain.Models
{
    public class Account : DomainObject
    {
        public User AccountHolder { get; set; }

        public ICollection<Entry> Entries { get; set; } //A collection of entries held by an account
    }
}
