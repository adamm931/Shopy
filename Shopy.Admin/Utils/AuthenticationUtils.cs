using Shopy.Admin.Models;
using System.Web;
using System.Web.Security;

namespace Shopy.Admin.Utils
{
    public class AuthenticationUtils : IAuthenticationUtils
    {
        public string DefaultUrl => FormsAuthentication.DefaultUrl;

        public string LoginUrl => FormsAuthentication.LoginUrl;

        public bool IsUserAuthenticated(HttpContextBase httpContext)
            => httpContext?.User?.Identity.IsAuthenticated ?? false;

        public bool ValidateCredentials(string username, string password)
            => FormsAuthentication.Authenticate(username, password);

        public UserLogedInResult LoginUser(string username, bool rememberMe, HttpRequestBase currentRequest)
        {
            FormsAuthentication.SetAuthCookie(username, rememberMe);

            return new UserLogedInResult
            {
                RedirectUrl = GetRedirectUrl(currentRequest)
            };
        }

        public void LogOut()
            => FormsAuthentication.SignOut();

        private string GetRedirectUrl(HttpRequestBase request)
        {
            var referrerQuery = HttpUtility.ParseQueryString(request.UrlReferrer.Query);
            var redirectUrl = referrerQuery[Constants.ReturnUrl];

            if (string.IsNullOrEmpty(redirectUrl))
            {
                redirectUrl = DefaultUrl;
            }

            return redirectUrl;
        }
    }
}