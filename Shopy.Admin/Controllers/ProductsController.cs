using Shopy.Admin.ViewModels;
using Shopy.Sdk.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Shopy.Admin.Controllers
{
    [Authorize]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> List()
        {
            var products = await Shopy.ListProductsAsync();
            var model = new ProductListViewModel()
            {
                Items = products.Select(p => new ProductListItemViewModel()
                {
                    Uid = p.Uid,
                    Number = p.ProductId,
                    Caption = p.Caption,
                    Price = p.Price
                })
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            var model = await PrepareSizeAndBrands();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var addProduct = new Product()
            {
                Caption = model.Caption,
                Description = model.Description,
                Price = model.Price,
                Brand = model.Brand,
                Size = model.Size
            };

            await this.Shopy.AddProductAsync(addProduct);

            return RedirectToAction("List");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid uid)
        {
            var product = await Shopy.GetProductAsync(uid);
            var sizeBrands = await PrepareSizeAndBrands();

            var model = new ProductViewModel()
            {
                Uid = uid,
                Caption = product.Caption,
                Description = product.Description,
                Price = product.Price,
                Brand = product.Brand,
                Size = product.Size,
                Sizes = sizeBrands.Sizes,
                Brands = sizeBrands.Brands
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var editProduct = new Product()
            {
                Uid = model.Uid,
                Caption = model.Caption,
                Description = model.Description,
                Price = model.Price,
                Brand = model.Brand,
                Size = model.Size

            };

            await this.Shopy.EditProductAsync(editProduct);

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
            var categories = await Shopy.ListCategoriesAsync();

            var availableCategories = categories
                .Where(c => !c.Products.Any(p => p.Uid == uid));

            var assignedCategories = categories
                .Where(c => c.Products.Any(p => p.Uid == uid));

            var response = new
            {
                AssignedCategories = assignedCategories,
                AvailableCategories = availableCategories,
            };

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

        private async Task<ProductViewModel> PrepareSizeAndBrands()
        {
            var sizes = await Shopy.ListSizesAsync();
            var brands = await Shopy.ListBrandsAsync();

            var sizesSelectList = SelectListItemConverter
                .Convert(sizes, s => s.Caption, s => s.EId.ToString());
            var brandsSelectList = SelectListItemConverter
                .Convert(brands, s => s.Caption, s => s.EId.ToString());

            var model = new ProductViewModel()
            {
                Sizes = sizesSelectList,
                Brands = brandsSelectList
            };

            return model;
        }
    }
}