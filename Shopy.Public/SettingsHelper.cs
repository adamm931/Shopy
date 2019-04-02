using System.Collections.Specialized;
using System.Configuration;

namespace Shopy.Public
{
    public class SettingsHelper
    {
        private const string ProductImage1TemplateUrlKey = "ProductImage1UrlTemplate";
        private const string ProductImage2TemplateUrlKey = "ProductImage2UrlTemplate";
        private const string ProductImage3TemplateUrlKey = "ProductImage3UrlTemplate";

        private static NameValueCollection appSettings = ConfigurationManager.AppSettings;

        public static string ProductImage1TemplateUrl
        {
            get
            {
                return appSettings[ProductImage1TemplateUrlKey] ?? string.Empty;
            }
        }

        public static string ProductImage2TemplateUrl
        {
            get
            {
                return appSettings[ProductImage2TemplateUrlKey] ?? string.Empty;
            }
        }

        public static string ProductImage3TemplateUrl
        {
            get
            {
                return appSettings[ProductImage3TemplateUrlKey] ?? string.Empty;
            }
        }
    }
}