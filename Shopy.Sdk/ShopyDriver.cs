using Shopy.Sdk.Client;
using Shopy.Sdk.Images;
using Shopy.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Sdk
{
    public class ShopyDriver : IShopyDriver
    {
        private readonly ProductsClient _productsClient;
        private readonly CategoriesClient _categoriesClient;
        private readonly SizesClient _sizesClient;
        private readonly BrandsClient _brandsClient;
        private readonly ImageProvider _imageProvider;

        public ShopyDriver(
            ProductsClient productsClient,
            CategoriesClient categoriesClient,
            SizesClient sizesClient,
            BrandsClient brandsClient,
            ImageProvider imageProvider)
        {
            _productsClient = productsClient;
            _categoriesClient = categoriesClient;
            _sizesClient = sizesClient;
            _brandsClient = brandsClient;
            _imageProvider = imageProvider;
        }

        public async Task<ProductListResponse> ListProductsAsync(ProductFilter filter = null)
        {
            var list = await _productsClient.ListAsync(filter);
            await list.SetUpImages(_imageProvider);

            return list;
        }

        public async Task<IEnumerable<Category>> ListCategoriesAsync()
        {
            return await _categoriesClient.ListAsync();
        }

        public async Task<Product> GetProductAsync(Guid uid)
        {
            var product = await _productsClient.GetAsync(uid);
            return await product.SetUpImages(_imageProvider);
        }

        public async Task<Product> AddProductAsync(AddEditProduct product)
        {
            var result = await _productsClient.AddAsync(product);
            product.Uid = result.Uid;
            await product.SaveImageAsync(_imageProvider);
            return await result.SetUpImages(_imageProvider);
        }

        public async Task EditProductAsync(AddEditProduct product)
        {
            await _productsClient.EditAsync(product);
            await product.SaveImageAsync(_imageProvider);
        }

        public async Task AddProductToCategoryAsync(Guid productUid, Guid categoryUid)
        {
            await _productsClient.AddToCategoryAsync(productUid, categoryUid);
        }

        public async Task RemoveProductFromCategoryAsync(Guid productUid, Guid categoryUid)
        {
            await _productsClient.RemoveFromCategoryAsync(productUid, categoryUid);
        }

        public async Task DeleteProductAsync(Guid uid)
        {
            await _productsClient.DeleteProductAsync(uid);
            await _imageProvider.DeleteImagesAsync(uid);
        }

        public async Task<ProductDetails> GetProductDetailsAsync(Guid uid)
        {
            var details = await _productsClient.GetDetailsAsync(uid);
            return await details.SetUpImages(_imageProvider);
        }

        public async Task<IEnumerable<Category>> ListCategoriesWithProductsAsync()
        {
            return await _categoriesClient.ListWithProductsAsync();
        }

        public async Task<IEnumerable<Size>> ListSizesAsync()
        {
            return await _sizesClient.ListAsync();
        }

        public async Task<IEnumerable<Brand>> ListBrandsAsync()
        {
            return await _brandsClient.ListAsync();
        }

        public async Task DeleteCategoryAsync(Guid uid)
        {
            await _categoriesClient.DeleteAsync(uid);
        }

        public async Task<Category> GetCategoryAsync(Guid uid)
        {
            return await _categoriesClient.GetAsync(uid);
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            return await _categoriesClient.AddAsync(category);
        }

        public async Task EditCategoryAsync(Category category)
        {
            await _categoriesClient.EditAsync(category);
        }
    }
}
