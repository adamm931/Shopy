﻿using Shopy.SDK.ApiModels;
using Shopy.SDK.ApiModels.Categories;
using Shopy.SDK.ApiModels.Products;
using Shopy.SDK.Client;
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

        public async Task GetProductAsycn(AddProduct addProduct)
        {
            await _products.AddAsync(addProduct);
        }

        public async Task AddProductAsync(AddProduct addProduct)
        {
            await _products.AddAsync(addProduct);
        }

        public async Task EditProductAsync(EditProduct editProduct)
        {
            await _products.EditAsync(editProduct);
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

        public async Task AddCategoryAsync(AddCategory addCategory)
        {
            await _categories.AddAsync(addCategory);
        }

        public async Task<IEnumerable<Category>> ListCategoriesWithProductsAsync()
        {
            return await _categories.ListWithProductsAsync();
        }

        public async Task<IEnumerable<SizeType>> ListSizesAsync()
        {
            return await _sizes.ListAsync();
        }

        public async Task<IEnumerable<BrandType>> ListBrandsAsync()
        {
            return await _brands.ListAsync();
        }
    }
}
