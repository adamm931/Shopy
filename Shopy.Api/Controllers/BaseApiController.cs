using Mediator.Net;
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
        protected IMediator Mediator
        {
            get
            {
                return _mediator ?? (_mediator = MediatorFactory.GetMediator());
            }
        }

        protected async Task<IHttpActionResult> ProcessCommand(
            Func<Task> command,
            params RequestParamValidator[] paramValidators)
        {
            var invalidParam = paramValidators?
                .FirstOrDefault(pv => !pv.Rule());

            if (invalidParam != null)
            {
                return BadRequest(invalidParam.Message);
            }

            try
            {
                await command();
                return Ok();
            }

            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        protected async Task<IHttpActionResult> ProcessRequest<T>(
            Func<Task<T>> request,
            params RequestParamValidator[] paramValidators)
        {
            var invalidParam = paramValidators?
                .FirstOrDefault(pv => !pv.Rule());

            if (invalidParam != null)
            {
                return BadRequest(invalidParam.Message);
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
                return InternalServerError(e);
            }
        }

    }
}
