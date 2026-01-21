using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendAPI.Wrappers
{
    public class Response<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private  set; }
        public IReadOnlyList<string> Errors { get; }

        public Response(T data, string message="")
        {
            Success = true;
            Message = message;
            Data = data;
            Errors = Array.Empty<string>();
        }

        public Response(string message, IEnumerable<string>? errors=null)
        {
            Success = false;
            Message = message;
            Data = default;
            Errors = (errors?? new[] { message })
                .ToList()
                .AsReadOnly();
        }
    }
}
