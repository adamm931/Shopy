using MediatR;
using Shopy.Application.Services;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.Application.Images.Upload
{
    public class UploadFileFromContextRequestHandler : IRequestHandler<UploadFileFromContextRequest>
    {
        private readonly IFileUploader _fileUploader;

        public UploadFileFromContextRequestHandler(IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
        }

        public async Task<Unit> Handle(UploadFileFromContextRequest request, CancellationToken cancellationToken)
        {
            await _fileUploader.UploadFile(request.Request);

            return Unit.Value;
        }
    }
}
