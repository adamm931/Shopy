using Shopy.Core.Application.Products.Queries;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    public class SizesController : BaseApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var items = await Mediator
                .RequestAsync<ListSizesRequest, ListSizesResponse>(new ListSizesRequest());

            return Ok(items);
        }
    }
}
