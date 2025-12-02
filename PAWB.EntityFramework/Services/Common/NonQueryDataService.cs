using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Internal;
using PAWB.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.EntityFramework.Services.Common
{
    /// <summary>
    /// Defines non-query methods where data is not returned. Includes create, delete, and update methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NonQueryDataService<T> where T : DomainObject
    {
        // Vars
        private readonly PAWBDbContextFactory _dbContextFactory;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContextFactory"></param>
        public NonQueryDataService(PAWBDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Creat a new item in the DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> Create(T entity)
        {
            using (PAWBDbContext context = _dbContextFactory.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        /// <summary>
        /// Delete an item in the DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            using (PAWBDbContext context = _dbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        /// <summary>
        /// Update an existing item in the DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> Update(int id, T entity)
        {
            using (PAWBDbContext context = _dbContextFactory.CreateDbContext())
            {
                entity.Id = id;

                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
