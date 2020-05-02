using Shopy.Admin.Validation;
using Shopy.Sdk.Common;
using System.Web;

namespace Shopy.Admin.ViewModels
{
    public class ImageViewModel
    {
        [ImageFileValidation(SizeMB = 2)]
        public HttpPostedFileBase File { get; set; }

        public string Url { get; set; }

        public static ImageViewModel Empty = new ImageViewModel(
            $@"{ProtoSettingsHelper.ImageDirectoryUrl}\{ProtoSettingsHelper.EmptyImageName}");

        public ImageViewModel(string url)
        {
            Url = url;
        }

        public ImageViewModel()
        {

        }

        private ImageViewModel(ImageViewModel model)
        {
            Url = model.Url;
        }

        public ImageViewModel Clone()
        {
            return new ImageViewModel(this);
        }
    }
}