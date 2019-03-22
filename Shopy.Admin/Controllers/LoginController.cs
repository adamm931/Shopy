using Shopy.Admin.ViewModels;
using System.Web.Mvc;

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
                if (model.Username == Admin && model.Password == Admin)
                {
                    HttpContext.Session["Authenticated"] = 1;
                    return RedirectToRoute("Products", new { action = "List" });
                }
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session["Authenticated"] = null;
            return RedirectToAction("Index");
        }
    }
}