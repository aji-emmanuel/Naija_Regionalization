using Microsoft.AspNetCore.Http;

namespace StatesNLgas.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public int Count { get; set; }

        public Response<T> Success(T data, string message, int count)
        {
            return new Response<T>() { Data = data, Message = message, Count = count, StatusCode = StatusCodes.Status200OK };
        }

        public Response<T> Fail(string message)
        {
            return new Response<T>() { Message = message, StatusCode = StatusCodes.Status500InternalServerError };
        }

        public Response<T> BadRequest(string message)
        {
            return new Response<T>() { Message = message, StatusCode = StatusCodes.Status400BadRequest };
        }
    }
}
