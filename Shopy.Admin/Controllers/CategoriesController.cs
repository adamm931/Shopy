using Shopy.Admin.ModelBuilder;
using Shopy.Admin.ViewModels;
using Shopy.SDK;
using Shopy.SDK.Models;
using System;
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
            var model = await DiC.GetService<CategoryListModelBuilder>()
                .BuildAsync();

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

        [HttpGet]
        public async Task<ActionResult> Delete(Guid uid)
        {
            await Shopy.DeleteCategoryAsync(uid);
            return RedirectToAction("List");
        }
    }
}