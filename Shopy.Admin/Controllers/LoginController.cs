using Shopy.Admin.ViewModels;
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
            if (ModelState.IsValid)
            {
                //TODO: login service here to authenticate
                if (model.Username == Admin && model.Password == Admin)
                {
                    FormsAuthentication.SetAuthCookie("Admin", false);
                    return RedirectToRoute("Products", new { action = "List" });
                }
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}