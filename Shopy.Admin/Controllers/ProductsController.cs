using Shopy.Admin.ViewModels;
using Shopy.SDK.ApiModels.Products;
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
                    Number = p.ProductID,
                    Caption = p.Caption,
                    Price = p.Price
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
        public async Task<ActionResult> Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            var addProduct = new AddProduct()
            {
                Caption = model.Caption,
                Description = model.Description,
                Price = model.Price,
                BrandType = model.Brand,
                SizeType = model.Size
            };

            await this.Shopy.AddProductAsync(addProduct);

            return RedirectToAction("List");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid uid)
        {
            var productDetails = await Shopy.GetProductDetailsAsync(uid);

            var model = new ProductViewModel()
            {
                Uid = uid,
                Brand = productDetails.Brand,
                Size = productDetails.Size,
                Caption = productDetails.Caption,
                Description = productDetails.Description,
                Price = productDetails.Price
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

            var editProduct = new EditProduct()
            {
                Uid = model.Uid,
                Caption = model.Caption,
                Description = model.Description,
                Price = model.Price,
                BrandType = model.Brand,
                SizeType = model.Size
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
        public ActionResult ChangeCategories(Guid uid)
        {
            var model = new ChangeProductCategoiresViewModel()
            {
                ProductUid = uid
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> LoadCategories(Guid uid)
        {
            var product = await Shopy.GetProductDetailsAsync(uid);

            var availableCategories = product.AvailableCategories
                .Select(c => new SelectListItem()
                {
                    Text = c.Caption,
                    Value = c.Uid.ToString()
                });

            var model = new
            {
                AssignedCategories = product.AssignedCategories,
                AvailableCategories = product.AvailableCategories,
            };

            return Json(model, JsonRequestBehavior.AllowGet);
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