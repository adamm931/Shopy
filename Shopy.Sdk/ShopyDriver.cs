using Shopy.Sdk.Client;
using Shopy.Sdk.Helpers;
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

        public ShopyDriver(
            ProductsClient productsClient,
            CategoriesClient categoriesClient,
            SizesClient sizesClient,
            BrandsClient brandsClient)
        {
            _productsClient = productsClient;
            _categoriesClient = categoriesClient;
            _sizesClient = sizesClient;
            _brandsClient = brandsClient;
        }

        public async Task<ProductListResponse> ListProducts(ProductFilter filter = null)
        {
            var products = await _productsClient.ListAsync(filter);

            return products;
        }

        public async Task<IEnumerable<Category>> ListCategories()
        {
            return await _categoriesClient.ListAsync();
        }

        public async Task<Product> GetProduct(Guid uid)
        {
            return await _productsClient.GetAsync(uid);
        }

        public async Task AddProduct(AddEditProduct product)
        {
            var result = await _productsClient.AddAsync(product);
            product.Uid = result.Uid;
            ImageHelper.SaveImagesFromProduct(product);
        }

        public async Task EditProduct(AddEditProduct product)
        {
            await _productsClient.EditAsync(product);
            ImageHelper.SaveImagesFromProduct(product);
        }

        public async Task AddProductToCategory(Guid productUid, Guid categoryUid)
        {
            await _productsClient.AddToCategoryAsync(productUid, categoryUid);
        }

        public async Task RemoveProductFromCategory(Guid productUid, Guid categoryUid)
        {
            await _productsClient.RemoveFromCategoryAsync(productUid, categoryUid);
        }

        public async Task DeleteProduct(Guid uid)
        {
            await _productsClient.DeleteProductAsync(uid);
            ImageHelper.DeleteImages(uid);
        }

        public async Task<ProductDetails> GetProductDetails(Guid uid)
        {
            var details = await _productsClient.GetDetailsAsync(uid);
            return details;
        }

        public async Task<IEnumerable<Size>> ListSizes()
        {
            return await _sizesClient.ListAsync();
        }

        public async Task<IEnumerable<Brand>> ListBrands()
        {
            return await _brandsClient.ListAsync();
        }

        public async Task DeleteCategory(Guid uid)
        {
            await _categoriesClient.DeleteAsync(uid);
        }

        public async Task<Category> GetCategory(Guid uid)
        {
            return await _categoriesClient.GetAsync(uid);
        }

        public async Task<Category> AddCategory(Category category)
        {
            return await _categoriesClient.AddAsync(category);
        }

        public async Task EditCategory(Category category)
        {
            await _categoriesClient.EditAsync(category);
        }

        public async Task<IEnumerable<CategoryLookup>> LookupCategories()
        {
            return await _categoriesClient.LookupAsync();
        }
    }
}
