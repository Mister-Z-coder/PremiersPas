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
    public class ElevesApiService : BaseApiService<EleveViewModel,EleveDto>,IEleveApiService
    {
        private const string route = "api/v1/eleves";

        public ElevesApiService(IHttpClientFactoryService httpClientFactoryService, IMapper mapper) : base(httpClientFactoryService, route, mapper)
        {
        }
    }
}
