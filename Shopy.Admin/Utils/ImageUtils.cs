using Shopy.Admin.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace Shopy.Admin.Utils
{
    public class ImageUtlis
    {
        private HttpContextBase _httpContext;

        public ImageUtlis(HttpContextBase httpContext)
        {
            _httpContext = httpContext;
        }

        public async Task SavePostedImagesAsync(ProductViewModel model, Guid productUid)
        {
            await Task.Run(() =>
            {

                var directoryPath = GetImageDirectoryPath(productUid);
                var serverPath = _httpContext.Server.MapPath($"~/{directoryPath}");

                if (!Directory.Exists(serverPath))
                {
                    Directory.CreateDirectory(serverPath);
                }

                if (model.Image1.File != null)
                {
                    model.Image1.File.SaveAs(Path.Combine(serverPath, Constants.Image1));
                }

                if (model.Image2.File != null)
                {
                    model.Image2.File.SaveAs(Path.Combine(serverPath, Constants.Image2));
                }

                if (model.Image3.File != null)
                {
                    model.Image3.File.SaveAs(Path.Combine(serverPath, Constants.Image3));
                }
            });
        }

        public async Task<string> GetImageUrl(Guid productUid, string name)
        {
            return await Task.Run(() =>
            {
                var productImageDir = GetImageDirectoryPath(productUid);

                var relativePath = $"{productImageDir}/{name}";
                var serverPath = _httpContext.Server.MapPath("~/" + relativePath);

                return File.Exists(serverPath)
                    ? relativePath
                    : Constants.ProductImageEmptytUrl;
            });
        }

        public async Task DeleteImagesAsync(Guid productUid)
        {
            await Task.Run(() =>
            {
                var directoryPath = GetImageDirectoryPath(productUid);
                Directory.Delete(directoryPath);
            });
        }

        private string GetImageDirectoryPath(Guid uid)
        {
            return Constants.ProductImageRootTemplate
                     .Replace("{{productUid}}", uid.ToString());
        }
    }
}