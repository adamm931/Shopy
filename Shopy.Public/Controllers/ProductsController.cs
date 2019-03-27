using Shopy.SDK;
using Shopy.SDK.ApiModels.Products;
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
                return shopy ?? (shopy = new ShopyDriveBuilder().WithBaseAddress("http://localhost:50253/api").Build());
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
            var data = new
            {
                Categories = await Shopy.ListCategoriesWithProductsAsync(),
                Sizes = await Shopy.ListSizesAsync(),
                Brands = await Shopy.ListBrandsAsync(),
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Search(ProductFilter filter)
        {
            var products = await Shopy.ListProductsAsync(filter);

            var result = new
            {
                items = products
            };

            return Json(result);
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }
    }
}