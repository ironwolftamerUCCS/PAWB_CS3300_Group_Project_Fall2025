using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PAWB.Domain.Models;
using PAWB.Domain.Services;
using PAWB.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.EntityFramework.Services
{
    /// <summary>
    /// Defines functions to create, get, or delete all information related to a specific account
    /// </summary>
    public class AccountDataService : IAccountService
    {
        // Vars
        private readonly PAWBDbContextFactory _dbContextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContextFactory"></param>
        public AccountDataService(PAWBDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(dbContextFactory);
        }

        /// <summary>
        /// Create an account in DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        /// <summary>
        /// Delete an account in DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        /// <summary>
        /// Gets an existing account in DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Account> Get(int id)
        {
            using (PAWBDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.Entries)
                    .FirstOrDefaultAsync((e) => e.Id == id);
            }
        }

        /// <summary>
        /// Gets every entry associated with an account
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Account>> GetAll()
        {
            using (PAWBDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts
                    .Include(a => a.AccountHolder)
                    .Include(a => a.Entries)
                    .ToListAsync();
                return entities;
            }
        }

        /// <summary>
        /// Gets an account by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Account> GetByEmail(string email)
        {
            using (PAWBDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
            }
        }

        /// <summary>
        /// Get an account by the username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<Account> GetByUsername(string username)
        {
            using (PAWBDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Username == username);
            }
        }

        /// <summary>
        /// Update an account in the DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
