using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.Models
{
    /// <summary>
    /// Get/set information for account entries 
    /// </summary>
    public class InfoItem
    {
       
        public string Title { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
