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
    /// <summary>
    /// Creates a local database context using a provided database connection string
    /// </summary>
    public class PAWBDbContextFactory : IDesignTimeDbContextFactory<PAWBDbContext>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public PAWBDbContext CreateDbContext(string[] args = null)
        {
            // Connect to local SQL DB
            var options = new DbContextOptionsBuilder<PAWBDbContext>();
            options.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=PAWB;Trusted_Connection=True;MultipleActiveResultSets=true",
                sqlOptions => sqlOptions.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: new List<int> { 40613 })
            );

            return new PAWBDbContext(options.Options);
        }
    }
}
