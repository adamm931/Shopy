using MediatR;
using Shopy.Application.Models;
using Shopy.Application.Products.Add;
using Shopy.Application.Products.AddToCategory;
using Shopy.Application.Products.Commands;
using Shopy.Application.Products.Edit;
using Shopy.Application.Products.Get;
using Shopy.Application.Products.RemoveFromCategory;
using Shopy.Core.Logging;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    public class ProductsController : BaseApiController
    {
        public ProductsController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<IHttpActionResult> List([FromUri]ProductFilter filter)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new ListProductsRequest(filter)));
        }

        [HttpGet]
        [ActionName("get")]
        public async Task<IHttpActionResult> Get(Guid? uid)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new GetProductRequest(uid.Value)),
                paramValidators: RequestParamValidator.ProductUidValidator(uid));
        }

        [HttpGet]
        [ActionName("details")]
        public async Task<IHttpActionResult> Details(Guid? uid)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new GetProductDetailsRequest(uid.Value)),
                paramValidators: RequestParamValidator.ProductUidValidator(uid));
        }

        [HttpGet]
        [ActionName("categories")]
        public async Task<IHttpActionResult> Categories(Guid? uid)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new GetProductCategoriesRequest(uid.Value)),
                paramValidators: RequestParamValidator.ProductUidValidator(uid));
        }

        [HttpPost]
        [ActionName("add")]
        public async Task<IHttpActionResult> Post(AddProductRequest addProduct)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(addProduct),
                paramValidators: RequestParamValidator.ProductAddValidator(addProduct));
        }

        [HttpPut]
        [ActionName("edit")]
        public async Task<IHttpActionResult> Put(Guid? uid, [FromBody]EditProductCommand editProduct)
        {
            editProduct.Uid = uid.Value;

            return await ProcessCommand(
                command: () => Mediator.Send(editProduct),
                paramValidators: RequestParamValidator.ProductEditValidator(editProduct));
        }

        [HttpDelete]
        [ActionName("delete")]
        public async Task<IHttpActionResult> Delete(Guid? uid)
        {
            return await ProcessCommand(
                command: () => Mediator.Send(new DeleteProductCommand(uid.Value)),
                paramValidators: RequestParamValidator.ProductUidValidator(uid));
        }

        [HttpPost]
        [ActionName("add-to-category")]
        public async Task<IHttpActionResult> AddToCategory(Guid? productid, Guid? categoryid)
        {
            var paramValidators = new[]
            {
                RequestParamValidator.ProductUidValidator(productid),
                RequestParamValidator.CategoryUidValidator(categoryid),
            };

            return await ProcessCommand(
                command: () => Mediator.Send(new AddProductToCategoryCommand(productid.Value, categoryid.Value)),
                paramValidators: paramValidators);
        }

        [HttpPost]
        [ActionName("remove-from-category")]
        public async Task<IHttpActionResult> RemoveFromCategory(Guid productid, Guid categoryid)
        {
            var paramValidators = new[]
            {
                RequestParamValidator.ProductUidValidator(productid),
                RequestParamValidator.CategoryUidValidator(categoryid),
            };

            return await ProcessCommand(
                command: () => Mediator.Send(new RemoveProductFromCategoryCommand(productid, categoryid)),
                paramValidators: paramValidators);
        }
    }
}
