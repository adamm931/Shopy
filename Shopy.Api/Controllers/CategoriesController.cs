using Shopy.Core.Application.Categories.Add;
using Shopy.Core.Application.Categories.Delete;
using Shopy.Core.Application.Categories.Edit;
using Shopy.Core.Application.Categories.Get;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get(bool withProductsOnly = false)
        {
            return await ProcessRequest(
                request: () => Mediator.RequestAsync<ListCategoriesRequest, ListCategoriesResponse>(
                    new ListCategoriesRequest(withProductsOnly)));
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(Guid? uid)
        {
            return await ProcessRequest(
                request: () => Mediator.RequestAsync<GetCategoryRequest, GetCategoryResponse>(
                    new GetCategoryRequest(uid.Value)),
                paramValidators: RequestParamValidator.ProductUidValidator(uid));
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]AddCategoryRequest addCategory)
        {
            return await ProcessRequest(
                request: () => Mediator.RequestAsync<AddCategoryRequest, AddCategoryResponse>(addCategory),
                paramValidators: RequestParamValidator.CategoryAddValidator(addCategory));
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(Guid uid, [FromBody]EditCategoryCommand editCategory)
        {
            editCategory.Uid = uid;

            return await ProcessCommand(
                command: () => Mediator.SendAsync(editCategory),
                paramValidators: RequestParamValidator.CategoryEditValidator(editCategory));
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(Guid? uid)
        {
            return await ProcessCommand(
                command: () => Mediator.SendAsync(new DeleteCategoryCommand(uid.Value)),
                paramValidators: RequestParamValidator.CategoryUidValidator(uid));
        }
    }
}
