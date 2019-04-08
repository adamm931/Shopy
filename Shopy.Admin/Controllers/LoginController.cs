using Shopy.Admin.Filters;
using Shopy.Admin.Utils;
using Shopy.Admin.ViewModels;
using Shopy.Sdk;
using System.Web;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
    public class LoginController : BaseController
    {
        private IAuthenticationUtils _authenticationUtils;

        public LoginController(
            IAuthenticationUtils authenticationUtils,
            IShopyDriver shopy) : base(shopy)
        {
            _authenticationUtils = authenticationUtils;
        }

        [HttpGet]
        [LoginCheck]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid
                || !_authenticationUtils.ValidateCredentials(model.Username, model.Password))
            {
                return View("Index");
            }

            var referrerQuery = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);
            var redirectUrl = referrerQuery[Constants.ReturnUrl];
            var result = _authenticationUtils.LoginUser(model.Username, model.Remember, redirectUrl);

            return Redirect(result.RedirectUrl);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            _authenticationUtils.LogOut();
            return Redirect(_authenticationUtils.LoginUrl);
        }

    }
}