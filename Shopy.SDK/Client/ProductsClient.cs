﻿using Shopy.SDK.Models.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.SDK.Client
{
    public class ProductsClient
    {
        private ShopyHttpClient _client;

        public ProductsClient()
        {
            _client = new ShopyHttpClient();
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            var list = await _client.GetAsync<ProductList>("products");
            return list.Result;
        }

        public async Task<ProductDetails> GetDetailsAsync(Guid uid)
        {
            return await _client.GetAsync<ProductDetails>($"products/{uid}");
        }

        public async Task<object> AddAsync(AddProduct addProduct)
        {
            return await _client.PostAsync<AddProduct, object>("products", addProduct);
        }

        public async Task<object> EditAsync(EditProduct editProduct)
        {
            return await _client.PutAsync<EditProduct, object>($"products/{editProduct.Uid}", editProduct);
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