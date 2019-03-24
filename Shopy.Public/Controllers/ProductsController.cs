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
                return shopy ?? (shopy = ShopyDriver.Create());
            }
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Data()
        {
            var data = new
            {
                Categories = Shopy.ListCategoriesWithProductsAsync(),
                Sizes = "",//provder api call to fetch available sizes
                Brands = "",//provide api call to fetch avalable brands
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