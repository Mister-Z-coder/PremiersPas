using AutoMapper;
using BackendAPI.Models;
using BackendAPI.Repositories.Interfaces;
using BackendAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Services.Implementations
{
    public class AnneScolaireService : BaseService<Annee_Scolaire>,IAnneeScolaireService
    {
        public AnneScolaireService(IRepository<Annee_Scolaire> repository, IMapper mapper, IUriService uriService) : base(repository, mapper, uriService)
        {
        }
    }
}
