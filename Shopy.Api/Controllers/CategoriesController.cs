using Shopy.Core.Application.Categories.Add;
using Shopy.Core.Application.Categories.Get;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get(bool withProductsOnly = false)
        {
            var request = new ListCategoriesRequest()
            {
                WithProductsOnly = withProductsOnly
            };

            var items = await Mediator
                .RequestAsync<ListCategoriesRequest, ListCategoriesResponse>(request);

            return Ok(items);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]AddCategoryRequest addCategory)
        {
            var category = await Mediator.RequestAsync<AddCategoryRequest, AddCategoryResponse>(addCategory);

            return Ok(category);
        }
    }
}
