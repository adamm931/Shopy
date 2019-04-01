using Shopy.Admin.ViewModels;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Shopy.Admin.Controllers
{
    public class LoginController : BaseController
    {
        private const string Admin = "Admin";

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }

            //TODO: refactor this
            //TODO: login service here to authenticate
            if (model.Username != Admin || model.Password != Admin)
            {
                return View("Index");
            }

            FormsAuthentication.SetAuthCookie(model.Username, true);
            var referrerQuery = HttpUtility.ParseQueryString(Request.UrlReferrer.Query);
            var redirectUrl = referrerQuery["ReturnUrl"];

            if (string.IsNullOrEmpty(redirectUrl))
            {
                redirectUrl = Url.RouteUrl("Products", new { action = "List" });
            }

            return Redirect(redirectUrl);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.LoginUrl);
        }
    }
}