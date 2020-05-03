using Shopy.Admin.ViewModels;
using Shopy.Admin.ViewModels.Interfaces;
using Shopy.Sdk;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        private readonly Lazy<IProductViewModelService> _productViewModelService;

        private IProductViewModelService ProductViewModelService => _productViewModelService.Value;


        public ProductsController(
            IShopyDriver shopy,
            Lazy<IProductViewModelService> productViewModelService) : base(shopy)
        {
            _productViewModelService = productViewModelService;
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var model = await ProductViewModelService.GetProductList();

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            var model = await ProductViewModelService.GetEmptyProduct();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await ProductViewModelService.PopulateProduct(model);

                return View(model);
            }

            await ProductViewModelService.AddProduct(model);

            return RedirectToAction("List");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid uid)
        {
            var model = await ProductViewModelService.GetProduct(uid);

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model = await ProductViewModelService.PopulateProduct(model);

                return View(model);
            }

            await ProductViewModelService.EditProduct(model);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid uid)
        {
            await Shopy.DeleteProduct(uid);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> ChangeCategories(Guid uid)
        {
            var model = await ProductViewModelService.GetProductCategoryChange(uid);

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> LoadCategories(Guid uid)
        {
            var response = await ProductViewModelService.GetProductCategories(uid);

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> AddToCategory(Guid uid, Guid categoryUid)
        {
            await Shopy.AddProductToCategory(uid, categoryUid);

            return Json(true);
        }

        [HttpPost]
        public async Task<ActionResult> RemoveFromCategory(Guid uid, Guid categoryUid)
        {
            await Shopy.RemoveProductFromCategory(uid, categoryUid);

            return Json(true);
        }
    }
}