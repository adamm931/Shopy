using MediatR;
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
        public async Task<IHttpActionResult> Get(bool withProductsOnly = false)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new ListCategoriesRequest(withProductsOnly)));
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(Guid? uid)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new GetCategoryRequest(uid.Value)),
                paramValidators: RequestParamValidator.ProductUidValidator(uid));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]AddCategoryRequest addCategory)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(addCategory),
                paramValidators: RequestParamValidator.CategoryAddValidator(addCategory));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(Guid uid, [FromBody]EditCategoryCommand editCategory)
        {
            editCategory.Uid = uid;

            return await ProcessCommand(
                command: () => Mediator.Send(editCategory),
                paramValidators: RequestParamValidator.CategoryEditValidator(editCategory));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid? uid)
        {
            return await ProcessCommand(
                command: () => Mediator.Send(new DeleteCategoryCommand(uid.Value)),
                paramValidators: RequestParamValidator.CategoryUidValidator(uid));
        }
    }
}
