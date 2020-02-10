using MediatR;
using Shopy.Application.Products.Add;
using Shopy.Application.Products.AddToCategory;
using Shopy.Application.Products.Commands;
using Shopy.Application.Products.Edit;
using Shopy.Application.Products.Get;
using Shopy.Application.Products.RemoveFromCategory;
using Shopy.Core.Logging;
using Shopy.Core.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    [RoutePrefix("api/products")]
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
        public async Task<IHttpActionResult> Get(Guid? uid)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new GetProductRequest(uid.Value)),
                paramValidators: RequestParamValidator.ProductUidValidator(uid));
        }

        [HttpGet]
        [Route("{uid}/details")]
        public async Task<IHttpActionResult> Details(Guid uid)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new GetProductDetailsRequest(uid)),
                paramValidators: RequestParamValidator.ProductUidValidator(uid));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]AddProductRequest addProduct)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(addProduct),
                paramValidators: RequestParamValidator.ProductAddValidator(addProduct));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(Guid? uid, [FromBody]EditProductCommand editProduct)
        {
            editProduct.Uid = uid.Value;

            return await ProcessCommand(
                command: () => Mediator.Send(editProduct),
                paramValidators: RequestParamValidator.ProductEditValidator(editProduct));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid? uid)
        {
            return await ProcessCommand(
                command: () => Mediator.Send(new DeleteProductCommand(uid.Value)),
                paramValidators: RequestParamValidator.ProductUidValidator(uid));
        }

        [HttpPost]
        [Route("{productid}/add-to-category/{categoryid}")]
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
        [Route("{productid}/remove-from-category/{categoryid}")]
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
