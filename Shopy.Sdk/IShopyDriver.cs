using Shopy.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Sdk
{
    public interface IShopyDriver
    {
        #region Categories

        Task<IEnumerable<Category>> ListCategoriesAsync();

        Task<IEnumerable<Category>> ListCategoriesWithProductsAsync();

        Task<Category> GetCategoryAsync(Guid uid);

        Task<Category> AddCategoryAsync(Category category);

        Task EditCategoryAsync(Category category);

        Task DeleteCategoryAsync(Guid uid);

        #endregion

        #region Products

        Task<ProductListResponse> ListProductsAsync(ProductFilter filter = null);

        Task<ProductDetails> GetProductDetailsAsync(Guid uid);

        Task<Product> GetProductAsync(Guid uid);

        Task<Product> AddProductAsync(AddEditProduct product);
    
        Task EditProductAsync(AddEditProduct product);

        Task AddProductToCategoryAsync(Guid productUid, Guid categoryUid);

        Task RemoveProductFromCategoryAsync(Guid productUid, Guid categoryUid);

        Task DeleteProductAsync(Guid uid);

        #endregion

        #region Brands and Sizes

        Task<IEnumerable<Size>> ListSizesAsync();

        Task<IEnumerable<Brand>> ListBrandsAsync();

        #endregion
    }
}
