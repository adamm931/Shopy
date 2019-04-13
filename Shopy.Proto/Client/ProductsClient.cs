using Shopy.Proto.Models;
using System;
using System.Threading.Tasks;

namespace Shopy.Proto.Client
{
    public class ProductsClient
    {
        private ShopyHttpClient _client;

        public ProductsClient(ShopyHttpClient client)
        {
            _client = client;
        }

        public async Task<ProductListResponse> ListAsync(ProductFilter filter = null)
        {
            return await _client.GetAsync<ProductListResponse>($"products/{filter?.GetQueryString()}");
        }

        public async Task<Product> GetAsync(Guid uid)
        {
            var product = await _client.GetAsync<Response<Product>>($"products/{uid}");
            return product?.Result;
        }

        public async Task<ProductDetails> GetDetailsAsync(Guid uid)
        {
            var details = await _client.GetAsync<Response<ProductDetails>>($"products/{uid}/details");
            return details?.Result;
        }

        public async Task<Product> AddAsync(AddEditProduct product)
        {
            var addProduct = await _client.PostAsync<AddEditProduct, Response<Product>>("products", product);
            return addProduct.Result;
        }

        public async Task EditAsync(AddEditProduct product)
        {
            await _client.PutAsync($"products/{product.Uid}", product);
        }

        public async Task DeleteProductAsync(Guid uid)
        {
            await _client.DeleteAsync($"products/{uid}");
        }

        public async Task<object> RemoveFromCategoryAsync(Guid productUid, Guid categoryUid)
        {
            return await _client.PostAsync<object, object>($"products/{productUid}/remove-from-category/{categoryUid}");
        }

        public async Task<object> AddToCategoryAsync(Guid productUid, Guid categoryUid)
        {
            return await _client.PostAsync<object, object>($"products/{productUid}/add-to-category/{categoryUid}");

        }
    }
}