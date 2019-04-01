using Shopy.Core.Application.Products.Commands;
using Shopy.Core.Application.Products.Queries;
using Shopy.Core.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    //TODO: implement parameters validation
    //TODO: wrapp methods with try catch

    [RoutePrefix("api/products")]
    public class ProductsController : BaseApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> List([FromUri]ProductFilter filter)
        {
            return await ProcessRequest(
                request: () => Mediator.RequestAsync<ListProductsRequest, ListProductsResponse>(
                    new ListProductsRequest(filter)));
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(Guid uid)
        {
            return await ProcessRequest(
                request: () => Mediator.RequestAsync<GetProductRequest, GetProductResponse>(new GetProductRequest(uid)),
                paramValidators: new RequestParamValidator(() => uid != Guid.Empty, "Product Uid is empty"));
        }

        [HttpGet]
        [Route("details/{uid}")]
        public async Task<IHttpActionResult> Details(Guid uid)
        {
            return await ProcessRequest(
                request: () => Mediator.RequestAsync<GetProductDetailsRequest, GetProductDetailsResponse>(new GetProductDetailsRequest(uid)),
                paramValidators: new RequestParamValidator(() => uid != Guid.Empty, "Product Uid is empty"));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]AddProductCommand addProduct)
        {
            return await ProcessCommand(
                command: () => Mediator.SendAsync(addProduct),
                paramValidators: new RequestParamValidator(() => addProduct != null, "Product is null"));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(Guid uid, [FromBody]UpdateProductCommand updateProduct)
        {
            updateProduct.Uid = uid;

            return await ProcessCommand(
                command: () => Mediator.SendAsync(updateProduct),
                paramValidators: new RequestParamValidator(() => uid != Guid.Empty, "Product Uid is empty"));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid uid)
        {
            return await ProcessCommand(
                command: () => Mediator.SendAsync(new DeleteProductCommand(uid)),
                paramValidators: new RequestParamValidator(() => uid != Guid.Empty, "Product Uid is empty"));
        }

        [HttpPost]
        [Route("{productid}/add-to-category/{categoryid}")]
        public async Task<IHttpActionResult> AddToCategory(Guid productid, Guid categoryid)
        {
            var paramValidators = new[]
            {
                new RequestParamValidator(() => productid != Guid.Empty, "Product Uid is empty"),
                new RequestParamValidator(() => categoryid != Guid.Empty, "Category Uid is empty")
            };

            return await ProcessCommand(
                command: () => Mediator.SendAsync(new AddProductFromCategoryCommand(productid, categoryid)),
                paramValidators: paramValidators);
        }

        [HttpPost]
        [Route("{productid}/remove-from-category/{categoryid}")]
        public async Task<IHttpActionResult> RemoveFromCategory(Guid productid, Guid categoryid)
        {
            var paramValidators = new[]
            {
                new RequestParamValidator(() => productid != Guid.Empty, "Product Uid is empty"),
                new RequestParamValidator(() => categoryid != Guid.Empty, "Category Uid is empty")
            };

            return await ProcessCommand(
                command: () => Mediator.SendAsync(new RemoveProductFromCategoryCommand(productid, categoryid)),
                paramValidators: paramValidators);
        }
    }
}
