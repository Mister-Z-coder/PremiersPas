using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords, string message = "") 
            : base(data, message)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            FirstPage = null;
            LastPage = null;
            NextPage = null;
            PreviousPage = null;
        }

        public PagedResponse(string message, IEnumerable<string>? errors = null) 
            : base(message, errors)
        {
            PageNumber = 0;
            PageSize = 0;
            TotalRecords = 0;
            FirstPage = null;
            LastPage = null;
            NextPage = null;
            PreviousPage = null;
            //Data = default;
        }

        //Pagination
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages =>PageSize == 0 ? 0 : (int)System.Math.Ceiling((double)TotalRecords / PageSize);
        public int TotalRecords { get; set; }

        //URLs
        public Uri FirstPageUrl { get; set; }
        public Uri LastPageUrl { get; set; }
        public Uri NextPageUrl { get; set; }
        public Uri PreviousPageUrl { get; set; }

        //Numéros de page
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
        public int? FirstPage { get; set; }
        public int? LastPage { get; set; }




    }
}
