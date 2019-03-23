using Shopy.SDK.ApiModels.Categories;
using Shopy.SDK.Models.Categories;
using Shopy.SDK.Models.Products;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.SDK
{
    public interface IShopyProxy
    {
        Task<IEnumerable<Product>> ListProductsAsync();

        Task<IEnumerable<Category>> ListCategoriesAsync();

        Task<ProductDetails> GetProductDetailsAsync(Guid uid);

        Task AddProductAsync(AddProduct addProduct);

        Task AddCategoryAsync(AddCategory addProduct);

        Task EditProductAsync(EditProduct editProduct);

        Task AddProductToCategoryAsync(Guid productUid, Guid categoryUid);

        Task RemoveProductFromCategoryAsync(Guid productUid, Guid categoryUid);

        Task DeleteProductAsync(Guid uid);
    }
}
