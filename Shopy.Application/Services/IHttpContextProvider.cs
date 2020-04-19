using System.Web;

namespace Shopy.Application.Services
{
    public interface IHttpContextProvider
    {
        HttpContext Context { get; }
    }
}
