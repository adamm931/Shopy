using Shopy.Core.Application.Categories.Add;
using Shopy.Core.Application.Categories.Delete;
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

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]AddCategoryRequest addCategory)
        {
            return await ProcessRequest(
                request: () => Mediator.RequestAsync<AddCategoryRequest, AddCategoryResponse>(addCategory),
                paramValidators: RequestParamValidator.CategoryAddValidator(addCategory));
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
