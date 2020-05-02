using Shopy.Admin.Filters;
using Shopy.Admin.Utils;
using Shopy.Admin.ViewModels;
using Shopy.Sdk;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
    public class LoginController : BaseController
    {
        private readonly IAuthenticationUtils _authenticationUtils;

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

            var result = _authenticationUtils.LoginUser(model.Username, model.Remember, Request);

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