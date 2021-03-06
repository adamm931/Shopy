﻿using MediatR;
using Shopy.Application.Categories.Add;
using Shopy.Application.Categories.Delete;
using Shopy.Application.Categories.Edit;
using Shopy.Application.Categories.Get;
using Shopy.Core.Logging;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [ActionName("list")]
        public async Task<IHttpActionResult> Get(bool withProductsOnly = false)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new ListCategoriesRequest(withProductsOnly)));
        }

        [HttpGet]
        [ActionName("lookup")]
        public async Task<IHttpActionResult> Lookup()
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new LookupCategoriesRequest()));
        }

        [HttpGet]
        [ActionName("get")]
        public async Task<IHttpActionResult> Get(Guid? uid)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new GetCategoryRequest(uid.Value)),
                paramValidators: RequestParamValidator.CategoryUidValidator(uid));
        }

        [HttpPost]
        [ActionName("add")]
        public async Task<IHttpActionResult> Post([FromBody]AddCategoryRequest addCategory)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(addCategory),
                paramValidators: RequestParamValidator.CategoryAddValidator(addCategory));
        }

        [HttpPut]
        [ActionName("edit")]
        public async Task<IHttpActionResult> Put(Guid uid, [FromBody]EditCategoryCommand editCategory)
        {
            editCategory.Uid = uid;

            return await ProcessCommand(
                command: () => Mediator.Send(editCategory),
                paramValidators: RequestParamValidator.CategoryEditValidator(editCategory));
        }

        [HttpDelete]
        [ActionName("delete")]
        public async Task<IHttpActionResult> Delete(Guid? uid)
        {
            return await ProcessCommand(
                command: () => Mediator.Send(new DeleteCategoryCommand(uid.Value)),
                paramValidators: RequestParamValidator.CategoryUidValidator(uid));
        }
    }
}
