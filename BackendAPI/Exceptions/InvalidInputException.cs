using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BackendAPI.Exceptions
{
    public class InvalidInputException : BaseException
    {

        public InvalidInputException(string invalidPropertyMessage, IEnumerable<string> errors) 
            : base(invalidPropertyMessage)
        {
            Errors = errors.ToList().AsReadOnly();
        }

        //Definir la liste des erreurs en lecture seule
        public IReadOnlyList<string> Errors { get; }
    }
}
