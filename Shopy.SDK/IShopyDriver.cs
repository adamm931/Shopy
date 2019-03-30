using Shopy.SDK.ApiModels;
using Shopy.SDK.ApiModels.Categories;
using Shopy.SDK.ApiModels.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.SDK
{
    public interface IShopyDriver
    {
        Task<IEnumerable<Product>> ListProductsAsync(ProductFilter filter = null);

        Task<IEnumerable<Category>> ListCategoriesAsync();

        Task<IEnumerable<Category>> ListCategoriesWithProductsAsync();

        Task<ProductDetails> GetProductDetailsAsync(Guid uid);

        Task AddProductAsync(AddProduct addProduct);

        Task AddCategoryAsync(AddCategory addProduct);

        Task EditProductAsync(EditProduct editProduct);

        Task AddProductToCategoryAsync(Guid productUid, Guid categoryUid);

        Task RemoveProductFromCategoryAsync(Guid productUid, Guid categoryUid);

        Task DeleteProductAsync(Guid uid);

        Task<IEnumerable<Size>> ListSizesAsync();

        Task<IEnumerable<Brand>> ListBrandsAsync();

    }
}
