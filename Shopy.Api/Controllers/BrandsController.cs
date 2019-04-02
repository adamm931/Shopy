using Shopy.Core.Application.Brands.Get;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    public class BrandsController : BaseApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            var items = await Mediator
                .RequestAsync<ListBrandsRequest, ListBrandsResponse>(new ListBrandsRequest());

            return Ok(items);
        }
    }
}
