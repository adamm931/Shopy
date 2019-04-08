using Shopy.Sdk.Client;
using Shopy.Sdk.Common;

namespace Shopy.Sdk
{
    public class ShopyDriveBuilder
    {
        public IShopyDriver Configure()
        {
            var httpClient = new ShopyHttpClient(SdkSettingsHelper.ApiBaseAddress);
            return new ShopyDriver(httpClient);
        }
    }
}
