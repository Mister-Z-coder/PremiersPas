using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendMVC.Models.Wrappers
{
    public class PagedResponse<T>:Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri FirstPageUrl { get; set; }
        public Uri LastPageUrl { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri NextPageUrl { get; set; }
        public Uri PreviousPageUrl { get; set; }
        //
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }
        public int? FirstPage { get; set; }
        public int? LastPage { get; set; }
    }
}
