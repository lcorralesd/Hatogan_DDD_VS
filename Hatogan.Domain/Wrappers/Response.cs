using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Domain.Wrappers
{
    public class Response<T>
    {
        public bool Succesful { get; set; }
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = new();
        public T? Data { get; set; }

        public Response()
        {
        }

        public Response(T data, string? message = null)
        {
            Succesful = true;
            Message = message;
            Data = data;
        }

        public Response(string? message)
        {
            Succesful=false;
            Message = message;
        }
    }
}
