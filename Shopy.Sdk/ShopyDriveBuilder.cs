using Shopy.Sdk.Client;
using Shopy.Sdk.Common;

namespace Shopy.Sdk
{
    public class ShopyDriveBuilder
    {
        public static IShopyDriver GetDriver()
        {
            // TODO: DI this
            var httpClient = new ShopyHttpClient(SettingsHelper.ApiBaseAddress);

            var products = new ProductsClient(httpClient);
            var categories = new CategoriesClient(httpClient);
            var brands = new BrandsClient(httpClient);
            var sizes = new SizesClient(httpClient);

            return new ShopyDriver(products, categories, sizes, brands);
        }
    }
}
