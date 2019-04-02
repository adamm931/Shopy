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
            return await ProcessRequest(
                request: () => Mediator.RequestAsync<ListBrandsRequest, ListBrandsResponse>(new ListBrandsRequest()));
        }
    }
}
