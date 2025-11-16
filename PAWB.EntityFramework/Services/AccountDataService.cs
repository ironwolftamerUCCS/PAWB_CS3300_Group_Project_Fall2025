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
    public class AccountDataService : IAccountService
    {
        private readonly PAWBDbContextFactory _dbContextFactory;
        private readonly NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(PAWBDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _nonQueryDataService = new NonQueryDataService<Account>(dbContextFactory);
        }
        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

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

        public async Task<Account> GetByEmail(string email)
        {
            using (PAWBDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Email == email);
            }
        }

        public async Task<Account> GetByUsername(string username)
        {
            using (PAWBDbContext context = _dbContextFactory.CreateDbContext())
            {
                return await context.Accounts
                    .Include(a => a.AccountHolder)
                    .FirstOrDefaultAsync(a => a.AccountHolder.Username == username);
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
