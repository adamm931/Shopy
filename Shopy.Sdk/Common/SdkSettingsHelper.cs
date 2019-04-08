using System;
using System.Configuration;

namespace Shopy.Sdk.Common
{
    public class SdkSettingsHelper
    {
        private static KeyValueConfigurationCollection appSettings = GetAppSettings();

        public static string ApiBaseAddress
        {
            get
            {
                if (appSettings[SettingKeys.ApiBaseAddress] == null)
                {
                    throw new Exception("Api base address is not in sdk configuration file.");
                }

                var baseAddress = appSettings[SettingKeys.ApiBaseAddress]?.Value;

                return baseAddress.EndsWith("/") ? baseAddress : $"{baseAddress}/";
            }
        }

        public static string ImageDirectory
        {
            get
            {
                if (appSettings[SettingKeys.ImagesDirectory] == null)
                {
                    throw new Exception("Product image directory is not set in sdk configuration file.");
                }

                return appSettings[SettingKeys.ImagesDirectory]?.Value;
            }
        }

        public static string ImageDirectoryUrl
        {
            get
            {
                if (appSettings[SettingKeys.ImagesDirectoryUrl] == null)
                {
                    throw new Exception("Product image directory url is not set in sdk configuration file.");
                }

                return appSettings[SettingKeys.ImagesDirectoryUrl]?.Value;
            }
        }

        public static string EmptyImageName
        {
            get
            {
                return appSettings[SettingKeys.EmptyImageName]?.Value ?? "empty-img.png";
            }
        }

        public static string Image1Name
        {
            get
            {
                return appSettings[SettingKeys.Image1Name]?.Value ?? "main.png";
            }
        }

        public static string Image2Name
        {
            get
            {
                return appSettings[SettingKeys.Image2Name]?.Value ?? "second.png";
            }
        }

        public static string Image3Name
        {
            get
            {
                return appSettings[SettingKeys.Image3Name]?.Value ?? "third.png";
            }
        }

        private static KeyValueConfigurationCollection GetAppSettings()
        {
            var config = ConfigurationManager.OpenExeConfiguration(
                @"C:\DEV\DotNet\Web\Shopy\Shopy.SDK\bin\Debug\Shopy.Sdk.dll");

            if (config == null)
            {
                throw new Exception("Error occurred when opening sdk configuration file");
            }

            return config.AppSettings.Settings;
        }
    }
}
