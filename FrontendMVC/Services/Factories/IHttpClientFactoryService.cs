using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontendMVC.Services.Factories
{
    public interface IHttpClientFactoryService
    {
        HttpClient CreateClient();
    }
}
