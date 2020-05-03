using Shopy.Public.Service;
using Shopy.Sdk.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shopy.Public.Controllers
{
    [HandleError]
    public class ProductsController : Controller
    {
        private readonly IProductsViewModelService _productViewModelService;

        public ProductsController(IProductsViewModelService productViewModelService)
        {
            _productViewModelService = productViewModelService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Filters()
        {
            var model = await _productViewModelService.GetFilters();

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Search(ProductFilter filter)
        {
            var products = await _productViewModelService.FilterProducts(filter);

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            return View(id);
        }

        [HttpGet]
        public async Task<ActionResult> LoadDetails(Guid id)
        {
            var details = await _productViewModelService.GetProductDetails(id);

            return Json(details, JsonRequestBehavior.AllowGet);
        }
    }
}