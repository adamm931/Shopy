using Shopy.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Sdk.Client
{
    public class ProductsClient
    {
        private ShopyHttpClient _client;

        public ProductsClient(ShopyHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Product>> ListAsync(ProductFilter filter = null)
        {
            var list = await _client.GetAsync<ListResult<Product>>($"products/{filter?.GetQueryString()}");
            return list.Result;
        }

        public async Task<Product> GetAsync(Guid uid)
        {
            return await _client.GetAsync<Product>($"products/{uid}");
        }

        public async Task<ProductDetails> GetDetailsAsync(Guid uid)
        {
            return await _client.GetAsync<ProductDetails>($"products/details/{uid}");
        }

        public async Task<object> AddAsync(Product product)
        {
            return await _client.PostAsync<Product, object>("products", product);
        }

        public async Task<object> EditAsync(Product product)
        {
            return await _client.PutAsync<Product, object>($"products/{product.Uid}", product);
        }

        public async Task<object> DeleteProductAsync(Guid uid)
        {
            return await _client.DeleteAsync<object>($"products/{uid}");
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