using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BackendAPI.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError):base(message)
        {
            StatusCode = statusCode;
        }
        public HttpStatusCode StatusCode { get; }
    }
}
