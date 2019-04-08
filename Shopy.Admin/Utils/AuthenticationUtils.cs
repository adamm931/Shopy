using Shopy.Admin.Models;
using System.Web;
using System.Web.Security;

namespace Shopy.Admin.Utils
{
    public class AuthenticationUtils : IAuthenticationUtils
    {
        public string DefaultUrl
        {
            get
            {
                return FormsAuthentication.DefaultUrl;
            }
        }

        public string LoginUrl
        {
            get
            {
                return FormsAuthentication.LoginUrl;
            }
        }

        public bool IsUserAuthenticated(HttpContextBase httpContext)
        {
            return httpContext?.User?.Identity.IsAuthenticated ?? false;
        }

        public bool ValidateCredentials(string username, string password)
        {
            return FormsAuthentication.Authenticate(username, password);
        }

        public UserLogedInResult LoginUser(string username, bool rememberMe = false, string redirectUrl = null)
        {
            FormsAuthentication.SetAuthCookie(username, rememberMe);

            var result = new UserLogedInResult()
            {
                RedirectUrl = string.IsNullOrEmpty(redirectUrl) ? DefaultUrl : redirectUrl
            };

            return result;
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }

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