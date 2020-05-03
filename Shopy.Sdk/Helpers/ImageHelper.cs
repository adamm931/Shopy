using Shopy.Sdk.Common;
using Shopy.Sdk.Models;
using System;
using System.IO;
using System.Web;

namespace Shopy.Sdk.Helpers
{
    public class ImageHelper
    {
        public static void SaveImagesFromProduct(AddEditProduct product)
        {
            SaveImage(product.Image1, product.Uid, SettingsHelper.Image1Name);
            SaveImage(product.Image2, product.Uid, SettingsHelper.Image2Name);
            SaveImage(product.Image3, product.Uid, SettingsHelper.Image3Name);
        }

        public static string GetImageUrl(Guid productUid, string name)
        {
            var directory = GetImageDirectoryPath(productUid);
            var fullPath = Path.Combine(directory, name);

            return File.Exists(fullPath)
                ? GetImageUrlForName(productUid, name)
                : GetEmptyImageUrl();
        }

        public static void DeleteImages(Guid productUid)
        {
            var directoryPath = GetImageDirectoryPath(productUid);
            Directory.Delete(directoryPath, recursive: true);
        }

        public static string GetEmptyImageUrl()
        {
            return $"{SettingsHelper.ImageDirectoryUrl}/{SettingsHelper.EmptyImageName}";
        }

        private static void SaveImage(HttpPostedFileBase image, Guid productUid, string imageName)
        {
            if (image == null)
            {
                return;
            }

            var fullPath = GetImageFullPath(productUid, imageName);

            image.EnsureSave(fullPath);
        }

        private static string GetImageFullPath(Guid productUid, string imageName)
        {
            var directory = GetImageDirectoryPath(productUid);
            var fullPath = Path.Combine(directory, imageName);

            return fullPath;
        }

        private static string GetImageDirectoryPath(Guid productUid)
        {
            return Path.Combine(SettingsHelper.ImageDirectory, productUid.ToString());
        }

        private static string GetImageUrlForName(Guid productUid, string name)
        {
            return $"{SettingsHelper.ImageDirectoryUrl}/{productUid}/{name}";
        }


    }
}