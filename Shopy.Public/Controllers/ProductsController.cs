using Shopy.SDK;
using Shopy.SDK.ApiModels.Products;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shopy.Public.Controllers
{
    public class ProductsController : Controller
    {
        private IShopyDriver shopy;
        protected IShopyDriver Shopy
        {
            get
            {
                return shopy ?? (shopy = new ShopyDriveBuilder()
                        .WithBaseAddress("http://localhost:50253/api")
                        .Build());
            }
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Filters()
        {
            var response = new
            {
                Categories = await Shopy.ListCategoriesWithProductsAsync(),
                Sizes = await Shopy.ListSizesAsync(),
                Brands = await Shopy.ListBrandsAsync(),
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Search(ProductFilter filter)
        {
            var products = await Shopy.ListProductsAsync(filter);

            var response = new
            {
                Items = products
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            return View(id);
        }

        [HttpGet]
        public async Task<ActionResult> LoadDetails(Guid id)
        {
            var productDetails = await Shopy.GetProductDetailsAsync(id);

            var response = new
            {
                Details = productDetails
            };

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}