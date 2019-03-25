using Shopy.SDK.Client;

namespace Shopy.SDK
{
    public class ShopyDriveBuilder
    {
        private string baseAddress;

        public ShopyDriveBuilder WithBaseAddress(string baseAddress)
        {
            if (string.IsNullOrWhiteSpace(baseAddress))
            {
                throw new System.ArgumentNullException(baseAddress);
            }

            this.baseAddress = baseAddress.EndsWith("/") ? baseAddress : $"{baseAddress}/";
            return this;
        }

        public IShopyDriver Build()
        {
            var httpClient = new ShopyHttpClient(this.baseAddress);
            return new ShopyDriver(httpClient);
        }
    }
}
