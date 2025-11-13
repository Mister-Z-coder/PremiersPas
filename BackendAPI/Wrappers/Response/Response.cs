using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Wrappers
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

        public Response(T data, string message="")
        {
            Success = true;
            Message = message;
            Data = data;
            Errors = null;
        }

        public Response(string message, List<string> errors=null)
        {
            Success = false;
            Message = message;
            Data = default;
            Errors = errors;
        }
    }
}
