using Shopy.Application.Contants;
using Shopy.Application.Services;
using Shopy.Core.Files;
using Shopy.Core.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shopy.Api.Services
{
    public class FileUploader : IFileUploader
    {
        private readonly IHttpContextProvider _httpContextProvider;
        private readonly IFileProvider _fileProvider;
        private readonly ILogger _logger;

        public FileUploader(
            IHttpContextProvider httpContextProvider,
            ILogger logger,
            IFileProvider fileProvider)
        {
            _httpContextProvider = httpContextProvider;
            _logger = logger;
            _fileProvider = fileProvider;
        }

        public async Task UploadFile(HttpRequestMessage request)
        {
            var context = _httpContextProvider.Context;
            var root = context.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await request.Content.ReadAsMultipartAsync(provider);

                foreach (var file in provider.FileData)
                {
                    var destinationRelativePath = context.Request.Headers[HeaderContants.XDestination];
                    var destination = context.Server.MapPath($"~/{destinationRelativePath}");

                    _logger.Debug($"Saving image to path: {destinationRelativePath}");

                    _fileProvider.Move(file.LocalFileName, destination);

                    _logger.Debug($"Saved image to path: {destinationRelativePath}");
                }
            }

            catch (Exception e)
            {
                _logger.Critical(e.ToString());
                throw new Exception("Failed to upload image", e);
            }
        }
    }
}