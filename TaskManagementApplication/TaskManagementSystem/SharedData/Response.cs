using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData
{
    public record Response<T>(bool Sucess, string? Message, T? Data)
    { 
        public static Response<T> Ok(T data, string? message = null) => new Response<T>(true, message, data);
        public static Response<T> Fail(string message) => new Response<T>(false, message, default);
    }
}
