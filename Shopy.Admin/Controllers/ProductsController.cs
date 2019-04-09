using Shopy.Admin.ModelBuilder;
using Shopy.Admin.ViewModels;
using Shopy.SDK;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        public ProductsController(IShopyDriver shopy) : base(shopy)
        { }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var model = await DiC.GetService<ProductListModelBuilder>()
                .BuildAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            var model = await DiC.GetService<DefaultProductModelBuilder>()
                .BuildAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var resultModel = await DiC.GetService<DefaultProductModelBuilder>()
                    .WithInner(model)
                    .BuildAsync();

                return View(resultModel);
            }

            var addProduct = await DiC.GetService<AddEditProductModelBuidler>()
                .FromViewModel(model)
                .BuildAsync();

            var product = await Shopy.AddProductAsync(addProduct);
            return RedirectToAction("List");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid uid)
        {
            var model = await DiC.GetService<ProductModelBuilder>()
                .WithUid(uid)
                .BuildAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var resultModel = await DiC.GetService<DefaultProductModelBuilder>()
                    .WithInner(model)
                    .BuildAsync();

                return View(resultModel);
            }

            var product = await DiC.GetService<AddEditProductModelBuidler>()
                .FromViewModel(model)
                .BuildAsync();

            await Shopy.EditProductAsync(product);

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid uid)
        {
            await Shopy.DeleteProductAsync(uid);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> ChangeCategories(Guid uid)
        {
            var product = await Shopy.GetProductAsync(uid);
            var model = new ChangeProductCategoriesViewModel()
            {
                ProductUid = uid,
                Caption = product.Caption
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> LoadCategories(Guid uid)
        {
            var response = await DiC.GetService<ProductCategoriesModelBuidler>()
                .ForProduct(uid)
                .BuildAsync();

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> AddToCategory(Guid uid, Guid categoryUid)
        {
            await Shopy.AddProductToCategoryAsync(uid, categoryUid);
            return Json(true);
        }

        [HttpPost]
        public async Task<ActionResult> RemoveFromCategory(Guid uid, Guid categoryUid)
        {
            await Shopy.RemoveProductFromCategoryAsync(uid, categoryUid);
            return Json(true);
        }
    }
}