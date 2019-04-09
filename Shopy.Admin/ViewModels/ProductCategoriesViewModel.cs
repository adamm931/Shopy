using System.Collections.Generic;

namespace Shopy.Admin.ViewModels
{
    public class ProductCategoriesViewModel
    {
        public IEnumerable<CategoryListItemViewModel> AssignedCategories { get; set; }

        public IEnumerable<CategoryListItemViewModel> AvailableCategories { get; set; }

    }
}