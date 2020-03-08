using MediatR;
using Shopy.Application.Identity.Login;
using Shopy.Core.Logging;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    public class IdentityController : BaseApiController
    {
        public IdentityController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpPost]
        [ActionName("login")]
        public async Task<IHttpActionResult> Login([FromBody] IdentityLoginRequest loginRequest)
        {
            return await ProcessRequest(
                request: () => Mediator.Send(loginRequest));
        }
    }
}