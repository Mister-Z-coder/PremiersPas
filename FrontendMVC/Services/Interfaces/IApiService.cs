using FrontendMVC.Models.Filters;
using FrontendMVC.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FrontendMVC.Services
{
    public interface IApiService<TViewModel>
    {
        Task<PagedResponse<List<TViewModel>>> GetAllAsync(PaginationFilter filter);
        Task<PagedResponse<List<TViewModel>>> GetBySearchStringAsync(string search, PaginationFilter filter);
        Task<Response<TViewModel>> GetByIdAsync(int id);
        Task<Response<TViewModel>> UpdateAsync(int id, TViewModel entity);
        Task<bool> DeleteAsync(int id);
        Task<Response<TViewModel>> AddAsync(TViewModel entity);
    }
}
