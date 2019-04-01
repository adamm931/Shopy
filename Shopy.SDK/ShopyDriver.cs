using Shopy.Sdk.Client;
using Shopy.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Sdk
{
    public class ShopyDriver : IShopyDriver
    {
        private ProductsClient _products;
        private CategoriesClient _categories;
        private SizesClient _sizes;
        private BrandsClient _brands;

        public ShopyDriver(ShopyHttpClient client)
        {
            _products = new ProductsClient(client);
            _categories = new CategoriesClient(client);
            _sizes = new SizesClient(client);
            _brands = new BrandsClient(client);
        }

        public async Task<IEnumerable<Product>> ListProductsAsync(ProductFilter filter = null)
        {
            return await _products.ListAsync(filter);
        }

        public async Task<IEnumerable<Category>> ListCategoriesAsync()
        {
            return await _categories.ListAsync();
        }

        public async Task<Product> GetProductAsync(Guid uid)
        {
            return await _products.GetAsync(uid);
        }

        public async Task AddProductAsync(Product product)
        {
            await _products.AddAsync(product);
        }

        public async Task EditProductAsync(Product product)
        {
            await _products.EditAsync(product);
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
        }

        public async Task<ProductDetails> GetProductDetailsAsync(Guid uid)
        {
            return await _products.GetDetailsAsync(uid);
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
    }
}
