using Shopy.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Sdk
{
    public interface IShopyDriver
    {
        #region Categories

        Task<IEnumerable<CategoryLookup>> LookupCategories();

        Task<IEnumerable<Category>> ListCategories();

        Task<Category> GetCategory(Guid uid);

        Task<Category> AddCategory(Category category);

        Task EditCategory(Category category);

        Task DeleteCategory(Guid uid);

        #endregion

        #region Products

        Task<ProductListResponse> ListProducts(ProductFilter filter = null);

        Task<ProductDetails> GetProductDetails(Guid uid);

        Task<Product> GetProduct(Guid uid);

        Task AddProduct(AddEditProduct product);

        Task EditProduct(AddEditProduct product);

        Task AddProductToCategory(Guid productUid, Guid categoryUid);

        Task RemoveProductFromCategory(Guid productUid, Guid categoryUid);

        Task DeleteProduct(Guid uid);

        #endregion

        #region Brands and Sizes

        Task<IEnumerable<Size>> ListSizes();

        Task<IEnumerable<Brand>> ListBrands();

        #endregion
    }
}
