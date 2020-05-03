using Shopy.Admin.Validation;
using Shopy.Sdk.Helpers;
using System.Web;

namespace Shopy.Admin.ViewModels
{
    public class ImageViewModel
    {
        [ImageFileValidation(SizeMB = 2)]
        public HttpPostedFileBase File { get; set; }

        public string Url { get; set; }

        public static ImageViewModel Empty = new ImageViewModel(ImageHelper.GetEmptyImageUrl());

        public ImageViewModel(string url)
        {
            Url = url;
        }

        public ImageViewModel()
        {
        }
    }
}