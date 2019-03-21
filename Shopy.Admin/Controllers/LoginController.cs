using Shopy.Admin.ViewModels;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //do authentication here
                return RedirectToRoute("Home");
            }

            return View("Index");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            //log out
            return View("Index");
        }
    }
}