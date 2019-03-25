using Shopy.Admin.ViewModels;
using Shopy.SDK.ApiModels.Categories;
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

            var addCategory = new AddCategory()
            {
                Caption = model.Caption
            };

            await Shopy.AddCategoryAsync(addCategory);

            return RedirectToAction("List");
        }
    }
}