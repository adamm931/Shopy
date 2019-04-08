using Shopy.Sdk.Common;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;

namespace Shopy.Sdk.Images
{
    public class ImageProvider
    {
        public async Task SaveImageAsync(HttpPostedFileBase postedImage, Guid productUid, string name)
        {
            await Task.Run(() =>
            {
                if (postedImage == null)
                {
                    return;
                }

                var directoryPath = GetImageDirectoryPath(productUid);

                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                postedImage.SaveAs(Path.Combine(directoryPath, name));
            });
        }

        public async Task<string> GetImageUrl(Guid productUid, string name)
        {
            return await Task.Run(() =>
            {
                var imagePath = Path.Combine(GetImageDirectoryPath(productUid), name);

                return File.Exists(imagePath)
                    ? GetImageUrlForName(productUid, name)
                    : GetEmptyImageUrl();
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

        private string GetImageDirectoryPath(Guid productUid)
        {
            return Path.Combine(SdkSettingsHelper.ImageDirectory, productUid.ToString());
        }

        private string GetImageUrlForName(Guid productUid, string name)
        {
            return $"{SdkSettingsHelper.ImageDirectoryUrl}/{productUid}/{name}";
        }

        private string GetEmptyImageUrl()
        {
            return $"{SdkSettingsHelper.ImageDirectoryUrl}/{SdkSettingsHelper.EmptyImageName}";
        }
    }
}