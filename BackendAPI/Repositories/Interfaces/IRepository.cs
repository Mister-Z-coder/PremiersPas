using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BackendAPI.Repositories.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetBySearchStringAsync(Expression<Func<T,bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<T> UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> SaveAsync();
    }
}
