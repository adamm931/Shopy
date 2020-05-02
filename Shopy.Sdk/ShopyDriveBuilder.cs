using Shopy.Sdk.Client;
using Shopy.Sdk.Common;
using Shopy.Sdk.Images;

namespace Shopy.Sdk
{
    public class ShopyDriveBuilder
    {
        public static IShopyDriver GetDriver()
        {
            // TODO: DI this
            var httpClient = new ShopyHttpClient(ProtoSettingsHelper.ApiBaseAddress);

            var products = new ProductsClient(httpClient);
            var categories = new CategoriesClient(httpClient);
            var brands = new BrandsClient(httpClient);
            var sizes = new SizesClient(httpClient);
            var imageProvider = new ImageProvider();

            return new ShopyDriver(products, categories, sizes, brands, imageProvider);
        }
    }
}
