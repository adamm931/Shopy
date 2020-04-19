using Shopy.Application.Services;
using System.Web;

namespace Shopy.Api.Services
{
    public class HttpContextProvider : IHttpContextProvider
    {
        public HttpContext Context => HttpContext.Current;
    }
}