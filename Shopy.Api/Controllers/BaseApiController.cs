using Mediator.Net;
using Shopy.Api.Logging;
using Shopy.Core.Factory;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= MediatorFactory.GetMediator();

        protected async Task<IHttpActionResult> ProcessCommand(
            Func<Task> command,
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
                await command();
                return Ok();
            }

            catch (Exception e)
            {
                Logger.Instance.LogMessage(e.ToString());
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
                Logger.Instance.LogMessage(e.ToString());
                return InternalServerError(e);
            }
        }

    }
}
