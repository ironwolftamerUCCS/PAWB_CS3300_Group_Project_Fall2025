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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:pawble.database.windows.net,1433;Initial Catalog=PAWBLE;Persist Security Info=False;User ID=PAWBLE;Password=Pawb4Group!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;", options => options.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: new List<int> { 40613 }));

            base.OnConfiguring(optionsBuilder);

        }
    }
}
