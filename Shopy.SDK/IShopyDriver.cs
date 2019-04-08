using Shopy.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Sdk
{
    public interface IShopyDriver
    {
        Task<ProductListResponse> ListProductsAsync(ProductFilter filter = null);

        Task<IEnumerable<Category>> ListCategoriesAsync();

        Task<IEnumerable<Category>> ListCategoriesWithProductsAsync();

        Task<ProductDetails> GetProductDetailsAsync(Guid uid);

        Task<Product> GetProductAsync(Guid uid);

        Task<Product> AddProductAsync(AddEditProduct product);

        Task AddCategoryAsync(Category category);

        Task EditProductAsync(AddEditProduct product);

        Task AddProductToCategoryAsync(Guid productUid, Guid categoryUid);

        Task RemoveProductFromCategoryAsync(Guid productUid, Guid categoryUid);

        Task DeleteProductAsync(Guid uid);

        Task<IEnumerable<Size>> ListSizesAsync();

        Task<IEnumerable<Brand>> ListBrandsAsync();
    }
}
