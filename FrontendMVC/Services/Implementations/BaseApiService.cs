using FrontendMVC.Models.Filters;
using FrontendMVC.Models.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using FrontendMVC.Services.Factories;
using AutoMapper;

namespace FrontendMVC.Services.Implementations
{
    public class BaseApiService<TViewModel,TDto> : IApiService<TViewModel>
    {
        protected readonly HttpClient _httpClient;
        protected readonly string _route;
        protected readonly IMapper _mapper;

        public BaseApiService(IHttpClientFactoryService httpClientFactoryService, string route, IMapper mapper)
        {
            _httpClient = httpClientFactoryService.CreateClient();
            _route = route;
            _mapper = mapper;
        }

        public async Task<Response<TViewModel>> AddAsync(TViewModel viewmodel)
        {
            //Mapper en DTO
            var dto = _mapper.Map<TDto>(viewmodel);

            var response = await _httpClient.PostAsJsonAsync(_route, dto);
            var resultdto = await response.Content.ReadFromJsonAsync<Response<TDto>>();
            //Mapper DTO => ViewModel pourle retour
            return new Response<TViewModel>
            {
                Data = _mapper.Map<TViewModel>(resultdto.Data),
                Success = resultdto.Success,
                Message = resultdto.Message,
                Errors = resultdto.Errors
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_route}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<PagedResponse<List<TViewModel>>> GetAllAsync(PaginationFilter filter)
        {
            var url = $"{_route}?pageNumber={filter.PageNumber}&pageSize={filter.PageSize}";
            var dtopagedResponse =  await _httpClient.GetFromJsonAsync <PagedResponse<List<TDto>>>(url);

            //Mapper DTO => ViewModel
            return new PagedResponse<List<TViewModel>>
            {
                Data = _mapper.Map<List<TViewModel>>(dtopagedResponse.Data),
                Success = dtopagedResponse.Success,
                Message = dtopagedResponse.Message,
                Errors = dtopagedResponse.Errors,
                FirstPage = dtopagedResponse.FirstPage,
                LastPage = dtopagedResponse.LastPage,
                NextPage = dtopagedResponse.NextPage,
                PreviousPage = dtopagedResponse.PreviousPage,
                FirstPageUrl = dtopagedResponse.FirstPageUrl,
                LastPageUrl = dtopagedResponse.LastPageUrl,
                NextPageUrl = dtopagedResponse.NextPageUrl,
                PreviousPageUrl = dtopagedResponse.PreviousPageUrl,
                PageNumber = dtopagedResponse.PageNumber,
                PageSize = dtopagedResponse.PageSize,
                TotalPages = dtopagedResponse.TotalPages,
                TotalRecords = dtopagedResponse.TotalRecords
            };
        }

        public async Task<Response<TViewModel>> GetByIdAsync(int id)
        {
            var dtoResponse =  await _httpClient.GetFromJsonAsync<Response<TDto>>($"{_route}/{id}");
            
            //Mapper DTO => ViewModel pourle retour
            return new Response<TViewModel>
            {
                Data = _mapper.Map<TViewModel>(dtoResponse.Data),
                Success = dtoResponse.Success,
                Message = dtoResponse.Message,
                Errors = dtoResponse.Errors
            };
        }

        public async Task<PagedResponse<List<TViewModel>>> GetBySearchStringAsync(string? search, PaginationFilter filter)
        {
            var url = $"{_route}/search?search={search}&pageNumber={filter.PageNumber}&pageSize={filter.PageSize}";
            /*if (!string.IsNullOrEmpty(search))
            {
                // Ajouter searchString en paramètre GET
                url += $"&search={Uri.EscapeDataString(search)}";
            }*/
            var dtopagedResponse = await _httpClient.GetFromJsonAsync<PagedResponse<List<TDto>>>(url);

            //Mapper DTO => ViewModel
            return new PagedResponse<List<TViewModel>>
            {
                Data = _mapper.Map<List<TViewModel>>(dtopagedResponse.Data),
                Success = dtopagedResponse.Success,
                Message = dtopagedResponse.Message,
                Errors = dtopagedResponse.Errors,
                FirstPage = dtopagedResponse.FirstPage,
                LastPage = dtopagedResponse.LastPage,
                NextPage = dtopagedResponse.NextPage,
                PreviousPage = dtopagedResponse.PreviousPage,
                FirstPageUrl = dtopagedResponse.FirstPageUrl,
                LastPageUrl = dtopagedResponse.LastPageUrl,
                NextPageUrl = dtopagedResponse.NextPageUrl,
                PreviousPageUrl = dtopagedResponse.PreviousPageUrl,
                PageNumber = dtopagedResponse.PageNumber,
                PageSize = dtopagedResponse.PageSize,
                TotalPages = dtopagedResponse.TotalPages,
                TotalRecords = dtopagedResponse.TotalRecords
            };
        }

        public async Task<Response<TViewModel>> UpdateAsync(int id, TViewModel viewmodel)
        {
            //Maper en DTO
            var dto = _mapper.Map<TDto>(viewmodel);

            var response = await _httpClient.PutAsJsonAsync($"{_route}/{id}", dto);
            var resultdto =  await response.Content.ReadFromJsonAsync<Response<TDto>>();

            //Mapper DTO => ViewModel pourle retour
            return new Response<TViewModel>
            {
                Data = _mapper.Map<TViewModel>(resultdto.Data),
                Success = resultdto.Success,
                Message = resultdto.Message,
                Errors = resultdto.Errors
            };
        }
    }
}
