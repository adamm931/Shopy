using Shopy.Admin.Utils;
using Shopy.Admin.ViewModels;
using Shopy.Sdk.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Shopy.Admin.Controllers
{
    //TODO: remove image when product is deleted
    [Authorize]
    public class ProductsController : BaseController
    {
        private ImageUtlis imageUtils;
        protected ImageUtlis ImageUtlis
        {
            get
            {
                return imageUtils ?? (imageUtils = new ImageUtlis(HttpContext));
            }
        }

        private SelectListItemUtils selectListItemUtils;
        protected SelectListItemUtils SelectListItemUtils
        {
            get
            {
                return selectListItemUtils ?? (selectListItemUtils = new SelectListItemUtils(Shopy));
            }
        }

        [HttpGet]
        public async Task<ActionResult> List()
        {
            var products = await Shopy.ListProductsAsync();
            var model = new ProductListViewModel()
            {
                Items = products.Select(p => new ProductListItemViewModel()
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
                BrandsSelectList = await SelectListItemUtils.GetBrandsSLI(),
                //SizesSelectList = await SelectListItemUtils.GetSizesSLI(),
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
                return View(model);
            }

            var addProduct = new Product()
            {
                Caption = model.Caption,
                Description = model.Description,
                Price = model.Price,
                Brand = model.Brand,
                Sizes = model.Sizes
            };

            var product = await Shopy.AddProductAsync(addProduct);

            ImageUtlis.SavePostedImages(model, product.Uid);

            return RedirectToAction("List");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid uid)
        {
            var product = await Shopy.GetProductAsync(uid);

            var image1Url1 = ImageUtlis.GetImageUrl(uid, Constants.Image1);
            var image1Url2 = ImageUtlis.GetImageUrl(uid, Constants.Image2);
            var image1Url3 = ImageUtlis.GetImageUrl(uid, Constants.Image3);

            var model = new ProductViewModel()
            {
                Uid = uid,
                Caption = product.Caption,
                Description = product.Description,
                Price = product.Price,
                Brand = product.Brand,
                Sizes = product.Sizes,
                SizesSelectList = await SelectListItemUtils.GetSizesSLI(),
                BrandsSelectList = await SelectListItemUtils.GetBrandsSLI(),
                Image1 = new ImageViewModel(image1Url1),
                Image2 = new ImageViewModel(image1Url2),
                Image3 = new ImageViewModel(image1Url3),
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var editProduct = new Product()
            {
                Uid = model.Uid,
                Caption = model.Caption,
                Description = model.Description,
                Price = model.Price,
                Brand = model.Brand,
                Sizes = model.Sizes
            };

            await Shopy.EditProductAsync(editProduct);

            ImageUtlis.SavePostedImages(model, model.Uid);

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
    }
}