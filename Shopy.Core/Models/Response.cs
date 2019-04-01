using Mediator.Net.Contracts;

namespace Shopy.Core.Models
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
