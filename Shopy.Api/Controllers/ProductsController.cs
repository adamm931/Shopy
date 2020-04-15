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
        public async Task<IHttpActionResult> Post(AddProductRequest addProduct)
        {
            #region Upload image logic

            //// move this to command handler
            //var context = HttpContext.Current;
            //var root = context.Server.MapPath("~/App_Data");
            //var provider = new MultipartFormDataStreamProvider(root);

            //try
            //{
            //    await Request.Content.ReadAsMultipartAsync(provider);

            //    foreach (var file in provider.Contents)
            //    {
            //        var fileName = file.Headers.ContentDisposition.FileName.Trim('\"');
            //        var bytes = await file.ReadAsByteArrayAsync();

            //        File.WriteAllBytes(fileName, bytes);
            //    }
            //}

            //catch (Exception e)
            //{
            //    var some = e;
            //}

            #endregion

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
        //[Route("{productid}/add-to-category/{categoryid}")]
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
        //[Route("{productid}/remove-from-category/{categoryid}")]
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
