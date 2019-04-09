using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Mvc;

namespace Shopy.Admin.Validation
{
    public class ImageFileValidationAttribute : ValidationAttribute, IClientValidatable
    {
        public int SizeMB { get; set; }

        private string MessageForSize
        {
            get
            {
                return $"Image file exceeds the maximum size of {SizeMB} MB";
            }
        }

        private int SizeBytes
        {
            get
            {
                return SizeMB * 1024 * 1024;
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var imageFile = value as HttpPostedFileBase;

            if (imageFile == null)
            {
                return ValidationResult.Success;
            }

            if (imageFile.ContentLength > (SizeBytes))
            {
                return new ValidationResult(MessageForSize);
            }

            if (!HasImageFormat(imageFile))
            {
                var validFormats = "jpg, png, bmp, gif, jpeg";
                return new ValidationResult($"Image file is not in valid format. The valid formats are {validFormats}");
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule()
            {
                ErrorMessage = MessageForSize,
                ValidationType = "imagefilevalidation"
            };

            rule.ValidationParameters.Add("size", SizeBytes);
            rule.ValidationParameters.Add("text", 123);


            return new[] { rule };
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