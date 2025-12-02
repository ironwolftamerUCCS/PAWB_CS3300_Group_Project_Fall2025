using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.Domain.Services
{
    /// <summary>
    ///     Defines a generic interface with methods declared to get, create, update, and delete database entries 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}
