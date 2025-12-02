using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PAWB.Domain.Model;
using PAWB.Domain.Services;
using PAWB.EntityFramework.Services.Common;

namespace PAWB.EntityFramework.Services
{
    /// <summary>
    /// Defines generic methods to get or getall account information. Implements create, update, and delete methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        // Vars
        private readonly PAWBDbContextFactory _dbContextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContextFactory"></param>
        public GenericDataService(PAWBDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            _nonQueryDataService = new NonQueryDataService<T>(dbContextFactory);
        }

        /// <summary>
        /// Creates an item in the DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        /// <summary>
        /// Delete an entry in the DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        /// <summary>
        /// Gets an item in the DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> Get(int id)
        {
            using (PAWBDbContext context = _dbContextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        /// <summary>
        /// Get all items in the DB
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAll()
        {
            using (PAWBDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        /// <summary>
        /// Update an item in the DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
