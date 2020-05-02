using AutoMapper;
using Shopy.Admin.ViewModels.Interfaces;
using Shopy.Sdk;
using Shopy.Sdk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Admin.ViewModels.Implementations
{
    public class CategoriesViewModelService : ICategoryViewModelService
    {
        private readonly IShopyDriver _shopy;
        private readonly IMapper _mapper;

        public CategoriesViewModelService(IShopyDriver shopy, IMapper mapper)
        {
            _shopy = shopy;
            _mapper = mapper;
        }

        public async Task AddCategory(CategoryViewModel model)
        {
            var addCategory = new Category
            {
                Name = model.Name
            };

            await _shopy.AddCategoryAsync(addCategory);
        }

        public async Task EditCategory(CategoryViewModel model)
        {
            var category = _mapper.Map<Category>(model);

            await _shopy.EditCategoryAsync(category);
        }

        public async Task<CategoryViewModel> GetCategory(Guid uid)
        {
            var category = await _shopy.GetCategoryAsync(uid);
            var viewModel = _mapper.Map<CategoryViewModel>(category);

            return viewModel;
        }

        public async Task<CategoryListViewModel> GetCategoryList()
        {
            var categories = await _shopy.ListCategoriesAsync();

            var viewModel = new CategoryListViewModel
            {
                Items = _mapper.Map<IEnumerable<CategoryListItemViewModel>>(categories)
            };

            return viewModel;
        }
    }
}