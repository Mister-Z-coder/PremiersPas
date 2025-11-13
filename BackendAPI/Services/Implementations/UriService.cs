using BackendAPI.Services.Interfaces;
using BackendAPI.Wrappers.Filter;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Services.Implementations
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            var _endpointUri = new Uri(string.Concat(_baseUri, route));//Concatener l'url de base (https:///localhost:5001/api/v1) et la route(/Ecole)
            var modifiedUri = QueryHelpers.AddQueryString(_endpointUri.ToString(), "pageNumber", filter.PageNumber.ToString());//ajoute les paramètres dans l’URL (en gérant les ? et &)
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri.ToString(), "pageSize", filter.PageSize.ToString());//ajoute les paramètres dans l’URL (en gérant les ? et &)
            //https:///localhost:5001/api/v1/Ecole?pageNumber=2&pageSize=10
            return new Uri(modifiedUri);
        }
    }
}
