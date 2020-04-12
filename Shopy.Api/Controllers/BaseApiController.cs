using MediatR;
using Shopy.Core.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    [Route("api/[controller]")]
    public class BaseApiController : ApiController
    {
        protected IMediator Mediator { get; }

        private ILogger Logger { get; }

        public BaseApiController(IMediator mediator, ILogger logger)
        {
            Mediator = mediator;
            Logger = logger;
        }

        protected async Task<IHttpActionResult> ProcessCommand(
            Func<Task> command,
            params RequestParamValidator[] paramValidators)
        {
            // Refactor this method into some pipeline

            var invalidParams = paramValidators?
                .Where(pv => pv.Rule());

            if (invalidParams.Any())
            {
                var message = string.Join(
                    ". ", invalidParams.Select(s => s.Message));
                return BadRequest(message);
            }

            try
            {
                await command();
                return Ok();
            }

            catch (Exception e)
            {
                Logger.Error(e);
                return InternalServerError(e);
            }
        }

        protected async Task<IHttpActionResult> ProcessRequest<T>(
            Func<Task<T>> request,
            params RequestParamValidator[] paramValidators)
        {
            var invalidParams = paramValidators?
                .Where(pv => pv.Rule());

            if (invalidParams.Any())
            {
                var message = string.Join(
                    ". ", invalidParams.Select(s => s.Message));

                return BadRequest(message);
            }

            try
            {
                var response = await request();

                if (response == null)
                {
                    return NotFound();
                }

                return Ok(response);
            }

            catch (Exception e)
            {
                Logger.Error(e);
                return InternalServerError(e);
            }
        }

    }
}
