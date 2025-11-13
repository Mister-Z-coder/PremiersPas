using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BackendAPI.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(int id)
            :base($"Element avec id : {id} est introuvable.",HttpStatusCode.NotFound)
        {
        }
        public NotFoundException(string propertyName, string value)
            :base($"Element avec propriété {propertyName} : {value} est introuvable.", HttpStatusCode.NotFound)
        {

        }
    }
}
