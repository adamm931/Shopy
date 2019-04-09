using Shopy.Admin.ViewModels;
using Shopy.SDK;
using System.Linq;
using System.Threading.Tasks;

namespace Shopy.Admin.ModelBuilder
{
    public class CategoryListModelBuilder : IModelBuilder<CategoryListViewModel>
    {
        private IShopyDriver _shopy;

        public CategoryListModelBuilder(IShopyDriver shopy)
        {
            _shopy = shopy;
        }
        public async Task<CategoryListViewModel> BuildAsync()
        {
            var categories = await _shopy.ListCategoriesAsync();

            var model = new CategoryListViewModel()
            {
                Items = categories.Select(c => new CategoryListItemViewModel()
                {
                    Uid = c.Uid,
                    CategoryId = c.CategoryId,
                    Caption = c.Caption
                })
            };

            return model;
        }
    }
}