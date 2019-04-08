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
        private SelectListItemUtils selectListUtils;
        protected SelectListItemUtils SelectListUtils
        {
            get
            {
                return selectListUtils ?? (selectListUtils = new SelectListItemUtils(Shopy));
            }
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var products = await Shopy.ListProductsAsync();
            var model = new ProductListViewModel()
            {
                Items = products.Result.Select(p => new ProductListItemViewModel()
                {
                    Uid = p.Uid,
                    ProductId = p.ProductId,
                    Caption = p.Caption,
                    Price = p.Price
                })
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            var model = new ProductViewModel()
            {
                BrandsSelectList = await SelectListUtils.GetBrandsSL(),
                SelectedSizesML = await SelectListUtils.GetSizesMSL(),
                Image1 = ImageViewModel.Empty,
                Image2 = ImageViewModel.Empty,
                Image3 = ImageViewModel.Empty,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.BrandsSelectList = await SelectListUtils.GetBrandsSL();
                model.SelectedSizesML = await SelectListUtils.GetSizesMSL();
                model.Image1 = new ImageViewModel(model.Image1.Url);
                model.Image2 = new ImageViewModel(model.Image2.Url);
                model.Image3 = new ImageViewModel(model.Image3.Url);

                return View(model);
            }

            var addProduct = new AddEditProduct()
            {
                Caption = model.Caption,
                Description = model.Description,
                Price = model.Price,
                Brand = model.Brand,
                Sizes = model.Sizes,
                Image1 = model.Image1.File,
                Image2 = model.Image2.File,
                Image3 = model.Image3.File
            };

            var product = await Shopy.AddProductAsync(addProduct);
            return RedirectToAction("List");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid uid)
        {
            var product = await Shopy.GetProductAsync(uid);

            if (product == null)
            {
                throw new Exception($"Product not found with id: {uid}");
            }

            var model = new ProductViewModel()
            {
                Uid = uid,
                Caption = product.Caption,
                Description = product.Description,
                Price = product.Price,
                Brand = product.Brand.EId,
                Sizes = product.Sizes.Select(s => s.EId),
                SelectedSizesML = await SelectListUtils.GetSizesMSL(),
                BrandsSelectList = await SelectListUtils.GetBrandsSL(),
                Image1 = new ImageViewModel(product.Image1.Url),
                Image2 = new ImageViewModel(product.Image2.Url),
                Image3 = new ImageViewModel(product.Image3.Url),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.BrandsSelectList = await SelectListUtils.GetBrandsSL();
                model.SelectedSizesML = await SelectListUtils.GetSizesMSL();
                model.Image1 = new ImageViewModel(model.Image1.Url);
                model.Image2 = new ImageViewModel(model.Image2.Url);
                model.Image3 = new ImageViewModel(model.Image3.Url);

                return View(model);
            }

            var editProduct = new AddEditProduct()
            {
                Uid = model.Uid,
                Caption = model.Caption,
                Description = model.Description,
                Price = model.Price,
                Brand = model.Brand,
                Sizes = model.Sizes,
                Image1 = model.Image1.File,
                Image2 = model.Image2.File,
                Image3 = model.Image3.File
            };

            await Shopy.EditProductAsync(editProduct);

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


        private async Task<ProductViewModel> GetModelWithDefaultSetup()
        {
            var model = new ProductViewModel()
            {
                BrandsSelectList = await SelectListUtils.GetBrandsSL(),
                SelectedSizesML = await SelectListUtils.GetSizesMSL(),
                Image1 = ImageViewModel.Empty,
                Image2 = ImageViewModel.Empty,
                Image3 = ImageViewModel.Empty,
            };

            return model;
        }
    }
}