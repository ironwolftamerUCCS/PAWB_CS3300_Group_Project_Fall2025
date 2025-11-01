using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PAWB.EntityFramework
{
    public class PAWBDbContextFactory : IDesignTimeDbContextFactory<PAWBDbContext>
    {
        public PAWBDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<PAWBDbContext>();
            // TODO insert connection string to sequel server into this command below
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            return new PAWBDbContext(options.Options);
        }
    }
}
