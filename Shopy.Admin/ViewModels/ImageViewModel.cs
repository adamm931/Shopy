using Shopy.Admin.Validation;
using System.Web;

namespace Shopy.Admin.ViewModels
{
    public class ImageViewModel
    {
        [ImageFile("jpg,png,jpeg", 2)]
        public HttpPostedFileBase File { get; set; }

        public string Url { get; set; }

        public static ImageViewModel Empty = new ImageViewModel(Constants.ProductImageEmptytUrl);
        public ImageViewModel(string url)
        {
            Url = url;
        }
        public ImageViewModel()
        {

        }
    }
}