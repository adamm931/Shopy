using Shopy.Admin.ViewModels;
using Shopy.Sdk;
using Shopy.Sdk.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IShopyDriver shopy) : base(shopy)
        {
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var categories = await Shopy.ListCategoriesAsync();

            var model = new CategoryListViewModel()
            {
                Items = categories.Select(c => new CategoryListItemViewModel()
                {
                    CategoryId = c.CategoryId,
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
        public async Task<ActionResult> Add(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var addCategory = new Category()
            {
                Caption = model.Caption
            };

            await Shopy.AddCategoryAsync(addCategory);

            return RedirectToAction("List");
        }
    }
}