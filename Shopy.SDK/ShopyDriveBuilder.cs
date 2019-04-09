using Shopy.SDK.Client;
using Shopy.SDK.Common;

namespace Shopy.SDK
{
    public class ShopyDriveBuilder
    {
        public IShopyDriver Configure()
        {
            var httpClient = new ShopyHttpClient(SDKSettingsHelper.ApiBaseAddress);
            return new ShopyDriver(httpClient);
        }
    }
}
