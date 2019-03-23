using Shopy.Api.Application.Products.Commands;
using Shopy.Api.Application.Products.Queries;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    //TODO: implement parameters validation
    //TODO: wrapp methods with try catch

    public class ProductsController : BaseApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var items = await Mediator
                .RequestAsync<ListProductsRequest, ListProductsResponse>(new ListProductsRequest());

            return Ok(items);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var request = new GetProductDetailsRequest()
            {
                Uid = id
            };

            var product = await Mediator.RequestAsync<GetProductDetailsRequest, GetProductDetailsResponse>(request);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]AddProductCommand addProduct)
        {
            await Mediator.SendAsync(addProduct);

            return Ok();
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(Guid id, [FromBody]UpdateProductCommand updateProduct)
        {
            updateProduct.Uid = id;

            await Mediator.SendAsync(updateProduct);

            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand()
            {
                Uid = id
            };

            await Mediator.SendAsync(command);
            return Ok();
        }

        [HttpPost]
        [Route("api/v1/products/{productid}/add-to-category/{categoryid}")]
        public async Task<IHttpActionResult> AddToCategory(Guid productid, Guid categoryid)
        {
            var command = new AddProductFromCategoryCommand()
            {
                CategoryUid = categoryid,
                ProductUid = productid
            };

            await Mediator.SendAsync(command);
            return Ok();
        }

        [HttpPost]
        [Route("api/v1/products/{productid}/remove-from-category/{categoryid}")]
        public async Task<IHttpActionResult> RemoveFromCategory(Guid productid, Guid categoryid)
        {
            var command = new RemoveProductFromCategoryCommand()
            {
                CategoryUid = categoryid,
                ProductUid = productid
            };

            await Mediator.SendAsync(command);
            return Ok();
        }
    }
}
