﻿using Shopy.Core.Application.Products.Add;
using Shopy.Core.Application.Products.AddToCategory;
using Shopy.Core.Application.Products.Commands;
using Shopy.Core.Application.Products.Edit;
using Shopy.Core.Application.Products.Get;
using Shopy.Core.Application.Products.RemoveFromCategory;
using Shopy.Core.Models;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
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
        public async Task<IHttpActionResult> Get(Guid? uid)
        {
            return await ProcessRequest(
                request: () => Mediator.RequestAsync<GetProductRequest, GetProductResponse>(new GetProductRequest(uid.Value)),
                paramValidators: RequestParamValidator.ProductUidValidator(uid));
        }

        [HttpGet]
        [Route("{uid}/details")]
        public async Task<IHttpActionResult> Details(Guid uid)
        {
            return await ProcessRequest(
                request: () => Mediator.RequestAsync<GetProductDetailsRequest, GetProductDetailsResponse>(new GetProductDetailsRequest(uid)),
                paramValidators: RequestParamValidator.ProductUidValidator(uid));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]AddProductRequest addProduct)
        {
            return await ProcessRequest(
                request: () => Mediator.RequestAsync<AddProductRequest, AddProductResponse>(addProduct),
                paramValidators: RequestParamValidator.ProductAddValidator(addProduct));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(Guid? uid, [FromBody]EditProductCommand updateProduct)
        {
            updateProduct.Uid = uid.Value;

            return await ProcessCommand(
                command: () => Mediator.SendAsync(updateProduct),
                paramValidators: RequestParamValidator.CategoryUidValidator(uid));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid? uid)
        {
            return await ProcessCommand(
                command: () => Mediator.SendAsync(new DeleteProductCommand(uid.Value)),
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
                command: () => Mediator.SendAsync(new AddProductFromCategoryCommand(productid.Value, categoryid.Value)),
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
                command: () => Mediator.SendAsync(new RemoveProductFromCategoryCommand(productid, categoryid)),
                paramValidators: paramValidators);
        }
    }
}
