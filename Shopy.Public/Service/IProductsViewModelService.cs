using Shopy.Public.ViewModels;
using Shopy.Sdk.Models;
using System;
using System.Threading.Tasks;

namespace Shopy.Public.Service
{
    public interface IProductsViewModelService
    {
        Task<ProductFiltersViewModel> GetFilters();

        Task<PagedListViewModel<ProductViewModel>> FilterProducts(ProductFilter filter);

        Task<ProductDetailsViewModel> GetProductDetails(Guid uid);
    }
}
