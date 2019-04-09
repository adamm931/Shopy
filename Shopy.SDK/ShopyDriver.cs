using Shopy.SDK.Client;
using Shopy.SDK.Images;
using Shopy.SDK.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.SDK
{
    public class ShopyDriver : IShopyDriver
    {
        private ProductsClient _products;
        private CategoriesClient _categories;
        private SizesClient _sizes;
        private BrandsClient _brands;
        private ImageProvider _imageProvider;

        public ShopyDriver(ShopyHttpClient client)
        {
            _products = new ProductsClient(client);
            _categories = new CategoriesClient(client);
            _sizes = new SizesClient(client);
            _brands = new BrandsClient(client);
            _imageProvider = new ImageProvider();
        }

        public async Task<ProductListResponse> ListProductsAsync(ProductFilter filter = null)
        {
            var list = await _products.ListAsync(filter);
            await list.SetUpImages(_imageProvider);

            return list;
        }

        public async Task<IEnumerable<Category>> ListCategoriesAsync()
        {
            return await _categories.ListAsync();
        }

        public async Task<Product> GetProductAsync(Guid uid)
        {
            var product = await _products.GetAsync(uid);
            return await product.SetUpImages(_imageProvider);
        }

        public async Task<Product> AddProductAsync(AddEditProduct product)
        {
            var result = await _products.AddAsync(product);
            product.Uid = result.Uid;
            await product.SaveImageAsync(_imageProvider);
            return await result.SetUpImages(_imageProvider);
        }

        public async Task EditProductAsync(AddEditProduct product)
        {
            await _products.EditAsync(product);
            await product.SaveImageAsync(_imageProvider);
        }

        public async Task AddProductToCategoryAsync(Guid productUid, Guid categoryUid)
        {
            await _products.AddToCategoryAsync(productUid, categoryUid);
        }

        public async Task RemoveProductFromCategoryAsync(Guid productUid, Guid categoryUid)
        {
            await _products.RemoveFromCategoryAsync(productUid, categoryUid);
        }

        public async Task DeleteProductAsync(Guid uid)
        {
            await _products.DeleteProductAsync(uid);
            await _imageProvider.DeleteImagesAsync(uid);
        }

        public async Task<ProductDetails> GetProductDetailsAsync(Guid uid)
        {
            var details = await _products.GetDetailsAsync(uid);
            return await details.SetUpImages(_imageProvider);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _categories.AddAsync(category);
        }

        public async Task<IEnumerable<Category>> ListCategoriesWithProductsAsync()
        {
            return await _categories.ListWithProductsAsync();
        }

        public async Task<IEnumerable<Size>> ListSizesAsync()
        {
            return await _sizes.ListAsync();
        }

        public async Task<IEnumerable<Brand>> ListBrandsAsync()
        {
            return await _brands.ListAsync();
        }

        public async Task DeleteCategoryAsync(Guid uid)
        {
            await _categories.DeleteAsync(uid);
        }
    }
}
