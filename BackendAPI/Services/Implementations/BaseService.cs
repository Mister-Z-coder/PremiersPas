using AutoMapper;
using BackendAPI.Exceptions;
using BackendAPI.Repositories.Interfaces;
using BackendAPI.Services.Interfaces;
using BackendAPI.Wrappers;
using BackendAPI.Wrappers.Filter;
using BackendAPI.Wrappers.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BackendAPI.Services.Implementations
{
    public class BaseService<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repo;
        protected readonly IMapper _mapper;
        protected readonly IUriService _uriService;

        public BaseService(IRepository<T> repository, IMapper mapper, IUriService uriService)
        {
            _repo = repository;
            _mapper = mapper;
            _uriService = uriService;
        }

        public async Task<Response<TDto>> AddAsync<TDto>(TDto dto)
        {
            foreach (var prop in typeof(TDto).GetProperties())
            {
                if (prop.Name.Contains("Photo"))
                    continue; // autoriser null si aucune modification de photo

                if (prop.Name == "UpdatedAt")
                    continue; // autoriser null si aucune modification de photo

                //Recupérer la nouvelle valeur des propriétés
                if (prop.GetValue(dto) == null)
                    throw new InvalidInputException(prop.Name);

            }

            var entity = _mapper.Map<T>(dto);
            await _repo.AddAsync(entity);
            await _repo.SaveAsync();
            var dataDto = _mapper.Map<TDto>(entity);
            return PaginationHelper.CreateResponse<TDto>(dataDto, "Donnée récupérée avec succès.");
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException(id);

            await _repo.DeleteAsync(existing);
            await _repo.SaveAsync();
            return true;
        }

        public async Task<PagedResponse<List<TDto>>> GetAllAsync<TDto>(PaginationFilter filter, string route, params Expression<Func<T, object>>[] includes)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var entities = await _repo.GetAllAsync(includes);
            var totalRecords = entities.Count();

            //Aucune donnée trouvée
            if (totalRecords == 0)
                return PaginationHelper.CreateErrorPagedResponse<TDto>("Auncun élément trouvé.");

            var pagedEntities = entities
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToList();

            var dataDtos = _mapper.Map<List<TDto>>(pagedEntities);
            var pagedResponse = PaginationHelper.CreatedPagedResponse<TDto>(dataDtos, validFilter, totalRecords, _uriService, route);

            return pagedResponse;
        }


        public async Task<Response<TDto>> GetByIdAsync<TDto>(int id, params Expression<Func<T, object>>[] includes)
        {
            var entity = await _repo.GetByIdAsync(id,includes);

            if (entity == null)
                throw new NotFoundException(id);
            //return PaginationHelper.CreateErrorResponse<TDto>("Aucun élément trouvé.");

            var dataDto = _mapper.Map<TDto>(entity);
            return PaginationHelper.CreateResponse<TDto>(dataDto);
        }

        public async Task<PagedResponse<List<TDto>>> GetBySearchStringAsync<TDto>(PaginationFilter filter, string route, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var entities = await _repo.GetBySearchStringAsync(predicate,includes);
            var totalRecords = entities.Count();

            //Aucune donnée trouvée
            if (totalRecords == 0)
                return PaginationHelper.CreateErrorPagedResponse<TDto>("Auncun élément trouvé.");

            var pagedEntities = entities
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToList();

            var dataDtos = _mapper.Map<List<TDto>>(pagedEntities);
            var pagedResponse = PaginationHelper.CreatedPagedResponse<TDto>(dataDtos, validFilter, totalRecords, _uriService, route);

            return pagedResponse;
        }

        public async Task<Response<TDto>> UpdateAsync<TDto>(int id, TDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null)
                throw new NotFoundException(id);
            //return PaginationHelper.CreateErrorResponse<TDto>("Aucun élément trouvé.");

            foreach (var prop in typeof(TDto).GetProperties())
            {
                if (prop.Name.Contains("Photo"))
                    continue; // autoriser null si aucune modification de photo

                if (prop.Name == "UpdatedAt")
                    continue; // autoriser null si aucune modification de photo

                //Recupérer la nouvelle valeur des propriétés
                if (prop.GetValue(dto) == null)
                    throw new InvalidInputException(prop.Name);
                
            }
            _mapper.Map(dto,existing);

            await _repo.UpdateAsync(existing);
            await _repo.SaveAsync();
            var dataDto = _mapper.Map<TDto>(existing);
            return PaginationHelper.CreateResponse<TDto>(dataDto);
        }

    }
}
