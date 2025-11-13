using BackendAPI.Wrappers;
using BackendAPI.Wrappers.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BackendAPI.Services.Interfaces
{
    public interface IService <T> where T : class
    {
        Task <PagedResponse<List<TDto>>> GetAllAsync<TDto>(PaginationFilter filter, string route, params Expression<Func<T, object>>[] includes);
        Task<Response<TDto>> GetByIdAsync<TDto>(int id, params Expression<Func<T, object>>[] includes);
        Task<PagedResponse<List<TDto>>> GetBySearchStringAsync<TDto>(PaginationFilter filter, string route, Expression<Func<T,bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<Response<TDto>> UpdateAsync<TDto>(int id, TDto entity);
        Task <bool>DeleteAsync(int id);
        Task<Response<TDto>> AddAsync<TDto>(TDto entity);

    }
}
