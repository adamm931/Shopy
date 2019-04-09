using Shopy.Proto.Client;
using Shopy.Proto.Common;

namespace Shopy.Proto
{
    public class ShopyDriveBuilder
    {
        public IShopyDriver Configure()
        {
            var httpClient = new ShopyHttpClient(ProtoSettingsHelper.ApiBaseAddress);
            return new ShopyDriver(httpClient);
        }
    }
}
