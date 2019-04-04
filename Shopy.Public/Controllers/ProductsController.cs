using Shopy.Sdk;
using Shopy.Sdk.Models;
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
            object response = null;

            try
            {
                response = new
                {
                    Success = true,
                    Items = await Shopy.ListProductsAsync(filter)
                };
            }

            catch (Exception e)
            {
                response = new
                {
                    Success = false,
                    Message = e.Message
                };
            }

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
            object response = null;

            try
            {
                var productDetails = await Shopy.GetProductDetailsAsync(id);

                response = new
                {
                    Success = true,
                    Details = productDetails
                };
            }

            catch (Exception e)
            {
                response = new
                {
                    Success = false,
                    Message = e.Message
                };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}