﻿using Shopy.Sdk.Models;
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
            var list = await _client.GetAsync<ListResponse<Product>>($"products/{filter?.GetQueryString()}");
            return list.Result;
        }

        public async Task<Product> GetAsync(Guid uid)
        {
            var product = await _client.GetAsync<Response<Product>>($"products/{uid}");
            return product.Result;
        }

        public async Task<ProductDetails> GetDetailsAsync(Guid uid)
        {
            var details = await _client.GetAsync<Response<ProductDetails>>($"products/{uid}/details");
            return details.Result;
        }

        public async Task<Product> AddAsync(AddEditProduct product)
        {
            var addProduct = await _client.PostAsync<AddEditProduct, Response<Product>>("products", product);
            return addProduct.Result;
        }

        public async Task<object> EditAsync(AddEditProduct product)
        {
            return await _client.PutAsync<AddEditProduct, object>($"products/{product.Uid}", product);
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