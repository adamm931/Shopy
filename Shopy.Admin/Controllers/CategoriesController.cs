using Shopy.Admin.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> List()
        {
            var categories = await Shopy.ListCategoriesAsync();

            var model = new CategoryListViewModel()
            {
                Items = categories.Select(c => new CategoryListItemViewModel()
                {
                    Caption = c.Caption
                })
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddCategoryViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //}
            return View();
        }

        [HttpGet]
        public ActionResult AddRemoveProducts()
        {
            return View();
        }
    }
}