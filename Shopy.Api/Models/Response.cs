using Mediator.Net.Contracts;

namespace Shopy.Api.Models
{
    public class Response<T> : IResponse
    {
        public T Result { get; }

        public Response(T result)
        {
            Result = result;
        }
    }
}
