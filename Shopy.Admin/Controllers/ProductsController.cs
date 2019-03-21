using Shopy.Admin.ViewModels;
using Shopy.SDK.Models.Products;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shopy.Admin.Controllers
{
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
            if (ModelState.IsValid)
            {
                var addProduct = new AddProduct()
                {
                    Caption = model.Caption,
                    Description = model.Description,
                    Price = model.Price,
                    BrandType = model.Brand,
                    SizeType = model.Size
                };

                await this.Shopy.AddProductAsycn(addProduct);

                return RedirectToAction("List");
            }

            return View("Index", model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(Guid uid)
        {
            var productDetails = await Shopy.GetProductDetailsAsync(uid);

            var model = new ProductViewModel()
            {
                Uid = uid,
                Brand = productDetails.BrandType,
                Size = productDetails.SizeType,
                Caption = productDetails.Caption,
                Description = productDetails.Description,
                Price = productDetails.Price
            };

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
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

            return View("Index", model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid uid)
        {
            await Shopy.DeleteProductAsync(uid);
            return RedirectToAction("List");
        }

        public async Task<ActionResult> ChangeCategories(Guid uid)
        {
            var product = await Shopy.GetProductDetailsAsync(uid);

            var model = new ChangeProductCategoiresViewModel()
            {
                AssignedCategories = product.AssignedCategories,
                AvailableCategories = product.AvailableCategories,
            };

            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> AddToCategory(Guid productUid, Guid categoryUid)
        {
            await Shopy.AddProductToCategoryAsync(productUid, categoryUid);
            return Json(true);
        }

        [HttpPost]
        public async Task<ActionResult> RemoveFromCategory(Guid productUid, Guid categoryUid)
        {
            await Shopy.RemoveProductFromCategoryAsync(productUid, categoryUid);
            return Json(true);
        }
    }
}