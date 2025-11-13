using AutoMapper;
using FrontendMVC.Models.DTOs;
using FrontendMVC.Models.ViewModels;
using FrontendMVC.Services.Factories;
using FrontendMVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontendMVC.Services.Implementations
{
    public class AnneeScolaireApiService : BaseApiService<AnneeScolaireViewModel, AnneeScolaireDto>,IAnneeScolaireApiService
    {
        private const string route="api/v1/anneescolaire";

        public AnneeScolaireApiService(IHttpClientFactoryService httpClientFactoryService, IMapper mapper) : base(httpClientFactoryService, route, mapper)
        {
        }
    }
}
