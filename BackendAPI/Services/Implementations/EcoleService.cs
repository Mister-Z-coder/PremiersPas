using AutoMapper;
using BackendAPI.Models;
using BackendAPI.Repositories.Interfaces;
using BackendAPI.Services.Implementations;
using BackendAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Services
{
    public class EcoleService : BaseService<Ecole>,IEcoleService
    {
        public EcoleService(IRepository<Ecole> repository, IMapper mapper, IUriService uriService) : base(repository, mapper, uriService)
        {
        }
    }
}
