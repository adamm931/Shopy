using Shopy.Admin.ViewModels;
using System;
using System.IO;
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

        public void SavePostedImages(ProductViewModel model, Guid productUid)
        {
            var relativePath =
                $@"~/{Constants.ProductImageRootTemplate.Replace("{{productUid}}", productUid.ToString())}";

            var serverPath = _httpContext.Server.MapPath(relativePath);

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
        }

        public string GetImageUrl(Guid productUid, string name)
        {
            var productImageDir = Constants.ProductImageRootTemplate
                .Replace("{{productUid}}", productUid.ToString());

            var relativePath = $@"{productImageDir}/{name}";
            var serverPath = _httpContext.Server.MapPath("~/" + relativePath);

            var url = File.Exists(serverPath)
                ? relativePath
                : Constants.ProductImageEmptytUrl;

            return url;
        }
    }
}