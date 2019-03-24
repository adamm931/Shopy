using Shopy.Api.Application.Categories.Commands;
using Shopy.Api.Application.Products.Queries;
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

        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody]AddCategoryRequest addCategory)
        {
            var category = await Mediator.RequestAsync<AddCategoryRequest, AddCategoryResponse>(addCategory);

            return Ok(category);
        }

        [HttpPut]
        public void Put(int id, [FromBody]string value)
        { }

        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
