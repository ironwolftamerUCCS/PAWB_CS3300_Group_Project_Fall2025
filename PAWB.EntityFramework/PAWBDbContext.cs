using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PAWB.Domain.Model;

namespace PAWB.EntityFramework
{
    public class PAWBDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Entry> Entrys { get; set; }

        public PAWBDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
