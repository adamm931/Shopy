using Shopy.Admin.ViewModels;
using Shopy.Admin.ViewModels.Interfaces;
using Shopy.Sdk;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
    [Authorize]
    public class CategoriesController : BaseController
    {
        private readonly Lazy<ICategoryViewModelService> _categoryViewModelService;

        public ICategoryViewModelService CategoryViewModelService => _categoryViewModelService.Value;

        public CategoriesController(
            Lazy<ICategoryViewModelService> categoryViewModelService,
            IShopyDriver shopy) : base(shopy)
        {
            _categoryViewModelService = categoryViewModelService;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var model = await CategoryViewModelService.GetCategoryList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await CategoryViewModelService.AddCategory(model);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid uid)
        {
            var model = await CategoryViewModelService.GetCategory(uid);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await CategoryViewModelService.EditCategory(model);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid uid)
        {
            await Shopy.DeleteCategory(uid);

            return RedirectToAction("List");
        }
    }
}