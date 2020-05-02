using Shopy.Admin.Models;
using System.Web;

namespace Shopy.Admin.Utils
{
    public interface IAuthenticationUtils
    {
        string DefaultUrl { get; }

        string LoginUrl { get; }

        bool IsUserAuthenticated(HttpContextBase httpContext);

        bool ValidateCredentials(string username, string password);

        UserLogedInResult LoginUser(string username, bool rememberMe, HttpRequestBase currentRequest);

        void LogOut();
    }
}
