using Microsoft.EntityFrameworkCore;
using PAWB.Domain.Model;
using PAWB.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.EntityFramework
{
    /// <summary>
    /// Defines get/set for users, accounts, and entries in the database
    /// </summary>
    public class PAWBDbContext : DbContext
    {
        // Vars
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Entry> Entrys { get; set; }
        public PAWBDbContext(DbContextOptions options) : base(options) { }


    }
}
