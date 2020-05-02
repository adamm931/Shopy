using System;
using System.Threading.Tasks;

namespace Shopy.Admin.ViewModels.Interfaces
{
    public interface ICategoryViewModelService
    {
        Task AddCategory(CategoryViewModel model);

        Task EditCategory(CategoryViewModel model);

        Task<CategoryListViewModel> GetCategoryList();

        Task<CategoryViewModel> GetCategory(Guid uid);
    }
}
