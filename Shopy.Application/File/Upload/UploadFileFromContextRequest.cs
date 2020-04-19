using MediatR;
using System.Net.Http;

namespace Shopy.Application.Images.Upload
{
    public class UploadFileFromContextRequest : IRequest
    {
        public HttpRequestMessage Request { get; }

        public UploadFileFromContextRequest(HttpRequestMessage request)
        {
            Request = request;
        }
    }
}
