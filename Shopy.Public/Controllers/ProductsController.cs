using Shopy.SDK;
using Shopy.SDK.Models;
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
                return shopy ?? (shopy = new ShopyDriveBuilder().Configure());
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
                Categories = await Shopy.ListCategoriesAsync(),
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
                    Data = await Shopy.ListProductsAsync(filter)
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
                var details = await Shopy.GetProductDetailsAsync(id);

                if (details == null)
                {
                    throw new Exception($"Product not found with id: {id}");
                }

                response = new
                {
                    Success = true,
                    Details = details
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