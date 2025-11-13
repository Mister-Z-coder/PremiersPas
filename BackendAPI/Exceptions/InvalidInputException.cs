using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BackendAPI.Exceptions
{
    public class InvalidInputException : BaseException
    {
        public InvalidInputException(string invalidPropertyMessage) 
            : base(invalidPropertyMessage, HttpStatusCode.BadRequest)
        {
        }

    }
}
