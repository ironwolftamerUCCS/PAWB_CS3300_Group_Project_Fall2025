using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
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
            //options.UseSqlServer("");
            options.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=PAWB;Trusted_Connection=True;MultipleActiveResultSets=true",
                sqlOptions => sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: new List<int> { 40613 })
            );

            return new PAWBDbContext(options.Options);
        }
    }
}
