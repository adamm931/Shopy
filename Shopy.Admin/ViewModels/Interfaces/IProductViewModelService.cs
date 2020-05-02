using System;
using System.Threading.Tasks;

namespace Shopy.Admin.ViewModels.Interfaces
{
    public interface IProductViewModelService
    {
        Task<ProductViewModel> GetProduct(Guid uid);

        Task<ProductListViewModel> GetProductList();

        Task<ProductViewModel> GetEmptyProduct();

        Task<ProductViewModel> PopulateProduct(ProductViewModel product);

        Task AddProduct(ProductViewModel product);

        Task EditProduct(ProductViewModel product);

        Task<ChangeProductCategoriesViewModel> GetProductCategoryChange(Guid uid);

        Task<ProductCategoriesViewModel> GetProductCategories(Guid uid);
    }
}
