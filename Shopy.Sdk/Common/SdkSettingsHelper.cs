using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Shopy.Sdk.Common
{
    public class ProtoSettingsHelper
    {
        private static KeyValueConfigurationCollection appSettings = GetAppSettings();

        public static string ApiBaseAddress
        {
            get
            {
                if (appSettings[SettingKeys.ApiBaseAddress] == null)
                {
                    throw new Exception("Api base address is not in Proto configuration file.");
                }

                var baseAddress = appSettings[SettingKeys.ApiBaseAddress]?.Value;

                return baseAddress.EndsWith("/") ? baseAddress : $"{baseAddress}/";
            }
        }


        private static string imageDirectory;
        public static string ImageDirectory
        {
            get
            {
                if (imageDirectory == null)
                {
                    var assembly = Assembly.GetExecutingAssembly().GetName();
                    var binPath = Path.GetDirectoryName(assembly.CodeBase).Substring(6);
                    string directoryName = appSettings[SettingKeys.ImagesRootDirectoryName]?.Value ?? "Images";
                    imageDirectory = Path.GetFullPath(
                        Path.Combine(binPath, $@"..\..\Shopy.Api\{directoryName}"));
                }

                return imageDirectory;
            }
        }

        public static string ImageDirectoryUrl
        {
            get
            {
                if (appSettings[SettingKeys.ImagesDirectoryUrl] == null)
                {
                    throw new Exception("Product image directory url is not set in Proto configuration file.");
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
            var assembly = Assembly.GetExecutingAssembly().GetName();
            var binPath = Path.GetDirectoryName(assembly.CodeBase).Substring(6);
            var exeConfigPath = Path.Combine(binPath, $"{assembly.Name}.dll");

            var config = ConfigurationManager.OpenExeConfiguration(exeConfigPath);

            if (config == null)
            {
                throw new Exception("Error occurred when opening Proto configuration file");
            }

            return config.AppSettings.Settings;
        }
    }
}
