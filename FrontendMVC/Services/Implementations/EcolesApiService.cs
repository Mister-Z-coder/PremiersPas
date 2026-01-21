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
    public class EcolesApiService : BaseApiService<EcoleViewModel,EcoleDto>,IEcoleApiService
    {
        private const string route = "api/v1/ecoles";

        public EcolesApiService(IHttpClientFactoryService httpClientFactoryService, IMapper mapper) : base(httpClientFactoryService, route, mapper)
        {
        }
    }
}
