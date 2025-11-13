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
    public class InscrpitionService : BaseService<Inscription>,IInscriptionService
    {
        public InscrpitionService(IRepository<Inscription> repository, IMapper mapper, IUriService uriService) : base(repository, mapper, uriService)
        {
        }
    }
}
