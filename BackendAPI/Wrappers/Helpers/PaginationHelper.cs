using BackendAPI.Services;
using BackendAPI.Services.Interfaces;
using BackendAPI.Wrappers.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Wrappers.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<List<TDto>> CreatedPagedResponse<TDto>(List<TDto> pagedData, PaginationFilter validFilter, int totalRecords,IUriService uriService, string route,string message="")
        {
            var response = new PagedResponse<List<TDto>>(pagedData, validFilter.PageNumber, validFilter.PageSize, totalRecords,
                string.IsNullOrWhiteSpace(message)
                ? (pagedData != null && pagedData.Count > 0 ? "Liste paginée récupérée avec succès" : "Aucun élément trouvé")
                : message);

            // Si aucune donnée, on retourne directement sans calculer les liens
            if (pagedData == null || pagedData.Count == 0)
                return response;
            //Calcul des pages 
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);//Trouver le nombre total des pages
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));//Convertir en entier
            response.NextPageUrl = validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                : null;
            response.PreviousPageUrl = validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                : null;
            response.FirstPageUrl = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
            response.LastPageUrl = uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route);
            response.TotalRecords = totalRecords;

            response.NextPage = validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages ? validFilter.PageNumber + 1 : null;
            response.PreviousPage = validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages ? validFilter.PageNumber - 1 : null;
            response.FirstPage = 1;
            response.LastPage = roundedTotalPages;
            return response;
        }
        public static PagedResponse<List<TDto>> CreateErrorPagedResponse<TDto>(string message, List<string> errors = null)
        {
            var finalMessage = String.IsNullOrWhiteSpace(message) ? "Une erreur est survenue lors du traitement de la requête." : message;
            return new PagedResponse<List<TDto>>(finalMessage, errors?? new List<string> { finalMessage });
        }

        public static Response<TDto> CreateResponse<TDto>(TDto data, string message="")
        {
            return new Response<TDto>(data, string.IsNullOrWhiteSpace(message)
                ? (data != null ? "Donnée récupérée avec succès" : "Aucun élément trouvé")
                : message);
        }
        public static Response<TDto> CreateErrorResponse<TDto>(string message, List<string> errors = null)
        {
            var finalMessage = String.IsNullOrWhiteSpace(message) ? "Une erreur est survenue lors du traitement de la requête." : message;
            return new Response<TDto>(finalMessage, errors?? new List<string> { finalMessage });
        }
    }
}
