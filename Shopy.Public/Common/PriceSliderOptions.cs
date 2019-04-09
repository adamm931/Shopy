using System;
using System.Configuration;

namespace Shopy.Public.Common
{
    public class PriceSliderOptions
    {
        public static int MinInitial { get; private set; }

        public static int MinEnd { get; private set; }

        public static int MaxInitial { get; private set; }

        public static int MaxEnd { get; private set; }

        static PriceSliderOptions()
        {
            var appSettings = ConfigurationManager.AppSettings;

            var rangeInitSetting = appSettings[PublicSettingsKeys.PriceRangeInit] ?? "10-500";
            var rangeSizeSetting = appSettings[PublicSettingsKeys.PriceRangeSize] ?? "10-1000";

            var rangeInit = rangeInitSetting.Split('-');
            var rangeSize = rangeSizeSetting.Split('-');

            MinInitial = Convert.ToInt32(rangeInit[0]);
            MinEnd = Convert.ToInt32(rangeSize[0]);
            MaxInitial = Convert.ToInt32(rangeInit[1]);
            MaxEnd = Convert.ToInt32(rangeSize[1]);
        }
    }
}