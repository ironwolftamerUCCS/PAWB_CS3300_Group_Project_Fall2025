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
    public class PAWBDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Entry> Entrys { get; set; }
        public PAWBDbContext(DbContextOptions options) : base(options) { }


    }
}
