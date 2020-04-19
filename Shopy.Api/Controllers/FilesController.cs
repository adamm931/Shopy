using MediatR;
using Shopy.Application.Images.Upload;
using Shopy.Core.Logging;
using System.Threading.Tasks;
using System.Web.Http;

namespace Shopy.Api.Controllers
{
    public class FilesController : BaseApiController
    {
        public FilesController(IMediator mediator, ILogger logger) : base(mediator, logger)
        {
        }

        [HttpPost]
        [ActionName("upload")]
        public async Task<IHttpActionResult> Upload()
        {
            return await ProcessRequest(
                 request: () => Mediator.Send(new UploadFileFromContextRequest(Request)));
        }
    }
}
