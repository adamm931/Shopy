using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace Shopy.Admin.Validation
{
    public class ImageFileValidationAttribute : ValidationAttribute
    {
        public int SizeMB { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var imageFile = value as HttpPostedFileBase;

            if (imageFile == null)
            {
                return ValidationResult.Success;
            }

            if (imageFile.ContentLength > (SizeMB * 1024 * 1024))
            {
                return new ValidationResult($"Image file exceeds the maximum size of {SizeMB} MB");
            }

            if (!HasImageFormat(imageFile))
            {
                var validFormats = "jpg, png, bmp, gif, jpeg";
                return new ValidationResult($"Image file is not in valid format. The valid formats are {validFormats}");
            }

            return ValidationResult.Success;
        }

        private bool HasImageFormat(HttpPostedFileBase imageFile)
        {
            try
            {
                var img = Image.FromStream(imageFile.InputStream);

                if (img.RawFormat.Equals(ImageFormat.Png)
                    || img.RawFormat.Equals(ImageFormat.Jpeg)
                    || img.RawFormat.Equals(ImageFormat.Gif)
                    || img.RawFormat.Equals(ImageFormat.Bmp))
                {
                    return true;
                }
            }

            catch
            {
                return false;
            }

            return false;
        }
    }
}