using Mediator.Net;
using Shopy.Api.Factory;
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

    }
}
