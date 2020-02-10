using MediatR;
using Shopy.Application.Sizes.Get;
using Shopy.Core.Logging;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    public class SizesController : BaseApiController
    {
        public SizesController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            return await ProcessRequest(
                request: () => Mediator.Send(new ListSizesRequest()));
        }
    }
}
